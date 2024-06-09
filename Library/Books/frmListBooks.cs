using Library_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Library.Books
{
    public partial class frmListBooks : Library.Form1
    {
        public frmListBooks()
        {
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            frmAddBooks frm = new frmAddBooks();
            frm.ShowDialog();

            frmListBooks_Load(null, null);
        }

        private void frmListBooks_Load(object sender, EventArgs e)
        {
            dgvBooks.DataSource = clsBook.GetAllBooks();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddBook.PerformClick();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            if(dgvBooks.RowCount > 0) 
            {
                frmAddBooks frmEdit = new frmAddBooks((int)dgvBooks.CurrentRow.Cells[0].Value);
                frmEdit.ShowDialog();

                frmListBooks_Load(null, null);
            }
        }

        private void addCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvBooks.RowCount > 0)
            {
                frmAddCopy frm = new frmAddCopy((int)dgvBooks.CurrentRow.Cells[0].Value);
                frm.ShowDialog();

                frmListBooks_Load(null, null);
            }
        }
    }
}
