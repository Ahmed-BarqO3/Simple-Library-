using Library_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Library.Borrow___Reservations
{
    public partial class frmBorrowManagement : Library.Form1
    {
        DataTable dt = new DataTable();
        public frmBorrowManagement()
        {
            InitializeComponent();
        }

        private void frmBorrowManagement_Load(object sender, EventArgs e)
        {
            dt = clsBorrowingRecords.GetAllBorrowing();
            dgvBorrowing.DataSource = dt;

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilter.Text)
            {
                case "CopyID":
                    break;

                case "Title":
                    break;

                case "Availability":
                    break;

            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
            {
                dgvBorrowing.DataSource = clsBorrowingRecords.GetAllBorrowing();
                return;
            }

            else if (cbFilter.Text == "CopyID" && !String.IsNullOrEmpty(txtFilter.Text))
                dt.DefaultView.RowFilter = $"{cbFilter.Text} = {txtFilter.Text.Trim()}";
            else if (!String.IsNullOrEmpty(txtFilter.Text))
                dt.DefaultView.RowFilter = $"{cbFilter.Text} LIKE \'%{txtFilter.Text.Trim()}%\'";
             dgvBorrowing.DataSource = dt;  
        }

        private void cmsBorrowing_Opening(object sender, CancelEventArgs e)
        {
            borrowToolStripMenuItem.Enabled = (dgvBorrowing.CurrentRow.Cells["Availability"].Value.ToString() == "YES");
            returnToolStripMenuItem.Enabled = (dgvBorrowing.CurrentRow.Cells["Availability"].Value.ToString() == "NO");

            deleteBookToolStripMenuItem.Enabled = (dgvBorrowing.CurrentRow.Cells["Availability"].Value.ToString() == "YES");

            if (dgvBorrowing.CurrentRow.Cells["Availability"].Value.ToString() == "NO")
            {
                cancelToolStripMenuItem.Enabled = clsBorrowingRecords.Find((int)dgvBorrowing.CurrentRow.Cells[0].Value)
                                                                .BorrowingDate.Equals(DateTime.Now.Date);
            }
        }

        private void borrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBorrowingBook frm = new frmBorrowingBook((int)dgvBorrowing.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmBorrowManagement_Load(null, null);
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRetrunBook fmr = new frmRetrunBook((int)dgvBorrowing.CurrentRow.Cells[0].Value);
            fmr.ShowDialog();

            frmBorrowManagement_Load(null, null);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBorrowingRecords.Cancel((int)dgvBorrowing.CurrentRow.Cells[0].Value);
            frmBorrowManagement_Load(null, null);

        }

        private void deleteBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Id = (int)dgvBorrowing.CurrentRow.Cells[0].Value;
            if (MessageBox.Show($"Do you want to delete this user[{Id}]", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                if (clsBookCopies.Delete(Id))
                    MessageBox.Show("Copy Book Deleted succssfuly", "Delete",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
                    MessageBox.Show("Copy Book Deleted Failed", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
