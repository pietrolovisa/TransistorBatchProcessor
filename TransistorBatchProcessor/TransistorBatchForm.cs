using System;
using System.Collections;
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
    public partial class TransistorBatchForm : Form
    {
        private bool SupressEvents { get; set; } = false;

        private readonly IBatchTypeRepository _batchTypeRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly ITransistorRepository _transistorRepository;
        private readonly ListViewColumnSorter _listViewColumnSorter;

        private System.Windows.Forms.TabControl TabCtrl { get; set; }
        private BatchManagement BatchManagementCtrl { get; set; }
        private BatchTypeManagement BatchTypeManagementCtrl { get; set; }
        private TransistorManagement TransistorManagementCtrl { get; set; }

        private Batch ActiveBatch { get; set; }
 
        public TransistorBatchForm(
            IBatchTypeRepository batchTypeRepository,
            IBatchRepository batchRepository,
            ITransistorRepository transistorRepository)
        {
            _batchTypeRepository = batchTypeRepository;
            _batchRepository = batchRepository;
            _transistorRepository = transistorRepository;

            _listViewColumnSorter = new ListViewColumnSorter();

            BatchTypeManagementCtrl = new BatchTypeManagement(_batchRepository, _batchTypeRepository, _transistorRepository)
            {
                Dock = DockStyle.Fill,
            };
            BatchManagementCtrl = new BatchManagement(_batchRepository, _batchTypeRepository, _transistorRepository)
            {
                Dock = DockStyle.Fill
            };
            TransistorManagementCtrl = new TransistorManagement(_batchRepository, _batchTypeRepository, _transistorRepository)
            {
                Dock = DockStyle.Fill
            };

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                SupressEvents = true;

                TabCtrl = new TabControl
                {
                    Dock = DockStyle.Fill,
                };

                BatchTypeManagementCtrl.InitializeView();
                TabCtrl.AddTab(BatchTypeManagementCtrl, "Batch Types");

                BatchManagementCtrl.InitializeView();
                TabCtrl.AddTab(BatchManagementCtrl, "Batches");

                TransistorManagementCtrl.InitializeView();
                TabCtrl.AddTab(TransistorManagementCtrl, "Transistors");

                Controls.Add(TabCtrl);
            }
            finally
            {
                SupressEvents = false;
            }
        }

        //private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (listView1.SelectedItems.Count > 0)
        //    {
        //        Transistor transistor = listView1.SelectedItems[0]?.Tag as Transistor;
        //        transistorCtrl1.EntityInfo = new EntityWrapper<Transistor>
        //        {
        //            State = EditState.Update,
        //            Entity = transistor
        //        };
        //        buttonAddOrUpdate.Text = "Update";
        //    }
        //    else
        //    {
        //        long next = ActiveBatch.Transistors.Max(t => t.Idx) + 1;
        //        transistorCtrl1.EntityInfo = new EntityWrapper<Transistor>
        //        {
        //            State = EditState.New,
        //            Entity = new Transistor
        //            {
        //                Idx = next
        //            }
        //        };
        //        buttonAddOrUpdate.Text = "Add";
        //    }
        //}

        //private void LoadBatches(Batch selectedItem = null)
        //{
        //    comboBoxBatches.Items.Clear();
        //    List<Batch> batches = _batchRepository.FindAll(new BatchQueryFilter
        //    {
        //        IncludeBatchType = true
        //    }).GetAwaiter().GetResult();
        //    comboBoxBatches.DataSource = batches;
        //    if (selectedItem != null)
        //    {
        //        comboBoxBatches.SelectedValue = selectedItem.Id;
        //    }
        //}

        //private void ComboBoxBatches_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (SupressEvents) return;

        //    Batch selectedItem = comboBoxBatches.SelectedItem as Batch;
        //    ActiveBatch = _batchRepository.FindByKey(selectedItem.Id, new BatchQueryFilter
        //    {
        //         IncludeBatchType = true,
        //         IncludeTransistors = true
        //    }).GetAwaiter().GetResult();
        //    LoadTransistors();
        //    if (listView1.Items.Count > 0)
        //    {
        //        listView1.Items[0].Focused = true;
        //        listView1.Items[0].Selected = true;
        //        listView1.Items[0].EnsureVisible();
        //    }
        //    else
        //    {
        //        transistorCtrl1.EntityInfo = new EntityWrapper<Transistor>
        //        {
        //            State = EditState.New,
        //            Entity = new Transistor
        //            {
        //                Idx = 1
        //            }
        //        };
        //        buttonAddOrUpdate.Text = "Add";
        //    }
        //}

        //private void LoadTransistors()
        //{
        //    listView1.Items.Clear();
        //    foreach(Transistor transistor in ActiveBatch.Transistors)
        //    {
        //        AddTransistorToView(transistor);
        //    }
        //}

        //private void AddTransistorToView(Transistor transistor, bool select = false)
        //{
        //    List<string> cols = new List<string>
        //        {
        //            transistor.Id.ToString(),
        //            transistor.Idx.ToString(),
        //            transistor.HEF.ToString(),
        //            transistor.Beta.ToString()
        //        };
        //    ListViewItem listViewItem = new ListViewItem(cols.ToArray())
        //    {
        //        Tag = transistor
        //    };
        //    listView1.Items.Add(listViewItem);

        //    if (select)
        //    {
        //        listViewItem.Focused = true;
        //        listViewItem.Selected = true;
        //        listViewItem.EnsureVisible();
        //    }
        //}

        //private void buttonAddOrUpdate_Click(object sender, EventArgs e)
        //{
        //    if(transistorCtrl1.EntityInfo.State == EditState.New)
        //    {
        //        Transistor transistor = transistorCtrl1.EntityInfo.Entity;
        //        transistor.BatchId = ActiveBatch.Id;
        //        _transistorRepository.Insert(transistor).GetAwaiter().GetResult();
        //        ActiveBatch.Transistors.Add(transistor);
        //        AddTransistorToView(transistor, true);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void buttonAddBatch_Click(object sender, EventArgs e)
        //{
        //    AddBatchForm addBatchForm = new AddBatchForm();
        //    addBatchForm.LoadTypes(_batchTypeRepository.FindAll().GetAwaiter().GetResult());
        //    DialogResult dialogResult = addBatchForm.ShowDialog(this);
        //    if (dialogResult == DialogResult.OK)
        //    {
        //        Batch newBatch = addBatchForm.GetBatch;
        //        _batchRepository.Insert(newBatch).GetAwaiter().GetResult();
        //        LoadBatches(newBatch);
        //    }
        //}
    }
}
