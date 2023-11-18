using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace redaktor_bebri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Сохранить файл?",
                "Текстовый редактор",
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                File.WriteAllText(filename, textBox1.Text);
                textBox1.Clear();
            }
            else
            {
                textBox1.Clear();
            }

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = File.ReadAllText(filename);
            textBox1.Text = fileText;
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try {
                string filename = saveFileDialog1.FileName;
                File.WriteAllText(filename, textBox1.Text);
            }
            catch
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
                string filename = saveFileDialog1.FileName;
                File.WriteAllText(filename, textBox1.Text);
            }
      
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            File.WriteAllText(filename, textBox1.Text);
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
