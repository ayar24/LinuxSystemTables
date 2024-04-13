using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinuxSystemTables
{ 
    public class LogMessage : LinuxItem
    {
        public LogMessage(string message, string timestamp)
        {
            Timestamp = timestamp;
            Message = message;
        }
        public string Timestamp { get; set; }
        public string Message { get; set; }
    }
    public class LOGMessages
    {
        public LOGMessages()
        {
            //     logMessages = new List<LogMessage>();
        }
    }
    internal class LogsParser : LinuxItemParser 
    {
        public override LinuxItem ParseOneLine(string input)
        {
                // Split the line into parts
                string[] parts = input.Split(new[] { ' ' }, 6, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 6)
                {
                    string timestamp = $"{parts[0]} {parts[1]} {parts[2]}";
                    string machineName = parts[4];
                    string processInfo = parts[5];
                    string message = parts[5];

                    return new LogMessage(message, timestamp);
                }
         
            return null;
        }
        public override ListViewItem ParseListItem(LinuxItem listItem, string filter, string selected)
        {
            LogMessage logMessageItem = (LogMessage)listItem;

            ListViewItem item = new ListViewItem(logMessageItem.Timestamp);

            item.SubItems.Add(logMessageItem.Message);
          
            if (selected == logMessageItem.Message)
            {
                item.Selected = true;

            }
            if (filter == "" || logMessageItem.Message.Contains(filter) ||
                logMessageItem.Timestamp.ToString().Contains(filter))
                return item;

            return null;
        }
        public override List<string> GetListColumns()
        {
            return new List<string> { "Time", "Message"  };
        }

        public override string GetCommandLine(string sort, bool asc, string param = "")
        {
            return "cat /var/log/syslog";
        }

    }
}
