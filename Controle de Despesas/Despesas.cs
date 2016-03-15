using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_de_Despesas
{
    public partial class Despesas : Form
    {
        string folderPath;

        public Despesas(string folderP)
        {
            InitializeComponent();
            folderPath = folderP;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            System.IO.Directory.CreateDirectory(folderPath+textBox1.Text + "-" + textBox2.Text);
            this.Close();
        }
    }
}
