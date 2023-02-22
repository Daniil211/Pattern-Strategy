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

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Context context;
        public int count = 0;
        public Form1()
        {
            InitializeComponent();

            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            IOFile.form1 = this;
            shell.form1 = this;
            Vstavka.form1 = this;
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            Rnd rnd = new Rnd();
            this.Hide();
            rnd.Show();
        }
        private void buttonSort_Click(object sender, EventArgs e)
        {
            try
            {
                if (Context.array != null)
                {
                    if (radioButtonBubbleSort.Checked == true)
                    {
                        this.context = new Context(new Vstavka());
                        context.ExecuteAlgorithm();
                        this.AddItemsListBox();
                        IOFile.SaveData();
                        buttonSort.Enabled = false;
                    }
                    if (radioButton2.Checked == true)
                    {
                        this.context = new Context(new shell());
                        context.ExecuteAlgorithm();
                        this.AddItemsListBox();
                        IOFile.SaveData();
                        buttonSort.Enabled = false;
                    }
                    IOFile.content = "";
                }
                else
                {
                    MessageBox.Show("Массив пуст, сортировка невозможна");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
        public void AddItemsListBox(int first = -1, int second = -1)
        {
            listBox1.Items.Add("");
            foreach (var item in Context.array)
            {
                if (item == first || item == second)
                {
                    listBox1.Items[count] += '[' + Convert.ToString(item) + ']' + " ";
                }
                else
                {
                    listBox1.Items[count] += Convert.ToString(item) + " ";
                }
            }
            count++;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (label3.Text != "" && label6.Text != "" && label5.Text != "")
            {
                buttonSort.Enabled = true;
                listBox1.Items.Clear();
                label3.Text = "";
                label6.Text = "";
                label5.Text = "";
                Context.array = null;
                this.count = 0;
            }
            else
                MessageBox.Show("Поля и так пусты");
        }

       

        private void ToolStripMenuItemX_Click(object sender, EventArgs e)
        {
            Rnd rnd = new Rnd();
            this.Hide();
            rnd.Show();
        }
    }
}
