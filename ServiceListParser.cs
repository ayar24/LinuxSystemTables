using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinuxSystemTables
{
    public class ServiceInfo : LinuxItem
    {
        public string Name { get; set; }
        public string Enabled { get; set; }
        public string State { get; set; }
        public string RunState { get; set; }
        public string Description { get; set; }
    }
    internal class ServiceListParser : LinuxItemParser
    {
        public override string GetCommandLine(string sort, bool asc, string param = "")
        {
            return "systemctl list-units --type=service";
        }
        public override LinuxItem ParseOneLine(string input)
        {
            string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 5)
            {
                ServiceInfo service = new ServiceInfo
                {
                    Name = parts[0],
                    Enabled = parts[1],
                    State = parts[2],
                    RunState = parts[3],
                    Description = string.Join(" ", parts.Skip(4))
                };
                return service;
            }
            return null;
        }
        public override ListViewItem ParseListItem(LinuxItem listItem, string filter, string selected)
        {
            ServiceInfo service = (ServiceInfo)listItem;

            ListViewItem item = new ListViewItem(service.Name);
           
            item.SubItems.Add(service.State);
            item.SubItems.Add(service.RunState);
            item.SubItems.Add(service.Enabled);
            item.SubItems.Add(service.Description);
            if (selected == service.Name)
            {
                item.Selected = true;

            }
            if (filter == "" || service.Name.Contains(filter) || service.Description.Contains(filter))
                return item;

            return null;
        }
        public override List<string> GetListColumns()
        {
            return new List<string> { "Name", "State", "RunState", "Enabled", "Description" };
        }

    }
}