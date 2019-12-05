using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsFormsApp2
{
    public static class WordDictionary
    {
        private static readonly Random random;

        /// <summary>
        /// Основной контейнер, который содержит все слова
        /// </summary>
        public static Dictionary<string, string> DictionaryOfWord;

        /// <summary>
        /// Список неиспользованных английских слов
        /// </summary>
        public static List<string> EngUnusedWords;

        /// <summary>
        /// Список неиспользованных русских слов
        /// </summary>
        public static List<string> RusUnusedWords;

        public static Dictionary<string, bool> DictForCheck;// вместо сериализации

        //public static int SizeOfEngUnusedWords = 0;
        //public static int SizeOfRusUnusedWords = 0;

        public static bool EngRusWord = true;

        /// <summary>
        /// рандомное слово, которое будет выведено в методе RandomWordInDictionary
        /// </summary>
        public static string RandomWord;
        //public static List<string> GoneWords = new List<string>();

        public static int Size //рамерность словаря Dict
        {
            get { return DictionaryOfWord.Count; }
        }

        static WordDictionary()
        {
            random = new Random();
            DictionaryOfWord = new Dictionary<string, string>();
            EngUnusedWords = new List<string>();
            RusUnusedWords = new List<string>();
            DictForCheck = new Dictionary<string, bool>();
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
                        if (!DictionaryOfWord.Contains(new KeyValuePair<string, string>(line[i], line[i + 1])))
                        {
                            DictionaryOfWord.Add(line[i], line[i + 1]);
                        }
                        if (!DictForCheck.Contains(new KeyValuePair<string, bool>(line[i], false)))
                        {
                            DictForCheck.Add(line[i], false);
                        }
                    }
                }
                //SizeOfEngUnusedWords = DictForCheck.Count;
                //SizeOfRusUnusedWords = DictForCheck.Count;
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

        /// <summary>
        /// рандомный выбор РУССКОГО слова из словаря Dict
        /// </summary>
        /// <returns></returns>
        public static string GetRusUnusedRandomWordOfDictionary()
        {
            int cont = random.Next(0, RusUnusedWords.Count);
            RandomWord = RusUnusedWords[cont];
            EngRusWord = false;

            return DictionaryOfWord[RandomWord];
        }

        /// <summary>
        /// рандомный выбор АНГЛИЙСКОГО слова из словаря Dict
        /// </summary>
        /// <returns></returns>
        public static string GetEngUnusedRandomWordOfDictionary()
        {
            int cont = random.Next(0, EngUnusedWords.Count);
            RandomWord = EngUnusedWords[cont];
            EngRusWord = true;

            return RandomWord;
        }

        public static void SetEngUnusedList()
        {
            EngUnusedWords.Clear();
            foreach (var item in DictionaryOfWord.Keys)
            {
                EngUnusedWords.Add(item);
            }

        }

        public static void SetRusUnusedList()
        {
            RusUnusedWords.Clear();
            foreach (var item in DictionaryOfWord.Values)
            {
                RusUnusedWords.Add(item);
            }

        }
    }
}
