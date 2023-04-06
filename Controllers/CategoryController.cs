using MVCNimapProject.BussinessLogic;
using MVCNimapProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MVCNimapProject.Controllers
{
    public class CategoryController : Controller
    {
        
        CategoryBussinessLogic categoryBussiness = new CategoryBussinessLogic();

        // GET: Categorydetails
        public ActionResult Index(string Search, int? i)
            {
                var categorydetails = categoryBussiness.GetCategories().ToPagedList(i ?? 1, 3);
                return View(categorydetails);
            }


        // GET Details: CategoryBy Id Based


        public ActionResult Details(int id)
            {
                Category category = new Category();
                category.CategoryId = id;
                var detailsById = categoryBussiness.GetCategoryById(id);
                return View(detailsById);
            }



        // Adding New Details: For Adding New Category
        public ActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Create(Category category)
            {
                var addingNewData = categoryBussiness.AddCategory(category);
                return RedirectToAction("Index");
            }


        // Updating Existing Details: For Updating Existing Category
        public ActionResult Edit(int id)
            {
                var getdatabyId = categoryBussiness.GetCategoryById(id);
                return View(getdatabyId);
            }
            [HttpPost]
            public ActionResult Edit(int id, Category category)
            {
                var updatedata = categoryBussiness.UpdateCategory(category);
                return RedirectToAction("Index");
            }



        // Delete Existing Details: For Delete Existing Category
        public ActionResult Delete(int id)
            {
               //Category category = new Category();
               //category.CategoryId = categoryid;

                Product product = new Product();
                product.ProductId = id;
                var deletedata = categoryBussiness.GetCategoryById(id);
                return View(deletedata);
            }
            [HttpPost]
            public ActionResult Delete(int id, Category category)
            {
                var datadelete = categoryBussiness.DeleteCategoryById(id);
                return RedirectToAction("Index");
            }

        }
    }