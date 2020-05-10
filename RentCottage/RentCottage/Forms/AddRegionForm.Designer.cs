namespace RentCottage.Forms
{
    partial class AddRegionForm
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
            this.tbRegionAddRegionName = new System.Windows.Forms.TextBox();
            this.btnRegionAddAdd = new System.Windows.Forms.Button();
            this.btnRegionAddCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Toiminta-alueen nimi:";
            // 
            // tbRegionAddRegionName
            // 
            this.tbRegionAddRegionName.Location = new System.Drawing.Point(124, 6);
            this.tbRegionAddRegionName.Name = "tbRegionAddRegionName";
            this.tbRegionAddRegionName.Size = new System.Drawing.Size(138, 20);
            this.tbRegionAddRegionName.TabIndex = 1;
            // 
            // btnRegionAddAdd
            // 
            this.btnRegionAddAdd.Location = new System.Drawing.Point(65, 42);
            this.btnRegionAddAdd.Name = "btnRegionAddAdd";
            this.btnRegionAddAdd.Size = new System.Drawing.Size(116, 23);
            this.btnRegionAddAdd.TabIndex = 2;
            this.btnRegionAddAdd.Text = "Lisää toiminta-alue";
            this.btnRegionAddAdd.UseVisualStyleBackColor = true;
            this.btnRegionAddAdd.Click += new System.EventHandler(this.btnRegionAddAdd_Click);
            // 
            // btnRegionAddCancel
            // 
            this.btnRegionAddCancel.Location = new System.Drawing.Point(187, 42);
            this.btnRegionAddCancel.Name = "btnRegionAddCancel";
            this.btnRegionAddCancel.Size = new System.Drawing.Size(75, 23);
            this.btnRegionAddCancel.TabIndex = 3;
            this.btnRegionAddCancel.Text = "Peruuta";
            this.btnRegionAddCancel.UseVisualStyleBackColor = true;
            this.btnRegionAddCancel.Click += new System.EventHandler(this.btnRegionAddCancel_Click);
            // 
            // AddRegionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 81);
            this.Controls.Add(this.btnRegionAddCancel);
            this.Controls.Add(this.btnRegionAddAdd);
            this.Controls.Add(this.tbRegionAddRegionName);
            this.Controls.Add(this.label1);
            this.Name = "AddRegionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lisää toiminta-alue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRegionAddRegionName;
        private System.Windows.Forms.Button btnRegionAddAdd;
        private System.Windows.Forms.Button btnRegionAddCancel;
    }
}