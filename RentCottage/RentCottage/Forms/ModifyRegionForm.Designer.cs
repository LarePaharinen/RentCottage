namespace RentCottage.Forms
{
    partial class ModifyRegionForm
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
            this.lblRegionModifyRegionID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRegionModifyRegionName = new System.Windows.Forms.TextBox();
            this.btnRegionModifyModify = new System.Windows.Forms.Button();
            this.btnRegionModifyCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Toiminta-alueID:";
            // 
            // lblRegionModifyRegionID
            // 
            this.lblRegionModifyRegionID.AutoSize = true;
            this.lblRegionModifyRegionID.Location = new System.Drawing.Point(121, 9);
            this.lblRegionModifyRegionID.Name = "lblRegionModifyRegionID";
            this.lblRegionModifyRegionID.Size = new System.Drawing.Size(31, 13);
            this.lblRegionModifyRegionID.TabIndex = 1;
            this.lblRegionModifyRegionID.Text = "0000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Toiminta-alueen nimi:";
            // 
            // tbRegionModifyRegionName
            // 
            this.tbRegionModifyRegionName.Location = new System.Drawing.Point(124, 29);
            this.tbRegionModifyRegionName.Name = "tbRegionModifyRegionName";
            this.tbRegionModifyRegionName.Size = new System.Drawing.Size(130, 20);
            this.tbRegionModifyRegionName.TabIndex = 0;
            // 
            // btnRegionModifyModify
            // 
            this.btnRegionModifyModify.Location = new System.Drawing.Point(90, 64);
            this.btnRegionModifyModify.Name = "btnRegionModifyModify";
            this.btnRegionModifyModify.Size = new System.Drawing.Size(83, 23);
            this.btnRegionModifyModify.TabIndex = 1;
            this.btnRegionModifyModify.Text = "Tallenna";
            this.btnRegionModifyModify.UseVisualStyleBackColor = true;
            this.btnRegionModifyModify.Click += new System.EventHandler(this.btnRegionModifyModify_Click);
            // 
            // btnRegionModifyCancel
            // 
            this.btnRegionModifyCancel.Location = new System.Drawing.Point(179, 64);
            this.btnRegionModifyCancel.Name = "btnRegionModifyCancel";
            this.btnRegionModifyCancel.Size = new System.Drawing.Size(75, 23);
            this.btnRegionModifyCancel.TabIndex = 2;
            this.btnRegionModifyCancel.Text = "Peruuta";
            this.btnRegionModifyCancel.UseVisualStyleBackColor = true;
            this.btnRegionModifyCancel.Click += new System.EventHandler(this.btnRegionModifyCancel_Click);
            // 
            // ModifyRegionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 99);
            this.Controls.Add(this.btnRegionModifyCancel);
            this.Controls.Add(this.btnRegionModifyModify);
            this.Controls.Add(this.tbRegionModifyRegionName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRegionModifyRegionID);
            this.Controls.Add(this.label1);
            this.Name = "ModifyRegionForm";
            this.Text = "Muokkaa toiminta-aluetta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRegionModifyRegionID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRegionModifyRegionName;
        private System.Windows.Forms.Button btnRegionModifyModify;
        private System.Windows.Forms.Button btnRegionModifyCancel;
    }
}