using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ED.Data.Infrastructure
{
    public interface IDataBaseFactory : IDisposable
    {
        DbContext DataContext { get; }
    }
}
