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

namespace Library.Users
{
    public partial class ctrlUserCardWithFilter : UserControl
    {

        public event Predicate<clsUser> OnUserSelected;
        
        public ctrlUserCardWithFilter()
        {
            InitializeComponent();
        }

        public clsUser UserInfo => ctrlUserCard1.User;
        public void FilterFocus() => txtFilter.Focus();


        void _FindUser()
        {
            switch (cbFilter.Text)
            {
                case "User ID":
                    ctrlUserCard1.LoadUserInfo(int.Parse(txtFilter.Text));                 
                    break;
                case "Card Numbre":
                    ctrlUserCard1.LoadUserInfo(txtFilter.Text);
                    break;
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {     
                _FindUser();
                if (OnUserSelected != null)
                    OnUserSelected(UserInfo);
            }

            if (cbFilter.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Clear();
            txtFilter.Focus();
        }
    }
}
