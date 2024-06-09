using Library_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Books
{
    public partial class ctrlBookCard : UserControl
    {

        int? _bookID;
        clsBook _book;
        public ctrlBookCard()
        {
            InitializeComponent();
        }

        public int? BookID => _bookID;
        public clsBook Book => _book;

        public void LoadBookData(int BookiD)
        {
            _book = clsBook.Find(BookiD);
            if(_book is null)
            {
                MessageBox.Show("No Book with Id = " + BookiD.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FiilBookCard();
        }

        public void LoadBookData(string Title)
        {
            _book = clsBook.Find(Title);
            if (_book is null)
            {
                MessageBox.Show("No Book with Title = " + Title, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FiilBookCard();
        }

        void _FiilBookCard()
        {       
                _bookID = _book.BookID;
                lblBookID.Text = _book.BookID.ToString();
                lblTitle.Text = _book.Title;
                lblisbn.Text = _book.ISBN;
                lblDate.Text = _book.PublicationDate.ToShortDateString();
                txtAdditionalDetails.Text = _book.AdditionalDetails;  
        }

    
    }
}
