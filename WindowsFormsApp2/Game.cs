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

        int scoreRight = 0;
        int scoreWrong = 0;

        string FileName;
        //private readonly WordsStaticCheck wordsStaticCheck;

        private int time; // переменная, используемая для того, чтобы задать время

        private readonly WordStatictics wordStatistics;

        //private readonly MainForm mainForm;

        private string RandomWordInRichTextBox;

        public Game()
        {
            InitializeComponent();
            //wordsStaticCheck = new WordsStaticCheck();
            wordStatistics = new WordStatictics();
            //mainForm = new MainForm();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void AddText()
        {
            WordDictionary.EngRandomWordOfDictionary();
            RandomWordInRichTextBox = WordDictionary.RandomWord;
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

        private void TextBox1_TextChanged(object sender, EventArgs e)
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
                    string OriginalWord = WordDictionary.RandomWord;

                    if (UserWord == OriginalWord)
                    {
                        wordStatistics.CheckWordFromForm1(OriginalWord);
                        WordDictionary.DictForCheck[OriginalWord] = true;
                        label2.Text = "Right!";
                        scoreRight++;
                        dataGridView1[0,0].Value = scoreRight;
                        label2.ForeColor = Color.Green;
                        label2.Refresh();
                        Begin_Click(sender, e);

                        if (WordDictionary.EngRusWord)
                        {
                            WordDictionary.SizeOfEngUnusedWords--;
                            if (WordDictionary.SizeOfEngUnusedWords > 0)
                                WordDictionary.EngUnusedWords.Remove(OriginalWord);
                            else
                                MessageBox.Show("Все английские слова изучены!","Позравляем!");
                        }
                        else
                        {
                            WordDictionary.SizeOfRusUnusedWords--;
                            if (WordDictionary.SizeOfRusUnusedWords > 1)
                                WordDictionary.RusUnusedWords.Remove(OriginalWord);
                            else
                                MessageBox.Show("Все русские слова изучены!","Позравляем!");
                        }
                    }
                    else if (UserWord.Length == OriginalWord.Length)
                    {
                        if (MistakeCounter(UserWord, OriginalWord) == 1)
                        {
                            label2.Text = "So close ;) Try again.";
                            scoreWrong++;
                            dataGridView1[1,0].Value = scoreWrong;
                            label2.ForeColor = Color.Blue;
                        }
                    }
                    else if (Math.Abs(UserWord.Length - OriginalWord.Length) == 1)
                    {
                        if (UserWord.Substring(1) == OriginalWord ||
                            UserWord.Substring(0, Math.Min(OriginalWord.Length, UserWord.Length)) == OriginalWord.Substring(0, OriginalWord.Length - 1))
                        {
                            label2.Text = "So close ;) Try again.";
                            scoreWrong++;
                            dataGridView1[1,0].Value = scoreWrong;
                            label2.ForeColor = Color.Blue;
                        }
                        else
                        {
                            label2.Text = "Wrong! Try another word.";
                            scoreWrong++;
                            dataGridView1[1,0].Value = scoreWrong;
                            label2.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        label2.Text = "Wrong! Try another word.";
                        scoreWrong++;
                        dataGridView1[1, 0].Value = scoreWrong;
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
                WordDictionary.Dict.Clear();
                WordDictionary.DictForCheck.Clear();
                RandomWordInRichTextBox = null;
                FileName = null;
                timer1.Enabled = Enabled;
                timer1.Stop();
                timer1 = null;
                time = 0;
                richTextBox1.Clear();
                textBox1.Clear();
                label2.Text = "";
                wordStatistics.ClearCheckedListBox();
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
            wordStatistics.AddItemsToCheckedListBox();
            StopTime.Enabled = false;
            label2.Text = "";
            timer1.Stop();
            time = 0;
            timeLabel.Text = "Время: ";
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        //1 - Animals, 2 - Hobbies
        private void Hint_Click(object sender, EventArgs e) //import Tkinter, m = Tkinter.Tk()
        {
            try
            {
                if (MainForm.NumberOfPictures == 1)
                {
                    string FileName = WordDictionary.RandomWord;
                    Image img = Image.FromFile(@"Pictures\Animals\" + FileName + ".jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = img;
                }

                else if(MainForm.NumberOfPictures == 2)
                {
                    FileName = WordDictionary.RandomWord;
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (time == 120)
            {
                timer1.Stop();
                MessageBox.Show("Время вышло!", "Таймер");
                
                Begin.PerformClick();
            }
            else if (time < 120)
            {
                // Display the new time left
                // by updating the Time Left label.
                time += 1;
                timeLabel.Text = "Время: " + time + " seconds / 120 seconds";
            }
        }

        private void TimeLabel_Click(object sender, EventArgs e)
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
            wordStatistics.Show();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Game_DockChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              
        }
    }
}
