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

namespace WindowsFormsApp2
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream createFile = File.Create(@"Users/" + textBox1.Text + ".txt"))
            {
                Byte[] password = new UTF8Encoding(true).GetBytes(textBox2.Text);
                createFile.Write(password, 0, password.Length);
                MessageBox.Show("You are sign up");
            }
        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
