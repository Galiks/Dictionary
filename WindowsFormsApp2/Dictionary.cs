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

        public static List<string> EngUnUsedWords = new List<string>(); //Список неиспользованных английских слов
        public static List<string> RusUnUsedWords = new List<string>(); //Список неиспользованных русских слов

        public static Dictionary<string, bool> DictForCheck = new Dictionary<string, bool>();// вместо сериализации

        public static int SizeOfEngUnUsedWords = 0;
        public static int SizeOfRusUnUsedWords = 0;

        public static bool EngRusWord = true;

        public static string RandomWord; //рандомное слово, которое будет выведено в методе RandomWordInDictionary

        //public static List<string> GoneWords = new List<string>();
        
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
            int cont = random.Next(0, SizeOfRusUnUsedWords);
            RandomWord = RusUnUsedWords[cont];
            EngRusWord = false;

           return Dict[RandomWord];
        }

        public static string EngRandomWordOfDictionary() // рандомный выбор АНГЛИЙСКОГО слова из словаря Dict
        {
            Random random = new Random();
            int cont = random.Next(0, SizeOfEngUnUsedWords);
            RandomWord = EngUnUsedWords[cont];
            EngRusWord = true;

            return Dict[RandomWord];
        }
    }
}
