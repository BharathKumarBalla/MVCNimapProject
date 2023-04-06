using MVCNimapProject.BussinessLogic;
using MVCNimapProject.Models;
using MVCNimapProject.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNimapProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductDetails Along With Category Details Also

        ProductBussinessLogic productBussinessLogic = new ProductBussinessLogic();
        CategoryBussinessLogic categoryBussinessLogic = new CategoryBussinessLogic();

        Product product = new Product();


        public ActionResult Index(string Search, int? i)
        {
            var productsWithCategories = productBussinessLogic.GetProductsWithCategories().ToPagedList(i ?? 1, 10);
            return View(productsWithCategories);
        }


        // GETBy Id Based: Product Details By Id
        public ActionResult Details(int id)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            ViewBag.Categories = categoryBussinessLogic.GetCategories();
            Product product = new Product();
            product.ProductId = id;
            var datadetails = productBussinessLogic.GetProductById(id);
            return View(datadetails);
        }


        // Adding New Product 
        public ActionResult Create()
        {
            //CategoryBussinessLogic categoryBussinessLogic = new CategoryBussinessLogic();

            ViewBag.Categories = new SelectList(categoryBussinessLogic.GetCategories(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    productBussinessLogic.AddProduct(product);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        
        }


        // Update Existing Product from ProductDetails
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(categoryBussinessLogic.GetCategories(), "CategoryId", "CategoryName");
            var data = productBussinessLogic.GetProductById(id);
               return View(data);
        }
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    productBussinessLogic.UpdateProduct(product);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // Delete Existing Product from ProductDetails
        public ActionResult Delete(int id)
        {
            //Product product = new Product();
            product.ProductId = id;
            var datadelete = productBussinessLogic.GetProductById(id);
            return View(datadelete);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            var deletedata = productBussinessLogic.DeleteProductById(id);
            return RedirectToAction("Index");
        }
    }
}