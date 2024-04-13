using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinuxSystemTables
{
    public class UserInfo : LinuxItem
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string UserId { get; set; }
        public string GroupId { get; set; }
        public string HomeDirectory { get; set; }
        public string Shell { get; set; }
    }
    internal class UsersListParser : LinuxItemParser
    {
        public override string GetCommandLine(string sort, bool asc, string param = "")
        {
            return "cat /etc/passwd";
        }
        public override LinuxItem ParseOneLine(string input)
        {
            string[] parts = input.Split(':');
            if (parts.Length >= 6)
            {
                UserInfo userInfo = new UserInfo();
                userInfo.UserName = parts[0];
                userInfo.UserId = parts[2];
                userInfo.GroupId = parts[3];
                userInfo.HomeDirectory = parts[5];
                userInfo.Shell = parts[6];
                return userInfo;
            }
            return null;
        }
        public override ListViewItem ParseListItem(LinuxItem listItem, string filter, string selected)
        {
            UserInfo userInfo = (UserInfo)listItem;

            ListViewItem item = new ListViewItem(userInfo.UserName);

            item.SubItems.Add(userInfo.UserId);
            item.SubItems.Add(userInfo.GroupId);
            item.SubItems.Add(userInfo.HomeDirectory);
            item.SubItems.Add(userInfo.Shell);
            if (selected == userInfo.UserName)
            {
                item.Selected = true;

            }
            if (filter == "" || userInfo.UserName.Contains(filter) || userInfo.HomeDirectory.Contains(filter))
                return item;

            return null;
        }
        public override List<string> GetListColumns()
        {
            return new List<string> { "Name", "UID", "GID", "Home", "Shell" };
        }

    }
}
