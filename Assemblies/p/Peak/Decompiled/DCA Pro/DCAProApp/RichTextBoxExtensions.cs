// Decompiled with JetBrains decompiler
// Type: DCAProApp.RichTextBoxExtensions
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using DCAPro;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#nullable disable
namespace DCAProApp;

public static class RichTextBoxExtensions
{
  public static void AppendText(this RichTextBox box, string text, Color color)
  {
    box.SelectionStart = box.TextLength;
    box.SelectionLength = 0;
    box.SelectionColor = color;
    box.AppendText(text);
  }

  public static void ColorizerateText(this RichTextBox Box, string Text)
  {
    Color windowText = SystemColors.WindowText;
    foreach (string input in Regex.Split(Text, "(\r\n|,)"))
    {
      foreach (string text in Regex.Split(input, "(Red|Green|Blue)"))
      {
        Color color = !text.Contains("Red") ? (!text.Contains("Green") ? (!text.Contains("Blue") ? SystemColors.WindowText : Display.MyBlue) : Display.MyGreen) : Display.MyRed;
        Box.AppendText(text, color);
      }
    }
  }

  internal static void RenderLeadString(
    this RichTextBox box,
    Test.CONFIG Config,
    string MT1,
    string MT2,
    string Gate)
  {
    box.RenderLeadString((Test.CONFIG_TRN) Config, MT1, MT2, Gate);
  }

  internal static void RenderLeadString(
    this RichTextBox box,
    Test.CONFIG_TRN Config,
    string MT1,
    string MT2,
    string Gate)
  {
    box.Text = "";
    string str1 = "";
    string str2 = "";
    string str3 = "";
    switch (Config)
    {
      case Test.CONFIG_TRN.MIN:
      case Test.CONFIG_TRN.Ps:
        str1 = MT1;
        str2 = MT2;
        str3 = Gate;
        break;
      case Test.CONFIG_TRN.N_EBC:
      case Test.CONFIG_TRN.P_EBC:
        str1 = MT1;
        str2 = Gate;
        str3 = MT2;
        break;
      case Test.CONFIG_TRN.N_CEB:
      case Test.CONFIG_TRN.P_CEB:
        str1 = MT2;
        str2 = MT1;
        str3 = Gate;
        break;
      case Test.CONFIG_TRN.N_BEC:
      case Test.CONFIG_TRN.P_BEC:
        str1 = Gate;
        str2 = MT1;
        str3 = MT2;
        break;
      case Test.CONFIG_TRN.N_CBE:
      case Test.CONFIG_TRN.P_CBE:
        str1 = MT2;
        str2 = Gate;
        str3 = MT1;
        break;
      case Test.CONFIG_TRN.N_BCE:
      case Test.CONFIG_TRN.P_BCE:
        str1 = Gate;
        str2 = MT2;
        str3 = MT1;
        break;
    }
    box.ColorizerateText($"Red-{str1}{Display.TextboxNewline}");
    box.ColorizerateText($"Green-{str2}{Display.TextboxNewline}");
    box.ColorizerateText($"Blue-{str3}{Display.TextboxNewline}");
  }

  public static void Render(this RichTextBox box, string Text)
  {
    box.Text = "";
    box.AppendText(Text, SystemColors.WindowText);
  }
}
