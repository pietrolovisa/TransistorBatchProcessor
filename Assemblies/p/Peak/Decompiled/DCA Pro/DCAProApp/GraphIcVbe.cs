// Decompiled with JetBrains decompiler
// Type: DCAProApp.GraphIcVbe
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using DCAPro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;

#nullable disable
namespace DCAProApp;

internal class GraphIcVbe : Graph
{
  internal const float VcMin = 0.0f;
  internal const float VcMax = 12f;
  internal const float VbMin = 0.0f;
  internal const float VbMax = 12f;
  internal const float IcMin = 0.0f;
  internal const float IcMax = 12f;
  internal const float IbMin = 0.0f;
  internal const float IbMax = 10000f;

  public GraphIcVbe(frmDCAProApp Parent)
    : base(Parent)
  {
    this.Type = Graph.Types.GRAPH_ICVBE;
    this.TestType = Test.TYPE.BJT;
    this.theMenuItem = this.theForm.IcVbeBJTMenuSubItem;
    this.thisPanel = this.theForm.panelIcVbe;
    this.thisZedGraph = this.theForm.zedGraphIcVbe;
    this.thisStartButton = this.theForm.butStartIcVbe;
    this.thisAutosetButton = this.theForm.butAutosetIcVbe;
    this.thisCheckLockParameters = this.theForm.checkIcVbeLockParameters;
    this.InitControls();
    this.theForm.textIcVbeVbMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIcVbeVbMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIcVbeVcMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIcVbeVcMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIcVbePoints.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIcVbeTraces.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.SetGraphDefaults();
    this.GraphType = "BJT Ic / Vbe";
    this.thisZedGraph.GraphPane.Title.Text = this.GraphType;
    this.thisZedGraph.GraphPane.XAxis.Title.Text = "Vbe";
    this.thisZedGraph.GraphPane.YAxis.Title.Text = "Ic (mA)";
    this.XAxisUnits = "V";
    this.YAxisUnits = "mA";
    this.thisZedGraph.AxisChange();
    this.theForm.textIcVbeVbMin.Text = $"{(ValueType) 0.0f:F1}";
    this.theForm.textIcVbeVbMax.Text = $"{(ValueType) 12f:F1}";
    this.theForm.textIcVbeVcMin.Text = $"{(ValueType) 0.0f:F1}";
    this.theForm.textIcVbeVcMax.Text = $"{(ValueType) 12f:F1}";
    this.theForm.textIcVbePoints.Text = $"{51:D}";
    this.theForm.textIcVbeTraces.Text = $"{5:D}";
    this.UpdateParameterTooltips(this.ToolTipGraph);
    this.CircuitSmall = this.theForm.picIcVbeCircuitSmall;
    this.CircuitLarge = this.theForm.picBJTIcVbeCircuitLarge;
    this.CircuitSmall.Tag = (object) this.CircuitLarge;
    this.CircuitLarge.Location = new Point(this.CircuitLarge.Parent.Width - this.CircuitLarge.Width, this.CircuitLarge.Parent.Height - this.CircuitLarge.Height);
  }

  internal void UpdateParameterTooltips(ToolTip theTooltip)
  {
    theTooltip.SetToolTip((Control) this.theForm.textIcVbeVbMin, $"Applied Vb for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textIcVbeVbMax, $"Applied Vb for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textIcVbeVcMin, $"Applied Vcc for each trace.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textIcVbeVcMax, $"Applied Vcc for each trace.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
  }

  internal override bool SetNewDefaults(Test.unResultDevice Result)
  {
    if (Result.Type == Test.TYPE.BJT)
    {
      this.thisConfig = Result.BJT.Config;
      this.theForm.rtextIcVbeConfig.RenderLeadString(Result.BJT.Config, "E", "C", "B");
      if (!this.ParametersLocked && (double) Result.BJT.Vbe != 0.0)
      {
        this.theForm.textIcVbeVbMax.Text = $"{Result.BJT.Vbe:F1}";
        this.theForm.textIcVbeVbMin.Text = $"{(ValueType) 0.0f:F1}";
      }
    }
    else
    {
      this.theForm.rtextIcVbeConfig.Render("Unknown");
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
      if (!this.theForm.bgWorkerTest.IsBusy && this.thisStartButton.Text == "Start")
      {
        this.StartingPrepareControls();
        this.theForm.bgWorkerTest.RunWorkerAsync((object) ACT.GRAPH_ICVBE);
      }
      else
      {
        if (!this.theForm.bgWorkerTest.IsBusy)
          return;
        this.theForm.bgWorkerTest.CancelAsync();
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
    if (textBox == this.theForm.textIcVbeVcMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textIcVbeVcMin.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textIcVbeVcMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textIcVbeVcMax.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textIcVbeVbMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textIcVbeVbMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textIcVbeVbMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textIcVbeVbMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textIcVbePoints)
    {
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 10000.0)
        result = 10000f;
      textBox.Text = $"{(int) result:D}";
    }
    else
    {
      if (textBox != this.theForm.textIcVbeTraces)
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
      int int16_1 = (int) Convert.ToInt16(this.theForm.textIcVbeTraces.Text);
      int int16_2 = (int) Convert.ToInt16(this.theForm.textIcVbePoints.Text);
      float[] numArray1 = new float[int16_2];
      double[] numArray2 = new double[int16_2];
      double[] numArray3 = new double[int16_2];
      bool flag1 = false;
      Test.CONFIG thisConfig = this.thisConfig;
      double single1 = (double) Convert.ToSingle(this.theForm.textIcVbeVcMin.Text);
      double single2 = (double) Convert.ToSingle(this.theForm.textIcVbeVcMax.Text);
      double single3 = (double) Convert.ToSingle(this.theForm.textIcVbeVbMin.Text);
      double single4 = (double) Convert.ToSingle(this.theForm.textIcVbeVbMax.Text);
      float VSpan = 12.5f;
      if (this.theForm.thisDCAPro.Mode(Test.MODE.ANALOG_USB) != Errors.Type.ErrNone)
        return;
      int index1 = 0;
      int num1 = (int) this.theForm.thisDCAPro.LeadsSafe();
      for (int index2 = 0; index2 < int16_1; ++index2)
      {
        bool flag2 = false;
        CurveItem thisCurve = (CurveItem) null;
        float num2 = int16_1 <= 1 ? (float) single1 : (float) (single1 + (double) index2 * ((single2 - single1) / (double) (int16_1 - 1)));
        float Volts = num2;
        for (int index3 = 0; index3 < int16_2; ++index3)
        {
          numArray1[index3] = int16_2 <= 1 ? (float) single3 : (float) (single3 + (double) index3 * ((single4 - single3) / (double) (int16_2 - 1)));
          Test.RGATE_IDX RIndex = Test.RGATE_IDX.MIN;
          double num3 = (double) this.theForm.thisDCAPro.TRNPowerOn(thisConfig, Test.TON.M1_ON | Test.TON.M2_ON | Test.TON.Gt_ON, VSpan);
          double num4 = 0.0;
          int num5 = (int) this.theForm.thisDCAPro.SetRGate(Test.RGATE_IDX._470k);
          this.theForm.thisDCAPro.TRNSetVgate(thisConfig, 0.0f, VSpan);
          this.theForm.thisDCAPro.DelaymS((ushort) 20);
          int num6 = (int) this.theForm.thisDCAPro.ReadADCSBurst(CORE.REQBIT_M.VR_MT2);
          double ic = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
          int num7 = (int) this.theForm.thisDCAPro.SetRGate(RIndex);
          for (int index4 = 0; index4 < 10; ++index4)
          {
            this.theForm.thisDCAPro.TRNSetVc(thisConfig, Volts, VSpan);
            this.theForm.thisDCAPro.BoostWait();
            if (thisConfig < Test.CONFIG.Ps)
            {
              int num8 = (int) this.theForm.thisDCAPro.SetGateVoltage(numArray1[index3], thisConfig);
            }
            else
            {
              int num9 = (int) this.theForm.thisDCAPro.SetGateVoltage(-numArray1[index3], thisConfig);
            }
            if (!this.theForm.thisDCAPro.WaitForCVOneShot(500, true))
            {
              flag2 = true;
              break;
            }
            double vce = (double) this.theForm.thisDCAPro.DetermineVce(thisConfig);
            num4 = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
            if (num4 > 12.0 || (double) Volts > (double) VSpan)
            {
              flag2 = true;
              break;
            }
            if (!DCAProUnit.EqualTo(vce, (double) num2, 0.1, 0.003))
            {
              Volts += (num2 - (float) vce) / (float) (index4 + 1);
              if (index4 == 19)
                break;
            }
            else
              break;
          }
          if (!flag2)
          {
            numArray3[index3] = num4;
            numArray2[index3] = (double) this.theForm.thisDCAPro.DetermineVbe(thisConfig);
            int count = ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Count;
            if (index3 == 0)
            {
              index1 = this.TraceAddWhole(new Graph.Trace($"{this.ParseTracePrefix((Control) this.theForm.textGlobalTracePrefix, (Control) this.theForm.numGlobalTraceN)}Vce={num2:F2}V", "", this.GetNextColor(), numArray2[0], numArray3[0]), count);
            }
            else
            {
              thisCurve = ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList)[index1];
              thisCurve.AddPoint(numArray2[index3], numArray3[index3]);
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
        int num10 = (int) this.theForm.thisDCAPro.LeadsSafe();
        this.TraceAddTag(thisCurve);
        this.thisZedGraph.AxisChange();
        Thread.Sleep(0);
        if (flag1)
          break;
      }
      int num11 = (int) this.theForm.thisDCAPro.Mode(Test.MODE.NONE);
    }
    catch (Exception ex)
    {
      throw;
    }
  }
}
