namespace Library_DataAccess
{
    public class clsFines
    {
        public int FineID { get; set; }
        public int UserID { get; set; }
        public int BorrowingRecordID { get; set; }
        public byte NumberOfLateDays { get; set; }
        public decimal FineAmount { get; set; }
        public bool PaymentStatus { get; set; }

         clsFines(int fineID, int userID, int borrowingRecordID, byte numberOfLateDays, decimal fineAmount, bool paymentStatus)
        {
            FineID = fineID;
            UserID = userID;
            BorrowingRecordID = borrowingRecordID;
            NumberOfLateDays = numberOfLateDays;
            FineAmount = fineAmount;
            PaymentStatus = paymentStatus;
        }

        public static clsFines LoadFinesInfo(int CopyID)
        {
            int FineID = 0, UserId =0, borrowingRecordID = 0;
            byte LateDays = 0;
            decimal amount = 0;
            bool paymentStatus = false;

            if(clsDataFines.GetFineInfo(CopyID,ref borrowingRecordID,ref FineID,ref UserId,ref LateDays,ref amount,ref paymentStatus))
                return new clsFines(FineID,UserId,borrowingRecordID, LateDays,amount,paymentStatus);
            
            return null;
        }
    }



}
