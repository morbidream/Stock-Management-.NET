using System;
using System.Collections.Generic;
using System.Text;

namespace ED.Domain
{
    public class Biological: Product
    {
        public string Herbs { get; set; }

        public override void GetMyType()
        {
            Console.WriteLine("je suis un produit Bio");
        }
    }
}
