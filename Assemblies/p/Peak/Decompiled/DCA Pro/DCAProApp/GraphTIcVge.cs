// Decompiled with JetBrains decompiler
// Type: DCAProApp.GraphTIcVge
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

internal class GraphTIcVge : Graph
{
  internal const float VMin = 0.0f;
  internal const float VMax = 12f;
  internal const float VceMin = 0.0f;
  internal const float VceLoMax = 8f;
  internal const float VceHiMax = 12f;
  internal const float IcMin = 0.0f;
  internal const float IcMax = 12f;
  internal const float VgeMin = -10f;
  internal const float VgeMax = 10f;
  internal const byte Traces = 5;

  public GraphTIcVge(frmDCAProApp Parent)
    : base(Parent)
  {
    this.Type = Graph.Types.GRAPH_TICVGE;
    this.TestType = Test.TYPE.IGBT;
    this.theMenuItem = this.theForm.IcVgeIGBTMenuSubItem;
    this.thisPanel = this.theForm.panelIGBTIcVge;
    this.thisZedGraph = this.theForm.zedGraphTIcVge;
    this.thisStartButton = this.theForm.butStartTIcVge;
    this.thisAutosetButton = this.theForm.butAutosetTIcVge;
    this.thisCheckLockParameters = this.theForm.checkTIcVgeLockParameters;
    this.InitControls();
    this.theForm.textTIcVgeVgeMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textTIcVgeVgeMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textTIcVgePoints.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textTIcVgeVceMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textTIcVgeVceMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textTIcVgeTraces.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.SetGraphDefaults();
    this.GraphType = "IGBT Ic / Vge";
    this.thisZedGraph.GraphPane.Title.Text = this.GraphType;
    this.thisZedGraph.GraphPane.XAxis.Title.Text = "Vge";
    this.thisZedGraph.GraphPane.YAxis.Title.Text = "Ic (mA)";
    this.XAxisUnits = "V";
    this.YAxisUnits = "mA";
    this.theForm.textTIcVgeTraces.Text = $"{(ValueType) (byte) 5:D}";
    this.theForm.textTIcVgePoints.Text = $"{51:D}";
    this.theForm.textTIcVgeVceMax.Text = $"{(ValueType) 12f:F1}";
    this.theForm.textTIcVgeVceMin.Text = $"{(ValueType) 2.4f:F1}";
    this.theForm.textTIcVgeVgeMin.Text = $"{(ValueType) -10f:F1}";
    this.theForm.textTIcVgeVgeMax.Text = $"{(ValueType) 10f:F1}";
    this.UpdateParameterTooltips(this.ToolTipGraph);
    this.CircuitSmall = this.theForm.picIGBTIcVgeCircuitSmall;
    this.CircuitLarge = this.theForm.picIGBTIcVgeCircuitLarge;
    this.CircuitSmall.Tag = (object) this.CircuitLarge;
    this.CircuitLarge.Location = new Point(this.CircuitLarge.Parent.Width - this.CircuitLarge.Width, this.CircuitLarge.Parent.Height - this.CircuitLarge.Height);
  }

  internal void UpdateParameterTooltips(ToolTip theTooltip)
  {
    theTooltip.SetToolTip((Control) this.theForm.textTIcVgeVgeMin, $"Applied Vge for each point.\r\n{(ValueType) -10f:F1}V to {(ValueType) 10f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textTIcVgeVgeMax, $"Applied Vge for each point.\r\n{(ValueType) -10f:F1}V to {(ValueType) 10f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textTIcVgeVceMin, $"Applied Vce for each trace.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 8f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textTIcVgeVceMax, $"Applied Vce for each trace.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
  }

  internal override bool SetNewDefaults(Test.unResultDevice Result)
  {
    if (Result.Type == Test.TYPE.IGBT)
    {
      this.thisConfig = Result.IGBT.Config;
      this.theForm.rtextTIcVgeConfig.RenderLeadString(Result.IGBT.Config, "E", "C", "G");
      if (!this.ParametersLocked)
      {
        double num1 = (double) Result.IGBT.Vgth + (12.0 - (double) Result.IGBT.IcOn) / (double) Result.IGBT.gfe;
        double num2 = (double) Result.IGBT.VgOff + (num1 - (double) Result.IGBT.VgOff) / 5.0;
        double num3 = Math.Round(num1 * 10.0) / 10.0;
        this.theForm.textTIcVgeVgeMin.Text = $"{Math.Round(num2 * 10.0) / 10.0:F1}";
        this.theForm.textTIcVgeVgeMax.Text = $"{num3:F1}";
      }
    }
    else
    {
      this.theForm.rtextTIcVgeConfig.Render("Unknown");
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
        this.theForm.bgWorkerTest.RunWorkerAsync((object) ACT.GRAPH_TICVGE);
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
    if (textBox == this.theForm.textTIcVgeVgeMin)
    {
      if ((double) result < -10.0)
        result = -10f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textTIcVgeVgeMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textTIcVgeVgeMax)
    {
      if ((double) result < -10.0)
        result = -10f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textTIcVgeVgeMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textTIcVgeVceMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 8.0)
        result = 8f;
      float single = Convert.ToSingle(this.theForm.textTIcVgeVceMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textTIcVgeVceMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textTIcVgeVceMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textTIcVgePoints)
    {
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 10000.0)
        result = 10000f;
      textBox.Text = $"{(int) result:D}";
    }
    else
    {
      if (textBox != this.theForm.textTIcVgeTraces)
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
      int int16_1 = (int) Convert.ToInt16(this.theForm.textTIcVgeTraces.Text);
      int int16_2 = (int) Convert.ToInt16(this.theForm.textTIcVgePoints.Text);
      double[] numArray1 = new double[int16_2];
      double[] numArray2 = new double[int16_2];
      bool flag1 = false;
      CurveItem thisCurve = (CurveItem) null;
      Test.CONFIG thisConfig = this.thisConfig;
      double single1 = (double) Convert.ToSingle(this.theForm.textTIcVgeVceMin.Text);
      double single2 = (double) Convert.ToSingle(this.theForm.textTIcVgeVceMax.Text);
      double single3 = (double) Convert.ToSingle(this.theForm.textTIcVgeVgeMin.Text);
      double single4 = (double) Convert.ToSingle(this.theForm.textTIcVgeVgeMax.Text);
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
            if (!this.theForm.thisDCAPro.WaitForCVOneShot(500, true))
            {
              flag2 = true;
              break;
            }
            float vce = this.theForm.thisDCAPro.DetermineVce(thisConfig);
            Vds += (num3 - vce) / (float) (index4 + 1);
          }
          if ((double) this.theForm.thisDCAPro.DetermineIc(thisConfig) > 12.0)
            flag2 = true;
          numArray1[index3] = (double) this.theForm.thisDCAPro.DetermineVbe(thisConfig);
          numArray2[index3] = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
          if (!flag2)
          {
            int count = ((List<CurveItem>) this.thisZedGraph.GraphPane.CurveList).Count;
            if (index3 == 0)
            {
              index1 = this.TraceAddWhole(new Graph.Trace($"{this.ParseTracePrefix((Control) this.theForm.textGlobalTracePrefix, (Control) this.theForm.numGlobalTraceN)}Vce={num3:F2}V", "", this.GetNextColor(), numArray1[0], numArray2[0]), count);
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
        int num7 = (int) this.theForm.thisDCAPro.LeadsSafe();
        this.TraceAddTag(thisCurve);
        this.thisZedGraph.AxisChange();
        if (flag1)
          break;
      }
      this.thisZedGraph.AxisChange();
      int num8 = (int) this.theForm.thisDCAPro.Mode(Test.MODE.NONE);
    }
    catch (Exception ex)
    {
      throw;
    }
  }
}
