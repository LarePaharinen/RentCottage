using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCottage
{
    //Class for modelling and handling different services
    class Service
    {
        private int serviceID;
        private int regionID;
        private string name;
        private int type;
        private string description;
        private double price;
        private double vat;

        //Constructors
        public Service() { }
        public Service(int serviceID, int regionID, string name, int type, string description, double price, double vat)
        {
            this.serviceID = serviceID;
            this.regionID = regionID;
            this.name = name;
            this.type = type;
            this.description = description;
            this.price = price;
            this.vat = vat;
        }



        //Functions
        public int ServiceID { get => serviceID; set => serviceID = value; }
        public int RegionID { get => regionID; set => regionID = value; }
        public string Name { get => name; set => name = value; }
        public int Type { get => type; set => type = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }
        public double Vat { get => vat; set => vat = value; }
    }
}
