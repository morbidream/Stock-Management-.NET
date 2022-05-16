using S = System; //~ import System; 
using ED.Domain;
using ED.Service;
using System.Collections.Generic;
using ED.Data;
using Microsoft.Extensions.DependencyInjection;
using ED.Data.Infrastructure;

namespace ED.Console //declarer un noveau namespace
{
    internal class Program //declarer une classe
    {
        static void Main(string[] args) // le point d'entré de notre application
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<ICategoryService, CategoryService>()
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddSingleton<IDataBaseFactory, DataBaseFactory>()
                .BuildServiceProvider();

            var categoryService = serviceProvider.GetService<ICategoryService>();

            categoryService.Add(DataTest.Categories[0]);
            categoryService.Commit();
        }

        public static void ChangeValue(ref int myParam, params int [] t)
        {
            S.Random rd = new S.Random();
            myParam = rd.Next(100,200);
            S.Console.WriteLine("la valeur de myParam est: "+myParam);
        }
    }
}
