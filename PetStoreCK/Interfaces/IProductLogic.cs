using System;

namespace PetStore
{
    public interface IProductLogic
    {
        public void AddProduct(Product product);

        public DogLeash GetDogLeashByName(string name);

        public decimal GetTotalPriceOfInventory();
    }
}
