using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10204902_PROG6211_POE
{
    public class Ingredient
    {
        

        //Variables stored in ingredient
        private string name;
        private double quantity;
        private string unitOfMeasurement;
        private double calories;
        private string foodGroup;

        //Parameterised constructor with all variables included
        public Ingredient(string name, double quantity, string unitOfMeasurement, double calories, string foodGroup)
        {
            this.name = name;
            this.quantity = quantity;
            this.unitOfMeasurement = unitOfMeasurement;
            this.calories = calories;
            this.foodGroup = foodGroup;
        }

        //default constructor to allow empty objects to be created then populated in NewMain.cs
        public Ingredient()
        {
        }



        //Getters and Setters
        public string Name { get => name; set => name = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public string UnitOfMeasurement { get => unitOfMeasurement; set => unitOfMeasurement = value; }
        public double Calories { get => calories; set => calories = value; }
        public string FoodGroup { get => foodGroup; set => foodGroup = value; }


        //Custom method to return a formatted ingredient sentence
        public string printIngredient()
        { 
            return Quantity + " " +UnitOfMeasurement + " of " + Name + "\t\t\t| " +Calories + "\t\t\t| " + FoodGroup;
        }
    }
}
