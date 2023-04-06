using MVCNimapProject.IBussinesslogic;
using MVCNimapProject.Models;
using MVCNimapProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNimapProject.BussinessLogic
{
    public class CategoryBussinessLogic : ICategoryBussinessLogic
    {

        CategoryRepository categoryRepository = new CategoryRepository();

        //This Method is used to Add a new Category  returning to the Category Repository
        public bool AddCategory(Category category)
        {
            try
            {
                return categoryRepository.AddCategory(category);
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        //This Method is used to Delete existing Category  returning to the Category Repository

        public bool DeleteCategoryById(int categoryid)
        {
            try
            {
                return categoryRepository.DeleteCategoryById(categoryid);
            }
            catch (Exception)
            {

                return false;
            }
        }

        //This Method is used to Fetch existing CategoryDetails By List  returning to the Category Repository

        public List<Category> GetCategories()
        {
            try
            {
                return categoryRepository.GetCategories();
            }
            catch (Exception)
            {

                return null;
            }
        }

        //This Method is used to Fetch existing Category By CategoryId Based returning to the Category Repository

        public Category GetCategoryById(int categoryid)
        {
            try
            {
              
                return categoryRepository.GetCategoryById(categoryid);
            }
            catch (Exception)
            {

                return null;
            }
        }

        //This Method is used to update existing Category returning to the Category Repository

        public bool UpdateCategory(Category category)
        {
            try
            {
                return categoryRepository.UpdateCategory(category);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}