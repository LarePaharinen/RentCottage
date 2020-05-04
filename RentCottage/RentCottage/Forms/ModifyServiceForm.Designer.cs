namespace RentCottage.Forms
{
    partial class ModifyServiceForm
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
            this.btnModifyServiceCancel = new System.Windows.Forms.Button();
            this.btnModifyServiceModify = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblModifyServiceID = new System.Windows.Forms.Label();
            this.cbModifyServiceRegion = new System.Windows.Forms.ComboBox();
            this.tbModifyServiceName = new System.Windows.Forms.TextBox();
            this.tbModifyServiceType = new System.Windows.Forms.TextBox();
            this.tbModifyServicePrice = new System.Windows.Forms.TextBox();
            this.tbModifyServiceVAT = new System.Windows.Forms.TextBox();
            this.tbModifyServiceDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnModifyServiceCancel
            // 
            this.btnModifyServiceCancel.Location = new System.Drawing.Point(106, 275);
            this.btnModifyServiceCancel.Name = "btnModifyServiceCancel";
            this.btnModifyServiceCancel.Size = new System.Drawing.Size(92, 35);
            this.btnModifyServiceCancel.TabIndex = 21;
            this.btnModifyServiceCancel.Text = "Peruuta";
            this.btnModifyServiceCancel.UseVisualStyleBackColor = true;
            this.btnModifyServiceCancel.Click += new System.EventHandler(this.btnModifyServiceCancel_Click);
            // 
            // btnModifyServiceModify
            // 
            this.btnModifyServiceModify.Location = new System.Drawing.Point(204, 275);
            this.btnModifyServiceModify.Name = "btnModifyServiceModify";
            this.btnModifyServiceModify.Size = new System.Drawing.Size(92, 35);
            this.btnModifyServiceModify.TabIndex = 20;
            this.btnModifyServiceModify.Text = "Muokkaa palvelun tietoja";
            this.btnModifyServiceModify.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Kuvaus:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Alv:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Hinta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Tyyppi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nimi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Toiminta-alue:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "PalveluID:";
            // 
            // lblModifyServiceID
            // 
            this.lblModifyServiceID.AutoSize = true;
            this.lblModifyServiceID.Location = new System.Drawing.Point(87, 28);
            this.lblModifyServiceID.Name = "lblModifyServiceID";
            this.lblModifyServiceID.Size = new System.Drawing.Size(31, 13);
            this.lblModifyServiceID.TabIndex = 29;
            this.lblModifyServiceID.Text = "0000";
            // 
            // cbModifyServiceRegion
            // 
            this.cbModifyServiceRegion.FormattingEnabled = true;
            this.cbModifyServiceRegion.Location = new System.Drawing.Point(87, 44);
            this.cbModifyServiceRegion.Name = "cbModifyServiceRegion";
            this.cbModifyServiceRegion.Size = new System.Drawing.Size(209, 21);
            this.cbModifyServiceRegion.TabIndex = 30;
            // 
            // tbModifyServiceName
            // 
            this.tbModifyServiceName.Location = new System.Drawing.Point(87, 71);
            this.tbModifyServiceName.Name = "tbModifyServiceName";
            this.tbModifyServiceName.Size = new System.Drawing.Size(209, 20);
            this.tbModifyServiceName.TabIndex = 31;
            // 
            // tbModifyServiceType
            // 
            this.tbModifyServiceType.Location = new System.Drawing.Point(87, 97);
            this.tbModifyServiceType.Name = "tbModifyServiceType";
            this.tbModifyServiceType.Size = new System.Drawing.Size(209, 20);
            this.tbModifyServiceType.TabIndex = 32;
            // 
            // tbModifyServicePrice
            // 
            this.tbModifyServicePrice.Location = new System.Drawing.Point(87, 123);
            this.tbModifyServicePrice.Name = "tbModifyServicePrice";
            this.tbModifyServicePrice.Size = new System.Drawing.Size(209, 20);
            this.tbModifyServicePrice.TabIndex = 33;
            // 
            // tbModifyServiceVAT
            // 
            this.tbModifyServiceVAT.Location = new System.Drawing.Point(87, 149);
            this.tbModifyServiceVAT.Name = "tbModifyServiceVAT";
            this.tbModifyServiceVAT.Size = new System.Drawing.Size(209, 20);
            this.tbModifyServiceVAT.TabIndex = 34;
            // 
            // tbModifyServiceDescription
            // 
            this.tbModifyServiceDescription.Location = new System.Drawing.Point(87, 175);
            this.tbModifyServiceDescription.Multiline = true;
            this.tbModifyServiceDescription.Name = "tbModifyServiceDescription";
            this.tbModifyServiceDescription.Size = new System.Drawing.Size(209, 94);
            this.tbModifyServiceDescription.TabIndex = 35;
            // 
            // ModifyServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 322);
            this.Controls.Add(this.tbModifyServiceDescription);
            this.Controls.Add(this.tbModifyServiceVAT);
            this.Controls.Add(this.tbModifyServicePrice);
            this.Controls.Add(this.tbModifyServiceType);
            this.Controls.Add(this.tbModifyServiceName);
            this.Controls.Add(this.cbModifyServiceRegion);
            this.Controls.Add(this.lblModifyServiceID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnModifyServiceCancel);
            this.Controls.Add(this.btnModifyServiceModify);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModifyServiceForm";
            this.Text = "Muokkaa palvelua";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModifyServiceCancel;
        private System.Windows.Forms.Button btnModifyServiceModify;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblModifyServiceID;
        private System.Windows.Forms.ComboBox cbModifyServiceRegion;
        private System.Windows.Forms.TextBox tbModifyServiceName;
        private System.Windows.Forms.TextBox tbModifyServiceType;
        private System.Windows.Forms.TextBox tbModifyServicePrice;
        private System.Windows.Forms.TextBox tbModifyServiceVAT;
        private System.Windows.Forms.TextBox tbModifyServiceDescription;
    }
}