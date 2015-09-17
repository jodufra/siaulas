﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application
{
    public partial class Form1 : Form
    {
        private bool IsDone { get; set; }

        public Form1()
        {
            InitializeComponent();
            IsDone = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsDone)
            {
                Close();
                return;
            }

            try
            {
                FileStream fsRead = new FileStream("C:/temp/security.jpg", FileMode.Open);
                FileStream fsWrite = new FileStream("C:/temp/bak_security.jpg", FileMode.Create);

                int length = (int)Math.Min(20480, fsRead.Length);
                byte[] buffer = new byte[length];
                fsRead.Read(buffer, 0, length);
                fsWrite.Write(buffer, 0, length);
                fsRead.Close();
                fsWrite.Close();

                IsDone = true;
                button1.Text = "Done";
            }
            catch
            {
                button1.Text = "Error";
            }
        }
    }
}
