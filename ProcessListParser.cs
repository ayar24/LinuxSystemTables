using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinuxSystemTables
{
    

    public class ProcessInfo : LinuxItem
    {
        public string PID { get; }
        public string Filename { get; }
        public string Cmdline { get; }
        public double CPU { get; }
        public double Memory { get; }

       

        public ProcessInfo(string pid, string filename, string cmdline, double cpu, double memory)
        {
            PID = pid;
            Filename = filename;
            Cmdline = cmdline;
            CPU = cpu;
            Memory = memory;

        }
    }
    internal class ProcessListParser : LinuxItemParser
    {
        public override string GetCommandLine(string sort, bool asc, string param = "")
        {
            if (sort == "")
                sort = "%cpu";
            else if (sort == "4")
                sort = "%mem";
            if (sort == "3")
                sort = "%cpu";
            if (sort == "2")
                sort = "command";
            if (sort == "0")
                sort = "pid";
            if (asc == true)
                sort = "-" + sort;
            return "ps -eo pid,command,%cpu,%mem --sort=" + sort;
        }
        public override LinuxItem ParseOneLine(string input)
        {
            LinuxItem res = null;
            string[] parts = input.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 4 && int.TryParse(parts[0], out int pid) && double.TryParse(parts[2], out double cpu) && double.TryParse(parts[3], out double memory))
            {
                string commandLine = string.Join(" ", parts, 1, parts.Length - 3);
                res = new ProcessInfo(pid.ToString(), "", commandLine, cpu, memory);
            }
            return res;
        }
        public override ListViewItem ParseListItem(LinuxItem listItem, string filter, string selected)
        {
            ProcessInfo process = (ProcessInfo)listItem;

            ListViewItem item = new ListViewItem(process.PID.ToString());
           
            item.SubItems.Add(process.Cmdline);
            item.SubItems.Add(process.CPU.ToString("F2"));
            item.SubItems.Add(process.Memory.ToString("F2"));
            if (selected == process.PID)
            {
                item.Selected = true;

            }
            if (filter == "" || process.Cmdline.Contains(filter) || process.PID.ToString().Contains(filter))
                return item;

            return null;
        }
        public override List<string> GetListColumns()
        {
            return new List<string> { "PID", "Command", "CPU", "Memory" };
        }
    }
}
