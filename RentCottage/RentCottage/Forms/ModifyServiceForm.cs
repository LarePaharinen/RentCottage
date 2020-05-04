using RentCottage.Code;
using RentCottage.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCottage.Forms
{
    public partial class ModifyServiceForm : Form
    {
        public ModifyServiceForm()
        {
            InitializeComponent();
            RegionUtils.PopulateCBRegion(cbModifyServiceRegion);
        }

        public ModifyServiceForm(Service s)
        {
            //Used to import services data to from
            InitializeComponent();
            RegionUtils.PopulateCBRegion(cbModifyServiceRegion);
            lblModifyServiceID.Text = s.ServiceID.ToString();
            cbModifyServiceRegion.SelectedItem = RegionUtils.RegionIndexToName(s.RegionID);
            tbModifyServiceName.Text = s.Name;
            tbModifyServiceType.Text = s.Type.ToString();
            tbModifyServicePrice.Text = s.Price.ToString();
            tbModifyServiceVAT.Text = s.Vat.ToString();
            tbModifyServiceDescription.Text = s.Description;

        }

        private void btnModifyServiceCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
