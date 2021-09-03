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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void backColor(object sender, EventArgs e)
        {
            txtShow.BackColor = Color.FromName(((ToolStripMenuItem)sender).Text);
            foreach(ToolStripMenuItem a in backgroundColorToolStripMenuItem.DropDownItems)
            {
                if(a.Text == ((ToolStripMenuItem)sender).Text)
                {
                    a.Checked = true;
                }
                else
                {
                    a.Checked = false;
                }
            }
        }

        private void zoom(object sender, EventArgs e)
        {
            string a = ((ToolStripMenuItem)sender).Text;
            float zoom = txtShow.ZoomFactor;
            if (a == "Zoom In" && zoom < 10)
            {
               
                txtShow.ZoomFactor += 1f;
            }
            else if(a == "Zoom Out" && zoom > 1)
            {
                txtShow.ZoomFactor -= 1f;

            }
            else
            {
                txtShow.ZoomFactor = 1f;

            }

        }

        private void wordwarpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtShow.WordWrap = wordwarpToolStripMenuItem.Checked;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fonts = new FontDialog();
            fonts.Font = txtShow.Font;
            if(fonts.ShowDialog() != DialogResult.Cancel)
            {
                txtShow.Font = fonts.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colors = new ColorDialog();
            colors.Color = txtShow.ForeColor;
            if(colors.ShowDialog() != DialogResult.Cancel)
            {
                txtShow.ForeColor = colors.Color;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
