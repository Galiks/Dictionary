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



        private WordStatictics WS = new WordStatictics();

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
            RandomWordInRichTextBox = Dictionary.EngRandomWordOfDictionary();
            richTextBox1.AppendText("Введите слово полностью: ");
            char[] BrokenWord = new char[RandomWordInRichTextBox.Length];//массив для букв слова
            for ( int i = 0; i < BrokenWord.Length; i++)
            {
                BrokenWord[i] = RandomWordInRichTextBox[i];
            }

            for (int i = 0; i < BrokenWord.Length; i++)
            {
                if (BrokenWord.Length == 3)
                {
                    if (i == 2)
                    {
                        BrokenWord[i] = '*';
                    }
                }
                if(BrokenWord.Length > 3)
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
            label1.Text = "";
            AddText();
            Begin.Text = "Далее";
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
                    string OriginalWord = RandomWordInRichTextBox;

                    if (UserWord == OriginalWord)
                    {
                        //MessageBox.Show("That's good, keep it up!");
                        WS.CheckWordFromForm1(OriginalWord);
                        label2.Text = "Right!";
                        label2.ForeColor = Color.Green;
                        label2.Refresh();
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

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Dictionary.Dict.Clear();
                richTextBox1.Clear();
                textBox1.Clear();
                WS.ClearCheckedListBox();
                Begin.Text = "Начать";
                Hide();
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Hint_Click(object sender, EventArgs e) //import Tkinter, m = Tkinter.Tk()
        {
            //RandomWordInRichTextBox
            string FileName = "fox";
            Image img = Image.FromFile(@"Pictures\" + FileName + ".jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = img;
        }
    }
}
