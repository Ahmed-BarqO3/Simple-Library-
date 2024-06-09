using Library_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Library.Users
{
    public partial class frmAddUser : Library.Form1
    {

        enum enMode { Add,Update};
        enMode Mode;

        clsUser User;

        public frmAddUser()
        {
            InitializeComponent();

            Mode = enMode.Add;
            User = new clsUser();   
        }
        public frmAddUser(int ID)
        {
            InitializeComponent();

            Mode = enMode.Update;
            User = clsUser.Find(ID);

            if(User == null)
            {
                MessageBox.Show("User not Found","Not Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        public static bool ValidateEmail(string emailAddress)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }

        void _RestScreen()
        {
            txtName.Clear();
            txtEmail.Clear();

            lblMain.Text = "Add User";
            lblCardNumber.Text = "???";
        }


        void _FillScreen()
        {
            lblMain.Text = "Update User";
            txtName.Text = User.Name;
            txtEmail.Text = User.ContactInformation;
            lblCardNumber.Text = User.LibraryCardNumber;

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            { 
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Mode == enMode.Add)
            {
                User.Name = txtName.Text;
                User.ContactInformation = txtEmail.Text;
            }


                if(User.Save())
                {
                    MessageBox.Show($"Data Saved successfuly withe CardNumber[{User.LibraryCardNumber}]","Data Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                MessageBox.Show("Something wret wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if(Mode == enMode.Update)
                    Close();

                _RestScreen();  
        }


        private void frmAddUser_Load(object sender, EventArgs e)
        {
            if(Mode == enMode.Update)
            {
                _FillScreen();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if(!ValidateEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail,"Email not valid");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");

            }
        }
    }
}
