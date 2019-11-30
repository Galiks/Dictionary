using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsFormsApp2
{
    public static class WordDictionary
    {
        public static Dictionary<string, string> Dict = new Dictionary<string, string>();

        public static List<string> EngUnusedWords = new List<string>(); //Список неиспользованных английских слов
        public static List<string> RusUnusedWords = new List<string>(); //Список неиспользованных русских слов

        public static Dictionary<string, bool> DictForCheck = new Dictionary<string, bool>();// вместо сериализации

        public static int SizeOfEngUnusedWords = 0;
        public static int SizeOfRusUnusedWords = 0;

        public static bool EngRusWord = true;

        public static string RandomWord; //рандомное слово, которое будет выведено в методе RandomWordInDictionary

        //public static List<string> GoneWords = new List<string>();

        public static int Size //рамерность словаря Dict
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
                        {
                            EngUnusedWords.Add(line[i]);
                            RusUnusedWords.Add(line[i + 1]);
                            Dict.Add(line[i], line[i + 1]);
                        }
                        if (!DictForCheck.Contains(new KeyValuePair<string, bool>(line[i], false)))
                        {
                            DictForCheck.Add(line[i], false);
                        }
                    }
                }
                SizeOfEngUnusedWords = DictForCheck.Count;
                SizeOfRusUnusedWords = DictForCheck.Count;
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

        public static string RusRandomWordOfDictionary() // рандомный выбор РУССКОГО слова из словаря Dict
        {
            Random random = new Random();
            int cont = random.Next(0, SizeOfRusUnusedWords);
            RandomWord = EngUnusedWords[cont];
            EngRusWord = false;

            return Dict[RandomWord];
        }

        public static string EngRandomWordOfDictionary() // рандомный выбор АНГЛИЙСКОГО слова из словаря Dict
        {
            Random random = new Random();
            int cont = random.Next(0, SizeOfEngUnusedWords);
            RandomWord = EngUnusedWords[cont];
            EngRusWord = true;

            return RandomWord;
        }
    }
}
