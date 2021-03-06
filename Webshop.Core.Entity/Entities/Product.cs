﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Webshop.Core.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
    }
}
