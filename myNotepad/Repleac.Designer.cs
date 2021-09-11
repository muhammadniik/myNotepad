
namespace myNotepad
{
    partial class Repleac
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReplacAll = new System.Windows.Forms.Button();
            this.btnReplec = new System.Windows.Forms.Button();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(257, 133);
            // 
            // direction
            // 
            this.direction.Location = new System.Drawing.Point(119, 104);
            // 
            // checkCase
            // 
            this.checkCase.Location = new System.Drawing.Point(12, 116);
            // 
            // checkWarp
            // 
            this.checkWarp.Location = new System.Drawing.Point(12, 139);
            // 
            // btnReplacAll
            // 
            this.btnReplacAll.Location = new System.Drawing.Point(257, 104);
            this.btnReplacAll.Name = "btnReplacAll";
            this.btnReplacAll.Size = new System.Drawing.Size(75, 23);
            this.btnReplacAll.TabIndex = 5;
            this.btnReplacAll.Text = "ReplacAll";
            this.btnReplacAll.UseVisualStyleBackColor = true;
            this.btnReplacAll.Click += new System.EventHandler(this.btnReplacAll_Click);
            // 
            // btnReplec
            // 
            this.btnReplec.Location = new System.Drawing.Point(257, 75);
            this.btnReplec.Name = "btnReplec";
            this.btnReplec.Size = new System.Drawing.Size(75, 23);
            this.btnReplec.TabIndex = 5;
            this.btnReplec.Text = "Replec";
            this.btnReplec.UseVisualStyleBackColor = true;
            this.btnReplec.Click += new System.EventHandler(this.btnReplec_Click);
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(74, 48);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(177, 20);
            this.txtReplace.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Replac";
            // 
            // Repleac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(351, 173);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.btnReplec);
            this.Controls.Add(this.btnReplacAll);
            this.Name = "Repleac";
            this.Load += new System.EventHandler(this.Repleac_Load);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.direction, 0);
            this.Controls.SetChildIndex(this.checkCase, 0);
            this.Controls.SetChildIndex(this.checkWarp, 0);
            this.Controls.SetChildIndex(this.btnReplacAll, 0);
            this.Controls.SetChildIndex(this.btnReplec, 0);
            this.Controls.SetChildIndex(this.txtReplace, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReplacAll;
        private System.Windows.Forms.Button btnReplec;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Label label2;
    }
}
