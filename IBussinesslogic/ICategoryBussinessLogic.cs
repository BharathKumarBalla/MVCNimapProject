using MVCNimapProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNimapProject.IBussinesslogic
{
    public  interface ICategoryBussinessLogic
    {
        List<Category> GetCategories();
        Category GetCategoryById(int categoryid);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategoryById(int categoryid);
    }
}
