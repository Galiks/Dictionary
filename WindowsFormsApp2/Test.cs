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
    public partial class Test : Form
    {
        private readonly int maxQuestions;
        public Test()
        {
            InitializeComponent();
            maxQuestions = WordDictionary.Size;
            label1.Text = "0";
            label2.Text = " / ";
            label3.Text = maxQuestions.ToString();
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }
    }
}
