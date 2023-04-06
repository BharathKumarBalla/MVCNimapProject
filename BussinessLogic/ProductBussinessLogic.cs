using MVCNimapProject.IBussinesslogic;
using MVCNimapProject.IRepository;
using MVCNimapProject.Models;
using MVCNimapProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNimapProject.BussinessLogic
{
    public class ProductBussinessLogic : IProductBussinessLogic
    {

        ProductRepository productRepository = new ProductRepository();

        //This Method is used Add a New Product By Id Based returning to the Product Repository
        public bool AddProduct(Product product)
        {
            try
            {
                return productRepository.AddProduct(product);
            }
            catch (Exception)
            {

                return false;
            }

        }

        //This Method is used Delete a existing Product By Id Based returning to the Product Repository
        public bool DeleteProductById(int id)
        {
            try
            {
                return productRepository.DeleteProductById(id);
            }
            catch (Exception)
            {

                return false;
            }
        }


        //This Method is used Fetch ProductBy Id Based returning to the Product Repository
        public Product GetProductById(int id)
        {
            try
            {
                return productRepository.GetProductById(id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        //This Method is used Fetch Product Details With Categories returning to the Product Repository
        public List<ProductsWithCategory> GetProductsWithCategories()
        {
            {
                try
                {
                    return productRepository.GetProductsWithCategories();
                }
                catch (Exception)
                {

                    return null;
                }
            }


        }

        //This Method is used to update existing Product returning to the Product Repository
        public bool UpdateProduct(Product product)
        {
            try
            {
                return productRepository.UpdateProduct(product);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}