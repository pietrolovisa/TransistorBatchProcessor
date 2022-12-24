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
                new Dictionary<string, int>
                {
                        { nameof(Transistor.Id), 0 },
                        { nameof(Transistor.Idx), 140 },
                        { nameof(Transistor.HEF), 140 },
                        { nameof(Transistor.Beta), 140 }
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
            //LoadTransistors();
            //if (listView1.Items.Count > 0)
            //{
            //    listView1.Items[0].ForceSelected();
            //}
            //else
            //{
            //    transistorCtrl1.EntityInfo = new EntityWrapper<Transistor>
            //    {
            //        State = EditState.New,
            //        Entity = new Transistor
            //        {
            //            Idx = 1
            //        }
            //    };
            //    buttonAddOrUpdate.Text = "Add";
            //}
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
            try
            {
                SupressEvents = true;
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
            finally
            {
                SupressEvents = false;
            }
        }

        private void buttonProcessBatch_Click(object sender, EventArgs e)
        {
            IBatchProcessor batchProcessor = new BatchProcessor();
            ActionResult<TransistorGroupDiscovery> result = batchProcessor.GenerateTransisterManifest(ActiveBatch, new TransistorGroupLoadArgs());

            listView1.Items.Clear();
            int index = 1;
            foreach (TransistorGroup group in result.Data.Matches)
            {
                ListViewGroup listViewGroup = new ListViewGroup($"Group {index}", HorizontalAlignment.Left);
                listView1.Groups.Add(listViewGroup);
                group.ForEach(t => listView1.AddItemToView<Transistor>(t, listViewGroup));
                index++;
            }

            ListViewGroup outlierListViewGroup = new ListViewGroup($"Outliers", HorizontalAlignment.Left);
            listView1.Groups.Add(outlierListViewGroup);
            foreach (TransistorGroup group in result.Data.Outliers)
            {
                group.ForEach(t => listView1.AddItemToView<Transistor>(t, outlierListViewGroup));
            }
        }
    }
}
