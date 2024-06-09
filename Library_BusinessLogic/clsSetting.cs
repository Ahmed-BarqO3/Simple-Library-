using Library_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_BusinessLogic
{
    public  class clsSetting
    {
        public byte BorrowDays { get; set; }
        public decimal FineperDaye { get; set; }

        clsSetting(byte borrowDays, decimal fineperDaye)
        {
            BorrowDays = borrowDays;
            FineperDaye = fineperDaye;
        }

       

        public static clsSetting GetSetting()
        {
            byte defultBorrwoDaye = 0;
            decimal FineperDaye = 0;
            if (clsDataSetting.GetSetting(ref defultBorrwoDaye, ref FineperDaye))
                return new clsSetting(defultBorrwoDaye, FineperDaye);
            return null;
        }
        public bool Update() => clsDataSetting.Update(BorrowDays, FineperDaye);
    }
}
