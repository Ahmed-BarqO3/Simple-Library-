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

namespace Library.Books
{
    public partial class ctrlBookCardWithFilter : UserControl
    {
        public ctrlBookCardWithFilter()
        {
            InitializeComponent();
        }
        public void FilterFocus() => txtFilter.Focus();
        public clsBook BookInfo => ctrlBookCard1.Book;

        void FindBook()
        {
            switch (cmbFilter.Text)
            {
                case "Book ID":
                    ctrlBookCard1.LoadBookData(int.Parse(txtFilter.Text));
                    break;
                case "Title":
                    ctrlBookCard1.LoadBookData(txtFilter.Text);
                    break;
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Clear();
            txtFilter.Focus();
        }

      

 
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                FindBook();


            if (cmbFilter.Text == "Book ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

      

        private void ctrlBookCardWithFilter_Load(object sender, EventArgs e)
        {
            txtFilter.Clear();
            txtFilter.Focus();
        }
    }
}
