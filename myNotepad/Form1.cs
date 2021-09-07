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
        Boolean isSaved = true;
        string fileN = "";
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
            foreach (ToolStripMenuItem a in backgroundColorToolStripMenuItem.DropDownItems)
            {
                if (a.Text == ((ToolStripMenuItem)sender).Text)
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
            else if (a == "Zoom Out" && zoom > 1)
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
            if (fonts.ShowDialog() != DialogResult.Cancel)
            {
                txtShow.Font = fonts.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colors = new ColorDialog();
            colors.Color = txtShow.ForeColor;
            if (colors.ShowDialog() != DialogResult.Cancel)
            {
                txtShow.ForeColor = colors.Color;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string backgroundName = txtShow.BackColor.Name;
            string forColorName = (Convert.ToInt32(txtShow.ForeColor.ToArgb())).ToString();

            System.IO.File.WriteAllText("all.txt", backgroundName + " " + forColorName + " ");
            if (isSaved == false)
            {
                DialogResult dr = MessageBox.Show("you want save this file", "saveing", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("all.txt"))
            {
                string[] allText = System.IO.File.ReadAllText("all.txt").Split(' ');


                //setbackcolor...........................
                ToolStripMenuItem temp = new ToolStripMenuItem();
                temp.Text = allText[0];
                backColor(temp, null);
                //setforcolor......................

                //txtShow.ForeColor = Color.FromArgb(Convert.ToInt32(allText[1]));

            }
            txtShow_TextChanged(null, null);

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (isSaved == false)
            {

                DialogResult dr = MessageBox.Show("want save this file", "saveing...", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    saveToolStripMenuItem_Click(null, null);
                isSaved = false;
            }
            txtShow.Text = "";
            fileN = "";

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (fileN == "")
            {
                saveFileDialog1.Filter = "all txt|*.txt|all file|*.*";
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                    fileN = saveFileDialog1.FileName;

            }
            if (isSaved == false && fileN != "")
            {
                System.IO.File.WriteAllText(fileN, txtShow.Text);
                isSaved = true;
            }



        }

        private void txtShow_TextChanged(object sender, EventArgs e)
        {
            isSaved = false;
            Boolean isEnable = Convert.ToBoolean(txtShow.Text.Length);

            searchToolStripMenuItem1.Enabled = isEnable;
            selectAllToolStripMenuItem.Enabled = isEnable;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileN = "";
            isSaved = false;
            saveFileDialog1.FileName = "";
            saveToolStripMenuItem_Click(null, null);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "all txt|*.txt|all file|*.*";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
                fileN = openFileDialog1.FileName;
            if (fileN != "")
                txtShow.Text = System.IO.File.ReadAllText(fileN);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = txtShow.SelectedText;

            if (a != "")
                Clipboard.SetText(a);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtShow.SelectedText = Clipboard.GetText();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(null, null);
            txtShow.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtShow.SelectAll();
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Find findForm = new Find(this);
            findForm.Show(this);
        }

        public bool find(string textSearch, StringComparison typcase , bool rithToLeft = true)
        {
            string txtBox = txtShow.Text;
            int i;
            if (rithToLeft)
                i = txtBox.IndexOf(textSearch, 0, typcase);
            else
                i = txtBox.LastIndexOf(textSearch,txtShow.Text.Length, typcase);

            if (i == -1)
            {
                MessageBox.Show("no find...");
                return false;
            }
            else
            {
                txtShow.SelectionStart = i;
                txtShow.SelectionLength = textSearch.Length;
                this.Focus();
                return true;

            }

        }

        public bool findNext(string textSearch, StringComparison typcase = StringComparison.Ordinal, bool rigthToLeft = true, bool warpAround = false)
        {
            string txtBox = txtShow.Text;
            int i;
            if (rigthToLeft)
            {
                int exam = txtShow.SelectionStart;
                i = txtBox.IndexOf(textSearch, exam + txtShow.SelectionLength, typcase);
                if(warpAround)
                {
                    if(i == -1)
                        i = txtBox.IndexOf(textSearch,0, typcase);
                }


            }
            else
            {
                int exam = txtShow.SelectionStart;
                
                    i = txtBox.LastIndexOf(textSearch, exam, typcase);
               
                if (warpAround)
                {
                    if (i == -1)
                        i = txtBox.LastIndexOf(textSearch, txtShow.Text.Length, typcase);
                }
            }



            if (i == -1)
            {
                MessageBox.Show("no find...");
                return false;
            }
            else
            {
                txtShow.SelectionStart = i;
                txtShow.SelectionLength = textSearch.Length;
                this.Focus();
                return true;

            }

        }
    }
}
