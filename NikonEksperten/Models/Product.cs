using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikonEksperten.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int ManufactureID { get; set; }
        public int StorageAmount { get; set; }
        public string Image { get; set; }
    }
}