using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RentCottage
{
    //Class for modelling and handling cottages
    public class Cottage
    {
        //Variables
        private int cottageID;
        private int regionID;
        private string postal;
        private string name;
        private string address;
        private string description;
        private int capacity;
        private string equipment;
        private double price;
        

        //Constructors
        public Cottage() { }

        public Cottage(int cottageID, int regionID, string postal, string name, string address, string description, int capacity, string equipment, double price)
        {
            this.cottageID = cottageID;
            this.regionID = regionID;
            this.postal = postal;
            this.name = name;
            this.address = address;
            this.description = description;
            this.capacity = capacity;
            this.equipment = equipment;
            this.price = price;
        }
        public Cottage(int cottageID, int regionID, string postal, string name, string address, string description, int capacity, double price)
        {
            this.cottageID = cottageID;
            this.regionID = regionID;
            this.postal = postal;
            this.name = name;
            this.address = address;
            this.description = description;
            this.capacity = capacity;
            this.price = price;
        }

        public Cottage(int cottageID, int regionID, string postal, string name, string address, string description, int capacity, double price, string equipment)
        {
            this.cottageID = cottageID;
            this.regionID = regionID;
            this.postal = postal;
            this.name = name;
            this.address = address;
            this.description = description;
            this.capacity = capacity;
            this.equipment = equipment;
            this.price = price;
        }

        //Functions
        public int CottageID { get => cottageID; set => cottageID = value; }
        public int RegionID { get => regionID; set => regionID = value; }
        public string Postal { get => postal; set => postal = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Description { get => description; set => description = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public string Equipment { get => equipment; set => equipment = value; }
        public double Price { get => price; set => price = value; }
    }
}
