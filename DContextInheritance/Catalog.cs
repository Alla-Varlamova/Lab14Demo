using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DContextInheritance
{
    public class Catalog
    {
        public string CatalogName => "Электроника";
        public ObservableCollection<Product> Products { get; } = new ObservableCollection<Product>()
            {
                new Product { Name = "Смартфон", Price = 500 },
                new Product { Name = "Планшет", Price = 800 }
            };
    }
}
