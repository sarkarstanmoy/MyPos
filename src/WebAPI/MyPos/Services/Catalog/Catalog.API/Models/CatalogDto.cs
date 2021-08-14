using System.Collections.Generic;

namespace Catalog.API.Models
{
    public class CatalogDto
    {
        public string CatalogType { get; set; }
        public List<Item> Items { get; set; }
    }
}