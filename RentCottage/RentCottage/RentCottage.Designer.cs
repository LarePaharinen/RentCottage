namespace RentCottage
{
    partial class RentCottage
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
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tSearch = new System.Windows.Forms.TabPage();
            this.tRentControl = new System.Windows.Forms.TabPage();
            this.tAreaControl = new System.Windows.Forms.TabPage();
            this.tServiceControl = new System.Windows.Forms.TabPage();
            this.tCustomerControl = new System.Windows.Forms.TabPage();
            this.tcServiceSub = new System.Windows.Forms.TabControl();
            this.stCottageControl = new System.Windows.Forms.TabPage();
            this.stService = new System.Windows.Forms.TabPage();
            this.tBilling = new System.Windows.Forms.TabPage();
            this.tcMain.SuspendLayout();
            this.tServiceControl.SuspendLayout();
            this.tcServiceSub.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tSearch);
            this.tcMain.Controls.Add(this.tRentControl);
            this.tcMain.Controls.Add(this.tAreaControl);
            this.tcMain.Controls.Add(this.tServiceControl);
            this.tcMain.Controls.Add(this.tCustomerControl);
            this.tcMain.Controls.Add(this.tBilling);
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1352, 727);
            this.tcMain.TabIndex = 0;
            // 
            // tSearch
            // 
            this.tSearch.Location = new System.Drawing.Point(4, 22);
            this.tSearch.Name = "tSearch";
            this.tSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tSearch.Size = new System.Drawing.Size(1344, 701);
            this.tSearch.TabIndex = 0;
            this.tSearch.Text = "Haku";
            this.tSearch.UseVisualStyleBackColor = true;
            // 
            // tRentControl
            // 
            this.tRentControl.Location = new System.Drawing.Point(4, 22);
            this.tRentControl.Name = "tRentControl";
            this.tRentControl.Padding = new System.Windows.Forms.Padding(3);
            this.tRentControl.Size = new System.Drawing.Size(1344, 701);
            this.tRentControl.TabIndex = 1;
            this.tRentControl.Text = "Mökkivarausten hallinta";
            this.tRentControl.UseVisualStyleBackColor = true;
            // 
            // tAreaControl
            // 
            this.tAreaControl.Location = new System.Drawing.Point(4, 22);
            this.tAreaControl.Name = "tAreaControl";
            this.tAreaControl.Padding = new System.Windows.Forms.Padding(3);
            this.tAreaControl.Size = new System.Drawing.Size(1344, 701);
            this.tAreaControl.TabIndex = 2;
            this.tAreaControl.Text = "Toiminta-alueiden hallinta";
            this.tAreaControl.UseVisualStyleBackColor = true;
            // 
            // tServiceControl
            // 
            this.tServiceControl.Controls.Add(this.tcServiceSub);
            this.tServiceControl.Location = new System.Drawing.Point(4, 22);
            this.tServiceControl.Name = "tServiceControl";
            this.tServiceControl.Padding = new System.Windows.Forms.Padding(3);
            this.tServiceControl.Size = new System.Drawing.Size(1344, 701);
            this.tServiceControl.TabIndex = 3;
            this.tServiceControl.Text = "Palveluiden hallinta";
            this.tServiceControl.UseVisualStyleBackColor = true;
            // 
            // tCustomerControl
            // 
            this.tCustomerControl.Location = new System.Drawing.Point(4, 22);
            this.tCustomerControl.Name = "tCustomerControl";
            this.tCustomerControl.Padding = new System.Windows.Forms.Padding(3);
            this.tCustomerControl.Size = new System.Drawing.Size(1344, 701);
            this.tCustomerControl.TabIndex = 4;
            this.tCustomerControl.Text = "Asiakkaiden hallinta";
            this.tCustomerControl.UseVisualStyleBackColor = true;
            // 
            // tcServiceSub
            // 
            this.tcServiceSub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcServiceSub.Controls.Add(this.stCottageControl);
            this.tcServiceSub.Controls.Add(this.stService);
            this.tcServiceSub.Location = new System.Drawing.Point(0, 0);
            this.tcServiceSub.Name = "tcServiceSub";
            this.tcServiceSub.SelectedIndex = 0;
            this.tcServiceSub.Size = new System.Drawing.Size(1348, 705);
            this.tcServiceSub.TabIndex = 0;
            // 
            // stCottageControl
            // 
            this.stCottageControl.Location = new System.Drawing.Point(4, 22);
            this.stCottageControl.Name = "stCottageControl";
            this.stCottageControl.Padding = new System.Windows.Forms.Padding(3);
            this.stCottageControl.Size = new System.Drawing.Size(1340, 679);
            this.stCottageControl.TabIndex = 0;
            this.stCottageControl.Text = "Mökkien hallinta";
            this.stCottageControl.UseVisualStyleBackColor = true;
            // 
            // stService
            // 
            this.stService.Location = new System.Drawing.Point(4, 22);
            this.stService.Name = "stService";
            this.stService.Padding = new System.Windows.Forms.Padding(3);
            this.stService.Size = new System.Drawing.Size(1340, 679);
            this.stService.TabIndex = 1;
            this.stService.Text = "Palveluiden hallinta";
            this.stService.UseVisualStyleBackColor = true;
            // 
            // tBilling
            // 
            this.tBilling.Location = new System.Drawing.Point(4, 22);
            this.tBilling.Name = "tBilling";
            this.tBilling.Padding = new System.Windows.Forms.Padding(3);
            this.tBilling.Size = new System.Drawing.Size(1344, 701);
            this.tBilling.TabIndex = 5;
            this.tBilling.Text = "Laskut";
            this.tBilling.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.tcMain);
            this.Name = "Form1";
            this.Text = "RentCottage";
            this.tcMain.ResumeLayout(false);
            this.tServiceControl.ResumeLayout(false);
            this.tcServiceSub.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tSearch;
        private System.Windows.Forms.TabPage tRentControl;
        private System.Windows.Forms.TabPage tAreaControl;
        private System.Windows.Forms.TabPage tServiceControl;
        private System.Windows.Forms.TabControl tcServiceSub;
        private System.Windows.Forms.TabPage stCottageControl;
        private System.Windows.Forms.TabPage stService;
        private System.Windows.Forms.TabPage tCustomerControl;
        private System.Windows.Forms.TabPage tBilling;
    }
}

