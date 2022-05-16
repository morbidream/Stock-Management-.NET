using System;
using System.Collections.Generic;
using System.Text;

namespace ED.Domain
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }

        public virtual IList<Product> Products { get; set; }
    }
}
