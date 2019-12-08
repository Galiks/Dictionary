using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Test : Form
    {
        private const int countOfQuestions = 5;
        private readonly int maxQuestions;
        private readonly HashSet<string> words;
        private readonly Random random;
        private string rightAnswer;
        private int counter;
        private Results results;
        private readonly List<string> rightWords;
        private readonly List<string> wrongWords;
        public Test()
        {
            InitializeComponent();
            maxQuestions = WordDictionary.Size;
            label1.Text = counter.ToString();
            label2.Text = " / ";
            label3.Text = maxQuestions.ToString();
            words = new HashSet<string>();
            random = new Random();
            rightWords = new List<string>();
            wrongWords = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                var radioButton = this.Controls.Find("radioButton" + (i + 1), true).FirstOrDefault() as RadioButton;
                radioButton.Visible = false;
            }
        }

        private void Test_Load(object sender, EventArgs e)
        {
            counter = 0;
            WordDictionary.SetEngUnusedList();
            button1.Enabled = true;
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            words.Clear();

            rightAnswer = WordDictionary.GetEngUnusedRandomWordFromDictionary();

            richTextBox1.Text = "Выберите перевод слова: " + WordDictionary.DictionaryOfWords[rightAnswer];

            int countOfWordsInDictionary = WordDictionary.DictionaryOfWords.Count;

            if (countOfWordsInDictionary >= countOfQuestions)
            {
                SetQuestionsForTest();
            }
            else
            {
                SetQuestionsForMiniTest(countOfWordsInDictionary);
            }

            button1.Enabled = false;
        }

        private void SetQuestionsForMiniTest(int countOfWordsInDictionary)
        {
            for (int i = 0; i < countOfWordsInDictionary; i++)
            {
                string randomWord = WordDictionary.GetEngRandomWordFromDictionary();
                RadioButton randomRadioButton = this.Controls.Find("radioButton" + (i + 1), true).FirstOrDefault() as RadioButton;
                randomRadioButton.Visible = true;
                randomRadioButton.Text = randomWord;
                words.Add(randomWord);
            }

            AddAnswerToList(); if (!words.Contains(rightAnswer))
            {
                AddAnswerToList();
            }

            SetVisibleForUnusedRadioButtons(countOfWordsInDictionary);
        }

        private void AddAnswerToList()
        {
            int randomNumber = random.Next(0, words.Count);
            var radioButton = this.Controls.Find("radioButton" + (randomNumber + 1), true).FirstOrDefault() as RadioButton;
            radioButton.Text = rightAnswer;
            words.ToList()[randomNumber] = rightAnswer;
        }

        private void SetVisibleForUnusedRadioButtons(int countOfWordsInDictionary)
        {
            for (int i = countOfWordsInDictionary; i < 5; i++)
            {
                var radioButton = this.Controls.Find("radioButton" + (i + 1), true).FirstOrDefault() as RadioButton;
                radioButton.Visible = false;
            }
        }

        private void SetQuestionsForTest()
        {
            for (int i = 0; i < countOfQuestions; i++)
            {
                string randomWord = WordDictionary.GetEngRandomWordFromDictionary();
                while (words.Contains(randomWord))
                {
                    randomWord = WordDictionary.GetEngRandomWordFromDictionary();
                }
                var radioButton = this.Controls.Find("radioButton" + (i + 1), true).FirstOrDefault() as RadioButton;
                radioButton.Text = randomWord;
                radioButton.Visible = true;
                words.Add(randomWord);
            }

            if (!words.Contains(rightAnswer))
            {
                AddAnswerToList(); 
            }
        }

        private void Finish()
        {
            Test_Load(new object(), new EventArgs());
            results = new Results(rightWords, wrongWords, countOfQuestions);
            results.Show();
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                var radioButton = this.Controls.Find("radioButton" + (i + 1), true).FirstOrDefault() as RadioButton;
                if (radioButton.Checked)
                {
                    try
                    {
                        if (radioButton.Text == rightAnswer)
                        {
                            rightWords.Add(rightAnswer);
                        }
                        else
                        {
                            wrongWords.Add(rightAnswer);
                        }
                    }
                    finally
                    {
                        WordDictionary.EngUnusedWords.Remove(rightAnswer);

                        if (WordDictionary.EngUnusedWords.Count == 0)
                        {
                            Finish();
                        }

                        counter += 1;
                        label1.Text = counter.ToString();
                        radioButton.Checked = false;
                        Button1_Click(sender, e);
                    }
                }
            }
        }

        private void Test_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            results?.Dispose();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
