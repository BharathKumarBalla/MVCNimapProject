﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNimapProject.Models
{
    public class ProductsWithCategory
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}