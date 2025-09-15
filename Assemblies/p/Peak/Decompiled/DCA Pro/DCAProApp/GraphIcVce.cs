// Decompiled with JetBrains decompiler
// Type: DCAProApp.GraphIcVce
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

internal class GraphIcVce : Graph
{
  internal const float VMin = 0.0f;
  internal const float VMax = 12f;
  internal const float IcMin = 0.0f;
  internal const float IcMax = 12f;
  internal const float IbMin = 0.0f;
  internal const float IbMax = 10000f;
  internal const byte MaxTraces = 5;
  internal double IMax;
  internal double RIbMax;
  internal double RIbMin;

  public GraphIcVce(frmDCAProApp Parent)
    : base(Parent)
  {
    this.Type = Graph.Types.GRAPH_ICVCE;
    this.TestType = Test.TYPE.BJT;
    this.theMenuItem = this.theForm.IcVceBJTMenuSubItem;
    this.thisPanel = this.theForm.panelIcVce;
    this.thisZedGraph = this.theForm.zedGraphIcVce;
    this.thisStartButton = this.theForm.butStartIcVce;
    this.thisAutosetButton = this.theForm.butAutosetIcVce;
    this.thisCheckLockParameters = this.theForm.checkIcVceLockParameters;
    this.InitControls();
    this.theForm.textIcVceVcMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIcVceVcMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIcVceBaseuIMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIcVceBaseuIMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIcVcePoints.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textIcVceBaseTraces.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.SetGraphDefaults();
    this.GraphType = "BJT Ic / Vce";
    this.thisZedGraph.GraphPane.Title.Text = this.GraphType;
    this.thisZedGraph.GraphPane.XAxis.Title.Text = "Vce";
    this.thisZedGraph.GraphPane.YAxis.Title.Text = "Ic (mA)";
    this.XAxisUnits = "V";
    this.YAxisUnits = "mA";
    this.theForm.textIcVceVcMin.Text = $"{(ValueType) 0.0f:F1}";
    this.theForm.textIcVceVcMax.Text = $"{(ValueType) 12f:F1}";
    this.theForm.textIcVcePoints.Text = $"{51:D}";
    this.theForm.textIcVceBaseTraces.Text = $"{5:D}";
    this.theForm.textIcVceBaseuIMin.Text = $"{(ValueType) 0.0f:F1}";
    this.theForm.textIcVceBaseuIMax.Text = $"{(ValueType) 0.0f:F1}";
    this.UpdateParameterTooltips(this.ToolTipGraph);
    this.CircuitSmall = this.theForm.picBJTIcVceCircuitSmall;
    this.CircuitLarge = this.theForm.picBJTIcVceCircuitLarge;
    this.CircuitSmall.Tag = (object) this.CircuitLarge;
    this.CircuitLarge.Location = new Point(this.CircuitLarge.Parent.Width - this.CircuitLarge.Width, this.CircuitLarge.Parent.Height - this.CircuitLarge.Height);
  }

  internal void UpdateParameterTooltips(ToolTip theTooltip)
  {
    theTooltip.SetToolTip((Control) this.theForm.textIcVceVcMin, $"Applied Vcc for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textIcVceVcMax, $"Applied Vcc for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textIcVceBaseuIMin, $"Applied Ib for each trace.\r\n{(ValueType) 0.0f:F1}µA to {(ValueType) 10000f:F1}µA");
    theTooltip.SetToolTip((Control) this.theForm.textIcVceBaseuIMax, $"Applied Ib for each trace.\r\n{(ValueType) 0.0f:F1}µA to {(ValueType) 10000f:F1}µA");
  }

  internal override bool SetNewDefaults(Test.unResultDevice Result)
  {
    if (Result.Type == Test.TYPE.BJT)
    {
      this.thisConfig = Result.BJT.Config;
      this.theForm.rtextIcVceConfig.RenderLeadString(Result.BJT.Config, "E", "C", "B");
      if (!this.ParametersLocked)
      {
        if ((double) Result.BJT.HFE != 0.0)
          this.IMax = 10000.0 / (double) Result.BJT.HFE;
        if (this.IMax < 0.0)
        {
          this.RIbMax = 0.0;
          this.RIbMin = 0.0;
          this.theForm.textIcVceBaseTraces.Text = "1";
        }
        else if (this.IMax / 2.0 < 0.0)
        {
          this.RIbMax = Math.Round(this.IMax);
          this.RIbMin = this.RIbMax;
          this.theForm.textIcVceBaseTraces.Text = "1";
        }
        else if (this.IMax / 3.0 < 0.0)
        {
          this.RIbMin = Math.Round(this.IMax / 2.0);
          this.RIbMax = this.RIbMin * 2.0;
          this.theForm.textIcVceBaseTraces.Text = "2";
        }
        else if (this.IMax / 4.0 < 0.0)
        {
          this.RIbMin = Math.Round(this.IMax / 3.0);
          this.RIbMax = this.RIbMin * 3.0;
          this.theForm.textIcVceBaseTraces.Text = "3";
        }
        else if (this.IMax / 5.0 < 0.0)
        {
          this.RIbMin = Math.Round(this.IMax / 4.0);
          this.RIbMax = this.RIbMin * 4.0;
          this.theForm.textIcVceBaseTraces.Text = "4";
        }
        else
        {
          this.RIbMin = Math.Round(this.IMax / 5.0);
          this.RIbMax = this.RIbMin * 5.0;
          this.theForm.textIcVceBaseTraces.Text = "5";
        }
        this.theForm.textIcVceBaseuIMax.Text = $"{this.RIbMax:F1}";
        this.theForm.textIcVceBaseuIMin.Text = $"{this.RIbMin:F1}";
      }
    }
    else
    {
      this.theForm.rtextIcVceConfig.Render("Unknown");
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
        this.theForm.bgWorkerTest.RunWorkerAsync((object) ACT.GRAPH_ICVCE);
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
    if (textBox == this.theForm.textIcVceVcMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textIcVceVcMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textIcVceVcMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textIcVceVcMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textIcVceBaseuIMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 10000.0)
        result = 10000f;
      float single = Convert.ToSingle(this.theForm.textIcVceBaseuIMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textIcVceBaseuIMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 10000.0)
        result = 10000f;
      float single = Convert.ToSingle(this.theForm.textIcVceBaseuIMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textIcVcePoints)
    {
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 10000.0)
        result = 10000f;
      textBox.Text = $"{(int) result:D}";
    }
    else
    {
      if (textBox != this.theForm.textIcVceBaseTraces)
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
      int int16_1 = (int) Convert.ToInt16(this.theForm.textIcVceBaseTraces.Text);
      int int16_2 = (int) Convert.ToInt16(this.theForm.textIcVcePoints.Text);
      double[] numArray1 = new double[int16_2];
      double[] numArray2 = new double[int16_2];
      double num1 = Convert.ToDouble(this.theForm.textIcVceBaseuIMax.Text) / 1000.0;
      double num2 = Convert.ToDouble(this.theForm.textIcVceBaseuIMin.Text) / 1000.0;
      bool flag1 = false;
      double Volts = Convert.ToDouble(this.theForm.textIcVceVcMin.Text);
      double num3 = Convert.ToDouble(this.theForm.textIcVceVcMax.Text);
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
        for (Test.RGATE_IDX RIndex = Test.RGATE_IDX._470k; RIndex >= Test.RGATE_IDX.MIN; --RIndex)
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
          if (!this.theForm.thisDCAPro.WaitForCCOneShot(200, true))
            break;
          if ((double) this.theForm.thisDCAPro.DetermineIc(thisConfig) > 12.0)
            flag2 = true;
          if (!flag2)
          {
            numArray1[index3] = (double) this.theForm.thisDCAPro.DetermineVce(thisConfig);
            numArray2[index3] = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
            int count = ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Count;
            if (index3 == 0)
            {
              index1 = this.TraceAddWhole(new Graph.Trace($"{this.ParseTracePrefix((Control) this.theForm.textGlobalTracePrefix, (Control) this.theForm.numGlobalTraceN)}Ib={(ValueType) (float) ((double) Current * 1000.0):F1}µA", "", this.GetNextColor(), numArray1[0], numArray2[0]), count);
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
