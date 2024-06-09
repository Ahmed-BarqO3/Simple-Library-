using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Library_DataAccess
{
    public class clsUser
    {
        enum eMode { AddNew, Update };

        public int? UserID { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public string LibraryCardNumber { get; set; }
        eMode Mode { get; set; }

        string GenrateCardNumber()
        {
            Guid GUID = Guid.NewGuid();
            string CardNUmber = GUID.ToString();

            return CardNUmber.Substring(0, 8);

        }

        public clsUser()
        {
            UserID = null;
            Name = null;
            ContactInformation = null;
            LibraryCardNumber = null;

            Mode = eMode.AddNew;
        }

        clsUser(int? userID, string name, string contactInformation, string libraryCardNumber)
        {
            UserID = userID;
            Name = name;
            ContactInformation = contactInformation;
            LibraryCardNumber = libraryCardNumber;

            Mode = eMode.Update;
        }
        public static clsUser Find(int? UserID)
        {
            string name = "", contact = "", cardnumber = "";
            if (clsDataUsers.FindUserByID(UserID, ref name, ref contact, ref cardnumber))
                return new clsUser(UserID, name, contact, cardnumber);
            else
                return null;

        }

        public static clsUser Find(string cardnumber)
        {
            string name = "", contact = "";
            int UserID = 0;

            if (clsDataUsers.FindUserByCardNum(ref UserID, ref name, ref contact,  cardnumber))
                return new clsUser(UserID, name, contact, cardnumber);
            else
                return null;

        }

        bool _AddNew()
        {

            LibraryCardNumber = GenrateCardNumber();
            UserID = clsDataUsers.AddNew(Name, ContactInformation, LibraryCardNumber);

            return UserID != null;
        }

        public static bool Delete(int UserID) => clsDataUsers.Delete(UserID);
        bool _Update() => clsDataUsers.Update(Name, ContactInformation, UserID);
        public static DataTable GetAllUsers() => clsDataUsers.GetAllUsers();
        public static bool IsExist(int UserID) => clsDataUsers.IsUserExist(UserID);

        public bool Save()
        {
            switch (Mode)
            {
                case eMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = eMode.Update;
                        return true;
                    }
                    else
                        return false;
                case eMode.Update:
                    return _Update();
                default: return false;
            }
        }

    

        
      
    }

    


  
}
