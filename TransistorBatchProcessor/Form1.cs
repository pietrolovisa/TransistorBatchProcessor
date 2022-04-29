using TransisterBatchCore;

namespace TransistorBatchProcessor
{
    public partial class Form1 : Form
    {
        public IExcelWorkspace Workspace { get; set; }

        public Form1()
        {
            InitializeComponent();
            SetState(false);
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
            WriteFeedback($"Starting load transistor batch from [{batchLoadArgs.Name}]...");
            ActionResult<TransistorBatchDiscovery> loadBatchResult = Workspace.LoadTransisterBatch(batchLoadArgs);
            WriteFeedback(loadBatchResult.Message);
            if (loadBatchResult.Success)
            {
                List<List<TransisterSettings>> batches = loadBatchResult.Data.Discovery.Process(batchLoadArgs);
                foreach(List<TransisterSettings> batch in batches)
                {
                    if (batch.Count == 1)
                    {
                        WriteFeedback($"Found outlier [{batch[0]}]");
                    }
                    else if(batch.Count > 1)
                    {
                        WriteFeedback($"Found [{batch.Count}] matches...");
                        foreach(TransisterSettings match in batch)
                        {
                            WriteFeedback($"     -> [{match}]");
                        }
                    }
                }
            }
        }

        private void WriteFeedback(string message)
        {
            textBox2.AppendText(message);
            textBox2.AppendText(Environment.NewLine);
        }
    }
}