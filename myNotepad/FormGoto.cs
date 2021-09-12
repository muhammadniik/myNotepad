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
    }
}
