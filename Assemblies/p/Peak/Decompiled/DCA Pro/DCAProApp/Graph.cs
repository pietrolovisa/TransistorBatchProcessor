// Decompiled with JetBrains decompiler
// Type: DCAProApp.Graph
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using DCAPro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using ZedGraph;

#nullable disable
namespace DCAProApp;

internal abstract class Graph
{
  internal const DashStyle TraceLockedStyle = DashStyle.Dash;
  internal const DashStyle TraceUnlockedStyle = DashStyle.Solid;
  internal const float BJT_IB_MIN_GRAPH = 0.0f;
  internal const float BJT_IB_HFE_LIMIT = 4f;
  internal const float BJT_IB_MAX_GRAPH = 10000f;
  internal static readonly Color[] Palete = new Color[16 /*0x10*/]
  {
    Color.Red,
    Color.DarkRed,
    Color.Green,
    Color.Lime,
    Color.Blue,
    Color.Cyan,
    Color.Magenta,
    Color.Salmon,
    Color.Gold,
    Color.DarkGoldenrod,
    Color.LightSlateGray,
    Color.BlueViolet,
    Color.Teal,
    Color.SaddleBrown,
    Color.DarkSlateBlue,
    Color.DarkOliveGreen
  };
  internal Graph.Types Type;
  internal Test.TYPE TestType;
  internal frmDCAProApp theForm;
  internal ToolStripMenuItem theMenuItem;
  internal GraphPanel thisPanel;
  internal string GraphType = "";
  internal Test.CONFIG thisConfig;
  internal bool ValuesUserModified;
  internal ZedGraphControl thisZedGraph;
  internal Button thisStartButton;
  internal Button thisAutosetButton;
  internal CheckBox thisCheckLockParameters;
  internal CheckBox thisCheckLog;
  internal double MinYSpan = 2.0;
  internal double MinYSpanRound = 0.5;
  internal double MinY2Span = 2.0;
  internal double MinY2SpanRound = 0.5;
  internal double MinXSpan = 2.0;
  internal double MinXSpanRound = 0.5;
  internal int CurrentColor = -1;
  internal string XAxisUnits = "";
  internal string YAxisUnits = "";
  internal string Y2AxisUnits = "";
  internal string PointTooltip = "";
  internal string TracePrefix = "";
  internal int TracePrefixN;
  internal bool ParametersLocked;
  internal PictureBox CircuitSmall;
  internal PictureBox CircuitLarge;
  internal ToolTip ToolTipGraph;

  public Graph()
  {
  }

  public Graph(frmDCAProApp Parent)
  {
    this.theForm = Parent;
    this.theForm.NewResultEvent += new frmDCAProApp.ResultEvent(this.NewResult_Event);
    this.theForm.NewDisEnableEvent += new frmDCAProApp.DisEnableEvent(this.buttonStart_DisEnable);
    this.ToolTipGraph = new ToolTip();
    this.ToolTipGraph.AutoPopDelay = 30000;
    this.ToolTipGraph.InitialDelay = 500;
    this.ToolTipGraph.ReshowDelay = 100;
    this.ToolTipGraph.ShowAlways = true;
    this.ResetDefaults();
  }

  internal void InitControls()
  {
    if (this.thisStartButton != null)
      this.thisStartButton.Click += new EventHandler(this.buttonStart_Click);
    if (this.thisAutosetButton != null)
    {
      this.thisAutosetButton.Click += new EventHandler(this.buttonAutoset_Click);
      this.ToolTipGraph.SetToolTip((Control) this.thisAutosetButton, "Sets the parameters to suit the current component.");
    }
    if (this.thisCheckLockParameters != null)
    {
      this.thisCheckLockParameters.CheckStateChanged += new EventHandler(this.Parameter_Lock);
      this.ToolTipGraph.SetToolTip((Control) this.thisCheckLockParameters, "Stops the parameters from changing when a component is retested.");
    }
    if (this.thisCheckLog == null)
      return;
    this.ToolTipGraph.SetToolTip((Control) this.thisCheckLog, "Applies a log span to the Vge values.");
  }

  internal void SetGraphDefaults()
  {
    this.thisZedGraph.MasterPane.Border.IsVisible = false;
    this.thisZedGraph.GraphPane.Border.IsVisible = false;
    this.thisZedGraph.GraphPane.XAxis.MajorGrid.IsVisible = true;
    this.thisZedGraph.GraphPane.YAxis.MajorGrid.IsVisible = true;
    this.thisZedGraph.GraphPane.XAxis.MajorGrid.PenWidth = 0.0f;
    this.thisZedGraph.GraphPane.YAxis.MajorGrid.PenWidth = 0.0f;
    this.thisZedGraph.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(this.ContextMenuBuilder);
    ((Control) this.thisZedGraph).MouseClick += new MouseEventHandler(this.Graph_MouseClick);
    this.thisZedGraph.IsShowPointValues = true;
    this.thisZedGraph.PointValueFormat = $"{0.0:F3}";
    ((Control) this.thisZedGraph).Location = new Point(3, 3);
    ((Control) this.thisZedGraph).Size = new Size(920, 342);
    this.thisZedGraph.PointValueEvent += new ZedGraphControl.PointValueHandler(this.OnPointValueRequested);
    this.thisZedGraph.GraphPane.Legend.IsReverse = true;
  }

  internal virtual bool ResetDefaults()
  {
    this.ValuesUserModified = false;
    this.ResetColor();
    return true;
  }

  internal virtual void Refresh() => ((Control) this.thisZedGraph).Refresh();

  internal virtual string ParseTracePrefix(string Source, int N)
  {
    return Source.Replace("#", N.ToString());
  }

  internal virtual string ParseTracePrefix(Control SourceControl, Control NControl)
  {
    string Result = "";
    int N = 0;
    SourceControl.Invoke((Delegate) (() => Result = SourceControl.Text));
    NControl.Invoke((Delegate) (() => N = int.Parse(NControl.Text)));
    Result = Result.Replace("#", N.ToString());
    return Result;
  }

  internal virtual bool SetNewDefaults(Test.unResultDevice Result) => true;

  internal virtual Test.CONFIG GetConfig() => Test.CONFIG.NONE;

  private string OnPointValueRequested(
    object sender,
    GraphPane thisGraphPane,
    CurveItem thisCurve,
    int thisPointIndex)
  {
    PointPair pointPair = thisCurve[thisPointIndex];
    if (thisCurve.IsY2Axis)
      this.PointTooltip = string.Format("{0:G4}{2} {1:G4}{3}", (object) pointPair.X, (object) pointPair.Y, (object) this.XAxisUnits, (object) this.Y2AxisUnits);
    else
      this.PointTooltip = string.Format("{0:G4}{2} {1:G4}{3}", (object) pointPair.X, (object) pointPair.Y, (object) this.XAxisUnits, (object) this.YAxisUnits);
    thisGraphPane.IsFontsScaled = true;
    return this.PointTooltip;
  }

  internal abstract void ValidateText(object sender, CancelEventArgs e);

  internal virtual void ComponentName_Changed(object sender, frmDCAProApp.ComponentName e)
  {
  }

  internal virtual void Parameter_Lock(object sender, EventArgs e)
  {
    if ((sender as CheckBox).Checked)
    {
      foreach (Control control in (ArrangedElementCollection) this.thisPanel.Controls)
      {
        if (control.Tag != null && control.Tag.GetType() == typeof (string) && ((string) control.Tag).Contains("Parameter"))
        {
          control.Enabled = false;
          this.ParametersLocked = true;
        }
      }
    }
    else
    {
      foreach (Control control in (ArrangedElementCollection) this.thisPanel.Controls)
      {
        if (control.Tag != null && control.Tag.GetType() == typeof (string) && ((string) control.Tag).Contains("Parameter"))
        {
          control.Enabled = true;
          this.ParametersLocked = false;
        }
      }
    }
  }

  internal abstract void buttonStart_Click(object sender, EventArgs e);

  internal virtual void buttonAutoset_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.theForm.bgWorkerTest.IsBusy || !(this.thisStartButton.Text == "Start"))
        return;
      this.SetNewDefaults(this.theForm.thisDCAPro.Result);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal virtual void buttonStart_DisEnable(object sender, frmDCAProApp.DisEnable e)
  {
    if (e.Enable && e.Result.Type == this.TestType)
    {
      this.thisStartButton.Enabled = true;
      this.thisStartButton.Text = "Start";
    }
    else
      this.thisStartButton.Enabled = false;
  }

  internal void StartingPrepareControls()
  {
    this.theForm.DisableAllButtons();
    this.thisStartButton.Text = "Stop";
    this.thisStartButton.Enabled = true;
    this.thisStartButton.Select();
    this.theForm.toolStripProgressLabel.Text = "Sampling...";
  }

  internal abstract void NewResult_Event(object sender, frmDCAProApp.AResult e);

  internal abstract void DoGraph(BackgroundWorker worker, WorkResult Info);

  internal Color GetNextColor()
  {
    ++this.CurrentColor;
    if (this.CurrentColor >= Graph.Palete.Length || this.CurrentColor < 0)
      this.CurrentColor = 0;
    return Graph.Palete[this.CurrentColor];
  }

  internal void ResetColor() => this.CurrentColor = -1;

  internal void DoRenameGraph()
  {
    dialogRenameGraph dialogRenameGraph = new dialogRenameGraph(this.thisZedGraph.GraphPane.Title.Text);
    dialogRenameGraph.StartPosition = FormStartPosition.CenterParent;
    int num = (int) dialogRenameGraph.ShowDialog();
    if (dialogRenameGraph.DialogResult == DialogResult.OK)
      this.thisZedGraph.GraphPane.Title.Text = dialogRenameGraph.TheText;
    else if (dialogRenameGraph.DialogResult == DialogResult.Yes)
      this.thisZedGraph.GraphPane.Title.Text = this.GraphType;
    ((Control) this.thisZedGraph).Refresh();
  }

  internal void MinimumScaleYAxisUpdate()
  {
    bool flag = false;
    if (this.thisZedGraph.GraphPane.IsZoomed)
      return;
    Axis yaxis = (Axis) this.thisZedGraph.GraphPane.YAxis;
    yaxis.Scale.MinAuto = true;
    yaxis.Scale.MaxAuto = true;
    this.thisZedGraph.AxisChange();
    double num1 = yaxis.Scale.Max - yaxis.Scale.Min;
    if (num1 < this.MinYSpan)
    {
      yaxis.Scale.Max = yaxis.Scale.Min + (num1 + this.MinYSpan) / 2.0;
      yaxis.Scale.Max = Math.Round(yaxis.Scale.Max / this.MinYSpanRound) * this.MinYSpanRound;
      yaxis.Scale.Min = yaxis.Scale.Max - this.MinYSpan;
      flag = true;
    }
    Axis y2Axis = (Axis) this.thisZedGraph.GraphPane.Y2Axis;
    if (y2Axis.IsVisible)
    {
      y2Axis.Scale.MinAuto = true;
      y2Axis.Scale.MaxAuto = true;
      this.thisZedGraph.AxisChange();
      double num2 = y2Axis.Scale.Max - y2Axis.Scale.Min;
      if (num2 < this.MinY2Span)
      {
        y2Axis.Scale.Max = y2Axis.Scale.Min + (num2 + this.MinY2Span) / 2.0;
        y2Axis.Scale.Max = Math.Round(y2Axis.Scale.Max / this.MinY2SpanRound) * this.MinY2SpanRound;
        y2Axis.Scale.Min = y2Axis.Scale.Max - this.MinY2Span;
        flag = true;
      }
    }
    if (!flag)
      return;
    this.thisZedGraph.AxisChange();
  }

  internal void MinimumScaleXAxisUpdate()
  {
    if (this.thisZedGraph.GraphPane.IsZoomed)
      return;
    this.thisZedGraph.GraphPane.XAxis.Scale.MinAuto = true;
    this.thisZedGraph.GraphPane.XAxis.Scale.MaxAuto = true;
    this.thisZedGraph.AxisChange();
    double num = this.thisZedGraph.GraphPane.XAxis.Scale.Max - this.thisZedGraph.GraphPane.XAxis.Scale.Min;
    if (num >= this.MinXSpan)
      return;
    this.thisZedGraph.GraphPane.XAxis.Scale.Max = this.thisZedGraph.GraphPane.XAxis.Scale.Min + (num + this.MinXSpan) / 2.0;
    this.thisZedGraph.GraphPane.XAxis.Scale.Max = Math.Round(this.thisZedGraph.GraphPane.XAxis.Scale.Max / this.MinXSpanRound) * this.MinXSpanRound;
    this.thisZedGraph.GraphPane.XAxis.Scale.Min = this.thisZedGraph.GraphPane.XAxis.Scale.Max - this.MinXSpan;
    this.thisZedGraph.AxisChange();
  }

  private void Graph_MouseClick(object sender, MouseEventArgs e)
  {
    ZedGraphControl zedGraphControl = (ZedGraphControl) sender;
    Graphics graphics = ((Control) zedGraphControl).CreateGraphics();
    object nearestObj;
    zedGraphControl.GraphPane.FindNearestObject((PointF) (PointF) e.Location, (Graphics) graphics, out nearestObj, out int _);
    if (nearestObj == null || !(nearestObj.GetType() == typeof (GraphPane)))
      return;
    this.DoRenameGraph();
  }

  private ToolStripMenuItem NewToolstripItem(string PreText, EventHandler Event)
  {
    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
    toolStripMenuItem.Name = PreText;
    toolStripMenuItem.Text = PreText;
    toolStripMenuItem.Click += new EventHandler(Event.Invoke);
    return toolStripMenuItem;
  }

  private ToolStripMenuItem NewCurveToolstripItem(
    CurveItem TheCurve,
    string PreText,
    EventHandler Event)
  {
    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
    toolStripMenuItem.Name = PreText;
    toolStripMenuItem.Text = $"{PreText} {TheCurve.Label.Text}";
    toolStripMenuItem.Tag = (object) TheCurve;
    toolStripMenuItem.Click += new EventHandler(Event.Invoke);
    return toolStripMenuItem;
  }

  internal virtual void ContextMenuBuilder(
    ZedGraphControl sender,
    ContextMenuStrip menuStrip,
    Point mousePt,
    ZedGraphControl.ContextMenuObjectState objState)
  {
    try
    {
      Graphics graphics = ((Control) sender).CreateGraphics();
      menuStrip.Items.RemoveByKey("show_val");
      menuStrip.Items[menuStrip.Items.IndexOfKey("page_setup")].Text = "Page Setup";
      menuStrip.Items[menuStrip.Items.IndexOfKey("print")].Text = "Print";
      menuStrip.Items.RemoveByKey("save_as");
      menuStrip.Items.RemoveByKey("undo_all");
      menuStrip.Items.RemoveByKey("set_default");
      if (menuStrip.Items.ContainsKey("unzoom") && menuStrip.Items[menuStrip.Items.IndexOfKey("unzoom")].Enabled)
      {
        menuStrip.Items.RemoveByKey("unzoom");
        menuStrip.Items.Add((ToolStripItem) this.NewToolstripItem("Un-Zoom", new EventHandler(this.UnzoomAll)));
      }
      menuStrip.Items[menuStrip.Items.IndexOfKey("copy")].Text = "Copy Image";
      object nearestObj;
      int index1;
      sender.GraphPane.FindNearestObject((PointF) (PointF) mousePt, (Graphics) graphics, out nearestObj, out index1);
      CurveItem nearestCurve;
      sender.GraphPane.FindNearestPoint((PointF) (PointF) mousePt, out nearestCurve, out int _);
      menuStrip.Closed += new ToolStripDropDownClosedEventHandler(this.ContextClosed);
      if (this.theForm.bgWorkerTest.IsBusy)
      {
        menuStrip.Items.Add((ToolStripItem) this.NewToolstripItem("Copy Graph Data", new EventHandler(this.TraceCopyAll)));
        menuStrip.Items.Add((ToolStripItem) this.NewToolstripItem("Save Graph Data", new EventHandler(this.TraceSaveAll)));
      }
      else
      {
        int index2 = -1;
        int index3 = -1;
        bool flag = true;
        if (nearestObj != null)
        {
          if (nearestObj.GetType() == typeof (Legend))
          {
            if (index1 < ((List<CurveItem>) sender.GraphPane.CurveList).Count)
              nearestCurve = !this.thisZedGraph.GraphPane.Legend.IsReverse ? ((List<CurveItem>) sender.GraphPane.CurveList)[index1] : ((List<CurveItem>) sender.GraphPane.CurveList)[((List<CurveItem>) sender.GraphPane.CurveList).Count - 1 - index1];
          }
          else if (nearestObj.GetType() == typeof (TextObj))
          {
            TextObj textObj = (TextObj) nearestObj;
            if (textObj.Tag.GetType() == typeof (LineItem))
              nearestCurve = (CurveItem) textObj.Tag;
          }
        }
        if (nearestCurve != null)
        {
          nearestCurve.IsSelected = true;
          menuStrip.Items.Add((ToolStripItem) this.NewCurveToolstripItem(nearestCurve, "Rename/colour", new EventHandler(this.TraceRename)));
          Graph.CurveTag tag = (Graph.CurveTag) nearestCurve.Tag;
          index2 = menuStrip.Items.Add((ToolStripItem) new ToolStripMenuItem("Delete"));
          if (tag.Locked)
          {
            flag = false;
            index3 = menuStrip.Items.Add((ToolStripItem) new ToolStripMenuItem("Unlock"));
            (menuStrip.Items[index3] as ToolStripMenuItem).DropDownItems.Add((ToolStripItem) this.NewCurveToolstripItem(nearestCurve, "", new EventHandler(this.TraceUnlock)));
          }
          else
          {
            flag = true;
            index3 = menuStrip.Items.Add((ToolStripItem) new ToolStripMenuItem("Lock"));
            (menuStrip.Items[index3] as ToolStripMenuItem).DropDownItems.Add((ToolStripItem) this.NewCurveToolstripItem(nearestCurve, "", new EventHandler(this.TraceLock)));
            (menuStrip.Items[index2] as ToolStripMenuItem).DropDownItems.Add((ToolStripItem) this.NewCurveToolstripItem(nearestCurve, "", new EventHandler(this.TraceDelete)));
          }
        }
        menuStrip.Items.Add((ToolStripItem) this.NewToolstripItem("Copy Graph Data", new EventHandler(this.TraceCopyAll)));
        menuStrip.Items.Add((ToolStripItem) this.NewToolstripItem("Save Graph Data", new EventHandler(this.TraceSaveAll)));
        if (index3 != -1)
        {
          if (flag)
            (menuStrip.Items[index3] as ToolStripMenuItem).DropDownItems.Add((ToolStripItem) this.NewToolstripItem("All", new EventHandler(this.TraceLockAll)));
          else
            (menuStrip.Items[index3] as ToolStripMenuItem).DropDownItems.Add((ToolStripItem) this.NewToolstripItem("All", new EventHandler(this.TraceUnlockAll)));
        }
        if (index2 != -1)
          (menuStrip.Items[index2] as ToolStripMenuItem).DropDownItems.Add((ToolStripItem) this.NewToolstripItem("All", new EventHandler(this.TraceDeleteAll)));
      }
      if (this.thisZedGraph.GraphPane.Legend.IsVisible)
        menuStrip.Items.Add((ToolStripItem) this.NewToolstripItem("Hide Legend", new EventHandler(this.LegendShowToggle)));
      else
        menuStrip.Items.Add((ToolStripItem) this.NewToolstripItem("Show Legend", new EventHandler(this.LegendShowToggle)));
      ((Control) sender).Refresh();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void ContextClosed(object sender, ToolStripDropDownClosedEventArgs e)
  {
    try
    {
      ContextMenuStrip contextMenuStrip = sender as ContextMenuStrip;
      foreach (ToolStripMenuItem toolStripMenuItem in (ArrangedElementCollection) contextMenuStrip.Items)
      {
        if (toolStripMenuItem.Tag is LineItem)
        {
          (toolStripMenuItem.Tag as LineItem).IsSelected = false;
          ((Control) this.thisZedGraph).Refresh();
          break;
        }
      }
      contextMenuStrip.Closed -= new ToolStripDropDownClosedEventHandler(this.ContextClosed);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal CurveItem TraceAddWhole(Graph.Trace TheTrace, bool IsY2Axis = false)
  {
    try
    {
      int count = ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Count;
      CurveItem thisCurve = (CurveItem) this.thisZedGraph.GraphPane.AddCurve(TheTrace.Label, TheTrace.DataX, TheTrace.DataY, (Color) TheTrace.Colour);
      if (IsY2Axis)
        thisCurve.IsY2Axis = true;
      Graph.CurveTag curveTag = new Graph.CurveTag(count);
      thisCurve.Tag = (object) curveTag;
      LineItem lineItem = thisCurve as LineItem;
      lineItem.Symbol.IsVisible = false;
      lineItem.Line.Width = 3f;
      ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Sort((IComparer<CurveItem>) new Graph.CurveItemRComparer());
      if (TheTrace.Tag != "" && TheTrace.Tag != null)
        this.TraceAddTag(TheTrace, thisCurve);
      return thisCurve;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal int TraceAddWhole(Graph.Trace TheTrace, int DummyIndex, bool IsY2Axis = false)
  {
    try
    {
      int count = ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Count;
      CurveItem thisCurve = (CurveItem) this.thisZedGraph.GraphPane.AddCurve(TheTrace.Label, TheTrace.DataX, TheTrace.DataY, (Color) TheTrace.Colour);
      if (IsY2Axis)
        thisCurve.IsY2Axis = true;
      Graph.CurveTag curveTag = new Graph.CurveTag(count);
      thisCurve.Tag = (object) curveTag;
      LineItem lineItem = thisCurve as LineItem;
      lineItem.Symbol.IsVisible = false;
      lineItem.Line.Width = 3f;
      ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Sort((IComparer<CurveItem>) new Graph.CurveItemRComparer());
      if (TheTrace.Tag != "" && TheTrace.Tag != null)
        this.TraceAddTag(TheTrace, thisCurve);
      return ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).IndexOf(thisCurve);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TraceAddTag(Graph.Trace TheTrace, CurveItem thisCurve, bool IsY2Axis = false)
  {
    try
    {
      if (thisCurve == null)
        return;
      PointPair point = thisCurve.Points[thisCurve.Points.Count - 1];
      TextObj textObj = new TextObj(TheTrace.Label, point.X, point.Y, CoordType.AxisXYScale, AlignH.Left, AlignV.Center);
      textObj.ZOrder = ZOrder.A_InFront;
      textObj.FontSpec.Border.IsVisible = true;
      textObj.FontSpec.Fill.IsVisible = true;
      textObj.Tag = (object) thisCurve;
      ((List<GraphObj>) this.thisZedGraph.GraphPane.GraphObjList).Add((GraphObj) textObj);
      ((List<GraphObj>) this.thisZedGraph.GraphPane.GraphObjList).Sort((IComparer<GraphObj>) new Graph.GraphObjListRComparer());
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TraceAddTag(CurveItem thisCurve, bool IsY2Axis = false)
  {
    try
    {
      if (thisCurve == null)
        return;
      PointPair point = thisCurve.Points[thisCurve.Points.Count - 1];
      TextObj textObj = !IsY2Axis ? new TextObj(thisCurve.Label.Text, point.X, point.Y, CoordType.AxisXYScale, AlignH.Left, AlignV.Center) : new TextObj(thisCurve.Label.Text, point.X, point.Y, CoordType.AxisXY2Scale, AlignH.Left, AlignV.Center);
      textObj.ZOrder = ZOrder.A_InFront;
      textObj.FontSpec.Border.IsVisible = true;
      textObj.FontSpec.Fill.IsVisible = true;
      textObj.Tag = (object) thisCurve;
      ((List<GraphObj>) this.thisZedGraph.GraphPane.GraphObjList).Add((GraphObj) textObj);
      ((List<GraphObj>) this.thisZedGraph.GraphPane.GraphObjList).Sort((IComparer<GraphObj>) new Graph.GraphObjListRComparer());
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TraceRename(object sender, EventArgs e)
  {
    try
    {
      if (this.theForm.bgWorkerTest.IsBusy)
        return;
      ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
      if (!(toolStripMenuItem.Tag is LineItem))
        return;
      LineItem tag = toolStripMenuItem.Tag as LineItem;
      dialogChangeText dialogChangeText = new dialogChangeText(tag.Label.Text, (Color) tag.Color, this.theForm.TraceColorDialog);
      dialogChangeText.StartPosition = FormStartPosition.CenterParent;
      int num = (int) dialogChangeText.ShowDialog();
      if (dialogChangeText.DialogResult == DialogResult.OK)
      {
        tag.Label.Text = dialogChangeText.TheText;
        tag.Color = (Color) dialogChangeText.TheColour;
        foreach (TextObj graphObj in (List<GraphObj>) this.thisZedGraph.GraphPane.GraphObjList)
        {
          if (graphObj.Tag == tag)
          {
            graphObj.Text = dialogChangeText.TheText;
            break;
          }
        }
      }
      ((Control) this.thisZedGraph).Refresh();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TraceLock(object sender, EventArgs e)
  {
    try
    {
      if (this.theForm.bgWorkerTest.IsBusy)
        return;
      ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
      if (!(toolStripMenuItem.Tag is LineItem))
        return;
      LineItem tag = toolStripMenuItem.Tag as LineItem;
      ((Graph.CurveTag) tag.Tag).Locked = true;
      tag.Line.Style = DashStyle.Dash;
      ((Control) this.thisZedGraph).Refresh();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TraceUnlock(object sender, EventArgs e)
  {
    try
    {
      if (this.theForm.bgWorkerTest.IsBusy)
        return;
      ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
      if (!(toolStripMenuItem.Tag is LineItem))
        return;
      LineItem tag = toolStripMenuItem.Tag as LineItem;
      ((Graph.CurveTag) tag.Tag).Locked = false;
      tag.Line.Style = DashStyle.Solid;
      ((Control) this.thisZedGraph).Refresh();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TraceLockAll(object sender, EventArgs e)
  {
    try
    {
      if (this.theForm.bgWorkerTest.IsBusy)
        return;
      foreach (CurveItem curve in (List<CurveItem>) this.thisZedGraph.GraphPane.CurveList)
      {
        if (curve is LineItem)
        {
          LineItem lineItem = curve as LineItem;
          ((Graph.CurveTag) lineItem.Tag).Locked = true;
          lineItem.Line.Style = DashStyle.Dash;
        }
      }
      ((Control) this.thisZedGraph).Refresh();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TraceUnlockAll(object sender, EventArgs e)
  {
    try
    {
      if (this.theForm.bgWorkerTest.IsBusy)
        return;
      foreach (CurveItem curve in (List<CurveItem>) this.thisZedGraph.GraphPane.CurveList)
      {
        if (curve is LineItem)
        {
          LineItem lineItem = curve as LineItem;
          ((Graph.CurveTag) lineItem.Tag).Locked = false;
          lineItem.Line.Style = DashStyle.Solid;
        }
      }
      ((Control) this.thisZedGraph).Refresh();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TraceDelete(object sender, EventArgs e)
  {
    try
    {
      if (this.theForm.bgWorkerTest.IsBusy)
        return;
      ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
      if (!(toolStripMenuItem.Tag is LineItem))
        return;
      LineItem tag = toolStripMenuItem.Tag as LineItem;
      GraphObjList graphObjList = this.thisZedGraph.GraphPane.GraphObjList;
      foreach (GraphObj graphObj in (List<GraphObj>) this.thisZedGraph.GraphPane.GraphObjList)
      {
        if (graphObj.Tag == tag)
        {
          ((List<GraphObj>) this.thisZedGraph.GraphPane.GraphObjList).Remove(graphObj);
          break;
        }
      }
      ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Remove((CurveItem) tag);
      ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Sort((IComparer<CurveItem>) new Graph.CurveItemRComparer());
      ((Control) this.thisZedGraph).Refresh();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TraceDeleteAll(object sender, Graph.TraceDeleteEventArgs e)
  {
    try
    {
      if (this.theForm.bgWorkerTest.IsBusy)
        return;
      bool flag1 = false;
      if (e.Confirm)
      {
        if (MessageBox.Show(string.Format("Delete all this graph's traces?\n(Locked traces will remain)"), "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
          flag1 = true;
      }
      else
        flag1 = true;
      if (!flag1)
        return;
      bool flag2 = true;
      while (flag2)
      {
        flag2 = false;
        foreach (CurveItem curve in (List<CurveItem>) this.thisZedGraph.GraphPane.CurveList)
        {
          if (!((Graph.CurveTag) curve.Tag).Locked)
          {
            bool flag3 = true;
            while (flag3)
            {
              flag3 = false;
              foreach (GraphObj graphObj in (List<GraphObj>) this.thisZedGraph.GraphPane.GraphObjList)
              {
                if (graphObj.Tag == curve)
                {
                  ((List<GraphObj>) this.thisZedGraph.GraphPane.GraphObjList).Remove(graphObj);
                  flag3 = true;
                  break;
                }
              }
            }
            ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Remove(curve);
            flag2 = true;
            break;
          }
        }
      }
      ((Control) this.thisZedGraph).Refresh();
      this.theForm.toolStripProgressLabel.Text = "";
      this.ResetColor();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TraceDeleteAll(object sender, EventArgs e)
  {
    try
    {
      if (this.theForm.bgWorkerTest.IsBusy || MessageBox.Show(string.Format("Delete all this graph's traces?\n(Locked traces will remain)"), "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
        return;
      bool flag1 = true;
      while (flag1)
      {
        flag1 = false;
        foreach (CurveItem curve in (List<CurveItem>) this.thisZedGraph.GraphPane.CurveList)
        {
          if (!((Graph.CurveTag) curve.Tag).Locked)
          {
            bool flag2 = true;
            while (flag2)
            {
              flag2 = false;
              foreach (GraphObj graphObj in (List<GraphObj>) this.thisZedGraph.GraphPane.GraphObjList)
              {
                if (graphObj.Tag == curve)
                {
                  ((List<GraphObj>) this.thisZedGraph.GraphPane.GraphObjList).Remove(graphObj);
                  flag2 = true;
                  break;
                }
              }
            }
            ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Remove(curve);
            flag1 = true;
            break;
          }
        }
      }
      ((Control) this.thisZedGraph).Refresh();
      this.theForm.toolStripProgressLabel.Text = "";
      this.ResetColor();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TraceCopyAll(object sender, EventArgs e)
  {
    try
    {
      string Result = "";
      int num1 = this.TraceExtractString(ref Result);
      if (num1 > 0)
      {
        Clipboard.SetText(Result);
        this.theForm.HighlightProgressLabel($"Copied {num1} traces to clipboard.");
      }
      else
      {
        int num2 = (int) MessageBox.Show("No data to copy.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.theForm.toolStripProgressLabel.Text = "";
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TraceSaveAll(object sender, EventArgs e)
  {
    Stream stream = (Stream) null;
    try
    {
      this.theForm.saveDataFileDialog.FileName = "*.txt";
      if (((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Count > 0)
      {
        if (this.theForm.saveDataFileDialog.ShowDialog() != DialogResult.OK)
          return;
        stream = (Stream) new FileStream(this.theForm.saveDataFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.Read);
        int num = 0;
        using (StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8))
        {
          string Result = "";
          num = this.TraceExtractString(ref Result);
          streamWriter.Write(Result);
        }
        this.theForm.HighlightProgressLabel($"Saved {num} traces to '{Path.GetFileName(this.theForm.saveDataFileDialog.FileName)}'.");
      }
      else
      {
        int num = (int) MessageBox.Show("No data to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.theForm.HighlightProgressLabel("Save failed.", false);
      }
    }
    catch (Exception ex)
    {
      throw;
    }
    finally
    {
      stream?.Close();
    }
  }

  internal int TraceExtractString(ref string Result)
  {
    GraphPane graphPane = this.thisZedGraph.GraphPane;
    Result = "";
    int num = 0;
    int count = ((List<CurveItem>) graphPane.CurveList).Count;
    Result += $"{graphPane.Title.Text}{Environment.NewLine}";
    Result += $"Type:\t{this.GraphType}{Environment.NewLine}";
    Result += string.Format("Trace:");
    for (int index = 0; index < count; ++index)
      Result += $"\t{((List<CurveItem>) graphPane.CurveList)[count - index - 1].Label.Text}\t";
    Result += string.Format(Environment.NewLine);
    Result += string.Format("Tag:");
    for (int index = 0; index < count; ++index)
    {
      bool flag = false;
      foreach (GraphObj graphObj in (List<GraphObj>) graphPane.GraphObjList)
      {
        if (graphObj.Tag == ((List<CurveItem>) graphPane.CurveList)[count - index - 1])
        {
          Result += $"\t{((TextObj) graphObj).Text}\t";
          flag = true;
        }
      }
      if (!flag)
        Result += string.Format("\t\t");
    }
    Result += string.Format(Environment.NewLine);
    Result += string.Format("Colour:");
    for (int index = 0; index < count; ++index)
      Result += $"\t{((Color) ((List<CurveItem>) graphPane.CurveList)[count - index - 1].Color).Name}\t";
    Result += string.Format(Environment.NewLine);
    Result += string.Format("Point");
    for (int index = 0; index < count; ++index)
    {
      if (((List<CurveItem>) graphPane.CurveList)[count - index - 1].IsY2Axis)
        Result += $"\t{graphPane.XAxis.Title.Text}\t{graphPane.Y2Axis.Title.Text}";
      else
        Result += $"\t{graphPane.XAxis.Title.Text}\t{graphPane.YAxis.Title.Text}";
      if (num < ((List<CurveItem>) graphPane.CurveList)[count - index - 1].NPts)
        num = ((List<CurveItem>) graphPane.CurveList)[count - index - 1].NPts;
    }
    Result += string.Format(Environment.NewLine);
    if (count > 0)
    {
      for (int index1 = 0; index1 < num; ++index1)
      {
        Result += $"{index1}";
        for (int index2 = 0; index2 < count; ++index2)
        {
          CurveItem curve = ((List<CurveItem>) graphPane.CurveList)[count - index2 - 1];
          if (curve.NPts > index1)
          {
            PointPair point = curve.Points[index1];
            Result += $"\t{point.X}\t{point.Y}";
          }
          else
            Result += string.Format("\t\t");
        }
        Result += string.Format(Environment.NewLine);
      }
    }
    return count;
  }

  internal void UnzoomAll(object sender, EventArgs e)
  {
    try
    {
      this.thisZedGraph.GraphPane.ZoomStack.PopAll(this.thisZedGraph.GraphPane);
      this.MinimumScaleYAxisUpdate();
      ((Control) this.thisZedGraph).Refresh();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void LegendShowToggle(object sender, EventArgs e)
  {
    try
    {
      if (this.thisZedGraph.GraphPane.Legend.IsVisible)
        this.thisZedGraph.GraphPane.Legend.IsVisible = false;
      else
        this.thisZedGraph.GraphPane.Legend.IsVisible = true;
      this.MinimumScaleYAxisUpdate();
      ((Control) this.thisZedGraph).Refresh();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal static int LoadDataFiles(string[] Filenames, ref Graph[] Graphs)
  {
    string str1 = "unknown";
    int num1 = 0;
    foreach (string filename in Filenames)
    {
      Stream stream = (Stream) new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
      try
      {
        using (StreamReader streamReader = new StreamReader(stream))
        {
          string str2 = "unknown";
          Graph TheGraph = (Graph) null;
          int newSize = 0;
          Graph.Trace[] array1 = new Graph.Trace[0];
          string[] array2 = new string[1]{ "" };
          string[] strArray1 = new string[1]{ "" };
          char[] chArray = new char[1]{ '\t' };
          int num2 = 0;
          while (!streamReader.EndOfStream)
          {
            if (num2 >= ((IEnumerable<string>) array2).Count<string>())
              Array.Resize<string>(ref array2, num2 + 1);
            array2[num2++] = streamReader.ReadLine();
          }
          foreach (string str3 in array2)
          {
            if (str3.Contains("Type:"))
            {
              str2 = str3.Split(chArray)[1];
              break;
            }
          }
          if (str2 == "unknown")
            str2 = array2[0].Trim();
          string str4 = array2[0].Trim();
          foreach (Graph graph in Graphs)
          {
            if (graph.GraphType == str2)
            {
              TheGraph = graph;
              break;
            }
          }
          if (TheGraph != null)
          {
            foreach (string str5 in array2)
            {
              if (str5.Contains("Trace:"))
              {
                string[] strArray2 = str5.Split(chArray);
                newSize = (strArray2.Length - 1) / 2;
                Array.Resize<Graph.Trace>(ref array1, newSize);
                for (int index = 0; index < newSize; ++index)
                  array1[index].Label = strArray2[index * 2 + 1];
                break;
              }
            }
            foreach (string str6 in array2)
            {
              if (str6.Contains("Tag:"))
              {
                string[] strArray3 = str6.Split(chArray);
                for (int index = 0; index < newSize; ++index)
                  array1[index].Tag = strArray3[index * 2 + 1];
                break;
              }
            }
            foreach (string str7 in array2)
            {
              if (str7.Contains("Colour:"))
              {
                string[] strArray4 = str7.Split(chArray);
                for (int index = 0; index < newSize; ++index)
                {
                  array1[index].Colour = Color.FromName(strArray4[index * 2 + 1]);
                  if (!array1[index].Colour.IsKnownColor)
                  {
                    int int32 = Convert.ToInt32(strArray4[index * 2 + 1], 16 /*0x10*/);
                    array1[index].Colour = Color.FromArgb(int32);
                  }
                }
                break;
              }
            }
            bool flag = false;
            foreach (string str8 in array2)
            {
              if (!flag)
              {
                if (str8.Contains("Point"))
                {
                  string[] strArray5 = str8.Split(chArray);
                  for (int index = 0; index < newSize; ++index)
                  {
                    array1[index].XAxis = strArray5[index * 2 + 1];
                    array1[index].YAxis = strArray5[index * 2 + 2];
                  }
                  flag = true;
                }
              }
              else
              {
                string[] strArray6 = str8.Split(chArray);
                int int32 = Convert.ToInt32(strArray6[0]);
                for (int index = 0; index < newSize; ++index)
                {
                  if (strArray6[index * 2 + 1].Length > 0 && strArray6[index * 2 + 2].Length > 0)
                  {
                    Array.Resize<double>(ref array1[index].DataX, int32 + 1);
                    Array.Resize<double>(ref array1[index].DataY, int32 + 1);
                    if (strArray6[index * 2 + 1].Length > 0)
                      double.TryParse(strArray6[index * 2 + 1], out array1[index].DataX[int32]);
                    if (strArray6[index * 2 + 2].Length > 0)
                      double.TryParse(strArray6[index * 2 + 2], out array1[index].DataY[int32]);
                  }
                }
              }
            }
            string withoutExtension = Path.GetFileNameWithoutExtension(filename);
            string[] TheTraceLabels = new string[array1.Length];
            string[] strArray7 = new string[array1.Length];
            for (int index = 0; index < newSize; ++index)
            {
              TheTraceLabels[index] = $"{array1[index].Label}";
              strArray7[index] = $"{array1[index].Tag}";
            }
            if (Graph.TracesClash(TheTraceLabels, TheGraph, ""))
            {
              for (int index = 0; index < newSize; ++index)
              {
                TheTraceLabels[index] = $"{withoutExtension} {array1[index].Label}";
                strArray7[index] = $"{withoutExtension} {array1[index].Tag}";
              }
              for (int index1 = 97; Graph.TracesClash(TheTraceLabels, TheGraph, "") && index1 <= 122; ++index1)
              {
                for (int index2 = 0; index2 < newSize; ++index2)
                {
                  TheTraceLabels[index2] = string.Format("{0}{2} {1}", (object) withoutExtension, (object) array1[index2].Label, (object) (char) index1);
                  strArray7[index2] = string.Format("{0}{2} {1}", (object) withoutExtension, (object) array1[index2].Tag, (object) (char) index1);
                }
              }
              for (int index = 0; index < newSize; ++index)
              {
                array1[index].Label = TheTraceLabels[index];
                if (array1[index].Tag != "" && array1[index].Tag != null)
                  array1[index].Tag = strArray7[index];
              }
            }
            foreach (Graph.Trace TheTrace in array1)
            {
              if (TheGraph.thisZedGraph.GraphPane.Y2Axis.Title.Text == TheTrace.YAxis)
                TheGraph.TraceAddWhole(TheTrace, true);
              else
                TheGraph.TraceAddWhole(TheTrace);
            }
            TheGraph.MinimumScaleYAxisUpdate();
            ((Control) TheGraph.thisZedGraph).Invalidate();
            num1 += newSize;
            if (TheGraph.thisZedGraph.GraphPane.Title.Text == str2)
              TheGraph.thisZedGraph.GraphPane.Title.Text = str4;
            TheGraph.theForm.SetSelectTabMenuItem(TheGraph.theMenuItem, true);
          }
          else
          {
            int num3 = (int) MessageBox.Show((IWin32Window) Graphs[0].theForm, $"Unknown Graph type: {str2}\nin file {Path.GetFileName(filename)}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        }
      }
      catch (Exception ex)
      {
        str1 = str1.Replace("\t", "\\t");
        str1 = str1.Replace("\n", "\\n");
        str1 = str1.Replace("\r", "\\r");
        int num4 = (int) MessageBox.Show((IWin32Window) Graphs[0].theForm, $"[{Path.GetFileName(filename)}] file load failed at line:\n{str1}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      finally
      {
        stream.Close();
      }
    }
    return num1;
  }

  private static bool TracesClash(string[] TheTraceLabels, Graph TheGraph, string Prefix)
  {
    bool flag = false;
    foreach (CurveItem curve in (List<CurveItem>) TheGraph.thisZedGraph.GraphPane.CurveList)
    {
      for (int index = 0; index < TheTraceLabels.Length; ++index)
      {
        if (curve.Label.Text == TheTraceLabels[index])
          flag = true;
        if (flag)
          break;
      }
      if (flag)
        break;
    }
    return flag;
  }

  internal enum Types
  {
    GRAPH_PN,
    GRAPH_ICVCE,
    GRAPH_ICVBE,
    GRAPH_HFEIC,
    GRAPH_ICIB,
    GRAPH_HFEVCE,
    GRAPH_IDVDS,
    GRAPH_IDVGS,
    GRAPH_TICVCE,
    GRAPH_TICVGE,
    GRAPH_JIDVDS,
    GRAPH_JIDVGS,
    GRAPH_VREGOI,
    GRAPH_GRAPHS,
  }

  internal enum PNOtherIndex
  {
    PN_OPEN,
    PN_470KA,
    PN_470KK,
    PN_LOWA,
    PN_LOWK,
  }

  internal struct Trace
  {
    internal string Label;
    internal string Tag;
    internal Color Colour;
    internal string XAxis;
    internal string YAxis;
    internal double[] DataX;
    internal double[] DataY;

    public Trace(
      string NewLabel,
      string NewTag,
      Color NewColour,
      double[] NewDataX,
      double[] NewDataY)
    {
      this.Label = NewLabel;
      this.Tag = NewTag;
      this.Colour = NewColour;
      this.XAxis = "";
      this.YAxis = "";
      this.DataX = NewDataX;
      this.DataY = NewDataY;
    }

    public Trace(
      string NewLabel,
      string NewTag,
      Color NewColour,
      double NewDataX,
      double NewDataY)
    {
      this.Label = NewLabel;
      this.Tag = NewTag;
      this.Colour = NewColour;
      this.XAxis = "";
      this.YAxis = "";
      this.DataX = new double[1]{ NewDataX };
      this.DataY = new double[1]{ NewDataY };
    }
  }

  internal class CurveTag
  {
    internal int Index;
    internal bool Locked;

    public CurveTag(int newIndex)
    {
      this.Index = newIndex;
      this.Locked = false;
    }

    public CurveTag(int newIndex, bool newLocked)
    {
      this.Index = newIndex;
      this.Locked = newLocked;
    }
  }

  private class CurveItemRComparer : IComparer<CurveItem>
  {
    public int Compare(CurveItem x, CurveItem y)
    {
      Graph.CurveTag tag = (Graph.CurveTag) x.Tag;
      return ((Graph.CurveTag) y.Tag).Index.CompareTo(tag.Index);
    }
  }

  private class GraphObjListRComparer : IComparer<GraphObj>
  {
    public int Compare(GraphObj x, GraphObj y)
    {
      CurveItem tag = (CurveItem) x.Tag;
      return ((Graph.CurveTag) ((CurveItem) y.Tag).Tag).Index.CompareTo(((Graph.CurveTag) tag.Tag).Index);
    }
  }

  public class TraceDeleteEventArgs : EventArgs
  {
    private bool mConfirm;

    public TraceDeleteEventArgs() => this.mConfirm = true;

    public TraceDeleteEventArgs(bool newConfirm) => this.mConfirm = newConfirm;

    public bool Confirm
    {
      get => this.mConfirm;
      set => this.mConfirm = value;
    }
  }
}
