using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<string> clearText(string text)
        {
            text = text.ToLower();
            List<string> clearedText = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                if ((c >= 'a' && c <= 'z') || (c >= 'а' && c <= 'я') || c == ' ' || c == '\n'|| c=='+' || c=='#')
                {
                    sb.Append(c);
                }
            }
            string[] spacedText = sb.ToString().Split('\n');

            foreach (string c in spacedText)
            {
                clearedText.AddRange(c.Split(' '));

            }

            clearedText.RemoveAll(string.IsNullOrWhiteSpace);
            clearedText = clearedText.Distinct().ToList();
            return clearedText;
        }

        private string findFirst(List<string> clearedText)
        {
            string firstSymbols = "";
            string firstUniqueSymbol = "";
            foreach (string s in clearedText)
            {
                firstSymbols += s.ToLookup(c => c).First(g => g.Count() == 1).Key;

            }
            firstUniqueSymbol += firstSymbols.ToLookup(c => c).First(g => g.Count() == 1).Key;
            return firstUniqueSymbol;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> clearedText = clearText(textBox1.Text);
            string uniqueSymbol = findFirst(clearedText);
            label1.Text = "Унікальний символ: " + uniqueSymbol;
            label1.Visible = true;
        }
    }
}
