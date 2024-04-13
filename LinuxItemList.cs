using Renci.SshNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinuxSystemTables
{
    internal class LinuxItemList
    {
        private List<LinuxItem> m_list;
     
        LinuxItemParser parser = null;
        public LinuxItemList (LinuxTableType type)
        {
            m_list = new List<LinuxItem>();
            
            if (type == LinuxTableType.Processes)
            {
                parser = new ProcessListParser();
            }
            else if (type == LinuxTableType.Services)
            {
                parser = new ServiceListParser();
            }
            else if (type == LinuxTableType.Users)
            {
                parser = new UsersListParser();
            }
            else if (type == LinuxTableType.Logs)
            {
                parser = new LogsParser();
            }
            else if (type == LinuxTableType.Procmaps)
            {
                parser = new ProcMapsParser();
            }
        }
        public bool Refresh(SSHGlobalSession client, string sort, bool asc, string param = "")
        {
            m_list.Clear();
           
            string sshCommandLine = parser.GetCommandLine(sort, asc, param);
            string psOutput = client.DoCommand(sshCommandLine); 

            string[] lines = psOutput.Split('\n');
            foreach (var line in lines)
            {
                LinuxItem item = parser.ParseOneLine(line);
                if (item != null)
                    m_list.Add(item);
            }
            return true;
        }
        public bool RefreshIncremental(SSHGlobalSession client, string sort, bool asc)
        {
            string sshCommandLine = parser.GetCommandLine(sort, asc);
            sshCommandLine = sshCommandLine.Replace("cat ", "");

            string psOutput = client.DoCommand("wc -l " + sshCommandLine);
            int currentLineCount = int.Parse(psOutput.Split(' ')[0]);
            int newLineCount = currentLineCount - m_list.Count;

            if ( newLineCount > 0)
            {
                string commandStr = $"tail -n {newLineCount} {sshCommandLine}";

                psOutput = client.DoCommand(commandStr);

                string[] lines = psOutput.Split('\n');
                foreach (var line in lines)
                {
                    LinuxItem item = parser.ParseOneLine(line);
                    if (item != null)
                        m_list.Add(item);
                }
                return true;
            }
            return false;
        }
        public bool UpdateListItems (ListView list, string filter, string selected)
        {
            if (list.Columns.Count == 0)
            {
                List<string> colNames = parser.GetListColumns();
                foreach (string colName in colNames) {
                    list.Columns.Add(colName);
                }
                
            }
            foreach (var linuxItem in m_list)
            {
                ListViewItem item = parser.ParseListItem(linuxItem, filter,selected);
                if (item != null)
                    list.Items.Add(item);
            }
            
            return true;
        }
      

    }
}
