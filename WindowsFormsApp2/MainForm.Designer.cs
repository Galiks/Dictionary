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
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.языкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.английскийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.словарьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.животныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хоббиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свойСловарьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.опросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текстовыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.картинкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "Показать словарь";
            this.toolTip1.SetToolTip(this.button1, "Выводит словарь выбранного файла.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.языкToolStripMenuItem,
            this.опросToolStripMenuItem,
            this.словарьToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(307, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // языкToolStripMenuItem
            // 
            this.языкToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.английскийToolStripMenuItem});
            this.языкToolStripMenuItem.Name = "языкToolStripMenuItem";
            this.языкToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.языкToolStripMenuItem.Text = "Язык";
            // 
            // английскийToolStripMenuItem
            // 
            this.английскийToolStripMenuItem.Name = "английскийToolStripMenuItem";
            this.английскийToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.английскийToolStripMenuItem.Text = "Английский";
            // 
            // словарьToolStripMenuItem
            // 
            this.словарьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.животныеToolStripMenuItem,
            this.хоббиToolStripMenuItem,
            this.свойСловарьToolStripMenuItem});
            this.словарьToolStripMenuItem.Name = "словарьToolStripMenuItem";
            this.словарьToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.словарьToolStripMenuItem.Text = "Словарь";
            // 
            // животныеToolStripMenuItem
            // 
            this.животныеToolStripMenuItem.Name = "животныеToolStripMenuItem";
            this.животныеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.животныеToolStripMenuItem.Text = "Животные";
            this.животныеToolStripMenuItem.Click += new System.EventHandler(this.животныеToolStripMenuItem_Click);
            // 
            // хоббиToolStripMenuItem
            // 
            this.хоббиToolStripMenuItem.Name = "хоббиToolStripMenuItem";
            this.хоббиToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.хоббиToolStripMenuItem.Text = "Хобби";
            this.хоббиToolStripMenuItem.Click += new System.EventHandler(this.хоббиToolStripMenuItem_Click);
            // 
            // свойСловарьToolStripMenuItem
            // 
            this.свойСловарьToolStripMenuItem.Name = "свойСловарьToolStripMenuItem";
            this.свойСловарьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.свойСловарьToolStripMenuItem.Text = "Свой словарь";
            this.свойСловарьToolStripMenuItem.Click += new System.EventHandler(this.свойСловарьToolStripMenuItem_Click);
            // 
            // опросToolStripMenuItem
            // 
            this.опросToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.текстовыйToolStripMenuItem,
            this.картинкиToolStripMenuItem,
            this.играToolStripMenuItem});
            this.опросToolStripMenuItem.Name = "опросToolStripMenuItem";
            this.опросToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.опросToolStripMenuItem.Text = "Опрос";
            // 
            // текстовыйToolStripMenuItem
            // 
            this.текстовыйToolStripMenuItem.Name = "текстовыйToolStripMenuItem";
            this.текстовыйToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.текстовыйToolStripMenuItem.Text = "Текстовый";
            this.текстовыйToolStripMenuItem.Click += new System.EventHandler(this.текстовыйToolStripMenuItem_Click);
            // 
            // картинкиToolStripMenuItem
            // 
            this.картинкиToolStripMenuItem.Name = "картинкиToolStripMenuItem";
            this.картинкиToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.картинкиToolStripMenuItem.Text = "Картинки";
            this.картинкиToolStripMenuItem.Click += new System.EventHandler(this.картинкиToolStripMenuItem_Click);
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.играToolStripMenuItem.Text = "Игра";
            this.играToolStripMenuItem.Click += new System.EventHandler(this.играToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(283, 170);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 287);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Словарь-тренер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem словарьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem животныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хоббиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свойСловарьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem опросToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem текстовыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem картинкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem языкToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem английскийToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
    }
}