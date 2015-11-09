namespace Caesar
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxM = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.OuputListBox = new System.Windows.Forms.ListBox();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.BreakOpenButton = new System.Windows.Forms.Button();
            this.SourceTextListBox = new System.Windows.Forms.ListBox();
            this.ChangeSourceTextButton = new System.Windows.Forms.Button();
            this.SelectedLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(228, 89);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBoxM);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(220, 63);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Шифр Цезаря";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "m:";
            // 
            // textBoxM
            // 
            this.textBoxM.Location = new System.Drawing.Point(44, 21);
            this.textBoxM.Name = "textBoxM";
            this.textBoxM.Size = new System.Drawing.Size(48, 20);
            this.textBoxM.TabIndex = 0;
            this.textBoxM.Text = "3";
            this.textBoxM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(220, 63);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Шифр Виженера";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // OuputListBox
            // 
            this.OuputListBox.FormattingEnabled = true;
            this.OuputListBox.Location = new System.Drawing.Point(290, 28);
            this.OuputListBox.Name = "OuputListBox";
            this.OuputListBox.Size = new System.Drawing.Size(448, 290);
            this.OuputListBox.TabIndex = 1;
            // 
            // EncryptButton
            // 
            this.EncryptButton.Location = new System.Drawing.Point(290, 334);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(97, 23);
            this.EncryptButton.TabIndex = 2;
            this.EncryptButton.Text = "Зашифровать";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(478, 334);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(98, 23);
            this.DecryptButton.TabIndex = 3;
            this.DecryptButton.Text = "Расшифровать";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // BreakOpenButton
            // 
            this.BreakOpenButton.Location = new System.Drawing.Point(663, 334);
            this.BreakOpenButton.Name = "BreakOpenButton";
            this.BreakOpenButton.Size = new System.Drawing.Size(75, 23);
            this.BreakOpenButton.TabIndex = 4;
            this.BreakOpenButton.Text = "Взломать";
            this.BreakOpenButton.UseVisualStyleBackColor = true;
            this.BreakOpenButton.Click += new System.EventHandler(this.BreakOpenButton_Click);
            // 
            // SourceTextListBox
            // 
            this.SourceTextListBox.FormattingEnabled = true;
            this.SourceTextListBox.Items.AddRange(new object[] {
            "Веб-страница недоступна"});
            this.SourceTextListBox.Location = new System.Drawing.Point(19, 185);
            this.SourceTextListBox.Name = "SourceTextListBox";
            this.SourceTextListBox.Size = new System.Drawing.Size(220, 95);
            this.SourceTextListBox.TabIndex = 5;
            // 
            // ChangeSourceTextButton
            // 
            this.ChangeSourceTextButton.Location = new System.Drawing.Point(19, 298);
            this.ChangeSourceTextButton.Name = "ChangeSourceTextButton";
            this.ChangeSourceTextButton.Size = new System.Drawing.Size(224, 23);
            this.ChangeSourceTextButton.TabIndex = 6;
            this.ChangeSourceTextButton.Text = "Изменить исходный текст";
            this.ChangeSourceTextButton.UseVisualStyleBackColor = true;
            this.ChangeSourceTextButton.Click += new System.EventHandler(this.ChangeSourceTextButton_Click);
            // 
            // SelectedLanguageComboBox
            // 
            this.SelectedLanguageComboBox.FormattingEnabled = true;
            this.SelectedLanguageComboBox.Items.AddRange(new object[] {
            "Русский",
            "Английский"});
            this.SelectedLanguageComboBox.Location = new System.Drawing.Point(118, 132);
            this.SelectedLanguageComboBox.Name = "SelectedLanguageComboBox";
            this.SelectedLanguageComboBox.Size = new System.Drawing.Size(121, 21);
            this.SelectedLanguageComboBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выберете язык";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 374);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectedLanguageComboBox);
            this.Controls.Add(this.ChangeSourceTextButton);
            this.Controls.Add(this.SourceTextListBox);
            this.Controls.Add(this.BreakOpenButton);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.EncryptButton);
            this.Controls.Add(this.OuputListBox);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Шифрование";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBoxM;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox OuputListBox;
        private System.Windows.Forms.Button EncryptButton;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.Button BreakOpenButton;
        private System.Windows.Forms.ListBox SourceTextListBox;
        private System.Windows.Forms.Button ChangeSourceTextButton;
        private System.Windows.Forms.ComboBox SelectedLanguageComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

