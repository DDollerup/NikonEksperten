using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NikonEksperten.Models;

namespace NikonEksperten.Factory
{
    public class DBContext
    {
        private AutoFactory<Product> productFactory;
        private AutoFactory<Category> categoryFactory;

        public AutoFactory<Product> ProductFactory
        {
            get
            {
                if (productFactory == null)
                {
                    productFactory = new AutoFactory<Product>();
                }
                return productFactory;
            }
        }
        public AutoFactory<Category> CategoryFactory
        {
            get
            {
                if (categoryFactory == null)
                {
                    categoryFactory = new AutoFactory<Category>();
                }
                return categoryFactory;
            }
        }
    }
}