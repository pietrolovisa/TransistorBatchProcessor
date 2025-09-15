// Decompiled with JetBrains decompiler
// Type: DCAProApp.GraphVRegVoVi
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

internal class GraphVRegVoVi : Graph
{
  internal const float VMin = 0.0f;
  internal const float VMax = 12f;
  internal const float IdMin = 0.0f;
  internal const float IdMax = 12f;
  internal int Polarity = 1;

  public GraphVRegVoVi(frmDCAProApp Parent)
    : base(Parent)
  {
    this.Type = Graph.Types.GRAPH_VREGOI;
    this.TestType = Test.TYPE.VREG;
    this.theMenuItem = this.theForm.VoutVinVRegMenuSubItem;
    this.thisPanel = this.theForm.panelVRegVoutVin;
    this.thisZedGraph = this.theForm.zedGraphVRegVoVi;
    this.thisStartButton = this.theForm.butStartVRegVoVi;
    this.InitControls();
    this.theForm.textVRegVoViViMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textVRegVoViViMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.textVRegVoViPoints.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.SetGraphDefaults();
    this.GraphType = "Voltage Regulator Vout & Iq / Vin";
    this.thisZedGraph.GraphPane.Title.Text = this.GraphType;
    this.thisZedGraph.GraphPane.XAxis.Title.Text = "Vin";
    this.thisZedGraph.GraphPane.YAxis.Title.Text = "Vout";
    this.thisZedGraph.GraphPane.Y2Axis.Title.Text = "Iq (mA)";
    this.thisZedGraph.GraphPane.Y2Axis.IsVisible = true;
    this.thisZedGraph.GraphPane.YAxis.MajorTic.IsOpposite = false;
    this.thisZedGraph.GraphPane.YAxis.MinorTic.IsOpposite = false;
    this.thisZedGraph.GraphPane.Y2Axis.MajorTic.IsOpposite = false;
    this.thisZedGraph.GraphPane.Y2Axis.MinorTic.IsOpposite = false;
    this.thisZedGraph.GraphPane.Y2Axis.MajorGrid.IsVisible = false;
    this.thisZedGraph.GraphPane.Y2Axis.Scale.Align = AlignP.Inside;
    this.thisZedGraph.GraphPane.Y2Axis.Scale.Min = 0.0;
    this.thisZedGraph.GraphPane.Y2Axis.Scale.Max = 1.0;
    this.XAxisUnits = "V";
    this.YAxisUnits = "V";
    this.Y2AxisUnits = "mA";
    this.theForm.textVRegVoViViMin.Text = $"{0.0:F1}";
    this.theForm.textVRegVoViViMax.Text = $"{12.0:F1}";
    this.theForm.textVRegVoViPoints.Text = $"{51:D}";
    this.UpdateParameterTooltips(this.ToolTipGraph);
    this.CircuitSmall = this.theForm.picVRegVoViSmall;
    this.CircuitLarge = this.theForm.picVRegVoViLarge;
    this.CircuitSmall.Tag = (object) this.CircuitLarge;
    this.CircuitLarge.Location = new Point(this.CircuitLarge.Parent.Width - this.CircuitLarge.Width, this.CircuitLarge.Parent.Height - this.CircuitLarge.Height);
  }

  internal void UpdateParameterTooltips(ToolTip theTooltip)
  {
    theTooltip.SetToolTip((Control) this.theForm.textVRegVoViViMin, $"Applied Vs for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.textVRegVoViViMax, $"Applied Vs for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
  }

  internal override bool SetNewDefaults(Test.unResultDevice Result)
  {
    if (Result.Type == Test.TYPE.VREG)
    {
      this.thisConfig = Result.VReg.Config;
      this.theForm.rtextVRegVoViConfig.RenderLeadString(Result.VReg.Config, "In", "GND", "Out");
      if (!this.ParametersLocked)
        this.Polarity = (double) Result.VReg.VReg >= 0.0 ? 1 : -1;
    }
    else
    {
      this.theForm.rtextVRegVoViConfig.Render("Unknown");
      this.thisStartButton.Enabled = false;
    }
    this.UpdateParameterTooltips(this.ToolTipGraph);
    return true;
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
    if (textBox == this.theForm.textVRegVoViViMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textVRegVoViViMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.textVRegVoViViMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.textVRegVoViViMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else
    {
      if (textBox != this.theForm.textVRegVoViPoints)
        return;
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 10000.0)
        result = 10000f;
      textBox.Text = $"{(int) result:D}";
    }
  }

  internal override void buttonStart_Click(object sender, EventArgs e)
  {
    try
    {
      if (!this.theForm.bgWorkerTest.IsBusy && this.thisStartButton.Text == "Start")
      {
        this.StartingPrepareControls();
        this.theForm.bgWorkerTest.RunWorkerAsync((object) ACT.GRAPH_VREGOI);
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

  internal override void DoGraph(BackgroundWorker worker, WorkResult Info)
  {
    try
    {
      int int16 = (int) Convert.ToInt16(this.theForm.textVRegVoViPoints.Text);
      double[] numArray1 = new double[int16];
      double[] numArray2 = new double[int16];
      double[] numArray3 = new double[int16];
      CurveItem thisCurve1 = (CurveItem) null;
      CurveItem thisCurve2 = (CurveItem) null;
      double num1 = Convert.ToDouble(this.theForm.textVRegVoViViMin.Text);
      double num2 = Convert.ToDouble(this.theForm.textVRegVoViViMax.Text);
      double num3 = 0.0;
      double num4 = 0.0;
      double num5 = -1.0;
      bool flag1 = false;
      Test.CONFIG thisConfig = this.thisConfig;
      float VMax = 12.5f;
      if (this.theForm.thisDCAPro.Mode(Test.MODE.ANALOG_USB) != Errors.Type.ErrNone)
        return;
      int num6 = (int) this.theForm.thisDCAPro.LeadsSafe();
      int num7 = (int) this.theForm.thisDCAPro.SetRGate(Test.RGATE_IDX.MIN);
      double num8 = (num2 - num1) / (double) (int16 - 1);
      float SetVIn = (float) num1;
      for (int index = 0; index < int16; ++index)
      {
        bool flag2 = true;
        while (flag2 && !flag1)
        {
          this.theForm.thisDCAPro.VRegPowerOn(thisConfig, SetVIn, VMax);
          this.theForm.thisDCAPro.DelaymS((ushort) 20);
          int num9 = (int) this.theForm.thisDCAPro.ReadADCSBurst(CORE.REQBIT_M.RGB | CORE.REQBIT_M.VR_MT2);
          num3 = (double) this.theForm.thisDCAPro.DetermineVce(thisConfig);
          num4 = (double) this.theForm.thisDCAPro.DetermineIc(thisConfig);
          if (num3 < 0.0)
            num3 = 0.0;
          if (num3 > num2 || num4 > 12.0)
            flag1 = true;
          if (num3 > num5)
          {
            flag2 = false;
            num5 = num3;
          }
          SetVIn += (float) num8;
          if ((double) SetVIn > (double) VMax)
            flag1 = true;
        }
        if (!flag1)
        {
          numArray1[index] = num3;
          numArray2[index] = (double) this.Polarity * (double) this.theForm.thisDCAPro.DetermineVcb(thisConfig);
          if (thisConfig < Test.CONFIG.Ps)
          {
            if (numArray2[index] > 0.0)
              numArray2[index] = 0.0;
          }
          else if (numArray2[index] < 0.0)
            numArray2[index] = 0.0;
          numArray3[index] = num4;
          if (index == 0)
          {
            int num10 = 0;
            string tracePrefix = this.ParseTracePrefix((Control) this.theForm.textGlobalTracePrefix, (Control) this.theForm.numGlobalTraceN);
            bool flag3;
            string NewLabel1;
            string NewLabel2;
            do
            {
              flag3 = false;
              ++num10;
              NewLabel1 = $"{tracePrefix}Vout{num10}";
              NewLabel2 = $"{tracePrefix}Iq{num10}";
              foreach (CurveItem curve in (List<CurveItem>) this.thisZedGraph.GraphPane.CurveList)
              {
                if (curve.Label.Text == NewLabel1 || curve.Label.Text == NewLabel2)
                {
                  flag3 = true;
                  break;
                }
              }
            }
            while (flag3);
            thisCurve1 = this.TraceAddWhole(new Graph.Trace(NewLabel1, "", this.GetNextColor(), numArray1[0], numArray2[0]));
            thisCurve2 = this.TraceAddWhole(new Graph.Trace(NewLabel2, "", this.GetNextColor(), numArray1[0], numArray3[0]), true);
          }
          else
          {
            thisCurve1.AddPoint(numArray1[index], numArray2[index]);
            thisCurve2.AddPoint(numArray1[index], numArray3[index]);
          }
          this.MinimumScaleYAxisUpdate();
          if (!worker.CancellationPending && this.theForm.thisDCAPro.ConnectedState == DCAProUnit.STATE.CONNECTED)
          {
            Info.Progress = 100 * (index + 1) / int16;
            worker.ReportProgress(0, (object) Info.Clone());
          }
          else
            break;
        }
        else
          break;
      }
      int num11 = (int) this.theForm.thisDCAPro.LeadsSafe();
      this.TraceAddTag(thisCurve1);
      this.TraceAddTag(thisCurve2, true);
      this.thisZedGraph.AxisChange();
      int num12 = (int) this.theForm.thisDCAPro.Mode(Test.MODE.NONE);
    }
    catch (Exception ex)
    {
      throw;
    }
  }
}
