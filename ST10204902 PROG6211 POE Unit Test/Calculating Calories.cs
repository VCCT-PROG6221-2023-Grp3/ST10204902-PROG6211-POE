using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ST10204902_PROG6211_POE;
using System.Collections.Generic;

namespace ST10204902_PROG6211_POE_Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        Recipe r = new Recipe();
        Ingredient i1 = new Ingredient("Bread", 8, "slices", 400, "grains");
        Ingredient i2 = new Ingredient("Butter", 50, "ml", 200, "oils");
        List<Ingredient> ingredients = new List<Ingredient>();
        
        [TestMethod]
        public void TestCalculateCalories()
        {
            ingredients.Add(i1);
            ingredients.Add(i2);
            r.Ingredients = ingredients;
            var result = r.calculateTotalCalories();
            var expected = 600;
            Assert.AreEqual(expected, result);
        }


    }
}
