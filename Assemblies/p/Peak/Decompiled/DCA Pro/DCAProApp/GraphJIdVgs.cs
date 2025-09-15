// Decompiled with JetBrains decompiler
// Type: DCAProApp.GraphJIdVgs
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

internal class GraphJIdVgs : Graph
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

  public GraphJIdVgs(frmDCAProApp Parent)
    : base(Parent)
  {
    this.Type = Graph.Types.GRAPH_JIDVGS;
    this.TestType = Test.TYPE.JFET;
    this.theMenuItem = this.theForm.IdVgsJFETMenuSubItem;
    this.thisPanel = this.theForm.panelJIdVgs;
    this.thisZedGraph = this.theForm.zedGraphJIdVgs;
    this.thisStartButton = this.theForm.butStartJIdVgs;
    this.thisAutosetButton = this.theForm.butAutosetJIdVgs;
    this.thisCheckLockParameters = this.theForm.checkJIdVgsLockParameters;
    this.InitControls();
    this.theForm.textJIdVgsVgsMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textJIdVgsVgsMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textJIdVgsPoints.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textJIdVgsVdsMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textJIdVgsVdsMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.SetGraphDefaults();
    this.GraphType = "JFET Id / Vgs";
    this.thisZedGraph.GraphPane.Title.Text = this.GraphType;
    this.thisZedGraph.GraphPane.XAxis.Title.Text = "Vgs";
    this.thisZedGraph.GraphPane.YAxis.Title.Text = "Id (mA)";
    this.XAxisUnits = "V";
    this.YAxisUnits = "mA";
    this.theForm.textJIdVgsPoints.Text = $"{51:D}";
    this.theForm.textJIdVgsTraces.Text = $"{5:D}";
    this.theForm.textJIdVgsVgsMin.Text = $"{(ValueType) -10f:F1}";
    this.theForm.textJIdVgsVgsMax.Text = $"{(ValueType) 10f:F1}";
    this.theForm.textJIdVgsVdsMin.Text = $"{(ValueType) 0.0f:F1}";
    this.theForm.textJIdVgsVdsMax.Text = $"{(ValueType) 12f:F1}";
    this.UpdateParameterTooltips(this.ToolTipGraph);
    this.CircuitSmall = this.theForm.picJFETIdVgsCircuitSmall;
    this.CircuitLarge = this.theForm.picJFETIdVgsCircuitLarge;
    this.CircuitSmall.Tag = (object) this.CircuitLarge;
    this.CircuitLarge.Location = new Point(this.CircuitLarge.Parent.Width - this.CircuitLarge.Width, this.CircuitLarge.Parent.Height - this.CircuitLarge.Height);
  }

  internal void UpdateParameterTooltips(ToolTip theTooltip)
  {
    theTooltip.SetToolTip((Control) this.theForm.textJIdVgsVdsMin, $"Applied Vgs for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 8f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textJIdVgsVdsMax, $"Applied Vgs for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textJIdVgsVgsMin, $"Applied Vds for each trace.\r\n{(ValueType) -10f:F1}V to {(ValueType) 10f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textJIdVgsVgsMax, $"Applied Vds for each trace.\r\n{(ValueType) -10f:F1}V to {(ValueType) 10f:F1}V");
  }

  internal override bool SetNewDefaults(Test.unResultDevice Result)
  {
    if (Result.Type == Test.TYPE.JFET)
    {
      this.theForm.comboJIdVgsConfig.Items.Clear();
      this.thisConfig = Result.JFET.Config;
      this.AltConfigs[0] = this.thisConfig;
      this.theForm.comboJIdVgsConfig.Items.Add((object) Display.LeadString(this.thisConfig, "S", "D", "G"));
      if ((Result.JFET.Flags & Test.JFETFlags.MirroredDS) != (Test.JFETFlags) 0)
      {
        this.AltConfigs[1] = Test.ConfigSwap12(this.AltConfigs[0]);
        this.theForm.comboJIdVgsConfig.Items.Add((object) Display.LeadString(this.AltConfigs[1], "S", "D", "G"));
      }
      this.theForm.comboJIdVgsConfig.SelectedIndex = 0;
      if (!this.ParametersLocked)
      {
        this.VgMax = Math.Round((double) Result.JFET.VgsOn * 10.0) / 10.0;
        this.VgMin = Math.Round((double) Result.JFET.VgsOff * 10.0) / 10.0;
        this.theForm.textJIdVgsVgsMin.Text = $"{this.VgMin:F1}";
        this.theForm.textJIdVgsVgsMax.Text = $"{this.VgMax:F1}";
        this.theForm.textJIdVgsVdsMin.Text = $"{(ValueType) 0.0f:F1}";
        this.theForm.textJIdVgsVdsMax.Text = $"{12.0 + Math.Round(this.VgMin - 0.5, 0):F1}";
      }
    }
    else
    {
      this.theForm.comboJIdVgsConfig.Items.Clear();
      this.thisConfig = Test.CONFIG.NONE;
      this.AltConfigs[0] = this.thisConfig;
      this.theForm.comboJIdVgsConfig.Items.Add((object) "Unknown");
      this.theForm.comboJIdVgsConfig.SelectedIndex = 0;
      this.thisStartButton.Enabled = false;
    }
    this.UpdateParameterTooltips(this.ToolTipGraph);
    return true;
  }

  internal override Test.CONFIG GetConfig()
  {
    return this.AltConfigs[this.theForm.comboJIdVgsConfig.SelectedIndex];
  }

  internal override void NewResult_Event(object sender, frmDCAProApp.AResult e)
  {
    this.SetNewDefaults(e.Result);
  }

  internal override void ValidateText(object sender, CancelEventArgs e)
  {
    TextBox textBox = sender as TextBox;
    float result;
    if (!float.TryParse(textBox.Text, out result))
      textBox.Text = $"{0.0:F1}";
    if (textBox == this.theForm.textJIdVgsVdsMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 8.0)
        result = 8f;
      float single = Convert.ToSingle(this.theForm.textJIdVgsVdsMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textJIdVgsVdsMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textJIdVgsVdsMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textJIdVgsVgsMin)
    {
      if ((double) result < -10.0)
        result = -10f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textJIdVgsVgsMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textJIdVgsVgsMax)
    {
      if ((double) result < -10.0)
        result = -10f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textJIdVgsVgsMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textJIdVgsPoints)
    {
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 10000.0)
        result = 10000f;
      textBox.Text = $"{(int) result:D}";
    }
    else
    {
      if (textBox != this.theForm.textJIdVgsTraces)
        return;
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 100.0)
        result = 100f;
      textBox.Text = $"{(int) result:D}";
    }
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
        this.theForm.bgWorkerTest.RunWorkerAsync((object) ACT.GRAPH_JIDVGS);
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal override void DoGraph(BackgroundWorker worker, WorkResult Info)
  {
    try
    {
      int int16_1 = (int) Convert.ToInt16(this.theForm.textJIdVgsTraces.Text);
      int int16_2 = (int) Convert.ToInt16(this.theForm.textJIdVgsPoints.Text);
      double[] numArray1 = new double[int16_2];
      double[] numArray2 = new double[int16_2];
      bool flag1 = false;
      Test.CONFIG thisConfig = this.thisConfig;
      double single1 = (double) Convert.ToSingle(this.theForm.textJIdVgsVdsMin.Text);
      double single2 = (double) Convert.ToSingle(this.theForm.textJIdVgsVdsMax.Text);
      double single3 = (double) Convert.ToSingle(this.theForm.textJIdVgsVgsMin.Text);
      double single4 = (double) Convert.ToSingle(this.theForm.textJIdVgsVgsMax.Text);
      float num1 = (float) single3;
      this.thisZedGraph.GraphPane.IsIgnoreInitial = true;
      if (this.theForm.thisDCAPro.Mode(Test.MODE.ANALOG_USB) != Errors.Type.ErrNone)
        return;
      int index1 = 0;
      int num2 = (int) this.theForm.thisDCAPro.LeadsSafe();
      int num3 = (int) this.theForm.thisDCAPro.SetRGate(Test.RGATE_IDX._8k2);
      for (int index2 = 0; index2 < int16_1; ++index2)
      {
        bool flag2 = false;
        CurveItem thisCurve = (CurveItem) null;
        float num4 = int16_1 <= 1 ? (float) single1 : (float) (single1 + (double) index2 * (single2 - single1) / (double) (int16_1 - 1));
        float Vds = num4;
        this.theForm.thisDCAPro.FETPowerOn(thisConfig, num1, 12f);
        this.theForm.thisDCAPro.FETSetVdsVgs(thisConfig, Vds, num1, 12f);
        for (int index3 = 0; index3 < int16_2; ++index3)
        {
          num1 = int16_2 <= 1 ? (float) single3 : (float) (single3 + (double) index3 * ((single4 - single3) / (double) (int16_2 - 1)));
          for (int index4 = 0; index4 < 5; ++index4)
          {
            if (!this.theForm.thisDCAPro.FETSetVds(thisConfig, Vds, num1, 12f))
            {
              flag2 = true;
              break;
            }
            this.theForm.thisDCAPro.BoostWait();
            if (thisConfig < Test.CONFIG.Ps)
            {
              int num5 = (int) this.theForm.thisDCAPro.SetGateVoltage(num1, thisConfig);
            }
            else
            {
              int num6 = (int) this.theForm.thisDCAPro.SetGateVoltage(-num1, thisConfig);
            }
            if (!this.theForm.thisDCAPro.WaitForCVOneShot(500, false))
            {
              flag2 = true;
              break;
            }
            double vce = (double) this.theForm.thisDCAPro.DetermineVce(thisConfig);
            if (!DCAProUnit.EqualTo(vce, (double) num4, 0.1, 0.003))
              Vds += (num4 - (float) vce) / (float) (index4 + 1);
            else
              break;
          }
          int num7 = (int) this.theForm.thisDCAPro.ReadADCSBurst(CORE.REQBIT_M.RGB | CORE.REQBIT_M.VR_MT2);
          if (!flag2)
          {
            double ic = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
            if ((double) Vds > 57.0 / 5.0)
              flag2 = true;
            if (ic > 12.0)
              flag2 = true;
            if (!flag2)
            {
              numArray1[index3] = (double) this.theForm.thisDCAPro.DetermineVbe(thisConfig);
              numArray2[index3] = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
              int count = ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Count;
              if (index3 == 0)
              {
                index1 = this.TraceAddWhole(new Graph.Trace($"{this.ParseTracePrefix((Control) this.theForm.textGlobalTracePrefix, (Control) this.theForm.numGlobalTraceN)}Vds={num4:F3}V", "", this.GetNextColor(), numArray1[0], numArray2[0]), count);
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
          else
            break;
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
