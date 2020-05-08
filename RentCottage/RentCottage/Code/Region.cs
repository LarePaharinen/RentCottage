using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCottage.Code
{
    public class Region
    {
        //Variables
        private int regionID;
        private string name;

        //Constructors
        public Region()
        {

        }

        public Region(int regionID, string name)
        {
            this.regionID = regionID;
            this.name = name;
        }



        //Methods
        public int RegionID { get => regionID; set => regionID = value; }
        public string Name { get => name; set => name = value; }

    }
}
