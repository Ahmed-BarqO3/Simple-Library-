using Library_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace Library.Books
{
    public partial class ctrlCopyBookCard : UserControl
    {

        public clsBookCopies Copy;
 
        public ctrlCopyBookCard()
        {
            InitializeComponent();
        }

        public void LoadBookData(int copyiD)
        {
            Copy = clsBookCopies.Find(copyiD);

            if (Copy is null)
            {
                MessageBox.Show("No Book with Id = " + copyiD.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FiilCopyBookCard();
        }

      

        void _FiilCopyBookCard()
        {
            lblCopyID.Text = Copy.CopyID.ToString();
            lblBookID.Text = Copy.BookID.ToString();
            lblTitle.Text = Copy.Book.Title;
            lblisbn.Text = Copy.Book.ISBN;
            lblDate.Text = Copy.Book.PublicationDate.ToShortDateString();
            txtAdditionalDetails.Text = Copy.Book.AdditionalDetails;
        }

      
    }
}
