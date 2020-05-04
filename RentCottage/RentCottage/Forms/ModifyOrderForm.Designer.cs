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
            this.lbOrder_ModifyCottageID = new System.Windows.Forms.Label();
            this.lbOrder_ModifyOrderDate = new System.Windows.Forms.Label();
            this.lbOrder_ModifyPaymentDate = new System.Windows.Forms.Label();
            this.dtpOrder_ModifyStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpOrder_ModifyEndDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lbOrder_OrderId
            // 
            this.lbOrder_OrderId.AutoSize = true;
            this.lbOrder_OrderId.Location = new System.Drawing.Point(81, 24);
            this.lbOrder_OrderId.Name = "lbOrder_OrderId";
            this.lbOrder_OrderId.Size = new System.Drawing.Size(77, 20);
            this.lbOrder_OrderId.TabIndex = 0;
            this.lbOrder_OrderId.Text = "VarausID";
            // 
            // lbOrder_CustomerD
            // 
            this.lbOrder_CustomerD.AutoSize = true;
            this.lbOrder_CustomerD.Location = new System.Drawing.Point(76, 78);
            this.lbOrder_CustomerD.Name = "lbOrder_CustomerD";
            this.lbOrder_CustomerD.Size = new System.Drawing.Size(82, 20);
            this.lbOrder_CustomerD.TabIndex = 1;
            this.lbOrder_CustomerD.Text = "AsiakasID";
            // 
            // lbOrder_CottageID
            // 
            this.lbOrder_CottageID.AutoSize = true;
            this.lbOrder_CottageID.Location = new System.Drawing.Point(91, 132);
            this.lbOrder_CottageID.Name = "lbOrder_CottageID";
            this.lbOrder_CottageID.Size = new System.Drawing.Size(67, 20);
            this.lbOrder_CottageID.TabIndex = 2;
            this.lbOrder_CottageID.Text = "MökkiID";
            // 
            // lbOrder_OrderDate
            // 
            this.lbOrder_OrderDate.AutoSize = true;
            this.lbOrder_OrderDate.Location = new System.Drawing.Point(63, 186);
            this.lbOrder_OrderDate.Name = "lbOrder_OrderDate";
            this.lbOrder_OrderDate.Size = new System.Drawing.Size(95, 20);
            this.lbOrder_OrderDate.TabIndex = 3;
            this.lbOrder_OrderDate.Text = "Varattu pvm";
            // 
            // lbOrder_PaymentDate
            // 
            this.lbOrder_PaymentDate.AutoSize = true;
            this.lbOrder_PaymentDate.Location = new System.Drawing.Point(47, 240);
            this.lbOrder_PaymentDate.Name = "lbOrder_PaymentDate";
            this.lbOrder_PaymentDate.Size = new System.Drawing.Size(111, 20);
            this.lbOrder_PaymentDate.TabIndex = 4;
            this.lbOrder_PaymentDate.Text = "Vahvistus pvm";
            // 
            // lbOrder_StartDate
            // 
            this.lbOrder_StartDate.AutoSize = true;
            this.lbOrder_StartDate.Location = new System.Drawing.Point(34, 294);
            this.lbOrder_StartDate.Name = "lbOrder_StartDate";
            this.lbOrder_StartDate.Size = new System.Drawing.Size(124, 20);
            this.lbOrder_StartDate.TabIndex = 5;
            this.lbOrder_StartDate.Text = "Varattu alkupvm";
            // 
            // lbOrder_EndDate
            // 
            this.lbOrder_EndDate.AutoSize = true;
            this.lbOrder_EndDate.Location = new System.Drawing.Point(24, 348);
            this.lbOrder_EndDate.Name = "lbOrder_EndDate";
            this.lbOrder_EndDate.Size = new System.Drawing.Size(134, 20);
            this.lbOrder_EndDate.TabIndex = 6;
            this.lbOrder_EndDate.Text = "Varattu loppupvm";
            // 
            // btmOrder_OrderModify
            // 
            this.btmOrder_OrderModify.Location = new System.Drawing.Point(25, 395);
            this.btmOrder_OrderModify.Name = "btmOrder_OrderModify";
            this.btmOrder_OrderModify.Size = new System.Drawing.Size(164, 35);
            this.btmOrder_OrderModify.TabIndex = 7;
            this.btmOrder_OrderModify.Text = "Talenna";
            this.btmOrder_OrderModify.UseVisualStyleBackColor = true;
            this.btmOrder_OrderModify.Click += new System.EventHandler(this.btmOrder_OrderModify_Click);
            // 
            // btmOrder_OrderModifyCancel
            // 
            this.btmOrder_OrderModifyCancel.Location = new System.Drawing.Point(210, 395);
            this.btmOrder_OrderModifyCancel.Name = "btmOrder_OrderModifyCancel";
            this.btmOrder_OrderModifyCancel.Size = new System.Drawing.Size(164, 35);
            this.btmOrder_OrderModifyCancel.TabIndex = 8;
            this.btmOrder_OrderModifyCancel.Text = "Peruuta";
            this.btmOrder_OrderModifyCancel.UseVisualStyleBackColor = true;
            this.btmOrder_OrderModifyCancel.Click += new System.EventHandler(this.btmOrder_OrderModifyCancel_Click);
            // 
            // lbOrder_ModifyOrderID
            // 
            this.lbOrder_ModifyOrderID.AutoSize = true;
            this.lbOrder_ModifyOrderID.Location = new System.Drawing.Point(196, 24);
            this.lbOrder_ModifyOrderID.Name = "lbOrder_ModifyOrderID";
            this.lbOrder_ModifyOrderID.Size = new System.Drawing.Size(51, 20);
            this.lbOrder_ModifyOrderID.TabIndex = 9;
            this.lbOrder_ModifyOrderID.Text = "label1";
            // 
            // lbOrder_ModifyCustomerID
            // 
            this.lbOrder_ModifyCustomerID.AutoSize = true;
            this.lbOrder_ModifyCustomerID.Location = new System.Drawing.Point(196, 78);
            this.lbOrder_ModifyCustomerID.Name = "lbOrder_ModifyCustomerID";
            this.lbOrder_ModifyCustomerID.Size = new System.Drawing.Size(51, 20);
            this.lbOrder_ModifyCustomerID.TabIndex = 10;
            this.lbOrder_ModifyCustomerID.Text = "label2";
            // 
            // lbOrder_ModifyCottageID
            // 
            this.lbOrder_ModifyCottageID.AutoSize = true;
            this.lbOrder_ModifyCottageID.Location = new System.Drawing.Point(196, 132);
            this.lbOrder_ModifyCottageID.Name = "lbOrder_ModifyCottageID";
            this.lbOrder_ModifyCottageID.Size = new System.Drawing.Size(51, 20);
            this.lbOrder_ModifyCottageID.TabIndex = 11;
            this.lbOrder_ModifyCottageID.Text = "label3";
            // 
            // lbOrder_ModifyOrderDate
            // 
            this.lbOrder_ModifyOrderDate.AutoSize = true;
            this.lbOrder_ModifyOrderDate.Location = new System.Drawing.Point(196, 186);
            this.lbOrder_ModifyOrderDate.Name = "lbOrder_ModifyOrderDate";
            this.lbOrder_ModifyOrderDate.Size = new System.Drawing.Size(51, 20);
            this.lbOrder_ModifyOrderDate.TabIndex = 12;
            this.lbOrder_ModifyOrderDate.Text = "label4";
            // 
            // lbOrder_ModifyPaymentDate
            // 
            this.lbOrder_ModifyPaymentDate.AutoSize = true;
            this.lbOrder_ModifyPaymentDate.Location = new System.Drawing.Point(196, 240);
            this.lbOrder_ModifyPaymentDate.Name = "lbOrder_ModifyPaymentDate";
            this.lbOrder_ModifyPaymentDate.Size = new System.Drawing.Size(51, 20);
            this.lbOrder_ModifyPaymentDate.TabIndex = 13;
            this.lbOrder_ModifyPaymentDate.Text = "label5";
            // 
            // dtpOrder_ModifyStartDate
            // 
            this.dtpOrder_ModifyStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpOrder_ModifyStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrder_ModifyStartDate.Location = new System.Drawing.Point(199, 288);
            this.dtpOrder_ModifyStartDate.Name = "dtpOrder_ModifyStartDate";
            this.dtpOrder_ModifyStartDate.Size = new System.Drawing.Size(175, 26);
            this.dtpOrder_ModifyStartDate.TabIndex = 14;
            // 
            // dtpOrder_ModifyEndDate
            // 
            this.dtpOrder_ModifyEndDate.CustomFormat = "yyyyy-MM-dd";
            this.dtpOrder_ModifyEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrder_ModifyEndDate.Location = new System.Drawing.Point(199, 343);
            this.dtpOrder_ModifyEndDate.Name = "dtpOrder_ModifyEndDate";
            this.dtpOrder_ModifyEndDate.Size = new System.Drawing.Size(174, 26);
            this.dtpOrder_ModifyEndDate.TabIndex = 15;
            // 
            // ModifyOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 442);
            this.Controls.Add(this.dtpOrder_ModifyEndDate);
            this.Controls.Add(this.dtpOrder_ModifyStartDate);
            this.Controls.Add(this.lbOrder_ModifyPaymentDate);
            this.Controls.Add(this.lbOrder_ModifyOrderDate);
            this.Controls.Add(this.lbOrder_ModifyCottageID);
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
            this.Name = "ModifyOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Muokkaa varaus";
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
        private System.Windows.Forms.Label lbOrder_ModifyCottageID;
        private System.Windows.Forms.Label lbOrder_ModifyOrderDate;
        private System.Windows.Forms.Label lbOrder_ModifyPaymentDate;
        private System.Windows.Forms.DateTimePicker dtpOrder_ModifyStartDate;
        private System.Windows.Forms.DateTimePicker dtpOrder_ModifyEndDate;
    }
}