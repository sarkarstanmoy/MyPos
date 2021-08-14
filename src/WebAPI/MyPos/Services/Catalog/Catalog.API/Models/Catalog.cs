using System.Collections.Generic;

namespace Catalog.API.Models
{
    public class Catalog
    {
        public int CatalogId { get; set; }
        public string CatalogType { get; set; }
        public List<Item> Items { get; set; }
    }
}