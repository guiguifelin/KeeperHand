using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button_finish.Enabled = false;
            button_update.Enabled = true;
            text_updating.Text = "Please launch the update...";
        }

        private void button_finish_Click(object sender, EventArgs e)
        {
            Process myInfo = new Process();
            myInfo.StartInfo.FileName = "Game.exe";
            myInfo.StartInfo.WorkingDirectory = Application.StartupPath;
            myInfo.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_update.Enabled = false;
            text_updating.Text = "The game is updating...";
            GZip.ExtractZipFile(Application.StartupPath + "\\Data\\Update.zip", null, Application.StartupPath);
            text_updating.Text = "The game have been updated !";
            button_finish.Enabled = true;
        }
    }
}
