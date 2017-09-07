using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exempeltenta.Models;
using Microsoft.AspNetCore.Identity;

namespace Exempeltenta.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                var tv = new ProductCategory { Name = "TV" };
                var dvd = new ProductCategory { Name = "DVD" };
                var vhs = new ProductCategory { Name = "VHS" };

                var product1 = new Product{Name = "Product1", Price = 100};
                var product2 = new Product { Name = "Product2", Price = 200 };
                var product3 = new Product { Name = "Product3", Price = 300 };

                dvd.Products = new List<Product>{product1};
                tv.Products = new List<Product> { product2 };
                vhs.Products = new List<Product> { product3 };

                context.AddRange(product1, product2, product3);
                context.AddRange(tv, dvd, vhs);

                context.SaveChanges();
            }
        }

        
    }
}
