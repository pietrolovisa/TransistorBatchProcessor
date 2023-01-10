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
                new List<Tuple<string, int, ColumnHeaderType>>
                {
                    { new Tuple<string, int, ColumnHeaderType>(nameof(BatchType.Id), 0, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(BatchType.Name), 140, ColumnHeaderType.text) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(BatchType.Description), 140, ColumnHeaderType.text) }
                });
            commandAndControl1.OnCommand += CommandAndControl1_OnCommand;
        }

        private void CommandAndControl1_OnCommand(object sender, CommandArgs e)
        {
            bool _ = e.Command switch
            {
                Command.Add => HandleAdd(),
                Command.Update => HandleUpdate(),
                Command.Remove => HandleRemove(),
                _ => throw new InvalidOperationException($"Command Type [{e.Command}] has no handler.")
            };
        }

        private bool HandleAdd()
        {
            if (batchTypeCtrl1.Validate(out string message))
            {
                BatchType batchType = batchTypeCtrl1.EntityInfo.Entity;
                _batchTypeRepository.Insert(batchType).GetAwaiter().GetResult();
                _batchTypeRepository.ClearTracker();
                listView1.AddItemToView<BatchType>(batchType, null, true);
                UpdateDetails();
                OnNotify?.Invoke(this, NotificationEventArgs.BatchTypeItemChanged(Command.Add));
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
            }
            return true;
        }

        private bool HandleUpdate()
        {
            if (batchTypeCtrl1.Validate(out string message))
            {
                BatchType batchType = batchTypeCtrl1.EntityInfo.Entity;
                _batchTypeRepository.Update(batchType).GetAwaiter().GetResult();
                _batchTypeRepository.ClearTracker();
                listView1.SetItemAfterUpdate<BatchType>(batchType);
                OnNotify?.Invoke(this, NotificationEventArgs.BatchTypeItemChanged(Command.Update));
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
            }
            return true;
        }

        private bool HandleRemove()
        {
            BatchType batchType = listView1.GetItemForUpdate<BatchType>().Entity;
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove batch type {batchType.Name}", "Delete", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                _batchTypeRepository.Delete(batchType).GetAwaiter().GetResult();
                _batchTypeRepository.ClearTracker();
                listView1.DeleteSelected();
                UpdateDetails();
                OnNotify?.Invoke(this, NotificationEventArgs.BatchTypeItemChanged(Command.Remove));
            }
            return true;
        }

        private void ListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.HasSelectedItem())
            {
                batchTypeCtrl1.EntityInfo = listView1.GetItemForUpdate<BatchType>();
                commandAndControl1.ToggleCommands(Command.Update | Command.Remove);
            }
            else
            {
                batchTypeCtrl1.EntityInfo = listView1.GetItemForAdd<BatchType>();
                commandAndControl1.ToggleCommands(Command.Add);
            }
        }

        public void InitializeView()
        {
            listView1.LoadItems<BatchType>(_batchTypeRepository.FindAll().GetAwaiter().GetResult());
            listView1.ResetSortOrder();
            ListViewSelectedIndexChanged(null, null);
            UpdateDetails();
        }

        public void HandleEvent(NotificationEventArgs args)
        {

        }

        public void UpdateDetails()
        {
            batchTypeCtrl1.Text = $"{listView1.Items.Count} batch type(s)";
        }
    }
}
