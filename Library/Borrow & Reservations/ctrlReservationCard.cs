using Library_BusinessLogic;
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

namespace Library.Borrow___Reservations
{
    public partial class ctrlReservationCard : UserControl
    {
  
        clsBorrowingRecords borrowingRecords;
        clsFines fines;
        public ctrlReservationCard()
        {
            InitializeComponent();
        }


        void _FillCard()
        {
            lblBorrowingDate.Text = borrowingRecords.BorrowingDate.ToShortDateString();
            lblDueDate.Text = borrowingRecords.DueDate.ToShortDateString();
            lblActualDate.Text = DateTime.Now.ToShortDateString();
            lblLateDays.Text = DateTime.Now.Date.Subtract(borrowingRecords.DueDate.Date).TotalDays.ToString();

            if (int.Parse(lblLateDays.Text) < 0)
                lblLateDays.Text = "0";

            lblFine.Text =(clsSetting.GetSetting().FineperDaye *  Convert.ToInt16(DateTime.Now.Date.Subtract(borrowingRecords.BorrowingDate.Date).TotalDays)).ToString("C");

            if (fines.PaymentStatus)
                lblPaymentStatus.Text = "Complete";
            else
                lblPaymentStatus.Text = "Not Complete";
        }
        public void LoadCard(int CopyID)
        {
            borrowingRecords = clsBorrowingRecords.Find(CopyID);
            fines = clsFines.LoadFinesInfo(CopyID);

            if (borrowingRecords is null || fines is null )
            {
                //To Do
                return;
            }
            _FillCard();
        }
    }
}

