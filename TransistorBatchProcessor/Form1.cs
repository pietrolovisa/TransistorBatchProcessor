using System.IO.Packaging;
using System.Reflection;
using TransisterBatchCore;

namespace TransistorBatchProcessor
{
    public partial class Form1 : Form
    {
        public IExcelWorkspace Workspace { get; set; }

        public Form1()
        {
            InitializeComponent();
            UpdateHeader();
            SetState(false);
        }

        private void UpdateHeader()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = $"{Text} - {version}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.xls)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        private void SetState(bool enabled)
        {
            buttonProcessBatch.Enabled = enabled;
            batchLoadArgsSettingsCtrl1.SetState(enabled);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WriteFeedback($"Creating workspace...");
            Workspace = ExcelWorkspaceFactory.CreateWorkspace();
            WriteFeedback($"Starting load workspace from [{textBox1.Text}]");
            ActionResult loadResult = Workspace.Load(textBox1.Text);
            WriteFeedback(loadResult.Message);
            if (loadResult.Success)
            {
                WriteFeedback($"Successfully loaded workspace and found {Workspace.Package?.Workbook?.Worksheets?.Count} worksheet(s).");
                ActionResult<List<string>> getWorksheetNamesResult = Workspace.GetWorksheetNames();
                WriteFeedback(getWorksheetNamesResult.Message);
                if (getWorksheetNamesResult.Success)
                {
                    SetState(true);
                    batchLoadArgsSettingsCtrl1.ResetSource(getWorksheetNamesResult.Data);
                }
                else
                {
                    WriteFeedback(getWorksheetNamesResult.Exception.ToString());
                }
            }
            else
            {
                WriteFeedback(loadResult.Exception.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TransistorBatchLoadArgs batchLoadArgs = batchLoadArgsSettingsCtrl1.BatchLoadArgs;
            WriteFeedback($"Starting load transistor batch from worksheet [{batchLoadArgs.Name}]...");
            ActionResult<TransistorBatchDiscovery> loadBatchResult = Workspace.LoadTransisterBatch(batchLoadArgs);
            
            if (loadBatchResult.Success)
            {
                WriteFeedback($"Successfully loaded batch data from worksheet [{batchLoadArgs.Name}]");
                WriteFeedback($"    Found [{loadBatchResult.Data.Discovery.Count}] items.");
                WriteFeedback($"    Found [{loadBatchResult.Data.Errors.Count}] items with errors.");
                WriteFeedback($"    Found [{loadBatchResult.Data.Matches.Count}] matches.");
                WriteFeedback($"    Found [{loadBatchResult.Data.Outliers.Count}] outliers.");
                WriteFeedback($"Starting save matches and outliers back to worksheet...");
                ActionResult<TransistorBatchSave> saveResult = Workspace.GenerateDiscoveryWorksheet(batchLoadArgs, loadBatchResult.Data);
                if (saveResult.Success)
                {
                    WriteFeedback($"    Saved matches to new worksheet [{saveResult.Data.MatchesWorksheet}].");
                    WriteFeedback($"    Saved outliers to new worksheet [{saveResult.Data.OutliersWorksheet}].");
                }
                else
                {
                    WriteFeedback(saveResult.Message);
                }
            }
            else
            {
                WriteFeedback(loadBatchResult.Message);
            }
        }

        private void WriteFeedback(string message)
        {
            textBox2.AppendText(message);
            textBox2.AppendText(Environment.NewLine);
        }
    }
}