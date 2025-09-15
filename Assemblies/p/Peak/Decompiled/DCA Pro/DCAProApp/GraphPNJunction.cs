// Decompiled with JetBrains decompiler
// Type: DCAProApp.GraphPNJunction
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

internal class GraphPNJunction : Graph
{
  internal const float VMin = 0.0f;
  internal const float VMax = 12f;
  internal const float IdMin = 0.0f;
  internal const float IdMax = 12f;
  private Graph.PNOtherIndex thisSpareLeadType;
  internal int thisTestPolarity;
  internal Test.DRIVE RedLeadDrive;
  internal Test.DRIVE GreenLeadDrive;
  internal Test.DRIVE BlueLeadDrive;
  internal List<string> LabelItems = new List<string>();

  public GraphPNJunction(frmDCAProApp Parent)
    : base(Parent)
  {
    this.Type = Graph.Types.GRAPH_PN;
    this.TestType = Test.TYPE.NONE;
    this.theMenuItem = this.theForm.PNJunctMenuItem;
    this.thisPanel = this.theForm.panelPNJunction;
    this.thisZedGraph = this.theForm.zedGraphPNJunct;
    this.thisStartButton = this.theForm.butStartPN;
    this.InitControls();
    this.theForm.TextPNVMin.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.TextPNVMax.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.theForm.TextPNPoints.Validating += new CancelEventHandler(((Graph) this).ValidateText);
    this.SetGraphDefaults();
    this.GraphType = "PN Junction I / V";
    this.thisZedGraph.GraphPane.Title.Text = this.GraphType;
    this.thisZedGraph.GraphPane.XAxis.Title.Text = "Vf";
    this.thisZedGraph.GraphPane.YAxis.Title.Text = "I (mA)";
    this.XAxisUnits = "V";
    this.YAxisUnits = "mA";
    this.theForm.comboPNAnode.Items.Add((object) "Red");
    this.theForm.comboPNAnode.Items.Add((object) "Green");
    this.theForm.comboPNAnode.Items.Add((object) "Blue");
    this.theForm.comboPNAnode.SelectedIndex = 0;
    this.theForm.comboPNCathode.Items.Add((object) "Red");
    this.theForm.comboPNCathode.Items.Add((object) "Green");
    this.theForm.comboPNCathode.Items.Add((object) "Blue");
    this.theForm.comboPNCathode.SelectedIndex = 1;
    this.LabelItems.Add("Red");
    this.LabelItems.Add("Green");
    this.LabelItems.Add("Blue");
    this.theForm.comboPNOther.Items.Add((object) "Open");
    this.theForm.comboPNOther.Items.Add((object) "470kΩ to Anode");
    this.theForm.comboPNOther.Items.Add((object) "470kΩ to Cathode");
    this.theForm.comboPNOther.Items.Add((object) "Low Ω to Anode");
    this.theForm.comboPNOther.Items.Add((object) "Low Ω to Cathode");
    this.theForm.comboPNOther.SelectedIndex = 0;
    this.theForm.comboPNBias.Items.Add((object) "Forward");
    this.theForm.comboPNBias.Items.Add((object) "Reverse");
    this.theForm.comboPNBias.SelectedIndex = 0;
    this.theForm.TextPNVMin.Text = $"{(ValueType) 0.0f:F1}";
    this.theForm.TextPNVMax.Text = $"{(ValueType) 12f:F1}";
    this.theForm.TextPNPoints.Text = $"{51:D}";
    this.UpdateParameterTooltips(this.ToolTipGraph);
    this.CircuitSmall = this.theForm.picPNCircuitSmall;
    this.CircuitLarge = this.theForm.picPNCircuitLarge;
    this.CircuitSmall.Tag = (object) this.CircuitLarge;
    this.CircuitLarge.Location = new Point(this.CircuitLarge.Parent.Width - this.CircuitLarge.Width, this.CircuitLarge.Parent.Height - this.CircuitLarge.Height);
  }

  private void AddLeadLabels(string Item)
  {
    try
    {
      this.theForm.comboPNAnode.Items.Add((object) Item);
      this.theForm.comboPNCathode.Items.Add((object) Item);
      this.LabelItems.Add(Item);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void AddLeadLabels(string Item, string Label)
  {
    try
    {
      this.theForm.comboPNAnode.Items.Add((object) Item);
      this.theForm.comboPNCathode.Items.Add((object) Item);
      this.LabelItems.Add(Label);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void ClearLeadLabels()
  {
    try
    {
      this.theForm.comboPNAnode.Items.Clear();
      this.theForm.comboPNCathode.Items.Clear();
      this.LabelItems.Clear();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void UpdateParameterTooltips(ToolTip theTooltip)
  {
    theTooltip.SetToolTip((Control) this.theForm.TextPNVMin, $"Applied Vs for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
    theTooltip.SetToolTip((Control) this.theForm.TextPNVMax, $"Applied Vs for each point.\r\n{(ValueType) 0.0f:F1}V to {(ValueType) 12f:F1}V");
  }

  internal override bool SetNewDefaults(Test.unResultDevice Result)
  {
    switch (Result.Type)
    {
      case Test.TYPE.NONE:
      case Test.TYPE.SHORT:
        this.ClearLeadLabels();
        this.AddLeadLabels("Red");
        this.AddLeadLabels("Green");
        this.AddLeadLabels("Blue");
        this.theForm.comboPNAnode.SelectedIndex = 0;
        this.theForm.comboPNCathode.SelectedIndex = 1;
        this.theForm.comboPNOther.SelectedIndex = 0;
        break;
      case Test.TYPE.BJT:
        this.ClearLeadLabels();
        this.AddLeadLabels($"{Display.Colour2(Result.BJT.Config)}-C", "C");
        this.AddLeadLabels($"{Display.ColourG(Result.BJT.Config)}-B", "B");
        this.AddLeadLabels($"{Display.Colour1(Result.BJT.Config)}-E", "E");
        if (Result.BJT.Config < Test.CONFIG.Ps)
        {
          this.theForm.comboPNAnode.SelectedIndex = 1;
          this.theForm.comboPNCathode.SelectedIndex = 2;
          this.theForm.comboPNOther.SelectedIndex = 1;
          break;
        }
        this.theForm.comboPNAnode.SelectedIndex = 2;
        this.theForm.comboPNCathode.SelectedIndex = 1;
        this.theForm.comboPNOther.SelectedIndex = 2;
        break;
      case Test.TYPE.MOSFET:
        this.ClearLeadLabels();
        this.AddLeadLabels($"{Display.Colour2(Result.MOSFET.Config)}-D", "D");
        this.AddLeadLabels($"{Display.ColourG(Result.MOSFET.Config)}-G", "G");
        this.AddLeadLabels($"{Display.Colour1(Result.MOSFET.Config)}-S", "S");
        if (Result.MOSFET.Config < Test.CONFIG.Ps)
        {
          this.theForm.comboPNAnode.SelectedIndex = 2;
          this.theForm.comboPNCathode.SelectedIndex = 0;
          this.theForm.comboPNOther.SelectedIndex = 1;
          break;
        }
        this.theForm.comboPNAnode.SelectedIndex = 0;
        this.theForm.comboPNCathode.SelectedIndex = 2;
        this.theForm.comboPNOther.SelectedIndex = 2;
        break;
      case Test.TYPE.IGBT:
        this.ClearLeadLabels();
        this.AddLeadLabels($"{Display.Colour2(Result.IGBT.Config)}-C", "C");
        this.AddLeadLabels($"{Display.ColourG(Result.IGBT.Config)}-G", "G");
        this.AddLeadLabels($"{Display.Colour1(Result.IGBT.Config)}-E", "E");
        if (Result.IGBT.Config < Test.CONFIG.Ps)
        {
          this.theForm.comboPNAnode.SelectedIndex = 2;
          this.theForm.comboPNCathode.SelectedIndex = 0;
          this.theForm.comboPNOther.SelectedIndex = 1;
          break;
        }
        this.theForm.comboPNAnode.SelectedIndex = 0;
        this.theForm.comboPNCathode.SelectedIndex = 2;
        this.theForm.comboPNOther.SelectedIndex = 2;
        break;
      case Test.TYPE.SCR:
        this.ClearLeadLabels();
        this.AddLeadLabels($"{Display.Colour2(Result.SCR.Config)}-A", "A");
        this.AddLeadLabels($"{Display.Colour1(Result.SCR.Config)}-K", "K");
        this.AddLeadLabels($"{Display.ColourG(Result.SCR.Config)}-G", "G");
        this.theForm.comboPNAnode.SelectedIndex = 0;
        this.theForm.comboPNCathode.SelectedIndex = 2;
        this.theForm.comboPNOther.SelectedIndex = 2;
        break;
      case Test.TYPE.TRIAC:
        this.ClearLeadLabels();
        this.AddLeadLabels($"{Display.Colour1(Result.SCR.Config)}-MT1", "MT1");
        this.AddLeadLabels($"{Display.Colour2(Result.SCR.Config)}-MT2", "MT2");
        this.AddLeadLabels($"{Display.ColourG(Result.SCR.Config)}-G", "G");
        this.theForm.comboPNAnode.SelectedIndex = 1;
        this.theForm.comboPNCathode.SelectedIndex = 2;
        this.theForm.comboPNOther.SelectedIndex = 1;
        break;
      case Test.TYPE.DIODE:
        this.ClearLeadLabels();
        switch (Result.Diodes.Number)
        {
          case 1:
            this.AddLeadLabels($"{Display.ColourG(Result.Diodes.Diode1.Config)}-A", "A");
            this.AddLeadLabels($"{Display.Colour1(Result.Diodes.Diode1.Config)}-K", "K");
            break;
          case 2:
          case 3:
          case 4:
          case 5:
          case 6:
            this.AddLeadLabels($"{Display.ColourG(Result.Diodes.Diode1.Config)}-A1", "A1");
            this.AddLeadLabels($"{Display.Colour1(Result.Diodes.Diode1.Config)}-K1", "K1");
            break;
        }
        switch (Result.Diodes.Number)
        {
          case 2:
          case 3:
          case 4:
          case 5:
          case 6:
            this.AddLeadLabels($"{Display.ColourG(Result.Diodes.Diode2.Config)}-A2", "A2");
            this.AddLeadLabels($"{Display.Colour1(Result.Diodes.Diode2.Config)}-K2", "K2");
            break;
        }
        switch (Result.Diodes.Number)
        {
          case 3:
          case 4:
          case 5:
          case 6:
            this.AddLeadLabels($"{Display.ColourG(Result.Diodes.Diode3.Config)}-A3", "A3");
            this.AddLeadLabels($"{Display.Colour1(Result.Diodes.Diode3.Config)}-K3", "K3");
            break;
        }
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        foreach (string str in this.theForm.comboPNAnode.Items)
        {
          if (str.Contains("Red"))
            flag1 = true;
          if (str.Contains("Green"))
            flag2 = true;
          if (str.Contains("Blue"))
            flag3 = true;
        }
        if (!flag1)
          this.AddLeadLabels("Red");
        if (!flag2)
          this.AddLeadLabels("Green");
        if (!flag3)
          this.AddLeadLabels("Blue");
        this.theForm.comboPNAnode.SelectedIndex = 0;
        this.theForm.comboPNCathode.SelectedIndex = 1;
        this.theForm.comboPNOther.SelectedIndex = 0;
        break;
      case Test.TYPE.JFET:
        this.ClearLeadLabels();
        this.AddLeadLabels($"{Display.Colour2(Result.JFET.Config)}-D", "D");
        this.AddLeadLabels($"{Display.ColourG(Result.JFET.Config)}-G", "G");
        this.AddLeadLabels($"{Display.Colour1(Result.JFET.Config)}-S", "S");
        if (Result.JFET.Config < Test.CONFIG.Ps)
        {
          this.theForm.comboPNAnode.SelectedIndex = 1;
          this.theForm.comboPNCathode.SelectedIndex = 2;
          this.theForm.comboPNOther.SelectedIndex = 1;
          break;
        }
        this.theForm.comboPNAnode.SelectedIndex = 2;
        this.theForm.comboPNCathode.SelectedIndex = 1;
        this.theForm.comboPNOther.SelectedIndex = 2;
        break;
      case Test.TYPE.VREG:
        this.ClearLeadLabels();
        this.AddLeadLabels($"{Display.Colour2(Result.VReg.Config)}-Gnd", "Gnd");
        this.AddLeadLabels($"{Display.Colour1(Result.VReg.Config)}-In", "In");
        this.AddLeadLabels($"{Display.ColourG(Result.VReg.Config)}-Out", "Out");
        this.theForm.comboPNAnode.SelectedIndex = 1;
        this.theForm.comboPNCathode.SelectedIndex = 0;
        this.theForm.comboPNOther.SelectedIndex = 0;
        break;
    }
    this.UpdateParameterTooltips(this.ToolTipGraph);
    return true;
  }

  internal override Test.CONFIG GetConfig()
  {
    try
    {
      Test.LEAD[] RGB = new Test.LEAD[3];
      if (this.theForm.comboPNCathode.Text.Contains("Red"))
        RGB[0] = Test.LEAD.RED;
      else if (this.theForm.comboPNCathode.Text.Contains("Green"))
        RGB[0] = Test.LEAD.GREEN;
      else if (this.theForm.comboPNCathode.Text.Contains("Blue"))
        RGB[0] = Test.LEAD.BLUE;
      if (this.theForm.comboPNAnode.Text.Contains("Red"))
        RGB[1] = Test.LEAD.RED;
      else if (this.theForm.comboPNAnode.Text.Contains("Green"))
        RGB[1] = Test.LEAD.GREEN;
      else if (this.theForm.comboPNAnode.Text.Contains("Blue"))
        RGB[1] = Test.LEAD.BLUE;
      RGB[2] = Test.LEAD.NONE;
      Test.CONFIG Config = Test.ConfigFrom12G(RGB);
      if (this.theForm.comboPNBias.Text == "Reverse")
        Config = DCAProUnit.ConfigReverse_M1_M2(Config);
      return Config;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal string GetLabel(int N)
  {
    int IndexAnode = 0;
    int IndexCathode = 0;
    string Bias = "";
    this.theForm.comboPNAnode.Invoke((Delegate) (() => IndexAnode = this.theForm.comboPNAnode.SelectedIndex));
    this.theForm.comboPNCathode.Invoke((Delegate) (() => IndexCathode = this.theForm.comboPNCathode.SelectedIndex));
    this.theForm.comboPNBias.Invoke((Delegate) (() => Bias = (string) this.theForm.comboPNBias.SelectedItem));
    switch (N)
    {
      case 1:
        return Bias == "Forward" ? this.LabelItems[IndexAnode] : this.LabelItems[IndexCathode];
      case 2:
        return Bias == "Forward" ? this.LabelItems[IndexCathode] : this.LabelItems[IndexAnode];
      default:
        return "";
    }
  }

  internal void DetermineLeadDrives()
  {
    this.RedLeadDrive = Test.DRIVE.NONE;
    this.GreenLeadDrive = Test.DRIVE.NONE;
    this.BlueLeadDrive = Test.DRIVE.NONE;
    Test.DRIVE drive1 = Test.DRIVE.NONE;
    Test.SHORT @short = Test.SHORT.RED | Test.SHORT.GREEN | Test.SHORT.BLUE;
    try
    {
      Test.DRIVE drive2;
      Test.DRIVE drive3;
      if (this.theForm.comboPNBias.Text == "Forward")
      {
        this.thisTestPolarity = 0;
        drive2 = Test.DRIVE.MT2;
        drive3 = Test.DRIVE.MT1;
      }
      else
      {
        this.thisTestPolarity = 1;
        drive2 = Test.DRIVE.MT1;
        drive3 = Test.DRIVE.MT2;
      }
      this.thisSpareLeadType = (Graph.PNOtherIndex) this.theForm.comboPNOther.SelectedIndex;
      if (this.theForm.comboPNCathode.Text.Contains("Red"))
      {
        this.RedLeadDrive = drive3;
        @short &= ~Test.SHORT.RED;
      }
      else if (this.theForm.comboPNCathode.Text.Contains("Green"))
      {
        this.GreenLeadDrive = drive3;
        @short &= ~Test.SHORT.GREEN;
      }
      else if (this.theForm.comboPNCathode.Text.Contains("Blue"))
      {
        this.BlueLeadDrive = drive3;
        @short &= ~Test.SHORT.BLUE;
      }
      if (this.theForm.comboPNAnode.Text.Contains("Red"))
      {
        this.RedLeadDrive = drive2;
        @short &= ~Test.SHORT.RED;
      }
      else if (this.theForm.comboPNAnode.Text.Contains("Green"))
      {
        this.GreenLeadDrive = drive2;
        @short &= ~Test.SHORT.GREEN;
      }
      else if (this.theForm.comboPNAnode.Text.Contains("Blue"))
      {
        this.BlueLeadDrive = drive2;
        @short &= ~Test.SHORT.BLUE;
      }
      switch (this.theForm.comboPNOther.SelectedIndex)
      {
        case 0:
          drive1 = Test.DRIVE.NONE;
          break;
        case 1:
          drive1 = Test.DRIVE.GATE;
          break;
        case 2:
          drive1 = Test.DRIVE.GATE;
          break;
        case 3:
          drive1 = drive2;
          break;
        case 4:
          drive1 = drive3;
          break;
      }
      switch (@short)
      {
        case Test.SHORT.RED:
          this.RedLeadDrive = drive1;
          break;
        case Test.SHORT.GREEN:
          this.GreenLeadDrive = drive1;
          break;
        case Test.SHORT.BLUE:
          this.BlueLeadDrive = drive1;
          break;
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal override void NewResult_Event(object sender, frmDCAProApp.AResult e)
  {
    this.SetNewDefaults(e.Result);
  }

  internal override void buttonStart_DisEnable(object sender, frmDCAProApp.DisEnable e)
  {
    if (e.Enable)
    {
      this.thisStartButton.Enabled = true;
      this.thisStartButton.Text = "Start";
    }
    else
      this.thisStartButton.Enabled = false;
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
        this.DetermineLeadDrives();
        this.StartingPrepareControls();
        this.theForm.bgWorkerTest.RunWorkerAsync((object) ACT.GRAPH_PN);
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
    if (textBox == this.theForm.TextPNVMin)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.TextPNVMax.Text);
      if ((double) result > (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else if (textBox == this.theForm.TextPNVMax)
    {
      if ((double) result < 0.0)
        result = 0.0f;
      if ((double) result > 12.0)
        result = 12f;
      float single = Convert.ToSingle(this.theForm.TextPNVMin.Text);
      if ((double) result < (double) single)
        result = single;
      textBox.Text = $"{result:F1}";
    }
    else
    {
      if (textBox != this.theForm.TextPNPoints)
        return;
      if ((double) result < 1.0)
        result = 1f;
      if ((double) result > 10000.0)
        result = 10000f;
      textBox.Text = $"{(int) result:D}";
    }
  }

  internal override void DoGraph(BackgroundWorker worker, WorkResult Info)
  {
    try
    {
      int int32 = Convert.ToInt32(this.theForm.TextPNPoints.Text);
      float single1 = Convert.ToSingle(this.theForm.TextPNVMin.Text);
      float single2 = Convert.ToSingle(this.theForm.TextPNVMax.Text);
      double[] numArray1 = new double[int32];
      double[] numArray2 = new double[int32];
      CurveItem thisCurve = (CurveItem) null;
      bool flag1 = false;
      if (this.theForm.thisDCAPro.Mode(Test.MODE.ANALOG_USB) != Errors.Type.ErrNone)
        return;
      double num1 = (double) Math.Max(single1, single2);
      int num2 = (int) this.theForm.thisDCAPro.LeadsSafe();
      int num3 = (int) this.theForm.thisDCAPro.BoostOnWait(0.5f + Math.Max(single2, single1));
      int num4 = (int) this.theForm.thisDCAPro.SetDACAllVolts(0.5f, 0.5f, 0.5f);
      int num5 = (int) this.theForm.thisDCAPro.SetRGate(Test.RGATE_IDX._470k);
      int num6 = (int) this.theForm.thisDCAPro.SetMatrixRGB(this.RedLeadDrive, this.GreenLeadDrive, this.BlueLeadDrive);
      for (int index = 0; index < int32; ++index)
      {
        numArray1[index] = int32 <= 1 ? 0.5 + (double) single1 : 0.5 + ((double) single1 + ((double) single2 - (double) single1) * (double) index / (double) (int32 - 1));
        int num7 = (int) this.theForm.thisDCAPro.SetDACVolts((float) numArray1[index], Test.DAC.MT2);
        switch (this.thisSpareLeadType)
        {
          case Graph.PNOtherIndex.PN_470KA:
            if (this.thisTestPolarity == 0)
            {
              int num8 = (int) this.theForm.thisDCAPro.SetDACVolts((float) numArray1[index], Test.DAC.GATE);
              break;
            }
            break;
          case Graph.PNOtherIndex.PN_470KK:
            if (this.thisTestPolarity == 1)
            {
              int num9 = (int) this.theForm.thisDCAPro.SetDACVolts((float) numArray1[index], Test.DAC.GATE);
              break;
            }
            break;
        }
        this.theForm.thisDCAPro.DelaymS((ushort) 20);
        this.theForm.thisDCAPro.BoostWait();
        int num10 = (int) this.theForm.thisDCAPro.ReadADCSBurst(CORE.REQBIT_M.RGB | CORE.REQBIT_M.VR_MT2);
        if ((double) this.theForm.thisDCAPro.DetermineIc(this.thisConfig) > 12.0)
          flag1 = true;
        if (!flag1)
        {
          numArray2[index] = (double) this.theForm.thisDCAPro.DetermineIc(this.thisConfig);
          numArray1[index] = (double) this.theForm.thisDCAPro.DetermineVce(this.thisConfig);
          if (index == 0)
          {
            bool flag2 = false;
            int num11 = 0;
            string tracePrefix = this.ParseTracePrefix((Control) this.theForm.textGlobalTracePrefix, (Control) this.theForm.numGlobalTraceN);
            string NewLabel;
            do
            {
              if (!flag2)
                NewLabel = $"{tracePrefix}{this.GetLabel(1)}-{this.GetLabel(2)}";
              else
                NewLabel = $"{tracePrefix}{this.GetLabel(1)}-{this.GetLabel(2)} {num11}";
              flag2 = false;
              foreach (CurveItem curve in (List<CurveItem>) this.thisZedGraph.GraphPane.CurveList)
              {
                if (curve.Label.Text == NewLabel)
                {
                  flag2 = true;
                  ++num11;
                  break;
                }
              }
            }
            while (flag2);
            thisCurve = this.TraceAddWhole(new Graph.Trace(NewLabel, "", this.GetNextColor(), numArray1[0], numArray2[0]));
          }
          else
            thisCurve.AddPoint(numArray1[index], numArray2[index]);
          this.MinimumScaleYAxisUpdate();
        }
        else
          index = int32 - 1;
        if (!worker.CancellationPending && this.theForm.thisDCAPro.ConnectedState == DCAProUnit.STATE.CONNECTED)
        {
          Info.Progress = 100 * (index + 1) / int32;
          worker.ReportProgress(0, (object) Info.Clone());
        }
        else
          break;
      }
      int num12 = (int) this.theForm.thisDCAPro.LeadsSafe();
      this.TraceAddTag(thisCurve);
      this.thisZedGraph.AxisChange();
      int num13 = (int) this.theForm.thisDCAPro.Mode(Test.MODE.NONE);
    }
    catch (Exception ex)
    {
      throw;
    }
  }
}
