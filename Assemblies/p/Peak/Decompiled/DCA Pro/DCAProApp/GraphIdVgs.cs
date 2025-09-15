// Decompiled with JetBrains decompiler
// Type: DCAProApp.GraphIdVgs
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

internal class GraphIdVgs : Graph
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
  internal const byte Traces = 5;

  public GraphIdVgs(frmDCAProApp Parent)
    : base(Parent)
  {
    this.Type = Graph.Types.GRAPH_IDVGS;
    this.TestType = Test.TYPE.MOSFET;
    this.theMenuItem = this.theForm.IdVgsMOSFETMenuSubItem;
    this.thisPanel = this.theForm.panelMIdVgs;
    this.thisZedGraph = this.theForm.zedGraphMIdVgs;
    this.thisStartButton = this.theForm.butStartMIdVgs;
    this.thisAutosetButton = this.theForm.butAutosetMIdVgs;
    this.thisCheckLockParameters = this.theForm.checkMIdVgsLockParameters;
    this.InitControls();
    this.theForm.textMIdVgsVgsMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textMIdVgsVgsMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textMIdVgsPoints.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textMIdVgsVdsMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textMIdVgsVdsMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textMIdVgsTraces.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.SetGraphDefaults();
    this.GraphType = "MOSFET Id / Vgs";
    this.thisZedGraph.GraphPane.Title.Text = this.GraphType;
    this.thisZedGraph.GraphPane.XAxis.Title.Text = "Vgs";
    this.thisZedGraph.GraphPane.YAxis.Title.Text = "Id (mA)";
    this.XAxisUnits = "V";
    this.YAxisUnits = "mA";
    this.theForm.textMIdVgsTraces.Text = $"{(ValueType) (byte) 5:D}";
    this.theForm.textMIdVgsPoints.Text = $"{51:D}";
    this.theForm.textMIdVgsVdsMax.Text = $"{(ValueType) 12f:F1}";
    this.theForm.textMIdVgsVdsMin.Text = $"{(ValueType) 2.4f:F1}";
    this.theForm.textMIdVgsVgsMin.Text = $"{(ValueType) -10f:F1}";
    this.theForm.textMIdVgsVgsMax.Text = $"{(ValueType) 10f:F1}";
    this.UpdateParameterTooltips(this.ToolTipGraph);
    this.CircuitSmall = this.theForm.picMOSIdVgsCircuitSmall;
    this.CircuitLarge = this.theForm.picMOSIdVgsCircuitLarge;
    this.CircuitSmall.Tag = (object) this.CircuitLarge;
    this.CircuitLarge.Location = new Point(this.CircuitLarge.Parent.Width - this.CircuitLarge.Width, this.CircuitLarge.Parent.Height - this.CircuitLarge.Height);
  }

  internal void UpdateParameterTooltips(ToolTip theTooltip)
  {
    theTooltip.SetToolTip((Control) this.theForm.textMIdVgsVgsMin, $"Applied Vgs for each point.\r\n{(ValueType) -10f:F1}V to {(ValueType) 10f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textMIdVgsVgsMax, $"Applied Vgs for each point.\r\n{(ValueType) -10f:F1}V to {(ValueType) 10f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textMIdVgsVdsMin, $"Applied Vds for each trace.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 8f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textMIdVgsVdsMax, $"Applied Vds for each trace.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
  }

  internal override bool SetNewDefaults(Test.unResultDevice Result)
  {
    if (Result.Type == Test.TYPE.MOSFET)
    {
      this.thisConfig = Result.MOSFET.Config;
      this.theForm.rtextIdVgsConfig.RenderLeadString(Result.MOSFET.Config, "S", "D", "G");
      if (!this.ParametersLocked)
      {
        double num1 = (double) Result.MOSFET.Vgth + (12.0 - (double) Result.MOSFET.IdOn) / (double) Result.MOSFET.gm;
        double num2 = (double) Result.MOSFET.VgOff + (num1 - (double) Result.MOSFET.VgOff) / 5.0;
        double num3 = Math.Round(num1 * 10.0) / 10.0;
        this.theForm.textMIdVgsVgsMin.Text = $"{Math.Round(num2 * 10.0) / 10.0:F1}";
        this.theForm.textMIdVgsVgsMax.Text = $"{num3:F1}";
      }
    }
    else
    {
      this.theForm.rtextIdVgsConfig.Render("Unknown");
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
        this.theForm.bgWorkerTest.RunWorkerAsync((object) ACT.GRAPH_IDVGS);
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
    if (textBox == this.theForm.textMIdVgsVgsMin)
    {
      if ((double) result < -10.0)
        result = -10f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textMIdVgsVgsMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textMIdVgsVgsMax)
    {
      if ((double) result < -10.0)
        result = -10f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textMIdVgsVgsMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textMIdVgsVdsMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 8.0)
        result = 8f;
      float single = Convert.ToSingle(this.theForm.textMIdVgsVdsMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textMIdVgsVdsMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textMIdVgsVdsMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textMIdVgsPoints)
    {
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 10000.0)
        result = 10000f;
      textBox.Text = $"{(int) result:D}";
    }
    else
    {
      if (textBox != this.theForm.textMIdVgsTraces)
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
      int int16_1 = (int) Convert.ToInt16(this.theForm.textMIdVgsTraces.Text);
      int int16_2 = (int) Convert.ToInt16(this.theForm.textMIdVgsPoints.Text);
      double[] numArray1 = new double[int16_2];
      double[] numArray2 = new double[int16_2];
      bool flag1 = false;
      CurveItem thisCurve = (CurveItem) null;
      Test.CONFIG thisConfig = this.thisConfig;
      double single1 = (double) Convert.ToSingle(this.theForm.textMIdVgsVdsMin.Text);
      double single2 = (double) Convert.ToSingle(this.theForm.textMIdVgsVdsMax.Text);
      double single3 = (double) Convert.ToSingle(this.theForm.textMIdVgsVgsMin.Text);
      double single4 = (double) Convert.ToSingle(this.theForm.textMIdVgsVgsMax.Text);
      float num1 = (float) single3;
      if (this.theForm.thisDCAPro.Mode(Test.MODE.ANALOG_USB) != Errors.Type.ErrNone)
        return;
      int index1 = 0;
      int num2 = (int) this.theForm.thisDCAPro.LeadsSafe();
      for (int index2 = 0; index2 < int16_1; ++index2)
      {
        bool flag2 = false;
        float num3 = int16_1 > 1 ? (float) (single2 - (double) index2 * (single2 - single1) / (double) (int16_1 - 1)) : (float) single1;
        float Vds = num3;
        int num4 = (int) this.theForm.thisDCAPro.SetRGate(Test.RGATE_IDX._8k2);
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
            float vce = this.theForm.thisDCAPro.DetermineVce(thisConfig);
            Vds += (num3 - vce) / (float) (index4 + 1);
          }
          int num7 = (int) this.theForm.thisDCAPro.ReadADCSBurst(CORE.REQBIT_M.RGB | CORE.REQBIT_M.VR_MT2);
          if ((double) this.theForm.thisDCAPro.DetermineIc(thisConfig) > 12.0)
            flag2 = true;
          numArray1[index3] = (double) this.theForm.thisDCAPro.DetermineVbe(thisConfig);
          numArray2[index3] = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
          if (!flag2)
          {
            int count = ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Count;
            if (index3 == 0)
            {
              index1 = this.TraceAddWhole(new Graph.Trace($"{this.ParseTracePrefix((Control) this.theForm.textGlobalTracePrefix, (Control) this.theForm.numGlobalTraceN)}Vds={num3:F2}V", "", this.GetNextColor(), numArray1[0], numArray2[0]), count);
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
          Info.Progress = 100 * (index3 + 1 + index2 * int16_2) / (int16_2 * int16_1);
          worker.ReportProgress(0, (object) Info.Clone());
        }
        int num8 = (int) this.theForm.thisDCAPro.LeadsSafe();
        this.TraceAddTag(thisCurve);
        this.thisZedGraph.AxisChange();
        if (flag1)
          break;
      }
      this.thisZedGraph.AxisChange();
      int num9 = (int) this.theForm.thisDCAPro.Mode(Test.MODE.NONE);
    }
    catch (Exception ex)
    {
      throw;
    }
  }
}
