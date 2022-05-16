using System;
using System.Collections.Generic;
using System.Text;
using ED.Domain;
using System.Linq;
using ServicePattern;
using ED.Data.Infrastructure;

namespace ED.Service
{
    public class ProviderServices:Service<Provider>, IProviderService
    {       
        public ProviderServices(IUnitOfWork utwk):base(utwk)
        {
                
        }
       // public ProviderServices(List<Provider> providers)
       // {
       //     Providers = providers;
       // }

       // public List<Provider> Providers { get; set; }


       // public List<Provider> GetProviderByName(string name)
       // {
       //     //List<Provider> list = new List<Provider>();
       //     //foreach (var item in Providers)
       //     //{
       //     //    if (item.UserName.Contains(name))
       //     //    {
       //     //        list.Add(item);
       //     //    }
       //     //}

       //     //return list;
       //     //Syntaxe de requete integré
       //     //var query = from p in Providers
       //     //            where p.UserName.Contains(name)
       //     //            select new { p.IsApproved, p.UserName };
       //     //var query = from p in Providers
       //     //            where p.UserName.Contains(name)
       //     //            select p.IsApproved;
       //     //var query = from p in Providers
       //     //            where p.UserName.Contains(name)
       //     //            select p;

       //     //Syntaxe des methodes
       //     //var query= Providers
       //     //    .Where(p=> p.UserName.Contains(name))
       //     //    .Select(p=> p)//optionnel;
       //     //var query = Providers
       //     //    .Where(p => p.UserName.Contains(name))
       //     //    .Select(p => p.UserName);
       //     //var query = Providers
       //     //    .Where(p => p.UserName.Contains(name))
       //     //    .Select(p => new { p.UserName, p.IsApproved });

       //     var query = Providers
       //        .Where(p => p.UserName.Contains(name))
       //        ;

       //     return query.ToList();//execution de requete + convertion de type
       // }


       // public Provider GetFirstProviderByName(string name)
       // {
       //     //var query = (from p in Providers
       //     //            where p.UserName.Contains(name)
       //     //            select p).First();//FirstOrDefault()

       //     return Providers
       //         .Where(p => p.UserName.Contains(name))
       //         .First();
       //}

       // public Provider GetProviderById(int id)
       // {
       //     return Providers
       //         .Where(p => p.Id == id)
       //         .Single();//SingleOrDefaut()
       // }


    }
}
