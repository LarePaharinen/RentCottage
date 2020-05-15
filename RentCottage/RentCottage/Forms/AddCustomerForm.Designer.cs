namespace RentCottage
{
    partial class AddCustomerForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbCustomerPhoneAdd = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbCustomerEmailAdd = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbCustomerAddressAdd = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbCustomerLNameAdd = new System.Windows.Forms.TextBox();
            this.tbCustomerFNameAdd = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbCustomerPostalAdd = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbCustomerPostOfficeAdd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(69, 228);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Lisää asiakas";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbCustomerPhoneAdd
            // 
            this.tbCustomerPhoneAdd.Location = new System.Drawing.Point(109, 194);
            this.tbCustomerPhoneAdd.MaxLength = 15;
            this.tbCustomerPhoneAdd.Name = "tbCustomerPhoneAdd";
            this.tbCustomerPhoneAdd.Size = new System.Drawing.Size(131, 20);
            this.tbCustomerPhoneAdd.TabIndex = 7;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(22, 197);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 13);
            this.label23.TabIndex = 38;
            this.label23.Text = "Puhelinnumero:";
            // 
            // tbCustomerEmailAdd
            // 
            this.tbCustomerEmailAdd.Location = new System.Drawing.Point(109, 168);
            this.tbCustomerEmailAdd.MaxLength = 50;
            this.tbCustomerEmailAdd.Name = "tbCustomerEmailAdd";
            this.tbCustomerEmailAdd.Size = new System.Drawing.Size(131, 20);
            this.tbCustomerEmailAdd.TabIndex = 6;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(40, 171);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 13);
            this.label22.TabIndex = 36;
            this.label22.Text = "Sähköposti:";
            // 
            // tbCustomerAddressAdd
            // 
            this.tbCustomerAddressAdd.Location = new System.Drawing.Point(109, 90);
            this.tbCustomerAddressAdd.MaxLength = 40;
            this.tbCustomerAddressAdd.Name = "tbCustomerAddressAdd";
            this.tbCustomerAddressAdd.Size = new System.Drawing.Size(131, 20);
            this.tbCustomerAddressAdd.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(45, 93);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 13);
            this.label21.TabIndex = 34;
            this.label21.Text = "Lähiosoite:";
            // 
            // tbCustomerLNameAdd
            // 
            this.tbCustomerLNameAdd.Location = new System.Drawing.Point(109, 64);
            this.tbCustomerLNameAdd.MaxLength = 40;
            this.tbCustomerLNameAdd.Name = "tbCustomerLNameAdd";
            this.tbCustomerLNameAdd.Size = new System.Drawing.Size(131, 20);
            this.tbCustomerLNameAdd.TabIndex = 2;
            // 
            // tbCustomerFNameAdd
            // 
            this.tbCustomerFNameAdd.Location = new System.Drawing.Point(109, 38);
            this.tbCustomerFNameAdd.MaxLength = 20;
            this.tbCustomerFNameAdd.Name = "tbCustomerFNameAdd";
            this.tbCustomerFNameAdd.Size = new System.Drawing.Size(131, 20);
            this.tbCustomerFNameAdd.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(50, 67);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 31;
            this.label20.Text = "Sukunimi:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(58, 41);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 13);
            this.label19.TabIndex = 30;
            this.label19.Text = "Etunimi:";
            // 
            // tbCustomerPostalAdd
            // 
            this.tbCustomerPostalAdd.Location = new System.Drawing.Point(109, 116);
            this.tbCustomerPostalAdd.MaxLength = 5;
            this.tbCustomerPostalAdd.Name = "tbCustomerPostalAdd";
            this.tbCustomerPostalAdd.Size = new System.Drawing.Size(131, 20);
            this.tbCustomerPostalAdd.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(34, 119);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Postinumero:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(164, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Peruuta";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbCustomerPostOfficeAdd
            // 
            this.tbCustomerPostOfficeAdd.Location = new System.Drawing.Point(109, 142);
            this.tbCustomerPostOfficeAdd.MaxLength = 45;
            this.tbCustomerPostOfficeAdd.Name = "tbCustomerPostOfficeAdd";
            this.tbCustomerPostOfficeAdd.Size = new System.Drawing.Size(131, 20);
            this.tbCustomerPostOfficeAdd.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Postitoimipaikka:";
            // 
            // AddCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 261);
            this.Controls.Add(this.tbCustomerPostOfficeAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbCustomerPhoneAdd);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.tbCustomerEmailAdd);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.tbCustomerAddressAdd);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tbCustomerLNameAdd);
            this.Controls.Add(this.tbCustomerFNameAdd);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tbCustomerPostalAdd);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddCustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lisää uusi asiakas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbCustomerPhoneAdd;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbCustomerEmailAdd;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbCustomerAddressAdd;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbCustomerLNameAdd;
        private System.Windows.Forms.TextBox tbCustomerFNameAdd;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbCustomerPostalAdd;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbCustomerPostOfficeAdd;
        private System.Windows.Forms.Label label1;
    }
}