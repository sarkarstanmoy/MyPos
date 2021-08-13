﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class CatalogDto
    {
        public string CatalogType { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}