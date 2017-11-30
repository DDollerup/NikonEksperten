using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikonEksperten.Models
{
    public class ProductVM
    {
        public enum StorageStatus
        {
            inSupply,
            shortSupply,
            noSupply
        }

        public Product Product { get; set; }
        public Category Category { get; set; }
        public Manufacture Manufacture { get; set; }


        public StorageStatus GetStatus()
        {
            if (Product.StorageAmount > 9)
            {
                return StorageStatus.inSupply;
            }
            else if (Product.StorageAmount >= 1 && Product.StorageAmount <= 9)
            {
                return StorageStatus.shortSupply;
            }
            else
            {
                return StorageStatus.noSupply;
            }
        }
    }
}