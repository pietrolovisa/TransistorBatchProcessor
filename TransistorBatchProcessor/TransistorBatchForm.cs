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
using System.Reflection;
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

        private TabControl TabCtrl { get; set; }

        private List<IManagementTool> ManagementTools { get; set; }
 
        public TransistorBatchForm(
            IBatchTypeRepository batchTypeRepository,
            IBatchRepository batchRepository,
            ITransistorRepository transistorRepository)
        {
            _batchTypeRepository = batchTypeRepository;
            _batchRepository = batchRepository;
            _transistorRepository = transistorRepository;

            ManagementTools = new List<IManagementTool>();

            //Processor processor = new Processor(_batchRepository, _batchTypeRepository, _transistorRepository)
            //{
            //    Dock = DockStyle.Fill
            //};
            //processor.OnNotify += ManagementToolsOnNotify;
            //ManagementTools.Add(processor);

            TransistorManagement transistorManagementCtrl = new TransistorManagement(_batchRepository, _batchTypeRepository, _transistorRepository)
            {
                Dock = DockStyle.Fill
            };
            transistorManagementCtrl.OnNotify += ManagementToolsOnNotify;
            ManagementTools.Add(transistorManagementCtrl);

            BatchManagement abtchManagementCtrl = new BatchManagement(_batchRepository, _batchTypeRepository, _transistorRepository)
            {
                Dock = DockStyle.Fill
            };
            abtchManagementCtrl.OnNotify += ManagementToolsOnNotify;
            ManagementTools.Add(abtchManagementCtrl);

            BatchTypeManagement batchTypeManagementCtrl = new BatchTypeManagement(_batchRepository, _batchTypeRepository, _transistorRepository)
            {
                Dock = DockStyle.Fill,
            };
            batchTypeManagementCtrl.OnNotify += ManagementToolsOnNotify;
            ManagementTools.Add(batchTypeManagementCtrl);

            InitializeComponent();
        }

        private void UpdateHeader()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = $"{Text} - {version}";
        }

        private void ManagementToolsOnNotify(object sender, NotificationEventArgs e)
        {
            foreach (IManagementTool managementTool in ManagementTools)
            {
                managementTool.HandleEvent(e);
            }
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
                foreach(IManagementTool managementTool in ManagementTools)
                {
                    managementTool.InitializeView();
                    TabCtrl.AddTab(managementTool as Control, managementTool.DisplayName);
                }
                Controls.Add(TabCtrl);
                UpdateHeader();
            }
            finally
            {
                SupressEvents = false;
            }
        }
    }
}
