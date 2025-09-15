// Decompiled with JetBrains decompiler
// Type: DCAProApp.GraphTIcVce
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

internal class GraphTIcVce : Graph
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

  public GraphTIcVce(frmDCAProApp Parent)
    : base(Parent)
  {
    this.Type = Graph.Types.GRAPH_TICVCE;
    this.TestType = Test.TYPE.IGBT;
    this.theMenuItem = this.theForm.IcVceIGBTMenuSubItem;
    this.thisPanel = this.theForm.panelIGBTIcVce;
    this.thisZedGraph = this.theForm.zedGraphTIcVce;
    this.thisStartButton = this.theForm.butStartTIcVce;
    this.thisAutosetButton = this.theForm.butAutosetTIcVce;
    this.thisCheckLockParameters = this.theForm.checkTIcVceLockParameters;
    this.thisCheckLog = this.theForm.checkTIcVceLog;
    this.InitControls();
    this.theForm.textTIcVceVccMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textTIcVceVccMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textTIcVcePoints.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textTIcVceVgeMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textTIcVceVgeMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textTIcVceTraces.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.SetGraphDefaults();
    this.GraphType = "IGBT Ic / Vce";
    this.thisZedGraph.GraphPane.Title.Text = this.GraphType;
    this.thisZedGraph.GraphPane.XAxis.Title.Text = "Vce";
    this.thisZedGraph.GraphPane.YAxis.Title.Text = "Ic (mA)";
    this.XAxisUnits = "V";
    this.YAxisUnits = "mA";
    this.theForm.textTIcVceVccMin.Text = $"{(ValueType) 0.0f:F1}";
    this.theForm.textTIcVceVccMax.Text = $"{(ValueType) 12f:F1}";
    this.theForm.textTIcVcePoints.Text = $"{51:D}";
    this.theForm.textTIcVceTraces.Text = $"{5:D}";
    this.theForm.textTIcVceVgeMin.Text = $"{(ValueType) -10f:F1}";
    this.theForm.textTIcVceVgeMax.Text = $"{(ValueType) 10f:F1}";
    this.UpdateParameterTooltips(this.ToolTipGraph);
    this.CircuitSmall = this.theForm.picIGBTIcVceCircuitSmall;
    this.CircuitLarge = this.theForm.picIGBTIcVceCircuitLarge;
    this.CircuitSmall.Tag = (object) this.CircuitLarge;
    this.CircuitLarge.Location = new Point(this.CircuitLarge.Parent.Width - this.CircuitLarge.Width, this.CircuitLarge.Parent.Height - this.CircuitLarge.Height);
  }

  internal void UpdateParameterTooltips(ToolTip theTooltip)
  {
    theTooltip.SetToolTip((Control) this.theForm.textTIcVceVccMin, $"Applied Vcc for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 8f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textTIcVceVccMax, $"Applied Vcc for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textTIcVceVgeMin, $"Applied Vge for each trace.\r\n{(ValueType) -10f:F1}V to {(ValueType) 10f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textTIcVceVgeMax, $"Applied Vge for each trace.\r\n{(ValueType) -10f:F1}V to {(ValueType) 10f:F1}V");
  }

  internal override bool SetNewDefaults(Test.unResultDevice Result)
  {
    if (Result.Type == Test.TYPE.IGBT)
    {
      this.thisConfig = Result.IGBT.Config;
      this.theForm.rtextTIcVceConfig.RenderLeadString(Result.IGBT.Config, "E", "C", "G");
      if (!this.ParametersLocked)
      {
        double num1 = Math.Round((double) Result.IGBT.Vgth * 10.0) / 10.0;
        double num2 = Math.Round(((double) Result.IGBT.Vgth - ((double) Result.IGBT.IcOn - (double) Result.IGBT.IcOn2) / (double) Result.IGBT.gfe) * 10.0) / 10.0;
        if (num2 == num1)
        {
          if (num2 >= 0.1)
            num2 = num1 - 0.1;
          else
            num1 += 0.1;
        }
        this.theForm.textTIcVceVgeMin.Text = $"{num2:F1}";
        this.theForm.textTIcVceVgeMax.Text = $"{num1:F1}";
      }
    }
    else
    {
      this.theForm.rtextTIcVceConfig.Render("Unknown");
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
        this.theForm.bgWorkerTest.RunWorkerAsync((object) ACT.GRAPH_TICVCE);
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
    if (textBox == this.theForm.textTIcVceVccMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 8.0)
        result = 8f;
      float single = Convert.ToSingle(this.theForm.textTIcVceVccMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textTIcVceVccMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textTIcVceVccMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textTIcVceVgeMin)
    {
      if ((double) result < -10.0)
        result = -10f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textTIcVceVgeMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textTIcVceVgeMax)
    {
      if ((double) result < -10.0)
        result = -10f;
      if ((double) result > 10.0)
        result = 10f;
      float single = Convert.ToSingle(this.theForm.textTIcVceVgeMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textTIcVcePoints)
    {
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 10000.0)
        result = 10000f;
      textBox.Text = $"{(int) result:D}";
    }
    else
    {
      if (textBox != this.theForm.textTIcVceTraces)
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
      int int16_1 = (int) Convert.ToInt16(this.theForm.textTIcVceTraces.Text);
      int int16_2 = (int) Convert.ToInt16(this.theForm.textTIcVcePoints.Text);
      double[] numArray1 = new double[int16_2];
      double[] numArray2 = new double[int16_2];
      bool flag1 = false;
      bool flag2 = false;
      Test.CONFIG thisConfig = this.thisConfig;
      double single1 = (double) Convert.ToSingle(this.theForm.textTIcVceVccMin.Text);
      double single2 = (double) Convert.ToSingle(this.theForm.textTIcVceVccMax.Text);
      double single3 = (double) Convert.ToSingle(this.theForm.textTIcVceVgeMin.Text);
      double single4 = (double) Convert.ToSingle(this.theForm.textTIcVceVgeMax.Text);
      if (this.theForm.checkTIcVceLog.Checked)
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
              index1 = this.TraceAddWhole(new Graph.Trace($"{this.ParseTracePrefix((Control) this.theForm.textGlobalTracePrefix, (Control) this.theForm.numGlobalTraceN)}Vge={num2:F3}V", "", this.GetNextColor(), numArray1[0], numArray2[0]), count);
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
        int num6 = (int) this.theForm.thisDCAPro.LeadsSafe();
        this.TraceAddTag(thisCurve);
        this.thisZedGraph.AxisChange();
        if (flag1)
          break;
      }
      int num7 = (int) this.theForm.thisDCAPro.Mode(Test.MODE.NONE);
    }
    catch (Exception ex)
    {
      throw;
    }
  }
}
