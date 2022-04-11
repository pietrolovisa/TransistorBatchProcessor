using TransisterBatchCore;

namespace TransistorBatchProcessor
{
    public partial class Form1 : Form
    {
        public IExcelWorkspace Workspace { get; set; }

        public Form1()
        {
            InitializeComponent();
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
                    foreach (string name in getWorksheetNamesResult.Data)
                    {
                        comboBox1.Items.Add(name);
                    }
                    if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
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
            WriteFeedback($"Starting load transistor batch from [{comboBox1.SelectedItem?.ToString()}]...");
            ActionResult<TransistorBatch> loadBatchResult = Workspace.LoadTransisterBatch( new TransisterWorkSheetArgs
            {
                Name = comboBox1.SelectedItem?.ToString()
            });
            WriteFeedback(loadBatchResult.Message);
            if (loadBatchResult.Success)
            {
                List<List<TransisterSettings>> batches = loadBatchResult.Data.Process();
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