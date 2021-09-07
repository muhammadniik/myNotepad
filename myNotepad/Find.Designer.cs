
namespace myNotepad
{
    partial class Find
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.direction = new System.Windows.Forms.GroupBox();
            this.ridBtnDown = new System.Windows.Forms.RadioButton();
            this.ridBtnUp = new System.Windows.Forms.RadioButton();
            this.checkCase = new System.Windows.Forms.CheckBox();
            this.checkWarp = new System.Windows.Forms.CheckBox();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.direction.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find what:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(74, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(177, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(257, 16);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(257, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // direction
            // 
            this.direction.Controls.Add(this.ridBtnUp);
            this.direction.Controls.Add(this.ridBtnDown);
            this.direction.Location = new System.Drawing.Point(141, 61);
            this.direction.Name = "direction";
            this.direction.Size = new System.Drawing.Size(110, 36);
            this.direction.TabIndex = 3;
            this.direction.TabStop = false;
            this.direction.Text = "direction";
            // 
            // ridBtnDown
            // 
            this.ridBtnDown.AutoSize = true;
            this.ridBtnDown.Location = new System.Drawing.Point(45, 19);
            this.ridBtnDown.Name = "ridBtnDown";
            this.ridBtnDown.Size = new System.Drawing.Size(53, 17);
            this.ridBtnDown.TabIndex = 0;
            this.ridBtnDown.TabStop = true;
            this.ridBtnDown.Text = "Down";
            this.ridBtnDown.UseVisualStyleBackColor = true;
            // 
            // ridBtnUp
            // 
            this.ridBtnUp.AutoSize = true;
            this.ridBtnUp.Checked = true;
            this.ridBtnUp.Location = new System.Drawing.Point(0, 19);
            this.ridBtnUp.Name = "ridBtnUp";
            this.ridBtnUp.Size = new System.Drawing.Size(39, 17);
            this.ridBtnUp.TabIndex = 0;
            this.ridBtnUp.TabStop = true;
            this.ridBtnUp.Text = "Up";
            this.ridBtnUp.UseVisualStyleBackColor = true;
            // 
            // checkCase
            // 
            this.checkCase.AutoSize = true;
            this.checkCase.Location = new System.Drawing.Point(12, 81);
            this.checkCase.Name = "checkCase";
            this.checkCase.Size = new System.Drawing.Size(82, 17);
            this.checkCase.TabIndex = 4;
            this.checkCase.Text = "Match case";
            this.checkCase.UseVisualStyleBackColor = true;
            // 
            // checkWarp
            // 
            this.checkWarp.AutoSize = true;
            this.checkWarp.Location = new System.Drawing.Point(12, 104);
            this.checkWarp.Name = "checkWarp";
            this.checkWarp.Size = new System.Drawing.Size(88, 17);
            this.checkWarp.TabIndex = 4;
            this.checkWarp.Text = "Warp around";
            this.checkWarp.UseVisualStyleBackColor = true;
            // 
            // btnFindNext
            // 
            this.btnFindNext.Location = new System.Drawing.Point(257, 45);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(75, 23);
            this.btnFindNext.TabIndex = 2;
            this.btnFindNext.Text = "find next";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 141);
            this.Controls.Add(this.checkWarp);
            this.Controls.Add(this.checkCase);
            this.Controls.Add(this.direction);
            this.Controls.Add(this.btnFindNext);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Find";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find";
            this.Load += new System.EventHandler(this.Find_Load);
            this.direction.ResumeLayout(false);
            this.direction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox direction;
        private System.Windows.Forms.RadioButton ridBtnUp;
        private System.Windows.Forms.RadioButton ridBtnDown;
        private System.Windows.Forms.CheckBox checkCase;
        private System.Windows.Forms.CheckBox checkWarp;
        private System.Windows.Forms.Button btnFindNext;
    }
}