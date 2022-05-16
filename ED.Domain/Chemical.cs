using System;
using System.Collections.Generic;
using System.Text;

namespace ED.Domain
{
    public class Chemical: Product
    {
        
        public string LabName { get; set; }
        public Address Address { get; set; }
       

        public override void GetMyType()
        {
            Console.WriteLine("je suis un produit chemique");
        }
    }
}
