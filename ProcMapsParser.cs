using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinuxSystemTables
{
    public class MemoryRegion : LinuxItem
    {
        public string LibraryPath { get; }
        public string StartAddress { get; }
        public string EndAddress { get; }
        public string Permissions { get; }

        public MemoryRegion(string libraryPath, string startAddress, string endAddress, string permissions)
        {
            LibraryPath = libraryPath;
            StartAddress = startAddress;
            EndAddress = endAddress;
            Permissions = permissions;
        }
    }
    internal class ProcMapsParser : LinuxItemParser
    {
        public override string GetCommandLine(string sort, bool asc, string param = "")
        {
            return "cat /proc/" + param + "/maps";
        }
        public override LinuxItem ParseOneLine(string input)
        {         
            Match match = Regex.Match(input, @"([0-9A-Fa-f]+)-([0-9A-Fa-f]+)\s+([rwxsp-]+)\s+[0-9A-Fa-f]+\s+[0-9A-Fa-f]+:[0-9A-Fa-f]+\s+[0-9]+\s*(.+)");
            if (match.Success)
            {
                string startAddress = match.Groups[1].Value;
                string endAddress = match.Groups[2].Value;
                string permissions = match.Groups[3].Value;
                string libraryPath = match.Groups[4].Value.Trim();

                return new MemoryRegion(libraryPath, startAddress, endAddress, permissions);
            }
            return null;
        }
        public override ListViewItem ParseListItem(LinuxItem listItem, string filter, string selected)
        {
            MemoryRegion memRegion = (MemoryRegion)listItem;

            ListViewItem item = new ListViewItem(memRegion.LibraryPath);
           
            item.SubItems.Add(memRegion.Permissions);
            item.SubItems.Add(memRegion.StartAddress);
            item.SubItems.Add(memRegion.StartAddress);
            if (selected == memRegion.LibraryPath)
            {
                item.Selected = true;

            }
            if (filter == "" || memRegion.LibraryPath.Contains(filter) )
                return item;

            return null;
        }
        public override List<string> GetListColumns()
        {
            return new List<string> { "PID", "Command", "CPU", "Memory" };
        }
    }
}
