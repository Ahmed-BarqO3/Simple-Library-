using Library_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Library.Books
{
    public partial class frmAddBooks : Library.Form1
    {
        enum enMode { Add,Update}
        enMode Mode;

        clsBook Book;

        public frmAddBooks()
        {
            InitializeComponent();
            Mode = enMode.Add;

            Book = new clsBook();
        }

        public frmAddBooks(int BookID)
        {
            InitializeComponent();
            Mode = enMode.Update;

            Book = clsBook.Find(BookID);     
            
            if(Book is null )
                MessageBox.Show($"Book not found BookID[{BookID}]", "Not Found",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        void _RestScreen()
        {
                lblMain.Text = "Add Book";

                txtISBN.Clear();
                txtTitle.Clear();
                dtpDate.Value = DateTime.Now.Date;
        }
        void _FillScreen()
        {
            if(Mode == enMode.Update && Book != null)
            {
                lblMain.Text = "Update Book";

                txtISBN.Text = Book.ISBN;
                txtTitle.Text = Book.Title;
                dtpDate.Value = Book.PublicationDate;
                txtAdditionalDetails.Text = Book.AdditionalDetails;
            }
        }
        private void frmAddBooks_Load(object sender, EventArgs e)
        {
            dtpDate.MaxDate = dtpDate.Value = DateTime.Now.Date;
            _FillScreen();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Book.Title = txtTitle.Text;
            Book.ISBN = txtISBN.Text;   
            Book.PublicationDate = dtpDate.Value;
            Book.AdditionalDetails = txtAdditionalDetails.Text;

            if(Book.Save())
            {
                MessageBox.Show("Data Saved successfuly", "Data Saved",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data not Saved successfuly", "Data Saved",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);


           if (Mode == enMode.Add)
                _RestScreen();
           else
                Close();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtTitle.Text))

            {
                errorProvider1.SetError(txtTitle, "This field is recuairred");
                e.Cancel = true;
            }

            else
                errorProvider1.SetError(txtTitle, "");

        }

        private void txtISBN_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtISBN.Text))
            {
                errorProvider1.SetError(txtISBN, "This field is recuairred");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtISBN, "");
        }
    }
}
