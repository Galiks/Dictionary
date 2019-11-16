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
    public partial class Images : Form
    {
        //private readonly MainForm mainForm;
        private readonly WordStatictics wordStatisctics;
        //private string RandomWordInRichTextBox;


        public Images()
        {
            InitializeComponent();
            //mainForm = new MainForm();
            wordStatisctics = new WordStatictics();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        //1 - Animals, 2 - Hobbies
        private void Start_Click(object sender, EventArgs e)
        {
            //RandomWordInRichTextBox = WordDictionary.EngRandomWordOfDictionary();
            string FileName = WordDictionary.RandomWord;
            if (MainForm.NumberOfPictures == 1)
            {
                Image img = Image.FromFile(@"Pictures\Animals\" + FileName + ".jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = img;
            }

            else if (MainForm.NumberOfPictures == 2)
            {
                Image img = Image.FromFile(@"Pictures\Hobbies\" + FileName + ".jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = img;
            }
            Start.Text = "Далее";

            //Очистка лейбла и текстбокса
            textBox1.Text = "";
            label1.Text = "";
            
        }

        private int MistakeCounter(string UserWord, string Pattern)
        {
            int result = 0;

            for (int i = 0; i < UserWord.Length; i++)
                if (UserWord[i] != Pattern[i])
                    result++;

            return result;
        }

        private void Answer_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (textBox1.TextLength > 0)
                {
                    string UserWord = textBox1.Text;
                    string OriginalWord = WordDictionary.RandomWord;

                    if (UserWord == OriginalWord)
                    {
                        wordStatisctics.CheckWordFromForm1(OriginalWord);
                        WordDictionary.DictForCheck[OriginalWord] = true;
                        label1.Text = "Right!";
                        label1.ForeColor = Color.Green;
                        label1.Refresh();

                        if (WordDictionary.EngRusWord)
                        {
                            WordDictionary.SizeOfEngUnusedWords--;
                            if (WordDictionary.SizeOfEngUnusedWords > 0)
                                WordDictionary.EngUnusedWords.Remove(OriginalWord);
                            else
                                MessageBox.Show("Все английские слова изучены!");
                        }
                        else
                        {
                            WordDictionary.SizeOfRusUnusedWords--;
                            if (WordDictionary.SizeOfRusUnusedWords > 1)
                                WordDictionary.RusUnusedWords.Remove(OriginalWord);
                            else
                                MessageBox.Show("Все русские слова изучены!");
                        }
                    }
                    else if (UserWord.Length == OriginalWord.Length)
                    {
                        if (MistakeCounter(UserWord, OriginalWord) == 1)
                        {
                            label1.Text = "So close ;) Try again.";
                            label1.ForeColor = Color.Blue;
                        }
                    }
                    else if (Math.Abs(UserWord.Length - OriginalWord.Length) == 1)
                    {
                        if (UserWord.Substring(1) == OriginalWord ||
                            UserWord.Substring(0, Math.Min(OriginalWord.Length, UserWord.Length)) == OriginalWord.Substring(0, OriginalWord.Length - 1))
                        {
                            label1.Text = "So close ;) Try again.";
                            label1.ForeColor = Color.Blue;
                        }
                        else
                        {
                            label1.Text = "Wrong! Try another word.";
                            label1.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        label1.Text = "Wrong! Try another word.";
                        label1.ForeColor = Color.Red;
                    }
                }
                else
                {
                    label1.Text = "Введите слово";
                    label1.ForeColor = Color.Black;
                }
            }
            else if (pictureBox1.Image == null)
            {
                label1.Text = "Нажмите кнопку 'Начать'";
                label1.ForeColor = Color.Black;
            }
        }

        private void Images_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                WordDictionary.Dict.Clear();
                WordDictionary.DictForCheck.Clear();
                textBox1.Clear();
                wordStatisctics.ClearCheckedListBox();
                Start.Text = "Начать";
                Hide();
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
            }
        }

        private void ShowWordStatics_Click(object sender, EventArgs e)
        {
            wordStatisctics.Show();
        }

        private void Images_Load(object sender, EventArgs e)
        {
            wordStatisctics.AddItemsToCheckedListBox();
        }
    }
}
