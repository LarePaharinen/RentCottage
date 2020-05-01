namespace RentCottage.Forms
{
    partial class AddServiceForm
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
            this.tbAddServiceName = new System.Windows.Forms.TextBox();
            this.tbAddServiceType = new System.Windows.Forms.TextBox();
            this.tbAddServicePrice = new System.Windows.Forms.TextBox();
            this.tbAddServiceVAT = new System.Windows.Forms.TextBox();
            this.tbAddServiceDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAddServiceRegion = new System.Windows.Forms.ComboBox();
            this.btnAddServiceAdd = new System.Windows.Forms.Button();
            this.btnAddServiceCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Toiminta-alue:";
            // 
            // tbAddServiceName
            // 
            this.tbAddServiceName.Location = new System.Drawing.Point(91, 49);
            this.tbAddServiceName.Name = "tbAddServiceName";
            this.tbAddServiceName.Size = new System.Drawing.Size(209, 20);
            this.tbAddServiceName.TabIndex = 2;
            // 
            // tbAddServiceType
            // 
            this.tbAddServiceType.Location = new System.Drawing.Point(91, 75);
            this.tbAddServiceType.Name = "tbAddServiceType";
            this.tbAddServiceType.Size = new System.Drawing.Size(209, 20);
            this.tbAddServiceType.TabIndex = 3;
            // 
            // tbAddServicePrice
            // 
            this.tbAddServicePrice.Location = new System.Drawing.Point(91, 101);
            this.tbAddServicePrice.Name = "tbAddServicePrice";
            this.tbAddServicePrice.Size = new System.Drawing.Size(209, 20);
            this.tbAddServicePrice.TabIndex = 4;
            // 
            // tbAddServiceVAT
            // 
            this.tbAddServiceVAT.Location = new System.Drawing.Point(91, 127);
            this.tbAddServiceVAT.Name = "tbAddServiceVAT";
            this.tbAddServiceVAT.Size = new System.Drawing.Size(209, 20);
            this.tbAddServiceVAT.TabIndex = 5;
            // 
            // tbAddServiceDescription
            // 
            this.tbAddServiceDescription.Location = new System.Drawing.Point(91, 153);
            this.tbAddServiceDescription.Multiline = true;
            this.tbAddServiceDescription.Name = "tbAddServiceDescription";
            this.tbAddServiceDescription.Size = new System.Drawing.Size(209, 94);
            this.tbAddServiceDescription.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nimi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tyyppi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hinta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Alv:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Kuvaus:";
            // 
            // cbAddServiceRegion
            // 
            this.cbAddServiceRegion.FormattingEnabled = true;
            this.cbAddServiceRegion.Location = new System.Drawing.Point(91, 22);
            this.cbAddServiceRegion.Name = "cbAddServiceRegion";
            this.cbAddServiceRegion.Size = new System.Drawing.Size(209, 21);
            this.cbAddServiceRegion.TabIndex = 1;
            // 
            // btnAddServiceAdd
            // 
            this.btnAddServiceAdd.Location = new System.Drawing.Point(225, 253);
            this.btnAddServiceAdd.Name = "btnAddServiceAdd";
            this.btnAddServiceAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAddServiceAdd.TabIndex = 7;
            this.btnAddServiceAdd.Text = "Lisää palvelu";
            this.btnAddServiceAdd.UseVisualStyleBackColor = true;
            // 
            // btnAddServiceCancel
            // 
            this.btnAddServiceCancel.Location = new System.Drawing.Point(144, 253);
            this.btnAddServiceCancel.Name = "btnAddServiceCancel";
            this.btnAddServiceCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAddServiceCancel.TabIndex = 8;
            this.btnAddServiceCancel.Text = "Peruuta";
            this.btnAddServiceCancel.UseVisualStyleBackColor = true;
            // 
            // AddServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 288);
            this.Controls.Add(this.btnAddServiceCancel);
            this.Controls.Add(this.btnAddServiceAdd);
            this.Controls.Add(this.cbAddServiceRegion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAddServiceDescription);
            this.Controls.Add(this.tbAddServiceVAT);
            this.Controls.Add(this.tbAddServicePrice);
            this.Controls.Add(this.tbAddServiceType);
            this.Controls.Add(this.tbAddServiceName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lisää palvelu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAddServiceName;
        private System.Windows.Forms.TextBox tbAddServiceType;
        private System.Windows.Forms.TextBox tbAddServicePrice;
        private System.Windows.Forms.TextBox tbAddServiceVAT;
        private System.Windows.Forms.TextBox tbAddServiceDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbAddServiceRegion;
        private System.Windows.Forms.Button btnAddServiceAdd;
        private System.Windows.Forms.Button btnAddServiceCancel;
    }
}