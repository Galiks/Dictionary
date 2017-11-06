using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp2
{
    [Serializable]
    public partial class WordStatictics : Form
    {
        BinaryFormatter BinSer = new BinaryFormatter();

        private byte[] serializedStream;

        public WordStatictics()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void CheckWordFromForm1(string name)
        {
            for (int i = 0; i < (checkedListBox1.Items.Count - 1); i++)
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
            foreach (var elem in Dictionary.Dict)
            {
                checkedListBox1.Items.Add(elem.Key);
            }
            checkedListBox1.Show();
        }

        public void ClearCheckedListBox()
        {
            for (int i = 0; i < (checkedListBox1.Items.Count - 1); i++)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }

 
        //Додумать сериализацию
        void SerializerCheckListBox()
        {
            BinaryFormatter serializer = new BinaryFormatter(); //создаем экземпляр твоего сериализатора
            var CheckListBoxItemsInArray = new string[checkedListBox1.Items.Count]; //создаем массив размером с количество элементов в твоем листбоксе
            checkedListBox1.Items.CopyTo(CheckListBoxItemsInArray, 0); //копируем элементы листбокса в массив (ибо сам ObjectCollection листбокса не сериализуем)
            serializedStream = ObjectToByteArray(CheckListBoxItemsInArray); //используя твой сериалайзер конвертим элементы из листбокса в массив байт
           
            using (FileStream fs = new FileStream("save.dat", FileMode.OpenOrCreate))
            {
                BinSer.Serialize(fs, serializedStream);
            }
            MessageBox.Show("You are saving your result");
        }

        //void DeserializerCheckListBox()
        //{
        //    using (FileStream fs = new FileStream("save.dat", FileMode.OpenOrCreate))
        //    {
        //        checkedListBox1.Items.Add((serializedStream)BinSer.Deserialize(fs));
        //        for (int j = 0; j < f2.goods2.Count; j++)
        //        {
        //            richTextBox2.AppendText("Название: " + goods[j].Name + "\tЦена: " + goods[j].Cost +
        //                "\tВозраст: " + goods[j].Age + "\tМатериал: " + goods[j].Manufacturer + "\n");
        //        }
        //        progressBar4.PerformStep();
        //    }
        //    checkedListBox1.Items.Add(ByteArrayToObject(serializedStream)); //десериализуем массив байт обратно в строкой массив, который добавляем в коллекцию элементов листбокса
        //    checkedListBox1.Show();
        //}

        private void TestButton_Click(object sender, EventArgs e)
        {
            SerializerCheckListBox();
        }

        private void WordStatictics_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serializedStream != null)
            {
                //DeserializerCheckListBox();
                MessageBox.Show("Your result have been load");
            }
            else MessageBox.Show("You haven't saves");
        }
    }
}
