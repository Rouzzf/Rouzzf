using Rouzzf.Server.Models;
using Rouzzf.Server.Networking;
using Rouzzf.Server.Utilities;
using System;
using System.Globalization;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Rouzzf.Server.Forms
{
    public partial class FrmSettings : Form
    {
        private readonly RouzzfServer _listenServer;

        public FrmSettings(RouzzfServer listenServer)
        {
            this._listenServer = listenServer;

            InitializeComponent();

            ToggleListenerSettings(!listenServer.Listening);

            ShowPassword(false);
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            ncPort.Value = Settings.ListenPort;
            chkIPv6Support.Checked = Settings.IPv6Support;
            chkAutoListen.Checked = Settings.AutoListen;
            chkPopup.Checked = Settings.ShowPopup;
            chkUseUpnp.Checked = Settings.UseUPnP;
            chkShowTooltip.Checked = Settings.ShowToolTip;
            chkNoIPIntegration.Checked = Settings.EnableNoIPUpdater;
            txtNoIPHost.Text = Settings.NoIPHost;
            txtNoIPUser.Text = Settings.NoIPUsername;
            txtNoIPPass.Text = Settings.NoIPPassword;
        }

        private ushort GetPortSafe()
        {
            var portValue = ncPort.Value.ToString(CultureInfo.InvariantCulture);
            ushort port;
            return (!ushort.TryParse(portValue, out port)) ? (ushort)0 : port;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            ushort port = GetPortSafe();

            if (port == 0)
            {
                MessageBox.Show("请输入有效的端口 > 0.", "请输入有效端口", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (btnListen.Text == "启动监听" && !_listenServer.Listening)
            {
                try
                {
                    if (chkNoIPIntegration.Checked)
                        NoIpUpdater.Start();
                    _listenServer.Listen(port, chkIPv6Support.Checked, chkUseUpnp.Checked);
                    ToggleListenerSettings(false);
                }
                catch (SocketException ex)
                {
                    if (ex.ErrorCode == 10048)
                    {
                        MessageBox.Show(this, "端口被占用.", "套接字错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(this, $"发生意外的套接字错误: {ex.Message}\n\n错误码: {ex.ErrorCode}\n\n", "套接字错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    _listenServer.Disconnect();
                }
                catch (Exception)
                {
                    _listenServer.Disconnect();
                }
            }
            else if (btnListen.Text == "停止监听" && _listenServer.Listening)
            {
                _listenServer.Disconnect();
                ToggleListenerSettings(true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ushort port = GetPortSafe();

            if (port == 0)
            {
                MessageBox.Show("请输入有效端口 > 0.", "请输入有效端口", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Settings.ListenPort = port;
            Settings.IPv6Support = chkIPv6Support.Checked;
            Settings.AutoListen = chkAutoListen.Checked;
            Settings.ShowPopup = chkPopup.Checked;
            Settings.UseUPnP = chkUseUpnp.Checked;
            Settings.ShowToolTip = chkShowTooltip.Checked;
            Settings.EnableNoIPUpdater = chkNoIPIntegration.Checked;
            Settings.NoIPHost = txtNoIPHost.Text;
            Settings.NoIPUsername = txtNoIPUser.Text;
            Settings.NoIPPassword = txtNoIPPass.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前配置", "关闭", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
                this.Close();
        }

        private void chkNoIPIntegration_CheckedChanged(object sender, EventArgs e)
        {
            NoIPControlHandler(chkNoIPIntegration.Checked);
        }

        private void ToggleListenerSettings(bool enabled)
        {
            btnListen.Text = enabled ? "启动监听" : "停止监听";
            ncPort.Enabled = enabled;
            chkIPv6Support.Enabled = enabled;
            chkUseUpnp.Enabled = enabled;
        }

        private void NoIPControlHandler(bool enable)
        {
            lblHost.Enabled = enable;
            lblUser.Enabled = enable;
            lblPass.Enabled = enable;
            txtNoIPHost.Enabled = enable;
            txtNoIPUser.Enabled = enable;
            txtNoIPPass.Enabled = enable;
            chkShowPassword.Enabled = enable;
        }

        private void ShowPassword(bool show = true)
        {
            txtNoIPPass.PasswordChar = (show) ? (char)0 : (char)'●';
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            ShowPassword(chkShowPassword.Checked);
        }
    }
}
