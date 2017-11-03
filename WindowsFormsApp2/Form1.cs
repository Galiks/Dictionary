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

        private string RandomWordInRichTextBox;

        private WordStatictics WS = new WordStatictics();

        public Form1()
        {
            InitializeComponent();
        }

        private void AddText()
        {
            RandomWordInRichTextBox = Dictionary.RandomWordOfDictionary();
            richTextBox1.Text = "Введите перевод слова: " + RandomWordInRichTextBox;
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
                        MessageBox.Show("That's good, keep it up!");

                    }
                    else if (UserWord.Length == OriginalWord.Length)
                    {
                        if (MistakeCounter(UserWord, OriginalWord) == 1)
                            MessageBox.Show("So close;) Try again.");
                    }
                    else if (Math.Abs(UserWord.Length - OriginalWord.Length) == 1)
                    {
                        if (UserWord.Substring(1) == OriginalWord ||
                            UserWord.Substring(0, Math.Min(OriginalWord.Length, UserWord.Length)) == OriginalWord.Substring(0, OriginalWord.Length - 1))
                            MessageBox.Show("So close;) Try again.");
                        else
                            MessageBox.Show("Wrong! Try another word");
                    }
                    else
                        MessageBox.Show("Wrong! Try another word");
                }
                else MessageBox.Show("Введите перевод слова");
            }
            else if (richTextBox1.TextLength == 0)
                MessageBox.Show("Нажмите кнопку 'Начать'");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowWordStatictics_Click(object sender, EventArgs e)
        {
            WS.Show();
        }
    }
}
