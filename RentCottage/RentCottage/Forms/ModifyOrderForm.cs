using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCottage
{
    public partial class ModifyOrderForm : Form
    {
        public ModifyOrderForm(Order o)
        {
            InitializeComponent();
            lbOrder_ModifyOrderID.Text = o.OrderID.ToString();
            lbOrder_ModifyCustomerID.Text = o.CustomerID.ToString();
            lbOrder_ModifyCottageID.Text = o.CottageID.ToString();
            lbOrder_ModifyOrderDate.Text = o.Order_date;
            lbOrder_ModifyPaymentDate.Text = o.Payment_date;
            dtpOrder_ModifyStartDate.Text = o.Start_date;
            dtpOrder_ModifyEndDate.Text = o.End_date;
        }

        private void btmOrder_OrderModify_Click(object sender, EventArgs e)
        {

        }

        private void btmOrder_OrderModifyCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
