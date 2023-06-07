using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10204902_PROG6211_POE
{
    public delegate void delCalorieWarning(Recipe r);
    public class Recipe
    {
        //Variable declaration
        String name;
        List<Ingredient> ingredients;
        List<Ingredient> originalIngredients;
        List<String> steps;

        //Getters and Setters
        public string Name { get => name; set => name = value; }
        public List<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }
        public List<string> Steps { get => steps; set => steps = value; }

        //parameterised constructor that accepts a name for the recipe, a List of ingredients that is generated in the main class then passed,
        //and a List of steps that is generated in the main class
        public Recipe(string name, List<Ingredient> ingredients, List<string> steps)
        {
            this.name = name;
            this.ingredients = ingredients;
            this.steps = steps;
        }

        //default constructor
        public Recipe()
        {
        }

        //Scales the quantity and calories of this recipe by a factor
        public void multiplyRecipes(double factor)
        {
            originalIngredients = ingredients;
            foreach(Ingredient ingredient in ingredients.ToList())
            {
                ingredient.Quantity *= factor;
                ingredient.Calories *= factor;
            }
        }

        //Returns the value of ingredients' quantity and calories to their values prior to scaling
        public void resetRecipes()
        {
            ingredients = originalIngredients;
        }

        public static void CalorieWarning(Recipe r)
        {
            if (r.calculateTotalCalories() > 300)
            {
                Console.WriteLine("Warning: This recipe has over 300 calories");
            }
        }

        //Calculates the total calories of a recipe by grabbing
        public double calculateTotalCalories()
        {
            delCalorieWarning cl = new delCalorieWarning(CalorieWarning);
            double total = 0;
            foreach (Ingredient ingredient in ingredients)
            {
                total += ingredient.Calories;
            }
            cl(this);
            return total;
        }
        
        //Original toString that prints a formatted list of the variables in Recipe.
        //Variables included: Name, Ingredients and their respective printouts, steps and their respective printouts
        public string  toString()
        {
            string temp = "Recipe: " +name;
            temp += "\n______________________________________________________________________________________________________________________________";
            temp += "\nIngredients \t\t\t\t| Calories \t\t| Food Group";
            foreach (Ingredient ingredient in ingredients)
            {
                temp += "\n - " + ingredient.printIngredient();
            }
            temp += "\n______________________________________________________________________________________________________________________________";
            temp += "\nSteps:";
            int i = 0;
            foreach(string step in Steps)
            {
                i++;
                temp += "\nStep " + i + ": " + step;
            }
            return temp;
        }

        //modified version of toString to fix a bug with scaling
        //Same functionality as original toString but uses the parameters values for return instead of this Recipe 
        public string ToString(Recipe recipe)
        {
            string temp = "Recipe: " + recipe.name;
            temp += "\n______________________________________________________________________________________________________________________________";
            temp += "\nIngredients \t\t\t\t| Calories \t\t| Food Group";
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                temp += "\n - " + ingredient.printIngredient();
            }
            temp += "\n______________________________________________________________________________________________________________________________";
            temp += "\nSteps:";
            int i = 0;
            foreach (string step in recipe.Steps)
            {
                i++;
                temp += "\nStep " + i + ": " + step;
            }
            return temp;
        }
    }
}
