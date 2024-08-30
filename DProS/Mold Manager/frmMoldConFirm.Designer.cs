namespace DProS.Mold_Manager
{
    partial class frmMoldConFirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoldConFirm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMoldCode = new System.Windows.Forms.TextBox();
            this.chkPC = new System.Windows.Forms.CheckBox();
            this.chkQC = new System.Windows.Forms.CheckBox();
            this.chkTooling = new System.Windows.Forms.CheckBox();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lý do xác nhận:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(191, 139);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(458, 38);
            this.txtNote.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã khuôn:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "PB đã xác nhận";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMoldCode
            // 
            this.txtMoldCode.Enabled = false;
            this.txtMoldCode.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoldCode.Location = new System.Drawing.Point(191, 26);
            this.txtMoldCode.Multiline = true;
            this.txtMoldCode.Name = "txtMoldCode";
            this.txtMoldCode.Size = new System.Drawing.Size(458, 38);
            this.txtMoldCode.TabIndex = 4;
            // 
            // chkPC
            // 
            this.chkPC.AutoSize = true;
            this.chkPC.Enabled = false;
            this.chkPC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPC.Location = new System.Drawing.Point(191, 91);
            this.chkPC.Name = "chkPC";
            this.chkPC.Size = new System.Drawing.Size(90, 23);
            this.chkPC.TabIndex = 5;
            this.chkPC.Text = "Phòng PC";
            this.chkPC.UseVisualStyleBackColor = true;
            // 
            // chkQC
            // 
            this.chkQC.AutoSize = true;
            this.chkQC.Enabled = false;
            this.chkQC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkQC.Location = new System.Drawing.Point(373, 91);
            this.chkQC.Name = "chkQC";
            this.chkQC.Size = new System.Drawing.Size(93, 23);
            this.chkQC.TabIndex = 6;
            this.chkQC.Text = "Phòng QC";
            this.chkQC.UseVisualStyleBackColor = true;
            // 
            // chkTooling
            // 
            this.chkTooling.AutoSize = true;
            this.chkTooling.Enabled = false;
            this.chkTooling.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTooling.Location = new System.Drawing.Point(572, 91);
            this.chkTooling.Name = "chkTooling";
            this.chkTooling.Size = new System.Drawing.Size(72, 23);
            this.chkTooling.TabIndex = 7;
            this.chkTooling.Text = "Tooling";
            this.chkTooling.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(295, 207);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmMoldConFirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 265);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkTooling);
            this.Controls.Add(this.chkQC);
            this.Controls.Add(this.chkPC);
            this.Controls.Add(this.txtMoldCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label1);
            this.Name = "frmMoldConFirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận khuôn được phép sử dụng.";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMoldCode;
        private System.Windows.Forms.CheckBox chkPC;
        private System.Windows.Forms.CheckBox chkQC;
        private System.Windows.Forms.CheckBox chkTooling;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}