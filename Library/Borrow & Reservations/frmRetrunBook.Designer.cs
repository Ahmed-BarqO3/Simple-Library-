namespace Library.Borrow___Reservations
{
    partial class frmRetrunBook
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
            this.ctrlCopyBookCard1 = new Library.Books.ctrlCopyBookCard();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnReservation = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlUserCard1 = new Library.Users.ctrlUserCard();
            this.ctrlReservationCard1 = new Library.Borrow___Reservations.ctrlReservationCard();
            this.SuspendLayout();
            // 
            // ctrlCopyBookCard1
            // 
            this.ctrlCopyBookCard1.Location = new System.Drawing.Point(1, 189);
            this.ctrlCopyBookCard1.Name = "ctrlCopyBookCard1";
            this.ctrlCopyBookCard1.Size = new System.Drawing.Size(630, 244);
            this.ctrlCopyBookCard1.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnClose.Location = new System.Drawing.Point(332, 628);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(134, 37);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReservation
            // 
            this.btnReservation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReservation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReservation.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReservation.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReservation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReservation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReservation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReservation.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReservation.Location = new System.Drawing.Point(490, 628);
            this.btnReservation.Name = "btnReservation";
            this.btnReservation.Size = new System.Drawing.Size(134, 37);
            this.btnReservation.TabIndex = 15;
            this.btnReservation.Text = "Reservation";
            this.btnReservation.Click += new System.EventHandler(this.btnReservation_Click);
            // 
            // ctrlUserCard1
            // 
            this.ctrlUserCard1.Location = new System.Drawing.Point(0, 42);
            this.ctrlUserCard1.Name = "ctrlUserCard1";
            this.ctrlUserCard1.Size = new System.Drawing.Size(630, 137);
            this.ctrlUserCard1.TabIndex = 17;
            // 
            // ctrlReservationCard1
            // 
            this.ctrlReservationCard1.Location = new System.Drawing.Point(1, 434);
            this.ctrlReservationCard1.Name = "ctrlReservationCard1";
            this.ctrlReservationCard1.Size = new System.Drawing.Size(630, 175);
            this.ctrlReservationCard1.TabIndex = 18;
            // 
            // frmRetrunBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(630, 677);
            this.Controls.Add(this.ctrlReservationCard1);
            this.Controls.Add(this.ctrlUserCard1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReservation);
            this.Controls.Add(this.ctrlCopyBookCard1);
            this.Name = "frmRetrunBook";
            this.Load += new System.EventHandler(this.frmRetrunBook_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Books.ctrlCopyBookCard ctrlCopyBookCard1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnReservation;
        private Users.ctrlUserCard ctrlUserCard1;
        private ctrlReservationCard ctrlReservationCard1;
    }
}
