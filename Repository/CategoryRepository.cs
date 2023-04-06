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
    public class CategoryRepository : ICategoryRepository
    {
        List<Category> categories = new List<Category>();
        //This Method is used to Add New Category
        public bool AddCategory(Category category)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NimapConnection"].ConnectionString;
                SqlConnection sqlconnect = new SqlConnection(connectionString);
                SqlCommand sqlcommand = new SqlCommand("spAddCategory", sqlconnect);
                sqlconnect.Open();
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                sqlcommand.ExecuteNonQuery();
                sqlconnect.Close();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }


        //This Method is used to Delete Existing Category
        public bool DeleteCategoryById(int categoryid)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NimapConnection"].ConnectionString;
                SqlConnection sqlconnect = new SqlConnection(connectionString);
                SqlCommand sqlcommand = new SqlCommand("spDeleteCategoryById", sqlconnect);
                sqlconnect.Open();
                sqlcommand.CommandType = CommandType.StoredProcedure;
                //SqlParameter p1 = new SqlParameter();
                //p1.ParameterName = "@ct"; // Defining Name  
                //p1.SqlDbType = SqlDbType.VarChar; // Defining DataType  
                //p1.Direction = ParameterDirection.Input; // Setting the direction  

                sqlcommand.Parameters.AddWithValue("@CategoryId", categoryid);
                sqlcommand.ExecuteNonQuery();
                sqlconnect.Close();
                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
        }


        //This Method is used to Get All CategoryList 
        public List<Category> GetCategories()
        {
            try
            {
                List<Category> categories = new List<Category>();
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["NimapConnection"].ConnectionString;
                SqlConnection sqlconnect = new SqlConnection(connection);
                SqlCommand sqlcommand = new SqlCommand("spGetAllCategories", sqlconnect);
                sqlconnect.Open();
                sqlcommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader datareader = sqlcommand.ExecuteReader();
                while(datareader.Read())
                {
                    Category category = new Category();

                    category.CategoryId = Convert.ToInt32(datareader["CategoryId"]);
                    category.CategoryName = Convert.ToString(datareader["CategoryName"]);
                    categories.Add(category);
                }
                datareader.Close();
                sqlconnect.Close();
                return categories;

            }
            catch (Exception)
            {

                return null;
            }
        }

        //This Method is used to view particular  Category By Id Based And Category Edit also 

        public Category GetCategoryById(int categoryid)
        {
            Category category = new Category();
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NimapConnection"].ConnectionString;
                SqlConnection sqlconnect = new SqlConnection(connectionString);
                SqlCommand sqlcommand = new SqlCommand("spGetCategoryById", sqlconnect);
                sqlconnect.Open();
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Parameters.AddWithValue("@CategoryId", categoryid);
                SqlDataReader datareader = sqlcommand.ExecuteReader();
                
                while (datareader.Read())
                {
                    category.CategoryId = Convert.ToInt32(datareader["CategoryId"]);
                    category.CategoryName = Convert.ToString(datareader["CategoryName"]);

                }
                datareader.Close();
                sqlconnect.Close();
                return category;

            }
            catch (Exception)
            {

                return null;
            }
        }


        //This Method is used to update existing Category 
        public bool UpdateCategory(Category category)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NimapConnection"].ConnectionString;
                SqlConnection sqlconnect = new SqlConnection(connectionString);
                SqlCommand sqlcommand = new SqlCommand("spUpdateCategory", sqlconnect);
                sqlconnect.Open();
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                sqlcommand.Parameters.AddWithValue("@CategoryName", category.CategoryName);
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