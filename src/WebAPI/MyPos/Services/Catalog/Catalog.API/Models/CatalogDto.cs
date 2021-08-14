using System.Collections.Generic;

namespace Catalog.API.Models
{
    public class CatalogDto
    {
        public string CatalogType { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}