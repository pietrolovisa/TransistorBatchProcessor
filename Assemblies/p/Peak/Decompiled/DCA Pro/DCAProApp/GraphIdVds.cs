// Decompiled with JetBrains decompiler
// Type: DCAProApp.GraphIdVds
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using DCAPro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

#nullable disable
namespace DCAProApp;

internal class GraphIdVds : Graph
{
  internal const float VMin = 0.0f;
  internal const float VMax = 12f;
  internal const float VdsMin = 0.0f;
  internal const float VdsLoMax = 8f;
  internal const float VdsHiMax = 12f;
  internal const float IdMin = 0.0f;
  internal const float IdMax = 12f;
  internal const float VgsMin = -10f;
  internal const float VgsMax = 10f;

  public GraphIdVds(frmDCAProApp Parent)
    : base(Parent)
  {
    this.Type = Graph.Types.GRAPH_IDVDS;
    this.TestType = Test.TYPE.MOSFET;
    this.theMenuItem = this.theForm.IdVdsMOSFETMenuSubItem;
    this.thisPanel = this.theForm.panelMIdVds;
    this.thisZedGraph = this.theForm.zedGraphMIdVds;
    this.thisStartButton = this.theForm.butStartMIdVds;
    this.thisAutosetButton = this.theForm.butAutosetMIdVds;
    this.thisCheckLockParameters = this.theForm.checkMIdVdsLockParameters;
    this.thisCheckLog = this.theForm.checkMIdVdsLog;
    this.InitControls();
    this.theForm.textIdVdsVddMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIdVdsVddMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIdVdsPoints.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIdVdsVgsMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIdVdsVgsMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIdVdsTraces.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.SetGraphDefaults();
    this.GraphType = "MOSFET Id / Vds";
    this.thisZedGraph.GraphPane.Title.Text = this.GraphType;
    this.thisZedGraph.GraphPane.XAxis.Title.Text = "Vds";
    this.thisZedGraph.GraphPane.YAxis.Title.Text = "Id (mA)";
    this.XAxisUnits = "V";
    this.YAxisUnits = "mA";
    this.theForm.textIdVdsVddMin.Text = $"{(ValueType) 0.0f:F1}";
    this.theForm.textIdVdsVddMax.Text = $"{(ValueType) 12f:F1}";
    this.theForm.textIdVdsPoints.Text = $"{51:D}";
    this.theForm.textIdVdsTraces.Text = $"{5:D}";
    this.theForm.textIdVdsVgsMin.Text = $"{(ValueType) -10f:F1}";
    this.theForm.textIdVdsVgsMax.Text = $"{(ValueType) 10f:F1}";
    this.UpdateParameterTooltips(this.ToolTipGraph);
    this.CircuitSmall = this.theForm.picMOSIdVdsCircuitSmall;
    this.CircuitLarge = this.theForm.picMOSIdVdsCircuitLarge;
    this.CircuitSmall.Tag = (object) this.CircuitLarge;
    this.CircuitLarge.Location = new Point(this.CircuitLarge.Parent.Width - this.CircuitLarge.Width, this.CircuitLarge.Parent.Height - this.CircuitLarge.Height);
  }

  internal void UpdateParameterTooltips(ToolTip theTooltip)
  {
    theTooltip.SetToolTip((Control) this.theForm.textIdVdsVddMin, $"Applied Vdd for each trace.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 8f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textIdVdsVddMax, $"Applied Vdd for each trace.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textIdVdsVgsMin, $"Applied Vgs for each point.\r\n{(ValueType) -10f:F1}V to {(ValueType) 10f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textIdVdsVgsMax, $"Applied Vgs for each point.\r\n{(ValueType) -10f:F1}V to {(ValueType) 10f:F1}V");
  }

  internal override bool SetNewDefaults(Test.unResultDevice Result)
  {
    if (Result.Type == Test.TYPE.MOSFET)
    {
      this.thisConfig = Result.MOSFET.Config;
      this.theForm.rtextIdVdsConfig.RenderLeadString(Result.MOSFET.Config, "S", "D", "G");
      if (!this.ParametersLocked)
      {
        double num = Math.Round((double) Result.MOSFET.Vgth * 10.0) / 10.0;
        this.theForm.textIdVdsVgsMin.Text = $"{Math.Round(((double) Result.MOSFET.Vgth - ((double) Result.MOSFET.IdOn - (double) Result.MOSFET.IdOn2) / (double) Result.MOSFET.gm) * 10.0) / 10.0:F1}";
        this.theForm.textIdVdsVgsMax.Text = $"{num:F1}";
      }
    }
    else
    {
      this.theForm.rtextIdVdsConfig.Render("Unknown");
      this.thisStartButton.Enabled = false;
    }
    this.UpdateParameterTooltips(this.ToolTipGraph);
    return true;
  }

  internal override void NewResult_Event(object sender, frmDCAProApp.AResult e)
  {
    this.SetNewDefaults(e.Result);
  }

  internal override void buttonStart_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.theForm.bgWorkerTest.IsBusy && this.thisStartButton.Text == "Stop")
      {
        this.theForm.bgWorkerTest.CancelAsync();
      }
      else
      {
        this.StartingPrepareControls();
        this.theForm.bgWorkerTest.RunWorkerAsync((object) ACT.GRAPH_IDVDS);
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal override void ValidateText(object sender, CancelEventArgs e)
  {
    TextBox textBox = sender as TextBox;
    float result;
    if (!float.TryParse(textBox.Text, out result))
      textBox.Text = $"{0.0:F1}";
    if (textBox == this.theForm.textIdVdsVddMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 8.0)
        result = 8f;
      float single = Convert.ToSingle(this.theForm.textIdVdsVddMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textIdVdsVddMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textIdVdsVddMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textIdVdsVgsMin)
    {
      if ((double) result < -10.0)
        result = -10f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textIdVdsVgsMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textIdVdsVgsMax)
    {
      if ((double) result < -10.0)
        result = -10f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textIdVdsVgsMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textIdVdsPoints)
    {
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 10000.0)
        result = 10000f;
      textBox.Text = $"{(int) result:D}";
    }
    else
    {
      if (textBox != this.theForm.textIdVdsTraces)
        return;
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 100.0)
        result = 100f;
      textBox.Text = $"{(int) result:D}";
    }
  }

  internal override void DoGraph(BackgroundWorker worker, WorkResult Info)
  {
    try
    {
      int int16_1 = (int) Convert.ToInt16(this.theForm.textIdVdsTraces.Text);
      int int16_2 = (int) Convert.ToInt16(this.theForm.textIdVdsPoints.Text);
      double[] numArray1 = new double[int16_2];
      double[] numArray2 = new double[int16_2];
      bool flag1 = false;
      bool flag2 = false;
      Test.CONFIG thisConfig = this.thisConfig;
      double single1 = (double) Convert.ToSingle(this.theForm.textIdVdsVddMin.Text);
      double single2 = (double) Convert.ToSingle(this.theForm.textIdVdsVddMax.Text);
      double single3 = (double) Convert.ToSingle(this.theForm.textIdVdsVgsMin.Text);
      double single4 = (double) Convert.ToSingle(this.theForm.textIdVdsVgsMax.Text);
      if (this.theForm.checkMIdVdsLog.Checked)
        flag2 = true;
      if (this.theForm.thisDCAPro.Mode(Test.MODE.ANALOG_USB) != Errors.Type.ErrNone)
        return;
      int index1 = 0;
      int num1 = (int) this.theForm.thisDCAPro.LeadsSafe();
      for (int index2 = 0; index2 < int16_1; ++index2)
      {
        bool flag3 = false;
        CurveItem thisCurve = (CurveItem) null;
        float num2 = int16_1 <= 1 ? (float) single3 : (!flag2 ? (float) (single3 + (double) index2 * (single4 - single3) / (double) (int16_1 - 1)) : (float) (single3 + Math.Pow((double) index2 / ((double) int16_1 - 1.0), 0.5) * (single4 - single3)));
        float Vds1 = (float) single1;
        int num3 = (int) this.theForm.thisDCAPro.SetRGate(Test.RGATE_IDX._8k2);
        this.theForm.thisDCAPro.FETPowerOn(thisConfig, num2, 12f);
        this.theForm.thisDCAPro.FETSetVdsVgs(thisConfig, Vds1, num2, 12f);
        if (thisConfig < Test.CONFIG.Ps)
        {
          int num4 = (int) this.theForm.thisDCAPro.SetGateVoltage(num2, thisConfig);
        }
        else
        {
          int num5 = (int) this.theForm.thisDCAPro.SetGateVoltage(-num2, thisConfig);
        }
        this.theForm.thisDCAPro.DelaymS((ushort) 24);
        for (int index3 = 0; index3 < int16_2; ++index3)
        {
          float Vds2 = int16_2 <= 1 ? (float) single1 : (float) (single1 + (double) index3 * (single2 - single1) / (double) (int16_2 - 1));
          if (!this.theForm.thisDCAPro.FETSetVds(thisConfig, Vds2, num2, 12f))
            flag3 = true;
          if (thisConfig < Test.CONFIG.Ps)
          {
            int num6 = (int) this.theForm.thisDCAPro.SetGateVoltage(num2, thisConfig);
          }
          else
          {
            int num7 = (int) this.theForm.thisDCAPro.SetGateVoltage(-num2, thisConfig);
          }
          this.theForm.thisDCAPro.BoostWait();
          if (!this.theForm.thisDCAPro.WaitForCVOneShot(500, true))
            flag3 = true;
          if ((double) this.theForm.thisDCAPro.DetermineIc(thisConfig) > 12.0)
            flag3 = true;
          numArray1[index3] = (double) this.theForm.thisDCAPro.DetermineVce(thisConfig);
          numArray2[index3] = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
          if (!flag3)
          {
            int count = ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Count;
            if (index3 == 0)
            {
              index1 = this.TraceAddWhole(new Graph.Trace($"{this.ParseTracePrefix((Control) this.theForm.textGlobalTracePrefix, (Control) this.theForm.numGlobalTraceN)}Vgs={num2:F3}V", "", this.GetNextColor(), numArray1[0], numArray2[0]), count);
            }
            else
            {
              thisCurve = ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList)[index1];
              thisCurve.AddPoint(numArray1[index3], numArray2[index3]);
            }
            this.MinimumScaleYAxisUpdate();
          }
          else
            index3 = int16_2 - 1;
          if (worker.CancellationPending || this.theForm.thisDCAPro.ConnectedState != DCAProUnit.STATE.CONNECTED)
          {
            flag1 = true;
            break;
          }
          Info.Progress = int16_2 * int16_1 == 0 ? 0 : 100 * (index3 + 1 + index2 * int16_2) / (int16_2 * int16_1);
          worker.ReportProgress(0, (object) Info.Clone());
        }
        int num8 = (int) this.theForm.thisDCAPro.LeadsSafe();
        this.TraceAddTag(thisCurve);
        this.thisZedGraph.AxisChange();
        if (flag1)
          break;
      }
      int num9 = (int) this.theForm.thisDCAPro.Mode(Test.MODE.NONE);
    }
    catch (Exception ex)
    {
      throw;
    }
  }
}
