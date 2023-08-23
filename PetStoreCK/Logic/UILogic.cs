using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace PetStore
{
    /// <summary>
    /// Creates the user interface and uses input for method calls
    /// </summary>
    public static class UserActions
    {
        private static string GetAction()
        {
            Console.WriteLine("Press 1 to add a dog leash.");
            Console.WriteLine("Press 2 to search for a dog leash by name.");
            Console.WriteLine("Press 3 to see the list of products in stock.");
            Console.WriteLine("Press 4 to see the total price of all items in stock.");
            Console.WriteLine("Type 'exit' to quit");
            return Console.ReadLine();
        }

        public static void GetMenu()
        {
            var productLogic = new ProductLogic();
            string? userInput = GetAction();
            while (userInput.ToLower() != "exit")
            {

                if (userInput == "1")
                {
                    DogLeash newProduct = new DogLeash();
                    Console.WriteLine("What is the product name?");
                    newProduct.Name = Console.ReadLine();
                    Console.WriteLine("What is the product price?");
                    newProduct.Price = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("How many are in stock?");
                    newProduct.Quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please describe the product:");
                    newProduct.Description = Console.ReadLine();
                    Console.WriteLine("How long is the leash in inches?");
                    newProduct.LengthInches = int.Parse(Console.ReadLine());
                    Console.WriteLine("Of what material is the leash made?");
                    newProduct.Material = Console.ReadLine();
                    productLogic.AddProduct(newProduct);
                    Console.WriteLine($"{newProduct.Name} was added.");
                }

                if (userInput == "2")
                {
                    Console.WriteLine("What is the product name?");
                    string leashName = Console.ReadLine();

                    if (productLogic.GetDogLeashByName(leashName) != null)
                    {
                        Console.WriteLine(JsonSerializer.Serialize(productLogic.GetDogLeashByName(leashName)));
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                }
                if (userInput == "3")
                {
                    List<string> stock = productLogic.GetOnlyInStockProducts();
                    foreach (string item in stock)
                    {
                        Console.WriteLine(item);
                    }
                }
                if (userInput == "4")
                {
                    Console.WriteLine($"${productLogic.GetTotalPriceOfInventory()}");
                }

                userInput = GetAction();
            }
        }
    }
}
