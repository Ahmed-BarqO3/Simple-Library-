using Library_BusinessLogic;
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
    public partial class frmBorrowingBook : Library.Form1
    {
        int _CopyId;
        clsBorrowingRecords _borrowingRecords = new clsBorrowingRecords();
        public frmBorrowingBook(int CopyID)
        {
            InitializeComponent();
            _CopyId = CopyID; 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {

            _borrowingRecords.DueDate = dtpDueDate.Value;
            _borrowingRecords.UserID = ctrlUserCardWithFilter1.UserInfo.UserID;
            _borrowingRecords.CopyID = _CopyId;
            if (_borrowingRecords.Save())
                MessageBox.Show($"Borrowing success\nYou Should retrun the book in {dtpDueDate.Value.Date}","information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
                MessageBox.Show($"Borrowing Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Close();
        }

        private void frmBorrowingBook_Load(object sender, EventArgs e)
        {
            ctrlCopyBookCard1.LoadBookData(_CopyId);
            ctrlUserCardWithFilter1.FilterFocus();

            dtpDueDate.MinDate = DateTime.Now.Date.AddDays(1);
            dtpDueDate.MaxDate = dtpDueDate.MinDate.AddDays(clsSetting.GetSetting().BorrowDays - 1);

            lblPaymentStatus.Text = "Not Complete";
            lblBorrowingDate.Text = DateTime.Now.Date.ToShortDateString();
            

        }

        private bool ctrlUserCardWithFilter1_OnUserSelected(clsUser obj) => btnBorrow.Enabled = obj != null;

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {
           
            lblFine.Text = (clsSetting.GetSetting().FineperDaye * Convert.ToInt16(dtpDueDate.Value.Date.Subtract(DateTime.Now.Date).TotalDays)).ToString("C");
        }
    }
}
