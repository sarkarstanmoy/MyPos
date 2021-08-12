﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class Catalog
    {
        public int CatalogId { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public string CatagoryName { get; set; }
        public string UOM { get; set; }
        public string HSNCode { get; set; }
        public decimal PurchaseRate { get; set; }
        public decimal Profile { get; set; }
        public decimal MRP { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        public decimal? CouponRate { get; set; }
        public decimal? CardRate { get; set; }
    }
}