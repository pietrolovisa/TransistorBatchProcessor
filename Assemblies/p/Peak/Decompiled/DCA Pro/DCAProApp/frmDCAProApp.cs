// Decompiled with JetBrains decompiler
// Type: DCAProApp.frmDCAProApp
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using DCAPro;
using DCAProApp.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using ZedGraph;

#nullable disable
namespace DCAProApp;

public class frmDCAProApp : Form
{
  private const int FORM_CLOSE_NONE = 0;
  private const int FORM_CLOSE_REQUEST = 1;
  private const int FORM_CLOSE_WAIT_BG = 2;
  private const int FORM_CLOSE_NOW = 3;
  internal BackgroundWorker bgWorkerTest;
  internal MenuStrip menuStripMain;
  internal ToolStripMenuItem DCAProToolStripMenuItem;
  internal ToolStripMenuItem exitToolStripMenuItem;
  internal ToolStripMenuItem helpToolStripMenuItem;
  internal ToolStripMenuItem aboutToolStripMenuItem;
  internal OpenFileDialog openHEXFileDialog;
  internal ToolStripMenuItem programFirmwareToolStripMenuItem;
  internal ToolStripMenuItem LCDToolStripMenuItem;
  internal System.Windows.Forms.Timer timerDisplay;
  internal System.Windows.Forms.Timer timerPulse;
  internal ToolStripStatusLabel toolStripStatusLabelDevice;
  internal ToolStripProgressBar toolStripProgressBar;
  internal ToolStripStatusLabel toolStripProgressLabel;
  internal ToolStripStatusLabel toolStripStatusError;
  internal ToolStripStatusLabel toolStripState;
  internal ToolStripStatusLabel toolStripIdentify;
  internal StatusStrip statusStrip1;
  internal ToolStripMenuItem graphsToolStripMenuItem;
  private IContainer components;
  internal TabPage tabVRegTest;
  internal GraphPanel panelVRegVoutVin;
  internal TextBox textVRegVoViPoints;
  internal TextBox textVRegVoViViMax;
  internal TextBox textVRegVoViViMin;
  internal Button butStartVRegVoVi;
  internal ZedGraphControl zedGraphVRegVoVi;
  internal TabPage tabJIdVgs;
  internal ZedGraphControl zedGraphJIdVgs;
  internal GraphPanel panelJIdVgs;
  internal TextBox textJIdVgsVdsMin;
  internal TextBox textJIdVgsPoints;
  internal TextBox textJIdVgsVgsMax;
  internal TextBox textJIdVgsVgsMin;
  internal Button butStartJIdVgs;
  internal TabPage tabJIdVds;
  internal ZedGraphControl zedGraphJIdVds;
  internal GraphPanel panelJIdVds;
  internal System.Windows.Forms.Label label87;
  internal System.Windows.Forms.Label label88;
  internal TextBox textJIdVdsTraces;
  internal TextBox textJIdVdsVgsMax;
  internal TextBox textJIdVdsVgsMin;
  internal TextBox textJIdVdsPoints;
  internal TextBox textJIdVdsVdsMax;
  internal TextBox textJIdVdsVdsMin;
  internal Button butStartJIdVds;
  internal TabPage tabFIdVds;
  internal GraphPanel panelMIdVds;
  internal Button butStartMIdVds;
  internal TextBox textIdVdsTraces;
  internal TextBox textIdVdsVgsMax;
  internal TextBox textIdVdsVgsMin;
  internal TextBox textIdVdsPoints;
  internal TextBox textIdVdsVddMax;
  internal TextBox textIdVdsVddMin;
  internal ZedGraphControl zedGraphMIdVds;
  internal ZedGraphControl zedGraphMIdVgs;
  internal GraphPanel panelMIdVgs;
  internal TextBox textMIdVgsTraces;
  internal TextBox textMIdVgsVdsMax;
  internal TextBox textMIdVgsVdsMin;
  internal TextBox textMIdVgsPoints;
  internal TextBox textMIdVgsVgsMax;
  internal TextBox textMIdVgsVgsMin;
  internal Button butStartMIdVgs;
  internal TabPage tabIcVce;
  internal ZedGraphControl zedGraphIcVce;
  internal TabPage tabPNTest;
  internal GraphPanel panelPNJunction;
  internal System.Windows.Forms.Label label15;
  internal System.Windows.Forms.Label label14;
  internal TextBox TextPNPoints;
  internal TextBox TextPNVMax;
  internal TextBox TextPNVMin;
  internal Button butStartPN;
  internal ZedGraphControl zedGraphPNJunct;
  internal TabPage tabIdentify;
  internal Button buttonIdentify;
  internal TabControl tabControl;
  internal PictureBox pictureResult;
  internal Panel panel2;
  internal RichTextBox textComments;
  internal ContextMenuStrip contextMenuComments;
  internal ToolStripMenuItem copyToolStripMenuItem;
  internal BackgroundWorker bgWorkerUpdate;
  internal PictureBox picPNCircuitLarge;
  internal PictureBox picVRegVoViLarge;
  internal PictureBox picJFETIdVgsCircuitLarge;
  internal PictureBox picJFETIdVdsCircuitLarge;
  internal PictureBox picMOSIdVdsCircuitLarge;
  internal PictureBox picMOSIdVgsCircuitLarge;
  internal PictureBox picBJTIcVceCircuitLarge;
  internal ComboBoxCustom comboJIdVgsConfig;
  internal ComboBoxCustom comboJIdVdsConfig;
  internal TabPage tabHfeIc;
  internal ZedGraphControl zedGraphHfeIc;
  internal GraphPanel panelHFEIc;
  internal TextBox textHfeIcTraces;
  internal TextBox textHfeIcBaseuIMax;
  internal TextBox textHfeIcBaseuIMin;
  internal TextBox textHfeIcPoints;
  internal TextBox textHfeIcVcMax;
  internal TextBox textHfeIcVcMin;
  internal Button butStartHfeIc;
  internal PictureBox picBJTHfeIcCircuitLarge;
  internal ToolStripMenuItem dataToolStripMenuItem;
  internal ToolStripMenuItem menuDataLoadData;
  internal ZedGraphControl zedGraphHfeVce;
  internal GraphPanel panelHFEVce;
  internal TextBox textHfeVceBaseTraces;
  internal TextBox textHfeVceBaseuIMax;
  internal TextBox textHfeVceBaseuIMin;
  internal TextBox textHfeVcePoints;
  internal TextBox textHfeVceVcMax;
  internal TextBox textHfeVceVcMin;
  internal Button butStartHfeVce;
  internal PictureBox picBJTHfeVceCircuitLarge;
  internal TabPage tabHfeVce;
  internal OpenFileDialog openDataFileDialog;
  internal SaveFileDialog saveDataFileDialog;
  internal ToolStripMenuItem menuDataSaveData;
  internal ToolStripMenuItem menuDataCopyData;
  internal ColorDialog TraceColorDialog;
  internal PictureBox picPNCircuitSmall;
  internal PictureBox picBJTHfeVceCircuitSmall;
  internal PictureBox picBJTHfeIcCircuitSmall;
  internal PictureBox picMOSIdVdsCircuitSmall;
  internal PictureBox picMOSIdVgsCircuitSmall;
  internal PictureBox picJFETIdVdsCircuitSmall;
  internal PictureBox picJFETIdVgsCircuitSmall;
  internal PictureBox picVRegVoViSmall;
  internal ToolStripMenuItem MenuCheckForUpdates;
  internal ToolStripMenuItem MenuCheckForUpdatesAutomatically;
  internal ToolStripMenuItem MenuCheckForUpdatesNow;
  internal System.Windows.Forms.Label label66;
  internal TextBox textJIdVgsTraces;
  internal TextBox textJIdVgsVdsMax;
  internal CheckBox checkMIdVdsLog;
  internal PictureBox picIGBTIcVceCircuitLarge;
  internal ZedGraphControl zedGraphTIcVce;
  internal GraphPanel panelIGBTIcVce;
  internal CheckBox checkTIcVceLog;
  internal Button butStartTIcVce;
  internal TextBox textTIcVceTraces;
  internal TextBox textTIcVceVgeMax;
  internal TextBox textTIcVceVgeMin;
  internal TextBox textTIcVcePoints;
  internal TextBox textTIcVceVccMax;
  internal TextBox textTIcVceVccMin;
  internal PictureBox picIGBTIcVceCircuitSmall;
  internal PictureBox picIGBTIcVgeCircuitLarge;
  internal ZedGraphControl zedGraphTIcVge;
  internal GraphPanel panelIGBTIcVge;
  internal TextBox textTIcVgeTraces;
  internal TextBox textTIcVgeVceMax;
  internal TextBox textTIcVgeVceMin;
  internal TextBox textTIcVgePoints;
  internal TextBox textTIcVgeVgeMax;
  internal TextBox textTIcVgeVgeMin;
  internal Button butStartTIcVge;
  internal PictureBox picIGBTIcVgeCircuitSmall;
  private ToolStripSeparator toolStripSeparator2;
  internal GraphPanel panelIcVce;
  internal PictureBox picBJTIcVceCircuitSmall;
  internal Button butStartIcVce;
  internal RichTextBox rtextIcVceConfig;
  internal MyPanel myPanelResults;
  internal ComboBoxCustom comboPNCathode;
  internal ComboBoxCustom comboPNAnode;
  internal ComboBoxCustom comboPNBias;
  internal RichTextBox rtextIdentifyResults;
  internal RichTextBox rtextVRegVoViConfig;
  internal RichTextBox rtextIdVdsConfig;
  internal RichTextBox rtextIdVgsConfig;
  internal RichTextBox rtextHfeVceConfig;
  internal RichTextBox rtextHfeIcConfig;
  internal RichTextBox rtextTIcVceConfig;
  internal RichTextBox rtextTIcVgeConfig;
  internal CheckBox checkJIdVgsLockParameters;
  internal CheckBox checkJIdVdsLockParameters;
  internal CheckBox checkMIdVdsLockParameters;
  internal CheckBox checkMIdVgsLockParameters;
  internal CheckBox checkHfeVceLockParameters;
  internal CheckBox checkHfeIcLockParameters;
  internal CheckBox checkTIcVceLockParameters;
  internal CheckBox checkTIcVgeLockParameters;
  internal Panel panel1;
  internal NumericUpDown numGlobalTraceN;
  internal TextBox textGlobalTracePrefix;
  internal TextBox textIcVceVcMin;
  internal CheckBox checkIcVceLockParameters;
  internal TextBox textIcVceBaseTraces;
  internal TextBox textIcVceBaseuIMax;
  internal TextBox textIcVceBaseuIMin;
  internal TextBox textIcVcePoints;
  internal TextBox textIcVceVcMax;
  internal Button butAutosetIcVce;
  internal Button butAutosetJIdVgs;
  internal Button butAutosetJIdVds;
  internal Button butAutosetMIdVds;
  internal Button butAutosetMIdVgs;
  internal Button butAutosetHfeVce;
  internal Button butAutosetHfeIc;
  internal Button butAutosetTIcVce;
  internal Button butAutosetTIcVge;
  internal ToolStripMenuItem selectGraphsTSMI;
  internal ToolStripMenuItem PNJunctMenuItem;
  internal ToolStripSeparator toolStripSeparator4;
  internal ToolStripMenuItem BJTMenuCategory;
  internal ToolStripMenuItem IcVceBJTMenuSubItem;
  internal ToolStripMenuItem HfeVceBJTMenuSubItem;
  internal ToolStripMenuItem HfeIcBJTMenuSubItem;
  internal ToolStripSeparator toolStripSeparator5;
  internal ToolStripMenuItem MOSFETMenuCategory;
  internal ToolStripMenuItem IdVdsMOSFETMenuSubItem;
  internal ToolStripMenuItem IdVgsMOSFETMenuSubItem;
  internal ToolStripSeparator toolStripSeparator6;
  internal ToolStripMenuItem IGBTMenuCategory;
  internal ToolStripMenuItem IcVceIGBTMenuSubItem;
  internal ToolStripMenuItem IcVgeIGBTMenuSubItem;
  private ToolStripSeparator toolStripSeparator1;
  internal ToolStripMenuItem JFETMenuCategory;
  internal ToolStripMenuItem IdVdsJFETMenuSubItem;
  internal ToolStripMenuItem IdVgsJFETMenuSubItem;
  internal ToolStripSeparator toolStripSeparator8;
  internal ToolStripMenuItem VRegMenuCategory;
  internal ToolStripMenuItem VoutVinVRegMenuSubItem;
  private ToolStripSeparator toolStripSeparator3;
  internal TabPage tabIcVbe;
  internal PictureBox picBJTIcVbeCircuitLarge;
  internal GraphPanel panelIcVbe;
  internal Button butAutosetIcVbe;
  internal RichTextBox rtextIcVbeConfig;
  internal TextBox textIcVbeVbMin;
  internal CheckBox checkIcVbeLockParameters;
  internal TextBox textIcVbeTraces;
  internal TextBox textIcVbeVcMax;
  internal TextBox textIcVbeVcMin;
  internal TextBox textIcVbePoints;
  internal TextBox textIcVbeVbMax;
  internal Button butStartIcVbe;
  internal PictureBox picIcVbeCircuitSmall;
  internal ZedGraphControl zedGraphIcVbe;
  internal ToolStripMenuItem IcVbeBJTMenuSubItem;
  private System.Windows.Forms.Label label122;
  private System.Windows.Forms.Label label135;
  private System.Windows.Forms.Label label138;
  private System.Windows.Forms.Label label139;
  private System.Windows.Forms.Label label140;
  private System.Windows.Forms.Label label141;
  private System.Windows.Forms.Label label142;
  private System.Windows.Forms.Label label143;
  private System.Windows.Forms.Label label144;
  private System.Windows.Forms.Label label145;
  private System.Windows.Forms.Label label146;
  private System.Windows.Forms.Label label147;
  private System.Windows.Forms.Label label148;
  internal ComboBoxCustom comboPNOther;
  internal ToolStripMenuItem renameGraphTSMI;
  internal ToolStripMenuItem resetDefaultGraphNameTSMI;
  internal ToolStripMenuItem deleteTSMI;
  internal ToolStripMenuItem deleteAllTracesTSMI;
  internal ToolStripMenuItem deleteAllAllTracesTSMI;
  internal ToolStripMenuItem unlockTSMI;
  internal ToolStripMenuItem unlockAllTSMI;
  internal ToolStripMenuItem unlockAllAllTSMI;
  internal ToolStripMenuItem fontSizeTSMI;
  internal ToolStripMenuItem fontSizeTSMI1;
  internal ToolStripMenuItem copyImageTSMI;
  internal ToolStripMenuItem pageSetupTSMI;
  internal ToolStripMenuItem printTSMI;
  internal ToolStripMenuItem hideLegendTSMI;
  internal ToolStripMenuItem printPreviewTSMI;
  internal LinkLabel lLabelCompTrace;
  internal TabPage tabFIdVgs;
  internal TabPage tabTIcVce;
  internal TabPage tabTIcVge;
  public ToolTip ToolTipFrm;
  internal TabPage tabIcIb;
  internal PictureBox picBJTIcIbCircuitLarge;
  internal ZedGraphControl zedGraphIcIb;
  internal GraphPanel panelIcIb;
  internal Button butAutosetIcIb;
  internal CheckBox checkIcIbLockParameters;
  internal RichTextBox rtextIcIbConfig;
  internal TextBox textIcIbTraces;
  internal TextBox textIcIbBaseuIMax;
  internal TextBox textIcIbBaseuIMin;
  internal TextBox textIcIbPoints;
  internal TextBox textIcIbVcMax;
  internal TextBox textIcIbVcMin;
  internal Button butStartIcIb;
  internal PictureBox picBJTIcIbCircuitSmall;
  internal ToolStripMenuItem IcIbBJTMenuSubItem;
  internal frmDCAProApp frmMy;
  internal DCAProUnit thisDCAPro;
  internal DeviceManagement myDeviceMan;
  internal AboutBox About;
  internal frmSplash Splash;
  internal UpdatePromptBox UpdatePrompt;
  internal DLUpdateBox DLUpdatePrompt;
  internal dialogLCDContrast dlgLCDContrast;
  internal Version FailedSWVersion = new Version("0.0.0.0");
  internal Version CurrentSWVersion = new Version("0.0.0.0");
  internal bool UpdateChecked;
  internal bool ReportUpdate;
  internal Version thisVersion = Assembly.GetEntryAssembly().GetName().Version;
  internal bool DCAFWValid;
  private int FormClosingState;
  private int ClosingTimeout;
  private bool UserWait;
  private bool TimerTicking;
  internal bool WasConnected;
  private DCAProUnit.STATE PreviousState;
  private frmDCAProApp.AResult NewResult = new frmDCAProApp.AResult();
  private frmDCAProApp.DisEnable NewDisEnable = new frmDCAProApp.DisEnable();
  private frmDCAProApp.ComponentName theComponentName = new frmDCAProApp.ComponentName();
  internal ContextMenuStrip ResultContextMenu;
  internal Graph[] Graphs = new Graph[13];

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  [DebuggerStepThrough]
  internal void InitializeComponent()
  {
    this.components = (IContainer) new System.ComponentModel.Container();
    GraphPanel.RectanglePlus rectanglePlus1 = new GraphPanel.RectanglePlus();
    GraphPanel.RectanglePlus rectanglePlus2 = new GraphPanel.RectanglePlus();
    GraphPanel.RectanglePlus rectanglePlus3 = new GraphPanel.RectanglePlus();
    GraphPanel.RectanglePlus rectanglePlus4 = new GraphPanel.RectanglePlus();
    GraphPanel.RectanglePlus rectanglePlus5 = new GraphPanel.RectanglePlus();
    GraphPanel.RectanglePlus rectanglePlus6 = new GraphPanel.RectanglePlus();
    GraphPanel.RectanglePlus rectanglePlus7 = new GraphPanel.RectanglePlus();
    GraphPanel.RectanglePlus rectanglePlus8 = new GraphPanel.RectanglePlus();
    GraphPanel.RectanglePlus rectanglePlus9 = new GraphPanel.RectanglePlus();
    GraphPanel.RectanglePlus rectanglePlus10 = new GraphPanel.RectanglePlus();
    GraphPanel.RectanglePlus rectanglePlus11 = new GraphPanel.RectanglePlus();
    GraphPanel.RectanglePlus rectanglePlus12 = new GraphPanel.RectanglePlus();
    GraphPanel.RectanglePlus rectanglePlus13 = new GraphPanel.RectanglePlus();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmDCAProApp));
    this.textGlobalTracePrefix = new TextBox();
    this.tabPNTest = new TabPage();
    this.picPNCircuitLarge = new PictureBox();
    this.zedGraphPNJunct = new ZedGraphControl();
    this.panelPNJunction = new GraphPanel();
    this.comboPNOther = new ComboBoxCustom();
    this.comboPNBias = new ComboBoxCustom();
    this.comboPNCathode = new ComboBoxCustom();
    this.comboPNAnode = new ComboBoxCustom();
    this.label15 = new System.Windows.Forms.Label();
    this.label14 = new System.Windows.Forms.Label();
    this.TextPNPoints = new TextBox();
    this.TextPNVMax = new TextBox();
    this.TextPNVMin = new TextBox();
    this.butStartPN = new Button();
    this.picPNCircuitSmall = new PictureBox();
    this.tabIdentify = new TabPage();
    this.myPanelResults = new MyPanel();
    this.rtextIdentifyResults = new RichTextBox();
    this.contextMenuComments = new ContextMenuStrip(this.components);
    this.copyToolStripMenuItem = new ToolStripMenuItem();
    this.textComments = new RichTextBox();
    this.panel2 = new Panel();
    this.pictureResult = new PictureBox();
    this.buttonIdentify = new Button();
    this.timerPulse = new System.Windows.Forms.Timer(this.components);
    this.bgWorkerTest = new BackgroundWorker();
    this.menuStripMain = new MenuStrip();
    this.DCAProToolStripMenuItem = new ToolStripMenuItem();
    this.programFirmwareToolStripMenuItem = new ToolStripMenuItem();
    this.LCDToolStripMenuItem = new ToolStripMenuItem();
    this.exitToolStripMenuItem = new ToolStripMenuItem();
    this.dataToolStripMenuItem = new ToolStripMenuItem();
    this.menuDataLoadData = new ToolStripMenuItem();
    this.menuDataSaveData = new ToolStripMenuItem();
    this.menuDataCopyData = new ToolStripMenuItem();
    this.graphsToolStripMenuItem = new ToolStripMenuItem();
    this.selectGraphsTSMI = new ToolStripMenuItem();
    this.PNJunctMenuItem = new ToolStripMenuItem();
    this.toolStripSeparator4 = new ToolStripSeparator();
    this.BJTMenuCategory = new ToolStripMenuItem();
    this.IcVceBJTMenuSubItem = new ToolStripMenuItem();
    this.HfeVceBJTMenuSubItem = new ToolStripMenuItem();
    this.HfeIcBJTMenuSubItem = new ToolStripMenuItem();
    this.IcVbeBJTMenuSubItem = new ToolStripMenuItem();
    this.IcIbBJTMenuSubItem = new ToolStripMenuItem();
    this.toolStripSeparator5 = new ToolStripSeparator();
    this.MOSFETMenuCategory = new ToolStripMenuItem();
    this.IdVdsMOSFETMenuSubItem = new ToolStripMenuItem();
    this.IdVgsMOSFETMenuSubItem = new ToolStripMenuItem();
    this.toolStripSeparator6 = new ToolStripSeparator();
    this.IGBTMenuCategory = new ToolStripMenuItem();
    this.IcVceIGBTMenuSubItem = new ToolStripMenuItem();
    this.IcVgeIGBTMenuSubItem = new ToolStripMenuItem();
    this.toolStripSeparator1 = new ToolStripSeparator();
    this.JFETMenuCategory = new ToolStripMenuItem();
    this.IdVdsJFETMenuSubItem = new ToolStripMenuItem();
    this.IdVgsJFETMenuSubItem = new ToolStripMenuItem();
    this.toolStripSeparator8 = new ToolStripSeparator();
    this.VRegMenuCategory = new ToolStripMenuItem();
    this.VoutVinVRegMenuSubItem = new ToolStripMenuItem();
    this.toolStripSeparator2 = new ToolStripSeparator();
    this.renameGraphTSMI = new ToolStripMenuItem();
    this.resetDefaultGraphNameTSMI = new ToolStripMenuItem();
    this.copyImageTSMI = new ToolStripMenuItem();
    this.pageSetupTSMI = new ToolStripMenuItem();
    this.printPreviewTSMI = new ToolStripMenuItem();
    this.printTSMI = new ToolStripMenuItem();
    this.deleteTSMI = new ToolStripMenuItem();
    this.deleteAllTracesTSMI = new ToolStripMenuItem();
    this.deleteAllAllTracesTSMI = new ToolStripMenuItem();
    this.unlockTSMI = new ToolStripMenuItem();
    this.unlockAllTSMI = new ToolStripMenuItem();
    this.unlockAllAllTSMI = new ToolStripMenuItem();
    this.hideLegendTSMI = new ToolStripMenuItem();
    this.toolStripSeparator3 = new ToolStripSeparator();
    this.fontSizeTSMI = new ToolStripMenuItem();
    this.fontSizeTSMI1 = new ToolStripMenuItem();
    this.helpToolStripMenuItem = new ToolStripMenuItem();
    this.MenuCheckForUpdates = new ToolStripMenuItem();
    this.MenuCheckForUpdatesAutomatically = new ToolStripMenuItem();
    this.MenuCheckForUpdatesNow = new ToolStripMenuItem();
    this.aboutToolStripMenuItem = new ToolStripMenuItem();
    this.openHEXFileDialog = new OpenFileDialog();
    this.timerDisplay = new System.Windows.Forms.Timer(this.components);
    this.toolStripStatusLabelDevice = new ToolStripStatusLabel();
    this.toolStripProgressBar = new ToolStripProgressBar();
    this.toolStripProgressLabel = new ToolStripStatusLabel();
    this.toolStripStatusError = new ToolStripStatusLabel();
    this.toolStripState = new ToolStripStatusLabel();
    this.toolStripIdentify = new ToolStripStatusLabel();
    this.statusStrip1 = new StatusStrip();
    this.tabVRegTest = new TabPage();
    this.picVRegVoViLarge = new PictureBox();
    this.zedGraphVRegVoVi = new ZedGraphControl();
    this.panelVRegVoutVin = new GraphPanel();
    this.rtextVRegVoViConfig = new RichTextBox();
    this.textVRegVoViPoints = new TextBox();
    this.textVRegVoViViMax = new TextBox();
    this.textVRegVoViViMin = new TextBox();
    this.butStartVRegVoVi = new Button();
    this.picVRegVoViSmall = new PictureBox();
    this.tabJIdVgs = new TabPage();
    this.picJFETIdVgsCircuitLarge = new PictureBox();
    this.zedGraphJIdVgs = new ZedGraphControl();
    this.panelJIdVgs = new GraphPanel();
    this.butAutosetJIdVgs = new Button();
    this.checkJIdVgsLockParameters = new CheckBox();
    this.label66 = new System.Windows.Forms.Label();
    this.textJIdVgsTraces = new TextBox();
    this.textJIdVgsVdsMax = new TextBox();
    this.comboJIdVgsConfig = new ComboBoxCustom();
    this.textJIdVgsVdsMin = new TextBox();
    this.textJIdVgsPoints = new TextBox();
    this.textJIdVgsVgsMax = new TextBox();
    this.textJIdVgsVgsMin = new TextBox();
    this.butStartJIdVgs = new Button();
    this.picJFETIdVgsCircuitSmall = new PictureBox();
    this.tabJIdVds = new TabPage();
    this.picJFETIdVdsCircuitLarge = new PictureBox();
    this.zedGraphJIdVds = new ZedGraphControl();
    this.panelJIdVds = new GraphPanel();
    this.butAutosetJIdVds = new Button();
    this.checkJIdVdsLockParameters = new CheckBox();
    this.comboJIdVdsConfig = new ComboBoxCustom();
    this.label87 = new System.Windows.Forms.Label();
    this.label88 = new System.Windows.Forms.Label();
    this.textJIdVdsTraces = new TextBox();
    this.textJIdVdsVgsMax = new TextBox();
    this.textJIdVdsVgsMin = new TextBox();
    this.textJIdVdsPoints = new TextBox();
    this.textJIdVdsVdsMax = new TextBox();
    this.textJIdVdsVdsMin = new TextBox();
    this.butStartJIdVds = new Button();
    this.picJFETIdVdsCircuitSmall = new PictureBox();
    this.tabFIdVds = new TabPage();
    this.picMOSIdVdsCircuitLarge = new PictureBox();
    this.zedGraphMIdVds = new ZedGraphControl();
    this.panelMIdVds = new GraphPanel();
    this.butAutosetMIdVds = new Button();
    this.checkMIdVdsLockParameters = new CheckBox();
    this.rtextIdVdsConfig = new RichTextBox();
    this.checkMIdVdsLog = new CheckBox();
    this.butStartMIdVds = new Button();
    this.textIdVdsTraces = new TextBox();
    this.textIdVdsVgsMax = new TextBox();
    this.textIdVdsVgsMin = new TextBox();
    this.textIdVdsPoints = new TextBox();
    this.textIdVdsVddMax = new TextBox();
    this.textIdVdsVddMin = new TextBox();
    this.picMOSIdVdsCircuitSmall = new PictureBox();
    this.tabFIdVgs = new TabPage();
    this.picMOSIdVgsCircuitLarge = new PictureBox();
    this.zedGraphMIdVgs = new ZedGraphControl();
    this.panelMIdVgs = new GraphPanel();
    this.butAutosetMIdVgs = new Button();
    this.checkMIdVgsLockParameters = new CheckBox();
    this.rtextIdVgsConfig = new RichTextBox();
    this.textMIdVgsTraces = new TextBox();
    this.textMIdVgsVdsMax = new TextBox();
    this.textMIdVgsVdsMin = new TextBox();
    this.textMIdVgsPoints = new TextBox();
    this.textMIdVgsVgsMax = new TextBox();
    this.textMIdVgsVgsMin = new TextBox();
    this.butStartMIdVgs = new Button();
    this.picMOSIdVgsCircuitSmall = new PictureBox();
    this.tabIcVce = new TabPage();
    this.picBJTIcVceCircuitLarge = new PictureBox();
    this.zedGraphIcVce = new ZedGraphControl();
    this.panelIcVce = new GraphPanel();
    this.butAutosetIcVce = new Button();
    this.rtextIcVceConfig = new RichTextBox();
    this.textIcVceVcMin = new TextBox();
    this.checkIcVceLockParameters = new CheckBox();
    this.textIcVceBaseTraces = new TextBox();
    this.textIcVceBaseuIMax = new TextBox();
    this.textIcVceBaseuIMin = new TextBox();
    this.textIcVcePoints = new TextBox();
    this.textIcVceVcMax = new TextBox();
    this.butStartIcVce = new Button();
    this.picBJTIcVceCircuitSmall = new PictureBox();
    this.tabControl = new TabControl();
    this.tabHfeVce = new TabPage();
    this.picBJTHfeVceCircuitLarge = new PictureBox();
    this.zedGraphHfeVce = new ZedGraphControl();
    this.panelHFEVce = new GraphPanel();
    this.butAutosetHfeVce = new Button();
    this.checkHfeVceLockParameters = new CheckBox();
    this.rtextHfeVceConfig = new RichTextBox();
    this.textHfeVceBaseTraces = new TextBox();
    this.textHfeVceBaseuIMax = new TextBox();
    this.textHfeVceBaseuIMin = new TextBox();
    this.textHfeVcePoints = new TextBox();
    this.textHfeVceVcMax = new TextBox();
    this.textHfeVceVcMin = new TextBox();
    this.butStartHfeVce = new Button();
    this.picBJTHfeVceCircuitSmall = new PictureBox();
    this.tabHfeIc = new TabPage();
    this.picBJTHfeIcCircuitLarge = new PictureBox();
    this.zedGraphHfeIc = new ZedGraphControl();
    this.panelHFEIc = new GraphPanel();
    this.butAutosetHfeIc = new Button();
    this.checkHfeIcLockParameters = new CheckBox();
    this.rtextHfeIcConfig = new RichTextBox();
    this.textHfeIcTraces = new TextBox();
    this.textHfeIcBaseuIMax = new TextBox();
    this.textHfeIcBaseuIMin = new TextBox();
    this.textHfeIcPoints = new TextBox();
    this.textHfeIcVcMax = new TextBox();
    this.textHfeIcVcMin = new TextBox();
    this.butStartHfeIc = new Button();
    this.picBJTHfeIcCircuitSmall = new PictureBox();
    this.tabIcVbe = new TabPage();
    this.picBJTIcVbeCircuitLarge = new PictureBox();
    this.zedGraphIcVbe = new ZedGraphControl();
    this.panelIcVbe = new GraphPanel();
    this.butAutosetIcVbe = new Button();
    this.rtextIcVbeConfig = new RichTextBox();
    this.label122 = new System.Windows.Forms.Label();
    this.textIcVbeVbMin = new TextBox();
    this.checkIcVbeLockParameters = new CheckBox();
    this.label135 = new System.Windows.Forms.Label();
    this.label138 = new System.Windows.Forms.Label();
    this.label139 = new System.Windows.Forms.Label();
    this.textIcVbeTraces = new TextBox();
    this.textIcVbeVcMax = new TextBox();
    this.textIcVbeVcMin = new TextBox();
    this.label140 = new System.Windows.Forms.Label();
    this.label141 = new System.Windows.Forms.Label();
    this.label142 = new System.Windows.Forms.Label();
    this.label143 = new System.Windows.Forms.Label();
    this.label144 = new System.Windows.Forms.Label();
    this.textIcVbePoints = new TextBox();
    this.textIcVbeVbMax = new TextBox();
    this.label145 = new System.Windows.Forms.Label();
    this.label146 = new System.Windows.Forms.Label();
    this.label147 = new System.Windows.Forms.Label();
    this.butStartIcVbe = new Button();
    this.label148 = new System.Windows.Forms.Label();
    this.picIcVbeCircuitSmall = new PictureBox();
    this.tabIcIb = new TabPage();
    this.picBJTIcIbCircuitLarge = new PictureBox();
    this.zedGraphIcIb = new ZedGraphControl();
    this.panelIcIb = new GraphPanel();
    this.butAutosetIcIb = new Button();
    this.checkIcIbLockParameters = new CheckBox();
    this.rtextIcIbConfig = new RichTextBox();
    this.textIcIbTraces = new TextBox();
    this.textIcIbBaseuIMax = new TextBox();
    this.textIcIbBaseuIMin = new TextBox();
    this.textIcIbPoints = new TextBox();
    this.textIcIbVcMax = new TextBox();
    this.textIcIbVcMin = new TextBox();
    this.butStartIcIb = new Button();
    this.picBJTIcIbCircuitSmall = new PictureBox();
    this.tabTIcVce = new TabPage();
    this.picIGBTIcVceCircuitLarge = new PictureBox();
    this.zedGraphTIcVce = new ZedGraphControl();
    this.panelIGBTIcVce = new GraphPanel();
    this.butAutosetTIcVce = new Button();
    this.checkTIcVceLockParameters = new CheckBox();
    this.rtextTIcVceConfig = new RichTextBox();
    this.checkTIcVceLog = new CheckBox();
    this.butStartTIcVce = new Button();
    this.textTIcVceTraces = new TextBox();
    this.textTIcVceVgeMax = new TextBox();
    this.textTIcVceVgeMin = new TextBox();
    this.textTIcVcePoints = new TextBox();
    this.textTIcVceVccMax = new TextBox();
    this.textTIcVceVccMin = new TextBox();
    this.picIGBTIcVceCircuitSmall = new PictureBox();
    this.tabTIcVge = new TabPage();
    this.picIGBTIcVgeCircuitLarge = new PictureBox();
    this.zedGraphTIcVge = new ZedGraphControl();
    this.panelIGBTIcVge = new GraphPanel();
    this.butAutosetTIcVge = new Button();
    this.checkTIcVgeLockParameters = new CheckBox();
    this.rtextTIcVgeConfig = new RichTextBox();
    this.textTIcVgeTraces = new TextBox();
    this.textTIcVgeVceMax = new TextBox();
    this.textTIcVgeVceMin = new TextBox();
    this.textTIcVgePoints = new TextBox();
    this.textTIcVgeVgeMax = new TextBox();
    this.textTIcVgeVgeMin = new TextBox();
    this.butStartTIcVge = new Button();
    this.picIGBTIcVgeCircuitSmall = new PictureBox();
    this.bgWorkerUpdate = new BackgroundWorker();
    this.openDataFileDialog = new OpenFileDialog();
    this.saveDataFileDialog = new SaveFileDialog();
    this.TraceColorDialog = new ColorDialog();
    this.panel1 = new Panel();
    this.numGlobalTraceN = new NumericUpDown();
    this.lLabelCompTrace = new LinkLabel();
    this.ToolTipFrm = new ToolTip(this.components);
    System.Windows.Forms.Label label1 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label2 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label3 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label4 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label5 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label6 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label7 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label8 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label9 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label10 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label11 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label12 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label13 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label14 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label15 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label16 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label17 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label18 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label19 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label20 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label21 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label22 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label23 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label24 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label25 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label26 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label27 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label28 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label29 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label30 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label31 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label32 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label33 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label34 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label35 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label36 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label37 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label38 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label39 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label40 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label41 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label42 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label43 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label44 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label45 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label46 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label47 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label48 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label49 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label50 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label51 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label52 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label53 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label54 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label55 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label56 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label57 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label58 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label59 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label60 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label61 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label62 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label63 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label64 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label65 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label66 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label67 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label68 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label69 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label70 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label71 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label72 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label73 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label74 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label75 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label76 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label77 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label78 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label79 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label80 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label81 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label82 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label83 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label84 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label85 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label86 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label87 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label88 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label89 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label90 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label91 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label92 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label93 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label94 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label95 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label96 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label97 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label98 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label99 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label100 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label101 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label102 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label103 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label104 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label105 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label106 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label107 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label108 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label109 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label110 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label111 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label112 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label113 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label114 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label115 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label116 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label117 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label118 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label119 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label120 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label121 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label122 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label123 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label124 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label125 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label126 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label127 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label128 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label129 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label130 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label131 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label132 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label133 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label134 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label135 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label136 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label137 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label138 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label139 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label140 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label141 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label142 = new System.Windows.Forms.Label();
    System.Windows.Forms.Label label143 = new System.Windows.Forms.Label();
    this.tabPNTest.SuspendLayout();
    ((ISupportInitialize) this.picPNCircuitLarge).BeginInit();
    this.panelPNJunction.SuspendLayout();
    ((ISupportInitialize) this.picPNCircuitSmall).BeginInit();
    this.tabIdentify.SuspendLayout();
    this.myPanelResults.SuspendLayout();
    this.contextMenuComments.SuspendLayout();
    this.panel2.SuspendLayout();
    ((ISupportInitialize) this.pictureResult).BeginInit();
    this.menuStripMain.SuspendLayout();
    this.statusStrip1.SuspendLayout();
    this.tabVRegTest.SuspendLayout();
    ((ISupportInitialize) this.picVRegVoViLarge).BeginInit();
    this.panelVRegVoutVin.SuspendLayout();
    ((ISupportInitialize) this.picVRegVoViSmall).BeginInit();
    this.tabJIdVgs.SuspendLayout();
    ((ISupportInitialize) this.picJFETIdVgsCircuitLarge).BeginInit();
    this.panelJIdVgs.SuspendLayout();
    ((ISupportInitialize) this.picJFETIdVgsCircuitSmall).BeginInit();
    this.tabJIdVds.SuspendLayout();
    ((ISupportInitialize) this.picJFETIdVdsCircuitLarge).BeginInit();
    this.panelJIdVds.SuspendLayout();
    ((ISupportInitialize) this.picJFETIdVdsCircuitSmall).BeginInit();
    this.tabFIdVds.SuspendLayout();
    ((ISupportInitialize) this.picMOSIdVdsCircuitLarge).BeginInit();
    this.panelMIdVds.SuspendLayout();
    ((ISupportInitialize) this.picMOSIdVdsCircuitSmall).BeginInit();
    this.tabFIdVgs.SuspendLayout();
    ((ISupportInitialize) this.picMOSIdVgsCircuitLarge).BeginInit();
    this.panelMIdVgs.SuspendLayout();
    ((ISupportInitialize) this.picMOSIdVgsCircuitSmall).BeginInit();
    this.tabIcVce.SuspendLayout();
    ((ISupportInitialize) this.picBJTIcVceCircuitLarge).BeginInit();
    this.panelIcVce.SuspendLayout();
    ((ISupportInitialize) this.picBJTIcVceCircuitSmall).BeginInit();
    this.tabControl.SuspendLayout();
    this.tabHfeVce.SuspendLayout();
    ((ISupportInitialize) this.picBJTHfeVceCircuitLarge).BeginInit();
    this.panelHFEVce.SuspendLayout();
    ((ISupportInitialize) this.picBJTHfeVceCircuitSmall).BeginInit();
    this.tabHfeIc.SuspendLayout();
    ((ISupportInitialize) this.picBJTHfeIcCircuitLarge).BeginInit();
    this.panelHFEIc.SuspendLayout();
    ((ISupportInitialize) this.picBJTHfeIcCircuitSmall).BeginInit();
    this.tabIcVbe.SuspendLayout();
    ((ISupportInitialize) this.picBJTIcVbeCircuitLarge).BeginInit();
    this.panelIcVbe.SuspendLayout();
    ((ISupportInitialize) this.picIcVbeCircuitSmall).BeginInit();
    this.tabIcIb.SuspendLayout();
    ((ISupportInitialize) this.picBJTIcIbCircuitLarge).BeginInit();
    this.panelIcIb.SuspendLayout();
    ((ISupportInitialize) this.picBJTIcIbCircuitSmall).BeginInit();
    this.tabTIcVce.SuspendLayout();
    ((ISupportInitialize) this.picIGBTIcVceCircuitLarge).BeginInit();
    this.panelIGBTIcVce.SuspendLayout();
    ((ISupportInitialize) this.picIGBTIcVceCircuitSmall).BeginInit();
    this.tabTIcVge.SuspendLayout();
    ((ISupportInitialize) this.picIGBTIcVgeCircuitLarge).BeginInit();
    this.panelIGBTIcVge.SuspendLayout();
    ((ISupportInitialize) this.picIGBTIcVgeCircuitSmall).BeginInit();
    this.panel1.SuspendLayout();
    this.numGlobalTraceN.BeginInit();
    this.SuspendLayout();
    label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    label1.AutoSize = true;
    label1.BackColor = Color.Transparent;
    label1.Location = new Point(283, 4);
    label1.Name = "label136";
    label1.Size = new Size(13, 14);
    label1.TabIndex = 104;
    label1.Text = "#";
    label2.AutoSize = true;
    label2.Location = new Point(7, 72);
    label2.Name = "label137";
    label2.Size = new Size(54, 14);
    label2.TabIndex = 57;
    label2.Text = "Third lead";
    label3.AutoSize = true;
    label3.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label3.Location = new Point(223, 35);
    label3.Name = "label70";
    label3.Size = new Size(25, 18);
    label3.TabIndex = 53;
    label3.Text = "Vs";
    label4.AutoSize = true;
    label4.Location = new Point(260, 36);
    label4.Name = "label13";
    label4.Size = new Size(18, 14);
    label4.TabIndex = 11;
    label4.Text = "To";
    label5.AutoSize = true;
    label5.Location = new Point(247, 8);
    label5.Name = "label12";
    label5.Size = new Size(31 /*0x1F*/, 14);
    label5.TabIndex = 10;
    label5.Text = "From";
    label6.AutoSize = true;
    label6.Location = new Point(242, 64 /*0x40*/);
    label6.Name = "label10";
    label6.Size = new Size(36, 14);
    label6.TabIndex = 9;
    label6.Text = "Points";
    label7.AutoSize = true;
    label7.Location = new Point(33, 51);
    label7.Name = "label3";
    label7.Size = new Size(28, 14);
    label7.TabIndex = 6;
    label7.Text = "Bias";
    label7.TextAlign = ContentAlignment.MiddleRight;
    label8.AutoSize = true;
    label8.Location = new Point(14, 29);
    label8.Name = "label2";
    label8.Size = new Size(47, 14);
    label8.TabIndex = 3;
    label8.Text = "Cathode";
    label9.AutoSize = true;
    label9.Location = new Point(22, 7);
    label9.Name = "label1";
    label9.Size = new Size(39, 14);
    label9.TabIndex = 2;
    label9.Text = "Anode";
    label10.AutoSize = true;
    label10.BackColor = Color.Transparent;
    label10.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label10.Location = new Point(98, 34);
    label10.Name = "label8";
    label10.Size = new Size(33, 18);
    label10.TabIndex = 115;
    label10.Text = "Vcc";
    label11.AutoSize = true;
    label11.BackColor = Color.Transparent;
    label11.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label11.Location = new Point(249, 34);
    label11.Name = "label7";
    label11.Size = new Size(21, 18);
    label11.TabIndex = 113;
    label11.Text = "Ib";
    label12.AutoSize = true;
    label12.BackColor = Color.Transparent;
    label12.Location = new Point(351, 36);
    label12.Name = "label54";
    label12.Size = new Size(21, 14);
    label12.TabIndex = 112 /*0x70*/;
    label12.Text = "µA";
    label13.AutoSize = true;
    label13.BackColor = Color.Transparent;
    label13.Location = new Point(351, 8);
    label13.Name = "label55";
    label13.Size = new Size(21, 14);
    label13.TabIndex = 111;
    label13.Text = "µA";
    label14.AutoSize = true;
    label14.BackColor = Color.Transparent;
    label14.Location = new Point(280, 36);
    label14.Name = "label56";
    label14.Size = new Size(18, 14);
    label14.TabIndex = 110;
    label14.Text = "To";
    label15.AutoSize = true;
    label15.BackColor = Color.Transparent;
    label15.Location = new Point(267, 8);
    label15.Name = "label57";
    label15.Size = new Size(31 /*0x1F*/, 14);
    label15.TabIndex = 109;
    label15.Text = "From";
    label16.AutoSize = true;
    label16.BackColor = Color.Transparent;
    label16.Location = new Point(257, 64 /*0x40*/);
    label16.Name = "label58";
    label16.Size = new Size(41, 14);
    label16.TabIndex = 108;
    label16.Text = "Traces";
    label17.AutoSize = true;
    label17.BackColor = Color.Transparent;
    label17.Location = new Point(209, 36);
    label17.Name = "label59";
    label17.Size = new Size(15, 14);
    label17.TabIndex = 107;
    label17.Text = "V";
    label18.AutoSize = true;
    label18.BackColor = Color.Transparent;
    label18.Location = new Point(209, 8);
    label18.Name = "label60";
    label18.Size = new Size(15, 14);
    label18.TabIndex = 106;
    label18.Text = "V";
    label19.AutoSize = true;
    label19.BackColor = Color.Transparent;
    label19.Location = new Point(138, 36);
    label19.Name = "label61";
    label19.Size = new Size(18, 14);
    label19.TabIndex = 105;
    label19.Text = "To";
    label20.AutoSize = true;
    label20.BackColor = Color.Transparent;
    label20.Location = new Point(125, 8);
    label20.Name = "label62";
    label20.Size = new Size(31 /*0x1F*/, 14);
    label20.TabIndex = 104;
    label20.Text = "From";
    label21.AutoSize = true;
    label21.BackColor = Color.Transparent;
    label21.Location = new Point(120, 64 /*0x40*/);
    label21.Name = "label63";
    label21.Size = new Size(36, 14);
    label21.TabIndex = 103;
    label21.Text = "Points";
    label22.AutoSize = true;
    label22.Location = new Point(12, 8);
    label22.Name = "label64";
    label22.Size = new Size(39, 14);
    label22.TabIndex = 90;
    label22.Text = "Pinout:";
    label23.AutoSize = true;
    label23.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label23.Location = new Point(98, 34);
    label23.Name = "label5";
    label23.Size = new Size(33, 18);
    label23.TabIndex = 30;
    label23.Text = "Vcc";
    label24.AutoSize = true;
    label24.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label24.Location = new Point(249, 34);
    label24.Name = "label29";
    label24.Size = new Size(21, 18);
    label24.TabIndex = 28;
    label24.Text = "Ib";
    label25.AutoSize = true;
    label25.Location = new Point(351, 36);
    label25.Name = "label30";
    label25.Size = new Size(21, 14);
    label25.TabIndex = 27;
    label25.Text = "µA";
    label26.AutoSize = true;
    label26.Location = new Point(351, 8);
    label26.Name = "label31";
    label26.Size = new Size(21, 14);
    label26.TabIndex = 26;
    label26.Text = "µA";
    label27.AutoSize = true;
    label27.Location = new Point(280, 36);
    label27.Name = "label32";
    label27.Size = new Size(18, 14);
    label27.TabIndex = 22;
    label27.Text = "To";
    label28.AutoSize = true;
    label28.Location = new Point(267, 8);
    label28.Name = "label33";
    label28.Size = new Size(31 /*0x1F*/, 14);
    label28.TabIndex = 21;
    label28.Text = "From";
    label29.AutoSize = true;
    label29.Location = new Point(257, 64 /*0x40*/);
    label29.Name = "label34";
    label29.Size = new Size(41, 14);
    label29.TabIndex = 20;
    label29.Text = "Traces";
    label30.AutoSize = true;
    label30.Location = new Point(209, 36);
    label30.Name = "label35";
    label30.Size = new Size(15, 14);
    label30.TabIndex = 19;
    label30.Text = "V";
    label31.AutoSize = true;
    label31.Location = new Point(209, 8);
    label31.Name = "label36";
    label31.Size = new Size(15, 14);
    label31.TabIndex = 18;
    label31.Text = "V";
    label32.AutoSize = true;
    label32.Location = new Point(138, 36);
    label32.Name = "label37";
    label32.Size = new Size(18, 14);
    label32.TabIndex = 11;
    label32.Text = "To";
    label33.AutoSize = true;
    label33.Location = new Point(125, 8);
    label33.Name = "label38";
    label33.Size = new Size(31 /*0x1F*/, 14);
    label33.TabIndex = 10;
    label33.Text = "From";
    label34.AutoSize = true;
    label34.Location = new Point(120, 64 /*0x40*/);
    label34.Name = "label39";
    label34.Size = new Size(36, 14);
    label34.TabIndex = 9;
    label34.Text = "Points";
    label35.AutoSize = true;
    label35.Location = new Point(12, 8);
    label35.Name = "label40";
    label35.Size = new Size(39, 14);
    label35.TabIndex = 2;
    label35.Text = "Pinout:";
    label36.AutoSize = true;
    label36.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label36.Location = new Point(239, 34);
    label36.Name = "label4";
    label36.Size = new Size(34, 18);
    label36.TabIndex = 30;
    label36.Text = "Vce";
    label37.AutoSize = true;
    label37.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label37.Location = new Point(98, 34);
    label37.Name = "label6";
    label37.Size = new Size(21, 18);
    label37.TabIndex = 28;
    label37.Text = "Ib";
    label38.AutoSize = true;
    label38.Location = new Point(209, 36);
    label38.Name = "label11";
    label38.Size = new Size(21, 14);
    label38.TabIndex = 27;
    label38.Text = "µA";
    label39.AutoSize = true;
    label39.Location = new Point(209, 8);
    label39.Name = "label16";
    label39.Size = new Size(21, 14);
    label39.TabIndex = 26;
    label39.Text = "µA";
    label40.AutoSize = true;
    label40.Location = new Point(280, 36);
    label40.Name = "label17";
    label40.Size = new Size(18, 14);
    label40.TabIndex = 22;
    label40.Text = "To";
    label41.AutoSize = true;
    label41.Location = new Point(267, 8);
    label41.Name = "label18";
    label41.Size = new Size(31 /*0x1F*/, 14);
    label41.TabIndex = 21;
    label41.Text = "From";
    label42.AutoSize = true;
    label42.Location = new Point(257, 64 /*0x40*/);
    label42.Name = "label19";
    label42.Size = new Size(41, 14);
    label42.TabIndex = 20;
    label42.Text = "Traces";
    label43.AutoSize = true;
    label43.Location = new Point(351, 36);
    label43.Name = "label20";
    label43.Size = new Size(15, 14);
    label43.TabIndex = 19;
    label43.Text = "V";
    label44.AutoSize = true;
    label44.Location = new Point(351, 8);
    label44.Name = "label21";
    label44.Size = new Size(15, 14);
    label44.TabIndex = 18;
    label44.Text = "V";
    label45.AutoSize = true;
    label45.Location = new Point(138, 36);
    label45.Name = "label22";
    label45.Size = new Size(18, 14);
    label45.TabIndex = 11;
    label45.Text = "To";
    label46.AutoSize = true;
    label46.Location = new Point(125, 8);
    label46.Name = "label25";
    label46.Size = new Size(31 /*0x1F*/, 14);
    label46.TabIndex = 10;
    label46.Text = "From";
    label47.AutoSize = true;
    label47.Location = new Point(120, 64 /*0x40*/);
    label47.Name = "label26";
    label47.Size = new Size(36, 14);
    label47.TabIndex = 9;
    label47.Text = "Points";
    label48.AutoSize = true;
    label48.Location = new Point(12, 8);
    label48.Name = "label27";
    label48.Size = new Size(39, 14);
    label48.TabIndex = 2;
    label48.Text = "Pinout:";
    label49.AutoSize = true;
    label49.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label49.Location = new Point(239, 34);
    label49.Name = "label149";
    label49.Size = new Size(34, 18);
    label49.TabIndex = 30;
    label49.Text = "Vce";
    label50.AutoSize = true;
    label50.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label50.Location = new Point(98, 34);
    label50.Name = "label150";
    label50.Size = new Size(21, 18);
    label50.TabIndex = 28;
    label50.Text = "Ib";
    label51.AutoSize = true;
    label51.Location = new Point(209, 36);
    label51.Name = "label151";
    label51.Size = new Size(21, 14);
    label51.TabIndex = 27;
    label51.Text = "µA";
    label52.AutoSize = true;
    label52.Location = new Point(209, 8);
    label52.Name = "label152";
    label52.Size = new Size(21, 14);
    label52.TabIndex = 26;
    label52.Text = "µA";
    label53.AutoSize = true;
    label53.Location = new Point(280, 36);
    label53.Name = "label153";
    label53.Size = new Size(18, 14);
    label53.TabIndex = 22;
    label53.Text = "To";
    label54.AutoSize = true;
    label54.Location = new Point(267, 8);
    label54.Name = "label154";
    label54.Size = new Size(31 /*0x1F*/, 14);
    label54.TabIndex = 21;
    label54.Text = "From";
    label55.AutoSize = true;
    label55.Location = new Point(257, 64 /*0x40*/);
    label55.Name = "label155";
    label55.Size = new Size(41, 14);
    label55.TabIndex = 20;
    label55.Text = "Traces";
    label56.AutoSize = true;
    label56.Location = new Point(351, 36);
    label56.Name = "label156";
    label56.Size = new Size(15, 14);
    label56.TabIndex = 19;
    label56.Text = "V";
    label57.AutoSize = true;
    label57.Location = new Point(351, 8);
    label57.Name = "label157";
    label57.Size = new Size(15, 14);
    label57.TabIndex = 18;
    label57.Text = "V";
    label58.AutoSize = true;
    label58.Location = new Point(138, 36);
    label58.Name = "label158";
    label58.Size = new Size(18, 14);
    label58.TabIndex = 11;
    label58.Text = "To";
    label59.AutoSize = true;
    label59.Location = new Point(125, 8);
    label59.Name = "label159";
    label59.Size = new Size(31 /*0x1F*/, 14);
    label59.TabIndex = 10;
    label59.Text = "From";
    label60.AutoSize = true;
    label60.Location = new Point(120, 64 /*0x40*/);
    label60.Name = "label160";
    label60.Size = new Size(36, 14);
    label60.TabIndex = 9;
    label60.Text = "Points";
    label61.AutoSize = true;
    label61.Location = new Point(12, 8);
    label61.Name = "label161";
    label61.Size = new Size(39, 14);
    label61.TabIndex = 2;
    label61.Text = "Pinout:";
    label62.AutoSize = true;
    label62.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label62.Location = new Point(98, 34);
    label62.Name = "label9";
    label62.Size = new Size(35, 18);
    label62.TabIndex = 52;
    label62.Text = "Vdd";
    label63.AutoSize = true;
    label63.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label63.Location = new Point(239, 34);
    label63.Name = "label42";
    label63.Size = new Size(34, 18);
    label63.TabIndex = 28;
    label63.Text = "Vgs";
    label64.AutoSize = true;
    label64.Location = new Point(351, 36);
    label64.Name = "label43";
    label64.Size = new Size(15, 14);
    label64.TabIndex = 27;
    label64.Text = "V";
    label65.AutoSize = true;
    label65.Location = new Point(351, 8);
    label65.Name = "label44";
    label65.Size = new Size(15, 14);
    label65.TabIndex = 26;
    label65.Text = "V";
    label66.AutoSize = true;
    label66.Location = new Point(280, 36);
    label66.Name = "label45";
    label66.Size = new Size(18, 14);
    label66.TabIndex = 22;
    label66.Text = "To";
    label67.AutoSize = true;
    label67.Location = new Point(267, 8);
    label67.Name = "label46";
    label67.Size = new Size(31 /*0x1F*/, 14);
    label67.TabIndex = 21;
    label67.Text = "From";
    label68.AutoSize = true;
    label68.Location = new Point(257, 64 /*0x40*/);
    label68.Name = "label47";
    label68.Size = new Size(41, 14);
    label68.TabIndex = 20;
    label68.Text = "Traces";
    label69.AutoSize = true;
    label69.Location = new Point(209, 36);
    label69.Name = "label48";
    label69.Size = new Size(15, 14);
    label69.TabIndex = 19;
    label69.Text = "V";
    label70.AutoSize = true;
    label70.Location = new Point(209, 8);
    label70.Name = "label49";
    label70.Size = new Size(15, 14);
    label70.TabIndex = 18;
    label70.Text = "V";
    label71.AutoSize = true;
    label71.Location = new Point(138, 36);
    label71.Name = "label50";
    label71.Size = new Size(18, 14);
    label71.TabIndex = 11;
    label71.Text = "To";
    label72.AutoSize = true;
    label72.Location = new Point(125, 8);
    label72.Name = "label51";
    label72.Size = new Size(31 /*0x1F*/, 14);
    label72.TabIndex = 10;
    label72.Text = "From";
    label73.AutoSize = true;
    label73.Location = new Point(120, 64 /*0x40*/);
    label73.Name = "label52";
    label73.Size = new Size(36, 14);
    label73.TabIndex = 9;
    label73.Text = "Points";
    label74.AutoSize = true;
    label74.Location = new Point(12, 8);
    label74.Name = "label53";
    label74.Size = new Size(39, 14);
    label74.TabIndex = 2;
    label74.Text = "Pinout:";
    label75.AutoSize = true;
    label75.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label75.Location = new Point(98, 34);
    label75.Name = "label71";
    label75.Size = new Size(34, 18);
    label75.TabIndex = 30;
    label75.Text = "Vgs";
    label76.AutoSize = true;
    label76.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label76.Location = new Point(239, 34);
    label76.Name = "label73";
    label76.Size = new Size(34, 18);
    label76.TabIndex = 28;
    label76.Text = "Vds";
    label77.AutoSize = true;
    label77.Location = new Point(351, 36);
    label77.Name = "label74";
    label77.Size = new Size(15, 14);
    label77.TabIndex = 27;
    label77.Text = "V";
    label78.AutoSize = true;
    label78.Location = new Point(351, 8);
    label78.Name = "label75";
    label78.Size = new Size(15, 14);
    label78.TabIndex = 26;
    label78.Text = "V";
    label79.AutoSize = true;
    label79.Location = new Point(280, 36);
    label79.Name = "label76";
    label79.Size = new Size(18, 14);
    label79.TabIndex = 22;
    label79.Text = "To";
    label80.AutoSize = true;
    label80.Location = new Point(267, 8);
    label80.Name = "label77";
    label80.Size = new Size(31 /*0x1F*/, 14);
    label80.TabIndex = 21;
    label80.Text = "From";
    label81.AutoSize = true;
    label81.Location = new Point(257, 64 /*0x40*/);
    label81.Name = "label78";
    label81.Size = new Size(41, 14);
    label81.TabIndex = 20;
    label81.Text = "Traces";
    label82.AutoSize = true;
    label82.Location = new Point(209, 36);
    label82.Name = "label79";
    label82.Size = new Size(15, 14);
    label82.TabIndex = 19;
    label82.Text = "V";
    label83.AutoSize = true;
    label83.Location = new Point(209, 8);
    label83.Name = "label80";
    label83.Size = new Size(15, 14);
    label83.TabIndex = 18;
    label83.Text = "V";
    label84.AutoSize = true;
    label84.Location = new Point(138, 36);
    label84.Name = "label81";
    label84.Size = new Size(18, 14);
    label84.TabIndex = 11;
    label84.Text = "To";
    label85.AutoSize = true;
    label85.Location = new Point(125, 8);
    label85.Name = "label82";
    label85.Size = new Size(31 /*0x1F*/, 14);
    label85.TabIndex = 10;
    label85.Text = "From";
    label86.AutoSize = true;
    label86.Location = new Point(120, 64 /*0x40*/);
    label86.Name = "label83";
    label86.Size = new Size(36, 14);
    label86.TabIndex = 9;
    label86.Text = "Points";
    label87.AutoSize = true;
    label87.Location = new Point(12, 8);
    label87.Name = "label84";
    label87.Size = new Size(39, 14);
    label87.TabIndex = 2;
    label87.Text = "Pinout:";
    label88.AutoSize = true;
    label88.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label88.Location = new Point(98, 34);
    label88.Name = "label67";
    label88.Size = new Size(33, 18);
    label88.TabIndex = 52;
    label88.Text = "Vcc";
    label89.AutoSize = true;
    label89.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label89.Location = new Point(238, 34);
    label89.Name = "label68";
    label89.Size = new Size(35, 18);
    label89.TabIndex = 28;
    label89.Text = "Vge";
    label90.AutoSize = true;
    label90.Location = new Point(351, 36);
    label90.Name = "label69";
    label90.Size = new Size(15, 14);
    label90.TabIndex = 27;
    label90.Text = "V";
    label91.AutoSize = true;
    label91.Location = new Point(351, 8);
    label91.Name = "label72";
    label91.Size = new Size(15, 14);
    label91.TabIndex = 26;
    label91.Text = "V";
    label92.AutoSize = true;
    label92.Location = new Point(280, 36);
    label92.Name = "label85";
    label92.Size = new Size(18, 14);
    label92.TabIndex = 22;
    label92.Text = "To";
    label93.AutoSize = true;
    label93.Location = new Point(267, 8);
    label93.Name = "label99";
    label93.Size = new Size(31 /*0x1F*/, 14);
    label93.TabIndex = 21;
    label93.Text = "From";
    label94.AutoSize = true;
    label94.Location = new Point(257, 64 /*0x40*/);
    label94.Name = "label101";
    label94.Size = new Size(41, 14);
    label94.TabIndex = 20;
    label94.Text = "Traces";
    label95.AutoSize = true;
    label95.Location = new Point(209, 36);
    label95.Name = "label103";
    label95.Size = new Size(15, 14);
    label95.TabIndex = 19;
    label95.Text = "V";
    label96.AutoSize = true;
    label96.Location = new Point(209, 8);
    label96.Name = "label104";
    label96.Size = new Size(15, 14);
    label96.TabIndex = 18;
    label96.Text = "V";
    label97.AutoSize = true;
    label97.Location = new Point(138, 36);
    label97.Name = "label105";
    label97.Size = new Size(18, 14);
    label97.TabIndex = 11;
    label97.Text = "To";
    label98.AutoSize = true;
    label98.Location = new Point(125, 8);
    label98.Name = "label112";
    label98.Size = new Size(31 /*0x1F*/, 14);
    label98.TabIndex = 10;
    label98.Text = "From";
    label99.AutoSize = true;
    label99.Location = new Point(120, 64 /*0x40*/);
    label99.Name = "label113";
    label99.Size = new Size(36, 14);
    label99.TabIndex = 9;
    label99.Text = "Points";
    label100.AutoSize = true;
    label100.Location = new Point(12, 8);
    label100.Name = "label120";
    label100.Size = new Size(39, 14);
    label100.TabIndex = 2;
    label100.Text = "Pinout:";
    label101.AutoSize = true;
    label101.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label101.Location = new Point(98, 34);
    label101.Name = "label121";
    label101.Size = new Size(35, 18);
    label101.TabIndex = 30;
    label101.Text = "Vge";
    label102.AutoSize = true;
    label102.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label102.Location = new Point(239, 34);
    label102.Name = "label123";
    label102.Size = new Size(34, 18);
    label102.TabIndex = 28;
    label102.Text = "Vce";
    label103.AutoSize = true;
    label103.Location = new Point(351, 36);
    label103.Name = "label124";
    label103.Size = new Size(15, 14);
    label103.TabIndex = 27;
    label103.Text = "V";
    label104.AutoSize = true;
    label104.Location = new Point(351, 8);
    label104.Name = "label125";
    label104.Size = new Size(15, 14);
    label104.TabIndex = 26;
    label104.Text = "V";
    label105.AutoSize = true;
    label105.Location = new Point(280, 36);
    label105.Name = "label126";
    label105.Size = new Size(18, 14);
    label105.TabIndex = 22;
    label105.Text = "To";
    label106.AutoSize = true;
    label106.Location = new Point(267, 8);
    label106.Name = "label127";
    label106.Size = new Size(31 /*0x1F*/, 14);
    label106.TabIndex = 21;
    label106.Text = "From";
    label107.AutoSize = true;
    label107.Location = new Point(257, 64 /*0x40*/);
    label107.Name = "label128";
    label107.Size = new Size(41, 14);
    label107.TabIndex = 20;
    label107.Text = "Traces";
    label108.AutoSize = true;
    label108.Location = new Point(209, 36);
    label108.Name = "label129";
    label108.Size = new Size(15, 14);
    label108.TabIndex = 19;
    label108.Text = "V";
    label109.AutoSize = true;
    label109.Location = new Point(209, 8);
    label109.Name = "label130";
    label109.Size = new Size(15, 14);
    label109.TabIndex = 18;
    label109.Text = "V";
    label110.AutoSize = true;
    label110.Location = new Point(138, 36);
    label110.Name = "label131";
    label110.Size = new Size(18, 14);
    label110.TabIndex = 11;
    label110.Text = "To";
    label111.AutoSize = true;
    label111.Location = new Point(125, 8);
    label111.Name = "label132";
    label111.Size = new Size(31 /*0x1F*/, 14);
    label111.TabIndex = 10;
    label111.Text = "From";
    label112.AutoSize = true;
    label112.Location = new Point(120, 64 /*0x40*/);
    label112.Name = "label133";
    label112.Size = new Size(36, 14);
    label112.TabIndex = 9;
    label112.Text = "Points";
    label113.AutoSize = true;
    label113.Location = new Point(12, 8);
    label113.Name = "label134";
    label113.Size = new Size(39, 14);
    label113.TabIndex = 2;
    label113.Text = "Pinout:";
    label114.AutoSize = true;
    label114.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label114.Location = new Point(178, 34);
    label114.Name = "label24";
    label114.Size = new Size(35, 18);
    label114.TabIndex = 30;
    label114.Text = "Vdd";
    label115.AutoSize = true;
    label115.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label115.Location = new Point(318, 35);
    label115.Name = "label86";
    label115.Size = new Size(34, 18);
    label115.TabIndex = 28;
    label115.Text = "Vgs";
    label116.AutoSize = true;
    label116.Location = new Point(360, 36);
    label116.Name = "label89";
    label116.Size = new Size(18, 14);
    label116.TabIndex = 22;
    label116.Text = "To";
    label117.AutoSize = true;
    label117.Location = new Point(347, 8);
    label117.Name = "label90";
    label117.Size = new Size(31 /*0x1F*/, 14);
    label117.TabIndex = 21;
    label117.Text = "From";
    label118.AutoSize = true;
    label118.Location = new Point(337, 64 /*0x40*/);
    label118.Name = "label91";
    label118.Size = new Size(41, 14);
    label118.TabIndex = 20;
    label118.Text = "Traces";
    label119.AutoSize = true;
    label119.Location = new Point(293, 36);
    label119.Name = "label92";
    label119.Size = new Size(15, 14);
    label119.TabIndex = 19;
    label119.Text = "V";
    label120.AutoSize = true;
    label120.Location = new Point(293, 8);
    label120.Name = "label93";
    label120.Size = new Size(15, 14);
    label120.TabIndex = 18;
    label120.Text = "V";
    label121.AutoSize = true;
    label121.Location = new Point(218, 36);
    label121.Name = "label94";
    label121.Size = new Size(18, 14);
    label121.TabIndex = 11;
    label121.Text = "To";
    label122.AutoSize = true;
    label122.Location = new Point(205, 8);
    label122.Name = "label95";
    label122.Size = new Size(31 /*0x1F*/, 14);
    label122.TabIndex = 10;
    label122.Text = "From";
    label123.AutoSize = true;
    label123.Location = new Point(200, 64 /*0x40*/);
    label123.Name = "label96";
    label123.Size = new Size(36, 14);
    label123.TabIndex = 9;
    label123.Text = "Points";
    label124.AutoSize = true;
    label124.Location = new Point(12, 8);
    label124.Name = "label97";
    label124.Size = new Size(39, 14);
    label124.TabIndex = 55;
    label124.Text = "Pinout:";
    label125.AutoSize = true;
    label125.Location = new Point(360, 36);
    label125.Name = "label28";
    label125.Size = new Size(18, 14);
    label125.TabIndex = 62;
    label125.Text = "To";
    label126.AutoSize = true;
    label126.Location = new Point(347, 8);
    label126.Name = "label41";
    label126.Size = new Size(31 /*0x1F*/, 14);
    label126.TabIndex = 61;
    label126.Text = "From";
    label127.AutoSize = true;
    label127.Location = new Point(337, 64 /*0x40*/);
    label127.Name = "label65";
    label127.Size = new Size(41, 14);
    label127.TabIndex = 60;
    label127.Text = "Traces";
    label128.AutoSize = true;
    label128.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label128.Location = new Point(178, 34);
    label128.Name = "label98";
    label128.Size = new Size(34, 18);
    label128.TabIndex = 30;
    label128.Text = "Vgs";
    label129.AutoSize = true;
    label129.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label129.Location = new Point(318, 35);
    label129.Name = "label100";
    label129.Size = new Size(34, 18);
    label129.TabIndex = 28;
    label129.Text = "Vds";
    label130.AutoSize = true;
    label130.Location = new Point(435, 8);
    label130.Name = "label102";
    label130.Size = new Size(15, 14);
    label130.TabIndex = 26;
    label130.Text = "V";
    label131.AutoSize = true;
    label131.Location = new Point(293, 36);
    label131.Name = "label106";
    label131.Size = new Size(15, 14);
    label131.TabIndex = 19;
    label131.Text = "V";
    label132.AutoSize = true;
    label132.Location = new Point(293, 8);
    label132.Name = "label107";
    label132.Size = new Size(15, 14);
    label132.TabIndex = 18;
    label132.Text = "V";
    label133.AutoSize = true;
    label133.Location = new Point(218, 36);
    label133.Name = "label108";
    label133.Size = new Size(18, 14);
    label133.TabIndex = 11;
    label133.Text = "To";
    label134.AutoSize = true;
    label134.Location = new Point(205, 8);
    label134.Name = "label109";
    label134.Size = new Size(31 /*0x1F*/, 14);
    label134.TabIndex = 10;
    label134.Text = "From";
    label135.AutoSize = true;
    label135.Location = new Point(200, 64 /*0x40*/);
    label135.Name = "label110";
    label135.Size = new Size(36, 14);
    label135.TabIndex = 9;
    label135.Text = "Points";
    label136.AutoSize = true;
    label136.Location = new Point(12, 8);
    label136.Name = "label111";
    label136.Size = new Size(39, 14);
    label136.TabIndex = 2;
    label136.Text = "Pinout:";
    label137.AutoSize = true;
    label137.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    label137.Location = new Point(102, 35);
    label137.Name = "label23";
    label137.Size = new Size(25, 18);
    label137.TabIndex = 3;
    label137.Text = "Vs";
    label138.AutoSize = true;
    label138.Location = new Point(209, 36);
    label138.Name = "label114";
    label138.Size = new Size(15, 14);
    label138.TabIndex = 19;
    label138.Text = "V";
    label139.AutoSize = true;
    label139.Location = new Point(209, 8);
    label139.Name = "label115";
    label139.Size = new Size(15, 14);
    label139.TabIndex = 18;
    label139.Text = "V";
    label140.AutoSize = true;
    label140.Location = new Point(138, 36);
    label140.Name = "label116";
    label140.Size = new Size(18, 14);
    label140.TabIndex = 5;
    label140.Text = "To";
    label141.AutoSize = true;
    label141.Location = new Point(125, 8);
    label141.Name = "label117";
    label141.Size = new Size(31 /*0x1F*/, 14);
    label141.TabIndex = 4;
    label141.Text = "From";
    label142.AutoSize = true;
    label142.Location = new Point(120, 64 /*0x40*/);
    label142.Name = "label118";
    label142.Size = new Size(36, 14);
    label142.TabIndex = 2;
    label142.Text = "Points";
    label143.AutoSize = true;
    label143.Location = new Point(12, 8);
    label143.Name = "label119";
    label143.Size = new Size(39, 14);
    label143.TabIndex = 2;
    label143.Text = "Pinout:";
    this.textGlobalTracePrefix.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.textGlobalTracePrefix.BorderStyle = BorderStyle.FixedSingle;
    this.textGlobalTracePrefix.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textGlobalTracePrefix.Location = new Point(102, 2);
    this.textGlobalTracePrefix.Name = "textGlobalTracePrefix";
    this.textGlobalTracePrefix.Size = new Size(180, 20);
    this.textGlobalTracePrefix.TabIndex = 102;
    this.textGlobalTracePrefix.TextAlign = HorizontalAlignment.Right;
    this.ToolTipFrm.SetToolTip((Control) this.textGlobalTracePrefix, "This text will prefix the next set of traces.A \\'#\\' will be replaced with the number in the # box.");
    this.textGlobalTracePrefix.KeyDown += new KeyEventHandler(this.textGlobalTracePrefix_KeyDown);
    this.tabPNTest.Controls.Add((Control) this.picPNCircuitLarge);
    this.tabPNTest.Controls.Add((Control) this.zedGraphPNJunct);
    this.tabPNTest.Controls.Add((Control) this.panelPNJunction);
    this.tabPNTest.Location = new Point(4, 23);
    this.tabPNTest.Name = "tabPNTest";
    this.tabPNTest.Size = new Size(926, 439);
    this.tabPNTest.TabIndex = 0;
    this.tabPNTest.Tag = (object) "Graph.Types.GRAPH_PN";
    this.tabPNTest.Text = "PN Junction";
    this.tabPNTest.UseVisualStyleBackColor = true;
    this.picPNCircuitLarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.picPNCircuitLarge.BorderStyle = BorderStyle.FixedSingle;
    this.picPNCircuitLarge.Image = (Image) Resources.cct_PN126;
    this.picPNCircuitLarge.InitialImage = (Image) null;
    this.picPNCircuitLarge.Location = new Point(546, 186);
    this.picPNCircuitLarge.Margin = new Padding(0);
    this.picPNCircuitLarge.Name = "picPNCircuitLarge";
    this.picPNCircuitLarge.Size = new Size(349, 128 /*0x80*/);
    this.picPNCircuitLarge.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picPNCircuitLarge.TabIndex = 44;
    this.picPNCircuitLarge.TabStop = false;
    this.picPNCircuitLarge.Tag = (object) "";
    this.picPNCircuitLarge.Visible = false;
    this.picPNCircuitLarge.MouseLeave += new EventHandler(this.picCircuit_MouseLeave);
    ((Control) this.zedGraphPNJunct).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.zedGraphPNJunct.IsAntiAlias = true;
    ((Control) this.zedGraphPNJunct).Location = new Point(3, 3);
    ((Control) this.zedGraphPNJunct).Name = "zedGraphPNJunct";
    this.zedGraphPNJunct.ScrollGrace = 0.0;
    this.zedGraphPNJunct.ScrollMaxX = 0.0;
    this.zedGraphPNJunct.ScrollMaxY = 0.0;
    this.zedGraphPNJunct.ScrollMaxY2 = 0.0;
    this.zedGraphPNJunct.ScrollMinX = 0.0;
    this.zedGraphPNJunct.ScrollMinY = 0.0;
    this.zedGraphPNJunct.ScrollMinY2 = 0.0;
    ((Control) this.zedGraphPNJunct).Size = new Size(920, 280);
    ((Control) this.zedGraphPNJunct).TabIndex = 9;
    this.panelPNJunction.Controls.Add((Control) this.comboPNOther);
    this.panelPNJunction.Controls.Add((Control) label2);
    this.panelPNJunction.Controls.Add((Control) this.comboPNBias);
    this.panelPNJunction.Controls.Add((Control) this.comboPNCathode);
    this.panelPNJunction.Controls.Add((Control) this.comboPNAnode);
    this.panelPNJunction.Controls.Add((Control) label3);
    this.panelPNJunction.Controls.Add((Control) this.label15);
    this.panelPNJunction.Controls.Add((Control) this.label14);
    this.panelPNJunction.Controls.Add((Control) this.TextPNPoints);
    this.panelPNJunction.Controls.Add((Control) this.TextPNVMax);
    this.panelPNJunction.Controls.Add((Control) this.TextPNVMin);
    this.panelPNJunction.Controls.Add((Control) label4);
    this.panelPNJunction.Controls.Add((Control) label5);
    this.panelPNJunction.Controls.Add((Control) label6);
    this.panelPNJunction.Controls.Add((Control) label7);
    this.panelPNJunction.Controls.Add((Control) this.butStartPN);
    this.panelPNJunction.Controls.Add((Control) label8);
    this.panelPNJunction.Controls.Add((Control) label9);
    this.panelPNJunction.Controls.Add((Control) this.picPNCircuitSmall);
    this.panelPNJunction.Dock = DockStyle.Bottom;
    this.panelPNJunction.Location = new Point(0, 347);
    this.panelPNJunction.MinimumSize = new Size(890, 0);
    this.panelPNJunction.Name = "panelPNJunction";
    rectanglePlus1.Color = SystemColors.ControlDark;
    rectanglePlus1.Rectangle = new Rectangle(206, 1, 154, 86);
    this.panelPNJunction.Rectangles = new GraphPanel.RectanglePlus[1]
    {
      rectanglePlus1
    };
    this.panelPNJunction.Size = new Size(926, 92);
    this.panelPNJunction.TabIndex = 37;
    this.comboPNOther.DrawMode = DrawMode.OwnerDrawFixed;
    this.comboPNOther.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboPNOther.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.comboPNOther.Location = new Point(67, 69);
    this.comboPNOther.Name = "comboPNOther";
    this.comboPNOther.Size = new Size(121, 21);
    this.comboPNOther.TabIndex = 8;
    this.comboPNBias.DrawMode = DrawMode.OwnerDrawFixed;
    this.comboPNBias.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboPNBias.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.comboPNBias.FormattingEnabled = true;
    this.comboPNBias.Location = new Point(67, 47);
    this.comboPNBias.Name = "comboPNBias";
    this.comboPNBias.Size = new Size(121, 21);
    this.comboPNBias.TabIndex = 7;
    this.comboPNCathode.DrawMode = DrawMode.OwnerDrawFixed;
    this.comboPNCathode.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboPNCathode.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.comboPNCathode.FormattingEnabled = true;
    this.comboPNCathode.Location = new Point(67, 25);
    this.comboPNCathode.Name = "comboPNCathode";
    this.comboPNCathode.Size = new Size(121, 21);
    this.comboPNCathode.TabIndex = 6;
    this.comboPNAnode.DrawMode = DrawMode.OwnerDrawFixed;
    this.comboPNAnode.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboPNAnode.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.comboPNAnode.Location = new Point(67, 3);
    this.comboPNAnode.Name = "comboPNAnode";
    this.comboPNAnode.Size = new Size(121, 21);
    this.comboPNAnode.TabIndex = 5;
    this.label15.AutoSize = true;
    this.label15.Location = new Point(331, 36);
    this.label15.Name = "label15";
    this.label15.Size = new Size(15, 14);
    this.label15.TabIndex = 19;
    this.label15.Text = "V";
    this.label14.AutoSize = true;
    this.label14.Location = new Point(331, 8);
    this.label14.Name = "label14";
    this.label14.Size = new Size(15, 14);
    this.label14.TabIndex = 18;
    this.label14.Text = "V";
    this.TextPNPoints.BorderStyle = BorderStyle.FixedSingle;
    this.TextPNPoints.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.TextPNPoints.Location = new Point(281, 62);
    this.TextPNPoints.Name = "TextPNPoints";
    this.TextPNPoints.Size = new Size(46, 20);
    this.TextPNPoints.TabIndex = 3;
    this.TextPNPoints.Text = "unset";
    this.TextPNPoints.TextAlign = HorizontalAlignment.Right;
    this.TextPNPoints.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.TextPNVMax.BorderStyle = BorderStyle.FixedSingle;
    this.TextPNVMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.TextPNVMax.Location = new Point(281, 34);
    this.TextPNVMax.Name = "TextPNVMax";
    this.TextPNVMax.Size = new Size(46, 20);
    this.TextPNVMax.TabIndex = 2;
    this.TextPNVMax.Text = "unset";
    this.TextPNVMax.TextAlign = HorizontalAlignment.Right;
    this.TextPNVMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.TextPNVMin.BorderStyle = BorderStyle.FixedSingle;
    this.TextPNVMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.TextPNVMin.Location = new Point(281, 6);
    this.TextPNVMin.Name = "TextPNVMin";
    this.TextPNVMin.Size = new Size(46, 20);
    this.TextPNVMin.TabIndex = 1;
    this.TextPNVMin.Text = "unset";
    this.TextPNVMin.TextAlign = HorizontalAlignment.Right;
    this.TextPNVMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.butStartPN.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.butStartPN.Location = new Point(371, 59);
    this.butStartPN.Name = "butStartPN";
    this.butStartPN.Size = new Size(75, 23);
    this.butStartPN.TabIndex = 4;
    this.butStartPN.Text = "Start";
    this.butStartPN.UseVisualStyleBackColor = true;
    this.picPNCircuitSmall.Cursor = Cursors.Hand;
    this.picPNCircuitSmall.Dock = DockStyle.Right;
    this.picPNCircuitSmall.Image = (Image) Resources.cct_PN86;
    this.picPNCircuitSmall.InitialImage = (Image) null;
    this.picPNCircuitSmall.Location = new Point(689, 0);
    this.picPNCircuitSmall.Margin = new Padding(0);
    this.picPNCircuitSmall.Name = "picPNCircuitSmall";
    this.picPNCircuitSmall.Size = new Size(237, 92);
    this.picPNCircuitSmall.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picPNCircuitSmall.TabIndex = 45;
    this.picPNCircuitSmall.TabStop = false;
    this.picPNCircuitSmall.Tag = (object) "picPNCircuitLarge";
    this.picPNCircuitSmall.Click += new EventHandler(this.picCircuit_Click);
    this.tabIdentify.Controls.Add((Control) this.myPanelResults);
    this.tabIdentify.Controls.Add((Control) this.buttonIdentify);
    this.tabIdentify.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.tabIdentify.Location = new Point(4, 23);
    this.tabIdentify.Name = "tabIdentify";
    this.tabIdentify.Size = new Size(926, 439);
    this.tabIdentify.TabIndex = 4;
    this.tabIdentify.Text = "Identify";
    this.tabIdentify.UseVisualStyleBackColor = true;
    this.myPanelResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.myPanelResults.AutoSizeMode = AutoSizeMode.GrowAndShrink;
    this.myPanelResults.BackColor = SystemColors.Window;
    this.myPanelResults.Controls.Add((Control) this.rtextIdentifyResults);
    this.myPanelResults.Controls.Add((Control) this.textComments);
    this.myPanelResults.Controls.Add((Control) this.panel2);
    this.myPanelResults.Location = new Point(0, 49);
    this.myPanelResults.Name = "myPanelResults";
    this.myPanelResults.Size = new Size(926, 391);
    this.myPanelResults.TabIndex = 43;
    this.rtextIdentifyResults.BackColor = SystemColors.Control;
    this.rtextIdentifyResults.BorderStyle = BorderStyle.None;
    this.rtextIdentifyResults.ContextMenuStrip = this.contextMenuComments;
    this.rtextIdentifyResults.Cursor = Cursors.Default;
    this.rtextIdentifyResults.Location = new Point(0, 0);
    this.rtextIdentifyResults.Name = "rtextIdentifyResults";
    this.rtextIdentifyResults.ReadOnly = true;
    this.rtextIdentifyResults.Size = new Size(300, 300);
    this.rtextIdentifyResults.TabIndex = 44;
    this.rtextIdentifyResults.TabStop = false;
    this.rtextIdentifyResults.Text = "";
    this.contextMenuComments.Items.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.copyToolStripMenuItem
    });
    this.contextMenuComments.Name = "contextMenuComments";
    this.contextMenuComments.Size = new Size(103, 26);
    this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
    this.copyToolStripMenuItem.Size = new Size(102, 22);
    this.copyToolStripMenuItem.Text = "Copy";
    this.copyToolStripMenuItem.Click += new EventHandler(this.copyToolStripMenuItem_Click);
    this.textComments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.textComments.BackColor = SystemColors.Control;
    this.textComments.BorderStyle = BorderStyle.None;
    this.textComments.ContextMenuStrip = this.contextMenuComments;
    this.textComments.Cursor = Cursors.Default;
    this.textComments.Location = new Point(606, 0);
    this.textComments.Name = "textComments";
    this.textComments.ReadOnly = true;
    this.textComments.Size = new Size(313, 388);
    this.textComments.TabIndex = 42;
    this.textComments.TabStop = false;
    this.textComments.Text = "";
    this.panel2.Controls.Add((Control) this.pictureResult);
    this.panel2.Location = new Point(300, 0);
    this.panel2.Name = "panel2";
    this.panel2.Size = new Size(300, 300);
    this.panel2.TabIndex = 43;
    this.pictureResult.BorderStyle = BorderStyle.FixedSingle;
    this.pictureResult.Location = new Point(0, 0);
    this.pictureResult.Margin = new Padding(0);
    this.pictureResult.Name = "pictureResult";
    this.pictureResult.Size = new Size(300, 300);
    this.pictureResult.TabIndex = 40;
    this.pictureResult.TabStop = false;
    this.buttonIdentify.AutoEllipsis = true;
    this.buttonIdentify.BackColor = Color.Transparent;
    this.buttonIdentify.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.buttonIdentify.Location = new Point(8, 12);
    this.buttonIdentify.Name = "buttonIdentify";
    this.buttonIdentify.Size = new Size(89, 31 /*0x1F*/);
    this.buttonIdentify.TabIndex = 0;
    this.buttonIdentify.Text = "Test";
    this.buttonIdentify.UseVisualStyleBackColor = false;
    this.buttonIdentify.Click += new EventHandler(this.buttonIdentify_Click);
    this.timerPulse.Interval = 200;
    this.timerPulse.Tick += new EventHandler(this.timerPulse_Tick);
    this.bgWorkerTest.WorkerReportsProgress = true;
    this.bgWorkerTest.WorkerSupportsCancellation = true;
    this.bgWorkerTest.DoWork += new DoWorkEventHandler(this.bgWorkerTest_DoWork);
    this.bgWorkerTest.ProgressChanged += new ProgressChangedEventHandler(this.bgWorkerTest_ProgressChanged);
    this.bgWorkerTest.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgWorkerTest_Complete);
    this.menuStripMain.Dock = DockStyle.None;
    this.menuStripMain.Items.AddRange(new ToolStripItem[4]
    {
      (ToolStripItem) this.DCAProToolStripMenuItem,
      (ToolStripItem) this.dataToolStripMenuItem,
      (ToolStripItem) this.graphsToolStripMenuItem,
      (ToolStripItem) this.helpToolStripMenuItem
    });
    this.menuStripMain.Location = new Point(0, 0);
    this.menuStripMain.Name = "menuStripMain";
    this.menuStripMain.Size = new Size(210, 24);
    this.menuStripMain.TabIndex = 36;
    this.menuStripMain.Text = "menuStrip3";
    this.DCAProToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
    {
      (ToolStripItem) this.programFirmwareToolStripMenuItem,
      (ToolStripItem) this.LCDToolStripMenuItem,
      (ToolStripItem) this.exitToolStripMenuItem
    });
    this.DCAProToolStripMenuItem.Name = "DCAProToolStripMenuItem";
    this.DCAProToolStripMenuItem.Size = new Size(64 /*0x40*/, 20);
    this.DCAProToolStripMenuItem.Text = "DCA Pro";
    this.programFirmwareToolStripMenuItem.Enabled = false;
    this.programFirmwareToolStripMenuItem.Name = "programFirmwareToolStripMenuItem";
    this.programFirmwareToolStripMenuItem.Size = new Size(172, 22);
    this.programFirmwareToolStripMenuItem.Text = "Program Firmware";
    this.programFirmwareToolStripMenuItem.Click += new EventHandler(this.programFirmwareToolStripMenuItem_Click);
    this.LCDToolStripMenuItem.Enabled = false;
    this.LCDToolStripMenuItem.Name = "LCDToolStripMenuItem";
    this.LCDToolStripMenuItem.Size = new Size(172, 22);
    this.LCDToolStripMenuItem.Text = "LCD Contrast";
    this.LCDToolStripMenuItem.Click += new EventHandler(this.utilitiesToolStripMenuItem_Click);
    this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
    this.exitToolStripMenuItem.Size = new Size(172, 22);
    this.exitToolStripMenuItem.Text = "Exit";
    this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
    this.dataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
    {
      (ToolStripItem) this.menuDataLoadData,
      (ToolStripItem) this.menuDataSaveData,
      (ToolStripItem) this.menuDataCopyData
    });
    this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
    this.dataToolStripMenuItem.Size = new Size(43, 20);
    this.dataToolStripMenuItem.Text = "Data";
    this.menuDataLoadData.Name = "menuDataLoadData";
    this.menuDataLoadData.Size = new Size(164, 22);
    this.menuDataLoadData.Text = "Load Graph Data";
    this.menuDataLoadData.Click += new EventHandler(this.MenuLoadData_Click);
    this.menuDataSaveData.Name = "menuDataSaveData";
    this.menuDataSaveData.Size = new Size(164, 22);
    this.menuDataSaveData.Text = "Save Graph Data";
    this.menuDataSaveData.Click += new EventHandler(this.MenuSaveData_Click);
    this.menuDataCopyData.Name = "menuDataCopyData";
    this.menuDataCopyData.Size = new Size(164, 22);
    this.menuDataCopyData.Text = "Copy Graph Data";
    this.menuDataCopyData.Click += new EventHandler(this.MenuCopyData_Click);
    this.graphsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[13]
    {
      (ToolStripItem) this.selectGraphsTSMI,
      (ToolStripItem) this.toolStripSeparator2,
      (ToolStripItem) this.renameGraphTSMI,
      (ToolStripItem) this.copyImageTSMI,
      (ToolStripItem) this.pageSetupTSMI,
      (ToolStripItem) this.printPreviewTSMI,
      (ToolStripItem) this.printTSMI,
      (ToolStripItem) this.deleteTSMI,
      (ToolStripItem) this.unlockTSMI,
      (ToolStripItem) this.hideLegendTSMI,
      (ToolStripItem) this.toolStripSeparator3,
      (ToolStripItem) this.fontSizeTSMI,
      (ToolStripItem) this.fontSizeTSMI1
    });
    this.graphsToolStripMenuItem.Name = "graphsToolStripMenuItem";
    this.graphsToolStripMenuItem.Size = new Size(51, 20);
    this.graphsToolStripMenuItem.Text = "Graph";
    this.selectGraphsTSMI.DropDownItems.AddRange(new ToolStripItem[23]
    {
      (ToolStripItem) this.PNJunctMenuItem,
      (ToolStripItem) this.toolStripSeparator4,
      (ToolStripItem) this.BJTMenuCategory,
      (ToolStripItem) this.IcVceBJTMenuSubItem,
      (ToolStripItem) this.HfeVceBJTMenuSubItem,
      (ToolStripItem) this.HfeIcBJTMenuSubItem,
      (ToolStripItem) this.IcVbeBJTMenuSubItem,
      (ToolStripItem) this.IcIbBJTMenuSubItem,
      (ToolStripItem) this.toolStripSeparator5,
      (ToolStripItem) this.MOSFETMenuCategory,
      (ToolStripItem) this.IdVdsMOSFETMenuSubItem,
      (ToolStripItem) this.IdVgsMOSFETMenuSubItem,
      (ToolStripItem) this.toolStripSeparator6,
      (ToolStripItem) this.IGBTMenuCategory,
      (ToolStripItem) this.IcVceIGBTMenuSubItem,
      (ToolStripItem) this.IcVgeIGBTMenuSubItem,
      (ToolStripItem) this.toolStripSeparator1,
      (ToolStripItem) this.JFETMenuCategory,
      (ToolStripItem) this.IdVdsJFETMenuSubItem,
      (ToolStripItem) this.IdVgsJFETMenuSubItem,
      (ToolStripItem) this.toolStripSeparator8,
      (ToolStripItem) this.VRegMenuCategory,
      (ToolStripItem) this.VoutVinVRegMenuSubItem
    });
    this.selectGraphsTSMI.Name = "selectGraphsTSMI";
    this.selectGraphsTSMI.Size = new Size(175, 22);
    this.selectGraphsTSMI.Text = "Select Graphs";
    this.PNJunctMenuItem.Name = "PNJunctMenuItem";
    this.PNJunctMenuItem.Size = new Size(193, 22);
    this.PNJunctMenuItem.Text = "PN Junction";
    this.PNJunctMenuItem.Click += new EventHandler(this.MenuTestsItem_Click);
    this.PNJunctMenuItem.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.PNJunctMenuItem.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.toolStripSeparator4.Name = "toolStripSeparator4";
    this.toolStripSeparator4.Size = new Size(190, 6);
    this.BJTMenuCategory.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
    this.BJTMenuCategory.Name = "BJTMenuCategory";
    this.BJTMenuCategory.Size = new Size(193, 22);
    this.BJTMenuCategory.Tag = (object) "BJT";
    this.BJTMenuCategory.Text = "BJT:";
    this.BJTMenuCategory.Click += new EventHandler(this.MenuTestCategory_Click);
    this.BJTMenuCategory.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.BJTMenuCategory.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.IcVceBJTMenuSubItem.Name = "IcVceBJTMenuSubItem";
    this.IcVceBJTMenuSubItem.Size = new Size(193, 22);
    this.IcVceBJTMenuSubItem.Tag = (object) "BJT";
    this.IcVceBJTMenuSubItem.Text = "Ic / Vce";
    this.IcVceBJTMenuSubItem.Click += new EventHandler(this.MenuTestsItem_Click);
    this.IcVceBJTMenuSubItem.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.IcVceBJTMenuSubItem.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.HfeVceBJTMenuSubItem.Name = "HfeVceBJTMenuSubItem";
    this.HfeVceBJTMenuSubItem.Size = new Size(193, 22);
    this.HfeVceBJTMenuSubItem.Tag = (object) "BJT";
    this.HfeVceBJTMenuSubItem.Text = "hFE / Vce";
    this.HfeVceBJTMenuSubItem.Click += new EventHandler(this.MenuTestsItem_Click);
    this.HfeVceBJTMenuSubItem.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.HfeVceBJTMenuSubItem.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.HfeIcBJTMenuSubItem.Name = "HfeIcBJTMenuSubItem";
    this.HfeIcBJTMenuSubItem.Size = new Size(193, 22);
    this.HfeIcBJTMenuSubItem.Tag = (object) "BJT";
    this.HfeIcBJTMenuSubItem.Text = "hFE / Ic";
    this.HfeIcBJTMenuSubItem.Click += new EventHandler(this.MenuTestsItem_Click);
    this.HfeIcBJTMenuSubItem.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.HfeIcBJTMenuSubItem.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.IcVbeBJTMenuSubItem.Name = "IcVbeBJTMenuSubItem";
    this.IcVbeBJTMenuSubItem.Size = new Size(193, 22);
    this.IcVbeBJTMenuSubItem.Tag = (object) "BJT";
    this.IcVbeBJTMenuSubItem.Text = "Ic / Vbe";
    this.IcVbeBJTMenuSubItem.Click += new EventHandler(this.MenuTestsItem_Click);
    this.IcVbeBJTMenuSubItem.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.IcVbeBJTMenuSubItem.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.IcIbBJTMenuSubItem.Name = "IcIbBJTMenuSubItem";
    this.IcIbBJTMenuSubItem.Size = new Size(193, 22);
    this.IcIbBJTMenuSubItem.Tag = (object) "BJT";
    this.IcIbBJTMenuSubItem.Text = "Ic / Ib";
    this.IcIbBJTMenuSubItem.Click += new EventHandler(this.MenuTestsItem_Click);
    this.IcIbBJTMenuSubItem.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.IcIbBJTMenuSubItem.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.toolStripSeparator5.Name = "toolStripSeparator5";
    this.toolStripSeparator5.Size = new Size(190, 6);
    this.MOSFETMenuCategory.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
    this.MOSFETMenuCategory.Name = "MOSFETMenuCategory";
    this.MOSFETMenuCategory.Size = new Size(193, 22);
    this.MOSFETMenuCategory.Tag = (object) "MOSFET";
    this.MOSFETMenuCategory.Text = "MOSFET:";
    this.MOSFETMenuCategory.Click += new EventHandler(this.MenuTestCategory_Click);
    this.MOSFETMenuCategory.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.MOSFETMenuCategory.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.IdVdsMOSFETMenuSubItem.Name = "IdVdsMOSFETMenuSubItem";
    this.IdVdsMOSFETMenuSubItem.Size = new Size(193, 22);
    this.IdVdsMOSFETMenuSubItem.Tag = (object) "MOSFET";
    this.IdVdsMOSFETMenuSubItem.Text = "Id / Vds";
    this.IdVdsMOSFETMenuSubItem.Click += new EventHandler(this.MenuTestsItem_Click);
    this.IdVdsMOSFETMenuSubItem.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.IdVdsMOSFETMenuSubItem.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.IdVgsMOSFETMenuSubItem.Name = "IdVgsMOSFETMenuSubItem";
    this.IdVgsMOSFETMenuSubItem.Size = new Size(193, 22);
    this.IdVgsMOSFETMenuSubItem.Tag = (object) "MOSFET";
    this.IdVgsMOSFETMenuSubItem.Text = "Id / Vgs";
    this.IdVgsMOSFETMenuSubItem.Click += new EventHandler(this.MenuTestsItem_Click);
    this.IdVgsMOSFETMenuSubItem.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.IdVgsMOSFETMenuSubItem.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.toolStripSeparator6.Name = "toolStripSeparator6";
    this.toolStripSeparator6.Size = new Size(190, 6);
    this.IGBTMenuCategory.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
    this.IGBTMenuCategory.Name = "IGBTMenuCategory";
    this.IGBTMenuCategory.Size = new Size(193, 22);
    this.IGBTMenuCategory.Tag = (object) "IGBT";
    this.IGBTMenuCategory.Text = "IGBT:";
    this.IGBTMenuCategory.Click += new EventHandler(this.MenuTestCategory_Click);
    this.IGBTMenuCategory.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.IGBTMenuCategory.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.IcVceIGBTMenuSubItem.Name = "IcVceIGBTMenuSubItem";
    this.IcVceIGBTMenuSubItem.Size = new Size(193, 22);
    this.IcVceIGBTMenuSubItem.Tag = (object) "IGBT";
    this.IcVceIGBTMenuSubItem.Text = "Ic / Vce";
    this.IcVceIGBTMenuSubItem.Click += new EventHandler(this.MenuTestsItem_Click);
    this.IcVceIGBTMenuSubItem.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.IcVceIGBTMenuSubItem.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.IcVgeIGBTMenuSubItem.Name = "IcVgeIGBTMenuSubItem";
    this.IcVgeIGBTMenuSubItem.Size = new Size(193, 22);
    this.IcVgeIGBTMenuSubItem.Tag = (object) "IGBT";
    this.IcVgeIGBTMenuSubItem.Text = "Ic / Vge";
    this.IcVgeIGBTMenuSubItem.Click += new EventHandler(this.MenuTestsItem_Click);
    this.IcVgeIGBTMenuSubItem.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.IcVgeIGBTMenuSubItem.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.toolStripSeparator1.Name = "toolStripSeparator1";
    this.toolStripSeparator1.Size = new Size(190, 6);
    this.JFETMenuCategory.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
    this.JFETMenuCategory.Name = "JFETMenuCategory";
    this.JFETMenuCategory.Size = new Size(193, 22);
    this.JFETMenuCategory.Tag = (object) "JFET";
    this.JFETMenuCategory.Text = "JFET:";
    this.JFETMenuCategory.Click += new EventHandler(this.MenuTestCategory_Click);
    this.JFETMenuCategory.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.JFETMenuCategory.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.IdVdsJFETMenuSubItem.Name = "IdVdsJFETMenuSubItem";
    this.IdVdsJFETMenuSubItem.Size = new Size(193, 22);
    this.IdVdsJFETMenuSubItem.Tag = (object) "JFET";
    this.IdVdsJFETMenuSubItem.Text = "Id / Vds";
    this.IdVdsJFETMenuSubItem.Click += new EventHandler(this.MenuTestsItem_Click);
    this.IdVdsJFETMenuSubItem.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.IdVdsJFETMenuSubItem.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.IdVgsJFETMenuSubItem.Name = "IdVgsJFETMenuSubItem";
    this.IdVgsJFETMenuSubItem.Size = new Size(193, 22);
    this.IdVgsJFETMenuSubItem.Tag = (object) "JFET";
    this.IdVgsJFETMenuSubItem.Text = "Id / Vgs";
    this.IdVgsJFETMenuSubItem.Click += new EventHandler(this.MenuTestsItem_Click);
    this.IdVgsJFETMenuSubItem.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.IdVgsJFETMenuSubItem.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.toolStripSeparator8.Name = "toolStripSeparator8";
    this.toolStripSeparator8.Size = new Size(190, 6);
    this.VRegMenuCategory.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.VRegMenuCategory.Name = "VRegMenuCategory";
    this.VRegMenuCategory.Size = new Size(193, 22);
    this.VRegMenuCategory.Tag = (object) "VReg";
    this.VRegMenuCategory.Text = "Voltage Regulator:";
    this.VRegMenuCategory.Click += new EventHandler(this.MenuTestCategory_Click);
    this.VRegMenuCategory.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.VRegMenuCategory.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.VoutVinVRegMenuSubItem.Name = "VoutVinVRegMenuSubItem";
    this.VoutVinVRegMenuSubItem.Size = new Size(193, 22);
    this.VoutVinVRegMenuSubItem.Tag = (object) "VReg";
    this.VoutVinVRegMenuSubItem.Text = "Vout && Iq / Vin";
    this.VoutVinVRegMenuSubItem.Click += new EventHandler(this.MenuTestsItem_Click);
    this.VoutVinVRegMenuSubItem.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.VoutVinVRegMenuSubItem.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.toolStripSeparator2.Name = "toolStripSeparator2";
    this.toolStripSeparator2.Size = new Size(172, 6);
    this.renameGraphTSMI.DropDownItems.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.resetDefaultGraphNameTSMI
    });
    this.renameGraphTSMI.Name = "renameGraphTSMI";
    this.renameGraphTSMI.Size = new Size(175, 22);
    this.renameGraphTSMI.Text = "Rename";
    this.renameGraphTSMI.Click += new EventHandler(this.renameGraphTSMI_Click);
    this.resetDefaultGraphNameTSMI.Name = "resetDefaultGraphNameTSMI";
    this.resetDefaultGraphNameTSMI.Size = new Size(156, 22);
    this.resetDefaultGraphNameTSMI.Text = "Reset to default";
    this.resetDefaultGraphNameTSMI.Click += new EventHandler(this.resetDefaultGraphNameTSMI_Click);
    this.copyImageTSMI.Name = "copyImageTSMI";
    this.copyImageTSMI.Size = new Size(175, 22);
    this.copyImageTSMI.Text = "Copy Image";
    this.copyImageTSMI.Click += new EventHandler(this.copyImageMenuItem_Click);
    this.pageSetupTSMI.Enabled = false;
    this.pageSetupTSMI.Name = "pageSetupTSMI";
    this.pageSetupTSMI.Size = new Size(175, 22);
    this.pageSetupTSMI.Text = "Page Setup";
    this.pageSetupTSMI.Click += new EventHandler(this.pageSetupMenuItem_Click);
    this.printPreviewTSMI.Name = "printPreviewTSMI";
    this.printPreviewTSMI.Size = new Size(175, 22);
    this.printPreviewTSMI.Text = "Print preview";
    this.printPreviewTSMI.Click += new EventHandler(this.printPreviewMenuItem_Click);
    this.printTSMI.Name = "printTSMI";
    this.printTSMI.Size = new Size(175, 22);
    this.printTSMI.Text = "Print";
    this.printTSMI.Click += new EventHandler(this.printMenuItem_Click);
    this.deleteTSMI.DropDownItems.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.deleteAllTracesTSMI,
      (ToolStripItem) this.deleteAllAllTracesTSMI
    });
    this.deleteTSMI.Name = "deleteTSMI";
    this.deleteTSMI.Size = new Size(175, 22);
    this.deleteTSMI.Text = "Delete";
    this.deleteAllTracesTSMI.Name = "deleteAllTracesTSMI";
    this.deleteAllTracesTSMI.Size = new Size(193, 22);
    this.deleteAllTracesTSMI.Text = "All traces";
    this.deleteAllTracesTSMI.Click += new EventHandler(this.deleteAllTracesTSMI_Click);
    this.deleteAllAllTracesTSMI.Name = "deleteAllAllTracesTSMI";
    this.deleteAllAllTracesTSMI.Size = new Size(193, 22);
    this.deleteAllAllTracesTSMI.Text = "All traces on all graphs";
    this.deleteAllAllTracesTSMI.Click += new EventHandler(this.deleteAllAllTracesTSMI_Click);
    this.unlockTSMI.DropDownItems.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.unlockAllTSMI,
      (ToolStripItem) this.unlockAllAllTSMI
    });
    this.unlockTSMI.Name = "unlockTSMI";
    this.unlockTSMI.Size = new Size(175, 22);
    this.unlockTSMI.Text = "Unlock";
    this.unlockAllTSMI.DisplayStyle = ToolStripItemDisplayStyle.Text;
    this.unlockAllTSMI.Name = "unlockAllTSMI";
    this.unlockAllTSMI.Size = new Size(193, 22);
    this.unlockAllTSMI.Text = "All traces";
    this.unlockAllTSMI.Click += new EventHandler(this.unlockAllTSMI_Click);
    this.unlockAllAllTSMI.DisplayStyle = ToolStripItemDisplayStyle.Text;
    this.unlockAllAllTSMI.Name = "unlockAllAllTSMI";
    this.unlockAllAllTSMI.Size = new Size(193, 22);
    this.unlockAllAllTSMI.Text = "All traces on all graphs";
    this.unlockAllAllTSMI.Click += new EventHandler(this.unlockAllAllTSMI_Click);
    this.hideLegendTSMI.Name = "hideLegendTSMI";
    this.hideLegendTSMI.Size = new Size(175, 22);
    this.hideLegendTSMI.Text = "Hide/Show Legend";
    this.hideLegendTSMI.Click += new EventHandler(this.hideLegendMenuItem_Click);
    this.toolStripSeparator3.Name = "toolStripSeparator3";
    this.toolStripSeparator3.Size = new Size(172, 6);
    this.fontSizeTSMI.Name = "fontSizeTSMI";
    this.fontSizeTSMI.Size = new Size(175, 22);
    this.fontSizeTSMI.Text = "Font Sizes +";
    this.fontSizeTSMI.Click += new EventHandler(this.fontSizeMenuItemInc_Click);
    this.fontSizeTSMI.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.fontSizeTSMI.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.fontSizeTSMI1.Name = "fontSizeTSMI1";
    this.fontSizeTSMI1.Size = new Size(175, 22);
    this.fontSizeTSMI1.Text = "Font Sizes -";
    this.fontSizeTSMI1.Click += new EventHandler(this.fontSizeMenuItemDec_Click);
    this.fontSizeTSMI1.MouseEnter += new EventHandler(this.MenuItem_Lock);
    this.fontSizeTSMI1.MouseLeave += new EventHandler(this.MenuItem_Unlock);
    this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.MenuCheckForUpdates,
      (ToolStripItem) this.aboutToolStripMenuItem
    });
    this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
    this.helpToolStripMenuItem.Size = new Size(44, 20);
    this.helpToolStripMenuItem.Text = "Help";
    this.MenuCheckForUpdates.DropDownItems.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.MenuCheckForUpdatesAutomatically,
      (ToolStripItem) this.MenuCheckForUpdatesNow
    });
    this.MenuCheckForUpdates.Name = "MenuCheckForUpdates";
    this.MenuCheckForUpdates.Size = new Size(179, 22);
    this.MenuCheckForUpdates.Text = "Check for updates...";
    this.MenuCheckForUpdatesAutomatically.Name = "MenuCheckForUpdatesAutomatically";
    this.MenuCheckForUpdatesAutomatically.Size = new Size(148, 22);
    this.MenuCheckForUpdatesAutomatically.Text = "Automatically";
    this.MenuCheckForUpdatesAutomatically.Click += new EventHandler(this.MenuCheckForUpdatesAutomatically_Click);
    this.MenuCheckForUpdatesNow.Name = "MenuCheckForUpdatesNow";
    this.MenuCheckForUpdatesNow.Size = new Size(148, 22);
    this.MenuCheckForUpdatesNow.Text = "Check now";
    this.MenuCheckForUpdatesNow.Click += new EventHandler(this.checkForUpdatesNow_Click);
    this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
    this.aboutToolStripMenuItem.Size = new Size(179, 22);
    this.aboutToolStripMenuItem.Text = "About";
    this.aboutToolStripMenuItem.Click += new EventHandler(this.aboutToolStripMenuItem_Click);
    this.openHEXFileDialog.DefaultExt = "hex";
    this.openHEXFileDialog.FileName = "*.hex";
    this.openHEXFileDialog.Filter = "HEX files|*.hex";
    this.openHEXFileDialog.InitialDirectory = ".";
    this.openHEXFileDialog.Title = "Open HEX file";
    this.timerDisplay.Interval = 50;
    this.timerDisplay.Tick += new EventHandler(this.timerDisplay_Tick);
    this.toolStripStatusLabelDevice.AutoSize = false;
    this.toolStripStatusLabelDevice.BackColor = Color.DarkRed;
    this.toolStripStatusLabelDevice.ForeColor = SystemColors.Info;
    this.toolStripStatusLabelDevice.Name = "toolStripStatusLabelDevice";
    this.toolStripStatusLabelDevice.Size = new Size(150, 17);
    this.toolStripStatusLabelDevice.Text = "DCA Pro disconnected";
    this.toolStripStatusLabelDevice.TextAlign = ContentAlignment.MiddleLeft;
    this.toolStripProgressBar.ForeColor = Color.LimeGreen;
    this.toolStripProgressBar.Name = "toolStripProgressBar";
    this.toolStripProgressBar.Size = new Size(300, 16 /*0x10*/);
    this.toolStripProgressBar.Style = ProgressBarStyle.Continuous;
    this.toolStripProgressLabel.Name = "toolStripProgressLabel";
    this.toolStripProgressLabel.Size = new Size(125, 17);
    this.toolStripProgressLabel.Text = "toolStripProgressLabel";
    this.toolStripStatusError.Name = "toolStripStatusError";
    this.toolStripStatusError.Size = new Size(109, 17);
    this.toolStripStatusError.Text = "toolStripStatusError";
    this.toolStripStatusError.Visible = false;
    this.toolStripState.Name = "toolStripState";
    this.toolStripState.Size = new Size(78, 17);
    this.toolStripState.Text = "toolStripState";
    this.toolStripState.Visible = false;
    this.toolStripIdentify.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.toolStripIdentify.Name = "toolStripIdentify";
    this.toolStripIdentify.Padding = new Padding(0, 0, 5, 0);
    this.toolStripIdentify.Size = new Size(86, 17);
    this.toolStripIdentify.Text = "Component";
    this.toolStripIdentify.TextAlign = ContentAlignment.MiddleRight;
    this.statusStrip1.Items.AddRange(new ToolStripItem[6]
    {
      (ToolStripItem) this.toolStripStatusLabelDevice,
      (ToolStripItem) this.toolStripProgressBar,
      (ToolStripItem) this.toolStripProgressLabel,
      (ToolStripItem) this.toolStripStatusError,
      (ToolStripItem) this.toolStripState,
      (ToolStripItem) this.toolStripIdentify
    });
    this.statusStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
    this.statusStrip1.Location = new Point(0, 490);
    this.statusStrip1.Name = "statusStrip1";
    this.statusStrip1.Size = new Size(934, 22);
    this.statusStrip1.TabIndex = 32 /*0x20*/;
    this.statusStrip1.Text = "statusStrip1";
    this.tabVRegTest.Controls.Add((Control) this.picVRegVoViLarge);
    this.tabVRegTest.Controls.Add((Control) this.zedGraphVRegVoVi);
    this.tabVRegTest.Controls.Add((Control) this.panelVRegVoutVin);
    this.tabVRegTest.Location = new Point(4, 22);
    this.tabVRegTest.Name = "tabVRegTest";
    this.tabVRegTest.Size = new Size(926, 440);
    this.tabVRegTest.TabIndex = 8;
    this.tabVRegTest.Text = "VReg Vout & Iq / Vin";
    this.tabVRegTest.UseVisualStyleBackColor = true;
    this.picVRegVoViLarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.picVRegVoViLarge.BorderStyle = BorderStyle.FixedSingle;
    this.picVRegVoViLarge.Image = (Image) Resources.cct_VREG126;
    this.picVRegVoViLarge.InitialImage = (Image) null;
    this.picVRegVoViLarge.Location = new Point(584, 188);
    this.picVRegVoViLarge.Margin = new Padding(0);
    this.picVRegVoViLarge.Name = "picVRegVoViLarge";
    this.picVRegVoViLarge.Size = new Size(349, 128 /*0x80*/);
    this.picVRegVoViLarge.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picVRegVoViLarge.TabIndex = 54;
    this.picVRegVoViLarge.TabStop = false;
    this.picVRegVoViLarge.Tag = (object) "";
    this.picVRegVoViLarge.Visible = false;
    this.picVRegVoViLarge.MouseLeave += new EventHandler(this.picCircuit_MouseLeave);
    ((Control) this.zedGraphVRegVoVi).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.zedGraphVRegVoVi.IsAntiAlias = true;
    ((Control) this.zedGraphVRegVoVi).Location = new Point(0, 0);
    ((Control) this.zedGraphVRegVoVi).Name = "zedGraphVRegVoVi";
    this.zedGraphVRegVoVi.ScrollGrace = 0.0;
    this.zedGraphVRegVoVi.ScrollMaxX = 0.0;
    this.zedGraphVRegVoVi.ScrollMaxY = 0.0;
    this.zedGraphVRegVoVi.ScrollMaxY2 = 0.0;
    this.zedGraphVRegVoVi.ScrollMinX = 0.0;
    this.zedGraphVRegVoVi.ScrollMinY = 0.0;
    this.zedGraphVRegVoVi.ScrollMinY2 = 0.0;
    ((Control) this.zedGraphVRegVoVi).Size = new Size(846, 302);
    ((Control) this.zedGraphVRegVoVi).TabIndex = 4;
    this.panelVRegVoutVin.Controls.Add((Control) this.rtextVRegVoViConfig);
    this.panelVRegVoutVin.Controls.Add((Control) label137);
    this.panelVRegVoutVin.Controls.Add((Control) label138);
    this.panelVRegVoutVin.Controls.Add((Control) label139);
    this.panelVRegVoutVin.Controls.Add((Control) this.textVRegVoViPoints);
    this.panelVRegVoutVin.Controls.Add((Control) this.textVRegVoViViMax);
    this.panelVRegVoutVin.Controls.Add((Control) this.textVRegVoViViMin);
    this.panelVRegVoutVin.Controls.Add((Control) label140);
    this.panelVRegVoutVin.Controls.Add((Control) label141);
    this.panelVRegVoutVin.Controls.Add((Control) label142);
    this.panelVRegVoutVin.Controls.Add((Control) this.butStartVRegVoVi);
    this.panelVRegVoutVin.Controls.Add((Control) label143);
    this.panelVRegVoutVin.Controls.Add((Control) this.picVRegVoViSmall);
    this.panelVRegVoutVin.Dock = DockStyle.Bottom;
    this.panelVRegVoutVin.Location = new Point(0, 348);
    this.panelVRegVoutVin.MinimumSize = new Size(890, 0);
    this.panelVRegVoutVin.Name = "panelVRegVoutVin";
    rectanglePlus2.Color = SystemColors.ControlDark;
    rectanglePlus2.Rectangle = new Rectangle(84, 1, 154, 86);
    this.panelVRegVoutVin.Rectangles = new GraphPanel.RectanglePlus[1]
    {
      rectanglePlus2
    };
    this.panelVRegVoutVin.Size = new Size(926, 92);
    this.panelVRegVoutVin.TabIndex = 44;
    this.rtextVRegVoViConfig.BackColor = SystemColors.Window;
    this.rtextVRegVoViConfig.BorderStyle = BorderStyle.None;
    this.rtextVRegVoViConfig.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.rtextVRegVoViConfig.Location = new Point(14, 22);
    this.rtextVRegVoViConfig.Name = "rtextVRegVoViConfig";
    this.rtextVRegVoViConfig.ReadOnly = true;
    this.rtextVRegVoViConfig.Size = new Size(64 /*0x40*/, 58);
    this.rtextVRegVoViConfig.TabIndex = 118;
    this.rtextVRegVoViConfig.TabStop = false;
    this.rtextVRegVoViConfig.Text = "Unknown";
    this.textVRegVoViPoints.BorderStyle = BorderStyle.FixedSingle;
    this.textVRegVoViPoints.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textVRegVoViPoints.Location = new Point(159, 62);
    this.textVRegVoViPoints.Name = "textVRegVoViPoints";
    this.textVRegVoViPoints.Size = new Size(46, 20);
    this.textVRegVoViPoints.TabIndex = 2;
    this.textVRegVoViPoints.Tag = (object) "Parameter";
    this.textVRegVoViPoints.Text = "unset";
    this.textVRegVoViPoints.TextAlign = HorizontalAlignment.Right;
    this.textVRegVoViPoints.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textVRegVoViViMax.BorderStyle = BorderStyle.FixedSingle;
    this.textVRegVoViViMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textVRegVoViViMax.Location = new Point(159, 34);
    this.textVRegVoViViMax.Name = "textVRegVoViViMax";
    this.textVRegVoViViMax.Size = new Size(46, 20);
    this.textVRegVoViViMax.TabIndex = 1;
    this.textVRegVoViViMax.Tag = (object) "Parameter";
    this.textVRegVoViViMax.Text = "unset";
    this.textVRegVoViViMax.TextAlign = HorizontalAlignment.Right;
    this.textVRegVoViViMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textVRegVoViViMin.BorderStyle = BorderStyle.FixedSingle;
    this.textVRegVoViViMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textVRegVoViViMin.Location = new Point(159, 6);
    this.textVRegVoViViMin.Name = "textVRegVoViViMin";
    this.textVRegVoViViMin.Size = new Size(46, 20);
    this.textVRegVoViViMin.TabIndex = 0;
    this.textVRegVoViViMin.Tag = (object) "Parameter";
    this.textVRegVoViViMin.Text = "unset";
    this.textVRegVoViViMin.TextAlign = HorizontalAlignment.Right;
    this.textVRegVoViViMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.butStartVRegVoVi.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.butStartVRegVoVi.Location = new Point(249, 59);
    this.butStartVRegVoVi.Name = "butStartVRegVoVi";
    this.butStartVRegVoVi.Size = new Size(75, 23);
    this.butStartVRegVoVi.TabIndex = 3;
    this.butStartVRegVoVi.Text = "Start";
    this.butStartVRegVoVi.UseVisualStyleBackColor = true;
    this.picVRegVoViSmall.Cursor = Cursors.Hand;
    this.picVRegVoViSmall.Dock = DockStyle.Right;
    this.picVRegVoViSmall.Image = (Image) Resources.cct_VREG86;
    this.picVRegVoViSmall.InitialImage = (Image) null;
    this.picVRegVoViSmall.Location = new Point(689, 0);
    this.picVRegVoViSmall.Margin = new Padding(0);
    this.picVRegVoViSmall.Name = "picVRegVoViSmall";
    this.picVRegVoViSmall.Size = new Size(237, 92);
    this.picVRegVoViSmall.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picVRegVoViSmall.TabIndex = 55;
    this.picVRegVoViSmall.TabStop = false;
    this.picVRegVoViSmall.Tag = (object) "picVRegVoViLarge";
    this.picVRegVoViSmall.Click += new EventHandler(this.picCircuit_Click);
    this.tabJIdVgs.Controls.Add((Control) this.picJFETIdVgsCircuitLarge);
    this.tabJIdVgs.Controls.Add((Control) this.zedGraphJIdVgs);
    this.tabJIdVgs.Controls.Add((Control) this.panelJIdVgs);
    this.tabJIdVgs.Location = new Point(4, 22);
    this.tabJIdVgs.Name = "tabJIdVgs";
    this.tabJIdVgs.Size = new Size(926, 440);
    this.tabJIdVgs.TabIndex = 12;
    this.tabJIdVgs.Text = "JFET Id / Vgs";
    this.tabJIdVgs.UseVisualStyleBackColor = true;
    this.picJFETIdVgsCircuitLarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.picJFETIdVgsCircuitLarge.BorderStyle = BorderStyle.FixedSingle;
    this.picJFETIdVgsCircuitLarge.Image = (Image) Resources.cct_FET126;
    this.picJFETIdVgsCircuitLarge.InitialImage = (Image) null;
    this.picJFETIdVgsCircuitLarge.Location = new Point(600, 187);
    this.picJFETIdVgsCircuitLarge.Margin = new Padding(0);
    this.picJFETIdVgsCircuitLarge.Name = "picJFETIdVgsCircuitLarge";
    this.picJFETIdVgsCircuitLarge.Size = new Size(349, 128 /*0x80*/);
    this.picJFETIdVgsCircuitLarge.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picJFETIdVgsCircuitLarge.TabIndex = 54;
    this.picJFETIdVgsCircuitLarge.TabStop = false;
    this.picJFETIdVgsCircuitLarge.Tag = (object) "";
    this.picJFETIdVgsCircuitLarge.Visible = false;
    this.picJFETIdVgsCircuitLarge.MouseLeave += new EventHandler(this.picCircuit_MouseLeave);
    ((Control) this.zedGraphJIdVgs).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.zedGraphJIdVgs.IsAntiAlias = true;
    ((Control) this.zedGraphJIdVgs).Location = new Point(0, 0);
    ((Control) this.zedGraphJIdVgs).Name = "zedGraphJIdVgs";
    this.zedGraphJIdVgs.ScrollGrace = 0.0;
    this.zedGraphJIdVgs.ScrollMaxX = 0.0;
    this.zedGraphJIdVgs.ScrollMaxY = 0.0;
    this.zedGraphJIdVgs.ScrollMaxY2 = 0.0;
    this.zedGraphJIdVgs.ScrollMinX = 0.0;
    this.zedGraphJIdVgs.ScrollMinY = 0.0;
    this.zedGraphJIdVgs.ScrollMinY2 = 0.0;
    ((Control) this.zedGraphJIdVgs).Size = new Size(846, 286);
    ((Control) this.zedGraphJIdVgs).TabIndex = 9;
    this.panelJIdVgs.Controls.Add((Control) this.butAutosetJIdVgs);
    this.panelJIdVgs.Controls.Add((Control) this.checkJIdVgsLockParameters);
    this.panelJIdVgs.Controls.Add((Control) this.label66);
    this.panelJIdVgs.Controls.Add((Control) this.textJIdVgsTraces);
    this.panelJIdVgs.Controls.Add((Control) this.textJIdVgsVdsMax);
    this.panelJIdVgs.Controls.Add((Control) label125);
    this.panelJIdVgs.Controls.Add((Control) label126);
    this.panelJIdVgs.Controls.Add((Control) label127);
    this.panelJIdVgs.Controls.Add((Control) this.comboJIdVgsConfig);
    this.panelJIdVgs.Controls.Add((Control) label128);
    this.panelJIdVgs.Controls.Add((Control) label129);
    this.panelJIdVgs.Controls.Add((Control) label130);
    this.panelJIdVgs.Controls.Add((Control) this.textJIdVgsVdsMin);
    this.panelJIdVgs.Controls.Add((Control) label131);
    this.panelJIdVgs.Controls.Add((Control) label132);
    this.panelJIdVgs.Controls.Add((Control) this.textJIdVgsPoints);
    this.panelJIdVgs.Controls.Add((Control) this.textJIdVgsVgsMax);
    this.panelJIdVgs.Controls.Add((Control) this.textJIdVgsVgsMin);
    this.panelJIdVgs.Controls.Add((Control) label133);
    this.panelJIdVgs.Controls.Add((Control) label134);
    this.panelJIdVgs.Controls.Add((Control) label135);
    this.panelJIdVgs.Controls.Add((Control) this.butStartJIdVgs);
    this.panelJIdVgs.Controls.Add((Control) label136);
    this.panelJIdVgs.Controls.Add((Control) this.picJFETIdVgsCircuitSmall);
    this.panelJIdVgs.Dock = DockStyle.Bottom;
    this.panelJIdVgs.Location = new Point(0, 348);
    this.panelJIdVgs.MinimumSize = new Size(890, 0);
    this.panelJIdVgs.Name = "panelJIdVgs";
    rectanglePlus3.Color = SystemColors.ControlDark;
    rectanglePlus3.Rectangle = new Rectangle(167, 1, 360, 86);
    this.panelJIdVgs.Rectangles = new GraphPanel.RectanglePlus[1]
    {
      rectanglePlus3
    };
    this.panelJIdVgs.Size = new Size(926, 92);
    this.panelJIdVgs.TabIndex = 44;
    this.butAutosetJIdVgs.Location = new Point(461, 59);
    this.butAutosetJIdVgs.Name = "butAutosetJIdVgs";
    this.butAutosetJIdVgs.Size = new Size(54, 23);
    this.butAutosetJIdVgs.TabIndex = 9;
    this.butAutosetJIdVgs.Tag = (object) "Parameter";
    this.butAutosetJIdVgs.Text = "Autoset";
    this.butAutosetJIdVgs.UseVisualStyleBackColor = true;
    this.checkJIdVgsLockParameters.AutoSize = true;
    this.checkJIdVgsLockParameters.BackColor = Color.Transparent;
    this.checkJIdVgsLockParameters.Location = new Point(470, 13);
    this.checkJIdVgsLockParameters.Name = "checkJIdVgsLockParameters";
    this.checkJIdVgsLockParameters.RightToLeft = RightToLeft.No;
    this.checkJIdVgsLockParameters.Size = new Size(49, 18);
    this.checkJIdVgsLockParameters.TabIndex = 8;
    this.checkJIdVgsLockParameters.Text = "Lock";
    this.checkJIdVgsLockParameters.UseVisualStyleBackColor = false;
    this.label66.AutoSize = true;
    this.label66.Location = new Point(435, 36);
    this.label66.Name = "label66";
    this.label66.Size = new Size(15, 14);
    this.label66.TabIndex = 65;
    this.label66.Text = "V";
    this.textJIdVgsTraces.BorderStyle = BorderStyle.FixedSingle;
    this.textJIdVgsTraces.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textJIdVgsTraces.Location = new Point(384, 61);
    this.textJIdVgsTraces.Name = "textJIdVgsTraces";
    this.textJIdVgsTraces.Size = new Size(46, 20);
    this.textJIdVgsTraces.TabIndex = 5;
    this.textJIdVgsTraces.Tag = (object) "Parameter";
    this.textJIdVgsTraces.Text = "unset";
    this.textJIdVgsTraces.TextAlign = HorizontalAlignment.Right;
    this.textJIdVgsTraces.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textJIdVgsVdsMax.BorderStyle = BorderStyle.FixedSingle;
    this.textJIdVgsVdsMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textJIdVgsVdsMax.Location = new Point(384, 33);
    this.textJIdVgsVdsMax.Name = "textJIdVgsVdsMax";
    this.textJIdVgsVdsMax.Size = new Size(46, 20);
    this.textJIdVgsVdsMax.TabIndex = 4;
    this.textJIdVgsVdsMax.Tag = (object) "Parameter";
    this.textJIdVgsVdsMax.Text = "unset";
    this.textJIdVgsVdsMax.TextAlign = HorizontalAlignment.Right;
    this.textJIdVgsVdsMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.comboJIdVgsConfig.DrawMode = DrawMode.OwnerDrawFixed;
    this.comboJIdVgsConfig.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboJIdVgsConfig.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.comboJIdVgsConfig.FormattingEnabled = true;
    this.comboJIdVgsConfig.Items.AddRange(new object[1]
    {
      (object) "Unknown"
    });
    this.comboJIdVgsConfig.Location = new Point(15, 25);
    this.comboJIdVgsConfig.Name = "comboJIdVgsConfig";
    this.comboJIdVgsConfig.Size = new Size(144 /*0x90*/, 21);
    this.comboJIdVgsConfig.TabIndex = 7;
    this.comboJIdVgsConfig.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textJIdVgsVdsMin.BorderStyle = BorderStyle.FixedSingle;
    this.textJIdVgsVdsMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textJIdVgsVdsMin.Location = new Point(384, 5);
    this.textJIdVgsVdsMin.Name = "textJIdVgsVdsMin";
    this.textJIdVgsVdsMin.Size = new Size(46, 20);
    this.textJIdVgsVdsMin.TabIndex = 3;
    this.textJIdVgsVdsMin.Tag = (object) "Parameter";
    this.textJIdVgsVdsMin.Text = "unset";
    this.textJIdVgsVdsMin.TextAlign = HorizontalAlignment.Right;
    this.textJIdVgsVdsMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textJIdVgsPoints.BorderStyle = BorderStyle.FixedSingle;
    this.textJIdVgsPoints.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textJIdVgsPoints.Location = new Point(242, 61);
    this.textJIdVgsPoints.Name = "textJIdVgsPoints";
    this.textJIdVgsPoints.Size = new Size(46, 20);
    this.textJIdVgsPoints.TabIndex = 2;
    this.textJIdVgsPoints.Tag = (object) "Parameter";
    this.textJIdVgsPoints.Text = "unset";
    this.textJIdVgsPoints.TextAlign = HorizontalAlignment.Right;
    this.textJIdVgsPoints.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textJIdVgsVgsMax.BorderStyle = BorderStyle.FixedSingle;
    this.textJIdVgsVgsMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textJIdVgsVgsMax.Location = new Point(242, 33);
    this.textJIdVgsVgsMax.Name = "textJIdVgsVgsMax";
    this.textJIdVgsVgsMax.Size = new Size(46, 20);
    this.textJIdVgsVgsMax.TabIndex = 1;
    this.textJIdVgsVgsMax.Tag = (object) "Parameter";
    this.textJIdVgsVgsMax.Text = "unset";
    this.textJIdVgsVgsMax.TextAlign = HorizontalAlignment.Right;
    this.textJIdVgsVgsMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textJIdVgsVgsMin.BorderStyle = BorderStyle.FixedSingle;
    this.textJIdVgsVgsMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textJIdVgsVgsMin.Location = new Point(242, 5);
    this.textJIdVgsVgsMin.Name = "textJIdVgsVgsMin";
    this.textJIdVgsVgsMin.Size = new Size(46, 20);
    this.textJIdVgsVgsMin.TabIndex = 0;
    this.textJIdVgsVgsMin.Tag = (object) "Parameter";
    this.textJIdVgsVgsMin.Text = "unset";
    this.textJIdVgsVgsMin.TextAlign = HorizontalAlignment.Right;
    this.textJIdVgsVgsMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.butStartJIdVgs.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.butStartJIdVgs.Location = new Point(538, 59);
    this.butStartJIdVgs.Name = "butStartJIdVgs";
    this.butStartJIdVgs.Size = new Size(75, 23);
    this.butStartJIdVgs.TabIndex = 6;
    this.butStartJIdVgs.Text = "Start";
    this.butStartJIdVgs.UseVisualStyleBackColor = true;
    this.picJFETIdVgsCircuitSmall.Cursor = Cursors.Hand;
    this.picJFETIdVgsCircuitSmall.Dock = DockStyle.Right;
    this.picJFETIdVgsCircuitSmall.Image = (Image) Resources.cct_FET86;
    this.picJFETIdVgsCircuitSmall.InitialImage = (Image) null;
    this.picJFETIdVgsCircuitSmall.Location = new Point(689, 0);
    this.picJFETIdVgsCircuitSmall.Margin = new Padding(0);
    this.picJFETIdVgsCircuitSmall.Name = "picJFETIdVgsCircuitSmall";
    this.picJFETIdVgsCircuitSmall.Size = new Size(237, 92);
    this.picJFETIdVgsCircuitSmall.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picJFETIdVgsCircuitSmall.TabIndex = 59;
    this.picJFETIdVgsCircuitSmall.TabStop = false;
    this.picJFETIdVgsCircuitSmall.Tag = (object) "picJFETIdVgsCircuitLarge";
    this.picJFETIdVgsCircuitSmall.Click += new EventHandler(this.picCircuit_Click);
    this.tabJIdVds.Controls.Add((Control) this.picJFETIdVdsCircuitLarge);
    this.tabJIdVds.Controls.Add((Control) this.zedGraphJIdVds);
    this.tabJIdVds.Controls.Add((Control) this.panelJIdVds);
    this.tabJIdVds.Location = new Point(4, 22);
    this.tabJIdVds.Name = "tabJIdVds";
    this.tabJIdVds.Size = new Size(926, 440);
    this.tabJIdVds.TabIndex = 11;
    this.tabJIdVds.Text = "JFET Id / Vds";
    this.tabJIdVds.UseVisualStyleBackColor = true;
    this.picJFETIdVdsCircuitLarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.picJFETIdVdsCircuitLarge.BorderStyle = BorderStyle.FixedSingle;
    this.picJFETIdVdsCircuitLarge.Image = (Image) Resources.cct_FET126;
    this.picJFETIdVdsCircuitLarge.InitialImage = (Image) null;
    this.picJFETIdVdsCircuitLarge.Location = new Point(605, 186);
    this.picJFETIdVdsCircuitLarge.Margin = new Padding(0);
    this.picJFETIdVdsCircuitLarge.Name = "picJFETIdVdsCircuitLarge";
    this.picJFETIdVdsCircuitLarge.Size = new Size(349, 128 /*0x80*/);
    this.picJFETIdVdsCircuitLarge.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picJFETIdVdsCircuitLarge.TabIndex = 56;
    this.picJFETIdVdsCircuitLarge.TabStop = false;
    this.picJFETIdVdsCircuitLarge.Tag = (object) "";
    this.picJFETIdVdsCircuitLarge.Visible = false;
    this.picJFETIdVdsCircuitLarge.MouseLeave += new EventHandler(this.picCircuit_MouseLeave);
    ((Control) this.zedGraphJIdVds).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.zedGraphJIdVds.IsAntiAlias = true;
    ((Control) this.zedGraphJIdVds).Location = new Point(0, 0);
    ((Control) this.zedGraphJIdVds).Name = "zedGraphJIdVds";
    this.zedGraphJIdVds.ScrollGrace = 0.0;
    this.zedGraphJIdVds.ScrollMaxX = 0.0;
    this.zedGraphJIdVds.ScrollMaxY = 0.0;
    this.zedGraphJIdVds.ScrollMaxY2 = 0.0;
    this.zedGraphJIdVds.ScrollMinX = 0.0;
    this.zedGraphJIdVds.ScrollMinY = 0.0;
    this.zedGraphJIdVds.ScrollMinY2 = 0.0;
    ((Control) this.zedGraphJIdVds).Size = new Size(846, 272);
    ((Control) this.zedGraphJIdVds).TabIndex = 9;
    this.panelJIdVds.Controls.Add((Control) this.butAutosetJIdVds);
    this.panelJIdVds.Controls.Add((Control) this.checkJIdVdsLockParameters);
    this.panelJIdVds.Controls.Add((Control) this.comboJIdVdsConfig);
    this.panelJIdVds.Controls.Add((Control) label114);
    this.panelJIdVds.Controls.Add((Control) label115);
    this.panelJIdVds.Controls.Add((Control) this.label87);
    this.panelJIdVds.Controls.Add((Control) this.label88);
    this.panelJIdVds.Controls.Add((Control) this.textJIdVdsTraces);
    this.panelJIdVds.Controls.Add((Control) this.textJIdVdsVgsMax);
    this.panelJIdVds.Controls.Add((Control) this.textJIdVdsVgsMin);
    this.panelJIdVds.Controls.Add((Control) label116);
    this.panelJIdVds.Controls.Add((Control) label117);
    this.panelJIdVds.Controls.Add((Control) label118);
    this.panelJIdVds.Controls.Add((Control) label119);
    this.panelJIdVds.Controls.Add((Control) label120);
    this.panelJIdVds.Controls.Add((Control) this.textJIdVdsPoints);
    this.panelJIdVds.Controls.Add((Control) this.textJIdVdsVdsMax);
    this.panelJIdVds.Controls.Add((Control) this.textJIdVdsVdsMin);
    this.panelJIdVds.Controls.Add((Control) label121);
    this.panelJIdVds.Controls.Add((Control) label122);
    this.panelJIdVds.Controls.Add((Control) label123);
    this.panelJIdVds.Controls.Add((Control) this.butStartJIdVds);
    this.panelJIdVds.Controls.Add((Control) label124);
    this.panelJIdVds.Controls.Add((Control) this.picJFETIdVdsCircuitSmall);
    this.panelJIdVds.Dock = DockStyle.Bottom;
    this.panelJIdVds.Location = new Point(0, 348);
    this.panelJIdVds.MinimumSize = new Size(890, 0);
    this.panelJIdVds.Name = "panelJIdVds";
    rectanglePlus4.Color = SystemColors.ControlDark;
    rectanglePlus4.Rectangle = new Rectangle(167, 1, 360, 86);
    this.panelJIdVds.Rectangles = new GraphPanel.RectanglePlus[1]
    {
      rectanglePlus4
    };
    this.panelJIdVds.Size = new Size(926, 92);
    this.panelJIdVds.TabIndex = 44;
    this.butAutosetJIdVds.Location = new Point(461, 59);
    this.butAutosetJIdVds.Name = "butAutosetJIdVds";
    this.butAutosetJIdVds.Size = new Size(54, 23);
    this.butAutosetJIdVds.TabIndex = 9;
    this.butAutosetJIdVds.Tag = (object) "Parameter";
    this.butAutosetJIdVds.Text = "Autoset";
    this.butAutosetJIdVds.UseVisualStyleBackColor = true;
    this.checkJIdVdsLockParameters.AutoSize = true;
    this.checkJIdVdsLockParameters.BackColor = Color.Transparent;
    this.checkJIdVdsLockParameters.Location = new Point(470, 13);
    this.checkJIdVdsLockParameters.Name = "checkJIdVdsLockParameters";
    this.checkJIdVdsLockParameters.RightToLeft = RightToLeft.No;
    this.checkJIdVdsLockParameters.Size = new Size(49, 18);
    this.checkJIdVdsLockParameters.TabIndex = 8;
    this.checkJIdVdsLockParameters.Text = "Lock";
    this.checkJIdVdsLockParameters.UseVisualStyleBackColor = false;
    this.comboJIdVdsConfig.DrawMode = DrawMode.OwnerDrawFixed;
    this.comboJIdVdsConfig.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboJIdVdsConfig.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.comboJIdVdsConfig.FormattingEnabled = true;
    this.comboJIdVdsConfig.Items.AddRange(new object[1]
    {
      (object) "Unknown"
    });
    this.comboJIdVdsConfig.Location = new Point(15, 25);
    this.comboJIdVdsConfig.Name = "comboJIdVdsConfig";
    this.comboJIdVdsConfig.Size = new Size(144 /*0x90*/, 21);
    this.comboJIdVdsConfig.TabIndex = 7;
    this.comboJIdVdsConfig.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.label87.AutoSize = true;
    this.label87.Location = new Point(435, 36);
    this.label87.Name = "label87";
    this.label87.Size = new Size(15, 14);
    this.label87.TabIndex = 27;
    this.label87.Text = "V";
    this.label88.AutoSize = true;
    this.label88.Location = new Point(435, 8);
    this.label88.Name = "label88";
    this.label88.Size = new Size(15, 14);
    this.label88.TabIndex = 26;
    this.label88.Text = "V";
    this.textJIdVdsTraces.BorderStyle = BorderStyle.FixedSingle;
    this.textJIdVdsTraces.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textJIdVdsTraces.Location = new Point(384, 61);
    this.textJIdVdsTraces.Name = "textJIdVdsTraces";
    this.textJIdVdsTraces.Size = new Size(46, 20);
    this.textJIdVdsTraces.TabIndex = 5;
    this.textJIdVdsTraces.Tag = (object) "Parameter";
    this.textJIdVdsTraces.Text = "unset";
    this.textJIdVdsTraces.TextAlign = HorizontalAlignment.Right;
    this.textJIdVdsTraces.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textJIdVdsVgsMax.BorderStyle = BorderStyle.FixedSingle;
    this.textJIdVdsVgsMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textJIdVdsVgsMax.Location = new Point(384, 33);
    this.textJIdVdsVgsMax.Name = "textJIdVdsVgsMax";
    this.textJIdVdsVgsMax.Size = new Size(46, 20);
    this.textJIdVdsVgsMax.TabIndex = 4;
    this.textJIdVdsVgsMax.Tag = (object) "Parameter";
    this.textJIdVdsVgsMax.Text = "unset";
    this.textJIdVdsVgsMax.TextAlign = HorizontalAlignment.Right;
    this.textJIdVdsVgsMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textJIdVdsVgsMin.BorderStyle = BorderStyle.FixedSingle;
    this.textJIdVdsVgsMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textJIdVdsVgsMin.Location = new Point(384, 5);
    this.textJIdVdsVgsMin.Name = "textJIdVdsVgsMin";
    this.textJIdVdsVgsMin.Size = new Size(46, 20);
    this.textJIdVdsVgsMin.TabIndex = 3;
    this.textJIdVdsVgsMin.Tag = (object) "Parameter";
    this.textJIdVdsVgsMin.Text = "unset";
    this.textJIdVdsVgsMin.TextAlign = HorizontalAlignment.Right;
    this.textJIdVdsVgsMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textJIdVdsPoints.BorderStyle = BorderStyle.FixedSingle;
    this.textJIdVdsPoints.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textJIdVdsPoints.Location = new Point(242, 61);
    this.textJIdVdsPoints.Name = "textJIdVdsPoints";
    this.textJIdVdsPoints.Size = new Size(46, 20);
    this.textJIdVdsPoints.TabIndex = 2;
    this.textJIdVdsPoints.Tag = (object) "Parameter";
    this.textJIdVdsPoints.Text = "unset";
    this.textJIdVdsPoints.TextAlign = HorizontalAlignment.Right;
    this.textJIdVdsPoints.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textJIdVdsVdsMax.BorderStyle = BorderStyle.FixedSingle;
    this.textJIdVdsVdsMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textJIdVdsVdsMax.Location = new Point(242, 33);
    this.textJIdVdsVdsMax.Name = "textJIdVdsVdsMax";
    this.textJIdVdsVdsMax.Size = new Size(46, 20);
    this.textJIdVdsVdsMax.TabIndex = 1;
    this.textJIdVdsVdsMax.Tag = (object) "Parameter";
    this.textJIdVdsVdsMax.Text = "unset";
    this.textJIdVdsVdsMax.TextAlign = HorizontalAlignment.Right;
    this.textJIdVdsVdsMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textJIdVdsVdsMin.BorderStyle = BorderStyle.FixedSingle;
    this.textJIdVdsVdsMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textJIdVdsVdsMin.Location = new Point(242, 5);
    this.textJIdVdsVdsMin.Name = "textJIdVdsVdsMin";
    this.textJIdVdsVdsMin.Size = new Size(46, 20);
    this.textJIdVdsVdsMin.TabIndex = 0;
    this.textJIdVdsVdsMin.Tag = (object) "Parameter";
    this.textJIdVdsVdsMin.Text = "unset";
    this.textJIdVdsVdsMin.TextAlign = HorizontalAlignment.Right;
    this.textJIdVdsVdsMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.butStartJIdVds.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.butStartJIdVds.Location = new Point(538, 59);
    this.butStartJIdVds.Name = "butStartJIdVds";
    this.butStartJIdVds.Size = new Size(75, 23);
    this.butStartJIdVds.TabIndex = 6;
    this.butStartJIdVds.Text = "Start";
    this.butStartJIdVds.UseVisualStyleBackColor = true;
    this.picJFETIdVdsCircuitSmall.Cursor = Cursors.Hand;
    this.picJFETIdVdsCircuitSmall.Dock = DockStyle.Right;
    this.picJFETIdVdsCircuitSmall.Image = (Image) Resources.cct_FET86;
    this.picJFETIdVdsCircuitSmall.InitialImage = (Image) null;
    this.picJFETIdVdsCircuitSmall.Location = new Point(689, 0);
    this.picJFETIdVdsCircuitSmall.Margin = new Padding(0);
    this.picJFETIdVdsCircuitSmall.Name = "picJFETIdVdsCircuitSmall";
    this.picJFETIdVdsCircuitSmall.Size = new Size(237, 92);
    this.picJFETIdVdsCircuitSmall.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picJFETIdVdsCircuitSmall.TabIndex = 58;
    this.picJFETIdVdsCircuitSmall.TabStop = false;
    this.picJFETIdVdsCircuitSmall.Tag = (object) "picJFETIdVdsCircuitLarge";
    this.picJFETIdVdsCircuitSmall.Click += new EventHandler(this.picCircuit_Click);
    this.tabFIdVds.Controls.Add((Control) this.picMOSIdVdsCircuitLarge);
    this.tabFIdVds.Controls.Add((Control) this.zedGraphMIdVds);
    this.tabFIdVds.Controls.Add((Control) this.panelMIdVds);
    this.tabFIdVds.Location = new Point(4, 22);
    this.tabFIdVds.Name = "tabFIdVds";
    this.tabFIdVds.Size = new Size(926, 440);
    this.tabFIdVds.TabIndex = 5;
    this.tabFIdVds.Text = "MOSFET Id / Vds";
    this.tabFIdVds.UseVisualStyleBackColor = true;
    this.picMOSIdVdsCircuitLarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.picMOSIdVdsCircuitLarge.BorderStyle = BorderStyle.FixedSingle;
    this.picMOSIdVdsCircuitLarge.Image = (Image) Resources.cct_FET126;
    this.picMOSIdVdsCircuitLarge.InitialImage = (Image) null;
    this.picMOSIdVdsCircuitLarge.Location = new Point(600, 169);
    this.picMOSIdVdsCircuitLarge.Margin = new Padding(0);
    this.picMOSIdVdsCircuitLarge.Name = "picMOSIdVdsCircuitLarge";
    this.picMOSIdVdsCircuitLarge.Size = new Size(349, 128 /*0x80*/);
    this.picMOSIdVdsCircuitLarge.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picMOSIdVdsCircuitLarge.TabIndex = 53;
    this.picMOSIdVdsCircuitLarge.TabStop = false;
    this.picMOSIdVdsCircuitLarge.Tag = (object) "";
    this.picMOSIdVdsCircuitLarge.Visible = false;
    this.picMOSIdVdsCircuitLarge.MouseLeave += new EventHandler(this.picCircuit_MouseLeave);
    ((Control) this.zedGraphMIdVds).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.zedGraphMIdVds.IsAntiAlias = true;
    ((Control) this.zedGraphMIdVds).Location = new Point(0, 0);
    ((Control) this.zedGraphMIdVds).Name = "zedGraphMIdVds";
    this.zedGraphMIdVds.ScrollGrace = 0.0;
    this.zedGraphMIdVds.ScrollMaxX = 0.0;
    this.zedGraphMIdVds.ScrollMaxY = 0.0;
    this.zedGraphMIdVds.ScrollMaxY2 = 0.0;
    this.zedGraphMIdVds.ScrollMinX = 0.0;
    this.zedGraphMIdVds.ScrollMinY = 0.0;
    this.zedGraphMIdVds.ScrollMinY2 = 0.0;
    ((Control) this.zedGraphMIdVds).Size = new Size(926, 297);
    ((Control) this.zedGraphMIdVds).TabIndex = 10;
    this.panelMIdVds.Controls.Add((Control) this.butAutosetMIdVds);
    this.panelMIdVds.Controls.Add((Control) this.checkMIdVdsLockParameters);
    this.panelMIdVds.Controls.Add((Control) this.rtextIdVdsConfig);
    this.panelMIdVds.Controls.Add((Control) this.checkMIdVdsLog);
    this.panelMIdVds.Controls.Add((Control) label62);
    this.panelMIdVds.Controls.Add((Control) label63);
    this.panelMIdVds.Controls.Add((Control) this.butStartMIdVds);
    this.panelMIdVds.Controls.Add((Control) label64);
    this.panelMIdVds.Controls.Add((Control) label65);
    this.panelMIdVds.Controls.Add((Control) this.textIdVdsTraces);
    this.panelMIdVds.Controls.Add((Control) this.textIdVdsVgsMax);
    this.panelMIdVds.Controls.Add((Control) this.textIdVdsVgsMin);
    this.panelMIdVds.Controls.Add((Control) label66);
    this.panelMIdVds.Controls.Add((Control) label67);
    this.panelMIdVds.Controls.Add((Control) label68);
    this.panelMIdVds.Controls.Add((Control) label69);
    this.panelMIdVds.Controls.Add((Control) label70);
    this.panelMIdVds.Controls.Add((Control) this.textIdVdsPoints);
    this.panelMIdVds.Controls.Add((Control) this.textIdVdsVddMax);
    this.panelMIdVds.Controls.Add((Control) this.textIdVdsVddMin);
    this.panelMIdVds.Controls.Add((Control) label71);
    this.panelMIdVds.Controls.Add((Control) label72);
    this.panelMIdVds.Controls.Add((Control) label73);
    this.panelMIdVds.Controls.Add((Control) label74);
    this.panelMIdVds.Controls.Add((Control) this.picMOSIdVdsCircuitSmall);
    this.panelMIdVds.Dock = DockStyle.Bottom;
    this.panelMIdVds.Location = new Point(0, 348);
    this.panelMIdVds.MinimumSize = new Size(890, 0);
    this.panelMIdVds.Name = "panelMIdVds";
    rectanglePlus5.Color = SystemColors.ControlDark;
    rectanglePlus5.Rectangle = new Rectangle(84, 1, 382, 86);
    this.panelMIdVds.Rectangles = new GraphPanel.RectanglePlus[1]
    {
      rectanglePlus5
    };
    this.panelMIdVds.Size = new Size(926, 92);
    this.panelMIdVds.TabIndex = 50;
    this.butAutosetMIdVds.Location = new Point(378, 59);
    this.butAutosetMIdVds.Name = "butAutosetMIdVds";
    this.butAutosetMIdVds.Size = new Size(54, 23);
    this.butAutosetMIdVds.TabIndex = 9;
    this.butAutosetMIdVds.Tag = (object) "Parameter";
    this.butAutosetMIdVds.Text = "Autoset";
    this.butAutosetMIdVds.UseVisualStyleBackColor = true;
    this.checkMIdVdsLockParameters.AutoSize = true;
    this.checkMIdVdsLockParameters.BackColor = Color.Transparent;
    this.checkMIdVdsLockParameters.Location = new Point(387, 13);
    this.checkMIdVdsLockParameters.Name = "checkMIdVdsLockParameters";
    this.checkMIdVdsLockParameters.RightToLeft = RightToLeft.No;
    this.checkMIdVdsLockParameters.Size = new Size(49, 18);
    this.checkMIdVdsLockParameters.TabIndex = 7;
    this.checkMIdVdsLockParameters.Text = "Lock";
    this.checkMIdVdsLockParameters.UseVisualStyleBackColor = false;
    this.rtextIdVdsConfig.BackColor = SystemColors.Window;
    this.rtextIdVdsConfig.BorderStyle = BorderStyle.None;
    this.rtextIdVdsConfig.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.rtextIdVdsConfig.Location = new Point(14, 22);
    this.rtextIdVdsConfig.Name = "rtextIdVdsConfig";
    this.rtextIdVdsConfig.ReadOnly = true;
    this.rtextIdVdsConfig.Size = new Size(64 /*0x40*/, 58);
    this.rtextIdVdsConfig.TabIndex = 118;
    this.rtextIdVdsConfig.TabStop = false;
    this.rtextIdVdsConfig.Text = "Unknown";
    this.checkMIdVdsLog.AutoSize = true;
    this.checkMIdVdsLog.Location = new Point(387, 35);
    this.checkMIdVdsLog.Name = "checkMIdVdsLog";
    this.checkMIdVdsLog.Size = new Size(71, 18);
    this.checkMIdVdsLog.TabIndex = 8;
    this.checkMIdVdsLog.Text = "Log span";
    this.checkMIdVdsLog.UseVisualStyleBackColor = true;
    this.butStartMIdVds.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.butStartMIdVds.Location = new Point(477, 59);
    this.butStartMIdVds.Name = "butStartMIdVds";
    this.butStartMIdVds.Size = new Size(75, 23);
    this.butStartMIdVds.TabIndex = 6;
    this.butStartMIdVds.Text = "Start";
    this.butStartMIdVds.UseVisualStyleBackColor = true;
    this.textIdVdsTraces.BorderStyle = BorderStyle.FixedSingle;
    this.textIdVdsTraces.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIdVdsTraces.Location = new Point(301, 62);
    this.textIdVdsTraces.Name = "textIdVdsTraces";
    this.textIdVdsTraces.Size = new Size(46, 20);
    this.textIdVdsTraces.TabIndex = 5;
    this.textIdVdsTraces.Tag = (object) "Parameter";
    this.textIdVdsTraces.Text = "unset";
    this.textIdVdsTraces.TextAlign = HorizontalAlignment.Right;
    this.textIdVdsTraces.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIdVdsVgsMax.BorderStyle = BorderStyle.FixedSingle;
    this.textIdVdsVgsMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIdVdsVgsMax.Location = new Point(301, 34);
    this.textIdVdsVgsMax.Name = "textIdVdsVgsMax";
    this.textIdVdsVgsMax.Size = new Size(46, 20);
    this.textIdVdsVgsMax.TabIndex = 4;
    this.textIdVdsVgsMax.Tag = (object) "Parameter";
    this.textIdVdsVgsMax.Text = "unset";
    this.textIdVdsVgsMax.TextAlign = HorizontalAlignment.Right;
    this.textIdVdsVgsMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIdVdsVgsMin.BorderStyle = BorderStyle.FixedSingle;
    this.textIdVdsVgsMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIdVdsVgsMin.Location = new Point(301, 6);
    this.textIdVdsVgsMin.Name = "textIdVdsVgsMin";
    this.textIdVdsVgsMin.Size = new Size(46, 20);
    this.textIdVdsVgsMin.TabIndex = 3;
    this.textIdVdsVgsMin.Tag = (object) "Parameter";
    this.textIdVdsVgsMin.Text = "unset";
    this.textIdVdsVgsMin.TextAlign = HorizontalAlignment.Right;
    this.textIdVdsVgsMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIdVdsPoints.BorderStyle = BorderStyle.FixedSingle;
    this.textIdVdsPoints.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIdVdsPoints.Location = new Point(159, 62);
    this.textIdVdsPoints.Name = "textIdVdsPoints";
    this.textIdVdsPoints.Size = new Size(46, 20);
    this.textIdVdsPoints.TabIndex = 2;
    this.textIdVdsPoints.Tag = (object) "Parameter";
    this.textIdVdsPoints.Text = "unset";
    this.textIdVdsPoints.TextAlign = HorizontalAlignment.Right;
    this.textIdVdsPoints.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIdVdsVddMax.BorderStyle = BorderStyle.FixedSingle;
    this.textIdVdsVddMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIdVdsVddMax.Location = new Point(159, 34);
    this.textIdVdsVddMax.Name = "textIdVdsVddMax";
    this.textIdVdsVddMax.Size = new Size(46, 20);
    this.textIdVdsVddMax.TabIndex = 1;
    this.textIdVdsVddMax.Tag = (object) "Parameter";
    this.textIdVdsVddMax.Text = "unset";
    this.textIdVdsVddMax.TextAlign = HorizontalAlignment.Right;
    this.textIdVdsVddMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIdVdsVddMin.BorderStyle = BorderStyle.FixedSingle;
    this.textIdVdsVddMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIdVdsVddMin.Location = new Point(159, 6);
    this.textIdVdsVddMin.Name = "textIdVdsVddMin";
    this.textIdVdsVddMin.Size = new Size(46, 20);
    this.textIdVdsVddMin.TabIndex = 0;
    this.textIdVdsVddMin.Tag = (object) "Parameter";
    this.textIdVdsVddMin.Text = "unset";
    this.textIdVdsVddMin.TextAlign = HorizontalAlignment.Right;
    this.textIdVdsVddMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.picMOSIdVdsCircuitSmall.Cursor = Cursors.Hand;
    this.picMOSIdVdsCircuitSmall.Dock = DockStyle.Right;
    this.picMOSIdVdsCircuitSmall.Image = (Image) Resources.cct_FET86;
    this.picMOSIdVdsCircuitSmall.InitialImage = (Image) null;
    this.picMOSIdVdsCircuitSmall.Location = new Point(689, 0);
    this.picMOSIdVdsCircuitSmall.Margin = new Padding(0);
    this.picMOSIdVdsCircuitSmall.Name = "picMOSIdVdsCircuitSmall";
    this.picMOSIdVdsCircuitSmall.Size = new Size(237, 92);
    this.picMOSIdVdsCircuitSmall.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picMOSIdVdsCircuitSmall.TabIndex = 54;
    this.picMOSIdVdsCircuitSmall.TabStop = false;
    this.picMOSIdVdsCircuitSmall.Tag = (object) "picMOSIdVdsCircuitLarge";
    this.picMOSIdVdsCircuitSmall.Click += new EventHandler(this.picCircuit_Click);
    this.tabFIdVgs.Controls.Add((Control) this.picMOSIdVgsCircuitLarge);
    this.tabFIdVgs.Controls.Add((Control) this.zedGraphMIdVgs);
    this.tabFIdVgs.Controls.Add((Control) this.panelMIdVgs);
    this.tabFIdVgs.Location = new Point(4, 22);
    this.tabFIdVgs.Name = "tabFIdVgs";
    this.tabFIdVgs.Size = new Size(926, 440);
    this.tabFIdVgs.TabIndex = 13;
    this.tabFIdVgs.Text = "MOSFET Id / Vgs";
    this.tabFIdVgs.UseVisualStyleBackColor = true;
    this.picMOSIdVgsCircuitLarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.picMOSIdVgsCircuitLarge.BorderStyle = BorderStyle.FixedSingle;
    this.picMOSIdVgsCircuitLarge.Image = (Image) Resources.cct_FET126;
    this.picMOSIdVgsCircuitLarge.InitialImage = (Image) null;
    this.picMOSIdVgsCircuitLarge.Location = new Point(600, 188);
    this.picMOSIdVgsCircuitLarge.Margin = new Padding(0);
    this.picMOSIdVgsCircuitLarge.Name = "picMOSIdVgsCircuitLarge";
    this.picMOSIdVgsCircuitLarge.Size = new Size(349, 128 /*0x80*/);
    this.picMOSIdVgsCircuitLarge.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picMOSIdVgsCircuitLarge.TabIndex = 54;
    this.picMOSIdVgsCircuitLarge.TabStop = false;
    this.picMOSIdVgsCircuitLarge.Tag = (object) "";
    this.picMOSIdVgsCircuitLarge.Visible = false;
    this.picMOSIdVgsCircuitLarge.MouseLeave += new EventHandler(this.picCircuit_MouseLeave);
    ((Control) this.zedGraphMIdVgs).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.zedGraphMIdVgs.IsAntiAlias = true;
    ((Control) this.zedGraphMIdVgs).Location = new Point(0, 0);
    ((Control) this.zedGraphMIdVgs).Name = "zedGraphMIdVgs";
    this.zedGraphMIdVgs.ScrollGrace = 0.0;
    this.zedGraphMIdVgs.ScrollMaxX = 0.0;
    this.zedGraphMIdVgs.ScrollMaxY = 0.0;
    this.zedGraphMIdVgs.ScrollMaxY2 = 0.0;
    this.zedGraphMIdVgs.ScrollMinX = 0.0;
    this.zedGraphMIdVgs.ScrollMinY = 0.0;
    this.zedGraphMIdVgs.ScrollMinY2 = 0.0;
    ((Control) this.zedGraphMIdVgs).Size = new Size(901, 290);
    ((Control) this.zedGraphMIdVgs).TabIndex = 9;
    this.panelMIdVgs.Controls.Add((Control) this.butAutosetMIdVgs);
    this.panelMIdVgs.Controls.Add((Control) this.checkMIdVgsLockParameters);
    this.panelMIdVgs.Controls.Add((Control) this.rtextIdVgsConfig);
    this.panelMIdVgs.Controls.Add((Control) label75);
    this.panelMIdVgs.Controls.Add((Control) label76);
    this.panelMIdVgs.Controls.Add((Control) label77);
    this.panelMIdVgs.Controls.Add((Control) label78);
    this.panelMIdVgs.Controls.Add((Control) this.textMIdVgsTraces);
    this.panelMIdVgs.Controls.Add((Control) this.textMIdVgsVdsMax);
    this.panelMIdVgs.Controls.Add((Control) this.textMIdVgsVdsMin);
    this.panelMIdVgs.Controls.Add((Control) label79);
    this.panelMIdVgs.Controls.Add((Control) label80);
    this.panelMIdVgs.Controls.Add((Control) label81);
    this.panelMIdVgs.Controls.Add((Control) label82);
    this.panelMIdVgs.Controls.Add((Control) label83);
    this.panelMIdVgs.Controls.Add((Control) this.textMIdVgsPoints);
    this.panelMIdVgs.Controls.Add((Control) this.textMIdVgsVgsMax);
    this.panelMIdVgs.Controls.Add((Control) this.textMIdVgsVgsMin);
    this.panelMIdVgs.Controls.Add((Control) label84);
    this.panelMIdVgs.Controls.Add((Control) label85);
    this.panelMIdVgs.Controls.Add((Control) label86);
    this.panelMIdVgs.Controls.Add((Control) this.butStartMIdVgs);
    this.panelMIdVgs.Controls.Add((Control) label87);
    this.panelMIdVgs.Controls.Add((Control) this.picMOSIdVgsCircuitSmall);
    this.panelMIdVgs.Dock = DockStyle.Bottom;
    this.panelMIdVgs.Location = new Point(0, 348);
    this.panelMIdVgs.MinimumSize = new Size(890, 0);
    this.panelMIdVgs.Name = "panelMIdVgs";
    rectanglePlus6.Color = SystemColors.ControlDark;
    rectanglePlus6.Rectangle = new Rectangle(84, 1, 360, 86);
    this.panelMIdVgs.Rectangles = new GraphPanel.RectanglePlus[1]
    {
      rectanglePlus6
    };
    this.panelMIdVgs.Size = new Size(926, 92);
    this.panelMIdVgs.TabIndex = 43;
    this.butAutosetMIdVgs.Location = new Point(378, 59);
    this.butAutosetMIdVgs.Name = "butAutosetMIdVgs";
    this.butAutosetMIdVgs.Size = new Size(54, 23);
    this.butAutosetMIdVgs.TabIndex = 8;
    this.butAutosetMIdVgs.Tag = (object) "Parameter";
    this.butAutosetMIdVgs.Text = "Autoset";
    this.butAutosetMIdVgs.UseVisualStyleBackColor = true;
    this.checkMIdVgsLockParameters.AutoSize = true;
    this.checkMIdVgsLockParameters.BackColor = Color.Transparent;
    this.checkMIdVgsLockParameters.Location = new Point(387, 13);
    this.checkMIdVgsLockParameters.Name = "checkMIdVgsLockParameters";
    this.checkMIdVgsLockParameters.RightToLeft = RightToLeft.No;
    this.checkMIdVgsLockParameters.Size = new Size(49, 18);
    this.checkMIdVgsLockParameters.TabIndex = 7;
    this.checkMIdVgsLockParameters.Text = "Lock";
    this.checkMIdVgsLockParameters.UseVisualStyleBackColor = false;
    this.rtextIdVgsConfig.BackColor = SystemColors.Window;
    this.rtextIdVgsConfig.BorderStyle = BorderStyle.None;
    this.rtextIdVgsConfig.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.rtextIdVgsConfig.Location = new Point(14, 22);
    this.rtextIdVgsConfig.Name = "rtextIdVgsConfig";
    this.rtextIdVgsConfig.ReadOnly = true;
    this.rtextIdVgsConfig.Size = new Size(64 /*0x40*/, 58);
    this.rtextIdVgsConfig.TabIndex = 118;
    this.rtextIdVgsConfig.TabStop = false;
    this.rtextIdVgsConfig.Text = "Unknown";
    this.textMIdVgsTraces.BorderStyle = BorderStyle.FixedSingle;
    this.textMIdVgsTraces.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textMIdVgsTraces.Location = new Point(301, 62);
    this.textMIdVgsTraces.Name = "textMIdVgsTraces";
    this.textMIdVgsTraces.Size = new Size(46, 20);
    this.textMIdVgsTraces.TabIndex = 5;
    this.textMIdVgsTraces.Tag = (object) "Parameter";
    this.textMIdVgsTraces.Text = "unset";
    this.textMIdVgsTraces.TextAlign = HorizontalAlignment.Right;
    this.textMIdVgsTraces.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textMIdVgsVdsMax.BorderStyle = BorderStyle.FixedSingle;
    this.textMIdVgsVdsMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textMIdVgsVdsMax.Location = new Point(301, 34);
    this.textMIdVgsVdsMax.Name = "textMIdVgsVdsMax";
    this.textMIdVgsVdsMax.Size = new Size(46, 20);
    this.textMIdVgsVdsMax.TabIndex = 4;
    this.textMIdVgsVdsMax.Tag = (object) "Parameter";
    this.textMIdVgsVdsMax.Text = "unset";
    this.textMIdVgsVdsMax.TextAlign = HorizontalAlignment.Right;
    this.textMIdVgsVdsMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textMIdVgsVdsMin.BorderStyle = BorderStyle.FixedSingle;
    this.textMIdVgsVdsMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textMIdVgsVdsMin.Location = new Point(301, 6);
    this.textMIdVgsVdsMin.Name = "textMIdVgsVdsMin";
    this.textMIdVgsVdsMin.Size = new Size(46, 20);
    this.textMIdVgsVdsMin.TabIndex = 3;
    this.textMIdVgsVdsMin.Tag = (object) "Parameter";
    this.textMIdVgsVdsMin.Text = "unset";
    this.textMIdVgsVdsMin.TextAlign = HorizontalAlignment.Right;
    this.textMIdVgsVdsMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textMIdVgsPoints.BorderStyle = BorderStyle.FixedSingle;
    this.textMIdVgsPoints.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textMIdVgsPoints.Location = new Point(159, 62);
    this.textMIdVgsPoints.Name = "textMIdVgsPoints";
    this.textMIdVgsPoints.Size = new Size(46, 20);
    this.textMIdVgsPoints.TabIndex = 2;
    this.textMIdVgsPoints.Tag = (object) "Parameter";
    this.textMIdVgsPoints.Text = "unset";
    this.textMIdVgsPoints.TextAlign = HorizontalAlignment.Right;
    this.textMIdVgsPoints.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textMIdVgsVgsMax.BorderStyle = BorderStyle.FixedSingle;
    this.textMIdVgsVgsMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textMIdVgsVgsMax.Location = new Point(159, 34);
    this.textMIdVgsVgsMax.Name = "textMIdVgsVgsMax";
    this.textMIdVgsVgsMax.Size = new Size(46, 20);
    this.textMIdVgsVgsMax.TabIndex = 1;
    this.textMIdVgsVgsMax.Tag = (object) "Parameter";
    this.textMIdVgsVgsMax.Text = "unset";
    this.textMIdVgsVgsMax.TextAlign = HorizontalAlignment.Right;
    this.textMIdVgsVgsMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textMIdVgsVgsMin.BorderStyle = BorderStyle.FixedSingle;
    this.textMIdVgsVgsMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textMIdVgsVgsMin.Location = new Point(159, 6);
    this.textMIdVgsVgsMin.Name = "textMIdVgsVgsMin";
    this.textMIdVgsVgsMin.Size = new Size(46, 20);
    this.textMIdVgsVgsMin.TabIndex = 0;
    this.textMIdVgsVgsMin.Tag = (object) "Parameter";
    this.textMIdVgsVgsMin.Text = "unset";
    this.textMIdVgsVgsMin.TextAlign = HorizontalAlignment.Right;
    this.textMIdVgsVgsMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.butStartMIdVgs.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.butStartMIdVgs.Location = new Point(455, 59);
    this.butStartMIdVgs.Name = "butStartMIdVgs";
    this.butStartMIdVgs.Size = new Size(75, 23);
    this.butStartMIdVgs.TabIndex = 6;
    this.butStartMIdVgs.Text = "Start";
    this.butStartMIdVgs.UseVisualStyleBackColor = true;
    this.picMOSIdVgsCircuitSmall.Cursor = Cursors.Hand;
    this.picMOSIdVgsCircuitSmall.Dock = DockStyle.Right;
    this.picMOSIdVgsCircuitSmall.Image = (Image) Resources.cct_FET86;
    this.picMOSIdVgsCircuitSmall.InitialImage = (Image) null;
    this.picMOSIdVgsCircuitSmall.Location = new Point(689, 0);
    this.picMOSIdVgsCircuitSmall.Margin = new Padding(0);
    this.picMOSIdVgsCircuitSmall.Name = "picMOSIdVgsCircuitSmall";
    this.picMOSIdVgsCircuitSmall.Size = new Size(237, 92);
    this.picMOSIdVgsCircuitSmall.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picMOSIdVgsCircuitSmall.TabIndex = 55;
    this.picMOSIdVgsCircuitSmall.TabStop = false;
    this.picMOSIdVgsCircuitSmall.Tag = (object) "picMOSIdVgsCircuitLarge";
    this.picMOSIdVgsCircuitSmall.Click += new EventHandler(this.picCircuit_Click);
    this.tabIcVce.Controls.Add((Control) this.picBJTIcVceCircuitLarge);
    this.tabIcVce.Controls.Add((Control) this.zedGraphIcVce);
    this.tabIcVce.Controls.Add((Control) this.panelIcVce);
    this.tabIcVce.Location = new Point(4, 22);
    this.tabIcVce.Name = "tabIcVce";
    this.tabIcVce.Size = new Size(926, 440);
    this.tabIcVce.TabIndex = 3;
    this.tabIcVce.Text = "BJT Ic / Vce";
    this.tabIcVce.UseVisualStyleBackColor = true;
    this.picBJTIcVceCircuitLarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.picBJTIcVceCircuitLarge.BorderStyle = BorderStyle.FixedSingle;
    this.picBJTIcVceCircuitLarge.Image = (Image) Resources.cct_TRANSISTOR126;
    this.picBJTIcVceCircuitLarge.InitialImage = (Image) null;
    this.picBJTIcVceCircuitLarge.Location = new Point(566, 168);
    this.picBJTIcVceCircuitLarge.Margin = new Padding(0);
    this.picBJTIcVceCircuitLarge.Name = "picBJTIcVceCircuitLarge";
    this.picBJTIcVceCircuitLarge.Size = new Size(349, 128 /*0x80*/);
    this.picBJTIcVceCircuitLarge.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picBJTIcVceCircuitLarge.TabIndex = 45;
    this.picBJTIcVceCircuitLarge.TabStop = false;
    this.picBJTIcVceCircuitLarge.Tag = (object) "";
    this.picBJTIcVceCircuitLarge.Visible = false;
    this.picBJTIcVceCircuitLarge.MouseLeave += new EventHandler(this.picCircuit_MouseLeave);
    ((Control) this.zedGraphIcVce).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.zedGraphIcVce.IsAntiAlias = true;
    ((Control) this.zedGraphIcVce).Location = new Point(0, 3);
    ((Control) this.zedGraphIcVce).Name = "zedGraphIcVce";
    this.zedGraphIcVce.ScrollGrace = 0.0;
    this.zedGraphIcVce.ScrollMaxX = 0.0;
    this.zedGraphIcVce.ScrollMaxY = 0.0;
    this.zedGraphIcVce.ScrollMaxY2 = 0.0;
    this.zedGraphIcVce.ScrollMinX = 0.0;
    this.zedGraphIcVce.ScrollMinY = 0.0;
    this.zedGraphIcVce.ScrollMinY2 = 0.0;
    ((Control) this.zedGraphIcVce).Size = new Size(858, 293);
    ((Control) this.zedGraphIcVce).TabIndex = 9;
    this.panelIcVce.Controls.Add((Control) this.butAutosetIcVce);
    this.panelIcVce.Controls.Add((Control) this.rtextIcVceConfig);
    this.panelIcVce.Controls.Add((Control) label10);
    this.panelIcVce.Controls.Add((Control) this.textIcVceVcMin);
    this.panelIcVce.Controls.Add((Control) this.checkIcVceLockParameters);
    this.panelIcVce.Controls.Add((Control) label11);
    this.panelIcVce.Controls.Add((Control) label12);
    this.panelIcVce.Controls.Add((Control) label13);
    this.panelIcVce.Controls.Add((Control) this.textIcVceBaseTraces);
    this.panelIcVce.Controls.Add((Control) this.textIcVceBaseuIMax);
    this.panelIcVce.Controls.Add((Control) this.textIcVceBaseuIMin);
    this.panelIcVce.Controls.Add((Control) label14);
    this.panelIcVce.Controls.Add((Control) label15);
    this.panelIcVce.Controls.Add((Control) label16);
    this.panelIcVce.Controls.Add((Control) label17);
    this.panelIcVce.Controls.Add((Control) label18);
    this.panelIcVce.Controls.Add((Control) this.textIcVcePoints);
    this.panelIcVce.Controls.Add((Control) this.textIcVceVcMax);
    this.panelIcVce.Controls.Add((Control) label19);
    this.panelIcVce.Controls.Add((Control) label20);
    this.panelIcVce.Controls.Add((Control) label21);
    this.panelIcVce.Controls.Add((Control) this.butStartIcVce);
    this.panelIcVce.Controls.Add((Control) label22);
    this.panelIcVce.Controls.Add((Control) this.picBJTIcVceCircuitSmall);
    this.panelIcVce.Dock = DockStyle.Bottom;
    this.panelIcVce.Location = new Point(0, 348);
    this.panelIcVce.MinimumSize = new Size(890, 0);
    this.panelIcVce.Name = "panelIcVce";
    rectanglePlus7.Color = SystemColors.ControlDark;
    rectanglePlus7.Rectangle = new Rectangle(84, 1, 360, 86);
    this.panelIcVce.Rectangles = new GraphPanel.RectanglePlus[1]
    {
      rectanglePlus7
    };
    this.panelIcVce.Size = new Size(926, 92);
    this.panelIcVce.TabIndex = 46;
    this.butAutosetIcVce.Location = new Point(378, 59);
    this.butAutosetIcVce.Name = "butAutosetIcVce";
    this.butAutosetIcVce.Size = new Size(54, 23);
    this.butAutosetIcVce.TabIndex = 8;
    this.butAutosetIcVce.Tag = (object) "Parameter";
    this.butAutosetIcVce.Text = "Autoset";
    this.butAutosetIcVce.UseVisualStyleBackColor = true;
    this.rtextIcVceConfig.BackColor = SystemColors.Window;
    this.rtextIcVceConfig.BorderStyle = BorderStyle.None;
    this.rtextIcVceConfig.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.rtextIcVceConfig.Location = new Point(14, 22);
    this.rtextIcVceConfig.Name = "rtextIcVceConfig";
    this.rtextIcVceConfig.ReadOnly = true;
    this.rtextIcVceConfig.Size = new Size(64 /*0x40*/, 58);
    this.rtextIcVceConfig.TabIndex = 117;
    this.rtextIcVceConfig.TabStop = false;
    this.rtextIcVceConfig.Text = "Unknown";
    this.textIcVceVcMin.BackColor = SystemColors.Window;
    this.textIcVceVcMin.BorderStyle = BorderStyle.FixedSingle;
    this.textIcVceVcMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcVceVcMin.Location = new Point(159, 6);
    this.textIcVceVcMin.Name = "textIcVceVcMin";
    this.textIcVceVcMin.Size = new Size(46, 20);
    this.textIcVceVcMin.TabIndex = 0;
    this.textIcVceVcMin.Tag = (object) "Parameter";
    this.textIcVceVcMin.Text = "unset";
    this.textIcVceVcMin.TextAlign = HorizontalAlignment.Right;
    this.textIcVceVcMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.checkIcVceLockParameters.AutoSize = true;
    this.checkIcVceLockParameters.BackColor = Color.Transparent;
    this.checkIcVceLockParameters.Location = new Point(387, 13);
    this.checkIcVceLockParameters.Name = "checkIcVceLockParameters";
    this.checkIcVceLockParameters.RightToLeft = RightToLeft.No;
    this.checkIcVceLockParameters.Size = new Size(49, 18);
    this.checkIcVceLockParameters.TabIndex = 7;
    this.checkIcVceLockParameters.Text = "Lock";
    this.checkIcVceLockParameters.UseVisualStyleBackColor = false;
    this.textIcVceBaseTraces.BackColor = SystemColors.Window;
    this.textIcVceBaseTraces.BorderStyle = BorderStyle.FixedSingle;
    this.textIcVceBaseTraces.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcVceBaseTraces.Location = new Point(301, 62);
    this.textIcVceBaseTraces.Name = "textIcVceBaseTraces";
    this.textIcVceBaseTraces.Size = new Size(46, 20);
    this.textIcVceBaseTraces.TabIndex = 5;
    this.textIcVceBaseTraces.Tag = (object) "Parameter";
    this.textIcVceBaseTraces.Text = "unset";
    this.textIcVceBaseTraces.TextAlign = HorizontalAlignment.Right;
    this.textIcVceBaseTraces.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIcVceBaseuIMax.BackColor = SystemColors.Window;
    this.textIcVceBaseuIMax.BorderStyle = BorderStyle.FixedSingle;
    this.textIcVceBaseuIMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcVceBaseuIMax.Location = new Point(301, 34);
    this.textIcVceBaseuIMax.Name = "textIcVceBaseuIMax";
    this.textIcVceBaseuIMax.Size = new Size(46, 20);
    this.textIcVceBaseuIMax.TabIndex = 4;
    this.textIcVceBaseuIMax.Tag = (object) "Parameter";
    this.textIcVceBaseuIMax.Text = "unset";
    this.textIcVceBaseuIMax.TextAlign = HorizontalAlignment.Right;
    this.textIcVceBaseuIMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIcVceBaseuIMin.BackColor = SystemColors.Window;
    this.textIcVceBaseuIMin.BorderStyle = BorderStyle.FixedSingle;
    this.textIcVceBaseuIMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcVceBaseuIMin.Location = new Point(301, 6);
    this.textIcVceBaseuIMin.Name = "textIcVceBaseuIMin";
    this.textIcVceBaseuIMin.Size = new Size(46, 20);
    this.textIcVceBaseuIMin.TabIndex = 3;
    this.textIcVceBaseuIMin.Tag = (object) "Parameter";
    this.textIcVceBaseuIMin.Text = "unset";
    this.textIcVceBaseuIMin.TextAlign = HorizontalAlignment.Right;
    this.textIcVceBaseuIMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIcVcePoints.BackColor = SystemColors.Window;
    this.textIcVcePoints.BorderStyle = BorderStyle.FixedSingle;
    this.textIcVcePoints.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcVcePoints.Location = new Point(159, 62);
    this.textIcVcePoints.Name = "textIcVcePoints";
    this.textIcVcePoints.Size = new Size(46, 20);
    this.textIcVcePoints.TabIndex = 2;
    this.textIcVcePoints.Tag = (object) "Parameter";
    this.textIcVcePoints.Text = "unset";
    this.textIcVcePoints.TextAlign = HorizontalAlignment.Right;
    this.textIcVcePoints.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIcVceVcMax.BackColor = SystemColors.Window;
    this.textIcVceVcMax.BorderStyle = BorderStyle.FixedSingle;
    this.textIcVceVcMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcVceVcMax.ForeColor = SystemColors.WindowText;
    this.textIcVceVcMax.Location = new Point(159, 34);
    this.textIcVceVcMax.Name = "textIcVceVcMax";
    this.textIcVceVcMax.Size = new Size(46, 20);
    this.textIcVceVcMax.TabIndex = 1;
    this.textIcVceVcMax.Tag = (object) "Parameter";
    this.textIcVceVcMax.Text = "unset";
    this.textIcVceVcMax.TextAlign = HorizontalAlignment.Right;
    this.textIcVceVcMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.butStartIcVce.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.butStartIcVce.Location = new Point(455, 59);
    this.butStartIcVce.Name = "butStartIcVce";
    this.butStartIcVce.Size = new Size(75, 23);
    this.butStartIcVce.TabIndex = 6;
    this.butStartIcVce.Text = "Start";
    this.butStartIcVce.UseVisualStyleBackColor = true;
    this.picBJTIcVceCircuitSmall.Cursor = Cursors.Hand;
    this.picBJTIcVceCircuitSmall.Dock = DockStyle.Right;
    this.picBJTIcVceCircuitSmall.Image = (Image) Resources.cct_TRANSISTOR86;
    this.picBJTIcVceCircuitSmall.InitialImage = (Image) null;
    this.picBJTIcVceCircuitSmall.Location = new Point(689, 0);
    this.picBJTIcVceCircuitSmall.Margin = new Padding(0);
    this.picBJTIcVceCircuitSmall.Name = "picBJTIcVceCircuitSmall";
    this.picBJTIcVceCircuitSmall.Size = new Size(237, 92);
    this.picBJTIcVceCircuitSmall.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picBJTIcVceCircuitSmall.TabIndex = 116;
    this.picBJTIcVceCircuitSmall.TabStop = false;
    this.picBJTIcVceCircuitSmall.Tag = (object) "picBJTIcVceCircuitLarge";
    this.picBJTIcVceCircuitSmall.Click += new EventHandler(this.picCircuit_Click);
    this.tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.tabControl.Controls.Add((Control) this.tabIdentify);
    this.tabControl.Controls.Add((Control) this.tabPNTest);
    this.tabControl.Controls.Add((Control) this.tabIcVce);
    this.tabControl.Controls.Add((Control) this.tabHfeVce);
    this.tabControl.Controls.Add((Control) this.tabHfeIc);
    this.tabControl.Controls.Add((Control) this.tabIcVbe);
    this.tabControl.Controls.Add((Control) this.tabIcIb);
    this.tabControl.Controls.Add((Control) this.tabFIdVds);
    this.tabControl.Controls.Add((Control) this.tabFIdVgs);
    this.tabControl.Controls.Add((Control) this.tabTIcVce);
    this.tabControl.Controls.Add((Control) this.tabTIcVge);
    this.tabControl.Controls.Add((Control) this.tabJIdVds);
    this.tabControl.Controls.Add((Control) this.tabJIdVgs);
    this.tabControl.Controls.Add((Control) this.tabVRegTest);
    this.tabControl.Location = new Point(0, 24);
    this.tabControl.Name = "tabControl";
    this.tabControl.SelectedIndex = 0;
    this.tabControl.Size = new Size(934, 466);
    this.tabControl.TabIndex = 1;
    this.tabControl.SelectedIndexChanged += new EventHandler(this.TestTabs_SelectedIndexChanged);
    this.tabHfeVce.Controls.Add((Control) this.picBJTHfeVceCircuitLarge);
    this.tabHfeVce.Controls.Add((Control) this.zedGraphHfeVce);
    this.tabHfeVce.Controls.Add((Control) this.panelHFEVce);
    this.tabHfeVce.Location = new Point(4, 22);
    this.tabHfeVce.Name = "tabHfeVce";
    this.tabHfeVce.Size = new Size(926, 440);
    this.tabHfeVce.TabIndex = 15;
    this.tabHfeVce.Text = "BJT hFE / Vce";
    this.tabHfeVce.UseVisualStyleBackColor = true;
    this.picBJTHfeVceCircuitLarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.picBJTHfeVceCircuitLarge.BorderStyle = BorderStyle.FixedSingle;
    this.picBJTHfeVceCircuitLarge.Image = (Image) Resources.cct_TRANSISTORHFE126;
    this.picBJTHfeVceCircuitLarge.InitialImage = (Image) null;
    this.picBJTHfeVceCircuitLarge.Location = new Point(556, 181);
    this.picBJTHfeVceCircuitLarge.Margin = new Padding(0);
    this.picBJTHfeVceCircuitLarge.Name = "picBJTHfeVceCircuitLarge";
    this.picBJTHfeVceCircuitLarge.Size = new Size(349, 128 /*0x80*/);
    this.picBJTHfeVceCircuitLarge.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picBJTHfeVceCircuitLarge.TabIndex = 45;
    this.picBJTHfeVceCircuitLarge.TabStop = false;
    this.picBJTHfeVceCircuitLarge.Tag = (object) "";
    this.picBJTHfeVceCircuitLarge.Visible = false;
    this.picBJTHfeVceCircuitLarge.MouseLeave += new EventHandler(this.picCircuit_MouseLeave);
    ((Control) this.zedGraphHfeVce).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.zedGraphHfeVce.IsAntiAlias = true;
    ((Control) this.zedGraphHfeVce).Location = new Point(3, 3);
    ((Control) this.zedGraphHfeVce).Name = "zedGraphHfeVce";
    this.zedGraphHfeVce.ScrollGrace = 0.0;
    this.zedGraphHfeVce.ScrollMaxX = 0.0;
    this.zedGraphHfeVce.ScrollMaxY = 0.0;
    this.zedGraphHfeVce.ScrollMaxY2 = 0.0;
    this.zedGraphHfeVce.ScrollMinX = 0.0;
    this.zedGraphHfeVce.ScrollMinY = 0.0;
    this.zedGraphHfeVce.ScrollMinY2 = 0.0;
    ((Control) this.zedGraphHfeVce).Size = new Size(760, 263);
    ((Control) this.zedGraphHfeVce).TabIndex = 9;
    this.panelHFEVce.BackColor = Color.Transparent;
    this.panelHFEVce.Controls.Add((Control) this.butAutosetHfeVce);
    this.panelHFEVce.Controls.Add((Control) label23);
    this.panelHFEVce.Controls.Add((Control) label24);
    this.panelHFEVce.Controls.Add((Control) label25);
    this.panelHFEVce.Controls.Add((Control) label26);
    this.panelHFEVce.Controls.Add((Control) label27);
    this.panelHFEVce.Controls.Add((Control) label28);
    this.panelHFEVce.Controls.Add((Control) label29);
    this.panelHFEVce.Controls.Add((Control) label30);
    this.panelHFEVce.Controls.Add((Control) label31);
    this.panelHFEVce.Controls.Add((Control) label32);
    this.panelHFEVce.Controls.Add((Control) label33);
    this.panelHFEVce.Controls.Add((Control) label34);
    this.panelHFEVce.Controls.Add((Control) this.checkHfeVceLockParameters);
    this.panelHFEVce.Controls.Add((Control) this.rtextHfeVceConfig);
    this.panelHFEVce.Controls.Add((Control) this.textHfeVceBaseTraces);
    this.panelHFEVce.Controls.Add((Control) this.textHfeVceBaseuIMax);
    this.panelHFEVce.Controls.Add((Control) this.textHfeVceBaseuIMin);
    this.panelHFEVce.Controls.Add((Control) this.textHfeVcePoints);
    this.panelHFEVce.Controls.Add((Control) this.textHfeVceVcMax);
    this.panelHFEVce.Controls.Add((Control) this.textHfeVceVcMin);
    this.panelHFEVce.Controls.Add((Control) this.butStartHfeVce);
    this.panelHFEVce.Controls.Add((Control) label35);
    this.panelHFEVce.Controls.Add((Control) this.picBJTHfeVceCircuitSmall);
    this.panelHFEVce.Dock = DockStyle.Bottom;
    this.panelHFEVce.Location = new Point(0, 348);
    this.panelHFEVce.MinimumSize = new Size(890, 0);
    this.panelHFEVce.Name = "panelHFEVce";
    rectanglePlus8.Color = SystemColors.ControlDark;
    rectanglePlus8.Rectangle = new Rectangle(84, 1, 360, 86);
    this.panelHFEVce.Rectangles = new GraphPanel.RectanglePlus[1]
    {
      rectanglePlus8
    };
    this.panelHFEVce.Size = new Size(926, 92);
    this.panelHFEVce.TabIndex = 44;
    this.butAutosetHfeVce.Location = new Point(378, 59);
    this.butAutosetHfeVce.Name = "butAutosetHfeVce";
    this.butAutosetHfeVce.Size = new Size(54, 23);
    this.butAutosetHfeVce.TabIndex = 8;
    this.butAutosetHfeVce.Tag = (object) "Parameter";
    this.butAutosetHfeVce.Text = "Autoset";
    this.butAutosetHfeVce.UseVisualStyleBackColor = true;
    this.checkHfeVceLockParameters.AutoSize = true;
    this.checkHfeVceLockParameters.BackColor = Color.Transparent;
    this.checkHfeVceLockParameters.Location = new Point(387, 13);
    this.checkHfeVceLockParameters.Name = "checkHfeVceLockParameters";
    this.checkHfeVceLockParameters.RightToLeft = RightToLeft.No;
    this.checkHfeVceLockParameters.Size = new Size(49, 18);
    this.checkHfeVceLockParameters.TabIndex = 7;
    this.checkHfeVceLockParameters.Text = "Lock";
    this.checkHfeVceLockParameters.UseVisualStyleBackColor = false;
    this.rtextHfeVceConfig.BackColor = SystemColors.Window;
    this.rtextHfeVceConfig.BorderStyle = BorderStyle.None;
    this.rtextHfeVceConfig.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.rtextHfeVceConfig.Location = new Point(14, 22);
    this.rtextHfeVceConfig.Name = "rtextHfeVceConfig";
    this.rtextHfeVceConfig.ReadOnly = true;
    this.rtextHfeVceConfig.Size = new Size(64 /*0x40*/, 58);
    this.rtextHfeVceConfig.TabIndex = 118;
    this.rtextHfeVceConfig.TabStop = false;
    this.rtextHfeVceConfig.Text = "Unknown";
    this.textHfeVceBaseTraces.BorderStyle = BorderStyle.FixedSingle;
    this.textHfeVceBaseTraces.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textHfeVceBaseTraces.Location = new Point(301, 62);
    this.textHfeVceBaseTraces.Name = "textHfeVceBaseTraces";
    this.textHfeVceBaseTraces.Size = new Size(46, 20);
    this.textHfeVceBaseTraces.TabIndex = 5;
    this.textHfeVceBaseTraces.Tag = (object) "Parameter";
    this.textHfeVceBaseTraces.Text = "unset";
    this.textHfeVceBaseTraces.TextAlign = HorizontalAlignment.Right;
    this.textHfeVceBaseTraces.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textHfeVceBaseuIMax.BorderStyle = BorderStyle.FixedSingle;
    this.textHfeVceBaseuIMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textHfeVceBaseuIMax.Location = new Point(301, 34);
    this.textHfeVceBaseuIMax.Name = "textHfeVceBaseuIMax";
    this.textHfeVceBaseuIMax.Size = new Size(46, 20);
    this.textHfeVceBaseuIMax.TabIndex = 4;
    this.textHfeVceBaseuIMax.Tag = (object) "Parameter";
    this.textHfeVceBaseuIMax.Text = "unset";
    this.textHfeVceBaseuIMax.TextAlign = HorizontalAlignment.Right;
    this.textHfeVceBaseuIMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textHfeVceBaseuIMin.BorderStyle = BorderStyle.FixedSingle;
    this.textHfeVceBaseuIMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textHfeVceBaseuIMin.Location = new Point(301, 6);
    this.textHfeVceBaseuIMin.Name = "textHfeVceBaseuIMin";
    this.textHfeVceBaseuIMin.Size = new Size(46, 20);
    this.textHfeVceBaseuIMin.TabIndex = 3;
    this.textHfeVceBaseuIMin.Tag = (object) "Parameter";
    this.textHfeVceBaseuIMin.Text = "unset";
    this.textHfeVceBaseuIMin.TextAlign = HorizontalAlignment.Right;
    this.textHfeVceBaseuIMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textHfeVcePoints.BorderStyle = BorderStyle.FixedSingle;
    this.textHfeVcePoints.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textHfeVcePoints.Location = new Point(159, 62);
    this.textHfeVcePoints.Name = "textHfeVcePoints";
    this.textHfeVcePoints.Size = new Size(46, 20);
    this.textHfeVcePoints.TabIndex = 2;
    this.textHfeVcePoints.Tag = (object) "Parameter";
    this.textHfeVcePoints.Text = "unset";
    this.textHfeVcePoints.TextAlign = HorizontalAlignment.Right;
    this.textHfeVcePoints.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textHfeVceVcMax.BorderStyle = BorderStyle.FixedSingle;
    this.textHfeVceVcMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textHfeVceVcMax.Location = new Point(159, 34);
    this.textHfeVceVcMax.Name = "textHfeVceVcMax";
    this.textHfeVceVcMax.Size = new Size(46, 20);
    this.textHfeVceVcMax.TabIndex = 1;
    this.textHfeVceVcMax.Tag = (object) "Parameter";
    this.textHfeVceVcMax.Text = "unset";
    this.textHfeVceVcMax.TextAlign = HorizontalAlignment.Right;
    this.textHfeVceVcMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textHfeVceVcMin.BorderStyle = BorderStyle.FixedSingle;
    this.textHfeVceVcMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textHfeVceVcMin.Location = new Point(159, 6);
    this.textHfeVceVcMin.Name = "textHfeVceVcMin";
    this.textHfeVceVcMin.Size = new Size(46, 20);
    this.textHfeVceVcMin.TabIndex = 0;
    this.textHfeVceVcMin.Tag = (object) "Parameter";
    this.textHfeVceVcMin.Text = "unset";
    this.textHfeVceVcMin.TextAlign = HorizontalAlignment.Right;
    this.textHfeVceVcMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.butStartHfeVce.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.butStartHfeVce.Location = new Point(455, 59);
    this.butStartHfeVce.Name = "butStartHfeVce";
    this.butStartHfeVce.Size = new Size(75, 23);
    this.butStartHfeVce.TabIndex = 6;
    this.butStartHfeVce.Text = "Start";
    this.butStartHfeVce.UseVisualStyleBackColor = true;
    this.picBJTHfeVceCircuitSmall.Cursor = Cursors.Hand;
    this.picBJTHfeVceCircuitSmall.Dock = DockStyle.Right;
    this.picBJTHfeVceCircuitSmall.Image = (Image) Resources.cct_TRANSISTORHFE86;
    this.picBJTHfeVceCircuitSmall.InitialImage = (Image) null;
    this.picBJTHfeVceCircuitSmall.Location = new Point(689, 0);
    this.picBJTHfeVceCircuitSmall.Margin = new Padding(0);
    this.picBJTHfeVceCircuitSmall.Name = "picBJTHfeVceCircuitSmall";
    this.picBJTHfeVceCircuitSmall.Size = new Size(237, 92);
    this.picBJTHfeVceCircuitSmall.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picBJTHfeVceCircuitSmall.TabIndex = 46;
    this.picBJTHfeVceCircuitSmall.TabStop = false;
    this.picBJTHfeVceCircuitSmall.Tag = (object) "picBJTHfeVceCircuitLarge";
    this.picBJTHfeVceCircuitSmall.Click += new EventHandler(this.picCircuit_Click);
    this.tabHfeIc.Controls.Add((Control) this.picBJTHfeIcCircuitLarge);
    this.tabHfeIc.Controls.Add((Control) this.zedGraphHfeIc);
    this.tabHfeIc.Controls.Add((Control) this.panelHFEIc);
    this.tabHfeIc.Location = new Point(4, 22);
    this.tabHfeIc.Name = "tabHfeIc";
    this.tabHfeIc.Size = new Size(926, 440);
    this.tabHfeIc.TabIndex = 14;
    this.tabHfeIc.Text = "BJT hFE / Ic";
    this.tabHfeIc.UseVisualStyleBackColor = true;
    this.picBJTHfeIcCircuitLarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.picBJTHfeIcCircuitLarge.BorderStyle = BorderStyle.FixedSingle;
    this.picBJTHfeIcCircuitLarge.Image = (Image) Resources.cct_TRANSISTORHFE126;
    this.picBJTHfeIcCircuitLarge.InitialImage = (Image) null;
    this.picBJTHfeIcCircuitLarge.Location = new Point(566, 184);
    this.picBJTHfeIcCircuitLarge.Margin = new Padding(0);
    this.picBJTHfeIcCircuitLarge.Name = "picBJTHfeIcCircuitLarge";
    this.picBJTHfeIcCircuitLarge.Size = new Size(349, 128 /*0x80*/);
    this.picBJTHfeIcCircuitLarge.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picBJTHfeIcCircuitLarge.TabIndex = 45;
    this.picBJTHfeIcCircuitLarge.TabStop = false;
    this.picBJTHfeIcCircuitLarge.Tag = (object) "";
    this.picBJTHfeIcCircuitLarge.Visible = false;
    this.picBJTHfeIcCircuitLarge.MouseLeave += new EventHandler(this.picCircuit_MouseLeave);
    ((Control) this.zedGraphHfeIc).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.zedGraphHfeIc.IsAntiAlias = true;
    ((Control) this.zedGraphHfeIc).Location = new Point(3, 3);
    ((Control) this.zedGraphHfeIc).Name = "zedGraphHfeIc";
    this.zedGraphHfeIc.ScrollGrace = 0.0;
    this.zedGraphHfeIc.ScrollMaxX = 0.0;
    this.zedGraphHfeIc.ScrollMaxY = 0.0;
    this.zedGraphHfeIc.ScrollMaxY2 = 0.0;
    this.zedGraphHfeIc.ScrollMinX = 0.0;
    this.zedGraphHfeIc.ScrollMinY = 0.0;
    this.zedGraphHfeIc.ScrollMinY2 = 0.0;
    ((Control) this.zedGraphHfeIc).Size = new Size(760, 269);
    ((Control) this.zedGraphHfeIc).TabIndex = 9;
    this.panelHFEIc.Controls.Add((Control) this.butAutosetHfeIc);
    this.panelHFEIc.Controls.Add((Control) this.checkHfeIcLockParameters);
    this.panelHFEIc.Controls.Add((Control) this.rtextHfeIcConfig);
    this.panelHFEIc.Controls.Add((Control) label36);
    this.panelHFEIc.Controls.Add((Control) label37);
    this.panelHFEIc.Controls.Add((Control) label38);
    this.panelHFEIc.Controls.Add((Control) label39);
    this.panelHFEIc.Controls.Add((Control) this.textHfeIcTraces);
    this.panelHFEIc.Controls.Add((Control) this.textHfeIcBaseuIMax);
    this.panelHFEIc.Controls.Add((Control) this.textHfeIcBaseuIMin);
    this.panelHFEIc.Controls.Add((Control) label40);
    this.panelHFEIc.Controls.Add((Control) label41);
    this.panelHFEIc.Controls.Add((Control) label42);
    this.panelHFEIc.Controls.Add((Control) label43);
    this.panelHFEIc.Controls.Add((Control) label44);
    this.panelHFEIc.Controls.Add((Control) this.textHfeIcPoints);
    this.panelHFEIc.Controls.Add((Control) this.textHfeIcVcMax);
    this.panelHFEIc.Controls.Add((Control) this.textHfeIcVcMin);
    this.panelHFEIc.Controls.Add((Control) label45);
    this.panelHFEIc.Controls.Add((Control) label46);
    this.panelHFEIc.Controls.Add((Control) label47);
    this.panelHFEIc.Controls.Add((Control) this.butStartHfeIc);
    this.panelHFEIc.Controls.Add((Control) label48);
    this.panelHFEIc.Controls.Add((Control) this.picBJTHfeIcCircuitSmall);
    this.panelHFEIc.Dock = DockStyle.Bottom;
    this.panelHFEIc.Location = new Point(0, 348);
    this.panelHFEIc.MinimumSize = new Size(890, 0);
    this.panelHFEIc.Name = "panelHFEIc";
    rectanglePlus9.Color = SystemColors.ControlDark;
    rectanglePlus9.Rectangle = new Rectangle(84, 1, 360, 86);
    this.panelHFEIc.Rectangles = new GraphPanel.RectanglePlus[1]
    {
      rectanglePlus9
    };
    this.panelHFEIc.Size = new Size(926, 92);
    this.panelHFEIc.TabIndex = 43;
    this.butAutosetHfeIc.Location = new Point(378, 59);
    this.butAutosetHfeIc.Name = "butAutosetHfeIc";
    this.butAutosetHfeIc.Size = new Size(54, 23);
    this.butAutosetHfeIc.TabIndex = 8;
    this.butAutosetHfeIc.Tag = (object) "Parameter";
    this.butAutosetHfeIc.Text = "Autoset";
    this.butAutosetHfeIc.UseVisualStyleBackColor = true;
    this.checkHfeIcLockParameters.AutoSize = true;
    this.checkHfeIcLockParameters.BackColor = Color.Transparent;
    this.checkHfeIcLockParameters.Location = new Point(387, 13);
    this.checkHfeIcLockParameters.Name = "checkHfeIcLockParameters";
    this.checkHfeIcLockParameters.RightToLeft = RightToLeft.No;
    this.checkHfeIcLockParameters.Size = new Size(49, 18);
    this.checkHfeIcLockParameters.TabIndex = 7;
    this.checkHfeIcLockParameters.Text = "Lock";
    this.checkHfeIcLockParameters.UseVisualStyleBackColor = false;
    this.rtextHfeIcConfig.BackColor = SystemColors.Window;
    this.rtextHfeIcConfig.BorderStyle = BorderStyle.None;
    this.rtextHfeIcConfig.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.rtextHfeIcConfig.Location = new Point(14, 22);
    this.rtextHfeIcConfig.Name = "rtextHfeIcConfig";
    this.rtextHfeIcConfig.ReadOnly = true;
    this.rtextHfeIcConfig.Size = new Size(64 /*0x40*/, 58);
    this.rtextHfeIcConfig.TabIndex = 118;
    this.rtextHfeIcConfig.TabStop = false;
    this.rtextHfeIcConfig.Text = "Unknown";
    this.textHfeIcTraces.BorderStyle = BorderStyle.FixedSingle;
    this.textHfeIcTraces.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textHfeIcTraces.Location = new Point(301, 62);
    this.textHfeIcTraces.Name = "textHfeIcTraces";
    this.textHfeIcTraces.Size = new Size(46, 20);
    this.textHfeIcTraces.TabIndex = 5;
    this.textHfeIcTraces.Tag = (object) "Parameter";
    this.textHfeIcTraces.Text = "unset";
    this.textHfeIcTraces.TextAlign = HorizontalAlignment.Right;
    this.textHfeIcTraces.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textHfeIcBaseuIMax.BorderStyle = BorderStyle.FixedSingle;
    this.textHfeIcBaseuIMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textHfeIcBaseuIMax.Location = new Point(159, 34);
    this.textHfeIcBaseuIMax.Name = "textHfeIcBaseuIMax";
    this.textHfeIcBaseuIMax.Size = new Size(46, 20);
    this.textHfeIcBaseuIMax.TabIndex = 1;
    this.textHfeIcBaseuIMax.Tag = (object) "Parameter";
    this.textHfeIcBaseuIMax.Text = "unset";
    this.textHfeIcBaseuIMax.TextAlign = HorizontalAlignment.Right;
    this.textHfeIcBaseuIMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textHfeIcBaseuIMin.BorderStyle = BorderStyle.FixedSingle;
    this.textHfeIcBaseuIMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textHfeIcBaseuIMin.Location = new Point(159, 6);
    this.textHfeIcBaseuIMin.Name = "textHfeIcBaseuIMin";
    this.textHfeIcBaseuIMin.Size = new Size(46, 20);
    this.textHfeIcBaseuIMin.TabIndex = 0;
    this.textHfeIcBaseuIMin.Tag = (object) "Parameter";
    this.textHfeIcBaseuIMin.Text = "unset";
    this.textHfeIcBaseuIMin.TextAlign = HorizontalAlignment.Right;
    this.textHfeIcBaseuIMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textHfeIcPoints.BorderStyle = BorderStyle.FixedSingle;
    this.textHfeIcPoints.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textHfeIcPoints.Location = new Point(159, 62);
    this.textHfeIcPoints.Name = "textHfeIcPoints";
    this.textHfeIcPoints.Size = new Size(46, 20);
    this.textHfeIcPoints.TabIndex = 2;
    this.textHfeIcPoints.Tag = (object) "Parameter";
    this.textHfeIcPoints.Text = "unset";
    this.textHfeIcPoints.TextAlign = HorizontalAlignment.Right;
    this.textHfeIcPoints.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textHfeIcVcMax.BorderStyle = BorderStyle.FixedSingle;
    this.textHfeIcVcMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textHfeIcVcMax.Location = new Point(301, 34);
    this.textHfeIcVcMax.Name = "textHfeIcVcMax";
    this.textHfeIcVcMax.Size = new Size(46, 20);
    this.textHfeIcVcMax.TabIndex = 4;
    this.textHfeIcVcMax.Tag = (object) "Parameter";
    this.textHfeIcVcMax.Text = "unset";
    this.textHfeIcVcMax.TextAlign = HorizontalAlignment.Right;
    this.textHfeIcVcMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textHfeIcVcMin.BorderStyle = BorderStyle.FixedSingle;
    this.textHfeIcVcMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textHfeIcVcMin.Location = new Point(301, 6);
    this.textHfeIcVcMin.Name = "textHfeIcVcMin";
    this.textHfeIcVcMin.Size = new Size(46, 20);
    this.textHfeIcVcMin.TabIndex = 3;
    this.textHfeIcVcMin.Tag = (object) "Parameter";
    this.textHfeIcVcMin.Text = "unset";
    this.textHfeIcVcMin.TextAlign = HorizontalAlignment.Right;
    this.textHfeIcVcMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.butStartHfeIc.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.butStartHfeIc.Location = new Point(455, 59);
    this.butStartHfeIc.Name = "butStartHfeIc";
    this.butStartHfeIc.Size = new Size(75, 23);
    this.butStartHfeIc.TabIndex = 6;
    this.butStartHfeIc.Text = "Start";
    this.butStartHfeIc.UseVisualStyleBackColor = true;
    this.picBJTHfeIcCircuitSmall.Cursor = Cursors.Hand;
    this.picBJTHfeIcCircuitSmall.Dock = DockStyle.Right;
    this.picBJTHfeIcCircuitSmall.Image = (Image) Resources.cct_TRANSISTORHFE86;
    this.picBJTHfeIcCircuitSmall.InitialImage = (Image) null;
    this.picBJTHfeIcCircuitSmall.Location = new Point(689, 0);
    this.picBJTHfeIcCircuitSmall.Margin = new Padding(0);
    this.picBJTHfeIcCircuitSmall.Name = "picBJTHfeIcCircuitSmall";
    this.picBJTHfeIcCircuitSmall.Size = new Size(237, 92);
    this.picBJTHfeIcCircuitSmall.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picBJTHfeIcCircuitSmall.TabIndex = 46;
    this.picBJTHfeIcCircuitSmall.TabStop = false;
    this.picBJTHfeIcCircuitSmall.Tag = (object) "picBJTHfeIcCircuitLarge";
    this.picBJTHfeIcCircuitSmall.Click += new EventHandler(this.picCircuit_Click);
    this.tabIcVbe.Controls.Add((Control) this.picBJTIcVbeCircuitLarge);
    this.tabIcVbe.Controls.Add((Control) this.zedGraphIcVbe);
    this.tabIcVbe.Controls.Add((Control) this.panelIcVbe);
    this.tabIcVbe.Location = new Point(4, 22);
    this.tabIcVbe.Name = "tabIcVbe";
    this.tabIcVbe.Size = new Size(926, 440);
    this.tabIcVbe.TabIndex = 18;
    this.tabIcVbe.Text = "BJT Ic / Vbe";
    this.tabIcVbe.UseVisualStyleBackColor = true;
    this.picBJTIcVbeCircuitLarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.picBJTIcVbeCircuitLarge.BorderStyle = BorderStyle.FixedSingle;
    this.picBJTIcVbeCircuitLarge.Image = (Image) Resources.cct_TRANSISTOR126;
    this.picBJTIcVbeCircuitLarge.InitialImage = (Image) null;
    this.picBJTIcVbeCircuitLarge.Location = new Point(557, 182);
    this.picBJTIcVbeCircuitLarge.Margin = new Padding(0);
    this.picBJTIcVbeCircuitLarge.Name = "picBJTIcVbeCircuitLarge";
    this.picBJTIcVbeCircuitLarge.Size = new Size(349, 128 /*0x80*/);
    this.picBJTIcVbeCircuitLarge.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picBJTIcVbeCircuitLarge.TabIndex = 48 /*0x30*/;
    this.picBJTIcVbeCircuitLarge.TabStop = false;
    this.picBJTIcVbeCircuitLarge.Tag = (object) "";
    this.picBJTIcVbeCircuitLarge.Visible = false;
    this.picBJTIcVbeCircuitLarge.MouseLeave += new EventHandler(this.picCircuit_MouseLeave);
    ((Control) this.zedGraphIcVbe).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.zedGraphIcVbe.IsAntiAlias = true;
    ((Control) this.zedGraphIcVbe).Location = new Point(3, 3);
    ((Control) this.zedGraphIcVbe).Name = "zedGraphIcVbe";
    this.zedGraphIcVbe.ScrollGrace = 0.0;
    this.zedGraphIcVbe.ScrollMaxX = 0.0;
    this.zedGraphIcVbe.ScrollMaxY = 0.0;
    this.zedGraphIcVbe.ScrollMaxY2 = 0.0;
    this.zedGraphIcVbe.ScrollMinX = 0.0;
    this.zedGraphIcVbe.ScrollMinY = 0.0;
    this.zedGraphIcVbe.ScrollMinY2 = 0.0;
    ((Control) this.zedGraphIcVbe).Size = new Size(858, 289);
    ((Control) this.zedGraphIcVbe).TabIndex = 9;
    this.panelIcVbe.Controls.Add((Control) this.butAutosetIcVbe);
    this.panelIcVbe.Controls.Add((Control) this.rtextIcVbeConfig);
    this.panelIcVbe.Controls.Add((Control) this.label122);
    this.panelIcVbe.Controls.Add((Control) this.textIcVbeVbMin);
    this.panelIcVbe.Controls.Add((Control) this.checkIcVbeLockParameters);
    this.panelIcVbe.Controls.Add((Control) this.label135);
    this.panelIcVbe.Controls.Add((Control) this.label138);
    this.panelIcVbe.Controls.Add((Control) this.label139);
    this.panelIcVbe.Controls.Add((Control) this.textIcVbeTraces);
    this.panelIcVbe.Controls.Add((Control) this.textIcVbeVcMax);
    this.panelIcVbe.Controls.Add((Control) this.textIcVbeVcMin);
    this.panelIcVbe.Controls.Add((Control) this.label140);
    this.panelIcVbe.Controls.Add((Control) this.label141);
    this.panelIcVbe.Controls.Add((Control) this.label142);
    this.panelIcVbe.Controls.Add((Control) this.label143);
    this.panelIcVbe.Controls.Add((Control) this.label144);
    this.panelIcVbe.Controls.Add((Control) this.textIcVbePoints);
    this.panelIcVbe.Controls.Add((Control) this.textIcVbeVbMax);
    this.panelIcVbe.Controls.Add((Control) this.label145);
    this.panelIcVbe.Controls.Add((Control) this.label146);
    this.panelIcVbe.Controls.Add((Control) this.label147);
    this.panelIcVbe.Controls.Add((Control) this.butStartIcVbe);
    this.panelIcVbe.Controls.Add((Control) this.label148);
    this.panelIcVbe.Controls.Add((Control) this.picIcVbeCircuitSmall);
    this.panelIcVbe.Dock = DockStyle.Bottom;
    this.panelIcVbe.Location = new Point(0, 348);
    this.panelIcVbe.MinimumSize = new Size(890, 0);
    this.panelIcVbe.Name = "panelIcVbe";
    rectanglePlus10.Color = SystemColors.ControlDark;
    rectanglePlus10.Rectangle = new Rectangle(84, 1, 360, 86);
    this.panelIcVbe.Rectangles = new GraphPanel.RectanglePlus[1]
    {
      rectanglePlus10
    };
    this.panelIcVbe.Size = new Size(926, 92);
    this.panelIcVbe.TabIndex = 47;
    this.butAutosetIcVbe.Location = new Point(378, 59);
    this.butAutosetIcVbe.Name = "butAutosetIcVbe";
    this.butAutosetIcVbe.Size = new Size(54, 23);
    this.butAutosetIcVbe.TabIndex = 8;
    this.butAutosetIcVbe.Tag = (object) "Parameter";
    this.butAutosetIcVbe.Text = "Autoset";
    this.butAutosetIcVbe.UseVisualStyleBackColor = true;
    this.rtextIcVbeConfig.BackColor = SystemColors.Window;
    this.rtextIcVbeConfig.BorderStyle = BorderStyle.None;
    this.rtextIcVbeConfig.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.rtextIcVbeConfig.Location = new Point(14, 22);
    this.rtextIcVbeConfig.Name = "rtextIcVbeConfig";
    this.rtextIcVbeConfig.ReadOnly = true;
    this.rtextIcVbeConfig.Size = new Size(64 /*0x40*/, 58);
    this.rtextIcVbeConfig.TabIndex = 117;
    this.rtextIcVbeConfig.TabStop = false;
    this.rtextIcVbeConfig.Text = "Unknown";
    this.label122.AutoSize = true;
    this.label122.BackColor = Color.Transparent;
    this.label122.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.label122.Location = new Point(98, 34);
    this.label122.Name = "label122";
    this.label122.Size = new Size(35, 18);
    this.label122.TabIndex = 115;
    this.label122.Text = "Vbe";
    this.textIcVbeVbMin.BackColor = SystemColors.Control;
    this.textIcVbeVbMin.BorderStyle = BorderStyle.FixedSingle;
    this.textIcVbeVbMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcVbeVbMin.Location = new Point(159, 6);
    this.textIcVbeVbMin.Name = "textIcVbeVbMin";
    this.textIcVbeVbMin.Size = new Size(46, 20);
    this.textIcVbeVbMin.TabIndex = 0;
    this.textIcVbeVbMin.Tag = (object) "Parameter";
    this.textIcVbeVbMin.Text = "unset";
    this.textIcVbeVbMin.TextAlign = HorizontalAlignment.Right;
    this.checkIcVbeLockParameters.AutoSize = true;
    this.checkIcVbeLockParameters.BackColor = Color.Transparent;
    this.checkIcVbeLockParameters.Location = new Point(387, 13);
    this.checkIcVbeLockParameters.Name = "checkIcVbeLockParameters";
    this.checkIcVbeLockParameters.RightToLeft = RightToLeft.No;
    this.checkIcVbeLockParameters.Size = new Size(49, 18);
    this.checkIcVbeLockParameters.TabIndex = 7;
    this.checkIcVbeLockParameters.Text = "Lock";
    this.checkIcVbeLockParameters.UseVisualStyleBackColor = false;
    this.label135.AutoSize = true;
    this.label135.BackColor = Color.Transparent;
    this.label135.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.label135.Location = new Point(240 /*0xF0*/, 34);
    this.label135.Name = "label135";
    this.label135.Size = new Size(34, 18);
    this.label135.TabIndex = 113;
    this.label135.Text = "Vce";
    this.label138.AutoSize = true;
    this.label138.BackColor = Color.Transparent;
    this.label138.Location = new Point(351, 36);
    this.label138.Name = "label138";
    this.label138.Size = new Size(15, 14);
    this.label138.TabIndex = 112 /*0x70*/;
    this.label138.Text = "V";
    this.label139.AutoSize = true;
    this.label139.BackColor = Color.Transparent;
    this.label139.Location = new Point(351, 8);
    this.label139.Name = "label139";
    this.label139.Size = new Size(15, 14);
    this.label139.TabIndex = 111;
    this.label139.Text = "V";
    this.textIcVbeTraces.BackColor = SystemColors.Control;
    this.textIcVbeTraces.BorderStyle = BorderStyle.FixedSingle;
    this.textIcVbeTraces.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcVbeTraces.Location = new Point(301, 62);
    this.textIcVbeTraces.Name = "textIcVbeTraces";
    this.textIcVbeTraces.Size = new Size(46, 20);
    this.textIcVbeTraces.TabIndex = 5;
    this.textIcVbeTraces.Tag = (object) "Parameter";
    this.textIcVbeTraces.Text = "unset";
    this.textIcVbeTraces.TextAlign = HorizontalAlignment.Right;
    this.textIcVbeVcMax.BackColor = SystemColors.Control;
    this.textIcVbeVcMax.BorderStyle = BorderStyle.FixedSingle;
    this.textIcVbeVcMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcVbeVcMax.Location = new Point(301, 34);
    this.textIcVbeVcMax.Name = "textIcVbeVcMax";
    this.textIcVbeVcMax.Size = new Size(46, 20);
    this.textIcVbeVcMax.TabIndex = 4;
    this.textIcVbeVcMax.Tag = (object) "Parameter";
    this.textIcVbeVcMax.Text = "unset";
    this.textIcVbeVcMax.TextAlign = HorizontalAlignment.Right;
    this.textIcVbeVcMin.BackColor = SystemColors.Control;
    this.textIcVbeVcMin.BorderStyle = BorderStyle.FixedSingle;
    this.textIcVbeVcMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcVbeVcMin.Location = new Point(301, 6);
    this.textIcVbeVcMin.Name = "textIcVbeVcMin";
    this.textIcVbeVcMin.Size = new Size(46, 20);
    this.textIcVbeVcMin.TabIndex = 3;
    this.textIcVbeVcMin.Tag = (object) "Parameter";
    this.textIcVbeVcMin.Text = "unset";
    this.textIcVbeVcMin.TextAlign = HorizontalAlignment.Right;
    this.label140.AutoSize = true;
    this.label140.BackColor = Color.Transparent;
    this.label140.Location = new Point(280, 36);
    this.label140.Name = "label140";
    this.label140.Size = new Size(18, 14);
    this.label140.TabIndex = 110;
    this.label140.Text = "To";
    this.label141.AutoSize = true;
    this.label141.BackColor = Color.Transparent;
    this.label141.Location = new Point(267, 8);
    this.label141.Name = "label141";
    this.label141.Size = new Size(31 /*0x1F*/, 14);
    this.label141.TabIndex = 109;
    this.label141.Text = "From";
    this.label142.AutoSize = true;
    this.label142.BackColor = Color.Transparent;
    this.label142.Location = new Point(257, 64 /*0x40*/);
    this.label142.Name = "label142";
    this.label142.Size = new Size(41, 14);
    this.label142.TabIndex = 108;
    this.label142.Text = "Traces";
    this.label143.AutoSize = true;
    this.label143.BackColor = Color.Transparent;
    this.label143.Location = new Point(209, 36);
    this.label143.Name = "label143";
    this.label143.Size = new Size(15, 14);
    this.label143.TabIndex = 107;
    this.label143.Text = "V";
    this.label144.AutoSize = true;
    this.label144.BackColor = Color.Transparent;
    this.label144.Location = new Point(209, 8);
    this.label144.Name = "label144";
    this.label144.Size = new Size(15, 14);
    this.label144.TabIndex = 106;
    this.label144.Text = "V";
    this.textIcVbePoints.BackColor = SystemColors.Control;
    this.textIcVbePoints.BorderStyle = BorderStyle.FixedSingle;
    this.textIcVbePoints.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcVbePoints.Location = new Point(159, 62);
    this.textIcVbePoints.Name = "textIcVbePoints";
    this.textIcVbePoints.Size = new Size(46, 20);
    this.textIcVbePoints.TabIndex = 2;
    this.textIcVbePoints.Tag = (object) "Parameter";
    this.textIcVbePoints.Text = "unset";
    this.textIcVbePoints.TextAlign = HorizontalAlignment.Right;
    this.textIcVbeVbMax.BackColor = SystemColors.Control;
    this.textIcVbeVbMax.BorderStyle = BorderStyle.FixedSingle;
    this.textIcVbeVbMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcVbeVbMax.ForeColor = SystemColors.ControlText;
    this.textIcVbeVbMax.Location = new Point(159, 34);
    this.textIcVbeVbMax.Name = "textIcVbeVbMax";
    this.textIcVbeVbMax.Size = new Size(46, 20);
    this.textIcVbeVbMax.TabIndex = 1;
    this.textIcVbeVbMax.Tag = (object) "Parameter";
    this.textIcVbeVbMax.Text = "unset";
    this.textIcVbeVbMax.TextAlign = HorizontalAlignment.Right;
    this.label145.AutoSize = true;
    this.label145.BackColor = Color.Transparent;
    this.label145.Location = new Point(138, 36);
    this.label145.Name = "label145";
    this.label145.Size = new Size(18, 14);
    this.label145.TabIndex = 105;
    this.label145.Text = "To";
    this.label146.AutoSize = true;
    this.label146.BackColor = Color.Transparent;
    this.label146.Location = new Point(125, 8);
    this.label146.Name = "label146";
    this.label146.Size = new Size(31 /*0x1F*/, 14);
    this.label146.TabIndex = 104;
    this.label146.Text = "From";
    this.label147.AutoSize = true;
    this.label147.BackColor = Color.Transparent;
    this.label147.Location = new Point(120, 64 /*0x40*/);
    this.label147.Name = "label147";
    this.label147.Size = new Size(36, 14);
    this.label147.TabIndex = 103;
    this.label147.Text = "Points";
    this.butStartIcVbe.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.butStartIcVbe.Location = new Point(455, 59);
    this.butStartIcVbe.Name = "butStartIcVbe";
    this.butStartIcVbe.Size = new Size(75, 23);
    this.butStartIcVbe.TabIndex = 6;
    this.butStartIcVbe.Text = "Start";
    this.butStartIcVbe.UseVisualStyleBackColor = true;
    this.label148.AutoSize = true;
    this.label148.Location = new Point(12, 8);
    this.label148.Name = "label148";
    this.label148.Size = new Size(39, 14);
    this.label148.TabIndex = 90;
    this.label148.Text = "Pinout:";
    this.picIcVbeCircuitSmall.Cursor = Cursors.Hand;
    this.picIcVbeCircuitSmall.Dock = DockStyle.Right;
    this.picIcVbeCircuitSmall.Image = (Image) Resources.cct_TRANSISTOR86;
    this.picIcVbeCircuitSmall.InitialImage = (Image) null;
    this.picIcVbeCircuitSmall.Location = new Point(689, 0);
    this.picIcVbeCircuitSmall.Margin = new Padding(0);
    this.picIcVbeCircuitSmall.Name = "picIcVbeCircuitSmall";
    this.picIcVbeCircuitSmall.Size = new Size(237, 92);
    this.picIcVbeCircuitSmall.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picIcVbeCircuitSmall.TabIndex = 116;
    this.picIcVbeCircuitSmall.TabStop = false;
    this.picIcVbeCircuitSmall.Tag = (object) "picBJTIcVceCircuitLarge";
    this.picIcVbeCircuitSmall.Click += new EventHandler(this.picCircuit_Click);
    this.tabIcIb.Controls.Add((Control) this.picBJTIcIbCircuitLarge);
    this.tabIcIb.Controls.Add((Control) this.zedGraphIcIb);
    this.tabIcIb.Controls.Add((Control) this.panelIcIb);
    this.tabIcIb.Location = new Point(4, 22);
    this.tabIcIb.Name = "tabIcIb";
    this.tabIcIb.Size = new Size(926, 440);
    this.tabIcIb.TabIndex = 19;
    this.tabIcIb.Text = "BJT Ic / Ib";
    this.tabIcIb.UseVisualStyleBackColor = true;
    this.picBJTIcIbCircuitLarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.picBJTIcIbCircuitLarge.BorderStyle = BorderStyle.FixedSingle;
    this.picBJTIcIbCircuitLarge.Image = (Image) Resources.cct_TRANSISTOR126;
    this.picBJTIcIbCircuitLarge.InitialImage = (Image) null;
    this.picBJTIcIbCircuitLarge.Location = new Point(569, 186);
    this.picBJTIcIbCircuitLarge.Margin = new Padding(0);
    this.picBJTIcIbCircuitLarge.Name = "picBJTIcIbCircuitLarge";
    this.picBJTIcIbCircuitLarge.Size = new Size(349, 128 /*0x80*/);
    this.picBJTIcIbCircuitLarge.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picBJTIcIbCircuitLarge.TabIndex = 46;
    this.picBJTIcIbCircuitLarge.TabStop = false;
    this.picBJTIcIbCircuitLarge.Tag = (object) "";
    this.picBJTIcIbCircuitLarge.Visible = false;
    this.picBJTIcIbCircuitLarge.MouseLeave += new EventHandler(this.picCircuit_MouseLeave);
    ((Control) this.zedGraphIcIb).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.zedGraphIcIb.IsAntiAlias = true;
    ((Control) this.zedGraphIcIb).Location = new Point(3, 3);
    ((Control) this.zedGraphIcIb).Name = "zedGraphIcIb";
    this.zedGraphIcIb.ScrollGrace = 0.0;
    this.zedGraphIcIb.ScrollMaxX = 0.0;
    this.zedGraphIcIb.ScrollMaxY = 0.0;
    this.zedGraphIcIb.ScrollMaxY2 = 0.0;
    this.zedGraphIcIb.ScrollMinX = 0.0;
    this.zedGraphIcIb.ScrollMinY = 0.0;
    this.zedGraphIcIb.ScrollMinY2 = 0.0;
    ((Control) this.zedGraphIcIb).Size = new Size(760, 268);
    ((Control) this.zedGraphIcIb).TabIndex = 47;
    this.panelIcIb.Controls.Add((Control) this.butAutosetIcIb);
    this.panelIcIb.Controls.Add((Control) this.checkIcIbLockParameters);
    this.panelIcIb.Controls.Add((Control) this.rtextIcIbConfig);
    this.panelIcIb.Controls.Add((Control) label49);
    this.panelIcIb.Controls.Add((Control) label50);
    this.panelIcIb.Controls.Add((Control) label51);
    this.panelIcIb.Controls.Add((Control) label52);
    this.panelIcIb.Controls.Add((Control) this.textIcIbTraces);
    this.panelIcIb.Controls.Add((Control) this.textIcIbBaseuIMax);
    this.panelIcIb.Controls.Add((Control) this.textIcIbBaseuIMin);
    this.panelIcIb.Controls.Add((Control) label53);
    this.panelIcIb.Controls.Add((Control) label54);
    this.panelIcIb.Controls.Add((Control) label55);
    this.panelIcIb.Controls.Add((Control) label56);
    this.panelIcIb.Controls.Add((Control) label57);
    this.panelIcIb.Controls.Add((Control) this.textIcIbPoints);
    this.panelIcIb.Controls.Add((Control) this.textIcIbVcMax);
    this.panelIcIb.Controls.Add((Control) this.textIcIbVcMin);
    this.panelIcIb.Controls.Add((Control) label58);
    this.panelIcIb.Controls.Add((Control) label59);
    this.panelIcIb.Controls.Add((Control) label60);
    this.panelIcIb.Controls.Add((Control) this.butStartIcIb);
    this.panelIcIb.Controls.Add((Control) label61);
    this.panelIcIb.Controls.Add((Control) this.picBJTIcIbCircuitSmall);
    this.panelIcIb.Dock = DockStyle.Bottom;
    this.panelIcIb.Location = new Point(0, 348);
    this.panelIcIb.MinimumSize = new Size(890, 0);
    this.panelIcIb.Name = "panelIcIb";
    rectanglePlus11.Color = SystemColors.ControlDark;
    rectanglePlus11.Rectangle = new Rectangle(84, 1, 360, 86);
    this.panelIcIb.Rectangles = new GraphPanel.RectanglePlus[1]
    {
      rectanglePlus11
    };
    this.panelIcIb.Size = new Size(926, 92);
    this.panelIcIb.TabIndex = 48 /*0x30*/;
    this.butAutosetIcIb.Location = new Point(378, 59);
    this.butAutosetIcIb.Name = "butAutosetIcIb";
    this.butAutosetIcIb.Size = new Size(54, 23);
    this.butAutosetIcIb.TabIndex = 8;
    this.butAutosetIcIb.Tag = (object) "Parameter";
    this.butAutosetIcIb.Text = "Autoset";
    this.butAutosetIcIb.UseVisualStyleBackColor = true;
    this.checkIcIbLockParameters.AutoSize = true;
    this.checkIcIbLockParameters.BackColor = Color.Transparent;
    this.checkIcIbLockParameters.Location = new Point(387, 13);
    this.checkIcIbLockParameters.Name = "checkIcIbLockParameters";
    this.checkIcIbLockParameters.RightToLeft = RightToLeft.No;
    this.checkIcIbLockParameters.Size = new Size(49, 18);
    this.checkIcIbLockParameters.TabIndex = 7;
    this.checkIcIbLockParameters.Text = "Lock";
    this.checkIcIbLockParameters.UseVisualStyleBackColor = false;
    this.rtextIcIbConfig.BackColor = SystemColors.Window;
    this.rtextIcIbConfig.BorderStyle = BorderStyle.None;
    this.rtextIcIbConfig.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.rtextIcIbConfig.Location = new Point(14, 22);
    this.rtextIcIbConfig.Name = "rtextIcIbConfig";
    this.rtextIcIbConfig.ReadOnly = true;
    this.rtextIcIbConfig.Size = new Size(64 /*0x40*/, 58);
    this.rtextIcIbConfig.TabIndex = 118;
    this.rtextIcIbConfig.TabStop = false;
    this.rtextIcIbConfig.Text = "Unknown";
    this.textIcIbTraces.BorderStyle = BorderStyle.FixedSingle;
    this.textIcIbTraces.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcIbTraces.Location = new Point(301, 62);
    this.textIcIbTraces.Name = "textIcIbTraces";
    this.textIcIbTraces.Size = new Size(46, 20);
    this.textIcIbTraces.TabIndex = 5;
    this.textIcIbTraces.Tag = (object) "Parameter";
    this.textIcIbTraces.Text = "unset";
    this.textIcIbTraces.TextAlign = HorizontalAlignment.Right;
    this.textIcIbTraces.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIcIbBaseuIMax.BorderStyle = BorderStyle.FixedSingle;
    this.textIcIbBaseuIMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcIbBaseuIMax.Location = new Point(159, 34);
    this.textIcIbBaseuIMax.Name = "textIcIbBaseuIMax";
    this.textIcIbBaseuIMax.Size = new Size(46, 20);
    this.textIcIbBaseuIMax.TabIndex = 1;
    this.textIcIbBaseuIMax.Tag = (object) "Parameter";
    this.textIcIbBaseuIMax.Text = "unset";
    this.textIcIbBaseuIMax.TextAlign = HorizontalAlignment.Right;
    this.textIcIbBaseuIMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIcIbBaseuIMin.BorderStyle = BorderStyle.FixedSingle;
    this.textIcIbBaseuIMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcIbBaseuIMin.Location = new Point(159, 6);
    this.textIcIbBaseuIMin.Name = "textIcIbBaseuIMin";
    this.textIcIbBaseuIMin.Size = new Size(46, 20);
    this.textIcIbBaseuIMin.TabIndex = 0;
    this.textIcIbBaseuIMin.Tag = (object) "Parameter";
    this.textIcIbBaseuIMin.Text = "unset";
    this.textIcIbBaseuIMin.TextAlign = HorizontalAlignment.Right;
    this.textIcIbBaseuIMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIcIbPoints.BorderStyle = BorderStyle.FixedSingle;
    this.textIcIbPoints.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcIbPoints.Location = new Point(159, 62);
    this.textIcIbPoints.Name = "textIcIbPoints";
    this.textIcIbPoints.Size = new Size(46, 20);
    this.textIcIbPoints.TabIndex = 2;
    this.textIcIbPoints.Tag = (object) "Parameter";
    this.textIcIbPoints.Text = "unset";
    this.textIcIbPoints.TextAlign = HorizontalAlignment.Right;
    this.textIcIbPoints.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIcIbVcMax.BorderStyle = BorderStyle.FixedSingle;
    this.textIcIbVcMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcIbVcMax.Location = new Point(301, 34);
    this.textIcIbVcMax.Name = "textIcIbVcMax";
    this.textIcIbVcMax.Size = new Size(46, 20);
    this.textIcIbVcMax.TabIndex = 4;
    this.textIcIbVcMax.Tag = (object) "Parameter";
    this.textIcIbVcMax.Text = "unset";
    this.textIcIbVcMax.TextAlign = HorizontalAlignment.Right;
    this.textIcIbVcMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textIcIbVcMin.BorderStyle = BorderStyle.FixedSingle;
    this.textIcIbVcMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textIcIbVcMin.Location = new Point(301, 6);
    this.textIcIbVcMin.Name = "textIcIbVcMin";
    this.textIcIbVcMin.Size = new Size(46, 20);
    this.textIcIbVcMin.TabIndex = 3;
    this.textIcIbVcMin.Tag = (object) "Parameter";
    this.textIcIbVcMin.Text = "unset";
    this.textIcIbVcMin.TextAlign = HorizontalAlignment.Right;
    this.textIcIbVcMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.butStartIcIb.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.butStartIcIb.Location = new Point(455, 59);
    this.butStartIcIb.Name = "butStartIcIb";
    this.butStartIcIb.Size = new Size(75, 23);
    this.butStartIcIb.TabIndex = 6;
    this.butStartIcIb.Text = "Start";
    this.butStartIcIb.UseVisualStyleBackColor = true;
    this.picBJTIcIbCircuitSmall.Cursor = Cursors.Hand;
    this.picBJTIcIbCircuitSmall.Dock = DockStyle.Right;
    this.picBJTIcIbCircuitSmall.Image = (Image) Resources.cct_TRANSISTOR86;
    this.picBJTIcIbCircuitSmall.InitialImage = (Image) null;
    this.picBJTIcIbCircuitSmall.Location = new Point(689, 0);
    this.picBJTIcIbCircuitSmall.Margin = new Padding(0);
    this.picBJTIcIbCircuitSmall.Name = "picBJTIcIbCircuitSmall";
    this.picBJTIcIbCircuitSmall.Size = new Size(237, 92);
    this.picBJTIcIbCircuitSmall.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picBJTIcIbCircuitSmall.TabIndex = 46;
    this.picBJTIcIbCircuitSmall.TabStop = false;
    this.picBJTIcIbCircuitSmall.Tag = (object) "picBJTHfeIcCircuitLarge";
    this.picBJTIcIbCircuitSmall.Click += new EventHandler(this.picCircuit_Click);
    this.tabTIcVce.Controls.Add((Control) this.picIGBTIcVceCircuitLarge);
    this.tabTIcVce.Controls.Add((Control) this.zedGraphTIcVce);
    this.tabTIcVce.Controls.Add((Control) this.panelIGBTIcVce);
    this.tabTIcVce.Location = new Point(4, 22);
    this.tabTIcVce.Name = "tabTIcVce";
    this.tabTIcVce.Size = new Size(926, 440);
    this.tabTIcVce.TabIndex = 16 /*0x10*/;
    this.tabTIcVce.Text = "IGBT Ic/Vce";
    this.tabTIcVce.UseVisualStyleBackColor = true;
    this.picIGBTIcVceCircuitLarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.picIGBTIcVceCircuitLarge.BorderStyle = BorderStyle.FixedSingle;
    this.picIGBTIcVceCircuitLarge.Image = (Image) Resources.cct_IGBT126;
    this.picIGBTIcVceCircuitLarge.InitialImage = (Image) null;
    this.picIGBTIcVceCircuitLarge.Location = new Point(596, 185);
    this.picIGBTIcVceCircuitLarge.Margin = new Padding(0);
    this.picIGBTIcVceCircuitLarge.Name = "picIGBTIcVceCircuitLarge";
    this.picIGBTIcVceCircuitLarge.Size = new Size(349, 128 /*0x80*/);
    this.picIGBTIcVceCircuitLarge.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picIGBTIcVceCircuitLarge.TabIndex = 54;
    this.picIGBTIcVceCircuitLarge.TabStop = false;
    this.picIGBTIcVceCircuitLarge.Tag = (object) "";
    this.picIGBTIcVceCircuitLarge.Visible = false;
    this.picIGBTIcVceCircuitLarge.MouseLeave += new EventHandler(this.picCircuit_MouseLeave);
    ((Control) this.zedGraphTIcVce).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.zedGraphTIcVce.IsAntiAlias = true;
    ((Control) this.zedGraphTIcVce).Location = new Point(0, 3);
    ((Control) this.zedGraphTIcVce).Name = "zedGraphTIcVce";
    this.zedGraphTIcVce.ScrollGrace = 0.0;
    this.zedGraphTIcVce.ScrollMaxX = 0.0;
    this.zedGraphTIcVce.ScrollMaxY = 0.0;
    this.zedGraphTIcVce.ScrollMaxY2 = 0.0;
    this.zedGraphTIcVce.ScrollMinX = 0.0;
    this.zedGraphTIcVce.ScrollMinY = 0.0;
    this.zedGraphTIcVce.ScrollMinY2 = 0.0;
    ((Control) this.zedGraphTIcVce).Size = new Size(846, 283);
    ((Control) this.zedGraphTIcVce).TabIndex = 10;
    this.panelIGBTIcVce.Controls.Add((Control) this.butAutosetTIcVce);
    this.panelIGBTIcVce.Controls.Add((Control) this.checkTIcVceLockParameters);
    this.panelIGBTIcVce.Controls.Add((Control) this.rtextTIcVceConfig);
    this.panelIGBTIcVce.Controls.Add((Control) this.checkTIcVceLog);
    this.panelIGBTIcVce.Controls.Add((Control) label88);
    this.panelIGBTIcVce.Controls.Add((Control) label89);
    this.panelIGBTIcVce.Controls.Add((Control) this.butStartTIcVce);
    this.panelIGBTIcVce.Controls.Add((Control) label90);
    this.panelIGBTIcVce.Controls.Add((Control) label91);
    this.panelIGBTIcVce.Controls.Add((Control) this.textTIcVceTraces);
    this.panelIGBTIcVce.Controls.Add((Control) this.textTIcVceVgeMax);
    this.panelIGBTIcVce.Controls.Add((Control) this.textTIcVceVgeMin);
    this.panelIGBTIcVce.Controls.Add((Control) label92);
    this.panelIGBTIcVce.Controls.Add((Control) label93);
    this.panelIGBTIcVce.Controls.Add((Control) label94);
    this.panelIGBTIcVce.Controls.Add((Control) label95);
    this.panelIGBTIcVce.Controls.Add((Control) label96);
    this.panelIGBTIcVce.Controls.Add((Control) this.textTIcVcePoints);
    this.panelIGBTIcVce.Controls.Add((Control) this.textTIcVceVccMax);
    this.panelIGBTIcVce.Controls.Add((Control) this.textTIcVceVccMin);
    this.panelIGBTIcVce.Controls.Add((Control) label97);
    this.panelIGBTIcVce.Controls.Add((Control) label98);
    this.panelIGBTIcVce.Controls.Add((Control) label99);
    this.panelIGBTIcVce.Controls.Add((Control) label100);
    this.panelIGBTIcVce.Controls.Add((Control) this.picIGBTIcVceCircuitSmall);
    this.panelIGBTIcVce.Dock = DockStyle.Bottom;
    this.panelIGBTIcVce.Location = new Point(0, 348);
    this.panelIGBTIcVce.MinimumSize = new Size(890, 0);
    this.panelIGBTIcVce.Name = "panelIGBTIcVce";
    rectanglePlus12.Color = SystemColors.ControlDark;
    rectanglePlus12.Rectangle = new Rectangle(84, 1, 382, 86);
    this.panelIGBTIcVce.Rectangles = new GraphPanel.RectanglePlus[1]
    {
      rectanglePlus12
    };
    this.panelIGBTIcVce.Size = new Size(926, 92);
    this.panelIGBTIcVce.TabIndex = 51;
    this.butAutosetTIcVce.Location = new Point(378, 59);
    this.butAutosetTIcVce.Name = "butAutosetTIcVce";
    this.butAutosetTIcVce.Size = new Size(54, 23);
    this.butAutosetTIcVce.TabIndex = 9;
    this.butAutosetTIcVce.Tag = (object) "Parameter";
    this.butAutosetTIcVce.Text = "Autoset";
    this.butAutosetTIcVce.UseVisualStyleBackColor = true;
    this.checkTIcVceLockParameters.AutoSize = true;
    this.checkTIcVceLockParameters.BackColor = Color.Transparent;
    this.checkTIcVceLockParameters.Location = new Point(387, 13);
    this.checkTIcVceLockParameters.Name = "checkTIcVceLockParameters";
    this.checkTIcVceLockParameters.RightToLeft = RightToLeft.No;
    this.checkTIcVceLockParameters.Size = new Size(49, 18);
    this.checkTIcVceLockParameters.TabIndex = 7;
    this.checkTIcVceLockParameters.Text = "Lock";
    this.checkTIcVceLockParameters.UseVisualStyleBackColor = false;
    this.rtextTIcVceConfig.BackColor = SystemColors.Window;
    this.rtextTIcVceConfig.BorderStyle = BorderStyle.None;
    this.rtextTIcVceConfig.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.rtextTIcVceConfig.Location = new Point(14, 22);
    this.rtextTIcVceConfig.Name = "rtextTIcVceConfig";
    this.rtextTIcVceConfig.ReadOnly = true;
    this.rtextTIcVceConfig.Size = new Size(64 /*0x40*/, 58);
    this.rtextTIcVceConfig.TabIndex = 118;
    this.rtextTIcVceConfig.TabStop = false;
    this.rtextTIcVceConfig.Text = "Unknown";
    this.checkTIcVceLog.AutoSize = true;
    this.checkTIcVceLog.Location = new Point(387, 35);
    this.checkTIcVceLog.Name = "checkTIcVceLog";
    this.checkTIcVceLog.Size = new Size(71, 18);
    this.checkTIcVceLog.TabIndex = 8;
    this.checkTIcVceLog.Text = "Log span";
    this.checkTIcVceLog.UseVisualStyleBackColor = true;
    this.butStartTIcVce.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.butStartTIcVce.Location = new Point(477, 59);
    this.butStartTIcVce.Name = "butStartTIcVce";
    this.butStartTIcVce.Size = new Size(75, 23);
    this.butStartTIcVce.TabIndex = 6;
    this.butStartTIcVce.Text = "Start";
    this.butStartTIcVce.UseVisualStyleBackColor = true;
    this.textTIcVceTraces.BorderStyle = BorderStyle.FixedSingle;
    this.textTIcVceTraces.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textTIcVceTraces.Location = new Point(301, 62);
    this.textTIcVceTraces.Name = "textTIcVceTraces";
    this.textTIcVceTraces.Size = new Size(46, 20);
    this.textTIcVceTraces.TabIndex = 5;
    this.textTIcVceTraces.Tag = (object) "Parameter";
    this.textTIcVceTraces.Text = "unset";
    this.textTIcVceTraces.TextAlign = HorizontalAlignment.Right;
    this.textTIcVceTraces.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textTIcVceVgeMax.BorderStyle = BorderStyle.FixedSingle;
    this.textTIcVceVgeMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textTIcVceVgeMax.Location = new Point(301, 34);
    this.textTIcVceVgeMax.Name = "textTIcVceVgeMax";
    this.textTIcVceVgeMax.Size = new Size(46, 20);
    this.textTIcVceVgeMax.TabIndex = 4;
    this.textTIcVceVgeMax.Tag = (object) "Parameter";
    this.textTIcVceVgeMax.Text = "unset";
    this.textTIcVceVgeMax.TextAlign = HorizontalAlignment.Right;
    this.textTIcVceVgeMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textTIcVceVgeMin.BorderStyle = BorderStyle.FixedSingle;
    this.textTIcVceVgeMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textTIcVceVgeMin.Location = new Point(301, 6);
    this.textTIcVceVgeMin.Name = "textTIcVceVgeMin";
    this.textTIcVceVgeMin.Size = new Size(46, 20);
    this.textTIcVceVgeMin.TabIndex = 3;
    this.textTIcVceVgeMin.Tag = (object) "Parameter";
    this.textTIcVceVgeMin.Text = "unset";
    this.textTIcVceVgeMin.TextAlign = HorizontalAlignment.Right;
    this.textTIcVceVgeMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textTIcVcePoints.BorderStyle = BorderStyle.FixedSingle;
    this.textTIcVcePoints.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textTIcVcePoints.Location = new Point(159, 62);
    this.textTIcVcePoints.Name = "textTIcVcePoints";
    this.textTIcVcePoints.Size = new Size(46, 20);
    this.textTIcVcePoints.TabIndex = 2;
    this.textTIcVcePoints.Tag = (object) "Parameter";
    this.textTIcVcePoints.Text = "unset";
    this.textTIcVcePoints.TextAlign = HorizontalAlignment.Right;
    this.textTIcVcePoints.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textTIcVceVccMax.BorderStyle = BorderStyle.FixedSingle;
    this.textTIcVceVccMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textTIcVceVccMax.Location = new Point(159, 34);
    this.textTIcVceVccMax.Name = "textTIcVceVccMax";
    this.textTIcVceVccMax.Size = new Size(46, 20);
    this.textTIcVceVccMax.TabIndex = 1;
    this.textTIcVceVccMax.Tag = (object) "Parameter";
    this.textTIcVceVccMax.Text = "unset";
    this.textTIcVceVccMax.TextAlign = HorizontalAlignment.Right;
    this.textTIcVceVccMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textTIcVceVccMin.BorderStyle = BorderStyle.FixedSingle;
    this.textTIcVceVccMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textTIcVceVccMin.Location = new Point(159, 6);
    this.textTIcVceVccMin.Name = "textTIcVceVccMin";
    this.textTIcVceVccMin.Size = new Size(46, 20);
    this.textTIcVceVccMin.TabIndex = 0;
    this.textTIcVceVccMin.Tag = (object) "Parameter";
    this.textTIcVceVccMin.Text = "unset";
    this.textTIcVceVccMin.TextAlign = HorizontalAlignment.Right;
    this.textTIcVceVccMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.picIGBTIcVceCircuitSmall.Cursor = Cursors.Hand;
    this.picIGBTIcVceCircuitSmall.Dock = DockStyle.Right;
    this.picIGBTIcVceCircuitSmall.Image = (Image) Resources.cct_IGBT86;
    this.picIGBTIcVceCircuitSmall.InitialImage = (Image) null;
    this.picIGBTIcVceCircuitSmall.Location = new Point(689, 0);
    this.picIGBTIcVceCircuitSmall.Margin = new Padding(0);
    this.picIGBTIcVceCircuitSmall.Name = "picIGBTIcVceCircuitSmall";
    this.picIGBTIcVceCircuitSmall.Size = new Size(237, 92);
    this.picIGBTIcVceCircuitSmall.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picIGBTIcVceCircuitSmall.TabIndex = 54;
    this.picIGBTIcVceCircuitSmall.TabStop = false;
    this.picIGBTIcVceCircuitSmall.Tag = (object) "picIGBTIcVceCircuitLarge";
    this.picIGBTIcVceCircuitSmall.Click += new EventHandler(this.picCircuit_Click);
    this.tabTIcVge.Controls.Add((Control) this.picIGBTIcVgeCircuitLarge);
    this.tabTIcVge.Controls.Add((Control) this.zedGraphTIcVge);
    this.tabTIcVge.Controls.Add((Control) this.panelIGBTIcVge);
    this.tabTIcVge.Location = new Point(4, 22);
    this.tabTIcVge.Name = "tabTIcVge";
    this.tabTIcVge.Size = new Size(926, 440);
    this.tabTIcVge.TabIndex = 17;
    this.tabTIcVge.Text = "IGBT Ic/Vge";
    this.tabTIcVge.UseVisualStyleBackColor = true;
    this.picIGBTIcVgeCircuitLarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.picIGBTIcVgeCircuitLarge.BorderStyle = BorderStyle.FixedSingle;
    this.picIGBTIcVgeCircuitLarge.Image = (Image) Resources.cct_IGBT126;
    this.picIGBTIcVgeCircuitLarge.InitialImage = (Image) null;
    this.picIGBTIcVgeCircuitLarge.Location = new Point(596, 188);
    this.picIGBTIcVgeCircuitLarge.Margin = new Padding(0);
    this.picIGBTIcVgeCircuitLarge.Name = "picIGBTIcVgeCircuitLarge";
    this.picIGBTIcVgeCircuitLarge.Size = new Size(349, 128 /*0x80*/);
    this.picIGBTIcVgeCircuitLarge.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picIGBTIcVgeCircuitLarge.TabIndex = 55;
    this.picIGBTIcVgeCircuitLarge.TabStop = false;
    this.picIGBTIcVgeCircuitLarge.Tag = (object) "";
    this.picIGBTIcVgeCircuitLarge.Visible = false;
    this.picIGBTIcVgeCircuitLarge.MouseLeave += new EventHandler(this.picCircuit_MouseLeave);
    ((Control) this.zedGraphTIcVge).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.zedGraphTIcVge.IsAntiAlias = true;
    ((Control) this.zedGraphTIcVge).Location = new Point(0, 3);
    ((Control) this.zedGraphTIcVge).Name = "zedGraphTIcVge";
    this.zedGraphTIcVge.ScrollGrace = 0.0;
    this.zedGraphTIcVge.ScrollMaxX = 0.0;
    this.zedGraphTIcVge.ScrollMaxY = 0.0;
    this.zedGraphTIcVge.ScrollMaxY2 = 0.0;
    this.zedGraphTIcVge.ScrollMinX = 0.0;
    this.zedGraphTIcVge.ScrollMinY = 0.0;
    this.zedGraphTIcVge.ScrollMinY2 = 0.0;
    ((Control) this.zedGraphTIcVge).Size = new Size(846, 295);
    ((Control) this.zedGraphTIcVge).TabIndex = 9;
    this.panelIGBTIcVge.Controls.Add((Control) this.butAutosetTIcVge);
    this.panelIGBTIcVge.Controls.Add((Control) this.checkTIcVgeLockParameters);
    this.panelIGBTIcVge.Controls.Add((Control) this.rtextTIcVgeConfig);
    this.panelIGBTIcVge.Controls.Add((Control) label101);
    this.panelIGBTIcVge.Controls.Add((Control) label102);
    this.panelIGBTIcVge.Controls.Add((Control) label103);
    this.panelIGBTIcVge.Controls.Add((Control) label104);
    this.panelIGBTIcVge.Controls.Add((Control) this.textTIcVgeTraces);
    this.panelIGBTIcVge.Controls.Add((Control) this.textTIcVgeVceMax);
    this.panelIGBTIcVge.Controls.Add((Control) this.textTIcVgeVceMin);
    this.panelIGBTIcVge.Controls.Add((Control) label105);
    this.panelIGBTIcVge.Controls.Add((Control) label106);
    this.panelIGBTIcVge.Controls.Add((Control) label107);
    this.panelIGBTIcVge.Controls.Add((Control) label108);
    this.panelIGBTIcVge.Controls.Add((Control) label109);
    this.panelIGBTIcVge.Controls.Add((Control) this.textTIcVgePoints);
    this.panelIGBTIcVge.Controls.Add((Control) this.textTIcVgeVgeMax);
    this.panelIGBTIcVge.Controls.Add((Control) this.textTIcVgeVgeMin);
    this.panelIGBTIcVge.Controls.Add((Control) label110);
    this.panelIGBTIcVge.Controls.Add((Control) label111);
    this.panelIGBTIcVge.Controls.Add((Control) label112);
    this.panelIGBTIcVge.Controls.Add((Control) this.butStartTIcVge);
    this.panelIGBTIcVge.Controls.Add((Control) label113);
    this.panelIGBTIcVge.Controls.Add((Control) this.picIGBTIcVgeCircuitSmall);
    this.panelIGBTIcVge.Dock = DockStyle.Bottom;
    this.panelIGBTIcVge.Location = new Point(0, 348);
    this.panelIGBTIcVge.MinimumSize = new Size(890, 0);
    this.panelIGBTIcVge.Name = "panelIGBTIcVge";
    rectanglePlus13.Color = SystemColors.ControlDark;
    rectanglePlus13.Rectangle = new Rectangle(84, 1, 360, 86);
    this.panelIGBTIcVge.Rectangles = new GraphPanel.RectanglePlus[1]
    {
      rectanglePlus13
    };
    this.panelIGBTIcVge.Size = new Size(926, 92);
    this.panelIGBTIcVge.TabIndex = 44;
    this.butAutosetTIcVge.Location = new Point(378, 59);
    this.butAutosetTIcVge.Name = "butAutosetTIcVge";
    this.butAutosetTIcVge.Size = new Size(54, 23);
    this.butAutosetTIcVge.TabIndex = 8;
    this.butAutosetTIcVge.Tag = (object) "Parameter";
    this.butAutosetTIcVge.Text = "Autoset";
    this.butAutosetTIcVge.UseVisualStyleBackColor = true;
    this.checkTIcVgeLockParameters.AutoSize = true;
    this.checkTIcVgeLockParameters.BackColor = Color.Transparent;
    this.checkTIcVgeLockParameters.Location = new Point(387, 13);
    this.checkTIcVgeLockParameters.Name = "checkTIcVgeLockParameters";
    this.checkTIcVgeLockParameters.RightToLeft = RightToLeft.No;
    this.checkTIcVgeLockParameters.Size = new Size(49, 18);
    this.checkTIcVgeLockParameters.TabIndex = 7;
    this.checkTIcVgeLockParameters.Text = "Lock";
    this.checkTIcVgeLockParameters.UseVisualStyleBackColor = false;
    this.rtextTIcVgeConfig.BackColor = SystemColors.Window;
    this.rtextTIcVgeConfig.BorderStyle = BorderStyle.None;
    this.rtextTIcVgeConfig.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.rtextTIcVgeConfig.Location = new Point(14, 22);
    this.rtextTIcVgeConfig.Name = "rtextTIcVgeConfig";
    this.rtextTIcVgeConfig.ReadOnly = true;
    this.rtextTIcVgeConfig.Size = new Size(64 /*0x40*/, 58);
    this.rtextTIcVgeConfig.TabIndex = 118;
    this.rtextTIcVgeConfig.TabStop = false;
    this.rtextTIcVgeConfig.Text = "Unknown";
    this.textTIcVgeTraces.BorderStyle = BorderStyle.FixedSingle;
    this.textTIcVgeTraces.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textTIcVgeTraces.Location = new Point(301, 62);
    this.textTIcVgeTraces.Name = "textTIcVgeTraces";
    this.textTIcVgeTraces.Size = new Size(46, 20);
    this.textTIcVgeTraces.TabIndex = 5;
    this.textTIcVgeTraces.Tag = (object) "Parameter";
    this.textTIcVgeTraces.Text = "unset";
    this.textTIcVgeTraces.TextAlign = HorizontalAlignment.Right;
    this.textTIcVgeTraces.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textTIcVgeVceMax.BorderStyle = BorderStyle.FixedSingle;
    this.textTIcVgeVceMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textTIcVgeVceMax.Location = new Point(301, 34);
    this.textTIcVgeVceMax.Name = "textTIcVgeVceMax";
    this.textTIcVgeVceMax.Size = new Size(46, 20);
    this.textTIcVgeVceMax.TabIndex = 4;
    this.textTIcVgeVceMax.Tag = (object) "Parameter";
    this.textTIcVgeVceMax.Text = "unset";
    this.textTIcVgeVceMax.TextAlign = HorizontalAlignment.Right;
    this.textTIcVgeVceMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textTIcVgeVceMin.BorderStyle = BorderStyle.FixedSingle;
    this.textTIcVgeVceMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textTIcVgeVceMin.Location = new Point(301, 6);
    this.textTIcVgeVceMin.Name = "textTIcVgeVceMin";
    this.textTIcVgeVceMin.Size = new Size(46, 20);
    this.textTIcVgeVceMin.TabIndex = 3;
    this.textTIcVgeVceMin.Tag = (object) "Parameter";
    this.textTIcVgeVceMin.Text = "unset";
    this.textTIcVgeVceMin.TextAlign = HorizontalAlignment.Right;
    this.textTIcVgeVceMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textTIcVgePoints.BorderStyle = BorderStyle.FixedSingle;
    this.textTIcVgePoints.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textTIcVgePoints.Location = new Point(159, 62);
    this.textTIcVgePoints.Name = "textTIcVgePoints";
    this.textTIcVgePoints.Size = new Size(46, 20);
    this.textTIcVgePoints.TabIndex = 2;
    this.textTIcVgePoints.Tag = (object) "Parameter";
    this.textTIcVgePoints.Text = "unset";
    this.textTIcVgePoints.TextAlign = HorizontalAlignment.Right;
    this.textTIcVgePoints.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textTIcVgeVgeMax.BorderStyle = BorderStyle.FixedSingle;
    this.textTIcVgeVgeMax.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textTIcVgeVgeMax.Location = new Point(159, 34);
    this.textTIcVgeVgeMax.Name = "textTIcVgeVgeMax";
    this.textTIcVgeVgeMax.Size = new Size(46, 20);
    this.textTIcVgeVgeMax.TabIndex = 1;
    this.textTIcVgeVgeMax.Tag = (object) "Parameter";
    this.textTIcVgeVgeMax.Text = "unset";
    this.textTIcVgeVgeMax.TextAlign = HorizontalAlignment.Right;
    this.textTIcVgeVgeMax.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.textTIcVgeVgeMin.BorderStyle = BorderStyle.FixedSingle;
    this.textTIcVgeVgeMin.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.textTIcVgeVgeMin.Location = new Point(159, 6);
    this.textTIcVgeVgeMin.Name = "textTIcVgeVgeMin";
    this.textTIcVgeVgeMin.Size = new Size(46, 20);
    this.textTIcVgeVgeMin.TabIndex = 0;
    this.textTIcVgeVgeMin.Tag = (object) "Parameter";
    this.textTIcVgeVgeMin.Text = "unset";
    this.textTIcVgeVgeMin.TextAlign = HorizontalAlignment.Right;
    this.textTIcVgeVgeMin.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
    this.butStartTIcVge.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.butStartTIcVge.Location = new Point(455, 59);
    this.butStartTIcVge.Name = "butStartTIcVge";
    this.butStartTIcVge.Size = new Size(75, 23);
    this.butStartTIcVge.TabIndex = 6;
    this.butStartTIcVge.Text = "Start";
    this.butStartTIcVge.UseVisualStyleBackColor = true;
    this.picIGBTIcVgeCircuitSmall.Cursor = Cursors.Hand;
    this.picIGBTIcVgeCircuitSmall.Dock = DockStyle.Right;
    this.picIGBTIcVgeCircuitSmall.Image = (Image) Resources.cct_IGBT86;
    this.picIGBTIcVgeCircuitSmall.InitialImage = (Image) null;
    this.picIGBTIcVgeCircuitSmall.Location = new Point(689, 0);
    this.picIGBTIcVgeCircuitSmall.Margin = new Padding(0);
    this.picIGBTIcVgeCircuitSmall.Name = "picIGBTIcVgeCircuitSmall";
    this.picIGBTIcVgeCircuitSmall.Size = new Size(237, 92);
    this.picIGBTIcVgeCircuitSmall.SizeMode = PictureBoxSizeMode.AutoSize;
    this.picIGBTIcVgeCircuitSmall.TabIndex = 55;
    this.picIGBTIcVgeCircuitSmall.TabStop = false;
    this.picIGBTIcVgeCircuitSmall.Tag = (object) "picIGBTIcVgeCircuitLarge";
    this.picIGBTIcVgeCircuitSmall.Click += new EventHandler(this.picCircuit_Click);
    this.bgWorkerUpdate.WorkerReportsProgress = true;
    this.bgWorkerUpdate.WorkerSupportsCancellation = true;
    this.bgWorkerUpdate.DoWork += new DoWorkEventHandler(this.bgWorkerUpdate_DoWork);
    this.bgWorkerUpdate.ProgressChanged += new ProgressChangedEventHandler(this.bgWorkerUpdate_ProgressChanged);
    this.bgWorkerUpdate.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgWorkerUpdate_RunWorkerCompleted);
    this.openDataFileDialog.DefaultExt = "txt";
    this.openDataFileDialog.FileName = "*.txt";
    this.openDataFileDialog.Filter = "Text files|*.txt";
    this.openDataFileDialog.InitialDirectory = ".";
    this.openDataFileDialog.Multiselect = true;
    this.openDataFileDialog.Title = "Load Data file";
    this.saveDataFileDialog.DefaultExt = "txt";
    this.saveDataFileDialog.FileName = "*.txt";
    this.saveDataFileDialog.Filter = "Text files|*.txt";
    this.saveDataFileDialog.InitialDirectory = ".";
    this.saveDataFileDialog.Title = "Save Data file";
    this.TraceColorDialog.AllowFullOpen = false;
    this.TraceColorDialog.SolidColorOnly = true;
    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.panel1.BackColor = SystemColors.ControlDark;
    this.panel1.Controls.Add((Control) this.numGlobalTraceN);
    this.panel1.Controls.Add((Control) this.lLabelCompTrace);
    this.panel1.Controls.Add((Control) label1);
    this.panel1.Controls.Add((Control) this.textGlobalTracePrefix);
    this.panel1.Location = new Point(583, 0);
    this.panel1.Margin = new Padding(0);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(351, 24);
    this.panel1.TabIndex = 102;
    this.numGlobalTraceN.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.numGlobalTraceN.BorderStyle = BorderStyle.FixedSingle;
    this.numGlobalTraceN.Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.numGlobalTraceN.Location = new Point(298, 2);
    this.numGlobalTraceN.Maximum = new Decimal(new int[4]
    {
      9999,
      0,
      0,
      0
    });
    this.numGlobalTraceN.Name = "numGlobalTraceN";
    this.numGlobalTraceN.Size = new Size(48 /*0x30*/, 20);
    this.numGlobalTraceN.TabIndex = 103;
    this.numGlobalTraceN.TextAlign = HorizontalAlignment.Right;
    this.numGlobalTraceN.Value = new Decimal(new int[4]
    {
      1,
      0,
      0,
      0
    });
    this.lLabelCompTrace.ActiveLinkColor = Color.DeepSkyBlue;
    this.lLabelCompTrace.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.lLabelCompTrace.BackColor = Color.Transparent;
    this.lLabelCompTrace.Cursor = Cursors.Hand;
    this.lLabelCompTrace.LinkColor = SystemColors.ControlText;
    this.lLabelCompTrace.Location = new Point(1, 4);
    this.lLabelCompTrace.Name = "lLabelCompTrace";
    this.lLabelCompTrace.Size = new Size(100, 16 /*0x10*/);
    this.lLabelCompTrace.TabIndex = 101;
    this.lLabelCompTrace.TabStop = true;
    this.lLabelCompTrace.Text = "lLabelCompTrace";
    this.lLabelCompTrace.TextAlign = ContentAlignment.MiddleRight;
    this.lLabelCompTrace.VisitedLinkColor = SystemColors.ControlText;
    this.lLabelCompTrace.TextChanged += new EventHandler(this.lLabelCompTrace_TextChanged);
    this.lLabelCompTrace.Click += new EventHandler(this.lLabelCompTrace_Click);
    this.ToolTipFrm.AutoPopDelay = 30000;
    this.ToolTipFrm.InitialDelay = 500;
    this.ToolTipFrm.ReshowDelay = 100;
    this.ToolTipFrm.ShowAlways = true;
    this.ClientSize = new Size(934, 512 /*0x0200*/);
    this.Controls.Add((Control) this.tabControl);
    this.Controls.Add((Control) this.menuStripMain);
    this.Controls.Add((Control) this.panel1);
    this.Controls.Add((Control) this.statusStrip1);
    this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.MainMenuStrip = this.menuStripMain;
    this.Name = nameof (frmDCAProApp);
    this.StartPosition = FormStartPosition.Manual;
    this.Text = "Peak DCA Pro";
    this.Closed += new EventHandler(this.frmMainApp_Closed);
    this.FormClosing += new FormClosingEventHandler(this.frmMainApp_FormClosing);
    this.Load += new EventHandler(this.frmMainApp_Load);
    this.tabPNTest.ResumeLayout(false);
    this.tabPNTest.PerformLayout();
    ((ISupportInitialize) this.picPNCircuitLarge).EndInit();
    this.panelPNJunction.ResumeLayout(false);
    this.panelPNJunction.PerformLayout();
    ((ISupportInitialize) this.picPNCircuitSmall).EndInit();
    this.tabIdentify.ResumeLayout(false);
    this.myPanelResults.ResumeLayout(false);
    this.contextMenuComments.ResumeLayout(false);
    this.panel2.ResumeLayout(false);
    ((ISupportInitialize) this.pictureResult).EndInit();
    this.menuStripMain.ResumeLayout(false);
    this.menuStripMain.PerformLayout();
    this.statusStrip1.ResumeLayout(false);
    this.statusStrip1.PerformLayout();
    this.tabVRegTest.ResumeLayout(false);
    this.tabVRegTest.PerformLayout();
    ((ISupportInitialize) this.picVRegVoViLarge).EndInit();
    this.panelVRegVoutVin.ResumeLayout(false);
    this.panelVRegVoutVin.PerformLayout();
    ((ISupportInitialize) this.picVRegVoViSmall).EndInit();
    this.tabJIdVgs.ResumeLayout(false);
    this.tabJIdVgs.PerformLayout();
    ((ISupportInitialize) this.picJFETIdVgsCircuitLarge).EndInit();
    this.panelJIdVgs.ResumeLayout(false);
    this.panelJIdVgs.PerformLayout();
    ((ISupportInitialize) this.picJFETIdVgsCircuitSmall).EndInit();
    this.tabJIdVds.ResumeLayout(false);
    this.tabJIdVds.PerformLayout();
    ((ISupportInitialize) this.picJFETIdVdsCircuitLarge).EndInit();
    this.panelJIdVds.ResumeLayout(false);
    this.panelJIdVds.PerformLayout();
    ((ISupportInitialize) this.picJFETIdVdsCircuitSmall).EndInit();
    this.tabFIdVds.ResumeLayout(false);
    this.tabFIdVds.PerformLayout();
    ((ISupportInitialize) this.picMOSIdVdsCircuitLarge).EndInit();
    this.panelMIdVds.ResumeLayout(false);
    this.panelMIdVds.PerformLayout();
    ((ISupportInitialize) this.picMOSIdVdsCircuitSmall).EndInit();
    this.tabFIdVgs.ResumeLayout(false);
    this.tabFIdVgs.PerformLayout();
    ((ISupportInitialize) this.picMOSIdVgsCircuitLarge).EndInit();
    this.panelMIdVgs.ResumeLayout(false);
    this.panelMIdVgs.PerformLayout();
    ((ISupportInitialize) this.picMOSIdVgsCircuitSmall).EndInit();
    this.tabIcVce.ResumeLayout(false);
    this.tabIcVce.PerformLayout();
    ((ISupportInitialize) this.picBJTIcVceCircuitLarge).EndInit();
    this.panelIcVce.ResumeLayout(false);
    this.panelIcVce.PerformLayout();
    ((ISupportInitialize) this.picBJTIcVceCircuitSmall).EndInit();
    this.tabControl.ResumeLayout(false);
    this.tabHfeVce.ResumeLayout(false);
    this.tabHfeVce.PerformLayout();
    ((ISupportInitialize) this.picBJTHfeVceCircuitLarge).EndInit();
    this.panelHFEVce.ResumeLayout(false);
    this.panelHFEVce.PerformLayout();
    ((ISupportInitialize) this.picBJTHfeVceCircuitSmall).EndInit();
    this.tabHfeIc.ResumeLayout(false);
    this.tabHfeIc.PerformLayout();
    ((ISupportInitialize) this.picBJTHfeIcCircuitLarge).EndInit();
    this.panelHFEIc.ResumeLayout(false);
    this.panelHFEIc.PerformLayout();
    ((ISupportInitialize) this.picBJTHfeIcCircuitSmall).EndInit();
    this.tabIcVbe.ResumeLayout(false);
    this.tabIcVbe.PerformLayout();
    ((ISupportInitialize) this.picBJTIcVbeCircuitLarge).EndInit();
    this.panelIcVbe.ResumeLayout(false);
    this.panelIcVbe.PerformLayout();
    ((ISupportInitialize) this.picIcVbeCircuitSmall).EndInit();
    this.tabIcIb.ResumeLayout(false);
    this.tabIcIb.PerformLayout();
    ((ISupportInitialize) this.picBJTIcIbCircuitLarge).EndInit();
    this.panelIcIb.ResumeLayout(false);
    this.panelIcIb.PerformLayout();
    ((ISupportInitialize) this.picBJTIcIbCircuitSmall).EndInit();
    this.tabTIcVce.ResumeLayout(false);
    this.tabTIcVce.PerformLayout();
    ((ISupportInitialize) this.picIGBTIcVceCircuitLarge).EndInit();
    this.panelIGBTIcVce.ResumeLayout(false);
    this.panelIGBTIcVce.PerformLayout();
    ((ISupportInitialize) this.picIGBTIcVceCircuitSmall).EndInit();
    this.tabTIcVge.ResumeLayout(false);
    this.tabTIcVge.PerformLayout();
    ((ISupportInitialize) this.picIGBTIcVgeCircuitLarge).EndInit();
    this.panelIGBTIcVge.ResumeLayout(false);
    this.panelIGBTIcVge.PerformLayout();
    ((ISupportInitialize) this.picIGBTIcVgeCircuitSmall).EndInit();
    this.panel1.ResumeLayout(false);
    this.panel1.PerformLayout();
    this.numGlobalTraceN.EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }

  internal event frmDCAProApp.ResultEvent NewResultEvent;

  internal event frmDCAProApp.DisEnableEvent NewDisEnableEvent;

  internal event frmDCAProApp.ComponentNameChanged ComponentNameChangedEvent;

  public frmDCAProApp(string[] args)
  {
    this.Splash = new frmSplash();
    this.Splash.Show();
    this.InitializeComponent();
    this.Size = new Size(950, 550);
    this.CenterToScreen();
    this.thisDCAPro = new DCAProUnit(this.Handle);
    this.myDeviceMan = new DeviceManagement();
    this.Graphs[1] = (Graph) new GraphIcVce(this);
    this.Graphs[2] = (Graph) new GraphIcVbe(this);
    this.Graphs[5] = (Graph) new GraphHfeVce(this);
    this.Graphs[3] = (Graph) new GraphHfeIc(this);
    this.Graphs[4] = (Graph) new GraphIcIb(this);
    this.Graphs[6] = (Graph) new GraphIdVds(this);
    this.Graphs[7] = (Graph) new GraphIdVgs(this);
    this.Graphs[8] = (Graph) new GraphTIcVce(this);
    this.Graphs[9] = (Graph) new GraphTIcVge(this);
    this.Graphs[10] = (Graph) new GraphJIdVds(this);
    this.Graphs[11] = (Graph) new GraphJIdVgs(this);
    this.Graphs[12] = (Graph) new GraphVRegVoVi(this);
    this.Graphs[0] = (Graph) new GraphPNJunction(this);
    this.BJTMenuCategory.Tag = (object) "BJT";
    this.MOSFETMenuCategory.Tag = (object) "MOSFET";
    this.IGBTMenuCategory.Tag = (object) "IGBT";
    this.JFETMenuCategory.Tag = (object) "JFET";
    this.VRegMenuCategory.Tag = (object) "VReg";
    this.PNJunctMenuItem.Tag = (object) this.tabPNTest;
    this.IcVceBJTMenuSubItem.Tag = (object) this.tabIcVce;
    this.HfeVceBJTMenuSubItem.Tag = (object) this.tabHfeVce;
    this.HfeIcBJTMenuSubItem.Tag = (object) this.tabHfeIc;
    this.IcIbBJTMenuSubItem.Tag = (object) this.tabIcIb;
    this.IcVbeBJTMenuSubItem.Tag = (object) this.tabIcVbe;
    this.IdVdsMOSFETMenuSubItem.Tag = (object) this.tabFIdVds;
    this.IdVgsMOSFETMenuSubItem.Tag = (object) this.tabFIdVgs;
    this.IcVceIGBTMenuSubItem.Tag = (object) this.tabTIcVce;
    this.IcVgeIGBTMenuSubItem.Tag = (object) this.tabTIcVge;
    this.IdVdsJFETMenuSubItem.Tag = (object) this.tabJIdVds;
    this.IdVgsJFETMenuSubItem.Tag = (object) this.tabJIdVgs;
    this.VoutVinVRegMenuSubItem.Tag = (object) this.tabVRegTest;
    this.tabPNTest.Tag = (object) this.Graphs[0];
    this.tabIcVce.Tag = (object) this.Graphs[1];
    this.tabIcVbe.Tag = (object) this.Graphs[2];
    this.tabHfeVce.Tag = (object) this.Graphs[5];
    this.tabHfeIc.Tag = (object) this.Graphs[3];
    this.tabIcIb.Tag = (object) this.Graphs[4];
    this.tabFIdVds.Tag = (object) this.Graphs[6];
    this.tabFIdVgs.Tag = (object) this.Graphs[7];
    this.tabTIcVce.Tag = (object) this.Graphs[8];
    this.tabTIcVge.Tag = (object) this.Graphs[9];
    this.tabJIdVds.Tag = (object) this.Graphs[10];
    this.tabJIdVgs.Tag = (object) this.Graphs[11];
    this.tabVRegTest.Tag = (object) this.Graphs[12];
    this.TestTabs_SelectedIndexChanged((object) this, (EventArgs) null);
    this.NewResultEvent += new frmDCAProApp.ResultEvent(this.NewResult_Event);
  }

  private void AddResultText(string action, string formText)
  {
    try
    {
      switch (action)
      {
        case "AddItem":
          this.rtextIdentifyResults.ColorizerateText(formText);
          break;
        case "Clear":
          this.rtextIdentifyResults.Text = "";
          break;
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void InitializeDisplay()
  {
    try
    {
      this.toolStripProgressLabel.Text = "";
      this.toolStripIdentify.Text = "";
      this.toolStripIdentify.Alignment = ToolStripItemAlignment.Right;
      this.lLabelCompTrace.Text = "Component name";
      this.ToolTipFrm.SetToolTip((Control) this.textGlobalTracePrefix, string.Format("This text will prefix the next set of traces.\nA '#' will be replaced with the number in the # box."));
      this.ResultContextMenu.Items.Clear();
      this.ResultContextMenu.Items.Add("Copy");
      this.ResultContextMenu.ItemClicked += new ToolStripItemClickedEventHandler(this.rtextIdentifyResultsContextMenu_ItemClicked);
      this.rtextIdentifyResults.ContextMenuStrip = this.ResultContextMenu;
      this.MenuCheckForUpdatesAutomatically.Checked = Settings.Default.CheckUpdates;
      this.PNJunctMenuItem.Checked = false;
      this.IcVceBJTMenuSubItem.Checked = false;
      this.HfeVceBJTMenuSubItem.Checked = false;
      this.HfeIcBJTMenuSubItem.Checked = false;
      this.IcIbBJTMenuSubItem.Checked = false;
      this.IcVbeBJTMenuSubItem.Checked = false;
      this.IdVdsMOSFETMenuSubItem.Checked = false;
      this.IdVgsMOSFETMenuSubItem.Checked = false;
      this.IcVceIGBTMenuSubItem.Checked = false;
      this.IcVgeIGBTMenuSubItem.Checked = false;
      this.IdVdsJFETMenuSubItem.Checked = false;
      this.IdVgsJFETMenuSubItem.Checked = false;
      this.VoutVinVRegMenuSubItem.Checked = false;
      this.UpdateAllTestTabs((ToolStripMenuItem) null);
      this.ButtonsForDisconnect();
      this.openHEXFileDialog.InitialDirectory = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\firmware";
      this.TraceColorDialog.CustomColors = new int[Graph.Palete.Length];
      int[] numArray = new int[this.TraceColorDialog.CustomColors.Length];
      for (int index = 0; index < this.TraceColorDialog.CustomColors.Length; ++index)
        numArray[index] = ColorTranslator.ToOle(Graph.Palete[index]);
      this.TraceColorDialog.CustomColors = numArray;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void Shutdown()
  {
    try
    {
      Settings.Default.Save();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void Startup()
  {
    try
    {
      this.About = new AboutBox();
      this.UpdatePrompt = new UpdatePromptBox();
      this.DLUpdatePrompt = new DLUpdateBox();
      this.dlgLCDContrast = new dialogLCDContrast(this);
      this.ResultContextMenu = new ContextMenuStrip();
      this.InitializeDisplay();
      if (Settings.Default.CheckUpdates)
        this.bgWorkerUpdate.RunWorkerAsync((object) false);
      this.timerPulse.Enabled = true;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void frmMainApp_Closed(object eventSender, EventArgs eventArgs)
  {
    try
    {
      this.Shutdown();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void frmMainApp_Load(object eventSender, EventArgs eventArgs)
  {
    try
    {
      this.frmMy = this;
      this.Startup();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void frmMainApp_FormClosing(object sender, FormClosingEventArgs e)
  {
    try
    {
      if (!this.bgWorkerTest.IsBusy)
        return;
      this.FormClosingState = 1;
      e.Cancel = true;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  protected override void WndProc(ref Message m)
  {
    try
    {
      if (m.Msg == 537)
      {
        this.OnDeviceChange(m);
        this.UpdateConnectedStatus(this.thisDCAPro.ConnectedState);
      }
      base.WndProc(ref m);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void OnDeviceChange(Message m)
  {
    try
    {
      switch (m.WParam.ToInt32())
      {
        case 32772:
          if (this.myDeviceMan.DeviceMsgMatch(m, this.thisDCAPro.Comms.myWinUsbDevice.deviceHandle))
          {
            this.thisDCAPro.ConnectedState = DCAProUnit.STATE.UNCONNECTED;
            break;
          }
          if (!this.myDeviceMan.DeviceMsgMatch(m, this.thisDCAPro.Boot.DeviceHandle))
            break;
          this.thisDCAPro.ConnectedState = DCAProUnit.STATE.UNCONNECTED;
          break;
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void timerPulse_Tick(object sender, EventArgs e)
  {
    try
    {
      if (this.TimerTicking)
        return;
      this.TimerTicking = true;
      if (!this.bgWorkerTest.IsBusy && this.Splash.Opacity == 0.0 && this.UpdateChecked)
      {
        this.CheckAndPromptUpdate();
        this.UpdateChecked = false;
      }
      switch (this.thisDCAPro.ConnectedState)
      {
        case DCAProUnit.STATE.UNCONNECTED:
          this.programFirmwareToolStripMenuItem.Enabled = true;
          this.LCDToolStripMenuItem.Enabled = false;
          int theDevice1 = (int) this.thisDCAPro.Comms.FindTheDevice();
          this.WasConnected = false;
          this.DCAFWValid = true;
          if (this.thisDCAPro.ConnectedState == DCAProUnit.STATE.UNCONNECTED)
          {
            this.thisDCAPro.Boot.FindTheDevice(1, 1);
            break;
          }
          break;
        case DCAProUnit.STATE.PRESENT:
          int theDevice2 = (int) this.thisDCAPro.Comms.FindTheDevice();
          break;
        case DCAProUnit.STATE.CONNECTED:
          if (!this.bgWorkerTest.IsBusy)
          {
            if (!this.WasConnected)
            {
              if (this.thisDCAPro.VersionNum != Settings.Default.RequiredFWVersionNum)
              {
                if (this.DCAFWValid)
                {
                  this.DCAFWValid = false;
                  if (MessageBox.Show((IWin32Window) this, $"DCAPro firmware is not correct\nfor this software version.\nRequired firmware: {Settings.Default.RequiredFWVersionNum}\nCurrent firmware: {this.thisDCAPro.VersionNum}\nProgram DCAPro now?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    this.ProgramUnit(Settings.Default.RequiredFWFile);
                }
                this.programFirmwareToolStripMenuItem.Enabled = true;
                this.LCDToolStripMenuItem.Enabled = false;
              }
              else
                this.DCAFWValid = true;
            }
            if (this.DCAFWValid)
            {
              this.EnableAllButtons();
              if (this.thisDCAPro.GetStateAck(Test.STATE.IDLE) == Errors.Type.ErrNone)
              {
                this.UpdateState(this.thisDCAPro.State);
                if (this.thisDCAPro.State == Test.STATE.TESTED || !this.WasConnected)
                {
                  if (!this.WasConnected)
                    this.UpdateConnectedStatus(this.thisDCAPro.ConnectedState);
                  if (this.thisDCAPro.GetStateAck(Test.STATE.TESTED_ACK) == Errors.Type.ErrNone)
                  {
                    this.WasConnected = true;
                    this.DoGrabStatus();
                  }
                }
              }
              this.programFirmwareToolStripMenuItem.Enabled = true;
              this.LCDToolStripMenuItem.Enabled = true;
              break;
            }
            break;
          }
          break;
        case DCAProUnit.STATE.BOOTPRESENT:
          this.thisDCAPro.Boot.FindTheDevice(1, 1);
          break;
        case DCAProUnit.STATE.BOOTCONNECTED:
          this.programFirmwareToolStripMenuItem.Enabled = true;
          this.LCDToolStripMenuItem.Enabled = false;
          break;
      }
      switch (this.FormClosingState)
      {
        case 1:
          if (this.bgWorkerTest.IsBusy || this.UserWait)
          {
            this.bgWorkerTest.CancelAsync();
            this.FormClosingState = 2;
            this.ClosingTimeout = 5000;
            break;
          }
          break;
        case 2:
          if (!this.bgWorkerTest.IsBusy)
          {
            this.FormClosingState = 3;
            break;
          }
          this.ClosingTimeout -= this.timerPulse.Interval;
          if (this.ClosingTimeout <= 0)
          {
            int num1 = (int) this.thisDCAPro.LeadsSafe();
            int num2 = (int) this.thisDCAPro.Mode(Test.MODE.NONE);
            this.FormClosingState = 3;
            break;
          }
          break;
        case 3:
          if (!this.UserWait)
          {
            this.Close();
            break;
          }
          break;
      }
      if (this.PreviousState != this.thisDCAPro.ConnectedState)
      {
        if (this.UpdateConnectedStatus(this.thisDCAPro.ConnectedState))
        {
          this.Refresh();
          this.UpdateErrorStatus(this.thisDCAPro.LastError);
        }
        this.PreviousState = this.thisDCAPro.ConnectedState;
      }
      this.TimerTicking = false;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void ShowIdentifyResult(Test.unResultDevice TheResult)
  {
    try
    {
      string formText = "";
      string str1 = "";
      this.AddResultText("Clear", formText);
      if (this.lLabelCompTrace.Text.Contains("Component") && this.textGlobalTracePrefix.Text != "")
      {
        this.AddResultText("AddItem", this.textGlobalTracePrefix.Text.Replace("#", int.Parse(this.numGlobalTraceN.Text).ToString()) + $"{Display.TextboxNewline}");
        formText = "";
      }
      switch (TheResult.Type)
      {
        case Test.TYPE.NONE:
          formText += string.Format("No component detected");
          str1 = string.Format("No component");
          break;
        case Test.TYPE.BJT:
          string str2 = TheResult.BJT.Config >= Test.CONFIG.Ps ? formText + string.Format("PNP ") : formText + string.Format("NPN ");
          if ((TheResult.BJT.Flags & Test.BJTFlags.Darlington) != (Test.BJTFlags) 0)
            str2 += string.Format("Darlington BJT");
          else if ((TheResult.BJT.Flags & Test.BJTFlags.Silicon) != (Test.BJTFlags) 0)
            str2 += string.Format("Silicon BJT");
          else if ((TheResult.BJT.Flags & Test.BJTFlags.Germanium) != (Test.BJTFlags) 0)
            str2 += string.Format("Germanium BJT");
          else if ((TheResult.BJT.Flags & Test.BJTFlags.Digital) != (Test.BJTFlags) 0)
            str2 += string.Format("Digital BJT");
          str1 = str2;
          string str3 = str2 + $"{Display.TextboxNewline}" + Display.LeadString(TheResult.BJT.Config, "E", "C", "B");
          string str4 = (double) TheResult.BJT.HFE < 32000.0 ? str3 + string.Format("{2}hFE={0:F0} at Ic={1:F2}mA", (object) Display.SetSigFigs((double) TheResult.BJT.HFE, 3), (object) TheResult.BJT.Ic, (object) Display.TextboxNewline) : str3 + $"{Display.TextboxNewline}hFE >32000, ";
          string str5 = (TheResult.BJT.Flags & Test.BJTFlags.Digital) == (Test.BJTFlags) 0 ? str4 + string.Format("{2}Vbe={0:F3}V at Ib={1:F2}mA", (object) TheResult.BJT.Vbe, (object) TheResult.BJT.Ib, (object) Display.TextboxNewline) : str4 + string.Format("{2}Vi(on)={0:F3}V at Ic={1:F2}mA", (object) TheResult.BJT.Vbe, (object) TheResult.BJT.IcOn, (object) Display.TextboxNewline) + string.Format("{2}Vi(off)={0:F3}V at Ic={1:F2}mA", (object) TheResult.BJT.ViOff, (object) TheResult.BJT.IcOff, (object) Display.TextboxNewline);
          if ((double) TheResult.BJT.IcSat != 0.0)
          {
            if ((TheResult.BJT.Flags & Test.BJTFlags.Digital) != (Test.BJTFlags) 0)
              str5 = str5 + string.Format("{2}VceSat={0:F3}V at Ic={1:F1}mA", (object) Display.SetSigFigs((double) TheResult.BJT.VceSat, 3), (object) TheResult.BJT.IcSat, (object) Display.TextboxNewline) + string.Format("{2} and Ib={0:F2}mA with Vbe={1:F1}V", (object) TheResult.BJT.IbSat, (object) 5f, (object) Display.TextboxNewline);
            else
              str5 += string.Format("{3}VceSat={0:F3}V at Ic={1:F1}mA and Ib={2:F2}mA", (object) Display.SetSigFigs((double) TheResult.BJT.VceSat, 3), (object) TheResult.BJT.IcSat, (object) TheResult.BJT.IbSat, (object) Display.TextboxNewline);
          }
          formText = (double) TheResult.BJT.IcLeak >= 0.0099999997764825821 ? str5 + string.Format("{1}IcLeak={0:F3}mA\t", (object) TheResult.BJT.IcLeak, (object) Display.TextboxNewline) : str5 + $"{Display.TextboxNewline}IcLeak=0.000mA";
          if ((double) TheResult.BJT.Rinput > 500.0)
            formText += string.Format("{1}Rinput={0:F0}R", (object) Display.SetSigFigs((double) TheResult.BJT.Rinput, 3), (object) Display.TextboxNewline);
          if ((double) TheResult.BJT.Rshunt > 1.0 && (TheResult.BJT.Flags & Test.BJTFlags.Germanium) == (Test.BJTFlags) 0)
            formText += string.Format("{1}Rshunt={0:F0}R", (object) Display.SetSigFigs((double) TheResult.BJT.Rshunt, 3), (object) Display.TextboxNewline);
          if ((TheResult.BJT.Flags & Test.BJTFlags.DiodeProt) != (Test.BJTFlags) 0)
          {
            formText += $"{Display.TextboxNewline}with protection diode";
            break;
          }
          break;
        case Test.TYPE.MOSFET:
          string str6 = TheResult.MOSFET.Config >= Test.CONFIG.Ps ? formText + string.Format("P-Ch ") : formText + string.Format("N-Ch ");
          string str7 = ((TheResult.MOSFET.Flags & Test.MOSFETFlags.DepletionMode) != (Test.MOSFETFlags) 0 ? str6 + string.Format("Depletion mode ") : str6 + string.Format("Enhancement mode ")) + string.Format("MOSFET");
          string Gate1 = "G";
          string MT1_1 = "S";
          string MT2_1 = "D";
          str1 = str7;
          string str8 = str7 + $"{Display.TextboxNewline}" + Display.LeadString(TheResult.MOSFET.Config, MT1_1, MT2_1, Gate1) + string.Format("{3}Vgs(on)={0:F3}V at Id={1:F2}mA and Ig={2:F0}µA", (object) TheResult.MOSFET.Vgth, (object) TheResult.MOSFET.IdOn, (object) ((double) TheResult.MOSFET.IgOn * 1000.0), (object) Display.TextboxNewline) + string.Format("{2}Vgs(off)={0:F3}V at Id={1:F1}µA", (object) TheResult.MOSFET.VgOff, (object) ((double) TheResult.MOSFET.IdOff * 1000.0), (object) Display.TextboxNewline);
          if ((double) TheResult.MOSFET.gm < 100.0)
            formText = str8 + string.Format("{3}gm={0:F1}mA/V at Id={1:F1}mA to {2:F1}mA", (object) TheResult.MOSFET.gm, (object) TheResult.MOSFET.IdOn2, (object) TheResult.MOSFET.IdOn, (object) Display.TextboxNewline);
          else
            formText = str8 + string.Format("{3}gm>99mA/V at Id={1:F1}mA to {2:F1}mA", (object) TheResult.MOSFET.gm, (object) TheResult.MOSFET.IdOn2, (object) TheResult.MOSFET.IdOn, (object) Display.TextboxNewline);
          if ((double) TheResult.MOSFET.IdSat != 0.0)
          {
            if ((double) TheResult.MOSFET.Rds < 1.0)
              formText += string.Format("{3}Rds(on)<1.0Ω at Id={1:F1}mA and Vgs={2:F1}V", (object) TheResult.MOSFET.Rds, (object) TheResult.MOSFET.IdSat, (object) 8f, (object) Display.TextboxNewline);
            else
              formText += string.Format("{3}Rds(on)={0:F1}Ω at Id={1:F1}mA and Vgs={2:F1}V", (object) TheResult.MOSFET.Rds, (object) TheResult.MOSFET.IdSat, (object) 8f, (object) Display.TextboxNewline);
          }
          if ((TheResult.MOSFET.Flags & Test.MOSFETFlags.DiodeProt) != (Test.MOSFETFlags) 0)
          {
            formText += $"{Display.TextboxNewline}with body diode";
            if ((TheResult.MOSFET.Flags & Test.MOSFETFlags.GateProt) != (Test.MOSFETFlags) 0)
            {
              formText += string.Format(" and gate protection");
              break;
            }
            break;
          }
          if ((TheResult.MOSFET.Flags & Test.MOSFETFlags.GateProt) != (Test.MOSFETFlags) 0)
          {
            formText += $"{Display.TextboxNewline}with gate protection";
            break;
          }
          break;
        case Test.TYPE.IGBT:
          string str9 = TheResult.IGBT.Config >= Test.CONFIG.Ps ? formText + string.Format("P-Ch ") : formText + string.Format("N-Ch ");
          string str10 = ((TheResult.IGBT.Flags & Test.IGBTFlags.DepletionMode) != (Test.IGBTFlags) 0 ? str9 + string.Format("Depletion mode ") : str9 + string.Format("Enhancement mode ")) + string.Format("IGBT");
          string Gate2 = "G";
          string MT1_2 = "E";
          string MT2_2 = "C";
          str1 = str10;
          string str11 = str10 + $"{Display.TextboxNewline}" + Display.LeadString(TheResult.MOSFET.Config, MT1_2, MT2_2, Gate2) + string.Format("{3}Vge(on)={0:F3}V at Ic={1:F2}mA and Ig={2:F0}µA", (object) TheResult.IGBT.Vgth, (object) TheResult.IGBT.IcOn, (object) ((double) TheResult.IGBT.IgOn * 1000.0), (object) Display.TextboxNewline) + string.Format("{2}Vge(off)={0:F3}V at Ic={1:F1}µA", (object) TheResult.IGBT.VgOff, (object) ((double) TheResult.IGBT.IcOff * 1000.0), (object) Display.TextboxNewline);
          if ((double) TheResult.IGBT.gfe < 100.0)
            formText = str11 + string.Format("{3}gfe={0:F1}mA/V at Ic={1:F1}mA to {2:F1}mA", (object) TheResult.IGBT.gfe, (object) TheResult.IGBT.IcOn2, (object) TheResult.IGBT.IcOn, (object) Display.TextboxNewline);
          else
            formText = str11 + string.Format("{3}gfe>99mA/V at Ic={1:F1}mA to {2:F1}mA", (object) TheResult.IGBT.gfe, (object) TheResult.IGBT.IcOn2, (object) TheResult.IGBT.IcOn, (object) Display.TextboxNewline);
          if ((double) TheResult.IGBT.IcSat != 0.0)
            formText += string.Format("{3}VceSat={0:F3}V at Ic={1:F1}mA and Vge={2:F1}V", (object) TheResult.IGBT.VceSat, (object) TheResult.IGBT.IcSat, (object) TheResult.IGBT.VgSat, (object) Display.TextboxNewline);
          if ((TheResult.IGBT.Flags & Test.IGBTFlags.DiodeProt) != (Test.IGBTFlags) 0)
          {
            formText += $"{Display.TextboxNewline}with body diode";
            if ((TheResult.IGBT.Flags & Test.IGBTFlags.GateProt) != (Test.IGBTFlags) 0)
            {
              formText += string.Format(" and gate protection");
              break;
            }
            break;
          }
          if ((TheResult.IGBT.Flags & Test.IGBTFlags.GateProt) != (Test.IGBTFlags) 0)
          {
            formText += $"{Display.TextboxNewline}with gate protection";
            break;
          }
          break;
        case Test.TYPE.SCR:
          string str12 = formText + string.Format("Thyristor (SCR)");
          str1 = str12;
          string str13 = str12 + $"{Display.TextboxNewline}" + Display.LeadString(TheResult.SCR.Config, "K", "A", "G");
          if ((double) TheResult.SCR.Igt != 0.0 || (double) TheResult.SCR.Vgt != 0.0)
            str13 = (double) TheResult.SCR.Igt >= 1.0 ? str13 + $"{Display.TextboxNewline}Igt={TheResult.SCR.Igt:F2}mA at Vgt={TheResult.SCR.Vgt:F3}V" : str13 + $"{Display.TextboxNewline}Igt={(double) TheResult.SCR.Igt * 1000.0:F0}uA at Vgt={TheResult.SCR.Vgt:F3}V";
          if ((double) TheResult.SCR.IaL != 0.0 || (double) TheResult.SCR.IaH != 0.0)
            str13 = str13 + $"{Display.TextboxNewline}IaLatch={TheResult.SCR.IaL:F2}mA with Ig={TheResult.SCR.IgL:F2}mA" + $"{Display.TextboxNewline}IaHold={TheResult.SCR.IaH:F2}mA";
          if ((double) TheResult.SCR.VgkOn != 0.0 || (double) TheResult.SCR.VakOn != 0.0)
            str13 = str13 + $"{Display.TextboxNewline}VakOn={TheResult.SCR.VakOn:F3}V and Vgk={TheResult.SCR.VgkOn:F3}V" + $"{Display.TextboxNewline} at Ia={TheResult.SCR.IaOn:F1}mA";
          formText = str13 + $"{Display.TextboxNewline}IaLeak={TheResult.SCR.ILeak:F3}mA at Vak={TheResult.SCR.VLeak:F1}V";
          break;
        case Test.TYPE.TRIAC:
          string str14 = formText + string.Format("Triac");
          str1 = str14;
          formText = str14 + $"{Display.TextboxNewline}" + Display.LeadString(TheResult.Triac.Config, "MT1", "MT2", "G");
          break;
        case Test.TYPE.DIODE:
          switch (TheResult.Diodes.Number)
          {
            case 0:
              formText += string.Format("Diode detect error.");
              str1 = string.Format("Diode detect error");
              break;
            case 1:
              formText = formText + $"{Display.DiodeTypeString(TheResult.Diodes.Diode1.Type)}{Display.TextboxNewline}" + Display.DiodeLeadsString(TheResult.Diodes.Diode1.Config) + Display.DiodeResults(TheResult.Diodes.Diode1);
              str1 = Display.DiodeTypeString(TheResult.Diodes.Diode1.Type);
              break;
            case 2:
              string str15;
              if (TheResult.Diodes.Diode1.Type == Test.DIODE.LED && TheResult.Diodes.Diode2.Type == Test.DIODE.LED)
              {
                string str16 = formText + string.Format("Bicolour LED (3 lead)");
                str1 = str16;
                str15 = str16 + $"{Display.TextboxNewline}" + Display.DiodeCACCString(TheResult.Diodes.DiodePattern);
              }
              else if (TheResult.Diodes.Diode1.Type == Test.DIODE.DUAL_LED && TheResult.Diodes.Diode2.Type == Test.DIODE.DUAL_LED)
              {
                str15 = formText + string.Format("Bicolour LED (2 lead)");
                str1 = str15;
              }
              else
              {
                string str17 = formText + string.Format("2 diode junctions");
                str1 = str17;
                str15 = str17 + $"{Display.TextboxNewline}" + Display.DiodeCACCString(TheResult.Diodes.DiodePattern);
              }
              formText = str15 + string.Format("{1}#1: {0}{1}", (object) Display.DiodeTypeString(TheResult.Diodes.Diode1.Type), (object) Display.TextboxNewline) + Display.DiodeLeadsString(TheResult.Diodes.Diode1.Config) + Display.DiodeResults(TheResult.Diodes.Diode1) + string.Format("{1}#2: {0}{1}", (object) Display.DiodeTypeString(TheResult.Diodes.Diode2.Type), (object) Display.TextboxNewline) + Display.DiodeLeadsString(TheResult.Diodes.Diode2.Config) + Display.DiodeResults(TheResult.Diodes.Diode2);
              break;
            case 3:
            case 4:
            case 5:
            case 6:
              formText += string.Format("Diode detect error.");
              str1 = string.Format("Diode detect error");
              break;
          }
          break;
        case Test.TYPE.SHORT:
          if (TheResult.Short.Shorts == (Test.SHORT.RED | Test.SHORT.GREEN | Test.SHORT.BLUE))
          {
            formText += string.Format("Red, Green & Blue leads shorted.");
            str1 = string.Format("Red, Green & Blue leads shorted");
            break;
          }
          if (TheResult.Short.Shorts == (Test.SHORT.RED | Test.SHORT.GREEN))
          {
            formText += string.Format("Red & Green leads shorted.");
            str1 = string.Format("Red & Green leads shorted");
            break;
          }
          if (TheResult.Short.Shorts == (Test.SHORT.RED | Test.SHORT.BLUE))
          {
            formText += string.Format("Red & Blue leads shorted.");
            str1 = string.Format("Red & Blue leads shorted");
            break;
          }
          if (TheResult.Short.Shorts == (Test.SHORT.GREEN | Test.SHORT.BLUE))
          {
            formText += string.Format("Green & Blue leads shorted.");
            str1 = string.Format("Green & Blue leads shorted");
            break;
          }
          formText += string.Format("Leads are shorted.");
          str1 = string.Format("Leads are shorted");
          break;
        case Test.TYPE.JFET:
          string str18 = TheResult.JFET.Config >= Test.CONFIG.Ps ? formText + string.Format("P-Ch ") : formText + string.Format("N-Ch ");
          if ((TheResult.JFET.Flags & Test.JFETFlags.NormallyOff) != (Test.JFETFlags) 0)
            str18 += string.Format("normally off ");
          string str19 = str18 + string.Format("JFET");
          str1 = str19;
          string str20 = str19 + $"{Display.TextboxNewline}";
          string str21 = ((TheResult.JFET.Flags & Test.JFETFlags.MirroredDS) != (Test.JFETFlags) 0 ? str20 + $"{Display.ColourG(TheResult.JFET.Config)}-G, Symmetrical Src/Drn" : str20 + Display.LeadString(TheResult.JFET.Config, "S", "D", "G")) + string.Format("{2}Vgs(off)={0:F2}V at Id={1:F1}µA", (object) TheResult.JFET.VgsOff, (object) (float) ((double) TheResult.JFET.IdOff * 1000.0), (object) Display.TextboxNewline) + string.Format("{2}Vgs(on)={0:F2}V at Id={1:F2}mA", (object) TheResult.JFET.VgsOn, (object) TheResult.JFET.IdOn, (object) Display.TextboxNewline);
          if ((double) TheResult.JFET.gfs < 100.0)
            formText = str21 + string.Format("{3}gfs={0:F1}mA/V at Id={1:F1}mA to {2:F1}mA", (object) TheResult.JFET.gfs, (object) TheResult.JFET.IdOn2, (object) TheResult.JFET.IdOn, (object) Display.TextboxNewline);
          else
            formText = str21 + string.Format("{3}gfs>99mA/V at Id={1:F1}mA to {2:F1}mA", (object) TheResult.JFET.gfs, (object) TheResult.JFET.IdOn2, (object) TheResult.JFET.IdOn, (object) Display.TextboxNewline);
          if ((TheResult.JFET.Flags & Test.JFETFlags.NormallyOff) == (Test.JFETFlags) 0)
          {
            if (DCAProUnit.IsZero((double) TheResult.JFET.Vgszero, 0.0099999997764825821))
              formText = (double) TheResult.JFET.Idzero <= 12.0 ? formText + string.Format("{2}Idss={0:F2}mA at Vds={1:F2}V", (object) TheResult.JFET.Idzero, (object) TheResult.JFET.Vdszero, (object) Display.TextboxNewline) : formText + string.Format("{2}Idss>12.00mA at Vds={1:F2}V", (object) TheResult.JFET.Idzero, (object) TheResult.JFET.Vdszero, (object) Display.TextboxNewline);
            else if ((double) TheResult.JFET.Idzero > 12.0)
              formText += string.Format("{3}Id>12.00mA at Vgs={1:F2} and Vds={2:F2}V", (object) TheResult.JFET.Idzero, (object) TheResult.JFET.Vgszero, (object) TheResult.JFET.Vdszero, (object) Display.TextboxNewline);
            else
              formText += string.Format("{3}Id={0:F2}mA at Vgs={1:F2} and Vds={2:F2}V", (object) TheResult.JFET.Idzero, (object) TheResult.JFET.Vgszero, (object) TheResult.JFET.Vdszero, (object) Display.TextboxNewline);
            if ((double) TheResult.JFET.IdRds != 0.0)
            {
              if ((double) TheResult.JFET.Rds < 1.0)
              {
                formText += string.Format("{3}Rds(on)<1.0Ω at Id={1:F1}mA and Vgs={2:F1}V", (object) TheResult.JFET.Rds, (object) TheResult.JFET.IdRds, (object) 0.0, (object) Display.TextboxNewline);
                break;
              }
              formText += string.Format("{3}Rds(on)={0:F1}Ω at Id={1:F1}mA and Vgs={2:F1}V", (object) TheResult.JFET.Rds, (object) TheResult.JFET.IdRds, (object) 0.0, (object) Display.TextboxNewline);
              break;
            }
            break;
          }
          if ((double) TheResult.JFET.IdRds != 0.0)
          {
            if ((double) TheResult.JFET.Rds < 1.0)
            {
              formText += string.Format("{3}Rds(on)<1.0Ω at Id={1:F1}mA and Vgs={2:F1}V", (object) TheResult.JFET.Rds, (object) TheResult.JFET.IdRds, (object) TheResult.JFET.VgsSat, (object) Display.TextboxNewline);
              break;
            }
            formText += string.Format("{3}Rds(on)={0:F1}Ω at Id={1:F1}mA and Vgs={2:F1}V", (object) TheResult.JFET.Rds, (object) TheResult.JFET.IdRds, (object) TheResult.JFET.VgsSat, (object) Display.TextboxNewline);
            break;
          }
          break;
        case Test.TYPE.VREG:
          string str22 = formText + string.Format("Voltage Regulator");
          str1 = str22;
          string str23 = str22 + $"{Display.TextboxNewline}" + Display.LeadString(TheResult.VReg.Config, "In", "GND", "Out") + string.Format("{1}Vout={0:F3}V", (object) TheResult.VReg.VReg, (object) Display.TextboxNewline) + string.Format("{1}Iq={0:F2}mA", (object) TheResult.VReg.Iq, (object) Display.TextboxNewline);
          if ((double) TheResult.VReg.Vdo != 0.0)
            str23 += string.Format("{1}Vdo={0:F2}V", (object) TheResult.VReg.Vdo, (object) Display.TextboxNewline);
          formText = str23 + string.Format("{1}dVout={0:F3}V", (object) TheResult.VReg.dVOut, (object) Display.TextboxNewline);
          if ((double) Math.Abs(TheResult.VReg.dVOut / TheResult.VReg.VReg) > 0.05000000074505806)
          {
            formText += " (>5%)";
            break;
          }
          break;
      }
      this.AddResultText("AddItem", formText);
      this.toolStripIdentify.Text = str1;
      this.pictureResult.Image = (Image) Display.PickResultPictogram(TheResult);
      this.textComments.Text = "";
      this.textComments.Text = Display.PickResultComments(TheResult);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void NewResult_Event(frmDCAProApp m, frmDCAProApp.AResult e)
  {
    this.SetTabMenuItems(e.Result.Type);
    this.UpdateComponentN();
  }

  internal void ButtonsForDisconnect()
  {
    this.NewDisEnable.Enable = false;
    this.NewDisEnable.Result = this.thisDCAPro.Result;
    this.NewDisEnableEvent(this, this.NewDisEnable);
    this.buttonIdentify.Enabled = false;
    this.LCDToolStripMenuItem.Enabled = false;
  }

  internal void DisableAllButtons()
  {
    this.NewDisEnable.Enable = false;
    this.NewDisEnable.Result = this.thisDCAPro.Result;
    this.NewDisEnableEvent(this, this.NewDisEnable);
    this.buttonIdentify.Enabled = false;
    this.programFirmwareToolStripMenuItem.Enabled = false;
    this.LCDToolStripMenuItem.Enabled = false;
    this.menuDataLoadData.Enabled = false;
    this.menuDataSaveData.Enabled = false;
    this.menuDataCopyData.Enabled = false;
    foreach (object dropDownItem in (ArrangedElementCollection) this.graphsToolStripMenuItem.DropDownItems)
    {
      if (dropDownItem is ToolStripMenuItem)
        ((ToolStripItem) dropDownItem).Enabled = false;
    }
    this.hideLegendTSMI.Enabled = true;
    this.fontSizeTSMI.Enabled = true;
    this.fontSizeTSMI1.Enabled = true;
    this.MenuCheckForUpdates.Enabled = false;
  }

  private void EnableAllButtons()
  {
    this.NewDisEnable.Enable = true;
    this.NewDisEnable.Result = this.thisDCAPro.Result;
    this.NewDisEnableEvent(this, this.NewDisEnable);
    this.buttonIdentify.Enabled = true;
    this.buttonIdentify.Text = "Test";
    this.programFirmwareToolStripMenuItem.Enabled = true;
    this.LCDToolStripMenuItem.Enabled = true;
    this.menuDataLoadData.Enabled = true;
    this.menuDataSaveData.Enabled = true;
    this.menuDataCopyData.Enabled = true;
    foreach (object dropDownItem in (ArrangedElementCollection) this.graphsToolStripMenuItem.DropDownItems)
    {
      if (dropDownItem is ToolStripMenuItem)
        ((ToolStripItem) dropDownItem).Enabled = true;
    }
    this.MenuCheckForUpdates.Enabled = true;
  }

  private void SetTabMenuItems(Test.TYPE ResultType)
  {
    try
    {
      switch (ResultType)
      {
        case Test.TYPE.BJT:
          this.SubMenuItems_Check(this.BJTMenuCategory, true);
          break;
        case Test.TYPE.MOSFET:
          this.SubMenuItems_Check(this.MOSFETMenuCategory, true);
          break;
        case Test.TYPE.IGBT:
          this.SubMenuItems_Check(this.IGBTMenuCategory, true);
          break;
        case Test.TYPE.DIODE:
          this.PNJunctMenuItem.Checked = true;
          break;
        case Test.TYPE.JFET:
          this.SubMenuItems_Check(this.JFETMenuCategory, true);
          break;
        case Test.TYPE.VREG:
          this.SubMenuItems_Check(this.VRegMenuCategory, true);
          break;
      }
      this.UpdateAllTestTabs((ToolStripMenuItem) null);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void SetSelectTabMenuItem(ToolStripMenuItem Item, bool State)
  {
    try
    {
      Item.Checked = State;
      this.UpdateAllTestTabs(Item);
      if (!State)
        return;
      this.tabControl.SelectedTab = Item.Tag as TabPage;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void bgWorkerTest_DoWork(object sender, DoWorkEventArgs e)
  {
    try
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      WorkResult workResult = new WorkResult();
      workResult.DoType = (ACT) e.Argument;
      switch (workResult.DoType)
      {
        case ACT.IDENTIFY:
          workResult.Data = (object) this.IdentifyTest(worker);
          break;
        case ACT.GRAPH_PN:
          this.Graphs[0].DoGraph(worker, workResult);
          break;
        case ACT.GRAPH_ICVCE:
          this.Graphs[1].DoGraph(worker, workResult);
          break;
        case ACT.GRAPH_ICVBE:
          this.Graphs[2].DoGraph(worker, workResult);
          break;
        case ACT.GRAPH_HFEIC:
          this.Graphs[3].DoGraph(worker, workResult);
          break;
        case ACT.GRAPH_ICIB:
          this.Graphs[4].DoGraph(worker, workResult);
          break;
        case ACT.GRAPH_HFEVCE:
          this.Graphs[5].DoGraph(worker, workResult);
          break;
        case ACT.GRAPH_IDVDS:
          this.Graphs[6].DoGraph(worker, workResult);
          break;
        case ACT.GRAPH_IDVGS:
          this.Graphs[7].DoGraph(worker, workResult);
          break;
        case ACT.GRAPH_TICVCE:
          this.Graphs[8].DoGraph(worker, workResult);
          break;
        case ACT.GRAPH_TICVGE:
          this.Graphs[9].DoGraph(worker, workResult);
          break;
        case ACT.GRAPH_JIDVDS:
          this.Graphs[10].DoGraph(worker, workResult);
          break;
        case ACT.GRAPH_JIDVGS:
          this.Graphs[11].DoGraph(worker, workResult);
          break;
        case ACT.GRAPH_VREGOI:
          this.Graphs[12].DoGraph(worker, workResult);
          break;
        case ACT.GRAB:
          workResult.Data = (object) this.GrabResults(worker);
          break;
        case ACT.BOOT_ENABLE:
          workResult.Data = (object) this.FindBootloader(worker);
          break;
        case ACT.BOOT_PROGRAM:
          workResult.Data = (object) this.thisDCAPro.Boot.ProgramStart(worker, workResult);
          break;
        case ACT.BOOT_RESET:
          workResult.Data = (object) this.thisDCAPro.Boot.ResetStart(worker, workResult);
          break;
      }
      e.Result = (object) workResult;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void bgWorkerTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
  {
    try
    {
      WorkResult userState = e.UserState as WorkResult;
      if (this.timerDisplay.Enabled)
        return;
      this.timerDisplay.Enabled = true;
      if (userState.Progress < 100)
      {
        this.toolStripProgressBar.Value = userState.Progress + 1;
        this.toolStripProgressBar.Value = userState.Progress;
      }
      else
      {
        this.toolStripProgressBar.Value = 100;
        this.toolStripProgressBar.Value = 99;
        this.toolStripProgressBar.Value = 100;
      }
      switch (userState.DoType)
      {
        case ACT.IDENTIFY:
          this.toolStripProgressLabel.Text = "Identifying...";
          break;
        case ACT.GRAPH_PN:
          this.Graphs[0].Refresh();
          break;
        case ACT.GRAPH_ICVCE:
          this.Graphs[1].Refresh();
          break;
        case ACT.GRAPH_ICVBE:
          this.Graphs[2].Refresh();
          break;
        case ACT.GRAPH_HFEIC:
          this.Graphs[3].Refresh();
          break;
        case ACT.GRAPH_ICIB:
          this.Graphs[4].Refresh();
          break;
        case ACT.GRAPH_HFEVCE:
          this.Graphs[5].Refresh();
          break;
        case ACT.GRAPH_IDVDS:
          this.Graphs[6].Refresh();
          break;
        case ACT.GRAPH_IDVGS:
          this.Graphs[7].Refresh();
          break;
        case ACT.GRAPH_TICVCE:
          this.Graphs[8].Refresh();
          break;
        case ACT.GRAPH_TICVGE:
          this.Graphs[9].Refresh();
          break;
        case ACT.GRAPH_JIDVDS:
          this.Graphs[10].Refresh();
          break;
        case ACT.GRAPH_JIDVGS:
          this.Graphs[11].Refresh();
          break;
        case ACT.GRAPH_VREGOI:
          this.Graphs[12].Refresh();
          break;
        case ACT.GRAB:
          this.toolStripProgressLabel.Text = "Fetching result...";
          break;
        case ACT.BOOT_PROGRAM:
          this.toolStripProgressLabel.Text = "Flashing...waiting for bootloader";
          break;
        case ACT.BOOT_RESET:
          this.toolStripProgressLabel.Text = "Resetting...";
          break;
        case ACT.BOOT_PROGRAM_ERASE:
          this.toolStripProgressLabel.Text = "Flashing...erasing";
          break;
        case ACT.BOOT_PROGRAM_PROG:
          this.toolStripProgressLabel.Text = "Flashing...programming";
          break;
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void bgWorkerTest_Complete(object sender, RunWorkerCompletedEventArgs e)
  {
    try
    {
      WorkResult workResult = new WorkResult();
      this.UserWait = true;
      WorkResult result = e.Result as WorkResult;
      switch (result.DoType)
      {
        case ACT.GRAPH_PN:
        case ACT.GRAPH_ICVCE:
        case ACT.GRAPH_ICVBE:
        case ACT.GRAPH_HFEIC:
        case ACT.GRAPH_ICIB:
        case ACT.GRAPH_HFEVCE:
        case ACT.GRAPH_IDVDS:
        case ACT.GRAPH_IDVGS:
        case ACT.GRAPH_TICVCE:
        case ACT.GRAPH_TICVGE:
        case ACT.GRAPH_JIDVDS:
        case ACT.GRAPH_JIDVGS:
        case ACT.GRAPH_VREGOI:
          this.toolStripProgressLabel.Text = "";
          this.EnableAllButtons();
          this.UpdateTraceN();
          break;
        case ACT.GRAB:
          if ((Errors.Type) result.Data == Errors.Type.ErrNone)
          {
            this.EnableAllButtons();
            this.NewResult.Result = this.thisDCAPro.Result;
            this.NewResultEvent(this, this.NewResult);
            this.ShowIdentifyResult(this.NewResult.Result);
            this.tabControl.SelectedTab = this.tabIdentify;
            this.HighlightProgressLabel("New result received.");
            SystemSounds.Exclamation.Play();
            break;
          }
          int num1 = (int) MessageBox.Show("Grab failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.EnableAllButtons();
          break;
        case ACT.BOOT_ENABLE:
          if ((DCAProUnit.STATE) result.Data == DCAProUnit.STATE.BOOTCONNECTED)
            this.ProgramUnit("");
          this.toolStripProgressLabel.Text = "";
          this.EnableAllButtons();
          break;
        case ACT.BOOT_PROGRAM:
        case ACT.BOOT_PROGRAM_ERASE:
        case ACT.BOOT_PROGRAM_PROG:
          switch ((Boot.RESULT) result.Data)
          {
            case Boot.RESULT.SUCCESS:
              this.ResetUnit();
              break;
            default:
              int num2 = (int) MessageBox.Show(string.Format("Programming failed.\nDon't panic!\nPlease reconnect and try again."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              break;
          }
          this.toolStripProgressLabel.Text = "";
          this.EnableAllButtons();
          break;
        case ACT.BOOT_RESET:
          this.toolStripProgressLabel.Text = "";
          this.EnableAllButtons();
          break;
      }
      this.toolStripProgressBar.Value = 0;
      this.Refresh();
    }
    catch (Exception ex)
    {
      throw;
    }
    finally
    {
      this.UserWait = false;
    }
  }

  private void bgWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
  {
    Version version = this.FailedSWVersion;
    bool flag = (bool) e.Argument;
    BackgroundWorker backgroundWorker = sender as BackgroundWorker;
    try
    {
      if (flag)
        backgroundWorker.ReportProgress(0, (object) true);
      WebClient webClient = new WebClient();
      WebRequest webRequest = WebRequest.Create(Settings.Default.VersionFileLocation);
      webRequest.Timeout = 30000;
      WebResponse response = webRequest.GetResponse();
      if (((HttpWebResponse) response).StatusCode == HttpStatusCode.OK)
        version = new Version(new StreamReader(response.GetResponseStream()).ReadLine());
      response.Close();
    }
    catch (Exception ex)
    {
    }
    finally
    {
      e.Result = (object) version;
      if (flag)
        this.ReportUpdate = true;
    }
  }

  private void bgWorkerUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
  {
    try
    {
      if ((bool) e.UserState)
        this.toolStripProgressLabel.Text = "Checking for update...";
      this.Refresh();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void bgWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
  {
    try
    {
      if (this.toolStripProgressLabel.Text == "Checking for update...")
        this.toolStripProgressLabel.Text = "";
      this.CurrentSWVersion = (Version) e.Result;
      this.UpdateChecked = true;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void CheckAndPromptUpdate()
  {
    if (this.CurrentSWVersion == this.FailedSWVersion)
    {
      if (this.ReportUpdate)
      {
        int num1 = (int) MessageBox.Show(string.Format("Can't connect to www.peakelec.co.uk"), "DCA Pro update", MessageBoxButtons.OK);
      }
    }
    else if (this.CurrentSWVersion > this.thisVersion)
    {
      if (this.CurrentSWVersion != new Version(Settings.Default.IgnoredUpdate))
      {
        this.UpdatePrompt.checkBoxIgnoreThis.Checked = Settings.Default.IgnoredUpdate == $"{this.CurrentSWVersion}";
        this.UpdatePrompt.checkBoxIgnoreAll.Checked = !this.MenuCheckForUpdatesAutomatically.Checked;
        this.UpdatePrompt.labelNewVersion.Text = $"New version: {this.CurrentSWVersion}";
        this.UpdatePrompt.labelCurrentVersion.Text = $"This version: {this.thisVersion}";
        this.UpdatePrompt.StartPosition = FormStartPosition.CenterParent;
        int num2 = (int) this.UpdatePrompt.ShowDialog();
        if (this.UpdatePrompt.checkBoxIgnoreThis.Checked)
          Settings.Default.IgnoredUpdate = $"{this.CurrentSWVersion}";
        if (this.UpdatePrompt.checkBoxIgnoreAll.Checked)
        {
          this.MenuCheckForUpdatesAutomatically.Checked = false;
          Settings.Default.CheckUpdates = false;
        }
        else
        {
          this.MenuCheckForUpdatesAutomatically.Checked = true;
          Settings.Default.CheckUpdates = true;
        }
        if (this.UpdatePrompt.FlagUpdateNow)
        {
          this.UpdatePrompt.FlagUpdateNow = false;
          int num3 = (int) this.DLUpdatePrompt.ShowDialog();
        }
      }
    }
    else if (this.ReportUpdate)
    {
      int num4 = (int) MessageBox.Show($"Software is up to date.\nVersion: {this.thisVersion}", "DCA Pro update", MessageBoxButtons.OK);
    }
    this.ReportUpdate = false;
    this.UpdateChecked = false;
  }

  private void checkForUpdatesNow_Click(object sender, EventArgs e)
  {
    if (this.bgWorkerUpdate.IsBusy)
      return;
    this.bgWorkerUpdate.RunWorkerAsync((object) true);
  }

  private void MenuCheckForUpdatesAutomatically_Click(object sender, EventArgs e)
  {
    this.MenuCheckForUpdatesAutomatically.Checked = !this.MenuCheckForUpdatesAutomatically.Checked;
    Settings.Default.CheckUpdates = this.MenuCheckForUpdatesAutomatically.Checked;
    if (!Settings.Default.CheckUpdates || this.bgWorkerUpdate.IsBusy)
      return;
    this.bgWorkerUpdate.RunWorkerAsync((object) true);
  }

  private void programFirmwareToolStripMenuItem_Click(object sender, EventArgs e)
  {
    try
    {
      this.ProgramUnit("");
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void ProgramUnit(string Filename)
  {
    try
    {
      if (this.thisDCAPro.ConnectedState != DCAProUnit.STATE.UNCONNECTED)
      {
        string str = "";
        if (Filename != "")
          str = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\firmware\\{Filename}";
        if (str == "" || !System.IO.File.Exists(str))
        {
          this.openHEXFileDialog.FileName = "*.hex";
          if (this.openHEXFileDialog.ShowDialog() == DialogResult.OK)
            str = this.openHEXFileDialog.FileName;
        }
        if (!(str != "") || !System.IO.File.Exists(str))
          return;
        this.thisDCAPro.Boot.LoadHEXFile(str);
        if (MessageBox.Show($"Program DCAPro with '{str}' ?\nCurrent firmware will be erased.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
          return;
        this.bgWorkerTest.RunWorkerAsync((object) ACT.BOOT_PROGRAM);
      }
      else
      {
        int num = (int) MessageBox.Show(string.Format("DCAPro not\nconnected."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void ResetUnit() => this.bgWorkerTest.RunWorkerAsync((object) ACT.BOOT_RESET);

  private DCAProUnit.STATE FindBootloader(BackgroundWorker worker)
  {
    try
    {
      if (this.thisDCAPro.ConnectedState != DCAProUnit.STATE.BOOTCONNECTED && this.thisDCAPro.ConnectedState != DCAProUnit.STATE.UNCONNECTED)
      {
        for (int index = 6000; this.thisDCAPro.ConnectedState != DCAProUnit.STATE.BOOTCONNECTED && index > 0; index -= 100)
        {
          int num = (int) this.thisDCAPro.BootLoad();
          Thread.Sleep(100);
        }
      }
      return this.thisDCAPro.ConnectedState == DCAProUnit.STATE.BOOTCONNECTED ? this.thisDCAPro.ConnectedState : this.thisDCAPro.ConnectedState;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private bool IdentifyTest(BackgroundWorker worker)
  {
    WorkResult workResult = new WorkResult();
    try
    {
      workResult.Progress = 10;
      workResult.DoType = ACT.IDENTIFY;
      worker.ReportProgress(0, (object) workResult.Clone());
      return this.thisDCAPro.Tests.IdentifyTests();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private Errors.Type GrabResults(BackgroundWorker worker)
  {
    worker.ReportProgress(0, (object) new WorkResult()
    {
      Progress = 0,
      DoType = ACT.GRAB
    }.Clone());
    return this.thisDCAPro.ReadTestResult();
  }

  private void DoGrabStatus()
  {
    this.DisableAllButtons();
    this.bgWorkerTest.RunWorkerAsync((object) ACT.GRAB);
  }

  private void UpdateThisTestTab(ToolStripMenuItem TSMItem, bool Select)
  {
    try
    {
      TabPage tag = TSMItem.Tag as TabPage;
      if (TSMItem.Checked)
      {
        if (!this.tabControl.TabPages.Contains(tag))
          this.tabControl.TabPages.Add(tag);
        if (!Select)
          return;
        this.tabControl.SelectedTab = tag;
      }
      else
      {
        if (!this.tabControl.TabPages.Contains(tag))
          return;
        this.tabControl.TabPages.Remove(tag);
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void UpdateAllTestTabs(ToolStripMenuItem SelectItem)
  {
    try
    {
      this.UpdateThisTestTab(this.PNJunctMenuItem, SelectItem == this.PNJunctMenuItem);
      this.UpdateThisTestTab(this.IcVceBJTMenuSubItem, SelectItem == this.IcVceBJTMenuSubItem);
      this.UpdateThisTestTab(this.HfeVceBJTMenuSubItem, SelectItem == this.HfeVceBJTMenuSubItem);
      this.UpdateThisTestTab(this.HfeIcBJTMenuSubItem, SelectItem == this.HfeIcBJTMenuSubItem);
      this.UpdateThisTestTab(this.IcVbeBJTMenuSubItem, SelectItem == this.IcVbeBJTMenuSubItem);
      this.UpdateThisTestTab(this.IcIbBJTMenuSubItem, SelectItem == this.IcIbBJTMenuSubItem);
      this.UpdateThisTestTab(this.IdVdsMOSFETMenuSubItem, SelectItem == this.IdVdsMOSFETMenuSubItem);
      this.UpdateThisTestTab(this.IdVgsMOSFETMenuSubItem, SelectItem == this.IdVgsMOSFETMenuSubItem);
      this.UpdateThisTestTab(this.IcVceIGBTMenuSubItem, SelectItem == this.IcVceIGBTMenuSubItem);
      this.UpdateThisTestTab(this.IcVgeIGBTMenuSubItem, SelectItem == this.IcVgeIGBTMenuSubItem);
      this.UpdateThisTestTab(this.IdVdsJFETMenuSubItem, SelectItem == this.IdVdsJFETMenuSubItem);
      this.UpdateThisTestTab(this.IdVgsJFETMenuSubItem, SelectItem == this.IdVgsJFETMenuSubItem);
      this.UpdateThisTestTab(this.VoutVinVRegMenuSubItem, SelectItem == this.VoutVinVRegMenuSubItem);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void TestTabs_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (this.tabControl.SelectedIndex == this.tabControl.TabPages.IndexOfKey("tabIdentify"))
    {
      this.menuDataSaveData.Visible = false;
      this.menuDataCopyData.Visible = false;
      this.renameGraphTSMI.Visible = false;
      this.copyImageTSMI.Visible = false;
      this.pageSetupTSMI.Visible = false;
      this.printPreviewTSMI.Visible = false;
      this.printTSMI.Visible = false;
      this.deleteTSMI.Visible = false;
      this.unlockTSMI.Visible = false;
      this.hideLegendTSMI.Visible = false;
      this.fontSizeTSMI.Visible = false;
      this.fontSizeTSMI1.Visible = false;
      this.toolStripSeparator2.Visible = false;
      this.toolStripSeparator3.Visible = false;
    }
    else
    {
      this.menuDataSaveData.Visible = true;
      this.menuDataCopyData.Visible = true;
      this.renameGraphTSMI.Visible = true;
      this.copyImageTSMI.Visible = true;
      this.pageSetupTSMI.Visible = true;
      this.printPreviewTSMI.Visible = true;
      this.printTSMI.Visible = true;
      this.deleteTSMI.Visible = true;
      this.unlockTSMI.Visible = true;
      this.hideLegendTSMI.Visible = true;
      this.fontSizeTSMI.Visible = true;
      this.fontSizeTSMI1.Visible = true;
      this.toolStripSeparator2.Visible = true;
      this.toolStripSeparator3.Visible = true;
    }
  }

  private void MenuTestsItem_Click(object sender, EventArgs e)
  {
    ToolStripMenuItem SelectItem = sender as ToolStripMenuItem;
    if (SelectItem.Checked)
    {
      SelectItem.Checked = false;
      SelectItem = (ToolStripMenuItem) null;
    }
    else
      SelectItem.Checked = true;
    this.UpdateAllTestTabs(SelectItem);
  }

  private void SubMenuItems_Check(ToolStripMenuItem Category, bool ForceOn)
  {
    try
    {
      ToolStripMenuItem ownerItem = Category.OwnerItem as ToolStripMenuItem;
      string tag = (string) Category.Tag;
      if (!Category.Checked || ForceOn)
      {
        foreach (object dropDownItem in (ArrangedElementCollection) ownerItem.DropDownItems)
        {
          if (dropDownItem is ToolStripMenuItem)
          {
            ToolStripMenuItem toolStripMenuItem = dropDownItem as ToolStripMenuItem;
            if (toolStripMenuItem.Name.Contains("MenuSubItem") || toolStripMenuItem.Name.Contains("MenuCategory"))
              toolStripMenuItem.Checked = toolStripMenuItem.Name.Contains(tag) && toolStripMenuItem.Enabled;
          }
        }
      }
      else
      {
        Category.Checked = false;
        foreach (object dropDownItem in (ArrangedElementCollection) ownerItem.DropDownItems)
        {
          if (dropDownItem is ToolStripMenuItem)
          {
            ToolStripMenuItem toolStripMenuItem = dropDownItem as ToolStripMenuItem;
            if (toolStripMenuItem.Name.Contains("MenuSubItem") && toolStripMenuItem.Name.Contains(tag))
              toolStripMenuItem.Checked = false;
          }
        }
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void MenuTestCategory_Click(object sender, EventArgs e)
  {
    this.SubMenuItems_Check(sender as ToolStripMenuItem, false);
    this.UpdateAllTestTabs((ToolStripMenuItem) null);
  }

  private void MenuLoadData_Click(object sender, EventArgs e)
  {
    try
    {
      this.openDataFileDialog.FileName = "*.txt";
      if (this.openDataFileDialog.ShowDialog() != DialogResult.OK)
        return;
      int num = Graph.LoadDataFiles(this.openDataFileDialog.FileNames, ref this.Graphs);
      if (num > 0)
        this.HighlightProgressLabel($"Loaded {num} traces.");
      else
        this.HighlightProgressLabel("Load failed.", false);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void MenuSaveData_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.tabControl.SelectedTab.Tag == null)
        return;
      (this.tabControl.SelectedTab.Tag as Graph).TraceSaveAll(sender, e);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void MenuCopyData_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.tabControl.SelectedTab.Tag == null)
        return;
      (this.tabControl.SelectedTab.Tag as Graph).TraceCopyAll(sender, e);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void buttonIdentify_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.bgWorkerTest.IsBusy && this.buttonIdentify.Text == "Stop")
      {
        this.bgWorkerTest.CancelAsync();
      }
      else
      {
        this.DisableAllButtons();
        this.buttonIdentify.Text = "Stop";
        this.buttonIdentify.Enabled = true;
        this.bgWorkerTest.RunWorkerAsync((object) ACT.IDENTIFY);
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void TextPNVMin_Validating(object sender, CancelEventArgs e)
  {
    float single = Convert.ToSingle((sender as TextBox).Text);
    if ((double) single >= 0.0 && (double) single <= 12.0)
      return;
    e.Cancel = true;
  }

  private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
  {
    try
    {
      this.About.StartPosition = FormStartPosition.CenterParent;
      int num = (int) this.About.ShowDialog();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void UpdateState(Test.STATE State)
  {
    switch (State)
    {
      case Test.STATE.IDLE:
        this.toolStripState.Text = "State: Idle";
        break;
      case Test.STATE.TESTING:
        this.toolStripState.Text = "State: Testing";
        break;
      case Test.STATE.TESTED:
        this.toolStripState.Text = "State: Tested";
        break;
      case Test.STATE.ACK:
        this.toolStripState.Text = "State: Idle(A)";
        break;
      case Test.STATE.TESTING_ACK:
        this.toolStripState.Text = "State: Testing(A)";
        break;
      case Test.STATE.TESTED_ACK:
        this.toolStripState.Text = "State: Tested(A)";
        break;
      default:
        this.toolStripState.Text = "State: Unknown";
        break;
    }
  }

  private bool UpdateConnectedStatus(DCAProUnit.STATE Connected)
  {
    try
    {
      bool flag = false;
      switch (this.thisDCAPro.ConnectedState)
      {
        case DCAProUnit.STATE.UNCONNECTED:
          this.About.labelDevice.Text = "Not connected";
          this.About.labelType.Text = "";
          this.About.labelFirmType.Text = "";
          this.About.labelSerial.Text = "";
          if (this.toolStripStatusLabelDevice.Text != "DCA Pro disconnected")
          {
            flag = true;
            this.toolStripStatusLabelDevice.Text = "DCA Pro disconnected";
            this.toolStripStatusLabelDevice.BackColor = Color.DarkRed;
            this.ButtonsForDisconnect();
            break;
          }
          break;
        case DCAProUnit.STATE.PRESENT:
          this.About.labelDevice.Text = "???";
          this.About.labelType.Text = this.thisDCAPro.ProductType;
          this.About.labelFirmType.Text = "???";
          this.About.labelSerial.Text = "???";
          if (this.toolStripStatusLabelDevice.Text != "DCA Pro connected")
          {
            flag = true;
            this.toolStripStatusLabelDevice.Text = "DCA Pro connected";
            this.toolStripStatusLabelDevice.BackColor = Color.DarkOrange;
            this.ButtonsForDisconnect();
            break;
          }
          break;
        case DCAProUnit.STATE.CONNECTED:
          this.About.labelDevice.Text = this.thisDCAPro.ProductName;
          this.About.labelType.Text = this.thisDCAPro.ProductType;
          this.About.labelFirmType.Text = this.thisDCAPro.VersionNum;
          this.About.labelSerial.Text = this.thisDCAPro.SerialNum;
          flag = true;
          this.toolStripStatusLabelDevice.Text = "DCA Pro connected";
          this.toolStripStatusLabelDevice.BackColor = Color.DarkGreen;
          break;
        case DCAProUnit.STATE.BOOTPRESENT:
        case DCAProUnit.STATE.BOOTCONNECTED:
          this.About.labelDevice.Text = this.thisDCAPro.Boot.ProductName;
          this.About.labelType.Text = this.thisDCAPro.Boot.MyHid.DeviceAttributes.VER.ToString("X4");
          this.About.labelFirmType.Text = "---";
          this.About.labelSerial.Text = this.thisDCAPro.Boot.SerialNum;
          if (this.toolStripStatusLabelDevice.Text != "DCA Pro Program")
          {
            flag = true;
            this.toolStripStatusLabelDevice.Text = "DCA Pro Program";
            this.toolStripStatusLabelDevice.BackColor = Color.MediumBlue;
            this.DisableAllButtons();
            break;
          }
          break;
      }
      return flag;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void UpdateErrorStatus(Errors.Type Error)
  {
    this.toolStripStatusError.Text = "Error: " + Errors.ErrorToString(Error);
  }

  private void rtextIdentifyResultsContextMenu_ItemClicked(
    object sender,
    ToolStripItemClickedEventArgs e)
  {
    string str = "";
    ContextMenuStrip contextMenuStrip = sender as ContextMenuStrip;
    if (!(e.ClickedItem.Text == "Copy"))
      return;
    str = $"Test Result:{Display.TextboxNewline}";
    Clipboard.SetText((contextMenuStrip.SourceControl as RichTextBox).Text.Replace(Display.TextboxNewline, Environment.NewLine));
  }

  private void copyToolStripMenuItem_Click(object sender, EventArgs e)
  {
    Clipboard.SetText((((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as RichTextBox).Text.Replace(Display.TextboxNewline, Environment.NewLine));
  }

  private void utilitiesToolStripMenuItem_Click(object sender, EventArgs e)
  {
    try
    {
      this.dlgLCDContrast.StartPosition = FormStartPosition.CenterParent;
      int num = (int) this.dlgLCDContrast.ShowDialog();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void HighlightProgressLabel(string Text)
  {
    this.toolStripProgressLabel.Text = Text;
    this.toolStripProgressLabel.BackColor = Color.DeepSkyBlue;
    this.timerDisplay.Enabled = true;
  }

  internal void HighlightProgressLabel(string Text, bool Goodness)
  {
    this.toolStripProgressLabel.Text = Text;
    if (Goodness)
      this.toolStripProgressLabel.BackColor = Color.DeepSkyBlue;
    else
      this.toolStripProgressLabel.BackColor = Color.DarkRed;
    this.timerDisplay.Enabled = true;
  }

  private void timerDisplay_Tick(object sender, EventArgs e)
  {
    if ((int) this.toolStripProgressLabel.BackColor.B != (int) SystemColors.Control.B)
    {
      this.toolStripProgressLabel.BackColor = Color.FromArgb((int) SystemColors.Control.R + ((int) this.toolStripProgressLabel.BackColor.R - (int) SystemColors.Control.R) * 2 / 3, (int) SystemColors.Control.G + ((int) this.toolStripProgressLabel.BackColor.G - (int) SystemColors.Control.G) * 2 / 3, (int) SystemColors.Control.B + ((int) this.toolStripProgressLabel.BackColor.B - (int) SystemColors.Control.B) * 2 / 3);
    }
    else
    {
      this.toolStripProgressLabel.BackColor = SystemColors.Control;
      this.timerDisplay.Enabled = false;
    }
  }

  private void textBox_KeyPress(object sender, KeyPressEventArgs e)
  {
    if (e.KeyChar != '\r')
      return;
    this.tabControl.SelectNextControl(this.ActiveControl, true, true, true, true);
  }

  private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

  private void picCircuit_Click(object sender, EventArgs e)
  {
    ((Control) (sender as PictureBox).Tag).Visible = true;
  }

  private void picCircuit_MouseLeave(object sender, EventArgs e)
  {
    (sender as PictureBox).Visible = false;
  }

  private void MenuItem_Lock(object sender, EventArgs e)
  {
    ((ToolStripDropDown) ((ToolStripItem) sender).Owner).AutoClose = false;
  }

  private void MenuItem_Unlock(object sender, EventArgs e)
  {
    ((ToolStripDropDown) ((ToolStripItem) sender).Owner).AutoClose = true;
  }

  private void fontSizeMenuItemInc_Click(object sender, EventArgs e)
  {
    foreach (Graph graph in this.Graphs)
    {
      graph.thisZedGraph.GraphPane.BaseDimension *= 0.95f;
      graph.Refresh();
    }
  }

  private void fontSizeMenuItemDec_Click(object sender, EventArgs e)
  {
    foreach (Graph graph in this.Graphs)
    {
      graph.thisZedGraph.GraphPane.BaseDimension *= 1.05f;
      graph.Refresh();
    }
  }

  internal virtual int UpdateTraceN()
  {
    string text = this.textGlobalTracePrefix.Text;
    int num = int.Parse(this.numGlobalTraceN.Text);
    if (this.lLabelCompTrace.Text.Contains("Trace") && text.Contains("#"))
    {
      ++num;
      this.numGlobalTraceN.Text = num.ToString();
    }
    return num;
  }

  internal virtual int UpdateComponentN()
  {
    string text = this.textGlobalTracePrefix.Text;
    int num = int.Parse(this.numGlobalTraceN.Text);
    if (this.lLabelCompTrace.Text.Contains("Component") && text.Contains("#"))
    {
      ++num;
      this.numGlobalTraceN.Text = num.ToString();
    }
    return num;
  }

  private void copyImageMenuItem_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.tabControl.SelectedTab.Tag == null)
        return;
      (this.tabControl.SelectedTab.Tag as Graph).thisZedGraph.Copy(false);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void pageSetupMenuItem_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.tabControl.SelectedTab.Tag == null)
        return;
      (this.tabControl.SelectedTab.Tag as Graph).thisZedGraph.DoPageSetup();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void printPreviewMenuItem_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.tabControl.SelectedTab.Tag == null)
        return;
      (this.tabControl.SelectedTab.Tag as Graph).thisZedGraph.DoPrintPreview();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void printMenuItem_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.tabControl.SelectedTab.Tag == null)
        return;
      (this.tabControl.SelectedTab.Tag as Graph).thisZedGraph.DoPrint();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void renameGraphTSMI_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.tabControl.SelectedTab.Tag == null)
        return;
      (this.tabControl.SelectedTab.Tag as Graph).DoRenameGraph();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void resetDefaultGraphNameTSMI_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.tabControl.SelectedTab.Tag == null)
        return;
      Graph tag = this.tabControl.SelectedTab.Tag as Graph;
      tag.thisZedGraph.GraphPane.Title.Text = tag.GraphType;
      ((Control) tag.thisZedGraph).Refresh();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void deleteAllTracesTSMI_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.tabControl.SelectedTab.Tag == null)
        return;
      (this.tabControl.SelectedTab.Tag as Graph).TraceDeleteAll((object) this, new Graph.TraceDeleteEventArgs(true));
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void deleteAllAllTracesTSMI_Click(object sender, EventArgs e)
  {
    try
    {
      if (MessageBox.Show(string.Format("Delete all graph traces?\n(Locked traces will remain)"), "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
        return;
      foreach (Graph graph in this.Graphs)
        graph.TraceDeleteAll((object) this, new Graph.TraceDeleteEventArgs(false));
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void unlockAllTSMI_Click(object sender, EventArgs e)
  {
    try
    {
      foreach (Graph graph in this.Graphs)
        graph.TraceUnlockAll((object) this, (EventArgs) null);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void unlockAllAllTSMI_Click(object sender, EventArgs e)
  {
    try
    {
      foreach (Graph graph in this.Graphs)
        graph.TraceUnlockAll((object) this, (EventArgs) null);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void hideLegendMenuItem_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.tabControl.SelectedTab.Tag == null)
        return;
      (this.tabControl.SelectedTab.Tag as Graph).LegendShowToggle((object) this, (EventArgs) null);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void lLabelCompTrace_Click(object sender, EventArgs e)
  {
    LinkLabel linkLabel = (LinkLabel) sender;
    if (linkLabel.Text.Contains("Component"))
      linkLabel.Text = "Trace name";
    else
      linkLabel.Text = "Component name";
  }

  private void lLabelCompTrace_TextChanged(object sender, EventArgs e)
  {
    LinkLabel linkLabel = (LinkLabel) sender;
    if (linkLabel.Text.Contains("Component"))
    {
      this.ToolTipFrm.SetToolTip((Control) linkLabel, string.Format("For 'Component name', # will increase\nwhen a component is identified.\nClick to switch to 'Trace name'."));
    }
    else
    {
      if (!linkLabel.Text.Contains("Trace"))
        return;
      this.ToolTipFrm.SetToolTip((Control) linkLabel, string.Format("For 'Trace name', # will increase\nafter each Graph is complete.\nClick to switch to 'Component name'."));
    }
  }

  private void textGlobalTracePrefix_KeyDown(object sender, KeyEventArgs e)
  {
    if (e.KeyCode != Keys.Return && e.KeyCode != Keys.Return || !this.lLabelCompTrace.Text.Contains("Component"))
      return;
    this.ShowIdentifyResult(this.thisDCAPro.Result);
  }

  public class AResult : EventArgs
  {
    private Test.unResultDevice ThisResult;

    public Test.unResultDevice Result
    {
      set => this.ThisResult = value;
      get => this.ThisResult;
    }
  }

  internal delegate void ResultEvent(frmDCAProApp m, frmDCAProApp.AResult e);

  public class DisEnable : EventArgs
  {
    private bool ThisEnable;
    private Test.unResultDevice ThisResult;

    public bool Enable
    {
      set => this.ThisEnable = value;
      get => this.ThisEnable;
    }

    public Test.unResultDevice Result
    {
      set => this.ThisResult = value;
      get => this.ThisResult;
    }
  }

  internal delegate void DisEnableEvent(frmDCAProApp m, frmDCAProApp.DisEnable e);

  public class ComponentName : EventArgs
  {
    private string thisName;

    public string Name
    {
      set => this.thisName = value;
      get => this.thisName;
    }
  }

  internal delegate void ComponentNameChanged(frmDCAProApp m, frmDCAProApp.ComponentName e);

  public enum enumDLState : byte
  {
    Idle,
    InProgress,
    Complete,
    Aborted,
    Failed,
  }
}
