namespace Library_DataAccess
{
    public class clsBookCopies
    {
        public int? CopyID { get; set; }
        public int BookID { get; set; }
        public bool AvailabilityStatus { get; set; }

        public clsBook Book { get; private set; }

        enum enMode { Add, Update }
        enMode Mode;

        public clsBookCopies()
        {
            CopyID = null;
            BookID = 0;
            AvailabilityStatus = true;

            Mode = enMode.Add;
        }
        clsBookCopies(int copyID, int bookID, bool availabilityStatus)
        {
            CopyID = copyID;
            BookID = bookID;
            AvailabilityStatus = availabilityStatus;
            Book = clsBook.Find(BookID);

            Mode = enMode.Update;
        }

        public static clsBookCopies Find(int CopyID)
        {

            int BookID = 0;
            bool AvailabilityStatus = false;
            if(clsDataBookCopies.FindByID(CopyID,ref BookID,ref AvailabilityStatus))
                return new clsBookCopies(CopyID,BookID,AvailabilityStatus);
            return null;
        }

        bool _Add()
        {
            CopyID = clsDataBookCopies.AddNew(BookID);
            return CopyID != null;

        }

        bool _Update() => clsDataBookCopies.Update(CopyID, BookID, AvailabilityStatus);
       static public bool Delete(int CopyID) => clsDataBookCopies.Delete(CopyID);
        

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _Update();

                default: return false;
            }
        }

    }

}
