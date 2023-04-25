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
            Console.WriteLine("Welcome to my Recipe application");
            Console.WriteLine("Would you like to begin? (yes/no)");
            string confirmBegin = Validation.validateString(Console.ReadLine()); // validate user input
            

            while (confirmBegin.Equals("yes")) //loop until user changes confirmbegin
            {
                Recipe r = new Recipe();
                Console.WriteLine("Please enter the number of ingredients in your recipe: ");
                r.setNumIngredients(Validation.validateInt(Console.ReadLine())); //validate user input for an integer

                //loop numberIngredients times. Build an ingredient object and populate it with the values entered by the user
                //once all the Ingredient objects data has been populated, add the ingredient to the array within the Recipe object
                for (int i = 0;  i < r.getNumIngredients(); i++) 
                {
                    Ingredient ing = new Ingredient();
                    Console.WriteLine("Please enter ingredient name: ");
                    ing.setName(Validation.validateString(Console.ReadLine()));
                    Console.WriteLine("Please enter the unit of measurement: ");
                    ing.setUnitOfMeasurement(Validation.validateString(Console.ReadLine()));
                    Console.WriteLine("Please enter the quantity of the ingredient: ");
                    ing.setQuantity(Validation.validateDouble(Console.ReadLine()));
                    r.addIngredientToArray(ing);
                }

                Console.WriteLine("Please enter the number of steps in your recipe: ");
                r.setNumSteps(Validation.validateInt(Console.ReadLine()));
                string[] steps = new string[r.getNumSteps()]; //instantiate a new string array to later be added to the Recipe object

                //loop for number of steps
                //add each step entered by the user to the steps array 
                
                for (int i = 0;i < r.getNumSteps(); i++)
                {
                    Console.WriteLine("Enter Step {0}:", i);
                    steps[i] = Validation.validateString(Console.ReadLine());
                }
                //pass the steps array to the recipe object
                r.setStepsArr(steps);
                Console.WriteLine(r.toString());

                //prompt the user to continue
                Console.WriteLine("Would you like to restart? (yes/no)");
                confirmBegin = Validation.validateString(Console.ReadLine());
            }
            

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            //end of application
        }
    }
}
