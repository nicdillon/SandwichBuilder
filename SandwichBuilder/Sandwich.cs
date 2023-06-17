using System;
using System.Collections.Generic;
using System.Linq;

namespace SandwichBuilder
{   
    // Further validation of ingredients and process can be added that correlate to sandwich type
    // Or we can create recipes based on each type, for example, BLT always gets bacon, lettuce and tomoto, but nothing else
    public enum SandwichType
    {
        HamAndCheese,
        Turkey,
        BLT,
        Veggie,
        GrilledCheese,
        Hamburger, // Definitely a sandwich
        Quesadilla // This one is up for debate
    }

    public enum IngredientType
    {
        Meat,
        Cheese,
        Seasoning,
        Vegetable,
        Condiment
    }

    public class Sandwich
    {
        public List<(string, IngredientType)> Ingredients { get; private set; }
        public SandwichType Type { get; private set; }
        private decimal Price { get; set; }
        private bool IsCompleted { get; set; }

        private Sandwich()
        {
            Ingredients = new List<(string, IngredientType)>();
        }

        public string GetSandwichPrice()
        {
            return "$" + Price.ToString("0.00");
        }

        public class SandwichBuilder
        {
            private Sandwich _sandwich;
            private Dictionary<IngredientType, decimal> _ingredientPriceMap;

            public SandwichBuilder(Dictionary<IngredientType, decimal> ingredientPriceMap)
            {
                _sandwich = new Sandwich();
                _ingredientPriceMap = ingredientPriceMap;
            }

            public SandwichBuilder SetType(SandwichType type)
            {
                _sandwich.Type = type;
                return this;
            }

            // Only needed for warm sandwiches, such as grilled cheese and quesadillas 
            public SandwichBuilder PrepareBread()
            {
                if (_sandwich.IsCompleted)
                {
                    return this;
                }

                Console.WriteLine("Preparing the bread...");

                _sandwich.Price += 1.00m;

                return this;
            }

            public SandwichBuilder ApplyMeatAndCheese(string meat, string cheese)
            {
                if (_sandwich.IsCompleted)
                {
                    return this;
                }

                Console.WriteLine("Applying the meat and cheese...");

                _sandwich.Price += _ingredientPriceMap[IngredientType.Meat] + _ingredientPriceMap[IngredientType.Cheese];

                List<(string, IngredientType)> meatAndCheese = new List<(string, IngredientType)>()
                {
                    (meat, IngredientType.Meat),
                    (cheese, IngredientType.Cheese)
                };

                _sandwich.Ingredients.AddRange(meatAndCheese);

                return this;
            }

            public SandwichBuilder ApplyVegetables(params string[] veggiesToAdd)
            {
                if (_sandwich.IsCompleted)
                {
                    return this;
                }

                var veggies = veggiesToAdd.ToList();

                Console.WriteLine("Applying the other ingredients...");

                _sandwich.Price += _ingredientPriceMap[IngredientType.Vegetable] * veggies.Count;

                List<(string, IngredientType)> veggieList = veggies.Select(vegetable => (vegetable, IngredientType.Vegetable)).ToList();

                _sandwich.Ingredients.AddRange(veggieList);

                return this;
            }

            public SandwichBuilder ApplyCondiments(params string[] condimentsToAdd)
            {
                if (_sandwich.IsCompleted)
                {
                    return this;
                }

                var condiments = condimentsToAdd.ToList();

                Console.WriteLine("Adding condiments...");

                _sandwich.Price += _ingredientPriceMap[IngredientType.Condiment] * condiments.Count;

                List<(string, IngredientType)> condimentsList = condiments.Select(condiment => (condiment, IngredientType.Condiment)).ToList();

                _sandwich.Ingredients.AddRange(condimentsList);

                return this;
            }

            public SandwichBuilder ApplySeasonings(params string[] seasoningsToAdd)
            {
                if(_sandwich.IsCompleted)
                {
                    return this;
                }

                var seasonings = seasoningsToAdd.ToList();

                Console.WriteLine("Adding seasonings...");

                _sandwich.Price += _ingredientPriceMap[IngredientType.Seasoning] * seasonings.Count;

                List<(string, IngredientType)> seasoningsList = seasonings.Select(seasoning => (seasoning, IngredientType.Seasoning)).ToList();

                _sandwich.Ingredients.AddRange(seasoningsList);

                return this;
            }

            public Sandwich Build()
            {
                // No substitutions!
                _sandwich.IsCompleted = true;
                return _sandwich;
            }
        }
    }
}