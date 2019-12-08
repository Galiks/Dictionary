using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Results : Form
    {
        private readonly int countOfQuestions;
        private readonly List<string> rightWords;
        private readonly List<string> wrongWords;
        public Results()
        {
            InitializeComponent();
        }

        public Results(List<string> rightWords, List<string> wrongWords, int countOfQuestions)
        {
            InitializeComponent();
            this.countOfQuestions = countOfQuestions;
            this.rightWords = rightWords;
            this.wrongWords = wrongWords;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Results_Load(object sender, EventArgs e)
        {
            countOfRightWords.Text = rightWords.Count.ToString();
            countOfWrongWords.Text = wrongWords.Count.ToString();

            AddRows();

            for (int i = 0; i < rightWords.Count; i++)
            {
                dataGridView1[0, i].Value = rightWords[i];
            }

            for (int i = 0; i < wrongWords.Count; i++)
            {
                dataGridView1[1, i].Value = wrongWords[i];
            }

            RichTextBox1_TextChanged(sender, e);
        }

        private void AddRows()
        {
            int countOfRows = rightWords.Count >= wrongWords.Count ? rightWords.Count : wrongWords.Count;

            for (int i = 0; i < countOfRows - 1; i++)
            {
                dataGridView1.Rows.Add();
            }
        }

        private int GetAssessment()
        {
            return rightWords.Count - (wrongWords.Count / (countOfQuestions - 1));
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
            richTextBox1.Text = "Ваша оценка за тест: " + GetAssessment();
        }
    }
}
