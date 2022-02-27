namespace C18_Ex05
{
    partial class GameSettingsD
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
            this.m_CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.m_TextBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.m_TextBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_NumericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.m_NumericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_ButtonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Players :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 1:";
            // 
            // m_CheckBoxPlayer2
            // 
            this.m_CheckBoxPlayer2.AutoSize = true;
            this.m_CheckBoxPlayer2.Location = new System.Drawing.Point(37, 74);
            this.m_CheckBoxPlayer2.Name = "m_CheckBoxPlayer2";
            this.m_CheckBoxPlayer2.Size = new System.Drawing.Size(67, 17);
            this.m_CheckBoxPlayer2.TabIndex = 2;
            this.m_CheckBoxPlayer2.Text = "Player 2:";
            this.m_CheckBoxPlayer2.UseVisualStyleBackColor = true;
            // 
            // m_TextBoxPlayer1
            // 
            this.m_TextBoxPlayer1.Location = new System.Drawing.Point(131, 45);
            this.m_TextBoxPlayer1.Name = "m_TextBoxPlayer1";
            this.m_TextBoxPlayer1.Size = new System.Drawing.Size(100, 20);
            this.m_TextBoxPlayer1.TabIndex = 3;
            // 
            // m_TextBoxPlayer2
            // 
            this.m_TextBoxPlayer2.Enabled = false;
            this.m_TextBoxPlayer2.Location = new System.Drawing.Point(131, 74);
            this.m_TextBoxPlayer2.Name = "m_TextBoxPlayer2";
            this.m_TextBoxPlayer2.Size = new System.Drawing.Size(100, 20);
            this.m_TextBoxPlayer2.TabIndex = 4;
            this.m_TextBoxPlayer2.Text = "[Computer]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Board size:";
            // 
            // m_NumericUpDownRows
            // 
            this.m_NumericUpDownRows.Location = new System.Drawing.Point(80, 164);
            this.m_NumericUpDownRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_NumericUpDownRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_NumericUpDownRows.Name = "m_NumericUpDownRows";
            this.m_NumericUpDownRows.Size = new System.Drawing.Size(42, 20);
            this.m_NumericUpDownRows.TabIndex = 6;
            this.m_NumericUpDownRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // m_NumericUpDownCols
            // 
            this.m_NumericUpDownCols.Location = new System.Drawing.Point(167, 164);
            this.m_NumericUpDownCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_NumericUpDownCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_NumericUpDownCols.Name = "m_NumericUpDownCols";
            this.m_NumericUpDownCols.Size = new System.Drawing.Size(39, 20);
            this.m_NumericUpDownCols.TabIndex = 7;
            this.m_NumericUpDownCols.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Rows :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cols :";
            // 
            // m_ButtonStart
            // 
            this.m_ButtonStart.Location = new System.Drawing.Point(56, 209);
            this.m_ButtonStart.Name = "m_ButtonStart";
            this.m_ButtonStart.Size = new System.Drawing.Size(161, 23);
            this.m_ButtonStart.TabIndex = 10;
            this.m_ButtonStart.Text = "Start";
            this.m_ButtonStart.UseVisualStyleBackColor = true;
            // 
            // GameSettingsD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.m_ButtonStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_NumericUpDownCols);
            this.Controls.Add(this.m_NumericUpDownRows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_TextBoxPlayer2);
            this.Controls.Add(this.m_TextBoxPlayer1);
            this.Controls.Add(this.m_CheckBoxPlayer2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsD";
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox m_CheckBoxPlayer2;
        private System.Windows.Forms.TextBox m_TextBoxPlayer1;
        private System.Windows.Forms.TextBox m_TextBoxPlayer2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown m_NumericUpDownRows;
        private System.Windows.Forms.NumericUpDown m_NumericUpDownCols;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button m_ButtonStart;
    }
}