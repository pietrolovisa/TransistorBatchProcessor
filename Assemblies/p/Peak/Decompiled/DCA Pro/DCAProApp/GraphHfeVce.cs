// Decompiled with JetBrains decompiler
// Type: DCAProApp.GraphHfeVce
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

internal class GraphHfeVce : Graph
{
  internal const float VMin = 0.0f;
  internal const float VMax = 12f;
  internal const float IcMin = 0.0f;
  internal const float IcMax = 12f;
  internal const float IbMin = 4f;
  internal const float IbMax = 10000f;
  internal const byte MaxTraces = 5;
  internal double IMax = 4.0;
  internal double RIbMax = 4.0;
  internal double RIbMin = 4.0;

  public GraphHfeVce(frmDCAProApp Parent)
    : base(Parent)
  {
    this.Type = Graph.Types.GRAPH_HFEVCE;
    this.TestType = Test.TYPE.BJT;
    this.theMenuItem = this.theForm.HfeVceBJTMenuSubItem;
    this.thisPanel = this.theForm.panelHFEVce;
    this.thisZedGraph = this.theForm.zedGraphHfeVce;
    this.thisStartButton = this.theForm.butStartHfeVce;
    this.thisAutosetButton = this.theForm.butAutosetHfeVce;
    this.thisCheckLockParameters = this.theForm.checkHfeVceLockParameters;
    this.InitControls();
    this.theForm.textHfeVceVcMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textHfeVceVcMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textHfeVceBaseuIMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textHfeVceBaseuIMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textHfeVcePoints.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textHfeVceBaseTraces.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.SetGraphDefaults();
    this.MinYSpan = 20.0;
    this.MinYSpanRound = 5.0;
    this.GraphType = "BJT hFE / Vce";
    this.thisZedGraph.GraphPane.Title.Text = this.GraphType;
    this.thisZedGraph.GraphPane.XAxis.Title.Text = "Vce";
    this.thisZedGraph.GraphPane.YAxis.Title.Text = "hFE";
    this.XAxisUnits = "V";
    this.YAxisUnits = "hFE";
    this.theForm.textHfeVceVcMin.Text = $"{(ValueType) 0.0f:F1}";
    this.theForm.textHfeVceVcMax.Text = $"{(ValueType) 12f:F1}";
    this.theForm.textHfeVcePoints.Text = $"{51:D}";
    this.theForm.textHfeVceBaseTraces.Text = $"{5:D}";
    this.theForm.textHfeVceBaseuIMin.Text = $"{(ValueType) 4f:F1}";
    this.theForm.textHfeVceBaseuIMax.Text = $"{(ValueType) 4f:F1}";
    this.UpdateParameterTooltips(this.ToolTipGraph);
    this.CircuitSmall = this.theForm.picBJTHfeVceCircuitSmall;
    this.CircuitLarge = this.theForm.picBJTHfeVceCircuitLarge;
    this.CircuitSmall.Tag = (object) this.CircuitLarge;
    this.CircuitLarge.Location = new Point(this.CircuitLarge.Parent.Width - this.CircuitLarge.Width, this.CircuitLarge.Parent.Height - this.CircuitLarge.Height);
  }

  internal void UpdateParameterTooltips(ToolTip theTooltip)
  {
    theTooltip.SetToolTip((Control) this.theForm.textHfeVceVcMin, $"Applied Vcc for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textHfeVceVcMax, $"Applied Vcc for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textHfeVceBaseuIMin, $"Applied Ib for each trace.\r\n{(ValueType) 4f:F1}µA to {(ValueType) 10000f:F1}µA");
    theTooltip.SetToolTip((Control) this.theForm.textHfeVceBaseuIMax, $"Applied Ib for each trace.\r\n{(ValueType) 4f:F1}µA to {(ValueType) 10000f:F1}µA");
  }

  internal override bool SetNewDefaults(Test.unResultDevice Result)
  {
    if (Result.Type == Test.TYPE.BJT)
    {
      this.thisConfig = Result.BJT.Config;
      this.theForm.rtextHfeVceConfig.RenderLeadString(Result.BJT.Config, "E", "C", "B");
      if (!this.ParametersLocked)
      {
        if ((double) Result.BJT.HFE != 0.0)
          this.IMax = 10000.0 / (double) Result.BJT.HFE;
        if (this.IMax < 4.0)
        {
          this.RIbMax = 4.0;
          this.RIbMin = 4.0;
          this.theForm.textHfeVceBaseTraces.Text = "1";
        }
        else if (this.IMax / 2.0 < 4.0)
        {
          this.RIbMax = Math.Round(this.IMax);
          this.RIbMin = this.RIbMax;
          this.theForm.textHfeVceBaseTraces.Text = "1";
        }
        else if (this.IMax / 3.0 < 4.0)
        {
          this.RIbMin = Math.Round(this.IMax / 2.0);
          this.RIbMax = this.RIbMin * 2.0;
          this.theForm.textHfeVceBaseTraces.Text = "2";
        }
        else if (this.IMax / 4.0 < 4.0)
        {
          this.RIbMin = Math.Round(this.IMax / 3.0);
          this.RIbMax = this.RIbMin * 3.0;
          this.theForm.textHfeVceBaseTraces.Text = "3";
        }
        else if (this.IMax / 5.0 < 4.0)
        {
          this.RIbMin = Math.Round(this.IMax / 4.0);
          this.RIbMax = this.RIbMin * 4.0;
          this.theForm.textHfeVceBaseTraces.Text = "4";
        }
        else
        {
          this.RIbMin = Math.Round(this.IMax / 5.0);
          this.RIbMax = this.RIbMin * 5.0;
          this.theForm.textHfeVceBaseTraces.Text = "5";
        }
        this.theForm.textHfeVceBaseuIMax.Text = $"{this.RIbMax:F1}";
        this.theForm.textHfeVceBaseuIMin.Text = $"{this.RIbMin:F1}";
      }
    }
    else
    {
      this.theForm.rtextHfeVceConfig.Render("Unknown");
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
        this.theForm.bgWorkerTest.RunWorkerAsync((object) ACT.GRAPH_HFEVCE);
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
    if (textBox == this.theForm.textHfeVceVcMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textHfeVceVcMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textHfeVceVcMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textHfeVceVcMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textHfeVceBaseuIMin)
    {
      if ((double) result < 4.0)
        result = 4f;
      if ((double) result > 10000.0)
        result = 10000f;
      float single = Convert.ToSingle(this.theForm.textHfeVceBaseuIMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textHfeVceBaseuIMax)
    {
      if ((double) result < 4.0)
        result = 4f;
      if ((double) result > 10000.0)
        result = 10000f;
      float single = Convert.ToSingle(this.theForm.textHfeVceBaseuIMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textHfeVcePoints)
    {
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 10000.0)
        result = 10000f;
      textBox.Text = $"{(int) result:D}";
    }
    else
    {
      if (textBox != this.theForm.textHfeVceBaseTraces)
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
      int int16_1 = (int) Convert.ToInt16(this.theForm.textHfeVceBaseTraces.Text);
      int int16_2 = (int) Convert.ToInt16(this.theForm.textHfeVcePoints.Text);
      double[] numArray1 = new double[int16_2];
      double[] numArray2 = new double[int16_2];
      double[] numArray3 = new double[int16_2];
      double num1 = Convert.ToDouble(this.theForm.textHfeVceBaseuIMax.Text) / 1000.0;
      double num2 = Convert.ToDouble(this.theForm.textHfeVceBaseuIMin.Text) / 1000.0;
      bool flag1 = false;
      double Volts = Convert.ToDouble(this.theForm.textHfeVceVcMin.Text);
      double num3 = Convert.ToDouble(this.theForm.textHfeVceVcMax.Text);
      Test.CONFIG thisConfig = this.thisConfig;
      if (this.theForm.thisDCAPro.Mode(Test.MODE.ANALOG_USB) != Errors.Type.ErrNone)
        return;
      int index1 = 0;
      int num4 = (int) this.theForm.thisDCAPro.LeadsSafe();
      for (int index2 = 0; index2 < int16_1; ++index2)
      {
        bool flag2 = false;
        CurveItem thisCurve = (CurveItem) null;
        float Current = int16_1 <= 1 ? (float) num1 : (float) (num1 - (double) index2 * ((num1 - num2) / (double) (int16_1 - 1)));
        double num5 = 10200.0 / (double) Current;
        Test.RGATE_IDX RIndex;
        for (RIndex = Test.RGATE_IDX._470k; RIndex >= Test.RGATE_IDX.MIN; --RIndex)
        {
          int num6 = (int) this.theForm.thisDCAPro.SetRGate(RIndex);
          if ((double) this.theForm.thisDCAPro.RGate < num5)
            break;
        }
        double num7 = (double) this.theForm.thisDCAPro.TRNPowerOn(thisConfig, Test.TON.M1_ON | Test.TON.M2_ON | Test.TON.Gt_ON, 12f);
        this.theForm.thisDCAPro.TRNSetVc(thisConfig, (float) Volts, 12f);
        this.theForm.thisDCAPro.BoostWait();
        if (thisConfig < Test.CONFIG.Ps)
        {
          int num8 = (int) this.theForm.thisDCAPro.SetGateCurrent(Current);
        }
        else
        {
          int num9 = (int) this.theForm.thisDCAPro.SetGateCurrent(-Current);
        }
        this.theForm.thisDCAPro.DelaymS((ushort) 24);
        for (int index3 = 0; index3 < int16_2; ++index3)
        {
          numArray1[index3] = int16_2 <= 1 ? Volts : Volts + (double) index3 * (num3 - Volts) / (double) (int16_2 - 1);
          this.theForm.thisDCAPro.TRNSetVc(thisConfig, (float) numArray1[index3], 12f);
          this.theForm.thisDCAPro.BoostWait();
          if (thisConfig < Test.CONFIG.Ps)
          {
            int num10 = (int) this.theForm.thisDCAPro.SetGateCurrent(Current);
          }
          else
          {
            int num11 = (int) this.theForm.thisDCAPro.SetGateCurrent(-Current);
          }
          if (!this.theForm.thisDCAPro.WaitForCCOneShot(200, true))
            break;
          double ic1 = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
          numArray2[index3] = (double) this.theForm.thisDCAPro.DetermineVce(thisConfig);
          double ib = (double) this.theForm.thisDCAPro.DetermineIb(thisConfig);
          int num12 = (int) this.theForm.thisDCAPro.SetRGate(Test.RGATE_IDX._470k);
          this.theForm.thisDCAPro.TRNSetVgate(thisConfig, 0.0f, 12f);
          this.theForm.thisDCAPro.DelaymS((ushort) 20);
          int num13 = (int) this.theForm.thisDCAPro.ReadADCSBurst(CORE.REQBIT_M.VR_MT2);
          float ic2 = this.theForm.thisDCAPro.DetermineIc(thisConfig);
          int num14 = (int) this.theForm.thisDCAPro.SetRGate(RIndex);
          if (ic1 > 12.0)
            flag2 = true;
          if (!flag2)
          {
            numArray3[index3] = ib == 0.0 ? 0.0 : (ic1 - (double) ic2) / ib;
            int count = ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Count;
            if (index3 == 0)
            {
              index1 = this.TraceAddWhole(new Graph.Trace($"{this.ParseTracePrefix((Control) this.theForm.textGlobalTracePrefix, (Control) this.theForm.numGlobalTraceN)}Ib={(ValueType) (float) ((double) Current * 1000.0):F1}µA", "", this.GetNextColor(), numArray2[0], numArray3[0]), count);
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
        int num15 = (int) this.theForm.thisDCAPro.LeadsSafe();
        this.TraceAddTag(thisCurve);
        this.thisZedGraph.AxisChange();
        Thread.Sleep(0);
        if (flag1)
          break;
      }
      int num16 = (int) this.theForm.thisDCAPro.Mode(Test.MODE.NONE);
    }
    catch (Exception ex)
    {
      throw;
    }
  }
}
