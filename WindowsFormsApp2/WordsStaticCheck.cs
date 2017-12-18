using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    [Serializable]
    public class WordsStaticCheck
    {
        [XmlElement("Word")]
        public string word { get; set; }

        [XmlElement("Status")]
        public bool check { get; set; }

        public WordsStaticCheck()
        {

        }

        public WordsStaticCheck(string name, bool checking)
        {
            word = name;
            check = checking;
        }

        public List<WordsStaticCheck> MasWSC;
    }

    //[Serializable]
    //public static class WordsStaticCheckCollection
    //{
    //    [XmlArray("Collection"), XmlArrayItem("Item")]
    //    public static List<WordsStaticCheck> MyList { get; set; }
    //}
}
