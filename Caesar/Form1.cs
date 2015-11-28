using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cryptology;
using Cryptology.Vigener;

namespace Caesar
{
    public partial class Form1 : Form
    {
        private ICypher cypher;
        private string sourceText;
        public Form1()
        {
            InitializeComponent();
            sourceText = SouceRichTextBox.Text;
            ChangeCurrentCipher();
        }

        private void ChangeCurrentCipher()
        {
            try
            {
                var selectedTab = tabControl1.SelectedTab;
                switch (selectedTab.Text)
                {
                    case @"Шифр Цезаря":
                        cypher = new CaesarCypher(GetM());
                        break;
                    case @"Шифр Виженера":
                        cypher = new VigenerCypher(GetKeyWord());
                        break;
                    default:
                        throw new Exception("Не найден текущий вид шифрования");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private string RemoveUnnecessarySymbols(string text, List<Alphabet> alphabets)
        {
            string newtext = "";
            text = text.ToLower().Replace('ё', 'е');
            foreach (var symbol in text)
            {
                foreach (var alphabet in alphabets)
                {
                    if (alphabet.Letters.Contains(symbol))
                    {
                        newtext += symbol;
                        break;
                    }
                }
            }
            return newtext;
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cipheredText = cypher.Encrypt(RemoveUnnecessarySymbols(sourceText, Data.GetAlphabets().Values.ToList()));
                OutputRichTextBox.Text += cipheredText;
                OutputRichTextBox.Text += "\n";
                OutputRichTextBox.Text += "\n";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                string text = cypher.Decrypt(RemoveUnnecessarySymbols(sourceText, Data.GetAlphabets().Values.ToList()));
                OutputRichTextBox.Text += text;
                OutputRichTextBox.Text += "\n";
                OutputRichTextBox.Text += "\n";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BreakOpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                var text = cypher.BreakOpen(RemoveUnnecessarySymbols(sourceText, Data.GetAlphabets().Values.ToList()));
                OutputRichTextBox.Text += text;
                OutputRichTextBox.Text += "\n";
                OutputRichTextBox.Text += "\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeSourceTextButton_Click(object sender, EventArgs e)
        {
            sourceText = SouceRichTextBox.Text;
        }

        private int GetM()
        {
            try
            {
                return Convert.ToInt32(textBoxM.Text);
            }
            catch (Exception)
            {
                throw new Exception(@"Некорректное значение m");
            }
        }

        private string GetKeyWord()
        {
            var keyWord = keyWordTextBox.Text;
            keyWord = keyWord.ToLower().Replace('ё', 'е');
            var acceptedKeyWord = RemoveUnnecessarySymbols(keyWord, new List<Alphabet>() { Data.GetAlphabets()[AlphabetType.Russian] });
            if (acceptedKeyWord != keyWord)
            {
                throw new Exception(@"Ключевое слово введено некорректно. Пожалуйста, используйте только символы русского алфавита.");
            }
            return acceptedKeyWord;
        }

        private void ChangeMValue_Click(object sender, EventArgs e)
        {
            try
            {
                if (cypher is CaesarCypher)
                {
                    (cypher as CaesarCypher).M = GetM();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void CLearRichTextButton_Click(object sender, EventArgs e)
        {
            OutputRichTextBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SouceRichTextBox.Clear();
        }

        private void keyWordTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cypher is VigenerCypher)
                {
                    (cypher as VigenerCypher).KeyWord = GetKeyWord();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCurrentCipher();
        }
    }
}
