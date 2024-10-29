using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace tunagu
{
    public partial class tunagu : Form
    {
        const string MessageTitle = "tunagu";

        private readonly Dictionary<string, RoomAP> APs = new Dictionary<string, RoomAP>
        {
            {"radio0", new RoomAP("1-A", "AP1-A") },
            {"radio1", new RoomAP("1-B", "AP1-B") },
            {"radio2", new RoomAP("1-C", "AP1-C") },
            {"radio3", new RoomAP("1-D", "AP1-D") },
            {"radio4", new RoomAP("2-A", "AP2-A") },
            {"radio5", new RoomAP("2-B", "AP2-B") },
            {"radio6", new RoomAP("2-C", "AP2-C") },
            {"radio7", new RoomAP("2-D", "AP2-D") },
            {"radio8", new RoomAP("3-A", "AP3-A") },
            {"radio9", new RoomAP("3-B", "AP3-B") },
        };

        public tunagu()
        {
            InitializeComponent();
        }

        private void tunagu_Load(object sender, EventArgs e)
        {
            // 部屋名セット
            foreach(var kv in APs)
            {
                ((RadioButton)this.Controls[kv.Key]).Text = kv.Value.RoomName;
            }

            radio0.Checked = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ssid = "";
            foreach(var kv in APs)
            {
                if (((RadioButton)this.Controls[kv.Key]).Checked)
                {
                    ssid = kv.Value.APName;
                    break;
                }
            }

            if (ssid != "")
            {
                string command = $"/c netsh wlan connect name=\"{ssid}\"";
                System.Diagnostics.Process.Start("cmd.exe", command);
                MessageBox.Show(ssid + " への接続を試みました", MessageTitle, MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("教室を指定してください", MessageTitle, MessageBoxButtons.OK);
            }
        }

        private void itemVersion_Click(object sender, EventArgs e)
        {
            var ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            MessageBox.Show("バージョン " + ver.FileVersion, MessageTitle, MessageBoxButtons.OK);
        }
    }
}
