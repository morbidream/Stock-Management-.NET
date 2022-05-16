using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ED.Domain
{
    public class Facture
    {
        
        public int ProductFk { get; set; }

        public int ClientFk { get; set; }
    
        public DateTime DateAchat { get; set; }
        public double Prix { get; set; }
        //[ForeignKey("ClientFk")]
        public virtual Client Client { get; set; }
       // [ForeignKey("ProductFk")]
        public virtual Product Product { get; set; }

    }
}
