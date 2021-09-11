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
    public partial class Find : Form
    {
        Form1 form1;
        public int i = 0;
        public Find(Form1 frm)
        {
            form1 = frm;
            InitializeComponent();
        }
        public Find()
        {
            
            InitializeComponent();
        }

        private void Find_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            StringComparison compo;
            compo = StringComparison.Ordinal;
            if (checkCase.Checked)
                compo = StringComparison.OrdinalIgnoreCase;
            
            bool find =form1.find(txtSearch.Text,compo,ridBtnUp.Checked);
            if (find == false)
                btnFind.Enabled = false;
            else
                btnFind.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnFind.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            StringComparison compo;
            compo = StringComparison.Ordinal;
            if (checkCase.Checked)
                compo = StringComparison.OrdinalIgnoreCase;
            form1.findNext(txtSearch.Text, compo, ridBtnUp.Checked, checkWarp.Checked);
        }
    }
}

