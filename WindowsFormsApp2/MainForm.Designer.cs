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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Texting = new System.Windows.Forms.Button();
            this.AnimalsDict = new System.Windows.Forms.Button();
            this.Hobby = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.Texting.Location = new System.Drawing.Point(107, 146);
            this.Texting.Name = "Texting";
            this.Texting.Size = new System.Drawing.Size(75, 23);
            this.Texting.TabIndex = 2;
            this.Texting.Text = "Текстовый";
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
            this.Hobby.UseVisualStyleBackColor = true;
            this.Hobby.Click += new System.EventHandler(this.Hobby_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Вывод словаря";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 287);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Hobby);
            this.Controls.Add(this.AnimalsDict);
            this.Controls.Add(this.Texting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
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
    }
}