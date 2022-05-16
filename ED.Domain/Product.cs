using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ED.Domain
{
    public class Product : Concept
    {
        [Key]
        public int ProductKey { get; set; }
        [Required(ErrorMessage ="Name is Required"),
            StringLength(25, ErrorMessage ="Name must have 25 caracters"),
            MaxLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Date), Display(Name ="Date Production")]
        public DateTime DateProd { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
        //[ForeignKey("Category")]
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual IList<Client> Clients { get; set; }

        public virtual IList<Facture> Factures { get; set; }

        public virtual List<Provider> Providers { get; set; }

        public override void GetDetails()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{Name}, {Price}, {Quantity}, {DateProd}";
        }

        public virtual void GetMyType()
        {
            Console.WriteLine("je suis un produit");
        }
    }
}
