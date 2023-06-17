using System.Collections.Generic;

namespace SandwichBuilder
{
    // Keep this seperate so we can always swap out specialty pricing menus later
    public static class IngredientPriceMapProvider
    {
        public static Dictionary<IngredientType, decimal> GetIngredientPriceMap()
        {
            Dictionary<IngredientType, decimal> ingredientPrices = new Dictionary<IngredientType, decimal>
            {
                { IngredientType.Meat, 2.00m },
                { IngredientType.Cheese, 1.00m },
                { IngredientType.Vegetable, 0.75m },
                { IngredientType.Condiment, 0.50m },
                { IngredientType.Seasoning, 0.25m }
            };

            return ingredientPrices;
        }
    }
}
