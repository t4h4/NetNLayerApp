using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNLayerApp.Core.Models
{
    class Category
    {
        public Category() //category olusturuldugunda bos bir product collection nesnesi
        {
            Products = new Collection<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; } //veritabanindan silmek yerine silinme durumunu veritabaninda tutulacak

        public ICollection<Product> Products { get; set; } //her kategori birden fazla urune sahip olabilir. one to many relation

    }
}
