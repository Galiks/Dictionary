namespace WindowsFormsApp2
{
    partial class OutputDictcs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputDictcs));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.OutPut = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(260, 198);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // OutPut
            // 
            this.OutPut.Location = new System.Drawing.Point(79, 226);
            this.OutPut.Name = "OutPut";
            this.OutPut.Size = new System.Drawing.Size(111, 23);
            this.OutPut.TabIndex = 1;
            this.OutPut.Text = "Вывести словарь";
            this.OutPut.UseVisualStyleBackColor = true;
            this.OutPut.Click += new System.EventHandler(this.OutPut_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "\"*.txt\"";
            this.openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.InitialDirectory = "Pictures\\Animals\\";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // OutputDictcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.OutPut);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OutputDictcs";
            this.Text = "OutputDictcs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OutputDictcs_FormClosing);
            this.Load += new System.EventHandler(this.OutputDictcs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button OutPut;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}