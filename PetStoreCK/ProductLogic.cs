namespace PetStore
{
    public class ProductLogic : IProductLogic
    {
        public List<Product> _products;
        public Dictionary<string, DogLeash> _dogLeash;
        public Dictionary<string, CatFood> _catFood;
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
                }
            };
            _dogLeash = new Dictionary<string, DogLeash>();
            _catFood = new Dictionary<string, CatFood>();
        }
        public void AddProduct(Product product)
        {
            if (product is DogLeash)
            {
                _dogLeash.Add(product.Name, product as DogLeash);

            }
            if (product is CatFood)
            {
                _catFood.Add(product.Name, product as CatFood);
            }
            _products.Add(product);
        }
        public DogLeash GetDogLeashByName(string name)
        {
            try
            {
                return _dogLeash[name];
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
            var total = 0m;
            var inStock = GetOnlyInStockProducts();
            foreach (var product in inStock)
            {
                total = _products.Select(p => p.Price*p.Quantity).Sum();

            }
            return total;
        }
    }
}
