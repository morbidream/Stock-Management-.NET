using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ED.Domain;
using ED.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ED.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            IList<Product> list = new List<Product>();

            list = productService.GetMany().ToList();

            return View(list);
        }

        [HttpPost]
        public ActionResult Index(string filtre)
        {
            IList<Product> list = new List<Product>();
            if (filtre == "" || filtre == null)
            {
                list = productService.GetMany().ToList();
            }
            else
            {
                list = productService.GetMany(p => p.Name.Contains(filtre))
                    .ToList();
            }
            return View(list);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {

            return View(productService.GetById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var categories = categoryService.GetMany();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection, IFormFile FileImage)
        {
            try
            {
                if (FileImage != null)
                {
                    // F:\ProductStore\wwwroot\uploads\nomdefichier.extention
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", FileImage.FileName);
                    using (Stream strem = new FileStream(path, FileMode.Create))
                    {
                        FileImage.CopyTo(strem); // copier l'image dans le dossier uploads
                    }
                }
                collection.Image = FileImage.FileName;

                productService.Add(collection);
                productService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(
                categoryService.GetMany().ToList(),
                "CategoryId",
                "Name"
                );
            return View(productService.GetById(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product collection, IFormFile file)
        {
            try
            {
                if(file!=null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    collection.Image = file.FileName;
                }

                productService.Update(collection);
                productService.Commit();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(productService.GetById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                productService.Delete(collection);
                productService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
