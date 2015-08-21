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

namespace SimpleReadWrite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            var myFile = new StreamReader(@"A:\Security.txt");
            MessageBox.Show(myFile.ReadLine());
            myFile.Close();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            var myFile = new StreamWriter(@"A:\Security.txt");
            myFile.WriteLine("Trust No One");
            myFile.Close();
        }
    }
}
