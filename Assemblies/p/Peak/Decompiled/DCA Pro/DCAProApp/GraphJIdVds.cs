// Decompiled with JetBrains decompiler
// Type: DCAProApp.GraphJIdVds
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

internal class GraphJIdVds : Graph
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
  internal double VgMax;
  internal double VgMin;
  internal Test.CONFIG[] AltConfigs = new Test.CONFIG[2];

  public GraphJIdVds(frmDCAProApp Parent)
    : base(Parent)
  {
    this.Type = Graph.Types.GRAPH_JIDVDS;
    this.TestType = Test.TYPE.JFET;
    this.theMenuItem = this.theForm.IdVdsJFETMenuSubItem;
    this.thisPanel = this.theForm.panelJIdVds;
    this.thisZedGraph = this.theForm.zedGraphJIdVds;
    this.thisStartButton = this.theForm.butStartJIdVds;
    this.thisAutosetButton = this.theForm.butAutosetJIdVds;
    this.thisCheckLockParameters = this.theForm.checkJIdVdsLockParameters;
    this.InitControls();
    this.theForm.textJIdVdsVdsMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textJIdVdsVdsMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textJIdVdsVgsMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textJIdVdsVgsMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textJIdVdsPoints.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textJIdVdsTraces.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.SetGraphDefaults();
    this.GraphType = "JFET Id / Vds";
    this.thisZedGraph.GraphPane.Title.Text = this.GraphType;
    this.thisZedGraph.GraphPane.XAxis.Title.Text = "Vds";
    this.thisZedGraph.GraphPane.YAxis.Title.Text = "Id (mA)";
    this.XAxisUnits = "V";
    this.YAxisUnits = "mA";
    this.theForm.textJIdVdsVdsMin.Text = $"{(ValueType) 0.0f:F1}";
    this.theForm.textJIdVdsVdsMax.Text = $"{(ValueType) 12f:F1}";
    this.theForm.textJIdVdsPoints.Text = $"{51:D}";
    this.theForm.textJIdVdsTraces.Text = $"{5:D}";
    this.theForm.textJIdVdsVgsMin.Text = $"{(ValueType) -10f:F1}";
    this.theForm.textJIdVdsVgsMax.Text = $"{(ValueType) 10f:F1}";
    this.UpdateParameterTooltips(this.ToolTipGraph);
    this.CircuitSmall = this.theForm.picJFETIdVdsCircuitSmall;
    this.CircuitLarge = this.theForm.picJFETIdVdsCircuitLarge;
    this.CircuitSmall.Tag = (object) this.CircuitLarge;
    this.CircuitLarge.Location = new Point(this.CircuitLarge.Parent.Width - this.CircuitLarge.Width, this.CircuitLarge.Parent.Height - this.CircuitLarge.Height);
  }

  internal void UpdateParameterTooltips(ToolTip theTooltip)
  {
    theTooltip.SetToolTip((Control) this.theForm.textJIdVdsVdsMin, $"Applied Vdd for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 8f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textJIdVdsVdsMax, $"Applied Vdd for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textJIdVdsVgsMin, $"Applied Vgs for each trace.\r\n{(ValueType) -10f:F1}V to {(ValueType) 10f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textJIdVdsVgsMax, $"Applied Vgs for each trace.\r\n{(ValueType) -10f:F1}V to {(ValueType) 10f:F1}V");
  }

  internal override bool SetNewDefaults(Test.unResultDevice Result)
  {
    if (Result.Type == Test.TYPE.JFET)
    {
      this.theForm.comboJIdVdsConfig.Items.Clear();
      this.thisConfig = Result.JFET.Config;
      this.AltConfigs[0] = this.thisConfig;
      this.theForm.comboJIdVdsConfig.Items.Add((object) Display.LeadString(this.thisConfig, "S", "D", "G"));
      if ((Result.JFET.Flags & Test.JFETFlags.MirroredDS) != (Test.JFETFlags) 0)
      {
        this.AltConfigs[1] = Test.ConfigSwap12(this.AltConfigs[0]);
        this.theForm.comboJIdVdsConfig.Items.Add((object) Display.LeadString(this.AltConfigs[1], "S", "D", "G"));
      }
      this.theForm.comboJIdVdsConfig.SelectedIndex = 0;
      if (!this.ParametersLocked)
      {
        this.VgMax = Math.Round((double) Result.JFET.VgsOn * 10.0) / 10.0;
        this.VgMin = Math.Round(((double) Result.JFET.VgsOn - ((double) Result.JFET.IdOn - (double) Result.JFET.IdOn2) / (double) Result.JFET.gfs) * 10.0) / 10.0;
        if (this.VgMin == this.VgMax)
        {
          if (this.VgMin >= 0.1)
            this.VgMin = this.VgMax - 0.1;
          else
            this.VgMax += 0.1;
        }
        this.theForm.textJIdVdsVgsMin.Text = $"{this.VgMin:F1}";
        this.theForm.textJIdVdsVgsMax.Text = $"{this.VgMax:F1}";
        this.theForm.textJIdVdsVdsMin.Text = $"{(ValueType) 0.0f:F1}";
        this.theForm.textJIdVdsVdsMax.Text = $"{12.0 + Math.Round(this.VgMin - 0.5, 0):F1}";
      }
    }
    else
    {
      this.theForm.comboJIdVdsConfig.Items.Clear();
      this.thisConfig = Test.CONFIG.NONE;
      this.AltConfigs[0] = this.thisConfig;
      this.theForm.comboJIdVdsConfig.Items.Add((object) "Unknown");
      this.theForm.comboJIdVdsConfig.SelectedIndex = 0;
      this.thisStartButton.Enabled = false;
    }
    this.UpdateParameterTooltips(this.ToolTipGraph);
    return true;
  }

  internal override Test.CONFIG GetConfig()
  {
    return this.AltConfigs[this.theForm.comboJIdVdsConfig.SelectedIndex];
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
        this.thisConfig = this.GetConfig();
        this.StartingPrepareControls();
        this.theForm.bgWorkerTest.RunWorkerAsync((object) ACT.GRAPH_JIDVDS);
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
    if (textBox == this.theForm.textJIdVdsVdsMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 8.0)
        result = 8f;
      float single = Convert.ToSingle(this.theForm.textJIdVdsVdsMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textJIdVdsVdsMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textJIdVdsVdsMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textJIdVdsVgsMin)
    {
      if ((double) result < -10.0)
        result = -10f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textJIdVdsVgsMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textJIdVdsVgsMax)
    {
      if ((double) result < -10.0)
        result = -10f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textJIdVdsVgsMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textJIdVdsPoints)
    {
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 10000.0)
        result = 10000f;
      textBox.Text = $"{(int) result:D}";
    }
    else
    {
      if (textBox != this.theForm.textJIdVdsTraces)
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
      int int16_1 = (int) Convert.ToInt16(this.theForm.textJIdVdsTraces.Text);
      int int16_2 = (int) Convert.ToInt16(this.theForm.textJIdVdsPoints.Text);
      double[] numArray1 = new double[int16_2];
      double[] numArray2 = new double[int16_2];
      bool flag1 = false;
      Test.CONFIG thisConfig = this.thisConfig;
      double single1 = (double) Convert.ToSingle(this.theForm.textJIdVdsVdsMin.Text);
      double single2 = (double) Convert.ToSingle(this.theForm.textJIdVdsVdsMax.Text);
      double single3 = (double) Convert.ToSingle(this.theForm.textJIdVdsVgsMin.Text);
      double single4 = (double) Convert.ToSingle(this.theForm.textJIdVdsVgsMax.Text);
      if (this.theForm.thisDCAPro.Mode(Test.MODE.ANALOG_USB) != Errors.Type.ErrNone)
        return;
      int index1 = 0;
      int num1 = (int) this.theForm.thisDCAPro.LeadsSafe();
      int num2 = (int) this.theForm.thisDCAPro.SetRGate(Test.RGATE_IDX._8k2);
      for (int index2 = 0; index2 < int16_1; ++index2)
      {
        bool flag2 = false;
        CurveItem thisCurve = (CurveItem) null;
        float num3 = int16_1 <= 1 ? (float) single3 : (float) (single3 + (double) index2 * (single4 - single3) / (double) (int16_1 - 1));
        float Vds1 = (float) single1;
        this.theForm.thisDCAPro.FETPowerOn(thisConfig, num3, 12f);
        this.theForm.thisDCAPro.FETSetVdsVgs(thisConfig, Vds1, num3, 12f);
        if (thisConfig < Test.CONFIG.Ps)
        {
          int num4 = (int) this.theForm.thisDCAPro.SetGateVoltage(num3, thisConfig);
        }
        else
        {
          int num5 = (int) this.theForm.thisDCAPro.SetGateVoltage(-num3, thisConfig);
        }
        this.theForm.thisDCAPro.DelaymS((ushort) 24);
        for (int index3 = 0; index3 < int16_2; ++index3)
        {
          float Vds2 = int16_2 <= 1 ? (float) single1 : (float) (single1 + (double) index3 * (single2 - single1) / (double) (int16_2 - 1));
          if (!this.theForm.thisDCAPro.FETSetVds(thisConfig, Vds2, num3, 12f))
            flag2 = true;
          if (thisConfig < Test.CONFIG.Ps)
          {
            int num6 = (int) this.theForm.thisDCAPro.SetGateVoltage(num3, thisConfig);
          }
          else
          {
            int num7 = (int) this.theForm.thisDCAPro.SetGateVoltage(-num3, thisConfig);
          }
          this.theForm.thisDCAPro.BoostWait();
          if (!this.theForm.thisDCAPro.WaitForCVOneShot(500, true))
            flag2 = true;
          double ic = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
          if ((double) this.theForm.thisDCAPro.DetermineIc(thisConfig) > 12.0)
            flag2 = true;
          numArray1[index3] = (double) this.theForm.thisDCAPro.DetermineVce(thisConfig);
          numArray2[index3] = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
          if (!flag2)
          {
            int count = ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Count;
            if (index3 == 0)
            {
              index1 = this.TraceAddWhole(new Graph.Trace($"{this.ParseTracePrefix((Control) this.theForm.textGlobalTracePrefix, (Control) this.theForm.numGlobalTraceN)}Vgs={num3:F3}V", "", this.GetNextColor(), numArray1[0], numArray2[0]), count);
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
