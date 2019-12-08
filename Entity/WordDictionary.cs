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
        public static Dictionary<string, string> DictionaryOfWords;

        /// <summary>
        /// Список неиспользованных английских слов
        /// </summary>
        public static List<string> EngUnusedWords;

        /// <summary>
        /// Список неиспользованных русских слов
        /// </summary>
        public static List<string> RusUnusedWords;

        public static Dictionary<string, bool> DictForCheck;// вместо сериализации

        public static bool EngRusWord = true;

        public static int Size //рамерность словаря Dict
        {
            get { return DictionaryOfWords.Count; }
        }

        static WordDictionary()
        {
            random = new Random();
            DictionaryOfWords = new Dictionary<string, string>();
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
                        if (!DictionaryOfWords.Contains(new KeyValuePair<string, string>(line[i], line[i + 1])))
                        {
                            DictionaryOfWords.Add(line[i], line[i + 1]);
                        }
                        if (!DictForCheck.Contains(new KeyValuePair<string, bool>(line[i], false)))
                        {
                            DictForCheck.Add(line[i], false);
                        }
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

        /// <summary>
        /// рандомный выбор РУССКОГО слова из словаря Dict
        /// </summary>
        /// <returns></returns>
        public static string GetRusUnusedRandomWordFromDictionary()
        {
            int cont = random.Next(0, RusUnusedWords.Count);
            string randomWord = RusUnusedWords[cont];
            EngRusWord = false;

            return DictionaryOfWords[randomWord];
        }

        /// <summary>
        /// рандомный выбор АНГЛИЙСКОГО слова из словаря Dict
        /// </summary>
        /// <returns></returns>
        public static string GetEngUnusedRandomWordFromDictionary()
        {
            int cont = random.Next(0, EngUnusedWords.Count);
            string randomWord = EngUnusedWords[cont];
            EngRusWord = true;

            return randomWord;
        }

        public static void SetEngUnusedList()
        {
            EngUnusedWords.Clear();
            foreach (var item in DictionaryOfWords.Keys)
            {
                EngUnusedWords.Add(item);
            }

        }

        public static void SetRusUnusedList()
        {
            RusUnusedWords.Clear();
            foreach (var item in DictionaryOfWords.Values)
            {
                RusUnusedWords.Add(item);
            }
        }

        public static string GetEngWordByRusWord(string value)
        {
            return DictionaryOfWords.First(x => x.Value == value).Key;
        }

        public static string GetRusWordByEngWord(string key)
        {
            return DictionaryOfWords.First(x => x.Key == key).Value;
        }

        public static string GetEngRandomWordFromDictionary()
        {
            int cont = random.Next(0, DictionaryOfWords.Count);
            return DictionaryOfWords.ElementAt(cont).Key;
        }

        public static string GetRusRandomWordFromDictionary()
        {
            int cont = random.Next(0, DictionaryOfWords.Count);
            return DictionaryOfWords.ElementAt(cont).Value;
        }
    }
}
