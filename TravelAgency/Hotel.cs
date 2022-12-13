using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Hotel
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string HotelCategory { get; set; }
        public string Name { get; set; }      
        public virtual Countrie Countries { get; set; }

        //public Hotel(int price, string hotel_Category, string name, Countrie countries)
        //{
        //    Price = price;
        //    Name = name;
        //    HotelCategory = hotel_Category;
        //    Countries = countries;
        //}
    }
}
