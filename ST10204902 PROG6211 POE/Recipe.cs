using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10204902_PROG6211_POE
{
    internal class Recipe
    {
        //Variable declaration
        String name;
        List<Ingredient> ingredients;
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

        public void multiplyRecipe(int option) //Scaling needs to be done in program.cs before committing to this method.
        {
            switch(option)
            {
                //ASK ABOUT THIS
                case 2:
                    foreach (Ingredient ingredient in ingredients)
                    {
                        Ingredient temp = ingredient;
                        temp.Quantity = temp.Quantity * 0.5;
                        temp.Calories = temp.Calories * 0.5;
                        ingredients.Remove(ingredient);
                        ingredients.Add(temp);
                    }
                    break;
                case 3:
                    foreach (Ingredient ingredient in ingredients)
                    {
                        Ingredient temp = ingredient;
                        temp.Quantity = temp.Quantity * 2;
                        temp.Calories = temp.Calories * 2;
                        ingredients.Remove(ingredient);
                        ingredients.Add(temp);
                    }
                    break;
                    case 4:
                    foreach (Ingredient ingredient in ingredients)
                    {
                        Ingredient temp = ingredient;
                        temp.Quantity = temp.Quantity * 3;
                        temp.Calories = temp.Calories * 3;
                        ingredients.Remove(ingredient);
                        ingredients.Add(temp);
                    }
                    break;
            }
        }

        public double calculateTotalCalories()
        { 
            double total = 0;
            foreach (Ingredient ingredient in ingredients)
            {
                total += ingredient.Calories;
            }
            return total;
        }

        public string toString()
        {
            string temp = "\t\tRecipe: " +name;
            temp += "\n___________________________________";
            temp += "\nIngredients \t\t\t\t| Calories \t\t\t| Food Group";
            foreach (Ingredient ingredient in ingredients)
            {
                temp += " - " + ingredient.printIngredient();
            }
            temp += "\n___________________________________";
            temp += "\nSteps:";
            int i = 0;
            foreach(string step in Steps)
            {
                i++;
                temp += "\nStep " + i + ": " + step;
            }
            return temp;
        }
    }
}
