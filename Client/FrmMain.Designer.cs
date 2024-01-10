namespace Client
{
    partial class FrmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPoslednjeTri = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnPrikaziSve = new System.Windows.Forms.Button();
            this.btnPrikaziSpecificno = new System.Windows.Forms.Button();
            this.cmb = new System.Windows.Forms.ComboBox();
            this.btnPosaljiSvima = new System.Windows.Forms.Button();
            this.btnPosaljiSpecificno = new System.Windows.Forms.Button();
            this.btnPrikaziFulPoruku = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSvePoruke = new System.Windows.Forms.DataGridView();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoslednjeTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSvePoruke)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPoslednjeTri
            // 
            this.dgvPoslednjeTri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoslednjeTri.Location = new System.Drawing.Point(12, 21);
            this.dgvPoslednjeTri.Name = "dgvPoslednjeTri";
            this.dgvPoslednjeTri.ReadOnly = true;
            this.dgvPoslednjeTri.Size = new System.Drawing.Size(289, 128);
            this.dgvPoslednjeTri.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 315);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(289, 31);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // btnPrikaziSve
            // 
            this.btnPrikaziSve.Location = new System.Drawing.Point(332, 5);
            this.btnPrikaziSve.Name = "btnPrikaziSve";
            this.btnPrikaziSve.Size = new System.Drawing.Size(174, 39);
            this.btnPrikaziSve.TabIndex = 4;
            this.btnPrikaziSve.Text = "Prikazi sve poruke ovog korisnika koje su svima poslate";
            this.btnPrikaziSve.UseVisualStyleBackColor = true;
            this.btnPrikaziSve.Click += new System.EventHandler(this.btnPrikaziSve_Click);
            // 
            // btnPrikaziSpecificno
            // 
            this.btnPrikaziSpecificno.Location = new System.Drawing.Point(332, 50);
            this.btnPrikaziSpecificno.Name = "btnPrikaziSpecificno";
            this.btnPrikaziSpecificno.Size = new System.Drawing.Size(174, 38);
            this.btnPrikaziSpecificno.TabIndex = 5;
            this.btnPrikaziSpecificno.Text = "Prikazi poruke ovog korisnika namenjene samo meni";
            this.btnPrikaziSpecificno.UseVisualStyleBackColor = true;
            this.btnPrikaziSpecificno.Click += new System.EventHandler(this.btnPrikaziSpecificno_Click);
            // 
            // cmb
            // 
            this.cmb.FormattingEnabled = true;
            this.cmb.Location = new System.Drawing.Point(332, 155);
            this.cmb.Name = "cmb";
            this.cmb.Size = new System.Drawing.Size(78, 21);
            this.cmb.TabIndex = 6;
            // 
            // btnPosaljiSvima
            // 
            this.btnPosaljiSvima.Location = new System.Drawing.Point(332, 228);
            this.btnPosaljiSvima.Name = "btnPosaljiSvima";
            this.btnPosaljiSvima.Size = new System.Drawing.Size(75, 23);
            this.btnPosaljiSvima.TabIndex = 7;
            this.btnPosaljiSvima.Text = "Posalji svima";
            this.btnPosaljiSvima.UseVisualStyleBackColor = true;
            this.btnPosaljiSvima.Click += new System.EventHandler(this.btnPosaljiSvima_Click);
            // 
            // btnPosaljiSpecificno
            // 
            this.btnPosaljiSpecificno.Location = new System.Drawing.Point(332, 182);
            this.btnPosaljiSpecificno.Name = "btnPosaljiSpecificno";
            this.btnPosaljiSpecificno.Size = new System.Drawing.Size(75, 40);
            this.btnPosaljiSpecificno.TabIndex = 8;
            this.btnPosaljiSpecificno.Text = "Posalji specificno";
            this.btnPosaljiSpecificno.UseVisualStyleBackColor = true;
            this.btnPosaljiSpecificno.Click += new System.EventHandler(this.btnPosaljiSpecificno_Click);
            // 
            // btnPrikaziFulPoruku
            // 
            this.btnPrikaziFulPoruku.Location = new System.Drawing.Point(332, 92);
            this.btnPrikaziFulPoruku.Name = "btnPrikaziFulPoruku";
            this.btnPrikaziFulPoruku.Size = new System.Drawing.Size(78, 57);
            this.btnPrikaziFulPoruku.TabIndex = 10;
            this.btnPrikaziFulPoruku.Text = "Prikazi ful poruku";
            this.btnPrikaziFulPoruku.UseVisualStyleBackColor = true;
            this.btnPrikaziFulPoruku.Click += new System.EventHandler(this.btnPrikaziFulPoruku_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Poslednje 3 poruke:";
            // 
            // dgvSvePoruke
            // 
            this.dgvSvePoruke.AllowUserToAddRows = false;
            this.dgvSvePoruke.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSvePoruke.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSvePoruke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSvePoruke.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSvePoruke.Location = new System.Drawing.Point(12, 155);
            this.dgvSvePoruke.MultiSelect = false;
            this.dgvSvePoruke.Name = "dgvSvePoruke";
            this.dgvSvePoruke.ReadOnly = true;
            this.dgvSvePoruke.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSvePoruke.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSvePoruke.Size = new System.Drawing.Size(289, 153);
            this.dgvSvePoruke.TabIndex = 12;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(426, 129);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(100, 96);
            this.richTextBox2.TabIndex = 13;
            this.richTextBox2.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Cela poruka glasi:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 358);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.dgvSvePoruke);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrikaziFulPoruku);
            this.Controls.Add(this.btnPosaljiSpecificno);
            this.Controls.Add(this.btnPosaljiSvima);
            this.Controls.Add(this.cmb);
            this.Controls.Add(this.btnPrikaziSpecificno);
            this.Controls.Add(this.btnPrikaziSve);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dgvPoslednjeTri);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoslednjeTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSvePoruke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPoslednjeTri;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnPrikaziSve;
        private System.Windows.Forms.Button btnPrikaziSpecificno;
        private System.Windows.Forms.ComboBox cmb;
        private System.Windows.Forms.Button btnPosaljiSvima;
        private System.Windows.Forms.Button btnPosaljiSpecificno;
        private System.Windows.Forms.Button btnPrikaziFulPoruku;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSvePoruke;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label2;
    }
}