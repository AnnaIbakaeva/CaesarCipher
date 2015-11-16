using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormApplication;

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
            var cipheredText = cypher.Encrypt(RemoveUnnecessarySymbols(sourceText));
            OutputRichTextBox.Text += cipheredText;
            OutputRichTextBox.Text += "\n";
            OutputRichTextBox.Text += "\n";
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            string text = cypher.Decrypt(RemoveUnnecessarySymbols(sourceText));
            OutputRichTextBox.Text += text;
            OutputRichTextBox.Text += "\n";
            OutputRichTextBox.Text += "\n";
        }

        private void BreakOpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                var text = cypher.BreakOpen(RemoveUnnecessarySymbols(sourceText));
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
                textBoxM.Text = "0";
                MessageBox.Show(@"Некорректное значение m");
                return 0;
            }
        }

        private void CreateCaesar()
        {
            cypher = new CaesarCypher(GetM());
        }

        private void ChangeMButton_Click(object sender, EventArgs e)
        {
            CreateCaesar();
        }

        private void CLearRichTextButton_Click(object sender, EventArgs e)
        {
            OutputRichTextBox.Clear();
        }
    }
}
