namespace DeptDets
{
    partial class MessageTeacher
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
            this.lstTeachers = new System.Windows.Forms.ListBox();
            this.btnEmail = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstTeachers
            // 
            this.lstTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTeachers.FormattingEnabled = true;
            this.lstTeachers.ItemHeight = 16;
            this.lstTeachers.Location = new System.Drawing.Point(21, 12);
            this.lstTeachers.Name = "lstTeachers";
            this.lstTeachers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTeachers.Size = new System.Drawing.Size(193, 404);
            this.lstTeachers.TabIndex = 32;
            // 
            // btnEmail
            // 
            this.btnEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEmail.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.Location = new System.Drawing.Point(131, 438);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(121, 34);
            this.btnEmail.TabIndex = 31;
            this.btnEmail.Text = "Send Email";
            this.btnEmail.UseVisualStyleBackColor = false;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Indigo;
            this.lblTitle.Location = new System.Drawing.Point(220, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(197, 404);
            this.lblTitle.TabIndex = 33;
            this.lblTitle.Text = "Staff Title";
            // 
            // MessageTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 490);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstTeachers);
            this.Controls.Add(this.btnEmail);
            this.Name = "MessageTeacher";
            this.Text = "MessageTeacher";
            this.Load += new System.EventHandler(this.MessageTeacher_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTeachers;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label lblTitle;
    }
}