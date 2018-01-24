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
    public partial class LogIn : Form
    {
        private MainForm mainForm = new MainForm();

        private SignUp signUp = new SignUp();

        public LogIn()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        string StupidMethod(string word)//этот метод обрезает найденный файл в каталоге так, чтобы осталось только название
        {
            char[] letters = new char[word.Length];
            for(int i = 6; i < word.Length-4; i++)
            {
                letters[i] = word[i];
            }

            foreach(char x in letters)
            {
                richTextBox1.Text += x;
            }
            
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("Enter username");
            }
            else if (textBox2.Text == null)
            {
                MessageBox.Show("Enter password");
            }
            else if (textBox1.Text == "admin" & textBox2.Text == "admin")
            {
                mainForm.Show();
            }
            else
            {
                string[] dirs = Directory.GetFiles(@"Users/", "*.txt");
                foreach (string dir in dirs)
                {
                    string login = StupidMethod(dir);
                    if (textBox1.Text == richTextBox1.Text)
                    {
                        using (StreamReader password = new StreamReader(dir))
                        {
                            string userPassword = password.ReadToEnd();
                            if (textBox2.Text == userPassword)
                            {
                                mainForm.Show();
                            }
                            else MessageBox.Show("Wrong password");
                        }
                    }
                    else MessageBox.Show("Wrong login");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            signUp.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
