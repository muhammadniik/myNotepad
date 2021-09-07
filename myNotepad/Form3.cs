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
    public partial class Form3 : Form
    {
        Form1 form1;
        public int i = 0;
        public Form3(Form1 frm)
        {
            form1 = frm;
            InitializeComponent();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (form1.findtext(txtFind.Text , i))
            {
                i++;
            }
            else
            {
                MessageBox.Show("cant find...");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
