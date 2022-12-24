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
    public partial class BatchManagement : UserControl, IManagementTool
    {
        public string DisplayName => "Batch Management";

        public event EventHandler<NotificationEventArgs> OnNotify;

        private readonly IBatchTypeRepository _batchTypeRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly ITransistorRepository _transistorRepository;

        private bool SupressEvents { get; set; } = false;

        public BatchManagement(
            IBatchRepository batchRepository,
            IBatchTypeRepository batchTypeRepository,
            ITransistorRepository transistorRepository)
            : this()
        {
            _batchRepository = batchRepository;
            _batchTypeRepository = batchTypeRepository;
            _transistorRepository = transistorRepository;
        }

        public BatchManagement()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            listView1.InitListView(new ListViewColumnSorter(), ListViewSelectedIndexChanged,
                new Dictionary<string, int>
                {
                    { nameof(Batch.Id), 0 },
                    { nameof(Batch.Name), 140 },
                    { nameof(Batch.Type), 140 }
                });
        }

        private void ListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            batchCtrl1.ResetBatchTypes(_batchTypeRepository.FindAll().GetAwaiter().GetResult());
            if (listView1.HasSelectedItem())
            {
                batchCtrl1.EntityInfo = listView1.GetItemForUpdate<Batch>();
                buttonAddOrUpdate.Text = "Update";
                buttonRemove.Enabled = true;
            }
            else
            {
                batchCtrl1.EntityInfo = listView1.GetItemForAdd<Batch>();
                buttonAddOrUpdate.Text = "Add";
                buttonRemove.Enabled = false;
            }
        }

        public void InitializeView()
        {
            listView1.LoadItems<Batch>(_batchRepository.FindAll(new BatchQueryFilter
            {
                IncludeBatchType = true
            }).GetAwaiter().GetResult());
            batchCtrl1.LoadTypes(_batchTypeRepository.FindAll().GetAwaiter().GetResult());
            ListViewSelectedIndexChanged(null, null);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            Batch batch = listView1.GetItemForUpdate<Batch>().Entity;
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove batch {batch.Name}", "Delete", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                _batchRepository.Delete(batch).GetAwaiter().GetResult();
                OnNotify?.Invoke(this, NotificationEventArgs.BatchRemoved);
            }
        }

        private void AddOrUpdate_Click(object sender, EventArgs e)
        {
            if (batchCtrl1.Validate(out string message))
            {
                Batch batch = batchCtrl1.EntityInfo.Entity;
                if (batchCtrl1.EntityInfo.State == EditState.New)
                {
                    _batchRepository.Insert(batch).GetAwaiter().GetResult();
                    batch = _batchRepository.FindByKey(batch.Id, new BatchQueryFilter
                    {
                        IncludeBatchType = true
                    }).GetAwaiter().GetResult();
                    listView1.AddItemToView<Batch>(batch, null, true);
                    OnNotify?.Invoke(this, NotificationEventArgs.BatchAdded);
                }
                else
                {
                    _batchRepository.Update(batch).GetAwaiter().GetResult();
                    batch = _batchRepository.FindByKey(batch.Id, new BatchQueryFilter
                    {
                        IncludeBatchType = true
                    }).GetAwaiter().GetResult();
                    listView1.SetItemAfterUpdate<Batch>(batch);
                }
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
            }
        }

        public void HandleEvent(NotificationEventArgs args)
        {

        }
    }
}
