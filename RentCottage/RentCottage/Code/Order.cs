using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCottage
{
    public class Order
    {
        private int orderID;
        private int customerID;
        private int cottageID;
        private string order_date;
        private string payment_date;
        private string start_date;
        private string end_date;

        public Order()
        {

        }

        public Order(int orderID, int customerID, int cottageID, string order_date, string payment_date, string start_date, string end_date)
        {
            this.orderID = orderID;
            this.customerID = customerID;
            this.cottageID = cottageID;
            this.order_date = order_date;
            this.payment_date = payment_date;
            this.start_date = start_date;
            this.end_date = end_date;
        }


        public int OrderID { get => orderID; set => orderID = value; }
        public int CustomerID { get => customerID; set => customerID = value; }
        public int CottageID { get => cottageID; set => cottageID = value; }
        public string Order_date { get => order_date; set => order_date = value; }
        public string Payment_date { get => payment_date; set => payment_date = value; }
        public string Start_date { get => start_date; set => start_date = value; }
        public string End_date { get => end_date; set => end_date = value; }
    }

}
