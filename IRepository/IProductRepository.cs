using MVCNimapProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNimapProject.IRepository
{
    interface IProductRepository
    {
        List<ProductsWithCategory> GetProductsWithCategories();
        Product GetProductById(int id);
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProductById(int id);
    }
}
