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
    public partial class Form1 : Form
    {
        private readonly WordDictionary wordDictionary;

        //private readonly WordsStaticCheck wordsStatisticsCheck;

        //private string RandomWordInRichTextBox;

        private readonly WordStatictics wordStatistics;

        public WordDictionary WordDictionary => wordDictionary;

        public Form1()
        {
            InitializeComponent();
            wordDictionary = new WordDictionary();
            //wordsStatisticsCheck = new WordsStaticCheck();
            wordStatistics = new WordStatictics();
        }

        private void AddText()
        {
            richTextBox1.Text = "Введите перевод слова: " + WordDictionary.EngRandomWordOfDictionary();
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
                            WordDictionary.SizeOfEngUnUsedWords--;
                            if (WordDictionary.SizeOfEngUnUsedWords > 0)
                                WordDictionary.EngUnUsedWords.Remove(OriginalWord);
                            else
                                MessageBox.Show("Все английские слова изучены!");
                        }
                        else
                        {
                            WordDictionary.SizeOfRusUnUsedWords--;
                            if (WordDictionary.SizeOfRusUnUsedWords > 1)
                                WordDictionary.RusUnUsedWords.Remove(OriginalWord);
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
                WordDictionary.Dict.Clear();
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
