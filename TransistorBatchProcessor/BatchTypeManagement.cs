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
    public partial class BatchTypeManagement : UserControl, IManagementTool
    {
        public string DisplayName => "Batch Type Management";

        public event EventHandler<NotificationEventArgs> OnNotify;

        private readonly IBatchTypeRepository _batchTypeRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly ITransistorRepository _transistorRepository;

        private bool SupressEvents { get; set; } = false;

        public BatchTypeManagement(
            IBatchRepository batchRepository,
            IBatchTypeRepository batchTypeRepository,
            ITransistorRepository transistorRepository)
            : this()
        {
            _batchRepository = batchRepository;
            _batchTypeRepository = batchTypeRepository;
            _transistorRepository = transistorRepository;
        }

        public BatchTypeManagement()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            listView1.InitListView(new ListViewColumnSorter(), ListViewSelectedIndexChanged,
                new Dictionary<string, int>
                {
                    { nameof(BatchType.Id), 0 },
                    { nameof(BatchType.Name), 100 },
                    { nameof(BatchType.Description), 100 }
                });
        }

        private void ListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.HasSelectedItem())
            {
                batchTypeCtrl1.EntityInfo = listView1.GetItemForUpdate<BatchType>();
                buttonAddOrUpdate.Text = "Update";
                buttonRemove.Enabled = true;
            }
            else
            {
                batchTypeCtrl1.EntityInfo = listView1.GetItemForAdd<BatchType>();
                buttonAddOrUpdate.Text = "Add";
                buttonRemove.Enabled = false;
            }
        }

        public void InitializeView()
        {
            listView1.LoadItems<BatchType>(_batchTypeRepository.FindAll().GetAwaiter().GetResult());
            ListViewSelectedIndexChanged(null, null);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            BatchType batchType = listView1.GetItemForUpdate<BatchType>().Entity;
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove batch type {batchType.Name}", "Delete", MessageBoxButtons.OKCancel);
            if(dialogResult == DialogResult.OK)
            {
                _batchTypeRepository.Delete(batchType).GetAwaiter().GetResult();
            }
        }

        private void AddOrUpdate_Click(object sender, EventArgs e)
        {
            if (batchTypeCtrl1.Validate(out string message))
            {
                BatchType batchType = batchTypeCtrl1.EntityInfo.Entity;
                if (batchTypeCtrl1.EntityInfo.State == EditState.New)
                {
                    _batchTypeRepository.Insert(batchType).GetAwaiter().GetResult();
                    listView1.AddItemToView<BatchType>(batchType, true);
                }
                else
                {
                    _batchTypeRepository.Update(batchType).GetAwaiter().GetResult();
                    listView1.SetItemAfterUpdate<BatchType>(batchType);
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
