// Decompiled with JetBrains decompiler
// Type: DCAPro.DCAProUnit
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System;
using System.Threading;

#nullable disable
namespace DCAPro;

public class DCAProUnit
{
  internal volatile float VBatt;
  internal volatile float BTest;
  internal volatile float V12V;
  internal volatile float VPrereg;
  internal volatile float VRef;
  internal volatile float VSetGate;
  internal volatile float VGate;
  internal volatile float VSetMT1;
  internal volatile float VSetMT2;
  internal volatile float VMT2;
  internal volatile float VRed;
  internal volatile float VGreen;
  internal volatile float VBlue;
  internal volatile float RGate = 1E+07f;
  internal volatile float RMT2 = 620f;
  internal stROMCalData ROMCalData = new stROMCalData();
  public Test.unResultDevice Result;
  internal Test.STATE State;
  public Errors.Type LastError;
  public string ProductName = "";
  public string SerialNum = "";
  public string VersionNum = "";
  public string ProductType = "";
  public volatile DCAProUnit.STATE ConnectedState;
  internal IntPtr ParentHandle;
  internal Comms Comms;
  internal Boot Boot;
  internal Tests Tests;

  public DCAProUnit(IntPtr FormHandle)
  {
    this.ParentHandle = FormHandle;
    this.Comms = new Comms(this);
    this.Boot = new Boot(this);
    this.Tests = new Tests(this);
    this.Result = new Test.unResultDevice();
  }

  public DCAProUnit.STATE FindTheDevice() => this.Comms.FindTheDevice();

  public float DetermineVb(Test.CONFIG Config)
  {
    float vb = 0.0f;
    switch (Config)
    {
      case Test.CONFIG._1:
      case Test.CONFIG._3:
      case Test.CONFIG._11:
      case Test.CONFIG._12:
        vb = this.VBlue;
        break;
      case Test.CONFIG._2:
      case Test.CONFIG._5:
      case Test.CONFIG._9:
      case Test.CONFIG._10:
        vb = this.VGreen;
        break;
      case Test.CONFIG._4:
      case Test.CONFIG._6:
      case Test.CONFIG.Ps:
      case Test.CONFIG._8:
        vb = this.VRed;
        break;
    }
    return vb;
  }

  public float DetermineVc(Test.CONFIG Config)
  {
    float vc = 0.0f;
    switch (Config)
    {
      case Test.CONFIG._1:
      case Test.CONFIG._6:
      case Test.CONFIG._9:
      case Test.CONFIG._10:
        vc = this.VGreen;
        break;
      case Test.CONFIG._2:
      case Test.CONFIG._4:
      case Test.CONFIG._11:
      case Test.CONFIG._12:
        vc = this.VBlue;
        break;
      case Test.CONFIG._3:
      case Test.CONFIG._5:
      case Test.CONFIG.Ps:
      case Test.CONFIG._8:
        vc = this.VRed;
        break;
    }
    return vc;
  }

  public float DetermineVe(Test.CONFIG Config)
  {
    float ve = 0.0f;
    switch (Config)
    {
      case Test.CONFIG._1:
      case Test.CONFIG._2:
      case Test.CONFIG._10:
      case Test.CONFIG._12:
        ve = this.VRed;
        break;
      case Test.CONFIG._3:
      case Test.CONFIG._4:
      case Test.CONFIG._8:
      case Test.CONFIG._11:
        ve = this.VGreen;
        break;
      case Test.CONFIG._5:
      case Test.CONFIG._6:
      case Test.CONFIG.Ps:
      case Test.CONFIG._9:
        ve = this.VBlue;
        break;
    }
    return ve;
  }

  public float DetermineVbe(Test.CONFIG Config)
  {
    float vbe = 0.0f;
    switch (Config)
    {
      case Test.CONFIG._1:
        vbe = this.VBlue - this.VRed;
        break;
      case Test.CONFIG._2:
        vbe = this.VGreen - this.VRed;
        break;
      case Test.CONFIG._3:
        vbe = this.VBlue - this.VGreen;
        break;
      case Test.CONFIG._4:
        vbe = this.VRed - this.VGreen;
        break;
      case Test.CONFIG._5:
        vbe = this.VGreen - this.VBlue;
        break;
      case Test.CONFIG._6:
        vbe = this.VRed - this.VBlue;
        break;
      case Test.CONFIG.Ps:
        vbe = this.VRed - this.VBlue;
        break;
      case Test.CONFIG._8:
        vbe = this.VRed - this.VGreen;
        break;
      case Test.CONFIG._9:
        vbe = this.VGreen - this.VBlue;
        break;
      case Test.CONFIG._10:
        vbe = this.VGreen - this.VRed;
        break;
      case Test.CONFIG._11:
        vbe = this.VBlue - this.VGreen;
        break;
      case Test.CONFIG._12:
        vbe = this.VBlue - this.VRed;
        break;
    }
    return vbe;
  }

  public float DetermineVce(Test.CONFIG Config)
  {
    float vce = 0.0f;
    switch (Config)
    {
      case Test.CONFIG._1:
        vce = this.VGreen - this.VRed;
        break;
      case Test.CONFIG._2:
        vce = this.VBlue - this.VRed;
        break;
      case Test.CONFIG._3:
        vce = this.VRed - this.VGreen;
        break;
      case Test.CONFIG._4:
        vce = this.VBlue - this.VGreen;
        break;
      case Test.CONFIG._5:
        vce = this.VRed - this.VBlue;
        break;
      case Test.CONFIG._6:
        vce = this.VGreen - this.VBlue;
        break;
      case Test.CONFIG.Ps:
        vce = this.VRed - this.VGreen;
        break;
      case Test.CONFIG._8:
        vce = this.VRed - this.VBlue;
        break;
      case Test.CONFIG._9:
        vce = this.VGreen - this.VRed;
        break;
      case Test.CONFIG._10:
        vce = this.VGreen - this.VBlue;
        break;
      case Test.CONFIG._11:
        vce = this.VBlue - this.VRed;
        break;
      case Test.CONFIG._12:
        vce = this.VBlue - this.VGreen;
        break;
    }
    return vce;
  }

  public float DetermineVcb(Test.CONFIG Config)
  {
    float vcb = 0.0f;
    switch (Config)
    {
      case Test.CONFIG._1:
        vcb = this.VGreen - this.VBlue;
        break;
      case Test.CONFIG._2:
        vcb = this.VBlue - this.VGreen;
        break;
      case Test.CONFIG._3:
        vcb = this.VRed - this.VBlue;
        break;
      case Test.CONFIG._4:
        vcb = this.VBlue - this.VRed;
        break;
      case Test.CONFIG._5:
        vcb = this.VRed - this.VGreen;
        break;
      case Test.CONFIG._6:
        vcb = this.VGreen - this.VRed;
        break;
      case Test.CONFIG.Ps:
        vcb = this.VBlue - this.VGreen;
        break;
      case Test.CONFIG._8:
        vcb = this.VGreen - this.VBlue;
        break;
      case Test.CONFIG._9:
        vcb = this.VBlue - this.VRed;
        break;
      case Test.CONFIG._10:
        vcb = this.VRed - this.VBlue;
        break;
      case Test.CONFIG._11:
        vcb = this.VGreen - this.VRed;
        break;
      case Test.CONFIG._12:
        vcb = this.VRed - this.VGreen;
        break;
    }
    return vcb;
  }

  public float DetermineIb(Test.CONFIG Config)
  {
    float ib = (float) (1000.0 * ((double) this.VSetGate - (double) this.VGate)) / this.RGate;
    if (Config > Test.CONFIG._6)
      ib = -ib;
    return ib;
  }

  public float DetermineVIb(Test.CONFIG Config)
  {
    float vib = this.VSetGate - this.VGate;
    if (Config > Test.CONFIG._6)
      vib = -vib;
    return vib;
  }

  public float DetermineIbMag()
  {
    float ibMag = (float) (1000.0 * ((double) this.VSetGate - (double) this.VGate)) / this.RGate;
    if ((double) ibMag < 0.0)
      ibMag = -ibMag;
    return ibMag;
  }

  public float DetermineIc(Test.CONFIG Config)
  {
    float ic = (float) (((double) this.VSetMT2 - (double) this.VMT2) * (1000.0 / (double) this.RMT2));
    if (Config > Test.CONFIG._6)
      ic = -ic;
    if ((double) ic <= 1000.0 / (double) this.RMT2 * 0.000915583213285469)
      ic = 0.0f;
    return ic;
  }

  public float DetermineIc(Test.CONFIG Config, bool Absolute)
  {
    float ic = (float) (((double) this.VSetMT2 - (double) this.VMT2) * (1000.0 / (double) this.RMT2));
    if (Config > Test.CONFIG._6)
      ic = -ic;
    if (Absolute && (double) ic <= 1000.0 / (double) this.RMT2 * 0.000915583213285469)
      ic = 0.0f;
    return ic;
  }

  public float DetermineVIc(Test.CONFIG Config)
  {
    float vic = this.VSetMT2 - this.VMT2;
    if (Config > Test.CONFIG._6)
      vic = -vic;
    if ((double) vic <= 0.00091558322310447693)
      vic = 0.0f;
    return vic;
  }

  public static Test.CONFIG ConfigReverse_M1_M2(Test.CONFIG Config)
  {
    return (Test.CONFIG) DCAProUnit.ConfigReverse_M1_M2((Test.CONFIG_RGB) Config);
  }

  public static Test.CONFIG_RGB ConfigReverse_M1_M2(Test.CONFIG_RGB Config)
  {
    Test.CONFIG_RGB configRgb = Test.CONFIG_RGB.NONE;
    switch (Config)
    {
      case Test.CONFIG_RGB.MIN:
        configRgb = Test.CONFIG_RGB._21G;
        break;
      case Test.CONFIG_RGB._1G2:
        configRgb = Test.CONFIG_RGB._2G1;
        break;
      case Test.CONFIG_RGB._21G:
        configRgb = Test.CONFIG_RGB.MIN;
        break;
      case Test.CONFIG_RGB._G12:
        configRgb = Test.CONFIG_RGB._G21;
        break;
      case Test.CONFIG_RGB._2G1:
        configRgb = Test.CONFIG_RGB._1G2;
        break;
      case Test.CONFIG_RGB._G21:
        configRgb = Test.CONFIG_RGB._G12;
        break;
    }
    return configRgb;
  }

  public static Test.CONFIG_RGB ConfigReverse_M1_Gt(Test.CONFIG_RGB Config)
  {
    Test.CONFIG_RGB configRgb = Test.CONFIG_RGB.NONE;
    switch (Config)
    {
      case Test.CONFIG_RGB.MIN:
        configRgb = Test.CONFIG_RGB._G21;
        break;
      case Test.CONFIG_RGB._1G2:
        configRgb = Test.CONFIG_RGB._G12;
        break;
      case Test.CONFIG_RGB._21G:
        configRgb = Test.CONFIG_RGB._2G1;
        break;
      case Test.CONFIG_RGB._G12:
        configRgb = Test.CONFIG_RGB._1G2;
        break;
      case Test.CONFIG_RGB._2G1:
        configRgb = Test.CONFIG_RGB._21G;
        break;
      case Test.CONFIG_RGB._G21:
        configRgb = Test.CONFIG_RGB.MIN;
        break;
    }
    return configRgb;
  }

  internal static bool EqualTo(double Value1, double Value2, double Percent)
  {
    Percent = Math.Abs(Percent);
    if (Percent > 100.0)
      Percent = 100.0;
    return Math.Abs(Value2 - Value1) < Math.Abs(Percent * Value1 / 100.0);
  }

  internal static bool IsZero(double Value, double Margin)
  {
    Margin = Math.Abs(Margin);
    Value = Math.Abs(Value);
    return Value <= Margin;
  }

  internal static bool EqualTo(double Value1, double Value2, double Percent, double Absolute)
  {
    Percent = Math.Abs(Percent);
    if (Percent > 100.0)
      Percent = 100.0;
    double num = Math.Abs(Value2 - Value1);
    return num < Absolute || num < Math.Abs(Percent * Value1 / 100.0);
  }

  internal void VRegPowerOn(Test.CONFIG TRNConfig, float SetVIn, float VMax)
  {
    int num1 = (int) this.BoostOnWait(VMax + 0.5f);
    if (TRNConfig < Test.CONFIG.Ps)
    {
      int num2 = (int) this.SetDACAllVolts(0.5f, 0.5f + SetVIn, 0.5f + SetVIn);
    }
    else
    {
      int num3 = (int) this.SetDACAllVolts(0.5f + SetVIn, 0.5f, 0.5f);
    }
    int num4 = (int) this.SetMatrixPlus(TRNConfig, Test.TON.M1_ON | Test.TON.M2_ON | Test.TON.Gt_ON);
  }

  internal float TRNPowerOn(Test.CONFIG TRNConfig, Test.TON EonConBon, float VSpan)
  {
    try
    {
      int num1 = (int) this.BoostOnWait(VSpan + 0.5f);
      float num2 = 0.5f + VSpan;
      if (TRNConfig < Test.CONFIG.Ps)
      {
        int num3 = (int) this.SetDACAllVolts(0.5f, num2, 0.5f);
      }
      else
      {
        int num4 = (int) this.SetDACAllVolts(num2, 0.5f, num2);
      }
      int num5 = (int) this.SetMatrixPlus(TRNConfig <= Test.CONFIG._6 ? TRNConfig : TRNConfig - (byte) 6, EonConBon);
      return VSpan / 2f;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TRNSetVgate(Test.CONFIG TRNConfig, float Volts, float VSpan)
  {
    try
    {
      if (TRNConfig < Test.CONFIG.Ps)
      {
        int num1 = (int) this.SetDACVolts(0.5f + Volts, Test.DAC.GATE);
      }
      else
      {
        int num2 = (int) this.SetDACVolts(0.5f + VSpan - Volts, Test.DAC.GATE);
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TRNSetVc(Test.CONFIG TRNConfig, float Volts, float VSpan)
  {
    try
    {
      if (TRNConfig < Test.CONFIG.Ps)
      {
        int num1 = (int) this.SetDACVolts(0.5f + Volts, Test.DAC.MT2);
      }
      else
      {
        int num2 = (int) this.SetDACVolts(0.5f + VSpan - Volts, Test.DAC.MT2);
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void TRNSetVe(Test.CONFIG TRNConfig, float Volts, float VSpan)
  {
    try
    {
      if (TRNConfig < Test.CONFIG.Ps)
      {
        int num1 = (int) this.SetDACVolts(0.5f + Volts, Test.DAC.MT1);
      }
      else
      {
        int num2 = (int) this.SetDACVolts(0.5f + VSpan - Volts, Test.DAC.MT1);
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void FETPowerOn(Test.CONFIG TRNConfig, float Vgs, float VMax)
  {
    try
    {
      int num1 = (int) this.BoostOnWait(VMax + 0.5f);
      this.FETSetVgs(TRNConfig, Vgs, VMax);
      int num2 = (int) this.SetMatrixPlus(TRNConfig, Test.TON.M1_ON | Test.TON.M2_ON | Test.TON.Gt_ON);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void FETSetVgs(Test.CONFIG TRNConfig, float Vgs, float VMax)
  {
    try
    {
      float num1;
      float num2;
      if ((double) Vgs > 0.0)
      {
        num1 = Vgs;
        num2 = 0.0f;
      }
      else
      {
        num1 = 0.0f;
        num2 = 0.0f - Vgs;
      }
      if (TRNConfig < Test.CONFIG.Ps)
      {
        int num3 = (int) this.SetDACAllVolts(0.5f + num2, 0.5f + VMax, 0.5f + num1);
      }
      else
      {
        int num4 = (int) this.SetDACAllVolts(0.5f + VMax - num2, 0.5f, 0.5f + VMax - num1);
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal bool FETSetVdsVgs(Test.CONFIG TRNConfig, float Vds, float Vgs, float VMax)
  {
    try
    {
      float num1;
      float num2;
      float num3;
      if ((double) Vgs < 0.0)
      {
        num1 = VMax;
        num2 = VMax - Vds;
        num3 = num2 + Vgs;
      }
      else
      {
        num2 = 0.0f;
        num1 = Vds;
        num3 = Vgs;
      }
      if ((double) num1 > (double) VMax + 0.5 || (double) num1 < -0.5 || (double) num2 > (double) VMax + 0.5 || (double) num2 < -0.5 || (double) num3 > (double) VMax + 0.5 || (double) num3 < -0.5)
        return false;
      if (TRNConfig < Test.CONFIG.Ps)
      {
        int num4 = (int) this.SetDACAllVolts(0.5f + num2, 0.5f + num1, 0.5f + num3);
      }
      else
      {
        int num5 = (int) this.SetDACAllVolts((float) (0.5 + ((double) VMax - (double) num2)), (float) (0.5 + ((double) VMax - (double) num1)), (float) (0.5 + ((double) VMax - (double) num3)));
      }
      return true;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal bool FETSetVds(Test.CONFIG TRNConfig, float Vds, float Vgs, float VMax)
  {
    try
    {
      float num1;
      float num2;
      float num3;
      if ((double) Vgs < 0.0)
      {
        num1 = VMax;
        num2 = VMax - Vds;
        num3 = num2 + Vgs;
      }
      else
      {
        num2 = 0.0f;
        num1 = Vds;
        num3 = Vgs;
      }
      if ((double) num1 > (double) VMax + 0.5 || (double) num1 < -0.5 || (double) num2 > (double) VMax + 0.5 || (double) num2 < -0.5 || (double) num3 > (double) VMax + 0.5 || (double) num3 < -0.5)
        return false;
      if (TRNConfig < Test.CONFIG.Ps)
      {
        int num4 = (int) this.SetDACVolts(0.5f + num2, Test.DAC.MT1);
        int num5 = (int) this.SetDACVolts(0.5f + num1, Test.DAC.MT2);
      }
      else
      {
        int num6 = (int) this.SetDACVolts((float) (0.5 + ((double) VMax - (double) num2)), Test.DAC.MT1);
        int num7 = (int) this.SetDACVolts((float) (0.5 + ((double) VMax - (double) num1)), Test.DAC.MT2);
      }
      return true;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void FETPowerOnAlt(Test.CONFIG TRNConfig, float Vgs, float VMax)
  {
    try
    {
      int num1 = (int) this.BoostOnWait(VMax + 0.5f);
      this.FETSetVgsAlt(TRNConfig, Vgs, VMax);
      int num2 = (int) this.SetMatrixPlus(TRNConfig, Test.TON.M1_ON | Test.TON.M2_ON | Test.TON.Gt_ON);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void FETSetVgsAlt(Test.CONFIG TRNConfig, float Vgs, float VMax)
  {
    try
    {
      float num1;
      float num2;
      if ((double) Vgs > 0.0)
      {
        num1 = Vgs;
        num2 = 0.0f;
      }
      else
      {
        num1 = 0.0f;
        num2 = 0.0f - Vgs;
      }
      if (TRNConfig < Test.CONFIG.Ps)
      {
        int num3 = (int) this.SetDACAllVolts(0.5f + num2, 0.5f + num1, 0.5f + VMax);
      }
      else
      {
        int num4 = (int) this.SetDACAllVolts(0.5f + VMax - num2, 0.5f + VMax - num1, 0.5f);
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal bool WaitForCCBase(double SetCurrent, Test.CONFIG Config, double Percent, int Timeout)
  {
    float Current = 0.0f;
    Percent /= 100.0;
    DateTime dateTime = DateTime.Now.Add(new TimeSpan(0, 0, 0, 0, Timeout));
    int num = 0;
    if (Config < Test.CONFIG.Ps)
    {
      do
      {
        this.DelaymS((ushort) 5);
        int gateCurrent = (int) this.GetGateCurrent(ref Current);
        ++num;
      }
      while (((double) Current < SetCurrent * (1.0 - Percent) || (double) Current > SetCurrent * (1.0 + Percent)) && DateTime.Now < dateTime);
    }
    else
    {
      do
      {
        this.DelaymS((ushort) 5);
        int gateCurrent = (int) this.GetGateCurrent(ref Current);
        ++num;
      }
      while ((-(double) Current < SetCurrent * (1.0 - Percent) || -(double) Current > SetCurrent * (1.0 + Percent)) && DateTime.Now < dateTime);
    }
    return !(DateTime.Now > dateTime);
  }

  internal bool WaitForCCOneShot(int Timeout, bool Burst)
  {
    DateTime dateTime = DateTime.Now.Add(new TimeSpan(0, 0, 0, 0, Timeout + 10));
    int num1 = 0;
    CORE.CxSTATE State = (CORE.CxSTATE) 0;
    int num2 = (int) this.SetGateCurrentOneShot(Burst, (ushort) Timeout);
    do
    {
      this.DelaymS((ushort) 3);
      int ccState = (int) this.GetCCState(ref State);
      ++num1;
    }
    while ((State & (CORE.CxSTATE.ACQUIRED | CORE.CxSTATE.FAILED | CORE.CxSTATE.TIMEDOUT)) == (CORE.CxSTATE) 0 && DateTime.Now < dateTime);
    if (DateTime.Now > dateTime || (State & (CORE.CxSTATE.FAILED | CORE.CxSTATE.TIMEDOUT)) != (CORE.CxSTATE) 0)
    {
      int num3 = (int) this.StopGateCurrent();
      return false;
    }
    int num4 = (int) this.ReadADCS((byte) 0);
    return true;
  }

  internal bool WaitForCVBase(int Timeout, ref float Voltage)
  {
    DateTime dateTime = DateTime.Now.Add(new TimeSpan(0, 0, 0, 0, Timeout + 10));
    int num1 = 0;
    CORE.CxSTATE State = (CORE.CxSTATE) 0;
    int num2 = (int) this.ResetGateVoltageAcquired();
    do
    {
      this.DelaymS((ushort) 3);
      int gateVoltage = (int) this.GetGateVoltage(ref Voltage, ref State);
      ++num1;
    }
    while ((State & (CORE.CxSTATE.ACQUIRED | CORE.CxSTATE.FAILED | CORE.CxSTATE.TIMEDOUT)) == (CORE.CxSTATE) 0 && DateTime.Now < dateTime);
    return !(DateTime.Now > dateTime) && (State & (CORE.CxSTATE.FAILED | CORE.CxSTATE.TIMEDOUT)) == (CORE.CxSTATE) 0;
  }

  internal bool WaitForCVOneShot(int Timeout, bool Burst)
  {
    DateTime dateTime = DateTime.Now.Add(new TimeSpan(0, 0, 0, 0, Timeout + 10));
    int num1 = 0;
    CORE.CxSTATE State = (CORE.CxSTATE) 0;
    int num2 = (int) this.SetGateVoltageOneShot(Burst, (ushort) Timeout);
    do
    {
      this.DelaymS((ushort) 3);
      int cvState = (int) this.GetCVState(ref State);
      ++num1;
    }
    while ((State & (CORE.CxSTATE.ACQUIRED | CORE.CxSTATE.FAILED | CORE.CxSTATE.TIMEDOUT)) == (CORE.CxSTATE) 0 && DateTime.Now < dateTime);
    if (DateTime.Now > dateTime || (State & (CORE.CxSTATE.FAILED | CORE.CxSTATE.TIMEDOUT)) != (CORE.CxSTATE) 0)
    {
      int num3 = (int) this.StopGateVoltage();
      return false;
    }
    int num4 = (int) this.ReadADCS((byte) 0);
    return true;
  }

  public bool BoostWait()
  {
    DateTime dateTime = DateTime.Now.Add(new TimeSpan(0, 0, 0, 0, 300));
    bool Status = false;
    Errors.Type type;
    do
    {
      type = this.Boosted(ref Status);
    }
    while (type == Errors.Type.ErrNone && !Status && DateTime.Now < dateTime);
    if (DateTime.Now > dateTime || !Status)
    {
      this.LastError = Errors.Type.ErrBoost_Timeout;
      return false;
    }
    return type == Errors.Type.ErrNone;
  }

  public void DelaymS(ushort mS) => Thread.Sleep((int) mS);

  internal bool DoSendAndReceiveCommand(ref CMD.unCommand TheBuffer)
  {
    bool command = false;
    int num = 3;
    CMD.unCommand ReceiveBuffer = new CMD.unCommand();
    while (!command && num-- > 0)
    {
      command = this.Comms.SendAndReceiveCommand(ref TheBuffer, ref ReceiveBuffer);
      if (ReceiveBuffer.Cmd.Type != TheBuffer.Cmd.Type)
        command = false;
    }
    TheBuffer = ReceiveBuffer;
    return command;
  }

  internal Errors.Type GetStateAck(Test.STATE ACKState)
  {
    Errors.Type stateAck = Errors.Type.ErrNone;
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.CmdState.Type = CMD.TYPE.STATE;
      TheBuffer.CmdState.State = ACKState;
      bool command = this.DoSendAndReceiveCommand(ref TheBuffer);
      char[] chArray = new char[6];
      if (command)
      {
        this.State = TheBuffer.CmdState.State;
        this.ProductType = $"{TheBuffer.CmdState.HardType:x04}";
        this.VersionNum = $"{TheBuffer.CmdState.FirmType:x04}";
        chArray[0] = (char) TheBuffer.CmdState.Serial1;
        chArray[1] = (char) TheBuffer.CmdState.Serial2;
        chArray[2] = (char) TheBuffer.CmdState.Serial3;
        chArray[3] = (char) TheBuffer.CmdState.Serial4;
        chArray[4] = (char) TheBuffer.CmdState.Serial5;
        chArray[5] = (char) TheBuffer.CmdState.Serial6;
        this.RMT2 = TheBuffer.CmdState.RMT2;
        this.SerialNum = new string(chArray);
      }
      else
      {
        stateAck = Errors.Type.CommsFailed_GetStateAck;
        this.LastError = stateAck;
      }
      return stateAck;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal Errors.Type ReadCal()
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.CmdCAL.Type = CMD.TYPE.CAL;
      TheBuffer.CmdCAL.Status = (byte) 0;
      if (!this.DoSendAndReceiveCommand(ref TheBuffer))
      {
        type = Errors.Type.CommsFailed_ReadCal;
        this.LastError = type;
      }
      this.ROMCalData = TheBuffer.CmdCAL.ROMCalData;
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal Errors.Type WriteCal(stROMCalData NewCalData)
  {
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.CmdCAL.Type = CMD.TYPE.CAL;
      TheBuffer.CmdCAL.Status = (byte) 92;
      TheBuffer.CmdCAL.ROMCalData = NewCalData;
      Errors.Type type;
      if (!this.DoSendAndReceiveCommand(ref TheBuffer))
      {
        type = Errors.Type.CommsFailed_ReadADCS;
        this.LastError = type;
      }
      else
        type = (Errors.Type) TheBuffer.CmdCAL.Status;
      this.ROMCalData = TheBuffer.CmdCAL.ROMCalData;
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type ReadSerial()
  {
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.CmdSerial.Type = CMD.TYPE.SERIAL;
      TheBuffer.CmdSerial.Status = (byte) 0;
      char[] chArray = new char[6];
      Errors.Type type;
      if (!this.DoSendAndReceiveCommand(ref TheBuffer))
      {
        type = Errors.Type.CommsFailed_ReadADCS;
        this.LastError = type;
      }
      else
      {
        chArray[0] = TheBuffer.CmdSerial.ROMSerial.Char0;
        chArray[1] = TheBuffer.CmdSerial.ROMSerial.Char1;
        chArray[2] = TheBuffer.CmdSerial.ROMSerial.Char2;
        chArray[3] = TheBuffer.CmdSerial.ROMSerial.Char3;
        chArray[4] = TheBuffer.CmdSerial.ROMSerial.Char4;
        chArray[5] = TheBuffer.CmdSerial.ROMSerial.Char5;
        this.SerialNum = new string(chArray);
        type = (Errors.Type) TheBuffer.CmdSerial.Status;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal Errors.Type WriteSerial(string NewSerialNum)
  {
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.CmdSerial.Type = CMD.TYPE.SERIAL;
      TheBuffer.CmdSerial.Status = (byte) 92;
      char[] chArray = new char[6];
      char[] charArray = NewSerialNum.ToCharArray();
      TheBuffer.CmdSerial.ROMSerial.Char0 = charArray[0];
      TheBuffer.CmdSerial.ROMSerial.Char1 = charArray[1];
      TheBuffer.CmdSerial.ROMSerial.Char2 = charArray[2];
      TheBuffer.CmdSerial.ROMSerial.Char3 = charArray[3];
      TheBuffer.CmdSerial.ROMSerial.Char4 = charArray[4];
      TheBuffer.CmdSerial.ROMSerial.Char5 = charArray[5];
      Errors.Type type;
      if (!this.DoSendAndReceiveCommand(ref TheBuffer))
      {
        type = Errors.Type.CommsFailed_ReadADCS;
        this.LastError = type;
      }
      else
      {
        charArray[0] = TheBuffer.CmdSerial.ROMSerial.Char0;
        charArray[1] = TheBuffer.CmdSerial.ROMSerial.Char1;
        charArray[2] = TheBuffer.CmdSerial.ROMSerial.Char2;
        charArray[3] = TheBuffer.CmdSerial.ROMSerial.Char3;
        charArray[4] = TheBuffer.CmdSerial.ROMSerial.Char4;
        charArray[5] = TheBuffer.CmdSerial.ROMSerial.Char5;
        this.SerialNum = new string(charArray);
        type = (Errors.Type) TheBuffer.CmdSerial.Status;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type InitiateTest()
  {
    Errors.Type type = Errors.Type.ErrNone;
    CMD.unCommand TheBuffer = new CMD.unCommand();
    TheBuffer.CmdResult.Type = CMD.TYPE.TEST;
    TheBuffer.CmdResult.Status = CMD.TEST.TEST;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref TheBuffer))
      {
        type = Errors.Type.CommsFailed_InitiateTest;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type ReadTestResult()
  {
    Errors.Type type = Errors.Type.ErrNone;
    CMD.unCommand TheBuffer = new CMD.unCommand();
    TheBuffer.CmdResult.Type = CMD.TYPE.TEST;
    TheBuffer.CmdResult.Status = CMD.TEST.READ;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref TheBuffer) || TheBuffer.CmdResult.Type != CMD.TYPE.TEST)
      {
        type = Errors.Type.CommsFailed_ReadTestResult;
        this.LastError = type;
      }
      this.Result = TheBuffer.CmdResult.Result;
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal Errors.Type WriteTestResult()
  {
    Errors.Type type = Errors.Type.ErrNone;
    if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
    {
      CmdResult = {
        Type = CMD.TYPE.TEST,
        Status = CMD.TEST.WRITE,
        Result = this.Result
      }
    }))
    {
      type = Errors.Type.CommsFailed_WriteTestResult;
      this.LastError = type;
    }
    return type;
  }

  public Errors.Type ReadADCS(byte ADCReq_Muxed)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.CmdRADCS.Type = CMD.TYPE.ADCS;
      TheBuffer.CmdRADCS.ADCReq_Direct.Byte = (byte) 0;
      TheBuffer.CmdRADCS.ADCReq_Muxed.Byte = ADCReq_Muxed;
      TheBuffer.CmdRADCS.ADCBurst_Muxed = ~(CORE.REQBIT_M.RGB | CORE.REQBIT_M.VR_MT2 | CORE.REQBIT_M.VR_GATE | CORE.REQBIT_M.VSET_MT1);
      if (!this.DoSendAndReceiveCommand(ref TheBuffer))
      {
        type = Errors.Type.CommsFailed_ReadADCS;
        this.LastError = type;
      }
      this.VSetGate = TheBuffer.CmdRADCS.VSetGate;
      this.VGate = TheBuffer.CmdRADCS.VGate;
      this.VSetMT1 = TheBuffer.CmdRADCS.VSetMT1;
      this.VSetMT2 = TheBuffer.CmdRADCS.VSetMT2;
      this.VMT2 = TheBuffer.CmdRADCS.VMT2;
      this.VRed = TheBuffer.CmdRADCS.VRed;
      this.VGreen = TheBuffer.CmdRADCS.VGreen;
      this.VBlue = TheBuffer.CmdRADCS.VBlue;
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type ReadADCSBurst(CORE.REQBIT_M ADCBurst_Muxed)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.CmdRADCS.Type = CMD.TYPE.ADCS;
      TheBuffer.CmdRADCS.ADCReq_Direct.Byte = (byte) 0;
      TheBuffer.CmdRADCS.ADCReq_Muxed.Byte = (byte) 0;
      TheBuffer.CmdRADCS.ADCBurst_Muxed = ADCBurst_Muxed;
      if (!this.DoSendAndReceiveCommand(ref TheBuffer))
      {
        type = Errors.Type.CommsFailed_ReadADCSBurst;
        this.LastError = type;
      }
      this.VSetGate = TheBuffer.CmdRADCS.VSetGate;
      this.VGate = TheBuffer.CmdRADCS.VGate;
      this.VSetMT1 = TheBuffer.CmdRADCS.VSetMT1;
      this.VSetMT2 = TheBuffer.CmdRADCS.VSetMT2;
      this.VMT2 = TheBuffer.CmdRADCS.VMT2;
      this.VRed = TheBuffer.CmdRADCS.VRed;
      this.VGreen = TheBuffer.CmdRADCS.VGreen;
      this.VBlue = TheBuffer.CmdRADCS.VBlue;
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type ReadADCSDirect(byte ADCReq_Direct)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.CmdRADCS.Type = CMD.TYPE.ADCS;
      TheBuffer.CmdRADCS.ADCReq_Direct.Byte = ADCReq_Direct;
      TheBuffer.CmdRADCS.ADCReq_Muxed.Byte = (byte) 0;
      TheBuffer.CmdRADCS.ADCBurst_Muxed = ~(CORE.REQBIT_M.RGB | CORE.REQBIT_M.VR_MT2 | CORE.REQBIT_M.VR_GATE | CORE.REQBIT_M.VSET_MT1);
      if (!this.DoSendAndReceiveCommand(ref TheBuffer))
      {
        type = Errors.Type.CommsFailed_ReadADCSDirect;
        this.LastError = type;
      }
      this.VBatt = TheBuffer.CmdRADCS.VBatt;
      this.BTest = TheBuffer.CmdRADCS.BTest;
      this.V12V = TheBuffer.CmdRADCS.V12V;
      this.VPrereg = TheBuffer.CmdRADCS.VPrereg;
      this.VRef = TheBuffer.CmdRADCS.VRef;
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal Errors.Type BootLoad()
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        Cmd = {
          Type = CMD.TYPE.BOOTL
        }
      });
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type WriteMessage(string Message) => Errors.Type.ErrNone;

  public Errors.Type BoostOnWait(float Volts)
  {
    Errors.Type type = Errors.Type.ErrNone;
    if ((double) Volts > 15.0)
      Volts = 15f;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdFloat = {
          Type = CMD.TYPE.BOOST,
          Data = Volts
        }
      }))
      {
        type = Errors.Type.CommsFailed_BoostOnWait;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type Boosted(ref bool Status)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.Cmd.Type = CMD.TYPE.BOOSTED;
      if (!this.DoSendAndReceiveCommand(ref TheBuffer))
      {
        type = Errors.Type.CommsFailed_BoostWait;
        this.LastError = type;
      }
      Status = TheBuffer.Cmd.Status != (byte) 0;
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type BoostOff()
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        Cmd = {
          Type = CMD.TYPE.BOOSTOFF
        }
      }))
      {
        type = Errors.Type.CommsFailed_BoostOff;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type LeadsSafe()
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        Cmd = {
          Type = CMD.TYPE.LEADSAFE
        }
      }))
      {
        type = Errors.Type.CommsFailed_LeadsSafe;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type SetRGate(Test.RGATE_IDX RIndex)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.CmdWGateRes.Type = CMD.TYPE.RGATE;
      TheBuffer.CmdWGateRes.RIndex = RIndex;
      bool command = this.DoSendAndReceiveCommand(ref TheBuffer);
      this.RGate = TheBuffer.CmdWGateRes.Resistance;
      if (!command)
      {
        type = Errors.Type.CommsFailed_SetRGate;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type SetDACVolts(float Volts, Test.DAC Channel)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdWVolts = {
          Type = CMD.TYPE.VOLTS,
          Volts = Volts,
          Channel = Channel
        }
      }))
      {
        type = Errors.Type.CommsFailed_WriteVolts;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type SetDACAllVolts(float MT1Volts, float MT2Volts, float GateVolts)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdWAllVolts = {
          Type = CMD.TYPE.ALLVOLTS,
          MT1Volts = MT1Volts,
          MT2Volts = MT2Volts,
          GateVolts = GateVolts
        }
      }))
      {
        type = Errors.Type.CommsFailed_WriteAllVolts;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type SetMatrixRGB(Test.DRIVE Red, Test.DRIVE Green, Test.DRIVE Blue)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdWSetMatrixRGB = {
          Type = CMD.TYPE.MATRIXRGB,
          Red = (byte) Red,
          Green = (byte) Green,
          Blue = (byte) Blue
        }
      }))
      {
        type = Errors.Type.CommsFailed_MatrixRGB;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type SetMatrixPlus(Test.CONFIG MXConfig, Test.TON SOnDOnGOn)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdWSetMatrixP = {
          Type = CMD.TYPE.MATRIXPLUS,
          MXConfig = MXConfig,
          SOnDOnGOn = SOnDOnGOn
        }
      }))
      {
        type = Errors.Type.CommsFailed_MatrixPlus;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type Mode(Test.MODE Mode)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdUChar = {
          Type = CMD.TYPE.MODE,
          Data = (byte) Mode
        }
      }))
      {
        type = Errors.Type.CommsFailed_Mode;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type SetGateCurrent(float Current)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdWCCGate = {
          Type = CMD.TYPE.CCGATE,
          Current = Current,
          Mode = CORE.CxMODE.ON
        }
      }))
      {
        type = Errors.Type.CommsFailed_CCGate;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type StopGateCurrent()
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdWCCGate = {
          Type = CMD.TYPE.CCGATE,
          Mode = CORE.CxMODE.OFF
        }
      }))
      {
        type = Errors.Type.CommsFailed_CCGate;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type ResetGateCurrentAcquired()
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdWCCGate = {
          Type = CMD.TYPE.CCGATE,
          Mode = CORE.CxMODE.RESET_ACQ
        }
      }))
      {
        type = Errors.Type.CommsFailed_CCGate;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type SetGateCurrentOneShot(bool Burst, ushort Timeout)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdWCCGate = {
          Type = CMD.TYPE.CCGATE,
          Mode = !Burst ? CORE.CxMODE.ONESHOT : CORE.CxMODE.ONESHOT_BURST,
          Timeout = Timeout
        }
      }))
      {
        type = Errors.Type.CommsFailed_CCGate;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type GetCCState(ref CORE.CxSTATE State)
  {
    Errors.Type ccState = Errors.Type.ErrNone;
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.CmdWCCGate.Type = CMD.TYPE.CCGATE;
      TheBuffer.CmdWCCGate.Mode = CORE.CxMODE.READ;
      if (!this.DoSendAndReceiveCommand(ref TheBuffer))
      {
        ccState = Errors.Type.CommsFailed_CCGate;
        this.LastError = ccState;
      }
      else
        State = TheBuffer.CmdWCCGate.State;
      return ccState;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type GetGateCurrent(ref float Current)
  {
    Errors.Type gateCurrent = Errors.Type.ErrNone;
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.CmdWCCGate.Type = CMD.TYPE.CCGATE;
      TheBuffer.CmdWCCGate.Current = Current;
      TheBuffer.CmdWCCGate.Mode = CORE.CxMODE.READ;
      if (!this.DoSendAndReceiveCommand(ref TheBuffer))
      {
        gateCurrent = Errors.Type.CommsFailed_CCGate;
        this.LastError = gateCurrent;
      }
      else
        Current = TheBuffer.CmdWCCGate.Current;
      return gateCurrent;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type SetGateVoltage(float Voltage, Test.CONFIG Config)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdWCVGate = {
          Type = CMD.TYPE.CVGATE,
          Config = Config,
          Voltage = Voltage,
          Mode = CORE.CxMODE.ON
        }
      }))
      {
        type = Errors.Type.CommsFailed_CVGate;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type StopGateVoltage()
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdWCVGate = {
          Type = CMD.TYPE.CVGATE,
          Mode = CORE.CxMODE.OFF
        }
      }))
      {
        type = Errors.Type.CommsFailed_CVGate;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type ResetGateVoltageAcquired()
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdWCVGate = {
          Type = CMD.TYPE.CVGATE,
          Mode = CORE.CxMODE.RESET_ACQ
        }
      }))
      {
        type = Errors.Type.CommsFailed_CVGate;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type SetGateVoltageOneShot(bool Burst, ushort Timeout)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdWCVGate = {
          Type = CMD.TYPE.CVGATE,
          Mode = !Burst ? CORE.CxMODE.ONESHOT : CORE.CxMODE.ONESHOT_BURST,
          Timeout = Timeout
        }
      }))
      {
        type = Errors.Type.CommsFailed_CVGate;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type GetCVState(ref CORE.CxSTATE State)
  {
    Errors.Type cvState = Errors.Type.ErrNone;
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.CmdWCVGate.Type = CMD.TYPE.CVGATE;
      TheBuffer.CmdWCVGate.Mode = CORE.CxMODE.READ;
      if (!this.DoSendAndReceiveCommand(ref TheBuffer))
      {
        cvState = Errors.Type.CommsFailed_CVGate;
        this.LastError = cvState;
      }
      else
        State = TheBuffer.CmdWCVGate.State;
      return cvState;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public Errors.Type GetGateVoltage(ref float Voltage, ref CORE.CxSTATE State)
  {
    Errors.Type gateVoltage = Errors.Type.ErrNone;
    try
    {
      CMD.unCommand TheBuffer = new CMD.unCommand();
      TheBuffer.CmdWCVGate.Type = CMD.TYPE.CVGATE;
      TheBuffer.CmdWCVGate.Voltage = Voltage;
      TheBuffer.CmdWCVGate.Mode = CORE.CxMODE.READ;
      if (!this.DoSendAndReceiveCommand(ref TheBuffer))
      {
        gateVoltage = Errors.Type.CommsFailed_CVGate;
        this.LastError = gateVoltage;
      }
      Voltage = TheBuffer.CmdWCVGate.Voltage;
      State = TheBuffer.CmdWCVGate.State;
      return gateVoltage;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal Errors.Type SetContrast(ushort Contrast)
  {
    Errors.Type type = Errors.Type.ErrNone;
    try
    {
      if (!this.DoSendAndReceiveCommand(ref new CMD.unCommand()
      {
        CmdUShort = {
          Type = CMD.TYPE.CNTRST,
          Data = Contrast
        }
      }))
      {
        type = Errors.Type.CommsFailed_SetContrast;
        this.LastError = type;
      }
      return type;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public enum STATE
  {
    UNCONNECTED,
    PRESENT,
    CONNECTED,
    BOOTPRESENT,
    BOOTCONNECTED,
  }
}
