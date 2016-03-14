using System;
using System.Windows.Forms;

namespace Controle_de_Despesas
{
    public partial class Form3 : Form
    {
        Form1 form1;

        public Form3(Form1 for1)
        {
            InitializeComponent();
            form1 = for1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folderName = Form1.mainDirectory + Form1.selectedAno + @"\" + dateTimePicker1.Text;

            System.IO.Directory.CreateDirectory(folderName);
            form1.ok_Clicked(dateTimePicker1.Text, 1);
            this.Close();
        }
    }
}
