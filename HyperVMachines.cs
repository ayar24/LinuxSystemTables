using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinuxSystemTables
{
    public partial class HyperVMachines : UserControl
    {
        public HyperVMachines()
        {
            InitializeComponent();
        }
        private HypderVMachineList hyperVMachines;
        private void HyperVMachines_Load(object sender, EventArgs e)
        {
            hyperVMachines = new HypderVMachineList();
            backgroundWorker1.RunWorkerAsync();
        }
        private void PopulateListViewWithHyperVMachines()
        {
            string savedSel = "";
            if (listView1.SelectedItems.Count > 0)
                savedSel = listView1.SelectedItems[0].SubItems[0].ToString();

            listView1.Items.Clear();
            // Populate ListView
            foreach (HyperVMachineInfo hyperVM in hyperVMachines.vmList)
            {
                ListViewItem item = new ListViewItem(hyperVM.Name);
                if (hyperVM.State == "3")
                    item.SubItems.Add("Off");
                else if (hyperVM.State == "2")
                    item.SubItems.Add("On");
                item.StateImageIndex = 0;
                if (savedSel == item.SubItems[0].ToString())
                    item.Selected = true;
                listView1.Items.Add(item);

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                HypderVMachineList hyperVMachinesNew = HyperVHelper.GetAllHyperVMachines();
                bool equaLists = true;
                if (hyperVMachinesNew.vmList.Count != hyperVMachines.vmList.Count)
                    equaLists = false;
                else
                {
                    for (int i = 0; i < hyperVMachinesNew.vmList.Count; i++)
                    {
                        if (hyperVMachinesNew.vmList[i].Name != hyperVMachines.vmList[i].Name
                             || hyperVMachinesNew.vmList[i].State != hyperVMachines.vmList[i].State)
                        {
                            equaLists = false;
                            break;
                        }
                    }
                }
                if (equaLists == false)
                // TODO: Dont update GUI if list hasnt changed.
                {
                    hyperVMachines = hyperVMachinesNew;
                    this.Invoke(new Action(PopulateListViewWithHyperVMachines));
                }
                Thread.Sleep(3000);
            }
        }
    }
}
