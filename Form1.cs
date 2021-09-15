using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCorrectList_dotNET5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.htmlEditControl1.CSSText = "body {font-family: Segoe UI, Arial}";
            this.htmlEditControl1.EnableInlineSpelling = true;
            this.htmlEditControl1.SpellingAutoCorrectionList = ReadFileToHashTable("autocorrects.csv");
            this.htmlEditControl1.DocumentHTML = "<h1>Autocorrect List example</h2><p>Loads an autocorrect list from file into the SpellingAutoCorrectList property. Please note that the autocorrect acronyms are case-sensitive. Try typing <b>BRB</b>, <b>AFAIK</b>, <b>BISFLATM</b>, or <b>AWOL</b>";
        }

        private static Hashtable ReadFileToHashTable(string filepath)
        {
            string line;
            Hashtable oHash = new();

            StreamReader sr = new(filepath);

            while (sr.Peek() >= 0)
            {
                line = sr.ReadLine();
                try
                {
                    oHash.Add(line.Split(',', 2)[0], line.Split(',', 2)[1].Replace("\"", ""));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message ); // duplicate key
                }
            }
            sr.Close();

            return oHash;
        }

    }
}
