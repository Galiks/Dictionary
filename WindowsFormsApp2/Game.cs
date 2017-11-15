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
    public partial class Game : Form
    {

        WordsStaticCheck wordsSC = new WordsStaticCheck();

        private int time; // переменная, используемая для того, чтобы задать время

        private WordStatictics WS = new WordStatictics();

        private MainForm MF = new MainForm();

        private string RandomWordInRichTextBox;

        public Game()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddText()
        {
            Dictionary.EngRandomWordOfDictionary();
            RandomWordInRichTextBox = Dictionary.RandomWord;
            richTextBox1.AppendText("Введите слово полностью: ");
            char[] BrokenWord = new char[RandomWordInRichTextBox.Length];//массив для букв слова
            for ( int i = 0; i < BrokenWord.Length; i++)
            {
                BrokenWord[i] = RandomWordInRichTextBox[i];
            }

            for (int i = 0; i < BrokenWord.Length; i++)
            {
                if (BrokenWord.Length <= 4)
                {
                    if (i == 1)
                    {
                        BrokenWord[i] = '*';
                    }
                }
                if(BrokenWord.Length > 4)
                {
                    if( i % 3 == 0)
                    {
                        BrokenWord[i] = '*';
                    }
                }
            }

            for (int i = 0; i < BrokenWord.Length; i++)
            {
                richTextBox1.AppendText(BrokenWord[i].ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Begin_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox1.Clear();
            AddText();
            Begin.Text = "Далее";
            label2.Text = "";
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            StopTime.Enabled = true;
            time = 0;
            timeLabel.Text = "Время: " + time + " seconds";
            if(StopTime.Text == "Стоп")
                timer1.Start();
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
            if (richTextBox1.TextLength > 0)
            {
                if (textBox1.TextLength > 0)
                {
                    string UserWord = textBox1.Text;
                    string OriginalWord = Dictionary.RandomWord;

                    if (UserWord == OriginalWord)
                    {
                        WS.CheckWordFromForm1(OriginalWord);
                        Dictionary.DictForCheck[OriginalWord] = true;
                        label1.Text = "Right!";
                        label1.ForeColor = Color.Green;
                        label1.Refresh();

                        if (Dictionary.EngRusWord)
                        {
                            Dictionary.SizeOfEngUnUsedWords--;
                            if (Dictionary.SizeOfEngUnUsedWords > 0)
                                Dictionary.EngUnUsedWords.Remove(OriginalWord);
                            else
                                MessageBox.Show("Все английские слова изучены!","Позравляем!");
                        }
                        else
                        {
                            Dictionary.SizeOfRusUnUsedWords--;
                            if (Dictionary.SizeOfRusUnUsedWords > 1)
                                Dictionary.RusUnUsedWords.Remove(OriginalWord);
                            else
                                MessageBox.Show("Все русские слова изучены!","Позравляем!");
                        }
                    }
                    else if (UserWord.Length == OriginalWord.Length)
                    {
                        if (MistakeCounter(UserWord, OriginalWord) == 1)
                        {
                            label2.Text = "So close ;) Try again.";
                            label2.ForeColor = Color.Blue;
                        }
                    }
                    else if (Math.Abs(UserWord.Length - OriginalWord.Length) == 1)
                    {
                        if (UserWord.Substring(1) == OriginalWord ||
                            UserWord.Substring(0, Math.Min(OriginalWord.Length, UserWord.Length)) == OriginalWord.Substring(0, OriginalWord.Length - 1))
                        {
                            label2.Text = "So close ;) Try again.";
                            label2.ForeColor = Color.Blue;
                        }
                        else
                        {
                            label2.Text = "Wrong! Try another word.";
                            label2.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        label2.Text = "Wrong! Try another word.";
                        label2.ForeColor = Color.Red;
                    }
                }
                else
                {
                    label2.Text = "Введите слово";
                    label2.ForeColor = Color.Black;
                }
            }
            else if (richTextBox1.TextLength == 0)
            {
                label2.Text = "Нажмите кнопку 'Начать'";
                label2.ForeColor = Color.Black;
            }
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Dictionary.Dict.Clear();
                Dictionary.DictForCheck.Clear();
                timer1.Enabled = Enabled;
                timer1.Stop();
                time = 0;
                richTextBox1.Clear();
                textBox1.Clear();
                label2.Text = "";
                WS.ClearCheckedListBox();
                Begin.Text = "Начать";
                Hide();
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            WS.AddItemsToCheckedListBox();
            StopTime.Enabled = false;
            label2.Text = "";
            timer1.Stop();
            time = 0;
            timeLabel.Text = "Время: ";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //1 - Animals, 2 - Hobbies
        private void Hint_Click(object sender, EventArgs e) //import Tkinter, m = Tkinter.Tk()
        {
            try
            {
                if (MainForm.NumberOfPictures == 1)
                {
                    string FileName = Dictionary.RandomWord;
                    Image img = Image.FromFile(@"Pictures\Animals\" + FileName + ".jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = img;
                }

                else if(MainForm.NumberOfPictures == 2)
                {
                    string FileName = Dictionary.RandomWord;
                    Image img = Image.FromFile(@"Pictures\Hobbies\" + FileName + ".jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = img;
                }
            }
            catch(FileNotFoundException)
            {
                label2.Text = "Нажмите кнопку 'Начать'";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time == 10)
            {
                timer1.Stop();
                MessageBox.Show("Время вышло!", "Таймер");
                
                Begin.PerformClick();
            }
            else if (time < 10)
            {
                // Display the new time left
                // by updating the Time Left label.
                time = time + 1;
                timeLabel.Text = "Время: " + time + " seconds";
            }
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void StopTime_Click(object sender, EventArgs e)
        {
            if (StopTime.Text == "Стоп")
            {
                timer1.Stop();
                Answer.Enabled = false;
                StopTime.Text = "Продолжить";
            }
            else if (StopTime.Text == "Продолжить")
            {
                timer1.Start();
                Answer.Enabled = true;
                StopTime.Text = "Стоп";
            }
        }

        private void ShowWordStatics_Click(object sender, EventArgs e)
        {
            WS.Show();
        }
    }
}
