using DevExpress.Utils.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QY.DBtools
{
    public class RdpHelper
    {
        public static Regex IpAddressRegex = new Regex(@"^((25[0-5]|2[0-4]\d|[01]?\d\d?)($|(?!\.$)\.)){4}$", RegexOptions.Compiled);

        public static bool IsValidIp(string ip)
        {
            return IpAddressRegex.IsMatch(ip);
        }

        public static DXMenuItem GetRdpMenuItem()
        {
            return new DXMenuItem("连接远程桌面", ConnectToRdp);
        }

        private static void ConnectToRdp(object sender, EventArgs e)
        {
            var mi = (DXMenuItem)sender;
            try
            {
                Process.Start("mstsc", "/v:" + mi.Tag as string);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法运行远程桌面程序:\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
