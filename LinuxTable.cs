using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Eventing.Reader;

namespace LinuxSystemTables
{
    public partial class LinuxTable : UserControl
    {
        public LinuxTable()
        {
            InitializeComponent();
            mainListView.ClientSize = this.Size;
        }

        [Browsable(true)]
        [TypeConverter(typeof(EnumConverter))]
        public LinuxTableType TableType  { get; set; }

        public bool Active { get; set; }
        public bool ShowSecondary { 
            get { return !splitContainer1.Panel2Collapsed; }
            set { splitContainer1.Panel2Collapsed = !value; } 
        }
        public void Start() { Active = true;  }
        public int RefreshInterval { get; set; } = 3000;
        public SSHGlobalSession SSHClient { get; set; }

        // Privates
        private DateTime lastUpdated = DateTime.MinValue;
        private LinuxItemList m_list = null;
        private LinuxItemList m_secondaryList = null;
        private bool m_refreshSecondary = false;
        private string m_selectedPID = "";
        private bool _RefreshTable(/*LinuxItemList list*/ bool main, string sort, bool asc)
        {
            LinuxItemList list = null;
            bool updated = false;
            string param = "";
            if (main) {
                if (m_list == null)
                {
                    m_list = new LinuxItemList(TableType);
                }
                list = m_list;
            }
            else
            {
                if (m_secondaryList == null)
                {
                    m_secondaryList = new LinuxItemList(LinuxTableType.Procmaps);
                }
                list = m_secondaryList;
                param = m_selectedPID;
            }

            if (TableType == LinuxTableType.Logs)
                updated = list.RefreshIncremental(SSHClient, sort, asc);
            else
                updated = list.Refresh(SSHClient, sort, asc, param);

            return updated;
        }
        private bool RefreshTable(string sort, bool asc)
        {
            bool updated = false;
            TimeSpan timeDifference = DateTime.Now.Subtract(lastUpdated);

            if (timeDifference.TotalMilliseconds > RefreshInterval || 
                lastUpdated == DateTime.MinValue)
            {
                 updated = _RefreshTable(true, sort,asc);

                 lastUpdated = DateTime.Now;

                return updated;
            }
            return false;
        }
        private bool UpdateListViewItems()
        {
            this.Invoke(new Action<LinuxItemList,System.Windows.Forms.ListView>(UpdateListViewForm),m_list, mainListView);
            return true;
        }
        private bool UpdateSecondaryListViewItems()
        {
            this.Invoke(new Action<LinuxItemList, System.Windows.Forms.ListView>(UpdateListViewForm), m_secondaryList, secondaryListView);
            return true;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (Active)
                {
                    if (RefreshTable("0", true))
                    {
                        UpdateListViewItems();

                        if (m_selectedPID != "" && m_refreshSecondary)
                        {
                            if (_RefreshTable(false, "", true) == true)
                            {
                                UpdateSecondaryListViewItems();
                                m_refreshSecondary = false;
                            }
                        }
                    }
                }
                System.Threading.Thread.Sleep(100);
            }
        }
        internal void UpdateListViewForm(LinuxItemList theList, System.Windows.Forms.ListView theListView)
        {
            string selectedPid = "";
            int selectVPffset = 0;
            string filter = filterTextBox.Text;

            if (theListView.SelectedItems.Count > 0)
            {
                selectedPid = theListView.SelectedItems[0].SubItems[0].Text;
            }

            if (theListView.TopItem != null)
                selectVPffset = theListView.TopItem.Index;

            theListView.BeginUpdate();
            theListView.SelectedItems.Clear();
            theListView.Items.Clear();

            theList.UpdateListItems(theListView, filter, selectedPid);

            if (selectVPffset > 0)
                theListView.EnsureVisible(selectVPffset);

            foreach (ColumnHeader column in theListView.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }

            theListView.EndUpdate();
           
        }

        private void LinuxTable_Load(object sender, EventArgs e)
        {
            switch (TableType)
            {
                case LinuxTableType.Processes:
                    mainListView.ContextMenuStrip = processMenuStrip;
                    break;

                case LinuxTableType.Users:
                    mainListView.ContextMenuStrip = usersMenuStrip;
                    break;

                case LinuxTableType.Services:
                    mainListView.ContextMenuStrip = serviceMenuStrip;
                    break;

                case LinuxTableType.Logs:
                    mainListView.ContextMenuStrip = logsMenuStrip;
                    break;
                default:
                    break;
            }
            
            mainBackgroundWorker.RunWorkerAsync();
        }


        private void mainListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainListView.SelectedItems.Count > 0 &&
                m_selectedPID != mainListView.SelectedItems[0].Text)

            {
                m_selectedPID = mainListView.SelectedItems[0].Text;
                m_refreshSecondary = true;
            }
        }

        private void binrayAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinrayAnalysis ba = new BinrayAnalysis();
            ba.SetELF(SSHClient.DoCommand("readelf -a /proc/" + m_selectedPID + "/exe"));
            ba.ShowDialog();
        }
    }
}
