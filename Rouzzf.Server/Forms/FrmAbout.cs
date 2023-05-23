﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Rouzzf.Server.Forms
{
    public partial class FrmAbout : Form
    {

        public FrmAbout()
        {
            InitializeComponent();

            lblVersion.Text = $"v{Application.ProductVersion}";
            rtxtContent.Text = Properties.Resources.License;
        }

        private void lnkGithubPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Process.Start(e.Link.LinkData.ToString());
        }

        private void lnkCredits_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
