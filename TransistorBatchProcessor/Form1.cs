using System.IO.Packaging;
using System.Reflection;
using TransisterBatchCore;
using TransisterBatch.EntityFramework.Repository;
using TransisterBatch.EntityFramework.Domain;

namespace TransistorBatchProcessor
{
    public partial class Form1 : Form
    {
        public IExcelWorkspace Workspace { get; set; }

        private readonly IBatchTypeRepository _batchTypeRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly ITransistorRepository _transistorRepository;

        public Form1(
            IBatchTypeRepository batchTypeRepository,
            IBatchRepository batchRepository,
            ITransistorRepository transistorRepository)
        {
            _batchTypeRepository = batchTypeRepository;
            _batchRepository = batchRepository;
            _transistorRepository = transistorRepository;

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
            //BatchType batchTypeBC549 = new BatchType
            //{
            //    Name = "BC549",
            //    Description = "BC549"
            //};

            //_batchTypeRepository.Insert(batchTypeBC549).GetAwaiter().GetResult();
            //_batchTypeRepository.Insert(new BatchType
            //{
            //    Name = "BC559",
            //    Description = "BC559"
            //}).GetAwaiter().GetResult();
            //_batchTypeRepository.Insert(new BatchType
            //{
            //    Name = "PN4250",
            //    Description = "PN4250"
            //}).GetAwaiter().GetResult();

            //Batch batch = new Batch
            //{
            //    Name = "TestBatch",
            //    BatchTypeId = batchTypeBC549.Id
            //};
            //_batchRepository.Insert(batch).GetAwaiter().GetResult();
            //_transistorRepository.Insert(new Transistor
            //{
            //    Idx = 1,
            //    HEF = 453,
            //    Beta = 0.764,
            //    BatchId = batch.Id
            //}).GetAwaiter().GetResult();
            //List<Batch> batches = _batchRepository.FindAll(new BatchQueryFilter
            //{
            //    IncludeTransistors = true,
            //    IncludeBatchType = true
            //}).GetAwaiter().GetResult();
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
            ActionResult<TransistorBatchDiscovery> loadBatchResult = Workspace.GenerateTransisterManifest(batchLoadArgs);
            if (loadBatchResult.Success)
            {
                WriteFeedback($"Successfully loaded batch data from worksheet [{batchLoadArgs.Name}]");
                WriteFeedback($"Found [{loadBatchResult.Data.ItemCount}] item(s).", 1);
                WriteFeedback($"Found [{loadBatchResult.Data.Errors.Count}] item(s) with errors.", 1);
                if (loadBatchResult.Data.HasErrors)
                {
                    loadBatchResult.Data.Errors.ForEach(transistor => 
                        WriteFeedback($"Row [{transistor.Source.Row}] of worksheet [{transistor.Source.Name}] is invalid ({transistor}).", 2));
                }
                WriteFeedback($"Found [{loadBatchResult.Data.Matches.Count}] match(es).", 1);
                WriteFeedback($"Found [{loadBatchResult.Data.Outliers.Count}] outlier(s).", 1);
                WriteFeedback($"Starting save matches and outliers back to worksheet...");
                ActionResult<TransistorBatchSave> saveResult = Workspace.GenerateDiscoveryWorksheets(batchLoadArgs, loadBatchResult.Data);
                if (saveResult.Success)
                {
                    WriteFeedback($"Saved matches to new worksheet [{saveResult.Data.MatchesWorksheet}].", 1);
                    WriteFeedback($"Saved outliers to new worksheet [{saveResult.Data.OutliersWorksheet}].", 1);
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

        private void WriteFeedback(string message, int indent = 0)
        {
            string prefix = indent < 1 ? string.Empty : $"{new string('\t', indent)}-> ";
            textBox2.AppendText($"{prefix}{message}");
            textBox2.AppendText(Environment.NewLine);
        }
    }
}