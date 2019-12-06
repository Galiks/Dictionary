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

        public static int NumberOfPictures;//1 - Animals, 2 - Hobbies

        public static int NumberOfQuiz;//1 - Text, 2 - Images, 3 - Game

        //private readonly WordStatictics wordStatictics;

        public MainForm()
        {
            InitializeComponent();
            //Image img = Image.FromFile(@"orig.gif");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox1.Image = img;
        }

        //private void Text_Click(object sender, EventArgs e)
        //{
        //    NumberOfQuiz = 1;
        //    Form1 f1 = new Form1();
        //    if (WordDictionary.Dict.Count != 0)
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
        //    WordDictionary.Dict.Clear();
        //    string ChooseDict = "Animals.txt";
        //    WordDictionary.AddToDict(ChooseDict);
        //    label3.Text = "В словарь добавлены слова на тему: животные";
        //    label3.ForeColor = Color.Green;
        //    Images.Enabled = true;
        //    Game.Enabled = true;
        //    NumberOfPictures = 1;
        //}

        //private void Hobby_Click(object sender, EventArgs e)
        //{
        //    WordDictionary.Dict.Clear();
        //    string ChooseDict = "Hobby.txt";
        //    WordDictionary.AddToDict(ChooseDict);
        //    label3.Text = "В словарь добавлены слова на тему: хобби";
        //    label3.ForeColor = Color.Green;
        //    Images.Enabled = true;
        //    Game.Enabled = true;
        //    NumberOfPictures = 2;
        //}

        private void Button1_Click(object sender, EventArgs e)
        {
            OutputDictcs outDict = new OutputDictcs();
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
        //    if (WordDictionary.Dict.Count != 0)
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
            richTextBox1.ReadOnly = true;
            richTextBox1.Text = "Здравствуйте!" + Environment.NewLine + 
                "Это приложение создано для того, чтобы пользователь смог выучить английские слова." + Environment.NewLine + 
                "На данный момент доступно только 2 стандартных словаря: животные и хобби." + Environment.NewLine + 
                "Пользователь может также добавить свои слова, выбрав его через окно выбора файла." + Environment.NewLine +
                "В приложении присутствует 4 типа заданий:" + Environment.NewLine + 
                "1. текстовый вариант," + Environment.NewLine + 
                "2. вариант с картинками," + Environment.NewLine + 
                "3. игра" + Environment.NewLine + 
                "4. тест";
            label3.Text = "";
        }

        //private void Images_Click(object sender, EventArgs e)
        //{
        //    NumberOfQuiz = 2;
        //    Form imagesGame = new Images();
        //    if (WordDictionary.Dict.Count != 0)
        //    {
        //        imagesGame.Show();
        //    }
        //    else
        //    {
        //        label3.Text = "Выберите словарь!";
        //        label3.ForeColor = Color.DarkRed;
        //    }
        //}

        //private void UserWordDictionary_Click(object sender, EventArgs e)
        //{
        //    WordDictionary.Dict.Clear();
        //    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        using (StreamReader fileRead = new StreamReader(openFileDialog1.FileName))
        //        {
        //            while (fileRead.Peek() > -1)
        //            {
        //                string[] line = fileRead.ReadLine().Split(',');
        //                for (int i = 0; i < line.Length - 1; i++)
        //                {
        //                    if (!WordDictionary.Dict.Contains(new KeyValuePair<string, string>(line[i], line[i + 1])))
        //                        WordDictionary.Dict.Add(line[i], line[i + 1]);
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
            WordDictionary.DictionaryOfWords.Clear();
            string ChooseDict = "Animals.txt";
            WordDictionary.AddToDict(ChooseDict);
            label3.Text = "В словарь добавлены слова на тему: животные";
            label3.ForeColor = Color.Green;

            textToolStripMenuItem.Enabled = true;
            gameToolStripMenuItem.Enabled = true;
            //Images.Enabled = true;
            //Game.Enabled = true;
            NumberOfPictures = 1;
        }

        private void HobbyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WordDictionary.DictionaryOfWords.Clear();
            string ChooseDict = "Hobby.txt";
            WordDictionary.AddToDict(ChooseDict);
            label3.Text = "В словарь добавлены слова на тему: хобби";
            label3.ForeColor = Color.Green;
            textToolStripMenuItem.Enabled = true;
            gameToolStripMenuItem.Enabled = true;
            //Images.Enabled = true;
            //Game.Enabled = true;
            NumberOfPictures = 2;
        }

        private void UserDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WordDictionary.DictionaryOfWords.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                WordDictionary.AddToDict(openFileDialog1.FileName);
            }
            label3.Text = "В словарь добавлены слова пользователя";
            label3.ForeColor = Color.Green;
            textToolStripMenuItem.Enabled = true;
            imageToolStripMenuItem.Enabled = false;
            gameToolStripMenuItem.Enabled = false;
        }

        private void TextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberOfQuiz = 1;
            Text f1 = new Text();


            if (WordDictionary.DictionaryOfWords.Count != 0)
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

            if (WordDictionary.DictionaryOfWords.Count != 0)
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

            if (WordDictionary.DictionaryOfWords.Count != 0)
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
            Settings settings = new Settings();
            settings.Show();
        }

        private void QuizToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WordDictionary.DictionaryOfWords.Count != 0)
            {
                Test test = new Test();
                test.Show();
            }
            else
            {
                label3.Text = "Выберите словарь!";
                label3.ForeColor = Color.DarkRed;
            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}