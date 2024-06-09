using Library_DataAccess;
using System.Windows.Forms;

namespace Library.Users
{
    public partial class ctrlUserCard : UserControl
    {

        int? _UserID;
        clsUser _User;

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public int? UserID => _UserID;
        public clsUser User => _User;   

        void  _FillUserCard()
        {
            _UserID = _User.UserID;
            lblUserID.Text = _UserID.ToString();
            lblName.Text = _User.Name;
            lblEmail.Text = _User.ContactInformation;
            lblCardNumber.Text = _User.LibraryCardNumber;
        }

        void _RestScreen()
        {
            
            lblUserID.Text = "???";
            lblName.Text = "???";
            lblEmail.Text = "???";
            lblCardNumber.Text = "???"; 
        }


        public void LoadUserInfo(int? userId)
        {
            _User = clsUser.Find(userId);

            if(_User is null)
            {
                MessageBox.Show("No User with ID = " + userId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _RestScreen();
                return;
            }
            _FillUserCard();
        }

        public void LoadUserInfo(string cardNum)
        {
            _User = clsUser.Find(cardNum);

            if (_User is null)
            {
                MessageBox.Show("No User with Card Number = " + cardNum, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _RestScreen();
                return;
            }
            _FillUserCard();
        }
    }
}
