using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class MainForm : Form
    {
        public WordDictionary dictionary;

        public static int NumberOfPictures;//1 - Animals, 2 - Hobbies

        public static int NumberOfQuiz;//1 - Text, 2 - Images, 3 - Game

        private readonly Form outDict;

        //private readonly WordStatictics wordStatictics;

        private readonly Settings settings;

        public MainForm()
        {
            InitializeComponent();
            Image img = Image.FromFile(@"orig.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = img;
            dictionary = new WordDictionary();
            outDict = new OutputDictcs();
            settings = new Settings();
        }

        //private void Text_Click(object sender, EventArgs e)
        //{
        //    NumberOfQuiz = 1;
        //    Form1 f1 = new Form1();
        //    if (Dictionary.Dict.Count != 0)
        //    {
        //        f1.Show();
        //    }
        //    else
        //    {
        //        label3.Text = "Выберите словарь!";
        //        label3.ForeColor = Color.DarkRed;
        //    }
        //}

        //private void AnimalsDict_Click(object sender, EventArgs e)
        //{
        //    Dictionary.Dict.Clear();
        //    string ChooseDict = "Animals.txt";
        //    Dictionary.AddToDict(ChooseDict);
        //    label3.Text = "В словарь добавлены слова на тему: животные";
        //    label3.ForeColor = Color.Green;
        //    Images.Enabled = true;
        //    Game.Enabled = true;
        //    NumberOfPictures = 1;
        //}

        //private void Hobby_Click(object sender, EventArgs e)
        //{
        //    Dictionary.Dict.Clear();
        //    string ChooseDict = "Hobby.txt";
        //    Dictionary.AddToDict(ChooseDict);
        //    label3.Text = "В словарь добавлены слова на тему: хобби";
        //    label3.ForeColor = Color.Green;
        //    Images.Enabled = true;
        //    Game.Enabled = true;
        //    NumberOfPictures = 2;
        //}

        private void Button1_Click(object sender, EventArgs e)
        {
            outDict.Show();
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

        //private void Game_Click(object sender, EventArgs e)
        //{
        //    NumberOfQuiz = 3;
        //    Form gaming = new Game();
        //    if (Dictionary.Dict.Count != 0)
        //    {
        //        gaming.Show();
        //    }
        //    else
        //    {
        //        label3.Text = "Выберите словарь!";
        //        label3.ForeColor = Color.DarkRed;
        //    }
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        //private void Images_Click(object sender, EventArgs e)
        //{
        //    NumberOfQuiz = 2;
        //    Form imagesGame = new Images();
        //    if (Dictionary.Dict.Count != 0)
        //    {
        //        imagesGame.Show();
        //    }
        //    else
        //    {
        //        label3.Text = "Выберите словарь!";
        //        label3.ForeColor = Color.DarkRed;
        //    }
        //}

        //private void UserDictionary_Click(object sender, EventArgs e)
        //{
        //    Dictionary.Dict.Clear();
        //    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        using (StreamReader fileRead = new StreamReader(openFileDialog1.FileName))
        //        {
        //            while (fileRead.Peek() > -1)
        //            {
        //                string[] line = fileRead.ReadLine().Split(',');
        //                for (int i = 0; i < line.Length - 1; i++)
        //                {
        //                    if (!Dictionary.Dict.Contains(new KeyValuePair<string, string>(line[i], line[i + 1])))
        //                        Dictionary.Dict.Add(line[i], line[i + 1]);
        //                }
        //            }
        //            fileRead.Close();
        //        }
        //    }
        //    label3.Text = "В словарь добавлены слова пользователя";
        //    label3.ForeColor = Color.Green;
        //    Images.Enabled = false;
        //    Game.Enabled = false;
        //}

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void AnimalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dictionary.Dict.Clear();
            string ChooseDict = "Animals.txt";
            dictionary.AddToDict(ChooseDict);
            label3.Text = "В словарь добавлены слова на тему: животные";
            label3.ForeColor = Color.Green;
            текстовыйToolStripMenuItem.Enabled = true;
            играToolStripMenuItem.Enabled = true;
            //Images.Enabled = true;
            //Game.Enabled = true;
            NumberOfPictures = 1;
        }

        private void HobbyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dictionary.Dict.Clear();
            string ChooseDict = "Hobby.txt";
            dictionary.AddToDict(ChooseDict);
            label3.Text = "В словарь добавлены слова на тему: хобби";
            label3.ForeColor = Color.Green;
            текстовыйToolStripMenuItem.Enabled = true;
            играToolStripMenuItem.Enabled = true;
            //Images.Enabled = true;
            //Game.Enabled = true;
            NumberOfPictures = 2;
        }

        private void UserDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dictionary.Dict.Clear();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamReader fileRead = new StreamReader(openFileDialog1.FileName))
                {
                    while (fileRead.Peek() > -1)
                    {
                        string[] line = fileRead.ReadLine().Split(',');
                        for (int i = 0; i < line.Length - 1; i++)
                        {
                            if (!dictionary.Dict.Contains(new KeyValuePair<string, string>(line[i], line[i + 1])))
                                dictionary.Dict.Add(line[i], line[i + 1]);
                        }
                    }
                    fileRead.Close();
                }
            }
            label3.Text = "В словарь добавлены слова пользователя";
            label3.ForeColor = Color.Green;
            текстовыйToolStripMenuItem.Enabled = false;
            играToolStripMenuItem.Enabled = false;
        }

        private void TextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberOfQuiz = 1;
            Form1 f1 = new Form1();


            if (dictionary.Dict.Count != 0)
            {
                f1.Show();
            }
            else
            {
                label3.Text = "Выберите словарь!";
                label3.ForeColor = Color.DarkRed;
            }

        }

        private void ImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberOfQuiz = 2;
            Form imagesGame = new Images();

            if (dictionary.Dict.Count != 0)
            {
                imagesGame.Show();
            }
            else
            {
                label3.Text = "Выберите словарь!";
                label3.ForeColor = Color.DarkRed;
            }

        }

        private void GameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberOfQuiz = 3;
            Form gaming = new Game();

            if (dictionary.Dict.Count != 0)
            {
                gaming.Show();
            }
            else
            {
                label3.Text = "Выберите словарь!";
                label3.ForeColor = Color.DarkRed;
            }

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.Show();
        }
    }
}
