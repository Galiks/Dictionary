namespace WindowsFormsApp2
{
    partial class Results
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RightScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WrongScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.countOfRightWords = new System.Windows.Forms.Label();
            this.countOfWrongWords = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RightScore,
            this.WrongScore});
            this.dataGridView1.Location = new System.Drawing.Point(12, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(260, 145);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // RightScore
            // 
            this.RightScore.HeaderText = "Правильные слова";
            this.RightScore.Name = "RightScore";
            this.RightScore.ReadOnly = true;
            // 
            // WrongScore
            // 
            this.WrongScore.HeaderText = "Неправильные слова";
            this.WrongScore.Name = "WrongScore";
            this.WrongScore.ReadOnly = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 225);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(260, 24);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            // 
            // countOfRightWords
            // 
            this.countOfRightWords.AutoSize = true;
            this.countOfRightWords.Location = new System.Drawing.Point(77, 45);
            this.countOfRightWords.Name = "countOfRightWords";
            this.countOfRightWords.Size = new System.Drawing.Size(35, 13);
            this.countOfRightWords.TabIndex = 2;
            this.countOfRightWords.Text = "label1";
            // 
            // countOfWrongWords
            // 
            this.countOfWrongWords.AutoSize = true;
            this.countOfWrongWords.Location = new System.Drawing.Point(190, 45);
            this.countOfWrongWords.Name = "countOfWrongWords";
            this.countOfWrongWords.Size = new System.Drawing.Size(35, 13);
            this.countOfWrongWords.TabIndex = 3;
            this.countOfWrongWords.Text = "label2";
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.countOfWrongWords);
            this.Controls.Add(this.countOfRightWords);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Results";
            this.Text = "Результаты";
            this.Load += new System.EventHandler(this.Results_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RightScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn WrongScore;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label countOfRightWords;
        private System.Windows.Forms.Label countOfWrongWords;
    }
}