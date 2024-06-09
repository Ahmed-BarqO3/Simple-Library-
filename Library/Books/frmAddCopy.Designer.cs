namespace Library.Books
{
    partial class frmAddCopy
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
            this.ctrlBookCard1 = new Library.Books.ctrlBookCard();
            this.NumCopies = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlBookCard1
            // 
            this.ctrlBookCard1.Location = new System.Drawing.Point(2, 42);
            this.ctrlBookCard1.Name = "ctrlBookCard1";
            this.ctrlBookCard1.Size = new System.Drawing.Size(634, 248);
            this.ctrlBookCard1.TabIndex = 1;
            // 
            // NumCopies
            // 
            this.NumCopies.BackColor = System.Drawing.Color.Transparent;
            this.NumCopies.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NumCopies.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NumCopies.Location = new System.Drawing.Point(142, 308);
            this.NumCopies.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NumCopies.Name = "NumCopies";
            this.NumCopies.Size = new System.Drawing.Size(149, 24);
            this.NumCopies.TabIndex = 2;
            this.NumCopies.ValueChanged += new System.EventHandler(this.NumCopies_ValueChanged);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(5, 308);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(131, 22);
            this.guna2HtmlLabel2.TabIndex = 3;
            this.guna2HtmlLabel2.Text = "Number of Copies:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BorderThickness = 1;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.Enabled = false;
            this.btnSave.FillColor = System.Drawing.SystemColors.ScrollBar;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.IndicateFocus = true;
            this.btnSave.Location = new System.Drawing.Point(522, 303);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(634, 347);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.NumCopies);
            this.Controls.Add(this.ctrlBookCard1);
            this.Name = "frmAddCopy";
            this.Load += new System.EventHandler(this.fmrAddCopy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlBookCard ctrlBookCard1;
        private Guna.UI2.WinForms.Guna2NumericUpDown NumCopies;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button btnSave;
    }
}
