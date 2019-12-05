using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Text : Form
    {

        //private readonly WordsStaticCheck wordsStatisticsCheck;

        //private string RandomWordInRichTextBox;

        private readonly WordStatictics wordStatistics;

        public Text()
        {
            InitializeComponent();
            //wordsStatisticsCheck = new WordsStaticCheck();
            wordStatistics = new WordStatictics();
        }

        private void AddText()
        {
            richTextBox1.Text = "Введите перевод слова: " + WordDictionary.GetRusUnusedRandomWordOfDictionary();
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
                        label1.Text = "Right!";
                        label1.ForeColor = Color.Green;
                        label1.Refresh();

                        if (WordDictionary.EngRusWord)
                        {
                            if (WordDictionary.EngUnusedWords.Count > 0)
                            {
                                WordDictionary.EngUnusedWords.Remove(UserWord);
                                if (WordDictionary.EngUnusedWords.Count == 0)
                                {
                                    FinishGame();
                                }
                            }
                        }
                        else
                        {
                            if (WordDictionary.RusUnusedWords.Count > 0)
                            {
                                WordDictionary.RusUnusedWords.Remove(UserWord);
                                if (WordDictionary.EngUnusedWords.Count == 0)
                                {
                                    FinishGame(isEngWords: false);
                                }
                            }
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
                    label1.Text = "Введите перевод слова";
                    label1.ForeColor = Color.Black;
                }
            }
            else if (richTextBox1.TextLength == 0)
            {
                label1.Text = "Нажмите кнопку 'Начать'";
                label1.ForeColor = Color.Black;
            }
        }

        private void FinishGame(bool isEngWords = true)
        {
            this.Form1_Load(new object(), new EventArgs());
            if (isEngWords)
            {
                MessageBox.Show("Все английские слова изучены!", "Позравляем!");
            }
            else
            {
                MessageBox.Show("Все русские слова изучены!", "Позравляем!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wordStatistics.AddItemsToCheckedListBox();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            AddText();
            textBox1.Text = "";
            Start.Text = "Далее";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                WordDictionary.DictionaryOfWord.Clear();
                richTextBox1.Clear();
                textBox1.Clear();
                wordStatistics.ClearCheckedListBox();
                WordDictionary.DictForCheck.Clear();
                label1.Text = "";
                Start.Text = "Начать";
                Hide();
            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowWordStatictics_Click(object sender, EventArgs e)
        {
            wordStatistics.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
