using System;
using System.Data;

namespace Library_DataAccess
{
    public class clsBorrowingRecords
    {
        enum enMode { Add, Updte }
        enMode Mode;

        public int? BorrowingRecordID { get; set; }
        public int? UserID { get; set; }
        public int CopyID { get; set; }
        public DateTime BorrowingDate { get; private set; }
        public DateTime DueDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public clsBookCopies BookCopy{ get; private set; }

        public clsBorrowingRecords()
        {
            BorrowingRecordID = 0;
            UserID = 0;
            CopyID = 0;
            DueDate = DateTime.Now.Date;
            BorrowingDate = DateTime.Now.Date;
            ActualReturnDate = null;


            Mode = enMode.Add;

        }

        clsBorrowingRecords(int borrowingRecordID, int userID, int copyID,
           DateTime borrowingDate, DateTime dueDate, DateTime? actualReturnDate)
        {
            BorrowingRecordID = borrowingRecordID;
            UserID = userID;
            CopyID = copyID;
            BorrowingDate = borrowingDate;
            DueDate = dueDate;
            ActualReturnDate = actualReturnDate;
            BookCopy = clsBookCopies.Find(CopyID);

            Mode = enMode.Updte;
        }

        public static clsBorrowingRecords Find(int CopyiD)
        {
            int borrowingRecordID = 0, UseriD = 0;
            DateTime borrowing, dueDate = DateTime.Now.Date;
            borrowing = DateTime.Now.Date;
            DateTime? actualReturnDate = null;

            if (clsDataBorrow.FindByID(CopyiD, ref UseriD, ref borrowingRecordID, ref borrowing, ref dueDate, ref actualReturnDate))
                return new clsBorrowingRecords(borrowingRecordID, UseriD, CopyiD, borrowing, dueDate, actualReturnDate);
            else
                return null;
        }

        bool _Add()
        {
            BorrowingRecordID = clsDataBorrow.AddNew(CopyID, UserID, BorrowingDate, DueDate);
            return BorrowingRecordID != null;
        }

        bool _Update() => clsDataBorrow.Update(BorrowingRecordID, CopyID, UserID, BorrowingDate, DueDate, ActualReturnDate);
        public static bool Delete(int BorrowingID) => clsDataBorrow.Delete(BorrowingID);
        public static bool IsExist(int BorrowingID) => clsDataBorrow.IsExist(BorrowingID);
        public static DataTable GetAllBorrowing() => clsDataBorrow.GetAllBorrowing();
        public static bool Cancel(int CopyID) => clsDataBorrow.CancelBorrow(CopyID);

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_Add())
                    {
                        Mode = enMode.Updte;
                        return true;
                    }
                    else
                        return false;
                case enMode.Updte:
                    return _Update();

                default: return false;
            }
        }

        public static bool ReservationBook(int? UserID,int CopyID,DateTime ReservationDate) =>
            clsDataBorrow.ReservationBook(UserID, CopyID, ReservationDate);
            
    }
}
