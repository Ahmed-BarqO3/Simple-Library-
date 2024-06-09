using Library_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Library.Borrow___Reservations
{
    public partial class frmRetrunBook : Library.Form1
    {
        int _CopyID;
        clsBorrowingRecords Borrowing;
        public frmRetrunBook(int CopyID)
        {
            InitializeComponent();
            _CopyID = CopyID;
            Borrowing = clsBorrowingRecords.Find(CopyID); 
        }
        private void frmRetrunBook_Load(object sender, EventArgs e)
        {
            if (Borrowing is null )
            {
                //To Do
                return;
            }

            ctrlCopyBookCard1.LoadBookData(_CopyID);
            ctrlUserCard1.LoadUserInfo(Borrowing.UserID);
            ctrlReservationCard1.LoadCard(_CopyID);

            btnReservation.Enabled = Borrowing.BorrowingDate != DateTime.Now.Date;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            if (clsBorrowingRecords.ReservationBook(Borrowing.UserID, _CopyID, DateTime.Now))
                MessageBox.Show("Book Retrun Successfuly", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ctrlReservationCard1.LoadCard(_CopyID);

            Close();
        }
    }
}
