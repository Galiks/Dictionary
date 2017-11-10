using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class MainForm : Form
    {

        Form OutDict = new OutputDictcs();

        private WordStatictics WS = new WordStatictics();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Text_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            if (Dictionary.Dict.Count != 0)
            {
                f1.Show();
            }
            else
            {
                label3.Text = "Выберите словарь!";
                label3.ForeColor = Color.DarkRed;
            }
        }

        private void AnimalsDict_Click(object sender, EventArgs e)
        {
            Dictionary.Dict.Clear();
            string ChooseDict = "Animals.txt";
            Dictionary.AddToDict(ChooseDict);
            label3.Text = "В словарь добавлены слова на тему: животные";
            label3.ForeColor = Color.Green;
        }

        private void Hobby_Click(object sender, EventArgs e)
        {
            Dictionary.Dict.Clear();
            string ChooseDict = "Hobby.txt";
            Dictionary.AddToDict(ChooseDict);
            label3.Text = "В словарь добавлены слова на тему: хобби";
            label3.ForeColor = Color.Green;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OutDict.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Game_Click(object sender, EventArgs e)
        {
            Form gaming = new Game();
            if (Dictionary.Dict.Count != 0)
            {
                gaming.Show();
            }
            else
            {
                label3.Text = "Выберите словарь!";
                label3.ForeColor = Color.DarkRed;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
