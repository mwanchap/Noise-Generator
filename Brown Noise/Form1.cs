using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrownNoise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SoundController.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SoundController.Stop();
        }

        private void barVol_Scroll(object sender, EventArgs e)
        {
            SoundController.Volume = barVol.Value / 100f;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SoundController.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundController.Stop();
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NoiseTypesList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private void NoiseTypesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NoiseTypesList_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
