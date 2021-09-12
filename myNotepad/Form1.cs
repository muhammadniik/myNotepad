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
        Boolean isSaved;
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
            //string backgroundName = txtShow.BackColor.Name;
            //string forColorName = (Convert.ToInt32(txtShow.ForeColor.ToArgb())).ToString();

            // System.IO.File.WriteAllText("all.txt", backgroundName + " " + forColorName + " ");
            string[] infosave = new string[7];
            infosave[0] = txtShow.Font.Name;
            infosave[1] = txtShow.Font.Size.ToString();
            infosave[2] = txtShow.BackColor.Name;
            infosave[3] = txtShow.ForeColor.ToArgb().ToString();
            infosave[4] = this.Size.Height.ToString();
            infosave[5] = this.Size.Width.ToString();


            System.IO.File.WriteAllLines("all.txt", infosave);


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

                string[] allText = System.IO.File.ReadAllLines("all.txt");

                txtShow.Font = new Font(allText[0], float.Parse(allText[1],System.Globalization.CultureInfo.InvariantCulture));
                txtShow.BackColor = Color.FromName(allText[2]);
                txtShow.ForeColor = Color.FromArgb(Convert.ToInt32(allText[3]));
                this.Height = Convert.ToInt32(allText[4]);
                this.Width = Convert.ToInt32(allText[5]);
                //setbackcolor...........................
                ToolStripMenuItem temp = new ToolStripMenuItem();
                temp.Text = allText[2];
                backColor(temp, null);
                //setforcolor......................

                //txtShow.ForeColor = Color.FromArgb(Convert.ToInt32(allText[1]));

            }
            txtShow_TextChanged(null, null);
            isSaved = true;

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
            newToolStripMenuItem_Click(null, null);
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

        public bool find(string textSearch, StringComparison typcase, bool rithToLeft = true)
        {
            string txtBox = txtShow.Text;
            int i;
            if (rithToLeft)
                i = txtBox.IndexOf(textSearch, 0, typcase);
            else
                i = txtBox.LastIndexOf(textSearch, txtShow.Text.Length, typcase);

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
                if (warpAround)
                {
                    if (i == -1)
                        i = txtBox.IndexOf(textSearch, 0, typcase);
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
        undoVaRedo undoredo = new undoVaRedo();
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtShow.Text = undoredo.undo();
        }

        private void txtShow_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {


        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtShow.Text = undoredo.redo();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            undoredo.setText(txtShow.Text);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Repleac replac = new Repleac(this);
            replac.Show(this);
        }





        public bool replace(string textReplac)
        {
            if (txtShow.SelectedText.Length != 0)
            {
                txtShow.SelectedText = textReplac;
                this.Focus();
                return true;
            }
            else
                return false;


        }
        public bool replaceAll(string text, bool findNext)
        {
            while (findNext)
            {

                txtShow.SelectedText = text;
                return true;
            }
            return false;
        }

        public Boolean gotometod(int numberline)
        {
            if (numberline > txtShow.Lines.Length || numberline < 0)
            {
                MessageBox.Show("this line out of range...");
                return false;
            }

            else
            {
                txtShow.SelectionStart = txtShow.GetFirstCharIndexFromLine(numberline);
                return true;
            }
        }

        private void gotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGoto frmgoto = new FormGoto(this);
            frmgoto.ShowDialog();

        }

        private void txtShow_KeyUp_1(object sender, KeyEventArgs e)
        {
            int firstchar = txtShow.GetFirstCharIndexOfCurrentLine();
            int ln = txtShow.GetLineFromCharIndex(firstchar) + 1;
            int col = (txtShow.SelectionStart - firstchar);
            toolStripStatusLine.Text = "Ln " + ln + ", Col " + col;
        }

        private void txtShow_Click(object sender, EventArgs e)
        {
            txtShow_KeyUp_1(null, null);
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = !isSaved;
            bool lenttextshow = txtShow.Text.Length > 0;
            cutToolStripMenuItem.Enabled = lenttextshow;
            copyToolStripMenuItem.Enabled = lenttextshow;
            pasteToolStripMenuItem.Enabled = Clipboard.ContainsText();
            searchToolStripMenuItem1.Enabled = lenttextshow;
            replaceToolStripMenuItem.Enabled = lenttextshow;
            gotoToolStripMenuItem.Enabled = txtShow.Lines.Length > 1;
            selectAllToolStripMenuItem.Enabled = lenttextshow;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            
            dg = printDialog1.ShowDialog();
            if (dg == DialogResult.OK)
                printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           e.Graphics.DrawString(txtShow.Text, txtShow.Font, Brushes.Black, 100, 100);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();
        }
    }






    // nex class...................................................
    public class undoVaRedo
    {
        List<string> texts = new List<string>();
        int i;
        int nowInt;
        public undoVaRedo()
        {
            i = 0;
            nowInt = i;
        }

        public void setText(string textnew)
        {
            if (i <= 100)
            {
                texts.Add(textnew);
                nowInt = i;
                ++i;
            }
            else
            {
                texts.Remove(texts[0]);
                texts.Add(textnew);
                i = 101;
            }

        }
        public string undo()
        {
            if (nowInt > 0)
                return texts[--nowInt];
            return null;


        }

        public string redo()
        {
            if (i > nowInt + 1)
                return texts[++nowInt];
            return texts[nowInt];



        }
    }


}
