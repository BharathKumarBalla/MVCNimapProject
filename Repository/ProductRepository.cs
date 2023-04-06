using MVCNimapProject.IRepository;
using MVCNimapProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCNimapProject.Repository
{
    public class ProductRepository: IProductRepository
    {
        //This Method is used to Add new Product 
        public bool AddProduct(Product product)
        {
            try
            {
                string stringConnection = System.Configuration.ConfigurationManager.ConnectionStrings["NimapConnection"].ConnectionString;
                SqlConnection sqlconnect = new SqlConnection(stringConnection);
                SqlCommand sqlcommand = new SqlCommand("spAddProduct", sqlconnect);
                sqlconnect.Open();
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Parameters.AddWithValue("@ProductName", product.ProductName);
                sqlcommand.Parameters.AddWithValue("@CategoryID", product.CategoryName);
                sqlcommand.ExecuteNonQuery();
                sqlconnect.Close();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }


        //This Method is used to Delete an existing Product  from ProductList
        public bool DeleteProductById(int id)
        {
            try
            {
                string stringConnection = System.Configuration.ConfigurationManager.ConnectionStrings["NimapConnection"].ConnectionString;
                SqlConnection sqlconnect = new SqlConnection(stringConnection);
                SqlCommand sqlcommand = new SqlCommand("spDeleteProduct", sqlconnect);
                sqlconnect.Open();
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Parameters.AddWithValue("@Id", id);
                sqlcommand.ExecuteNonQuery();
                sqlconnect.Close();
                return true;


            }
            catch (Exception)
            {

                return false;
            }
        }


        //This Method is used to Fetch all Required Task Details
        public List<ProductsWithCategory> GetProductsWithCategories()
        {
            try
            {
                List<ProductsWithCategory> productsWithCategories = new List<ProductsWithCategory>();
                string stringConnection = System.Configuration.ConfigurationManager.ConnectionStrings["NimapConnection"].ConnectionString;
                SqlConnection sqlconnect = new SqlConnection(stringConnection);
                SqlCommand sqlcommand = new SqlCommand("SpGetProductlist", sqlconnect);
                sqlconnect.Open();
                sqlcommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader datareader = sqlcommand.ExecuteReader();
                while (datareader.Read())
                {
                    ProductsWithCategory products = new ProductsWithCategory();

                    products.ProductId = Convert.ToInt32(datareader["ProductId"]);
                    products.ProductName = Convert.ToString(datareader["ProductName"]);
                    products.CategoryId = Convert.ToInt32(datareader["CategoryId"]);
                    products.CategoryName = Convert.ToString(datareader["CategoryName"]);

                    productsWithCategories.Add(products);
                }
                datareader.Close();
                sqlconnect.Close();
                return productsWithCategories;

            }
            catch (Exception)
            {

                return null;
            }
        }


        //This Method is used to Fetch all Required Task Details By Product Id Based

        public Product GetProductById(int id)
        {
            Product product = new Product();
            try
            {
                string stringConnection = System.Configuration.ConfigurationManager.ConnectionStrings["NimapConnection"].ConnectionString;
                SqlConnection sqlconnect = new SqlConnection(stringConnection);
                SqlCommand sqlcommand = new SqlCommand("spGetProductsById", sqlconnect);
                sqlconnect.Open();
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Parameters.AddWithValue("@Id", id);
                SqlDataReader datareader = sqlcommand.ExecuteReader();
                
                while (datareader.Read())
                {
                    product.ProductId = Convert.ToInt32(datareader["ProductId"]);
                    product.ProductName = Convert.ToString(datareader["ProductName"]);
                    product.CategoryName = Convert.ToInt32(datareader["CategoryID"]);
                }
                datareader.Close();
                sqlconnect.Close();
                return product;

            }
            catch (Exception ex)
            {

                return null;
            }
        }


        //This Method is used to update existing Product 
        public bool UpdateProduct(Product product)
        {
            try
            {
                string stringConnection = System.Configuration.ConfigurationManager.ConnectionStrings["NimapConnection"].ConnectionString;
                SqlConnection sqlconnect = new SqlConnection(stringConnection);
                SqlCommand sqlcommand = new SqlCommand("spUpdateProduct", sqlconnect);
                sqlconnect.Open();
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Parameters.AddWithValue("@ProductId", product.ProductId);
                sqlcommand.Parameters.AddWithValue("@ProductName", product.ProductName);
                sqlcommand.Parameters.AddWithValue("@CategoryID", product.CategoryName);

                sqlcommand.ExecuteNonQuery();
                sqlconnect.Close();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }



    }
}