using System;
using System.Windows.Forms;

namespace Controle_de_Despesas
{
    public partial class Form2 : Form
    {
        Form1 form1;
        
        public Form2(Form1 for1)
        {
            InitializeComponent();
            form1 = for1;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                string folderName = Form1.mainDirectory + dateTimePicker1.Text;
                //Console.WriteLine("Ano");
                System.IO.Directory.CreateDirectory(folderName);
                form1.ok_Clicked(dateTimePicker1.Text,0);
                this.Close();
    }

        
    }
}
