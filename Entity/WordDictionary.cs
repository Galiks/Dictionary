using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsFormsApp2
{
    public class WordDictionary
    {
        public Dictionary<string, string> Dict = new Dictionary<string, string>();

        public List<string> EngUnUsedWords = new List<string>(); //Список неиспользованных английских слов
        public List<string> RusUnUsedWords = new List<string>(); //Список неиспользованных русских слов

        public Dictionary<string, bool> DictForCheck = new Dictionary<string, bool>();// вместо сериализации

        public int SizeOfEngUnUsedWords = 0;
        public int SizeOfRusUnUsedWords = 0;

        public bool EngRusWord = true;

        public string RandomWord; //рандомное слово, которое будет выведено в методе RandomWordInDictionary

        //public static List<string> GoneWords = new List<string>();

        public int Size //рамерность словаря Dict
        {
            get { return Dict.Count; }
        }

        public void AddToDict(string name) // добавление в словарь
        {
            using (StreamReader file = new StreamReader(name))
            {
                while (file.Peek() > -1)
                {
                    string[] line = file.ReadLine().Split(',');
                    for (int i = 0; i < line.Length - 1; i++)
                    {
                        if (!Dict.Contains(new KeyValuePair<string, string>(line[i], line[i + 1])))
                        {
                            EngUnUsedWords.Add(line[i]);
                            RusUnUsedWords.Add(line[i + 1]);
                            Dict.Add(line[i], line[i + 1]);
                        }
                        if (!DictForCheck.Contains(new KeyValuePair<string, bool>(line[i], false)))
                        {
                            DictForCheck.Add(line[i], false);
                        }
                    }
                }
                SizeOfEngUnUsedWords = DictForCheck.Count;
                SizeOfRusUnUsedWords = DictForCheck.Count;
            }
        }

        public void Reverse(string name) // переворот словаря, сделанный по заказу Макса
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

        public string RusRandomWordOfDictionary() // рандомный выбор РУССКОГО слова из словаря Dict
        {
            Random random = new Random();
            int cont = random.Next(0, SizeOfRusUnUsedWords);
            RandomWord = RusUnUsedWords[cont];
            EngRusWord = false;

            return Dict[RandomWord];
        }

        public string EngRandomWordOfDictionary() // рандомный выбор АНГЛИЙСКОГО слова из словаря Dict
        {
            Random random = new Random();
            int cont = random.Next(0, SizeOfEngUnUsedWords);
            RandomWord = EngUnUsedWords[cont];
            EngRusWord = true;

            return Dict[RandomWord];
        }
    }
}
