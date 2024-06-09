using System;
using System.Data;

namespace Library_DataAccess
{
    public class clsBook
    {
        enum enMode { Add, Update}
        enMode Mode { get; set; }

        public int? BookID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public string AdditionalDetails { get; set;}

        public clsBook()
        {
            BookID = null;
            Title = null;
            ISBN = null;
            PublicationDate = default;
            AdditionalDetails = null;

            Mode = enMode.Add;
        }

        clsBook(int? bookID, string title, string iSBN, DateTime publicationDate, string additionalDetails)
        {
            BookID = bookID;
            Title = title;
            ISBN = iSBN;
            PublicationDate = publicationDate;
            AdditionalDetails = additionalDetails;

            Mode = enMode.Update;
        }

        public static clsBook Find(int BookID)
        {

            string Title = "", isbn = "", additionalDetails ="";
            DateTime publicationDate = default;

            if (clsDataBook.FindByID(BookID, ref Title, ref isbn, ref publicationDate, ref additionalDetails))
                return new clsBook(BookID, Title, isbn, publicationDate,additionalDetails);
            else
                return null;
        }

        public static clsBook Find(string Title)
        {

            int BookID = 0;string isbn = "", additionalDetails = "";
            DateTime publicationDate = default;

            if (clsDataBook.FindByTitle(ref BookID,  Title, ref isbn, ref publicationDate, ref additionalDetails))
                return new clsBook(BookID, Title, isbn, publicationDate, additionalDetails);
            else
                return null;
        }

        public static clsBook FindbyISNB(string isbn)
        {

            int BookID = 0; string Title = "", additionalDetails = "";
            DateTime publicationDate = default;

            if (clsDataBook.FindByISBN(ref BookID, ref Title,  isbn, ref publicationDate, ref additionalDetails))
                return new clsBook(BookID, Title, isbn, publicationDate, additionalDetails);
            else
                return null;
        }


        bool _AddNew()
        {
            BookID = clsDataBook.AddNew(Title, ISBN,PublicationDate,AdditionalDetails);

           return BookID != null;
        }

        bool _Update() => clsDataBook.Update(BookID, Title, ISBN, AdditionalDetails);
        public static bool Delete(int BookID) => clsDataBook.Delete(BookID);
        public static DataTable GetAllBooks() => clsDataBook.GetAllBooks();
        public static bool IsExist(int BookID) => clsDataBook.IsBookExist(BookID);

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNew())
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
