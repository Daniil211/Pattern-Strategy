using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp9
{
    public partial class Rnd : Form
    {
        private Random random = new Random();
        public Rnd()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBoxCountElements.Text = Convert.ToString(trackBar1.Value);
        }

        private void buttonCreateArray_Click(object sender, EventArgs e)
        {
            try
            {
                Context.array = new int[trackBar1.Value];
                string s = " ";
                for (int i = 0; i < Context.array.Length; i++)
                {
                    Context.array[i] = random.Next(0, 1000);
                    s += random.Next(10000) + " ";
                }
                string path = @"C:\Users\id202\Desktop\LABA4_SORT\1.txt";
                using (FileStream fstream = new FileStream($"{path}", FileMode.OpenOrCreate))
                {
                    byte[] arr = System.Text.Encoding.Default.GetBytes(s);
                    fstream.Write(arr, 0, arr.Length);
                    MessageBox.Show("Значения записаны");
                }
                Form1 form1 = new Form1();
                form1.listBox1.Items.Add("");
                foreach (var item in Context.array)
                {
                    form1.listBox1.Items[form1.count] += Convert.ToString(item) + " ";
                }
                form1.count++;
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\id202\Desktop\LABA4_SORT\1.txt";
            System.IO.File.WriteAllBytes(path, new byte[0]);
            MessageBox.Show("Файл успешно очищен");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vuborka vuv = new Vuborka();
            this.Hide();
            vuv.Show();
        }

        private void textBoxCountElements_TextChanged(object sender, EventArgs e)
        {
            try
            {
                trackBar1.Value = Convert.ToInt32(textBoxCountElements.Text);
            }
            catch
            {
                MessageBox.Show("Входная строка имела неверный формат");
            }
        }

        private void SetGenerator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
