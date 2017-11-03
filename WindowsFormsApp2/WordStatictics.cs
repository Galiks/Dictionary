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
    public partial class WordStatictics : Form
    {
        public WordStatictics()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void AddItemsToCheckedListBox()
        {
            checkedListBox1.Items.Clear();
            foreach (var elem in Dictionary.Dict)
            {
                checkedListBox1.Items.Add(elem.Key + " : " + elem.Value);
            }
            checkedListBox1.Show();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            AddItemsToCheckedListBox();
        }
    }
}
