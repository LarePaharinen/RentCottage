using MySql.Data.MySqlClient;
using RentCottage.Code;
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
    public partial class AddServiceForm : Form
    {
        public AddServiceForm()
        {
            InitializeComponent();
            RegionUtils.PopulateCBRegion(cbAddServiceRegion);
        }
        
    }
}
