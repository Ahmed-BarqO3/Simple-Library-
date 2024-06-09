using Library.Books;
using Library.Borrow___Reservations;
using Library.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (pnlSideBar.Width is 195)
                pnlSideBar.Width = 37;
            else
                pnlSideBar.Width = 195;
        }

     

        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            frmListBooks frm = new frmListBooks();
            frm.ShowDialog();
        }

        private void btnStduent_Click(object sender, EventArgs e)
        {
            frmListUser frm = new frmListUser();
            frm.ShowDialog();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            var frm = new frmBorrowManagement();
            frm.ShowDialog();
        }
    }
}
