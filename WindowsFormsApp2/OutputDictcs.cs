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

namespace WindowsFormsApp2
{
    public partial class OutputDictcs : Form
    {

        //Form mainform = new MainForm();

        public OutputDictcs()
        {
            InitializeComponent();
        }

        private void OutputDictcs_Load(object sender, EventArgs e)
        {

        }

        private void OutputDictcs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void OutPut_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = "Словарь слов:\n";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamReader fileRead = new StreamReader(openFileDialog1.FileName))
                {
                    while (fileRead.Peek() > -1)
                    {
                        string[] line = fileRead.ReadLine().Split(',');
                        for (int i = 0; i < line.Length - 1; i++)
                        {
                            richTextBox1.AppendText(line[i] + " : " + line[i + 1] + "\n");
                        }
                    }
                    fileRead.Close();
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
