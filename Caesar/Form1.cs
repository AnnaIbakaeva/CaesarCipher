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
            sourceText = SourceTextListBox.Text;

            var selectedTab = tabControl1.SelectedTab;
            if (selectedTab.Name == "Шифр Цезаря")
            {
                CreateCaesar();
            }
            else if (selectedTab.Name == "Шифр Виженера")
            {

            }
            else
            {
                throw new Exception("Не найден текущий вид шифрования");
            }
        }

        private void buttonChangeM_Click(object sender, EventArgs e)
        {
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
           
            cipheredText = cypher.Encrypt(sourceText);
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            var text = cypher.Decrypt(cipheredText);
            OuputListBox.Items.Add(text);
        }

        private void BreakOpenButton_Click(object sender, EventArgs e)
        {
            var text = cypher.BreakOpen(cipheredText);
            OuputListBox.Items.Add(text);
        }

        private void ChangeSourceTextButton_Click(object sender, EventArgs e)
        {
            sourceText = SourceTextListBox.Text;
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
            cypher = new CaesarCypher(GetM());
        }
    }
}
