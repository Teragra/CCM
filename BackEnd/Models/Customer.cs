using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Customer
    {

        public int ID { get; set; }

        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public ICollection<CustomerContact> Contacts { get; set; }


    }
}
