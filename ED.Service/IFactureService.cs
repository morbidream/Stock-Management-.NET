using ED.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace ED.Service
{
    public interface IFactureService: IService<Facture>
    {
        public List<Product> GetProdsByClient(Client c);
    }
}
