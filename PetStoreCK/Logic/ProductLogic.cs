namespace PetStore
{
    /// <summary>
    /// Provides the logic for working with products
    /// </summary>
    public class ProductLogic : IProductLogic, IList
    {
        public List<Product> _products;
        public ProductLogic()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    Name = "Dog Bowl",
                    Price = 14.99M,
                    Quantity = 12,
                    Description = "lorem"
                },
                new DogLeash()
                {
                    Name = "UnLeashed",
                    Price = 45.95M,
                    Quantity = 0,
                    Description = "It feels like no leash is even there!",
                    LengthInches = 144,
                    Material = "Nylon"
                },
                new CatFood()
                {
                    Name = "Old Milk",
                    Price = 1.79M,
                    Quantity = 144,
                    Description = "Curdled goodness for your feline companion.",
                    KittenFood = true
                },
                new Product()
                {
                    Name = "Chew Toy",
                    Price = 7.99M,
                    Quantity = 8,
                    Description = "lorem"
                }
            };
    }
        
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public DogLeash GetDogLeashByName(string? name)
        {
            try
            {
                return _products.OfType<DogLeash>().FirstOrDefault(leash => leash.Name == name);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public List<string> GetOnlyInStockProducts()
        {
            return ListExtensions.InStock<Product>(_products);
        }

        public decimal GetTotalPriceOfInventory()
        {
            decimal total = 0m;
            var inStock = GetOnlyInStockProducts();
            foreach (var product in inStock)
            {
                total = _products.Select(p => p.Price*p.Quantity).Sum();

            }
            return total;
        }
    }
}
