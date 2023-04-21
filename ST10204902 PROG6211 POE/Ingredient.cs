using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10204902_PROG6211_POE
{
    public class Ingredient
    {
        /*The user shall be able to enter the details for a single recipe:
        a. The number of ingredients.
        b. For each ingredient: the name, quantity, and unit of measurement. For example, one
        tablespoon of sugar.
        c. The number of steps.
        d. For each step: a description of what the user should do*/

        //Variables stored in ingredient
        private string name;
        private double quantity;
        private string unitOfMeasurement;

        //Accessor methods
        public string getName()  {return name;}
        public double getQuantity() { return quantity; }
        public string getUnitOfMeasurement() {  return unitOfMeasurement;}

        //Mutator methods
        public void setName(string name) { this.name = name;}
        public void setQuantity(double quantity) {  this.quantity = quantity;}
        public void setUnitOfMeasurement(string unitOfMeasurement) { this.unitOfMeasurement = unitOfMeasurement;}

        //Custom method to return a formatted ingredient sentence
        public string printIngredient()
        { 
            return this.quantity + " " +this.unitOfMeasurement + " of " + this.name;
        }
    }
}
