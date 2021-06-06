using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNLayerApp.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Stock { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }

        public string InnerBarcode { get; set; }

        public virtual Category Category { get; set; } //product, category'ye bagli olacagindan, category'ye referans. one to many relation
    }
}
