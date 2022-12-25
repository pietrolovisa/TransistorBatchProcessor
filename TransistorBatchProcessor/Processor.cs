using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransisterBatch.EntityFramework.Domain;
using TransisterBatch.EntityFramework.Repository;
using TransisterBatchCore;
using TransistorBatchProcessor.Extensions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TransistorBatchProcessor
{
    public partial class Processor : UserControl, IManagementTool
    {
        public event EventHandler<NotificationEventArgs> OnNotify;

        public string DisplayName => "Transistor Processor";

        private readonly IBatchTypeRepository _batchTypeRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly ITransistorRepository _transistorRepository;

        private bool SupressEvents { get; set; } = false;
        private Batch ActiveBatch { get; set; }

        public Processor(
            IBatchRepository batchRepository,
            IBatchTypeRepository batchTypeRepository,
            ITransistorRepository transistorRepository)
            : this()
        {
            _batchRepository = batchRepository;
            _batchTypeRepository = batchTypeRepository;
            _transistorRepository = transistorRepository;
        }

        public Processor()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            comboBoxBatches.InitCombobox(ComboBoxBatches_SelectedIndexChanged, "Description");
            listView1.InitListView(new ListViewColumnSorter(), ListViewSelectedIndexChanged,
                new List<Tuple<string, int, ColumnHeaderType>>
                {
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.Id), 0, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.Idx), 140, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.HEF), 140, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.Beta), 140, ColumnHeaderType.numeric) }
                });
        }

        private void ListViewSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ComboBoxBatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SupressEvents) return;

            Batch selectedItem = comboBoxBatches.SelectedItem as Batch;
            ActiveBatch = _batchRepository.FindByKey(selectedItem.Id, new BatchQueryFilter
            {
                IncludeBatchType = true,
                IncludeTransistors = true
            }).GetAwaiter().GetResult();
        }

        public void HandleEvent(NotificationEventArgs args)
        {
            if (args.Event == EventType.BatchAdded || args.Event == EventType.BatchRemoved)
            {
                ResetBatches();
            }
        }

        public void InitializeView()
        {
            ResetBatches();
        }

        private void ResetBatches()
        {
            List<Batch> batches = _batchRepository.FindAll(new BatchQueryFilter
            {
                IncludeBatchType = true
            }).GetAwaiter().GetResult();
            comboBoxBatches.DataSource = batches;
            if (ActiveBatch != null)
            {
                comboBoxBatches.SelectedValue = ActiveBatch.Id;
            }
        }

        private void buttonProcessBatch_Click(object sender, EventArgs e)
        {
            IBatchProcessor batchProcessor = new BatchProcessor();
            TransistorGroupLoadArgs args = new TransistorGroupLoadArgs
            {
                BetaTolerance = (double)numericUpDownBetaTolerance.Value,
                HefTolerance = (int)numericUpDownHefTolerance.Value
            };

            ActionResult<TransistorGroupDiscovery> result = batchProcessor.GenerateTransisterManifest(ActiveBatch, args);

            listView1.Items.Clear();
            int index = 1;
            foreach (TransistorGroup group in result.Data.Matches)
            {
                ListViewGroup listViewGroup = new ListViewGroup($"Group {index} ({group.Count})", HorizontalAlignment.Left);
                listView1.Groups.Add(listViewGroup);
                group.ForEach(t => listView1.AddItemToView<Transistor>(t, listViewGroup));
                index++;
            }

            ListViewGroup outlierListViewGroup = new ListViewGroup($"Outliers ({result.Data.Outliers.Count})", HorizontalAlignment.Left);
            listView1.Groups.Add(outlierListViewGroup);
            foreach (TransistorGroup group in result.Data.Outliers)
            {
                group.ForEach(t => listView1.AddItemToView<Transistor>(t, outlierListViewGroup));
            }

            listView1.ResetSortOrder();
        }
    }
}
