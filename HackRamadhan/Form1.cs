using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackRamadhan
{
    public partial class Form1 : Form
    {
        private int currentCheckboxIndex = 0;
        private string[] checkboxStatuses;

        public Form1()
        {
            InitializeComponent();

            checkboxStatuses = new string[]
            {
                "Fast Time: OFF",
                "Auto Buka: OFF",
                "Auto Sahur: OFF",
                "Hack Pahala: OFF",
                "Anti Lapar: OFF",
                "Auto Khatam: OFF",
                "Hack Amal: OFF",
                "Anti Nafsu: OFF"
            };

            timer.Tick += StatusUpdateTimer_Tick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Masukan nama dan kota.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                checkboxStatuses[0] = $"Fast Time: {(fasttime.Checked ? "ON" : "OFF")}";
                checkboxStatuses[1] = $"Auto Buka: {(autobuka.Checked ? "ON" : "OFF")}";
                checkboxStatuses[2] = $"Auto Sahur: {(autosahur.Checked ? "ON" : "OFF")}";
                checkboxStatuses[3] = $"Hack Pahala: {(hackpahala.Checked ? "ON" : "OFF")}";
                checkboxStatuses[4] = $"Anti Lapar: {(antilapar.Checked ? "ON" : "OFF")}";
                checkboxStatuses[5] = $"Auto Khatam: {(autokhatam.Checked ? "ON" : "OFF")}";
                checkboxStatuses[6] = $"Hack Amal: {(hackamal.Checked ? "ON" : "OFF")}";
                checkboxStatuses[7] = $"Anti Nafsu: {(antinafsu.Checked ? "ON" : "OFF")}";

                lblstatus.Text = "Hacking...";
                currentCheckboxIndex = 0;
                progressBar.Value = 0;
                progressBar.Maximum = checkboxStatuses.Length;
                timer.Start();
            }
        }

        private void StatusUpdateTimer_Tick(object sender, EventArgs e)
        {
            lblstatus.Text = checkboxStatuses[currentCheckboxIndex];
            progressBar.Value = currentCheckboxIndex + 1;
            currentCheckboxIndex++;
            if (currentCheckboxIndex >= checkboxStatuses.Length)
            {
                timer.Stop();
                string statusFastTime = fasttime.Checked ? "ON" : "OFF";
                string statusAutoBuka = autobuka.Checked ? "ON" : "OFF";
                string statusAutoSahur = autosahur.Checked ? "ON" : "OFF";
                string statusHackPahala = hackpahala.Checked ? "ON" : "OFF";
                string statusAntiLapar = antilapar.Checked ? "ON" : "OFF";
                string statusAutoKhatam = autokhatam.Checked ? "ON" : "OFF";
                string statusHackAmal = hackamal.Checked ? "ON" : "OFF";
                string statusAntiNafsu = antinafsu.Checked ? "ON" : "OFF";
                string message = $"Fast Time = {statusFastTime}\nAuto Buka = {statusAutoBuka}\nAuto Sahur= {statusAutoSahur}\nHack Pahala = {statusHackPahala}\n" +
                                 $"Anti Lapar = {statusAntiLapar}\nAuto Khatam = {statusAutoKhatam}\nHack Amal = {statusHackAmal}\nAnti Nafsu = {statusAntiNafsu}";
                if (MessageBox.Show(message, "Hack Status", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    progressBar.Value = 0;
                    lblstatus.Text = "Idle...";
                }
            }
        }
    }
}
