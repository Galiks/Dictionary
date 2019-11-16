using BusinessLogicLayer;
using CommonLayer;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class LogIn : Form
    {
        private const string patternForLogin = @"Users\/(.+?)\.";

        private readonly MainForm mainForm;
        private readonly Registration registration;
        private readonly IUserLogic loginLogic;

        public MainForm MainForm => mainForm;

        public Registration Registration => registration;

        public LogIn()
        {
            InitializeComponent();
            mainForm = new MainForm();
            registration = new Registration();
            NinjectCommon.Registration();
            loginLogic = NinjectCommon.Kernel.Get<IUserLogic>();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            
        }

        public string CutOffFileName(string word)//этот метод обрезает найденный файл в каталоге так, чтобы осталось только название
        {
            string login = string.Empty;
            try
            {
                login = Regex.Match(word, patternForLogin).Groups[1].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong login");
            }
            return login;
        }

        private void Button1_Click(object sender, EventArgs e)
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
                MainForm.Show();
            }
            else
            {
                if (loginLogic.IsConfirmLogin(textBox1.Text, textBox2.Text))
                {
                    MainForm.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Wrong login or password");
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Registration.Show();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
