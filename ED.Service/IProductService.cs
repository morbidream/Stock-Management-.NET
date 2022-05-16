﻿using ED.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace ED.Service
{
   public interface IProductService: IService<Product>
    {
        public List<Product> FindMost5ExpensiveProds();

        public double UnavailableProductsPercentage();

        public void DeleteOldProducts();
    }
}
