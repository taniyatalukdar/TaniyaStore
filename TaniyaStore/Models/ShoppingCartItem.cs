﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaniyaStore.Models
{
    public class ShoppingCartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}