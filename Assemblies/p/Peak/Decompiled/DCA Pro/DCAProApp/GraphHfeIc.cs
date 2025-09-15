// Decompiled with JetBrains decompiler
// Type: DCAProApp.GraphHfeIc
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

internal class GraphHfeIc : Graph
{
  internal const float VMin = 0.0f;
  internal const float VStart = 2f;
  internal const float VMax = 10f;
  internal const float IcMin = 0.0f;
  internal const float IcMax = 12f;
  internal const float IbMin = 4f;
  internal const float IbMax = 10000f;
  internal const byte MaxTraces = 5;
  internal double IMax = 4.0;
  internal double RIbMax = 4.0;
  internal double RIbMin = 4.0;

  public GraphHfeIc(frmDCAProApp Parent)
    : base(Parent)
  {
    this.Type = Graph.Types.GRAPH_HFEIC;
    this.TestType = Test.TYPE.BJT;
    this.theMenuItem = this.theForm.HfeIcBJTMenuSubItem;
    this.thisPanel = this.theForm.panelHFEIc;
    this.thisZedGraph = this.theForm.zedGraphHfeIc;
    this.thisStartButton = this.theForm.butStartHfeIc;
    this.thisAutosetButton = this.theForm.butAutosetHfeIc;
    this.thisCheckLockParameters = this.theForm.checkHfeIcLockParameters;
    this.InitControls();
    this.theForm.textHfeIcVcMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textHfeIcVcMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textHfeIcBaseuIMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textHfeIcBaseuIMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textHfeIcPoints.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textHfeIcTraces.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.SetGraphDefaults();
    this.MinYSpan = 20.0;
    this.MinYSpanRound = 5.0;
    this.GraphType = "BJT hFE / Ic";
    this.thisZedGraph.GraphPane.Title.Text = this.GraphType;
    this.thisZedGraph.GraphPane.XAxis.Title.Text = "Ic (mA)";
    this.thisZedGraph.GraphPane.YAxis.Title.Text = "hFE";
    this.XAxisUnits = "mA";
    this.YAxisUnits = "hFE";
    this.theForm.textHfeIcVcMin.Text = $"{(ValueType) 2f:F1}";
    this.theForm.textHfeIcVcMax.Text = $"{(ValueType) 10f:F1}";
    this.theForm.textHfeIcPoints.Text = $"{51:D}";
    this.theForm.textHfeIcTraces.Text = $"{5:D}";
    this.theForm.textHfeIcBaseuIMin.Text = $"{(ValueType) 4f:F1}";
    this.theForm.textHfeIcBaseuIMax.Text = $"{(ValueType) 4f:F1}";
    this.UpdateParameterTooltips(this.ToolTipGraph);
    this.CircuitSmall = this.theForm.picBJTHfeIcCircuitSmall;
    this.CircuitLarge = this.theForm.picBJTHfeIcCircuitLarge;
    this.CircuitSmall.Tag = (object) this.CircuitLarge;
    this.CircuitLarge.Location = new Point(this.CircuitLarge.Parent.Width - this.CircuitLarge.Width, this.CircuitLarge.Parent.Height - this.CircuitLarge.Height);
  }

  internal void UpdateParameterTooltips(ToolTip theTooltip)
  {
    theTooltip.SetToolTip((Control) this.theForm.textHfeIcBaseuIMin, $"Applied Ib for each point.\r\n{(ValueType) 4f:F1}µA to {(ValueType) 10000f:F1}µA");
    theTooltip.SetToolTip((Control) this.theForm.textHfeIcBaseuIMax, $"Applied Ib for each point.\r\n{(ValueType) 4f:F1}µA to {(ValueType) 10000f:F1}µA");
    theTooltip.SetToolTip((Control) this.theForm.textHfeIcVcMin, $"Applied Vce for each trace.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 10f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textHfeIcVcMax, $"Applied Vce for each trace.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 10f:F1}V");
  }

  internal override bool SetNewDefaults(Test.unResultDevice Result)
  {
    if (Result.Type == Test.TYPE.BJT)
    {
      this.thisConfig = Result.BJT.Config;
      this.theForm.rtextHfeIcConfig.RenderLeadString(Result.BJT.Config, "E", "C", "B");
      if (!this.ParametersLocked)
      {
        if ((double) Result.BJT.HFE != 0.0)
          this.IMax = 10000.0 / (double) Result.BJT.HFE;
        if (this.IMax < 4.0)
        {
          this.RIbMax = 4.0;
          this.RIbMin = 4.0;
          this.theForm.textHfeIcPoints.Text = "1";
        }
        else if (this.IMax / 2.0 < 4.0)
        {
          this.RIbMax = Math.Round(this.IMax);
          this.RIbMin = this.RIbMax;
          this.theForm.textHfeIcPoints.Text = "1";
        }
        else if (this.IMax / 3.0 < 4.0)
        {
          this.RIbMin = Math.Round(this.IMax / 2.0);
          this.RIbMax = this.RIbMin * 2.0;
          this.theForm.textHfeIcPoints.Text = "2";
        }
        else if (this.IMax / 4.0 < 4.0)
        {
          this.RIbMin = Math.Round(this.IMax / 3.0);
          this.RIbMax = this.RIbMin * 3.0;
          this.theForm.textHfeIcPoints.Text = "3";
        }
        else if (this.IMax / 5.0 < 4.0)
        {
          this.RIbMin = Math.Round(this.IMax / 4.0);
          this.RIbMax = this.RIbMin * 4.0;
          this.theForm.textHfeIcPoints.Text = "4";
        }
        else
        {
          this.RIbMin = Math.Round(this.IMax / 5.0);
          this.RIbMax = this.RIbMin * 5.0;
          this.theForm.textHfeIcPoints.Text = "5";
        }
        this.theForm.textHfeIcPoints.Text = "21";
        this.theForm.textHfeIcBaseuIMax.Text = $"{this.RIbMax:F1}";
        this.theForm.textHfeIcBaseuIMin.Text = $"{this.RIbMin:F1}";
      }
    }
    else
    {
      this.theForm.rtextHfeIcConfig.Render("Unknown");
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
        this.theForm.bgWorkerTest.RunWorkerAsync((object) ACT.GRAPH_HFEIC);
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
    if (textBox == this.theForm.textHfeIcVcMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textHfeIcVcMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textHfeIcVcMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textHfeIcVcMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textHfeIcBaseuIMin)
    {
      if ((double) result < 4.0)
        result = 4f;
      if ((double) result > 10000.0)
        result = 10000f;
      float single = Convert.ToSingle(this.theForm.textHfeIcBaseuIMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textHfeIcBaseuIMax)
    {
      if ((double) result < 4.0)
        result = 4f;
      if ((double) result > 10000.0)
        result = 10000f;
      float single = Convert.ToSingle(this.theForm.textHfeIcBaseuIMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textHfeIcPoints)
    {
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 10000.0)
        result = 10000f;
      textBox.Text = $"{(int) result:D}";
    }
    else
    {
      if (textBox != this.theForm.textHfeIcTraces)
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
      int int16_1 = (int) Convert.ToInt16(this.theForm.textHfeIcTraces.Text);
      int int16_2 = (int) Convert.ToInt16(this.theForm.textHfeIcPoints.Text);
      float[] numArray1 = new float[int16_2];
      double[] numArray2 = new double[int16_2];
      double[] numArray3 = new double[int16_2];
      double num1 = Convert.ToDouble(this.theForm.textHfeIcBaseuIMax.Text) / 1000.0;
      double num2 = Convert.ToDouble(this.theForm.textHfeIcBaseuIMin.Text) / 1000.0;
      bool flag1 = false;
      double num3 = Convert.ToDouble(this.theForm.textHfeIcVcMin.Text);
      double num4 = Convert.ToDouble(this.theForm.textHfeIcVcMax.Text);
      Test.CONFIG thisConfig = this.thisConfig;
      if (this.theForm.thisDCAPro.Mode(Test.MODE.ANALOG_USB) != Errors.Type.ErrNone)
        return;
      int index1 = 0;
      int num5 = (int) this.theForm.thisDCAPro.LeadsSafe();
      for (int index2 = 0; index2 < int16_1; ++index2)
      {
        bool flag2 = false;
        CurveItem thisCurve = (CurveItem) null;
        float num6 = int16_1 <= 1 ? (float) num3 : (float) (num3 + (double) index2 * ((num4 - num3) / (double) (int16_1 - 1)));
        float Volts = num6;
        for (int index3 = 0; index3 < int16_2; ++index3)
        {
          numArray1[index3] = int16_2 <= 1 ? (float) num2 : (float) (num2 + (double) index3 * ((num1 - num2) / (double) (int16_2 - 1)));
          double num7 = 8200.0 / (double) numArray1[index3];
          Test.RGATE_IDX RIndex;
          for (RIndex = Test.RGATE_IDX._470k; RIndex >= Test.RGATE_IDX.MIN; --RIndex)
          {
            int num8 = (int) this.theForm.thisDCAPro.SetRGate(RIndex);
            if ((double) this.theForm.thisDCAPro.RGate < num7)
              break;
          }
          double num9 = (double) this.theForm.thisDCAPro.TRNPowerOn(thisConfig, Test.TON.M1_ON | Test.TON.M2_ON | Test.TON.Gt_ON, 12f);
          double num10 = 0.0;
          for (int index4 = 0; index4 < 10; ++index4)
          {
            this.theForm.thisDCAPro.TRNSetVc(thisConfig, Volts, 12f);
            this.theForm.thisDCAPro.BoostWait();
            if (thisConfig < Test.CONFIG.Ps)
            {
              int num11 = (int) this.theForm.thisDCAPro.SetGateCurrent(numArray1[index3]);
            }
            else
            {
              int num12 = (int) this.theForm.thisDCAPro.SetGateCurrent(-numArray1[index3]);
            }
            if (!this.theForm.thisDCAPro.WaitForCCOneShot(500, true))
            {
              flag2 = true;
              break;
            }
            double vce = (double) this.theForm.thisDCAPro.DetermineVce(thisConfig);
            num10 = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
            if (num10 > 12.0 || (double) Volts > 12.0)
            {
              flag2 = true;
              break;
            }
            if (!DCAProUnit.EqualTo(vce, (double) num6, 0.1, 0.003))
              Volts += (num6 - (float) vce) / (float) (index4 + 1);
            else
              break;
          }
          int num13 = (int) this.theForm.thisDCAPro.SetRGate(Test.RGATE_IDX._470k);
          this.theForm.thisDCAPro.TRNSetVgate(thisConfig, 0.0f, 12f);
          this.theForm.thisDCAPro.DelaymS((ushort) 20);
          int num14 = (int) this.theForm.thisDCAPro.ReadADCSBurst(CORE.REQBIT_M.VR_MT2);
          double ic = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
          int num15 = (int) this.theForm.thisDCAPro.SetRGate(RIndex);
          if (!flag2)
          {
            numArray2[index3] = num10;
            double ib = (double) this.theForm.thisDCAPro.DetermineIb(thisConfig);
            numArray3[index3] = ib == 0.0 ? 0.0 : (num10 - ic) / ib;
            int count = ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Count;
            if (index3 == 0)
            {
              index1 = this.TraceAddWhole(new Graph.Trace($"{this.ParseTracePrefix((Control) this.theForm.textGlobalTracePrefix, (Control) this.theForm.numGlobalTraceN)}Vce={num6:F2}V", "", this.GetNextColor(), numArray2[0], numArray3[0]), count);
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
        int num16 = (int) this.theForm.thisDCAPro.LeadsSafe();
        this.TraceAddTag(thisCurve);
        this.thisZedGraph.AxisChange();
        Thread.Sleep(0);
        if (flag1)
          break;
      }
      int num17 = (int) this.theForm.thisDCAPro.Mode(Test.MODE.NONE);
    }
    catch (Exception ex)
    {
      throw;
    }
  }
}
