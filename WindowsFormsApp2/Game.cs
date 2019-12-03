using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Game : Form
    {
        private readonly Random random;
        private int scoreRight = 0;
        private int scoreWrong = 0;

        private string gameWord;

        private string FileName;

        private int time; // переменная, используемая для того, чтобы задать время

        private readonly WordStatictics wordStatistics;

        public Game()
        {
            InitializeComponent();
            wordStatistics = new WordStatictics();
            random = new Random();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void AddTextToRichTextBox()
        {
            gameWord = WordDictionary.GetEngUnusedRandomWordOfDictionary();
            richTextBox1.AppendText("Введите слово полностью: ");
            richTextBox1.AppendText(new string(GetBrokenWord()));

            //for (int i = 0; i < BrokenWord.Length; i++)
            //{
            //    richTextBox1.AppendText(BrokenWord[i].ToString());
            //}
        }

        private char[] GetBrokenWord()
        {
            char[] BrokenWord = gameWord.ToCharArray();

            if (BrokenWord.Length <= 4)
            {
                int randomIndex = random.Next(0, BrokenWord.Length - 1);
                BrokenWord[randomIndex] = '*';            
            }
            else
            {
                for (int i = 0; i < BrokenWord.Length; i++)
                {
                    if (i % 3 == 0)
                    {
                        BrokenWord[i] = '*';
                    }
                }
            }

            return BrokenWord;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Begin_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            StopTime.Visible = true;
            timeLabel.Visible = true;
            dataGridView1.Visible = true;
            label2.Visible = true;
            richTextBox1.Clear();
            textBox1.Clear();
            AddTextToRichTextBox();
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
            if (StopTime.Text == "Стоп")
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
                    string OriginalWord = gameWord;

                    if (UserWord == OriginalWord)
                    {
                        wordStatistics.CheckWordFromForm1(OriginalWord);
                        WordDictionary.DictForCheck[OriginalWord] = true;
                        label2.Text = "Right!";
                        scoreRight++;
                        dataGridView1[0, 0].Value = scoreRight;
                        label2.ForeColor = Color.Green;
                        label2.Refresh();
                        var testList = WordDictionary.EngUnusedWords;
                        if (WordDictionary.EngRusWord)
                        {
                            if (WordDictionary.EngUnusedWords.Count > 0)
                            {
                                WordDictionary.EngUnusedWords.Remove(UserWord);
                                if (WordDictionary.EngUnusedWords.Count == 0)
                                {
                                    FinishGame();
                                }
                                else
                                {
                                    Begin_Click(sender, e);
                                }
                            }
                        }
                        else
                        {
                            if (WordDictionary.RusUnusedWords.Count > 0)
                            {
                                WordDictionary.RusUnusedWords.Remove(UserWord);
                                if (WordDictionary.RusUnusedWords.Count == 0)
                                {
                                    MessageBox.Show("Все русские слова изучены!", "Позравляем!");
                                }
                            }
                        }
                    }
                    else if (UserWord.Length == OriginalWord.Length)
                    {
                        if (MistakeCounter(UserWord, OriginalWord) == 1)
                        {
                            label2.Text = "So close ;) Try again.";
                            scoreWrong++;
                            dataGridView1[1, 0].Value = scoreWrong;
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
                            dataGridView1[1, 0].Value = scoreWrong;
                            label2.ForeColor = Color.Blue;
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

        private void FinishGame()
        {
            this.Game_Load(new object(), new EventArgs());
            MessageBox.Show("Все английские слова изучены!", "Позравляем!");
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                WordDictionary.DictionaryOfWord.Clear();
                WordDictionary.DictForCheck.Clear();
                gameWord = null;
                FileName = null;
                //timer1.Enabled = Enabled;
                //timer1.Stop();
                timer1 = null;
                time = 0;
                richTextBox1.Clear();
                textBox1.Clear();
                label2.Text = "";
                wordStatistics.ClearCheckedListBox();
                Begin.Text = "Начать";
                this.Dispose();
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            WordDictionary.SetEngUnusedList();
            wordStatistics.AddItemsToCheckedListBox();
            scoreRight = 0;
            scoreWrong = 0;
            StopTime.Enabled = false;
            richTextBox1.Text = "";
            label2.Text = "";
            label2.Visible = false;
            timer1.Stop();
            time = 0;
            timeLabel.Text = "Время: ";
            textBox1.Visible = false;
            StopTime.Visible = false;
            timeLabel.Visible = false;
            dataGridView1.Visible = false;
            StopTime.Enabled = false;
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

                else if (MainForm.NumberOfPictures == 2)
                {
                    FileName = WordDictionary.RandomWord;
                    Image img = Image.FromFile(@"Pictures\Hobbies\" + FileName + ".jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = img;
                }
            }
            catch (FileNotFoundException)
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
