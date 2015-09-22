using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guild_Wars_2_Inventory_Search
{
    public partial class Form2 : Form
    {
        Form1 form1;

        public Form2(Form1 form1)
        {
           this.form1 = form1;
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://account.guildwars2.com/account/api-keys/create");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = form1.apiKey;
        }

        private void change_Click(object sender, EventArgs e)
        {
            if (form1.thread != null && form1.thread.IsAlive)
            {
                MessageBox.Show("Please wait untill the data has been loaded before changing the API key.");
            }
            else
            {
                form1.apiKey = textBox1.Text;
                Properties.Settings.Default.ApiKey = form1.apiKey;
                Properties.Settings.Default.Save();
                form1.refreshButton_Click(null, null);
                this.Close();
            }
        }
    }
}
