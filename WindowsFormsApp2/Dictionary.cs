using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp2
{
    public static class Dictionary
    {
        public static Dictionary<string, string> Dict = new Dictionary<string, string>();

        public static string RandomWord; //рандомное слово, которое будет выведено в методе RandomWordInDictionary
        
        static int Size //рамерность словаря Dict
        {
            get { return Dict.Count; }
        }

        public static void AddToDict(string name) // добавление в словарь
        {
            using (StreamReader file = new StreamReader(name))
            {
                while (file.Peek() > -1)
                {
                    string[] line = file.ReadLine().Split(',');
                    for (int i = 0; i < line.Length - 1; i++)
                    {
                        if (!Dict.Contains(new KeyValuePair<string, string>(line[i], line[i + 1])))
                            Dict.Add(line[i], line[i + 1]);
                    }
                }
            }
        }

        public static void Reverse(string name) // переворот словаря, сделанный по заказу Макса
        {
            using (StreamWriter fileWrite = new StreamWriter("AnimalReverse.txt"))
            {
                using (StreamReader fileRead = new StreamReader(name))
                {
                    while (fileRead.Peek() > -1)
                    {
                        string[] line = fileRead.ReadLine().Split(',');
                        for (int i = 0; i < line.Length - 1; i++)
                        {
                            fileWrite.WriteLine(line[i + 1] + "," + line[i]);
                        }
                    }
                }
            }
        }

        public static string RusRandomWordOfDictionary() // рандомный выбор слова из словаря Dict
        {
            Random random = new Random();
            int cont = random.Next(0, Size);
            List<string> values = Dict.Values.ToList();
            List<string> keys = Dict.Keys.ToList();
            RandomWord = keys[cont];
            string list = values[cont];
            return list;
        }

        public static string EngRandomWordOfDictionary() // рандомный выбор слова из словаря Dict
        {
            Random random = new Random();
            int cont = random.Next(0, Size);
            List<string> values = Dict.Values.ToList();
            List<string> keys = Dict.Keys.ToList();
            RandomWord = values[cont];
            string list = keys[cont];
            return list;
        }
    }
}
