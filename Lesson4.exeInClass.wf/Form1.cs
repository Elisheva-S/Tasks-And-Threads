using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lesson4.exeInClass.cl;
namespace Lesson4.exeInClass.wf
{
    public partial class Form1 : Form
    {
        GeneratesFilesAndInitThem g = new GeneratesFilesAndInitThem();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Generate(10);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            g.Create5Threads();

        }

        private void button3_Click(object sender, EventArgs e)
        {                     
            g.CreateNRemove10Files();
        }
    }
}
