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
    public partial class MainForm : Form
    {

        Form1 f1 = new Form1();

        Form OutDict = new OutputDictcs();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Text_Click(object sender, EventArgs e)
        {
            if (Dictionary.Dict.Count != 0)
                f1.Show();
            else MessageBox.Show("Выберите словарь!");
        }

        private void AnimalsDict_Click(object sender, EventArgs e)
        {
            Dictionary.Dict.Clear();
            string ChooseDict = "Animals.txt";
            Dictionary.AddToDict(ChooseDict);
            MessageBox.Show("В словарь добавлены слова на тему: животные");
        }

        private void Hobby_Click(object sender, EventArgs e)
        {
            Dictionary.Dict.Clear();
            string ChooseDict = "Hobby.txt";
            Dictionary.AddToDict(ChooseDict);
            MessageBox.Show("В словарь добавлены слова на тему: хобби");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OutDict.Show();
        }
    }
}
