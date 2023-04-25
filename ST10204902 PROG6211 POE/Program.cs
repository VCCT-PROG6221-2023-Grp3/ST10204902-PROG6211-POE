using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10204902_PROG6211_POE
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             * The user shall be able to enter the details for a single recipe:
                a. The number of ingredients.
                b. For each ingredient: the name, quantity, and unit of measurement. For example, one
                tablespoon of sugar.
                c. The number of steps.
                d. For each step: a description of what the user should do           
             */

            //start of application
            int steps = 3;
            int ingredients = 3;
            Recipe r = new Recipe(3, 3);
            string[] arrSteps = { "Wash vegetables", "Cook food", "Eat food" };

            for (int i = 0; i < ingredients; i++)
            {
                Ingredient ing = new Ingredient();
                Console.WriteLine("Enter ingredient name:");
                ing.setName(Console.ReadLine());
                Console.WriteLine("Enter the quanity for this item: ");
                ing.setQuantity(Double.Parse(Console.ReadLine()));
                Console.WriteLine("Enter the unit of measurement for this item: ");
                ing.setUnitOfMeasurement(Console.ReadLine());
                r.addIngredientToArray(ing);
            }
            
            Console.WriteLine(r.toString());

            

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            //end of application
        }
    }
}
