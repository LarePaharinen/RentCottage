﻿namespace RentCottage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tSearch = new System.Windows.Forms.TabPage();
            this.tRentControl = new System.Windows.Forms.TabPage();
            this.tAreaControl = new System.Windows.Forms.TabPage();
            this.tbRegionName = new System.Windows.Forms.TextBox();
            this.btnRegionDelete = new System.Windows.Forms.Button();
            this.lblRegionID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRegion = new System.Windows.Forms.DataGridView();
            this.btnRegionAdd = new System.Windows.Forms.Button();
            this.lblRegion = new System.Windows.Forms.Label();
            this.tCustomerControl = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCustomerDeleteInfo = new System.Windows.Forms.Button();
            this.btnCustomerAdd = new System.Windows.Forms.Button();
            this.btnCustomerSearch = new System.Windows.Forms.Button();
            this.tbCustomerPhone = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbCustomerEmail = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbCustomerAddress = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbCustomerLName = new System.Windows.Forms.TextBox();
            this.tbCustomerFName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbCustomerPostal = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.tServiceControl = new System.Windows.Forms.TabPage();
            this.tcServiceSub = new System.Windows.Forms.TabControl();
            this.stCottageControl = new System.Windows.Forms.TabPage();
            this.cbCottageCapacity = new System.Windows.Forms.ComboBox();
            this.cbCottagePostal = new System.Windows.Forms.ComboBox();
            this.cbCottageRegions = new System.Windows.Forms.ComboBox();
            this.lblMokkiID = new System.Windows.Forms.Label();
            this.tbCottageDescription = new System.Windows.Forms.TextBox();
            this.tbCottageEqupment = new System.Windows.Forms.TextBox();
            this.tbCottageStreetAddress = new System.Windows.Forms.TextBox();
            this.tbCottageName = new System.Windows.Forms.TextBox();
            this.btnCottageDelete = new System.Windows.Forms.Button();
            this.btnCottageAdd = new System.Windows.Forms.Button();
            this.btnCottageSearch = new System.Windows.Forms.Button();
            this.dgvCottage = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stService = new System.Windows.Forms.TabPage();
            this.btnServiceDelete = new System.Windows.Forms.Button();
            this.btnServiceAdd = new System.Windows.Forms.Button();
            this.btnServiceSearch = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tbServiceDescription = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbServicePrice = new System.Windows.Forms.TextBox();
            this.tbServiceVAT = new System.Windows.Forms.TextBox();
            this.tbServiceType = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbServiceName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbServiceRegion = new System.Windows.Forms.ComboBox();
            this.lblServiceID = new System.Windows.Forms.Label();
            this.dgvService = new System.Windows.Forms.DataGridView();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tBilling = new System.Windows.Forms.TabPage();
            this.tcMain.SuspendLayout();
            this.tAreaControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegion)).BeginInit();
            this.tCustomerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tServiceControl.SuspendLayout();
            this.tcServiceSub.SuspendLayout();
            this.stCottageControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCottage)).BeginInit();
            this.stService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).BeginInit();
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
            this.tcMain.Controls.Add(this.tCustomerControl);
            this.tcMain.Controls.Add(this.tServiceControl);
            this.tcMain.Controls.Add(this.tBilling);
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(2028, 1118);
            this.tcMain.TabIndex = 0;
            // 
            // tSearch
            // 
            this.tSearch.Location = new System.Drawing.Point(4, 29);
            this.tSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tSearch.Name = "tSearch";
            this.tSearch.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tSearch.Size = new System.Drawing.Size(2020, 1085);
            this.tSearch.TabIndex = 0;
            this.tSearch.Text = "Uusi varaus";
            this.tSearch.UseVisualStyleBackColor = true;
            // 
            // tRentControl
            // 
            this.tRentControl.Location = new System.Drawing.Point(4, 29);
            this.tRentControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tRentControl.Name = "tRentControl";
            this.tRentControl.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tRentControl.Size = new System.Drawing.Size(2020, 1085);
            this.tRentControl.TabIndex = 1;
            this.tRentControl.Text = "Varausten hallinta";
            this.tRentControl.UseVisualStyleBackColor = true;
            // 
            // tAreaControl
            // 
            this.tAreaControl.Controls.Add(this.tbRegionName);
            this.tAreaControl.Controls.Add(this.btnRegionDelete);
            this.tAreaControl.Controls.Add(this.lblRegionID);
            this.tAreaControl.Controls.Add(this.label1);
            this.tAreaControl.Controls.Add(this.dgvRegion);
            this.tAreaControl.Controls.Add(this.btnRegionAdd);
            this.tAreaControl.Controls.Add(this.lblRegion);
            this.tAreaControl.Location = new System.Drawing.Point(4, 29);
            this.tAreaControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tAreaControl.Name = "tAreaControl";
            this.tAreaControl.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tAreaControl.Size = new System.Drawing.Size(2020, 1085);
            this.tAreaControl.TabIndex = 2;
            this.tAreaControl.Text = "Toiminta-alueiden hallinta";
            this.tAreaControl.UseVisualStyleBackColor = true;
            // 
            // tbRegionName
            // 
            this.tbRegionName.Location = new System.Drawing.Point(146, 114);
            this.tbRegionName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRegionName.Name = "tbRegionName";
            this.tbRegionName.Size = new System.Drawing.Size(238, 26);
            this.tbRegionName.TabIndex = 10;
            // 
            // btnRegionDelete
            // 
            this.btnRegionDelete.Location = new System.Drawing.Point(88, 172);
            this.btnRegionDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRegionDelete.Name = "btnRegionDelete";
            this.btnRegionDelete.Size = new System.Drawing.Size(144, 63);
            this.btnRegionDelete.TabIndex = 9;
            this.btnRegionDelete.Text = "Poista valittu alue";
            this.btnRegionDelete.UseVisualStyleBackColor = true;
            // 
            // lblRegionID
            // 
            this.lblRegionID.AutoSize = true;
            this.lblRegionID.Location = new System.Drawing.Point(146, 89);
            this.lblRegionID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegionID.Name = "lblRegionID";
            this.lblRegionID.Size = new System.Drawing.Size(45, 20);
            this.lblRegionID.TabIndex = 8;
            this.lblRegionID.Text = "0000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Toiminta-alueID:";
            // 
            // dgvRegion
            // 
            this.dgvRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegion.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRegion.Location = new System.Drawing.Point(489, 9);
            this.dgvRegion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvRegion.Name = "dgvRegion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegion.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRegion.RowHeadersVisible = false;
            this.dgvRegion.RowHeadersWidth = 51;
            this.dgvRegion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegion.Size = new System.Drawing.Size(1512, 1060);
            this.dgvRegion.TabIndex = 6;
            // 
            // btnRegionAdd
            // 
            this.btnRegionAdd.Location = new System.Drawing.Point(242, 172);
            this.btnRegionAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRegionAdd.Name = "btnRegionAdd";
            this.btnRegionAdd.Size = new System.Drawing.Size(144, 63);
            this.btnRegionAdd.TabIndex = 5;
            this.btnRegionAdd.Text = "Lisää uusi alue";
            this.btnRegionAdd.UseVisualStyleBackColor = true;
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(27, 118);
            this.lblRegion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(115, 20);
            this.lblRegion.TabIndex = 0;
            this.lblRegion.Text = "Toiminta-alue:";
            // 
            // tCustomerControl
            // 
            this.tCustomerControl.BackColor = System.Drawing.Color.Transparent;
            this.tCustomerControl.Controls.Add(this.dataGridView1);
            this.tCustomerControl.Controls.Add(this.btnCustomerDeleteInfo);
            this.tCustomerControl.Controls.Add(this.btnCustomerAdd);
            this.tCustomerControl.Controls.Add(this.btnCustomerSearch);
            this.tCustomerControl.Controls.Add(this.tbCustomerPhone);
            this.tCustomerControl.Controls.Add(this.label23);
            this.tCustomerControl.Controls.Add(this.tbCustomerEmail);
            this.tCustomerControl.Controls.Add(this.label22);
            this.tCustomerControl.Controls.Add(this.tbCustomerAddress);
            this.tCustomerControl.Controls.Add(this.label21);
            this.tCustomerControl.Controls.Add(this.tbCustomerLName);
            this.tCustomerControl.Controls.Add(this.tbCustomerFName);
            this.tCustomerControl.Controls.Add(this.label20);
            this.tCustomerControl.Controls.Add(this.label19);
            this.tCustomerControl.Controls.Add(this.tbCustomerPostal);
            this.tCustomerControl.Controls.Add(this.label16);
            this.tCustomerControl.Controls.Add(this.label15);
            this.tCustomerControl.Controls.Add(this.lblCustomerID);
            this.tCustomerControl.Location = new System.Drawing.Point(4, 29);
            this.tCustomerControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tCustomerControl.Name = "tCustomerControl";
            this.tCustomerControl.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tCustomerControl.Size = new System.Drawing.Size(2020, 1085);
            this.tCustomerControl.TabIndex = 4;
            this.tCustomerControl.Text = "Asiakkaiden hallinta";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(495, 9);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1512, 1060);
            this.dataGridView1.TabIndex = 56;
            // 
            // btnCustomerDeleteInfo
            // 
            this.btnCustomerDeleteInfo.Location = new System.Drawing.Point(62, 402);
            this.btnCustomerDeleteInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCustomerDeleteInfo.Name = "btnCustomerDeleteInfo";
            this.btnCustomerDeleteInfo.Size = new System.Drawing.Size(158, 71);
            this.btnCustomerDeleteInfo.TabIndex = 55;
            this.btnCustomerDeleteInfo.Text = "Poista valitun asiakkaan tiedot";
            this.btnCustomerDeleteInfo.UseVisualStyleBackColor = true;
            // 
            // btnCustomerAdd
            // 
            this.btnCustomerAdd.Location = new System.Drawing.Point(228, 402);
            this.btnCustomerAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCustomerAdd.Name = "btnCustomerAdd";
            this.btnCustomerAdd.Size = new System.Drawing.Size(158, 71);
            this.btnCustomerAdd.TabIndex = 54;
            this.btnCustomerAdd.Text = "Lisää uusi asiakas";
            this.btnCustomerAdd.UseVisualStyleBackColor = true;
            // 
            // btnCustomerSearch
            // 
            this.btnCustomerSearch.Location = new System.Drawing.Point(273, 342);
            this.btnCustomerSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCustomerSearch.Name = "btnCustomerSearch";
            this.btnCustomerSearch.Size = new System.Drawing.Size(112, 35);
            this.btnCustomerSearch.TabIndex = 14;
            this.btnCustomerSearch.Text = "Etsi";
            this.btnCustomerSearch.UseVisualStyleBackColor = true;
            // 
            // tbCustomerPhone
            // 
            this.tbCustomerPhone.Location = new System.Drawing.Point(189, 288);
            this.tbCustomerPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCustomerPhone.Name = "tbCustomerPhone";
            this.tbCustomerPhone.Size = new System.Drawing.Size(194, 26);
            this.tbCustomerPhone.TabIndex = 13;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(60, 292);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(125, 20);
            this.label23.TabIndex = 12;
            this.label23.Text = "Puhelinnumero:";
            // 
            // tbCustomerEmail
            // 
            this.tbCustomerEmail.Location = new System.Drawing.Point(189, 248);
            this.tbCustomerEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCustomerEmail.Name = "tbCustomerEmail";
            this.tbCustomerEmail.Size = new System.Drawing.Size(194, 26);
            this.tbCustomerEmail.TabIndex = 11;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(86, 252);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(96, 20);
            this.label22.TabIndex = 10;
            this.label22.Text = "Sähköposti:";
            // 
            // tbCustomerAddress
            // 
            this.tbCustomerAddress.Location = new System.Drawing.Point(189, 212);
            this.tbCustomerAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCustomerAddress.Name = "tbCustomerAddress";
            this.tbCustomerAddress.Size = new System.Drawing.Size(194, 26);
            this.tbCustomerAddress.TabIndex = 9;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(93, 217);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 20);
            this.label21.TabIndex = 8;
            this.label21.Text = "Lähiosoite:";
            // 
            // tbCustomerLName
            // 
            this.tbCustomerLName.Location = new System.Drawing.Point(189, 172);
            this.tbCustomerLName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCustomerLName.Name = "tbCustomerLName";
            this.tbCustomerLName.Size = new System.Drawing.Size(194, 26);
            this.tbCustomerLName.TabIndex = 7;
            // 
            // tbCustomerFName
            // 
            this.tbCustomerFName.Location = new System.Drawing.Point(189, 132);
            this.tbCustomerFName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCustomerFName.Name = "tbCustomerFName";
            this.tbCustomerFName.Size = new System.Drawing.Size(194, 26);
            this.tbCustomerFName.TabIndex = 6;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(100, 177);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 20);
            this.label20.TabIndex = 5;
            this.label20.Text = "Sukunimi:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(114, 137);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 20);
            this.label19.TabIndex = 4;
            this.label19.Text = "Etunimi:";
            // 
            // tbCustomerPostal
            // 
            this.tbCustomerPostal.Location = new System.Drawing.Point(189, 92);
            this.tbCustomerPostal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCustomerPostal.Name = "tbCustomerPostal";
            this.tbCustomerPostal.Size = new System.Drawing.Size(194, 26);
            this.tbCustomerPostal.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(78, 97);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 20);
            this.label16.TabIndex = 2;
            this.label16.Text = "Postinumero:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(93, 68);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 20);
            this.label15.TabIndex = 1;
            this.label15.Text = "AsiakasID:";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(189, 68);
            this.lblCustomerID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(45, 20);
            this.lblCustomerID.TabIndex = 0;
            this.lblCustomerID.Text = "0000";
            // 
            // tServiceControl
            // 
            this.tServiceControl.Controls.Add(this.tcServiceSub);
            this.tServiceControl.Location = new System.Drawing.Point(4, 29);
            this.tServiceControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tServiceControl.Name = "tServiceControl";
            this.tServiceControl.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tServiceControl.Size = new System.Drawing.Size(2020, 1085);
            this.tServiceControl.TabIndex = 3;
            this.tServiceControl.Text = "Palveluiden hallinta";
            this.tServiceControl.UseVisualStyleBackColor = true;
            // 
            // tcServiceSub
            // 
            this.tcServiceSub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcServiceSub.Controls.Add(this.stCottageControl);
            this.tcServiceSub.Controls.Add(this.stService);
            this.tcServiceSub.Location = new System.Drawing.Point(0, 0);
            this.tcServiceSub.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcServiceSub.Name = "tcServiceSub";
            this.tcServiceSub.SelectedIndex = 0;
            this.tcServiceSub.Size = new System.Drawing.Size(2022, 1085);
            this.tcServiceSub.TabIndex = 0;
            // 
            // stCottageControl
            // 
            this.stCottageControl.Controls.Add(this.cbCottageCapacity);
            this.stCottageControl.Controls.Add(this.cbCottagePostal);
            this.stCottageControl.Controls.Add(this.cbCottageRegions);
            this.stCottageControl.Controls.Add(this.lblMokkiID);
            this.stCottageControl.Controls.Add(this.tbCottageDescription);
            this.stCottageControl.Controls.Add(this.tbCottageEqupment);
            this.stCottageControl.Controls.Add(this.tbCottageStreetAddress);
            this.stCottageControl.Controls.Add(this.tbCottageName);
            this.stCottageControl.Controls.Add(this.btnCottageDelete);
            this.stCottageControl.Controls.Add(this.btnCottageAdd);
            this.stCottageControl.Controls.Add(this.btnCottageSearch);
            this.stCottageControl.Controls.Add(this.dgvCottage);
            this.stCottageControl.Controls.Add(this.label6);
            this.stCottageControl.Controls.Add(this.label7);
            this.stCottageControl.Controls.Add(this.label8);
            this.stCottageControl.Controls.Add(this.label9);
            this.stCottageControl.Controls.Add(this.label4);
            this.stCottageControl.Controls.Add(this.label5);
            this.stCottageControl.Controls.Add(this.label3);
            this.stCottageControl.Controls.Add(this.label2);
            this.stCottageControl.Location = new System.Drawing.Point(4, 29);
            this.stCottageControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stCottageControl.Name = "stCottageControl";
            this.stCottageControl.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stCottageControl.Size = new System.Drawing.Size(2014, 1052);
            this.stCottageControl.TabIndex = 0;
            this.stCottageControl.Text = "Mökkien hallinta";
            this.stCottageControl.UseVisualStyleBackColor = true;
            // 
            // cbCottageCapacity
            // 
            this.cbCottageCapacity.FormattingEnabled = true;
            this.cbCottageCapacity.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6+"});
            this.cbCottageCapacity.Location = new System.Drawing.Point(146, 249);
            this.cbCottageCapacity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCottageCapacity.Name = "cbCottageCapacity";
            this.cbCottageCapacity.Size = new System.Drawing.Size(294, 28);
            this.cbCottageCapacity.TabIndex = 23;
            // 
            // cbCottagePostal
            // 
            this.cbCottagePostal.FormattingEnabled = true;
            this.cbCottagePostal.Location = new System.Drawing.Point(146, 128);
            this.cbCottagePostal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCottagePostal.Name = "cbCottagePostal";
            this.cbCottagePostal.Size = new System.Drawing.Size(294, 28);
            this.cbCottagePostal.TabIndex = 22;
            // 
            // cbCottageRegions
            // 
            this.cbCottageRegions.FormattingEnabled = true;
            this.cbCottageRegions.Location = new System.Drawing.Point(146, 86);
            this.cbCottageRegions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCottageRegions.Name = "cbCottageRegions";
            this.cbCottageRegions.Size = new System.Drawing.Size(292, 28);
            this.cbCottageRegions.TabIndex = 21;
            // 
            // lblMokkiID
            // 
            this.lblMokkiID.AutoSize = true;
            this.lblMokkiID.Location = new System.Drawing.Point(146, 62);
            this.lblMokkiID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMokkiID.Name = "lblMokkiID";
            this.lblMokkiID.Size = new System.Drawing.Size(45, 20);
            this.lblMokkiID.TabIndex = 20;
            this.lblMokkiID.Text = "0000";
            // 
            // tbCottageDescription
            // 
            this.tbCottageDescription.Location = new System.Drawing.Point(146, 331);
            this.tbCottageDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCottageDescription.Multiline = true;
            this.tbCottageDescription.Name = "tbCottageDescription";
            this.tbCottageDescription.Size = new System.Drawing.Size(295, 136);
            this.tbCottageDescription.TabIndex = 19;
            // 
            // tbCottageEqupment
            // 
            this.tbCottageEqupment.Location = new System.Drawing.Point(146, 291);
            this.tbCottageEqupment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCottageEqupment.Name = "tbCottageEqupment";
            this.tbCottageEqupment.Size = new System.Drawing.Size(294, 26);
            this.tbCottageEqupment.TabIndex = 18;
            // 
            // tbCottageStreetAddress
            // 
            this.tbCottageStreetAddress.Location = new System.Drawing.Point(146, 209);
            this.tbCottageStreetAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCottageStreetAddress.Name = "tbCottageStreetAddress";
            this.tbCottageStreetAddress.Size = new System.Drawing.Size(295, 26);
            this.tbCottageStreetAddress.TabIndex = 16;
            // 
            // tbCottageName
            // 
            this.tbCottageName.Location = new System.Drawing.Point(146, 169);
            this.tbCottageName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCottageName.Name = "tbCottageName";
            this.tbCottageName.Size = new System.Drawing.Size(295, 26);
            this.tbCottageName.TabIndex = 15;
            // 
            // btnCottageDelete
            // 
            this.btnCottageDelete.Location = new System.Drawing.Point(116, 551);
            this.btnCottageDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCottageDelete.Name = "btnCottageDelete";
            this.btnCottageDelete.Size = new System.Drawing.Size(158, 71);
            this.btnCottageDelete.TabIndex = 11;
            this.btnCottageDelete.Text = "Poista valittu mökki";
            this.btnCottageDelete.UseVisualStyleBackColor = true;
            // 
            // btnCottageAdd
            // 
            this.btnCottageAdd.Location = new System.Drawing.Point(282, 551);
            this.btnCottageAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCottageAdd.Name = "btnCottageAdd";
            this.btnCottageAdd.Size = new System.Drawing.Size(158, 71);
            this.btnCottageAdd.TabIndex = 10;
            this.btnCottageAdd.Text = "Lisää uusi mökki";
            this.btnCottageAdd.UseVisualStyleBackColor = true;
            // 
            // btnCottageSearch
            // 
            this.btnCottageSearch.Location = new System.Drawing.Point(327, 495);
            this.btnCottageSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCottageSearch.Name = "btnCottageSearch";
            this.btnCottageSearch.Size = new System.Drawing.Size(112, 35);
            this.btnCottageSearch.TabIndex = 9;
            this.btnCottageSearch.Text = "Etsi mökki";
            this.btnCottageSearch.UseVisualStyleBackColor = true;
            // 
            // dgvCottage
            // 
            this.dgvCottage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCottage.Location = new System.Drawing.Point(472, 9);
            this.dgvCottage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCottage.Name = "dgvCottage";
            this.dgvCottage.RowHeadersWidth = 51;
            this.dgvCottage.Size = new System.Drawing.Size(1522, 1026);
            this.dgvCottage.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 295);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Varustelu:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 254);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Henkilömäärä:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 335);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Kuvaus:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 214);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Katuosoite:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 174);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mökin nimi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Postinumero:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Toiminta-alue:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mökki-ID:";
            // 
            // stService
            // 
            this.stService.Controls.Add(this.btnServiceDelete);
            this.stService.Controls.Add(this.btnServiceAdd);
            this.stService.Controls.Add(this.btnServiceSearch);
            this.stService.Controls.Add(this.label14);
            this.stService.Controls.Add(this.tbServiceDescription);
            this.stService.Controls.Add(this.label13);
            this.stService.Controls.Add(this.label12);
            this.stService.Controls.Add(this.tbServicePrice);
            this.stService.Controls.Add(this.tbServiceVAT);
            this.stService.Controls.Add(this.tbServiceType);
            this.stService.Controls.Add(this.label11);
            this.stService.Controls.Add(this.tbServiceName);
            this.stService.Controls.Add(this.label10);
            this.stService.Controls.Add(this.cbServiceRegion);
            this.stService.Controls.Add(this.lblServiceID);
            this.stService.Controls.Add(this.dgvService);
            this.stService.Controls.Add(this.label17);
            this.stService.Controls.Add(this.label18);
            this.stService.Location = new System.Drawing.Point(4, 29);
            this.stService.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stService.Name = "stService";
            this.stService.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stService.Size = new System.Drawing.Size(2014, 1052);
            this.stService.TabIndex = 1;
            this.stService.Text = "Palveluiden hallinta";
            this.stService.UseVisualStyleBackColor = true;
            // 
            // btnServiceDelete
            // 
            this.btnServiceDelete.Location = new System.Drawing.Point(116, 475);
            this.btnServiceDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnServiceDelete.Name = "btnServiceDelete";
            this.btnServiceDelete.Size = new System.Drawing.Size(158, 71);
            this.btnServiceDelete.TabIndex = 54;
            this.btnServiceDelete.Text = "Poista valittu palvelu";
            this.btnServiceDelete.UseVisualStyleBackColor = true;
            // 
            // btnServiceAdd
            // 
            this.btnServiceAdd.Location = new System.Drawing.Point(282, 475);
            this.btnServiceAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnServiceAdd.Name = "btnServiceAdd";
            this.btnServiceAdd.Size = new System.Drawing.Size(158, 71);
            this.btnServiceAdd.TabIndex = 53;
            this.btnServiceAdd.Text = "Lisää uusi palvelu";
            this.btnServiceAdd.UseVisualStyleBackColor = true;
            // 
            // btnServiceSearch
            // 
            this.btnServiceSearch.Location = new System.Drawing.Point(327, 431);
            this.btnServiceSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnServiceSearch.Name = "btnServiceSearch";
            this.btnServiceSearch.Size = new System.Drawing.Size(112, 35);
            this.btnServiceSearch.TabIndex = 52;
            this.btnServiceSearch.Text = "Etsi palvelu";
            this.btnServiceSearch.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(68, 248);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 20);
            this.label14.TabIndex = 51;
            this.label14.Text = "Kuvaus:";
            // 
            // tbServiceDescription
            // 
            this.tbServiceDescription.Location = new System.Drawing.Point(146, 243);
            this.tbServiceDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbServiceDescription.Multiline = true;
            this.tbServiceDescription.Name = "tbServiceDescription";
            this.tbServiceDescription.Size = new System.Drawing.Size(292, 176);
            this.tbServiceDescription.TabIndex = 50;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(84, 214);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 20);
            this.label13.TabIndex = 49;
            this.label13.Text = "Hinta:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(268, 214);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 20);
            this.label12.TabIndex = 48;
            this.label12.Text = "Alv:";
            // 
            // tbServicePrice
            // 
            this.tbServicePrice.Location = new System.Drawing.Point(146, 209);
            this.tbServicePrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbServicePrice.Name = "tbServicePrice";
            this.tbServicePrice.Size = new System.Drawing.Size(112, 26);
            this.tbServicePrice.TabIndex = 47;
            // 
            // tbServiceVAT
            // 
            this.tbServiceVAT.Location = new System.Drawing.Point(315, 209);
            this.tbServiceVAT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbServiceVAT.Name = "tbServiceVAT";
            this.tbServiceVAT.Size = new System.Drawing.Size(122, 26);
            this.tbServiceVAT.TabIndex = 46;
            // 
            // tbServiceType
            // 
            this.tbServiceType.Location = new System.Drawing.Point(146, 169);
            this.tbServiceType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbServiceType.Name = "tbServiceType";
            this.tbServiceType.Size = new System.Drawing.Size(292, 26);
            this.tbServiceType.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(75, 174);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 20);
            this.label11.TabIndex = 44;
            this.label11.Text = "Tyyppi:";
            // 
            // tbServiceName
            // 
            this.tbServiceName.Location = new System.Drawing.Point(146, 128);
            this.tbServiceName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbServiceName.Name = "tbServiceName";
            this.tbServiceName.Size = new System.Drawing.Size(292, 26);
            this.tbServiceName.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(92, 132);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 20);
            this.label10.TabIndex = 42;
            this.label10.Text = "Nimi:";
            // 
            // cbServiceRegion
            // 
            this.cbServiceRegion.FormattingEnabled = true;
            this.cbServiceRegion.Location = new System.Drawing.Point(146, 86);
            this.cbServiceRegion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbServiceRegion.Name = "cbServiceRegion";
            this.cbServiceRegion.Size = new System.Drawing.Size(292, 28);
            this.cbServiceRegion.TabIndex = 41;
            // 
            // lblServiceID
            // 
            this.lblServiceID.AutoSize = true;
            this.lblServiceID.Location = new System.Drawing.Point(146, 62);
            this.lblServiceID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServiceID.Name = "lblServiceID";
            this.lblServiceID.Size = new System.Drawing.Size(45, 20);
            this.lblServiceID.TabIndex = 40;
            this.lblServiceID.Text = "0000";
            // 
            // dgvService
            // 
            this.dgvService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvService.Location = new System.Drawing.Point(478, 14);
            this.dgvService.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvService.Name = "dgvService";
            this.dgvService.RowHeadersWidth = 51;
            this.dgvService.Size = new System.Drawing.Size(1522, 1026);
            this.dgvService.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(27, 91);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(115, 20);
            this.label17.TabIndex = 25;
            this.label17.Text = "Toiminta-alue:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(48, 62);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 20);
            this.label18.TabIndex = 24;
            this.label18.Text = "Palvelu-ID:";
            // 
            // tBilling
            // 
            this.tBilling.Location = new System.Drawing.Point(4, 29);
            this.tBilling.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBilling.Name = "tBilling";
            this.tBilling.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBilling.Size = new System.Drawing.Size(2020, 1085);
            this.tBilling.TabIndex = 5;
            this.tBilling.Text = "Laskut";
            this.tBilling.UseVisualStyleBackColor = true;
            // 
            // RentCottage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.tcMain);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RentCottage";
            this.Text = "RentCottage";
            this.Load += new System.EventHandler(this.RentCottage_Load);
            this.tcMain.ResumeLayout(false);
            this.tAreaControl.ResumeLayout(false);
            this.tAreaControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegion)).EndInit();
            this.tCustomerControl.ResumeLayout(false);
            this.tCustomerControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tServiceControl.ResumeLayout(false);
            this.tcServiceSub.ResumeLayout(false);
            this.stCottageControl.ResumeLayout(false);
            this.stCottageControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCottage)).EndInit();
            this.stService.ResumeLayout(false);
            this.stService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).EndInit();
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
        private System.Windows.Forms.Button btnRegionAdd;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.DataGridView dgvRegion;
        private System.Windows.Forms.Button btnRegionDelete;
        private System.Windows.Forms.Label lblRegionID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCottageCapacity;
        private System.Windows.Forms.ComboBox cbCottagePostal;
        private System.Windows.Forms.ComboBox cbCottageRegions;
        private System.Windows.Forms.Label lblMokkiID;
        private System.Windows.Forms.TextBox tbCottageDescription;
        private System.Windows.Forms.TextBox tbCottageEqupment;
        private System.Windows.Forms.TextBox tbCottageStreetAddress;
        private System.Windows.Forms.TextBox tbCottageName;
        private System.Windows.Forms.Button btnCottageDelete;
        private System.Windows.Forms.Button btnCottageAdd;
        private System.Windows.Forms.Button btnCottageSearch;
        private System.Windows.Forms.DataGridView dgvCottage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbServicePrice;
        private System.Windows.Forms.TextBox tbServiceVAT;
        private System.Windows.Forms.TextBox tbServiceType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbServiceName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbServiceRegion;
        private System.Windows.Forms.Label lblServiceID;
        private System.Windows.Forms.DataGridView dgvService;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbServiceDescription;
        private System.Windows.Forms.Button btnServiceDelete;
        private System.Windows.Forms.Button btnServiceAdd;
        private System.Windows.Forms.Button btnServiceSearch;
        private System.Windows.Forms.TextBox tbRegionName;
        private System.Windows.Forms.Button btnCustomerSearch;
        private System.Windows.Forms.TextBox tbCustomerPhone;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbCustomerEmail;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbCustomerAddress;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbCustomerLName;
        private System.Windows.Forms.TextBox tbCustomerFName;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbCustomerPostal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCustomerDeleteInfo;
        private System.Windows.Forms.Button btnCustomerAdd;
    }
}

