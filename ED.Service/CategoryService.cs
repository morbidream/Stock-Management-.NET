using ED.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ED.Data.Infrastructure;

namespace ED.Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork utwk):base(utwk)
        {                
        }
        
    }
}
