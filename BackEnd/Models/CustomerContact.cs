using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public class CustomerContact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }

        public int CustomerID { get; set; }
    }
}
