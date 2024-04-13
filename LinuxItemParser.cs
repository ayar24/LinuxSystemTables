using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinuxSystemTables
{
    public enum LinuxTableType
    {
        Processes,
        Procmaps,
        Services,
        Packages,
        Logs,
        Users
    }
    public abstract class LinuxItem
    {
        public LinuxItem() { }
        public List<LinuxItem> SecondaryItems;
    }
    public abstract class LinuxItemParser
    {
        public LinuxItemParser() { }
        public abstract string GetCommandLine(string sort, bool asc, string param = "");
        public abstract LinuxItem ParseOneLine(string input);
        public abstract ListViewItem ParseListItem(LinuxItem listItem, string filter, string selected);
        public abstract List<string> GetListColumns();

    }
}
