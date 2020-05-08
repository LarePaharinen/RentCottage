namespace RentCottage
{
    partial class ModifyOrderForm
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
            this.lbOrder_OrderId = new System.Windows.Forms.Label();
            this.lbOrder_CustomerD = new System.Windows.Forms.Label();
            this.lbOrder_CottageID = new System.Windows.Forms.Label();
            this.lbOrder_OrderDate = new System.Windows.Forms.Label();
            this.lbOrder_PaymentDate = new System.Windows.Forms.Label();
            this.lbOrder_StartDate = new System.Windows.Forms.Label();
            this.lbOrder_EndDate = new System.Windows.Forms.Label();
            this.btmOrder_OrderModify = new System.Windows.Forms.Button();
            this.btmOrder_OrderModifyCancel = new System.Windows.Forms.Button();
            this.lbOrder_ModifyOrderID = new System.Windows.Forms.Label();
            this.lbOrder_ModifyCustomerID = new System.Windows.Forms.Label();
            this.lbOrder_ModifyOrderDate = new System.Windows.Forms.Label();
            this.lbOrder_ModifyPaymentDate = new System.Windows.Forms.Label();
            this.dtpOrder_ModifyStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpOrder_ModifyEndDate = new System.Windows.Forms.DateTimePicker();
            this.dgvOrderServices = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOrder_ModifyCottageID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderServices)).BeginInit();
            this.SuspendLayout();
            // 
            // lbOrder_OrderId
            // 
            this.lbOrder_OrderId.AutoSize = true;
            this.lbOrder_OrderId.Location = new System.Drawing.Point(54, 16);
            this.lbOrder_OrderId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOrder_OrderId.Name = "lbOrder_OrderId";
            this.lbOrder_OrderId.Size = new System.Drawing.Size(51, 13);
            this.lbOrder_OrderId.TabIndex = 0;
            this.lbOrder_OrderId.Text = "VarausID";
            // 
            // lbOrder_CustomerD
            // 
            this.lbOrder_CustomerD.AutoSize = true;
            this.lbOrder_CustomerD.Location = new System.Drawing.Point(51, 46);
            this.lbOrder_CustomerD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOrder_CustomerD.Name = "lbOrder_CustomerD";
            this.lbOrder_CustomerD.Size = new System.Drawing.Size(55, 13);
            this.lbOrder_CustomerD.TabIndex = 1;
            this.lbOrder_CustomerD.Text = "AsiakasID";
            // 
            // lbOrder_CottageID
            // 
            this.lbOrder_CottageID.AutoSize = true;
            this.lbOrder_CottageID.Location = new System.Drawing.Point(58, 72);
            this.lbOrder_CottageID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOrder_CottageID.Name = "lbOrder_CottageID";
            this.lbOrder_CottageID.Size = new System.Drawing.Size(47, 13);
            this.lbOrder_CottageID.TabIndex = 2;
            this.lbOrder_CottageID.Text = "MökkiID";
            // 
            // lbOrder_OrderDate
            // 
            this.lbOrder_OrderDate.AutoSize = true;
            this.lbOrder_OrderDate.Location = new System.Drawing.Point(305, 46);
            this.lbOrder_OrderDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOrder_OrderDate.Name = "lbOrder_OrderDate";
            this.lbOrder_OrderDate.Size = new System.Drawing.Size(64, 13);
            this.lbOrder_OrderDate.TabIndex = 3;
            this.lbOrder_OrderDate.Text = "Varattu pvm";
            // 
            // lbOrder_PaymentDate
            // 
            this.lbOrder_PaymentDate.AutoSize = true;
            this.lbOrder_PaymentDate.Location = new System.Drawing.Point(293, 72);
            this.lbOrder_PaymentDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOrder_PaymentDate.Name = "lbOrder_PaymentDate";
            this.lbOrder_PaymentDate.Size = new System.Drawing.Size(76, 13);
            this.lbOrder_PaymentDate.TabIndex = 4;
            this.lbOrder_PaymentDate.Text = "Vahvistus pvm";
            // 
            // lbOrder_StartDate
            // 
            this.lbOrder_StartDate.AutoSize = true;
            this.lbOrder_StartDate.Location = new System.Drawing.Point(22, 108);
            this.lbOrder_StartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOrder_StartDate.Name = "lbOrder_StartDate";
            this.lbOrder_StartDate.Size = new System.Drawing.Size(84, 13);
            this.lbOrder_StartDate.TabIndex = 5;
            this.lbOrder_StartDate.Text = "Varattu alkupvm";
            // 
            // lbOrder_EndDate
            // 
            this.lbOrder_EndDate.AutoSize = true;
            this.lbOrder_EndDate.Location = new System.Drawing.Point(279, 108);
            this.lbOrder_EndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOrder_EndDate.Name = "lbOrder_EndDate";
            this.lbOrder_EndDate.Size = new System.Drawing.Size(90, 13);
            this.lbOrder_EndDate.TabIndex = 6;
            this.lbOrder_EndDate.Text = "Varattu loppupvm";
            // 
            // btmOrder_OrderModify
            // 
            this.btmOrder_OrderModify.Location = new System.Drawing.Point(160, 313);
            this.btmOrder_OrderModify.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btmOrder_OrderModify.Name = "btmOrder_OrderModify";
            this.btmOrder_OrderModify.Size = new System.Drawing.Size(109, 23);
            this.btmOrder_OrderModify.TabIndex = 7;
            this.btmOrder_OrderModify.Text = "Talenna";
            this.btmOrder_OrderModify.UseVisualStyleBackColor = true;
            this.btmOrder_OrderModify.Click += new System.EventHandler(this.btmOrder_OrderModify_Click);
            // 
            // btmOrder_OrderModifyCancel
            // 
            this.btmOrder_OrderModifyCancel.Location = new System.Drawing.Point(283, 313);
            this.btmOrder_OrderModifyCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btmOrder_OrderModifyCancel.Name = "btmOrder_OrderModifyCancel";
            this.btmOrder_OrderModifyCancel.Size = new System.Drawing.Size(109, 23);
            this.btmOrder_OrderModifyCancel.TabIndex = 8;
            this.btmOrder_OrderModifyCancel.Text = "Peruuta";
            this.btmOrder_OrderModifyCancel.UseVisualStyleBackColor = true;
            this.btmOrder_OrderModifyCancel.Click += new System.EventHandler(this.btmOrder_OrderModifyCancel_Click);
            // 
            // lbOrder_ModifyOrderID
            // 
            this.lbOrder_ModifyOrderID.AutoSize = true;
            this.lbOrder_ModifyOrderID.Location = new System.Drawing.Point(131, 16);
            this.lbOrder_ModifyOrderID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOrder_ModifyOrderID.Name = "lbOrder_ModifyOrderID";
            this.lbOrder_ModifyOrderID.Size = new System.Drawing.Size(35, 13);
            this.lbOrder_ModifyOrderID.TabIndex = 9;
            this.lbOrder_ModifyOrderID.Text = "label1";
            // 
            // lbOrder_ModifyCustomerID
            // 
            this.lbOrder_ModifyCustomerID.AutoSize = true;
            this.lbOrder_ModifyCustomerID.Location = new System.Drawing.Point(131, 46);
            this.lbOrder_ModifyCustomerID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOrder_ModifyCustomerID.Name = "lbOrder_ModifyCustomerID";
            this.lbOrder_ModifyCustomerID.Size = new System.Drawing.Size(35, 13);
            this.lbOrder_ModifyCustomerID.TabIndex = 10;
            this.lbOrder_ModifyCustomerID.Text = "label2";
            // 
            // lbOrder_ModifyOrderDate
            // 
            this.lbOrder_ModifyOrderDate.AutoSize = true;
            this.lbOrder_ModifyOrderDate.Location = new System.Drawing.Point(393, 46);
            this.lbOrder_ModifyOrderDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOrder_ModifyOrderDate.Name = "lbOrder_ModifyOrderDate";
            this.lbOrder_ModifyOrderDate.Size = new System.Drawing.Size(35, 13);
            this.lbOrder_ModifyOrderDate.TabIndex = 12;
            this.lbOrder_ModifyOrderDate.Text = "label4";
            // 
            // lbOrder_ModifyPaymentDate
            // 
            this.lbOrder_ModifyPaymentDate.AutoSize = true;
            this.lbOrder_ModifyPaymentDate.Location = new System.Drawing.Point(393, 72);
            this.lbOrder_ModifyPaymentDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOrder_ModifyPaymentDate.Name = "lbOrder_ModifyPaymentDate";
            this.lbOrder_ModifyPaymentDate.Size = new System.Drawing.Size(35, 13);
            this.lbOrder_ModifyPaymentDate.TabIndex = 13;
            this.lbOrder_ModifyPaymentDate.Text = "label5";
            // 
            // dtpOrder_ModifyStartDate
            // 
            this.dtpOrder_ModifyStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpOrder_ModifyStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrder_ModifyStartDate.Location = new System.Drawing.Point(133, 104);
            this.dtpOrder_ModifyStartDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpOrder_ModifyStartDate.Name = "dtpOrder_ModifyStartDate";
            this.dtpOrder_ModifyStartDate.Size = new System.Drawing.Size(118, 20);
            this.dtpOrder_ModifyStartDate.TabIndex = 14;
            // 
            // dtpOrder_ModifyEndDate
            // 
            this.dtpOrder_ModifyEndDate.CustomFormat = "yyyyy-MM-dd";
            this.dtpOrder_ModifyEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrder_ModifyEndDate.Location = new System.Drawing.Point(396, 104);
            this.dtpOrder_ModifyEndDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpOrder_ModifyEndDate.Name = "dtpOrder_ModifyEndDate";
            this.dtpOrder_ModifyEndDate.Size = new System.Drawing.Size(117, 20);
            this.dtpOrder_ModifyEndDate.TabIndex = 15;
            this.dtpOrder_ModifyEndDate.ValueChanged += new System.EventHandler(this.dtpOrder_ModifyEndDate_ValueChanged);
            // 
            // dgvOrderServices
            // 
            this.dgvOrderServices.AllowUserToAddRows = false;
            this.dgvOrderServices.AllowUserToDeleteRows = false;
            this.dgvOrderServices.AllowUserToResizeRows = false;
            this.dgvOrderServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderServices.Location = new System.Drawing.Point(12, 160);
            this.dgvOrderServices.Name = "dgvOrderServices";
            this.dgvOrderServices.RowHeadersVisible = false;
            this.dgvOrderServices.RowHeadersWidth = 62;
            this.dgvOrderServices.Size = new System.Drawing.Size(500, 142);
            this.dgvOrderServices.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Lisäpalvelut";
            // 
            // tbOrder_ModifyCottageID
            // 
            this.tbOrder_ModifyCottageID.Location = new System.Drawing.Point(133, 72);
            this.tbOrder_ModifyCottageID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbOrder_ModifyCottageID.MaxLength = 6;
            this.tbOrder_ModifyCottageID.Name = "tbOrder_ModifyCottageID";
            this.tbOrder_ModifyCottageID.Size = new System.Drawing.Size(64, 20);
            this.tbOrder_ModifyCottageID.TabIndex = 18;
            this.tbOrder_ModifyCottageID.Leave += new System.EventHandler(this.tbOrder_ModifyCottageID_Leave);
            // 
            // ModifyOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 347);
            this.Controls.Add(this.tbOrder_ModifyCottageID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOrderServices);
            this.Controls.Add(this.dtpOrder_ModifyEndDate);
            this.Controls.Add(this.dtpOrder_ModifyStartDate);
            this.Controls.Add(this.lbOrder_ModifyPaymentDate);
            this.Controls.Add(this.lbOrder_ModifyOrderDate);
            this.Controls.Add(this.lbOrder_ModifyCustomerID);
            this.Controls.Add(this.lbOrder_ModifyOrderID);
            this.Controls.Add(this.btmOrder_OrderModifyCancel);
            this.Controls.Add(this.btmOrder_OrderModify);
            this.Controls.Add(this.lbOrder_EndDate);
            this.Controls.Add(this.lbOrder_StartDate);
            this.Controls.Add(this.lbOrder_PaymentDate);
            this.Controls.Add(this.lbOrder_OrderDate);
            this.Controls.Add(this.lbOrder_CottageID);
            this.Controls.Add(this.lbOrder_CustomerD);
            this.Controls.Add(this.lbOrder_OrderId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ModifyOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Muokkaa varaus";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOrder_OrderId;
        private System.Windows.Forms.Label lbOrder_CustomerD;
        private System.Windows.Forms.Label lbOrder_CottageID;
        private System.Windows.Forms.Label lbOrder_OrderDate;
        private System.Windows.Forms.Label lbOrder_PaymentDate;
        private System.Windows.Forms.Label lbOrder_StartDate;
        private System.Windows.Forms.Label lbOrder_EndDate;
        private System.Windows.Forms.Button btmOrder_OrderModify;
        private System.Windows.Forms.Button btmOrder_OrderModifyCancel;
        private System.Windows.Forms.Label lbOrder_ModifyOrderID;
        private System.Windows.Forms.Label lbOrder_ModifyCustomerID;
        private System.Windows.Forms.Label lbOrder_ModifyOrderDate;
        private System.Windows.Forms.Label lbOrder_ModifyPaymentDate;
        private System.Windows.Forms.DateTimePicker dtpOrder_ModifyStartDate;
        private System.Windows.Forms.DateTimePicker dtpOrder_ModifyEndDate;
        private System.Windows.Forms.DataGridView dgvOrderServices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOrder_ModifyCottageID;
    }
}