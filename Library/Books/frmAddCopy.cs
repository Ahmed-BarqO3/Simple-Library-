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
    public partial class frmAddCopy : Library.Form1
    {
        int _BookID;
        clsBookCopies _BookCopies = new clsBookCopies();
        public frmAddCopy(int BookID)
        {
            InitializeComponent();
            _BookID = BookID;
            _BookCopies.BookID = _BookID;
        }

        private void fmrAddCopy_Load(object sender, EventArgs e)
        {
            if(_BookID == 0)
            {
                return;
            }
            
            ctrlBookCard1.LoadBookData(_BookID);
        }

      
        private void NumCopies_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = NumCopies.Value > 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool SaveData = true; 
            for(int i = 0; i < NumCopies.Value; i++)
            {
                if (_BookCopies.Save() == false)
                    SaveData = false;
            }

            if(SaveData)
            {
                MessageBox.Show("Copies Book are Added successfuly", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("something went wrong at added CopyBook", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Close();

        }
    }
}
