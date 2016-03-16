using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Controle_de_Despesas
{
    public partial class Form1 : Form
    {
        public static string selectedAno;
        public static string selectedMes;
        public static string mainDirectory;
        BindingList<string> ano = new BindingList<string>();
        BindingList<string> mes = new BindingList<string>();
        
        
       
        public Form1()
        {
            InitializeComponent();

            mainDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Despesas\";
            string []anoFolders = System.IO.Directory.GetDirectories(mainDirectory);
            Console.WriteLine(mainDirectory);
            
            foreach (var folder in anoFolders)
            {
                string temp = folder.Substring(folder.LastIndexOf(@"\")+1);
                ano.Add(temp);
            }

           
            comboBoxAno.DataSource = ano;
            comboBoxMes.DataSource = mes;

            if (ano.Count == 0) {
                comboBoxMes.Enabled = false;
                addMes.Enabled = false;
                comboBoxAno.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
            }
            
        }
              
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 popup = new Form2(this);
            popup.ShowDialog();
        }

        private void addMes_Click(object sender, EventArgs e)
        {
            Form3 popup = new Form3(this);
            popup.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAno = comboBoxAno.Text;
            Console.WriteLine(selectedAno);           
            mes.Clear();
            comboBoxMes.DataSource = null;
            string[] mesFolders = System.IO.Directory.GetDirectories(mainDirectory + comboBoxAno.Text);
            Console.WriteLine(mesFolders.Length);
            for (int i = 0; i< mesFolders.Length; i++) {
                string temp = mesFolders[i].Substring(mesFolders[i].LastIndexOf(@"\") + 1);
                // Console.WriteLine(mes.Count);
                comboBoxMes.Enabled = true;
                mes.Add(temp);
 //               Console.WriteLine(mes.Count);
            }
            


            if (mes.Count == 0)
            {
                comboBoxMes.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else {
                comboBoxMes.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                comboBoxMes.DataSource = mes;

            }
            

        }

        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboBoxMes.SelectedIndex == -1)
            {
                string[] mesFolders = System.IO.Directory.GetDirectories(mainDirectory + comboBoxAno.Text);
                string folder = mesFolders[0].Substring(mesFolders[0].LastIndexOf(@"\") + 1);
                comboBoxMes.SelectedIndex = 0;
                comboBoxMes.Text = folder;
                selectedMes = comboBoxMes.Text;
                return;
            }
            else {
                string[] despesaFolders = System.IO.Directory.GetDirectories(mainDirectory + comboBoxAno.Text + @"\" + comboBoxMes.Text);
                foreach (var folder in despesaFolders)
                {

                    //Console.WriteLine(folder);
                    string tempDespesa = folder.Substring(folder.LastIndexOf(@"\") + 1);
                    Console.WriteLine(tempDespesa);
                    string fornecedor = tempDespesa.Substring(0, tempDespesa.IndexOf("-"));
                    Console.WriteLine(fornecedor);
                    string despesa = tempDespesa.Substring(tempDespesa.IndexOf("-")+1);
                    Console.WriteLine(despesa);
                    ListViewItem item = new ListViewItem(fornecedor);
                    item.SubItems.Add(despesa);
                    listView2.Items.Add(item);
                }
            }
            
            selectedMes = comboBoxMes.Text;
        }

        public void ok_Clicked(string stringCadastrada,int indexTela) {

            if (indexTela == 0)
            {
                if (ano.Contains(stringCadastrada)) {
                    return;
                }
                ano.Add(stringCadastrada);
                //comboBoxAno.DataSource = ano;
                comboBoxAno.SelectedIndex = comboBoxAno.FindStringExact(stringCadastrada);
                selectedAno = comboBoxAno.Text;
                if (ano.Count == 1) {
                    comboBoxMes.Enabled = true;
                    addMes.Enabled = true;
                    comboBoxAno.Enabled = true;
                }
                if (mes.Count == 0) {
                    comboBoxMes.Enabled = false;
                }

            }
            else if (indexTela == 1)
            {
                if (mes.Contains(stringCadastrada)) {
                    return;
                } 
                mes.Add(stringCadastrada);                
                //comboBoxMes.DataSource = mes;
                comboBoxMes.SelectedIndex = comboBoxMes.FindStringExact(stringCadastrada);
                selectedMes = comboBoxMes.Text;
                if (mes.Count == 1) {
                    comboBoxMes.Enabled = true;
                    button1.Enabled = true;
                    button2.Enabled = true;
                }
            }
            
             
                        
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string folderPath = mainDirectory + selectedAno +@"\"+ selectedMes + @"\";
            Console.WriteLine(folderPath);
            Despesas despesas = new Despesas(this,folderPath);
            despesas.ShowDialog();
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        public void registrarDespesa(string fornecedor, string despesa) {
            ListViewItem item = new ListViewItem(fornecedor);
            item.SubItems.Add(despesa);
            listView2.Items.Add(item);

        }
    }
}
