using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCNimapProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter CategoryName"), MaxLength(25)]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }
    }
}