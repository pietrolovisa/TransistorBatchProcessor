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
using TransistorBatchProcessor.Extensions;

namespace TransistorBatchProcessor
{
    public partial class TransistorManagement : UserControl
    {
        private readonly IBatchTypeRepository _batchTypeRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly ITransistorRepository _transistorRepository;

        private bool SupressEvents { get; set; } = false;
        private Batch ActiveBatch { get; set; }

        public TransistorManagement(
            IBatchRepository batchRepository, 
            IBatchTypeRepository batchTypeRepository,
            ITransistorRepository transistorRepository)
            : this()
        {
            _batchRepository = batchRepository;
            _batchTypeRepository = batchTypeRepository;
            _transistorRepository = transistorRepository;
        }

        public TransistorManagement()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            comboBoxBatches.InitCombobox(ComboBoxBatches_SelectedIndexChanged, "Description");
            listView1.InitListView(new ListViewColumnSorter(), ListView1_SelectedIndexChanged,
                new Dictionary<string, int>
                {
                        { nameof(Transistor.Id), 0 },
                        { nameof(Transistor.Idx), 100 },
                        { nameof(Transistor.HEF), 100 },
                        { nameof(Transistor.Beta), 100 }
                });
        }

        public void InitializeView()
        {
            try
            {
                SupressEvents = true;
                ResetBatches();
            }
            finally
            {
                SupressEvents = false;
            }
            if (comboBoxBatches.Items.Count > 0)
            {
                ComboBoxBatches_SelectedIndexChanged(null, null);
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.HasSelectedItem())
            {
                transistorCtrl1.EntityInfo = listView1.GetItemForUpdate<Transistor>();
                buttonAddOrUpdate.Text = "Update";
            }
            else
            {
                long next = ActiveBatch.Transistors.Max(t => t.Idx) + 1;
                transistorCtrl1.EntityInfo = new EntityWrapper<Transistor>
                {
                    State = EditState.New,
                    Entity = new Transistor
                    {
                        Idx = next
                    }
                };
                buttonAddOrUpdate.Text = "Add";
            }
        }

        private void ResetBatches(Batch selectedItem = null)
        {
            List<Batch> batches = _batchRepository.FindAll(new BatchQueryFilter
            {
                IncludeBatchType = true
            }).GetAwaiter().GetResult();
            comboBoxBatches.DataSource = batches;
            if (selectedItem != null)
            {
                comboBoxBatches.SelectedValue = selectedItem.Id;
            }
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
            LoadTransistors();
            if (listView1.Items.Count > 0)
            {
                listView1.Items[0].ForceSelected();
            }
            else
            {
                transistorCtrl1.EntityInfo = new EntityWrapper<Transistor>
                {
                    State = EditState.New,
                    Entity = new Transistor
                    {
                        Idx = 1
                    }
                };
                buttonAddOrUpdate.Text = "Add";
            }
        }

        private void LoadTransistors()
        {
            listView1.LoadItems<Transistor>(ActiveBatch.Transistors);
        }

        private void Remove_Click(object sender, EventArgs e)
        {

        }

        private void AddOrUpdate_Click(object sender, EventArgs e)
        {
            if (transistorCtrl1.EntityInfo.State == EditState.New)
            {
                Transistor transistor = transistorCtrl1.EntityInfo.Entity;
                transistor.BatchId = ActiveBatch.Id;
                _transistorRepository.Insert(transistor).GetAwaiter().GetResult();
                ActiveBatch.Transistors.Add(transistor);
                listView1.AddItemToView<Transistor>(transistor, true);
            }
            else
            {

            }
        }
    }
}
