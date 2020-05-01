using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace RentCottage
{
    public class NewBook
    {
        //Variables
        private Cottage cottage;
        private DateTime dayFrom;
        private DateTime dayTo;

        //Constructors
        public NewBook() { }

        public NewBook(Cottage cottage, DateTime startday, DateTime endday)
        {
            
            this.cottage = cottage;
            this.dayFrom = startday;
            this.dayTo = endday;
        }

        //Functions
        public Cottage Cottage { get => cottage; set => cottage = value; }
        public DateTime Alkupv { get => dayFrom; set => dayFrom = value; }
        public DateTime Loppupv { get => dayTo; set => dayTo = value; }
    }
}
