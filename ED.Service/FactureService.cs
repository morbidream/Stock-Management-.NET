using ED.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ED.Data.Infrastructure;

namespace ED.Service
{
    public class FactureService : Service<Facture>, IFactureService
    {
        public FactureService(IUnitOfWork utwk):base(utwk)
        {                
        }
        public List<Product> GetProdsByClient(Client c)
        {
            return GetMany().Where(f=>f.ClientFk==c.CIN)
                .Select(f=>f.Product).ToList();
        }
    }
}
