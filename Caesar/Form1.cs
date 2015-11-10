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

namespace Caesar
{
    public partial class Form1 : Form
    {
        private ICypher cypher;
        private string sourceText;
        private string cipheredText;
        public Form1()
        {
            InitializeComponent();
            sourceText = SouceRichTextBox.Text;

            SelectedLanguageComboBox.SelectedIndex = 0;

            var selectedTab = tabControl1.SelectedTab;
            if (selectedTab.Text == @"Шифр Цезаря")
            {
                CreateCaesar();
            }
            else if (selectedTab.Text == @"Шифр Виженера")
            {

            }
            else
            {
                throw new Exception("Не найден текущий вид шифрования");
            }
        }

        private string RemoveUnnecessarySymbols(string text)
        {
            string newtext = "";
            text = text.ToLower().Replace('ё', 'е');
            foreach (var symbol in text)
            {
                foreach (var key in Data.GetAlphabets().Keys)
                {
                    if (Data.GetAlphabets()[key].Letters.Contains(symbol))
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
            if (SelectedLanguageComboBox.SelectedIndex == 0)
                cipheredText = cypher.Encrypt(RemoveUnnecessarySymbols(sourceText), AlphabetType.Russian);
            else
                cipheredText = cypher.Encrypt(RemoveUnnecessarySymbols(sourceText), AlphabetType.English);
            OutputRichTextBox.Text += cipheredText;
            OutputRichTextBox.Text += "\n";
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            string text;
            if (SelectedLanguageComboBox.SelectedIndex == 0)
                 text = cypher.Decrypt(cipheredText.Replace(" ", ""), AlphabetType.Russian);
            else
                text = cypher.Decrypt(cipheredText.Replace(" ", ""), AlphabetType.English);
            OutputRichTextBox.Text += text;
            OutputRichTextBox.Text += "\n";
        }

        private void BreakOpenButton_Click(object sender, EventArgs e)
        {
            //var text = cypher.BreakOpen(cipheredText);
            //OuputListBox.Items.Add(text);
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
                MessageBox.Show(@"Некорректное значение m");
                return 0;
            }
        }

        private void CreateCaesar()
        {
            if (SelectedLanguageComboBox.SelectedIndex == 0)
                cypher = new CaesarCypher(GetM(), AlphabetType.Russian);
            else
                cypher = new CaesarCypher(GetM(), AlphabetType.English);
        }

        private void ChangeMButton_Click(object sender, EventArgs e)
        {
            CreateCaesar();
        }

        private void SelectedLanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateCaesar();
        }
    }
}
