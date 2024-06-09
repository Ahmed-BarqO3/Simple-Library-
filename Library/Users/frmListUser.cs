using Library_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Library.Users
{
    public partial class frmListUser : Library.Form1
    {
        public frmListUser()
        {
            InitializeComponent();
        }

        DataTable dt; 
        void _RfreachData()
        {
            dt = clsUser.GetAllUsers();
            dgvUsers.DataSource = dt;


            if (dt.Rows.Count > 0)
            {
                dgvUsers.Columns[2].HeaderText = "Email";
                dgvUsers.Columns[3].HeaderText = "Card Number";

                dgvUsers.Columns[1].Width = 200;
                dgvUsers.Columns[2].Width = 300;
                dgvUsers.Columns[3].Width = 200;
            }

        }

        private void frmListUser_Load(object sender, EventArgs e)
        {
            _RfreachData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            frmAddUser frm = new frmAddUser();
            frm.ShowDialog();

            frmListUser_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Id = (int)dgvUsers.CurrentRow.Cells[0].Value ;
            
          
                if(MessageBox.Show($"Do you want to delete this user[{Id}]","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    clsUser.Delete(Id);

                frmListUser_Load(null , null);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUser frm = new frmAddUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListUser_Load(null, null);
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUser frm = new frmAddUser();
            frm.ShowDialog();

            frmListUser_Load(null, null);
        }
    }
}
