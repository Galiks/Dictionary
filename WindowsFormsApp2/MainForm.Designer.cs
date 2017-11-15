namespace WindowsFormsApp2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Texting = new System.Windows.Forms.Button();
            this.AnimalsDict = new System.Windows.Forms.Button();
            this.Hobby = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Game = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Images = new System.Windows.Forms.Button();
            this.UserDictionary = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(64, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите словарь";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(49, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Выберите тип опроса";
            // 
            // Texting
            // 
            this.Texting.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Texting.Location = new System.Drawing.Point(12, 146);
            this.Texting.Name = "Texting";
            this.Texting.Size = new System.Drawing.Size(75, 23);
            this.Texting.TabIndex = 2;
            this.Texting.Text = "Текстовый";
            this.toolTip1.SetToolTip(this.Texting, "Выводит новое окно с текстовым опросом.");
            this.Texting.UseVisualStyleBackColor = true;
            this.Texting.Click += new System.EventHandler(this.Text_Click);
            // 
            // AnimalsDict
            // 
            this.AnimalsDict.Location = new System.Drawing.Point(12, 58);
            this.AnimalsDict.Name = "AnimalsDict";
            this.AnimalsDict.Size = new System.Drawing.Size(75, 23);
            this.AnimalsDict.TabIndex = 3;
            this.AnimalsDict.Text = "Животные";
            this.toolTip1.SetToolTip(this.AnimalsDict, "Добавляет в словарь слова на тему животные.");
            this.AnimalsDict.UseVisualStyleBackColor = true;
            this.AnimalsDict.Click += new System.EventHandler(this.AnimalsDict_Click);
            // 
            // Hobby
            // 
            this.Hobby.Location = new System.Drawing.Point(214, 58);
            this.Hobby.Name = "Hobby";
            this.Hobby.Size = new System.Drawing.Size(75, 23);
            this.Hobby.TabIndex = 4;
            this.Hobby.Text = "Хобби";
            this.toolTip1.SetToolTip(this.Hobby, "Добавляет в словарь слова на тему хобби.");
            this.Hobby.UseVisualStyleBackColor = true;
            this.Hobby.Click += new System.EventHandler(this.Hobby_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "Показать словарь";
            this.toolTip1.SetToolTip(this.button1, "Выводит словарь выбранного файла.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Exit
            // 
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Exit.Location = new System.Drawing.Point(214, 243);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 32);
            this.Exit.TabIndex = 6;
            this.toolTip1.SetToolTip(this.Exit, "Выйти из программы.");
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Game
            // 
            this.Game.Location = new System.Drawing.Point(214, 146);
            this.Game.Name = "Game";
            this.Game.Size = new System.Drawing.Size(75, 23);
            this.Game.TabIndex = 7;
            this.Game.Text = "Игра";
            this.toolTip1.SetToolTip(this.Game, "Выводит новое окно с игрой на время, где нужно угадать слово.");
            this.Game.UseVisualStyleBackColor = true;
            this.Game.Click += new System.EventHandler(this.Game_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Images
            // 
            this.Images.Location = new System.Drawing.Point(113, 146);
            this.Images.Name = "Images";
            this.Images.Size = new System.Drawing.Size(75, 23);
            this.Images.TabIndex = 9;
            this.Images.Text = "Картинки";
            this.toolTip1.SetToolTip(this.Images, "Выводит новое окно, где нужно написать какое животное изображено на картинке.");
            this.Images.UseVisualStyleBackColor = true;
            this.Images.Click += new System.EventHandler(this.Images_Click);
            // 
            // UserDictionary
            // 
            this.UserDictionary.Location = new System.Drawing.Point(102, 40);
            this.UserDictionary.Name = "UserDictionary";
            this.UserDictionary.Size = new System.Drawing.Size(95, 41);
            this.UserDictionary.TabIndex = 10;
            this.UserDictionary.Text = "Словарь пользователя";
            this.toolTip1.SetToolTip(this.UserDictionary, resources.GetString("UserDictionary.ToolTip"));
            this.UserDictionary.UseVisualStyleBackColor = true;
            this.UserDictionary.Click += new System.EventHandler(this.UserDictionary_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "\"*.txt\"";
            this.openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            this.openFileDialog1.InitialDirectory = "Pictures\\User Dictionary\\";
            this.openFileDialog1.ReadOnlyChecked = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 15000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Подсказка";
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // toolTip2
            // 
            this.toolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Exit;
            this.ClientSize = new System.Drawing.Size(301, 287);
            this.ControlBox = false;
            this.Controls.Add(this.UserDictionary);
            this.Controls.Add(this.Images);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Game);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Hobby);
            this.Controls.Add(this.AnimalsDict);
            this.Controls.Add(this.Texting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Словарь-тренер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Texting;
        private System.Windows.Forms.Button AnimalsDict;
        private System.Windows.Forms.Button Hobby;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Game;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Images;
        private System.Windows.Forms.Button UserDictionary;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}