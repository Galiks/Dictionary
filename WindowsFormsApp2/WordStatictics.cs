using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    [Serializable]
    public partial class WordStatictics : Form
    {
        //BinaryFormatter BinSer = new BinaryFormatter();

        //private byte[] serializedStream;

        private readonly NameOfSave nameOfSafe;
        private readonly WordDictionary wordDictionary;

        public WordDictionary WordDictionary => wordDictionary;

        public WordStatictics()
        {
            InitializeComponent();
            nameOfSafe = new NameOfSave();
            wordDictionary = new WordDictionary();
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void CheckWordFromForm1(string name)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.Items[i].ToString() == name)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }

        public void AddItemsToCheckedListBox()
        {
            checkedListBox1.Items.Clear();
            foreach (var elem in WordDictionary.Dict)
            {
                checkedListBox1.Items.Add(elem.Key);
            }
            checkedListBox1.Show();
        }

        public void ClearCheckedListBox()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }



        private void TestButton_Click(object sender, EventArgs e) //Save
        {
            nameOfSafe.Show();
        }

        private void WordStatictics_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void Button1_Click(object sender, EventArgs e) // Load
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamReader fileRead = new StreamReader(openFileDialog1.FileName))
                {
                    while (fileRead.Peek() > -1)
                    {
                        string[] line = fileRead.ReadLine().Split(':');
                        for (int i = 0; i < line.Length - 1; i++)
                        {
                            checkedListBox2.Items.Add(line[i]);
                            for (int j = 0; j < checkedListBox2.Items.Count; j++)
                            {
                                if (checkedListBox2.Items[j].ToString() == line[i])
                                {
                                    if (line[i + 1] == "True")
                                        checkedListBox2.SetItemCheckState(j, CheckState.Checked);
                                }
                            }
                        }
                    }

                    fileRead.Close();
                }
            }
            if (checkedListBox2.Items.Count != 0)
                MessageBox.Show("Статистика загружена.", "Сообщение");
            else MessageBox.Show("Статистика не загружена.", "Ошибка");
        }

        private void WordStatictics_Load(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void CheckedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

//////////////
//public static byte[] ObjectToByteArray(Object obj)
//{
//    BinaryFormatter bf = new BinaryFormatter();
//    using (var ms = new MemoryStream())
//    {
//        bf.Serialize(ms, obj);
//        return ms.ToArray();
//    }
//}

//public static Object ByteArrayToObject(byte[] arrBytes)
//{
//    using (var memStream = new MemoryStream())
//    {
//        var binForm = new BinaryFormatter();
//        memStream.Write(arrBytes, 0, arrBytes.Length);
//        memStream.Seek(0, SeekOrigin.Begin);
//        var obj = binForm.Deserialize(memStream);
//        return obj.ToString();
//    }
//}


////Додумать сериализацию
//void SerializerCheckListBox()
//{
//    //BinaryFormatter serializer = new BinaryFormatter(); //создаем экземпляр твоего сериализатора
//    var CheckListBoxItemsInArray = new string[checkedListBox1.Items.Count]; //создаем массив размером с количество элементов в твоем листбоксе
//    checkedListBox1.Items.CopyTo(CheckListBoxItemsInArray, 0); //копируем элементы листбокса в массив (ибо сам ObjectCollection листбокса не сериализуем)
//    serializedStream = ObjectToByteArray(CheckListBoxItemsInArray); //используя твой сериалайзер конвертим элементы из листбокса в массив байт

//    using (FileStream fs = new FileStream("save.dat", FileMode.OpenOrCreate))
//    {
//        BinSer.Serialize(fs, serializedStream);
//    }
//    MessageBox.Show("You are saving your result");
//}

//void DeserializerCheckListBox()
//{
//    using (FileStream fs = new FileStream("save.dat", FileMode.OpenOrCreate))
//    {
//        List<string> MyList = (List<string>)BinSer.Deserialize(fs);
//        foreach (var elem in MyList)
//        {
//            richTextBox1.AppendText(elem + "\n");
//        }
//    }
//}
