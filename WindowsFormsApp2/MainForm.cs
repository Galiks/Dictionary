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
            Images.Enabled = true;
            Game.Enabled = true;
        }

        private void Hobby_Click(object sender, EventArgs e)
        {
            Dictionary.Dict.Clear();
            string ChooseDict = "Hobby.txt";
            Dictionary.AddToDict(ChooseDict);
            label3.Text = "В словарь добавлены слова на тему: хобби";
            label3.ForeColor = Color.Green;
            Images.Enabled = true;
            Game.Enabled = true;
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
            label3.Text = "";
        }

        private void Images_Click(object sender, EventArgs e)
        {
            Form imagesGame = new Images();
            if (Dictionary.Dict.Count != 0)
            {
                imagesGame.Show();
            }
            else
            {
                label3.Text = "Выберите словарь!";
                label3.ForeColor = Color.DarkRed;
            }
        }

        private void UserDictionary_Click(object sender, EventArgs e)
        {
            Dictionary.Dict.Clear();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamReader fileRead = new StreamReader(openFileDialog1.FileName))
                {
                    while (fileRead.Peek() > -1)
                    {
                        string[] line = fileRead.ReadLine().Split(',');
                        for (int i = 0; i < line.Length - 1; i++)
                        {
                            if (!Dictionary.Dict.Contains(new KeyValuePair<string, string>(line[i], line[i + 1])))
                                Dictionary.Dict.Add(line[i], line[i + 1]);
                        }
                    }
                    fileRead.Close();
                }
            }
            Images.Enabled = false;
            Game.Enabled = false;
        }
    }
}
