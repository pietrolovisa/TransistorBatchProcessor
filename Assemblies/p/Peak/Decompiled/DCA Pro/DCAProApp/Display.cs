// Decompiled with JetBrains decompiler
// Type: DCAProApp.Display
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using DCAPro;
using DCAProApp.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;

#nullable disable
namespace DCAProApp;

internal static class Display
{
  internal static Color MyRed = Color.FromArgb((int) byte.MaxValue, 41, 41);
  internal static Color MyGreen = Color.FromArgb(25, 173, 17);
  internal static Color MyBlue = Color.FromArgb(31 /*0x1F*/, 106, (int) byte.MaxValue);
  internal static string TextboxNewline = "\n";

  internal static string DiodeTypeString(Test.DIODE Type)
  {
    try
    {
      string str = "";
      switch (Type)
      {
        case Test.DIODE.PN:
          str += string.Format("Diode junction");
          break;
        case Test.DIODE.LED:
        case Test.DIODE.DUAL_LED:
          str += string.Format("LED");
          break;
        case Test.DIODE.ZENER:
          str += string.Format("Zener diode");
          break;
        case Test.DIODE.OTHER:
          str += string.Format("");
          break;
      }
      return str;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal static string DiodeCACCString(Test.DIODE_PATTERN DiodePattern)
  {
    try
    {
      string str;
      switch (DiodePattern)
      {
        case Test.DIODE_PATTERN.CC1:
        case Test.DIODE_PATTERN.CC2:
        case Test.DIODE_PATTERN.CC3:
          str = "Common Cathode";
          break;
        case Test.DIODE_PATTERN.CA1:
        case Test.DIODE_PATTERN.CA2:
        case Test.DIODE_PATTERN.CA3:
          str = "Common Anode";
          break;
        default:
          str = "Series pair";
          break;
      }
      return str;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal static string DiodeLeadsString(Test.CONFIG Config)
  {
    return Display.DiodeLeadsString((Test.CONFIG_PN) Config);
  }

  internal static string DiodeLeadsString(Test.CONFIG_PN Config)
  {
    try
    {
      string str = "";
      switch (Config)
      {
        case Test.CONFIG_PN.KOA:
          str += $"Red-K Blue-A{Display.TextboxNewline}";
          break;
        case Test.CONFIG_PN.KAO:
          str += $"Red-K Green-A{Display.TextboxNewline}";
          break;
        case Test.CONFIG_PN.OKA:
          str += $"Green-K Blue-A{Display.TextboxNewline}";
          break;
        case Test.CONFIG_PN.AKO:
          str += $"Red-A Green-K{Display.TextboxNewline}";
          break;
        case Test.CONFIG_PN.OAK:
          str += $"Green-A Blue-K{Display.TextboxNewline}";
          break;
        case Test.CONFIG_PN.AOK:
          str += $"Red-A Blue-K{Display.TextboxNewline}";
          break;
      }
      return str;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal static string DiodeResults(Test.stResultDiode TheResult)
  {
    string str = "";
    if (TheResult.Type == Test.DIODE.ZENER)
      str += $"Vr={TheResult.Vr:F3}V at {TheResult.Ir:F2}mA{Display.TextboxNewline}";
    return str + $"Vf={TheResult.Vf:F3}V at {TheResult.If:F2}mA{Display.TextboxNewline}";
  }

  internal static string LeadString(Test.CONFIG_PN ConfigPN, string MT1, string MT2, string Gate)
  {
    return Display.LeadString((Test.CONFIG) ConfigPN, MT1, MT2, Gate);
  }

  internal static string LeadString(
    Test.CONFIG_RGB ConfigRGB,
    string MT1,
    string MT2,
    string Gate)
  {
    return Display.LeadString((Test.CONFIG) ConfigRGB, MT1, MT2, Gate);
  }

  internal static string LeadString(
    Test.CONFIG_SCR ConfigSCR,
    string MT1,
    string MT2,
    string Gate)
  {
    return Display.LeadString((Test.CONFIG) ConfigSCR, MT1, MT2, Gate);
  }

  internal static string LeadString(
    Test.CONFIG_TRN ConfigTRN,
    string MT1,
    string MT2,
    string Gate)
  {
    return Display.LeadString((Test.CONFIG) ConfigTRN, MT1, MT2, Gate);
  }

  internal static string LeadString(Test.CONFIG Config, string MT1, string MT2, string Gate)
  {
    string str = "";
    switch (Config)
    {
      case Test.CONFIG._1:
      case Test.CONFIG.Ps:
        str += $"Red-{MT1} Green-{MT2} Blue-{Gate}";
        break;
      case Test.CONFIG._2:
      case Test.CONFIG._8:
        str += string.Format("Red-{0} Green-{2} Blue-{1}", (object) MT1, (object) MT2, (object) Gate);
        break;
      case Test.CONFIG._3:
      case Test.CONFIG._9:
        str += string.Format("Red-{1} Green-{0} Blue-{2}", (object) MT1, (object) MT2, (object) Gate);
        break;
      case Test.CONFIG._4:
      case Test.CONFIG._10:
        str += string.Format("Red-{2} Green-{0} Blue-{1}", (object) MT1, (object) MT2, (object) Gate);
        break;
      case Test.CONFIG._5:
      case Test.CONFIG._11:
        str += string.Format("Red-{1} Green-{2} Blue-{0}", (object) MT1, (object) MT2, (object) Gate);
        break;
      case Test.CONFIG._6:
      case Test.CONFIG._12:
        str += string.Format("Red-{2} Green-{1} Blue-{0}", (object) MT1, (object) MT2, (object) Gate);
        break;
    }
    return str;
  }

  internal static string Colour1(Test.CONFIG Config)
  {
    string str = "";
    switch (Config)
    {
      case Test.CONFIG._1:
      case Test.CONFIG._2:
      case Test.CONFIG.Ps:
      case Test.CONFIG._8:
        str = "Red";
        break;
      case Test.CONFIG._3:
      case Test.CONFIG._4:
      case Test.CONFIG._9:
      case Test.CONFIG._10:
        str = "Green";
        break;
      case Test.CONFIG._5:
      case Test.CONFIG._6:
      case Test.CONFIG._11:
      case Test.CONFIG._12:
        str = "Blue";
        break;
    }
    return str;
  }

  internal static string Colour2(Test.CONFIG Config)
  {
    string str = "";
    switch (Config)
    {
      case Test.CONFIG._1:
      case Test.CONFIG._6:
      case Test.CONFIG.Ps:
      case Test.CONFIG._12:
        str = "Green";
        break;
      case Test.CONFIG._2:
      case Test.CONFIG._4:
      case Test.CONFIG._8:
      case Test.CONFIG._10:
        str = "Blue";
        break;
      case Test.CONFIG._3:
      case Test.CONFIG._5:
      case Test.CONFIG._9:
      case Test.CONFIG._11:
        str = "Red";
        break;
    }
    return str;
  }

  internal static string ColourG(Test.CONFIG Config)
  {
    string str = "";
    switch (Config)
    {
      case Test.CONFIG._1:
      case Test.CONFIG._3:
      case Test.CONFIG.Ps:
      case Test.CONFIG._9:
        str = "Blue";
        break;
      case Test.CONFIG._2:
      case Test.CONFIG._5:
      case Test.CONFIG._8:
      case Test.CONFIG._11:
        str = "Green";
        break;
      case Test.CONFIG._4:
      case Test.CONFIG._6:
      case Test.CONFIG._10:
      case Test.CONFIG._12:
        str = "Red";
        break;
    }
    return str;
  }

  internal static Test.DIODES DetermineDiodesCC(Test.stResultDiodes TheResult)
  {
    if (TheResult.DiodePattern == Test.DIODE_PATTERN.CC1 || TheResult.DiodePattern == Test.DIODE_PATTERN.CC2 || TheResult.DiodePattern == Test.DIODE_PATTERN.CC3)
      return Test.DIODES.CC;
    return TheResult.DiodePattern == Test.DIODE_PATTERN.CA1 || TheResult.DiodePattern == Test.DIODE_PATTERN.CA2 || TheResult.DiodePattern == Test.DIODE_PATTERN.CA3 ? Test.DIODES.CA : Test.DIODES.SER;
  }

  internal static Test.CONFIG DiodePatternToConfig(Test.DIODE_PATTERN Pattern)
  {
    Test.DIODE_PATTERN diodePattern = Pattern;
    if ((uint) diodePattern <= 18U)
    {
      switch (diodePattern)
      {
        case Test.DIODE_PATTERN.CC1:
        case Test.DIODE_PATTERN.SER2:
          return Test.CONFIG._1;
        case Test.DIODE_PATTERN.CA1:
          goto label_11;
        case Test.DIODE_PATTERN.SER1:
        case Test.DIODE_PATTERN.CC2:
          return Test.CONFIG._3;
        case Test.DIODE_PATTERN.SER3:
          goto label_10;
        case Test.DIODE_PATTERN.CA2:
          break;
        default:
          goto label_12;
      }
    }
    else
    {
      if ((uint) diodePattern <= 36U)
      {
        switch (diodePattern)
        {
          case Test.DIODE_PATTERN.SER4:
            goto label_9;
          case Test.DIODE_PATTERN.SER5:
            break;
          case Test.DIODE_PATTERN.SER6:
            goto label_11;
          default:
            goto label_12;
        }
      }
      else if (diodePattern != Test.DIODE_PATTERN.CA3)
      {
        if (diodePattern == Test.DIODE_PATTERN.CC3)
          goto label_10;
        goto label_12;
      }
      return Test.CONFIG._2;
    }
label_9:
    return Test.CONFIG._4;
label_10:
    return Test.CONFIG._5;
label_11:
    return Test.CONFIG._6;
label_12:
    return Test.CONFIG._1;
  }

  internal static ColorPalette SetPictColours(Image Pictogram, Test.CONFIG Config)
  {
    ColorPalette palette = Pictogram.Palette;
    switch (Config)
    {
      case Test.CONFIG._1:
      case Test.CONFIG.Ps:
        palette.Entries[13] = Display.MyRed;
        palette.Entries[11] = Display.MyGreen;
        palette.Entries[14] = Display.MyBlue;
        break;
      case Test.CONFIG._2:
      case Test.CONFIG._8:
        palette.Entries[13] = Display.MyRed;
        palette.Entries[14] = Display.MyGreen;
        palette.Entries[11] = Display.MyBlue;
        break;
      case Test.CONFIG._3:
      case Test.CONFIG._9:
        palette.Entries[11] = Display.MyRed;
        palette.Entries[13] = Display.MyGreen;
        palette.Entries[14] = Display.MyBlue;
        break;
      case Test.CONFIG._4:
      case Test.CONFIG._10:
        palette.Entries[14] = Display.MyRed;
        palette.Entries[13] = Display.MyGreen;
        palette.Entries[11] = Display.MyBlue;
        break;
      case Test.CONFIG._5:
      case Test.CONFIG._11:
        palette.Entries[11] = Display.MyRed;
        palette.Entries[14] = Display.MyGreen;
        palette.Entries[13] = Display.MyBlue;
        break;
      case Test.CONFIG._6:
      case Test.CONFIG._12:
        palette.Entries[14] = Display.MyRed;
        palette.Entries[11] = Display.MyGreen;
        palette.Entries[13] = Display.MyBlue;
        break;
    }
    return palette;
  }

  internal static Bitmap PickResultPictogram(Test.unResultDevice Result)
  {
    try
    {
      Bitmap Pictogram = (Bitmap) null;
      switch (Result.Type)
      {
        case Test.TYPE.BJT:
          Pictogram = Result.BJT.Config >= Test.CONFIG.Ps ? ((Result.BJT.Flags & Test.BJTFlags.Digital) == (Test.BJTFlags) 0 ? ((Result.BJT.Flags & Test.BJTFlags.Darlington) == (Test.BJTFlags) 0 ? ((Result.BJT.Flags & Test.BJTFlags.DiodeProt) == (Test.BJTFlags) 0 ? Resources.pict_PNP : Resources.pict_PNPD) : ((double) Result.BJT.Rshunt <= 1.0 ? ((Result.BJT.Flags & Test.BJTFlags.DiodeProt) == (Test.BJTFlags) 0 ? Resources.pict_PNPDARL : Resources.pict_PNPDARLD) : ((Result.BJT.Flags & Test.BJTFlags.DiodeProt) == (Test.BJTFlags) 0 ? Resources.pict_PNPDARLR : Resources.pict_PNPDARLRD))) : Resources.pict_PNPDIG) : ((Result.BJT.Flags & Test.BJTFlags.Digital) == (Test.BJTFlags) 0 ? ((Result.BJT.Flags & Test.BJTFlags.Darlington) == (Test.BJTFlags) 0 ? ((Result.BJT.Flags & Test.BJTFlags.DiodeProt) == (Test.BJTFlags) 0 ? Resources.pict_NPN : Resources.pict_NPND) : ((double) Result.BJT.Rshunt <= 1.0 ? ((Result.BJT.Flags & Test.BJTFlags.DiodeProt) == (Test.BJTFlags) 0 ? Resources.pict_NPNDARL : Resources.pict_NPNDARLD) : ((Result.BJT.Flags & Test.BJTFlags.DiodeProt) == (Test.BJTFlags) 0 ? Resources.pict_NPNDARLR : Resources.pict_NPNDARLRD))) : Resources.pict_NPNDIG);
          Pictogram.Palette = Display.SetPictColours((Image) Pictogram, Result.BJT.Config);
          break;
        case Test.TYPE.MOSFET:
          Pictogram = (Result.MOSFET.Flags & Test.MOSFETFlags.DepletionMode) == (Test.MOSFETFlags) 0 ? ((Result.MOSFET.Flags & Test.MOSFETFlags.DiodeProt) == (Test.MOSFETFlags) 0 ? (Result.MOSFET.Config >= Test.CONFIG.Ps ? Resources.pict_MFETP : Resources.pict_MFETN) : (Result.MOSFET.Config >= Test.CONFIG.Ps ? Resources.pict_MFETPD : Resources.pict_MFETND)) : ((Result.MOSFET.Flags & Test.MOSFETFlags.DiodeProt) == (Test.MOSFETFlags) 0 ? (Result.MOSFET.Config >= Test.CONFIG.Ps ? Resources.pict_DMFETP : Resources.pict_DMFETN) : (Result.MOSFET.Config >= Test.CONFIG.Ps ? Resources.pict_DMFETPD : Resources.pict_DMFETND));
          Pictogram.Palette = Display.SetPictColours((Image) Pictogram, Result.MOSFET.Config);
          break;
        case Test.TYPE.IGBT:
          Pictogram = (Result.IGBT.Flags & Test.IGBTFlags.DepletionMode) == (Test.IGBTFlags) 0 ? (Result.IGBT.Config >= Test.CONFIG.Ps ? ((Result.IGBT.Flags & Test.IGBTFlags.DiodeProt) == (Test.IGBTFlags) 0 ? Resources.pict_IGBTP : Resources.pict_IGBTPD) : ((Result.IGBT.Flags & Test.IGBTFlags.DiodeProt) == (Test.IGBTFlags) 0 ? Resources.pict_IGBTN : Resources.pict_IGBTND)) : (Result.IGBT.Config >= Test.CONFIG.Ps ? ((Result.IGBT.Flags & Test.IGBTFlags.DiodeProt) == (Test.IGBTFlags) 0 ? Resources.pict_DMIGBTP : Resources.pict_DMIGBTPD) : ((Result.IGBT.Flags & Test.IGBTFlags.DiodeProt) == (Test.IGBTFlags) 0 ? Resources.pict_DMIGBTN : Resources.pict_DMIGBTND));
          Pictogram.Palette = Display.SetPictColours((Image) Pictogram, Result.IGBT.Config);
          break;
        case Test.TYPE.SCR:
          Pictogram = Resources.pict_SCR;
          Pictogram.Palette = Display.SetPictColours((Image) Pictogram, Result.SCR.Config);
          break;
        case Test.TYPE.TRIAC:
          Pictogram = Resources.pict_TRIAC;
          Pictogram.Palette = Display.SetPictColours((Image) Pictogram, Result.Triac.Config);
          break;
        case Test.TYPE.DIODE:
          switch (Result.Diodes.Number)
          {
            case 1:
              switch (Result.Diodes.Diode1.Type)
              {
                case Test.DIODE.LED:
                  Pictogram = Resources.pict_LED;
                  break;
                case Test.DIODE.DUAL_LED:
                  Pictogram = Resources.pict_BICOL2;
                  break;
                case Test.DIODE.ZENER:
                  Pictogram = Resources.pict_ZENER;
                  break;
                default:
                  Pictogram = Resources.pict_DIODE;
                  break;
              }
              Pictogram.Palette = Display.SetPictColours((Image) Pictogram, Result.Diodes.Diode1.Config);
              break;
            case 2:
              if (Result.Diodes.Diode1.Type == Test.DIODE.LED && Result.Diodes.Diode2.Type == Test.DIODE.LED)
              {
                switch (Display.DetermineDiodesCC(Result.Diodes))
                {
                  case Test.DIODES.SER:
                    Pictogram = Resources.pict_DIODES;
                    break;
                  case Test.DIODES.CC:
                    Pictogram = Resources.pict_BICOL3CC;
                    break;
                  case Test.DIODES.CA:
                    Pictogram = Resources.pict_BICOL3CA;
                    break;
                }
                Pictogram.Palette = Display.SetPictColours((Image) Pictogram, Display.DiodePatternToConfig(Result.Diodes.DiodePattern));
                break;
              }
              if (Result.Diodes.Diode1.Type == Test.DIODE.DUAL_LED && Result.Diodes.Diode2.Type == Test.DIODE.DUAL_LED)
              {
                Pictogram = Resources.pict_BICOL2;
                Pictogram.Palette = Display.SetPictColours((Image) Pictogram, Result.Diodes.Diode1.Config);
                break;
              }
              switch (Display.DetermineDiodesCC(Result.Diodes))
              {
                case Test.DIODES.SER:
                  Pictogram = Resources.pict_DIODES;
                  break;
                case Test.DIODES.CC:
                  Pictogram = Resources.pict_DIODECC;
                  break;
                case Test.DIODES.CA:
                  Pictogram = Resources.pict_DIODECA;
                  break;
              }
              Pictogram.Palette = Display.SetPictColours((Image) Pictogram, Display.DiodePatternToConfig(Result.Diodes.DiodePattern));
              break;
            case 3:
            case 4:
            case 5:
            case 6:
              Pictogram = Resources.pict_DIODE;
              Pictogram.Palette = Display.SetPictColours((Image) Pictogram, Display.DiodePatternToConfig(Result.Diodes.DiodePattern));
              break;
          }
          break;
        case Test.TYPE.JFET:
          Pictogram = (Result.JFET.Flags & Test.JFETFlags.MirroredDS) != (Test.JFETFlags) 0 ? (Result.JFET.Config >= Test.CONFIG.Ps ? Resources.pict_JFETPG : Resources.pict_JFETNG) : (Result.JFET.Config >= Test.CONFIG.Ps ? Resources.pict_JFETP : Resources.pict_JFETN);
          Pictogram.Palette = Display.SetPictColours((Image) Pictogram, Result.JFET.Config);
          break;
        case Test.TYPE.VREG:
          Pictogram = Resources.pict_VREG;
          Pictogram.Palette = Display.SetPictColours((Image) Pictogram, Result.VReg.Config);
          break;
      }
      return Pictogram;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal static string PickResultComments(Test.unResultDevice Result)
  {
    try
    {
      string str = "";
      switch (Result.Type)
      {
        case Test.TYPE.NONE:
          str = Resources.text_NOTHING;
          break;
        case Test.TYPE.BJT:
          str = Result.BJT.Config >= Test.CONFIG.Ps ? ((Result.BJT.Flags & Test.BJTFlags.Darlington) == (Test.BJTFlags) 0 ? ((Result.BJT.Flags & Test.BJTFlags.DiodeProt) == (Test.BJTFlags) 0 ? Resources.text_PNP : Resources.text_PNPD) : ((double) Result.BJT.Rshunt <= 1.0 ? ((Result.BJT.Flags & Test.BJTFlags.DiodeProt) == (Test.BJTFlags) 0 ? Resources.text_PNPDARL : Resources.text_PNPDARLD) : Resources.text_PNPDARLR)) : ((Result.BJT.Flags & Test.BJTFlags.Darlington) == (Test.BJTFlags) 0 ? ((Result.BJT.Flags & Test.BJTFlags.DiodeProt) == (Test.BJTFlags) 0 ? Resources.text_NPN : Resources.text_NPND) : ((double) Result.BJT.Rshunt <= 1.0 ? ((Result.BJT.Flags & Test.BJTFlags.DiodeProt) == (Test.BJTFlags) 0 ? Resources.text_NPNDARL : Resources.text_NPNDARLD) : ((Result.BJT.Flags & Test.BJTFlags.DiodeProt) == (Test.BJTFlags) 0 ? Resources.text_NPNDARLR : Resources.text_NPNDARLRD)));
          break;
        case Test.TYPE.MOSFET:
          str = (Result.MOSFET.Flags & Test.MOSFETFlags.DepletionMode) == (Test.MOSFETFlags) 0 ? (Result.MOSFET.Config >= Test.CONFIG.Ps ? Resources.text_MFETP : Resources.text_MFETN) : (Result.MOSFET.Config >= Test.CONFIG.Ps ? Resources.text_DMFETP : Resources.text_DMFETN);
          break;
        case Test.TYPE.IGBT:
          str = (Result.IGBT.Flags & Test.IGBTFlags.DepletionMode) == (Test.IGBTFlags) 0 ? (Result.IGBT.Config >= Test.CONFIG.Ps ? ((Result.IGBT.Flags & Test.IGBTFlags.DiodeProt) == (Test.IGBTFlags) 0 ? Resources.text_IGBTP : Resources.text_IGBTPD) : ((Result.IGBT.Flags & Test.IGBTFlags.DiodeProt) == (Test.IGBTFlags) 0 ? Resources.text_IGBTN : Resources.text_IGBTND)) : (Result.IGBT.Config >= Test.CONFIG.Ps ? ((Result.IGBT.Flags & Test.IGBTFlags.DiodeProt) == (Test.IGBTFlags) 0 ? Resources.text_DMIGBTP : Resources.text_DMIGBTPD) : ((Result.IGBT.Flags & Test.IGBTFlags.DiodeProt) == (Test.IGBTFlags) 0 ? Resources.text_DMIGBTN : Resources.text_DMIGBTND));
          break;
        case Test.TYPE.SCR:
          str = Resources.text_SCR;
          break;
        case Test.TYPE.TRIAC:
          str = Resources.text_TRIAC;
          break;
        case Test.TYPE.DIODE:
          switch (Result.Diodes.Number)
          {
            case 1:
              switch (Result.Diodes.Diode1.Type)
              {
                case Test.DIODE.LED:
                  str = Resources.text_LED;
                  break;
                case Test.DIODE.DUAL_LED:
                  str = Resources.text_BICOL2;
                  break;
                case Test.DIODE.ZENER:
                  str = Resources.text_ZENER;
                  break;
                default:
                  str = Resources.text_DIODE;
                  break;
              }
              break;
            case 2:
              if (Result.Diodes.Diode1.Type == Test.DIODE.LED && Result.Diodes.Diode2.Type == Test.DIODE.LED)
              {
                switch (Display.DetermineDiodesCC(Result.Diodes))
                {
                  case Test.DIODES.SER:
                    str = Resources.text_LED;
                    break;
                  case Test.DIODES.CC:
                    str = Resources.text_BICOL3CC;
                    break;
                  case Test.DIODES.CA:
                    str = Resources.text_BICOL3CA;
                    break;
                }
              }
              else
              {
                if (Result.Diodes.Diode1.Type == Test.DIODE.DUAL_LED && Result.Diodes.Diode2.Type == Test.DIODE.DUAL_LED)
                {
                  str = Resources.text_BICOL2;
                  break;
                }
                switch (Display.DetermineDiodesCC(Result.Diodes))
                {
                  case Test.DIODES.SER:
                    str = Resources.text_DIODES;
                    break;
                  case Test.DIODES.CC:
                    str = Resources.text_DIODECC;
                    break;
                  case Test.DIODES.CA:
                    str = Resources.text_DIODECA;
                    break;
                }
              }
              break;
            case 3:
            case 4:
            case 5:
            case 6:
              str = Resources.text_DIODE;
              break;
          }
          break;
        case Test.TYPE.SHORT:
          str = Resources.text_SHORT;
          break;
        case Test.TYPE.JFET:
          str = (Result.JFET.Flags & Test.JFETFlags.MirroredDS) != (Test.JFETFlags) 0 ? (Result.JFET.Config >= Test.CONFIG.Ps ? Resources.text_JFETPG : Resources.text_JFETNG) : (Result.JFET.Config >= Test.CONFIG.Ps ? Resources.text_JFETP : Resources.text_JFETN);
          break;
        case Test.TYPE.VREG:
          str = Resources.text_VREG;
          break;
      }
      return str;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal static string[] GetLeadLabels(Test.unResultDevice Result)
  {
    string[] leadLabels = new string[4]{ "", "", "", "" };
    switch (Result.Type)
    {
      case Test.TYPE.BJT:
        string[] strArray1;
        (strArray1 = leadLabels)[0] = strArray1[0] + $"{Display.Colour2(Result.BJT.Config)} - C";
        string[] strArray2;
        (strArray2 = leadLabels)[1] = strArray2[1] + $"{Display.ColourG(Result.BJT.Config)} - B";
        string[] strArray3;
        (strArray3 = leadLabels)[2] = strArray3[2] + $"{Display.Colour1(Result.BJT.Config)} - E";
        break;
      case Test.TYPE.MOSFET:
        string[] strArray4;
        (strArray4 = leadLabels)[0] = strArray4[0] + string.Format("{1} - {0}", (object) "D", (object) Display.Colour2(Result.MOSFET.Config));
        string[] strArray5;
        (strArray5 = leadLabels)[1] = strArray5[1] + string.Format("{1} - {0}", (object) "G", (object) Display.ColourG(Result.MOSFET.Config));
        string[] strArray6;
        (strArray6 = leadLabels)[2] = strArray6[2] + string.Format("{1} - {0}", (object) "S", (object) Display.Colour1(Result.MOSFET.Config));
        break;
      case Test.TYPE.IGBT:
        string[] strArray7;
        (strArray7 = leadLabels)[0] = strArray7[0] + string.Format("{1} - {0}", (object) "C", (object) Display.Colour2(Result.IGBT.Config));
        string[] strArray8;
        (strArray8 = leadLabels)[1] = strArray8[1] + string.Format("{1} - {0}", (object) "G", (object) Display.ColourG(Result.IGBT.Config));
        string[] strArray9;
        (strArray9 = leadLabels)[2] = strArray9[2] + string.Format("{1} - {0}", (object) "E", (object) Display.Colour1(Result.IGBT.Config));
        break;
      case Test.TYPE.DIODE:
        switch (Result.Diodes.Number)
        {
          case 1:
            string[] strArray10;
            (strArray10 = leadLabels)[0] = strArray10[0] + $"{Display.ColourG(Result.Diodes.Diode1.Config)} - A";
            string[] strArray11;
            (strArray11 = leadLabels)[1] = strArray11[1] + $"{Display.Colour1(Result.Diodes.Diode1.Config)} - K";
            break;
          case 2:
          case 3:
          case 4:
          case 5:
          case 6:
            string[] strArray12;
            (strArray12 = leadLabels)[0] = strArray12[0] + $"{Display.ColourG(Result.Diodes.Diode1.Config)} - A1";
            string[] strArray13;
            (strArray13 = leadLabels)[1] = strArray13[1] + $"{Display.Colour1(Result.Diodes.Diode1.Config)} - K1";
            break;
        }
        switch (Result.Diodes.Number)
        {
          case 2:
          case 3:
          case 4:
          case 5:
          case 6:
            string[] strArray14;
            (strArray14 = leadLabels)[2] = strArray14[2] + $"{Display.ColourG(Result.Diodes.Diode2.Config)} - A2";
            string[] strArray15;
            (strArray15 = leadLabels)[3] = strArray15[3] + $"{Display.Colour1(Result.Diodes.Diode2.Config)} - K2";
            break;
        }
        break;
    }
    return leadLabels;
  }

  internal static double SetSigFigs(double d, int digits)
  {
    double num = Math.Pow(10.0, Math.Floor(Math.Log10(Math.Abs(d))) + 1.0);
    return num * Math.Round(d / num, digits);
  }
}
