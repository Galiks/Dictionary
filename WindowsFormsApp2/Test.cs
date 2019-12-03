using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Test : Form
    {
        private readonly int maxQuestions;
        private HashSet<string> words;
        private Random Random { get; set; }
        private string answer;
        public Test()
        {
            InitializeComponent();
            maxQuestions = WordDictionary.Size;
            label1.Text = "0";
            label2.Text = " / ";
            label3.Text = maxQuestions.ToString();
            words = new HashSet<string>();
            Random = new Random();
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            words.Clear();

            for (int i = 0; i < 5; i++)
            {
                string randomWord = WordDictionary.GetEngUnusedRandomWordOfDictionary();
                while (words.Contains(randomWord))
                {
                    randomWord = WordDictionary.GetEngUnusedRandomWordOfDictionary();
                }
                var radioButton = this.Controls.Find("radioButton" + (i + 1), true).FirstOrDefault() as RadioButton;
                radioButton.Text = randomWord;
                words.Add(randomWord);
            }


            int randomNumber = Random.Next(0, 5);

            answer = words.ToList()[randomNumber];

            richTextBox1.Text = "Выберите перевод слова: " + WordDictionary.DictionaryOfWord[answer];

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
                        if (radioButton.Text == answer)
                        {
                            MessageBox.Show("ПРАВИЛЬНО!");
                        }
                        else
                        {
                            MessageBox.Show("НЕПРАВИЛЬНО!");
                        }
                    }
                    finally
                    {
                        radioButton.Checked = false;
                    }
                }
            }
        }
    }
}
