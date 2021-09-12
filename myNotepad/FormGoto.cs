using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myNotepad
{
    public partial class FormGoto : Form
    {
        Form1 frm1;
        public FormGoto(Form1 form)
        {
            frm1 = form;
            InitializeComponent();
        }

        private void txtGoto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
             bool i = frm1.gotometod(Convert.ToInt32(txtGoto.Text) -1);
            if (i)
                this.Close();
        }

        private void FormGoto_Load(object sender, EventArgs e)
        {
            txtGoto.Text = frm1.returnallLines().ToString();
            txtGoto.SelectAll();
        }

        private void txtGoto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar =='\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
