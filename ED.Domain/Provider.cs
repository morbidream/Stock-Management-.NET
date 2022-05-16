using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ED.Domain
{
    public class Provider: Concept
    {
        public static int NbInstance { get; set; } = 0;
        [Key]
        public int Id { get; set; }
        [EmailAddress, Required]
        //[DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }
        string confirmPassword;
        [Required, 
            NotMapped,
            DataType(DataType.Password), 
            Compare("Password")]
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                if (value == password)
                    confirmPassword = value;
                else
                {
                    Console.WriteLine("Erreur, confirmPassword!=Password !!");
                }
            }
        }
        string password;
        [DataType(DataType.Password), 
            MinLength(8), 
            Required]
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length >= 5 && value.Length <= 20)
                { password = value; }
                else { Console.WriteLine("Erreur, password invalide!"); }
            }
        }
        public string UserName { get; set; }
        public bool IsApproved { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<Product> Products { get; set; }
        public Provider()
        {
            NbInstance++;
        }
        public Provider(int id, string userNmae, string password, string confirmPassword, string email, DateTime dateCreated)
        {
            Id = id;
            UserName = userNmae;
            this.password = password;
            this.confirmPassword = confirmPassword;
            Email = email;
            DateCreated = dateCreated;
            NbInstance++;
        }

        public static void SetIsApproved(Provider p)
        {
            //if (p.confirmPassword == p.password)
            //{
            //    p.IsApproved = true;
            //}
            //else
            //    {
            //    p.IsApproved = false;
            //}

            // p.IsApproved = p.confirmPassword == p.password ? true : false;

            p.IsApproved = p.confirmPassword == p.password;
        }

        public static void SetIsApproved(string password, string confirmPassword, ref bool isApproved)
        {
            isApproved = password == confirmPassword;
        }

        //public bool Login(string userName, string password)
        //{
        //    if (userName == UserName && password == Password)
        //    { return true; }
        //    else { return false; }
        //}

        //public bool Login(string userName, string password, string email)
        //{
        //    if (userName == UserName && password == Password && Email==email)
        //    { return true; }
        //    else { return false; }
        //}

        public bool Login(string userName, string password, string email = null)
        {
            if (email != null)
            {
                if (userName == UserName && password == Password && Email == email)
                { return true; }
                else { return false; }
            }
            else
            {
                if (userName == UserName && password == Password )
                { return true; }
                else { return false; }
            }
        }

        public override string ToString()
        {
            //return "["+id+","+userName+","+email+","+isApproved+"]";
            //
            //return $"[{Id},{UserName},{Email},{IsApproved}]";

           string str= $"[{Id},{UserName},{Email},{IsApproved}]";
            str = str+"\n La liste des produits: \n";
            //for (int i = 0; i < Products.Count; i++)
            //{
            //    str += "\t " + Products[i];
            //}

            foreach (Product item in Products)
            {
                str += "\t " + item;
            }
            return str;
        }

        public List<Product> GetProducts(string filterType, string filterValue)
        {
            List<Product> list = new List<Product>();
            foreach (var item in Products)
            {

                switch (filterType)
                {
                    case "Price":
                        {
                            double y= 0;
                            double.TryParse(filterValue, out y);
                            if (item.Price == y)
                            {
                                list.Add(item);
                            }
                            break;
                        }
                    case "Quantity":
                        int x = 0;
                        int.TryParse(filterValue, out x);
                        if (item.Price == x)
                        {
                            list.Add(item);
                        }
                        break;
                    default:
                        break;
                }

                
            }
            return list;
        }

        public override void GetDetails()
        {
            Console.WriteLine(ToString());
        }
    }
}
