using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myNotepad
{
    public partial class Repleac : myNotepad.Find
    {
        Form1 frm1;
        public Repleac()
        {
            InitializeComponent();
        }
        public Repleac(Form1 form1) : base(form1)
        {
            frm1 = form1;
            InitializeComponent();
        }

        private void Repleac_Load(object sender, EventArgs e)
        {

        }

        private void btnReplec_Click(object sender, EventArgs e)
        {
            frm1.replace(txtReplace.Text);
        }

        private void btnReplacAll_Click(object sender, EventArgs e)
        {
            bool man = true;
            StringComparison compo;
            compo = StringComparison.Ordinal;
            if (checkCase.Checked)
                compo = StringComparison.OrdinalIgnoreCase;
            
            while (man)
            {
                man = frm1.findNext(txtSearch.Text, compo, ridBtnUp.Checked, checkWarp.Checked);
                frm1.replaceAll(txtReplace.Text, man);
            }
        }
    }
}
