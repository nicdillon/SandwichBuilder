using System;
using System.Collections.Generic;
using System.Linq;

namespace SandwichBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredientsPriceMap = IngredientPriceMapProvider.GetIngredientPriceMap();

            List<Sandwich> sandwichList = new List<Sandwich>
            {
                new Sandwich.SandwichBuilder(ingredientsPriceMap)
                .SetType(SandwichType.HamAndCheese)
                .ApplyMeatAndCheese("Ham", "American cheese")
                .ApplyCondiments("Mayo", "Mustard")
                .ApplySeasonings("Salt and pepper")
                .Build(),

                new Sandwich.SandwichBuilder(ingredientsPriceMap)
                .SetType(SandwichType.Quesadilla)
                .PrepareBread()
                .ApplyMeatAndCheese("Chicken", "Shredded cheese")
                .ApplyVegetables("Bell peppers", "Onions", "Pico")
                .ApplyCondiments("Sour creame")
                .Build()
            };

            sandwichList.ForEach(sandwich =>
            {
                Console.WriteLine("----------");
                Console.WriteLine($"Sandwich Type: {sandwich.Type}");
                Console.WriteLine($"Ingredients: {string.Join(", ", sandwich.Ingredients.Select(IngredientType => IngredientType.Item1))}");
                Console.WriteLine($"Price: ${sandwich.GetSandwichPrice()}");
                Console.WriteLine("----------");
            });

            Console.WriteLine("Would you like an apple pie with that?");
        }
    }
}
