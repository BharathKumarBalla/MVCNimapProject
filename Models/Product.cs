using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCNimapProject.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter ProductName"), MaxLength(45)]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }


        [Required(ErrorMessage = "Please Select CategoryName")]
        [DataType(DataType.Text)]
        public Nullable<int> CategoryName { get; set; }

    }
}