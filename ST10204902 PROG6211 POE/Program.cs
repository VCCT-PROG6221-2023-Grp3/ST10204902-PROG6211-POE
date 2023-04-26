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

            //I have successfully transferred to github

            //start of application

            Recipe r = new Recipe();
            Console.WriteLine("Welcome to my Recipe application");
            Console.WriteLine("Would you like to begin? (yes/no)");
            string confirmBegin = Validation.validateString(Console.ReadLine()); // validate user input

            confirmBegin = Validation.returnYesNo(confirmBegin);

            while (confirmBegin.Equals("yes")) //loop until user changes confirmbegin
            {
                
                Console.WriteLine("Please enter the number of ingredients in your recipe: ");
                r.setNumIngredients(Validation.validateInt(Console.ReadLine())); //validate user input for an integer

                //loop numberIngredients times. Build an ingredient object and populate it with the values entered by the user
                //once all the Ingredient objects data has been populated, add the ingredient to the array within the Recipe object
                for (int i = 0;  i < r.getNumIngredients(); i++) 
                {
                    Ingredient ing = new Ingredient();
                    Console.WriteLine("\nPlease enter ingredient name: ");
                    ing.setName(Validation.validateString(Console.ReadLine()));
                    Console.WriteLine("\nPlease enter the unit of measurement: ");
                    ing.setUnitOfMeasurement(Validation.validateString(Console.ReadLine()));
                    Console.WriteLine("\nPlease enter the quantity of the ingredient: ");
                    ing.setQuantity(Validation.validateDouble(Console.ReadLine()));
                    r.addIngredientToArray(ing);
                }

                Console.WriteLine("\nPlease enter the number of steps in your recipe: ");
                r.setNumSteps(Validation.validateInt(Console.ReadLine()));
                string[] steps = new string[r.getNumSteps()]; //instantiate a new string array to later be added to the Recipe object

                //loop for number of steps
                //add each step entered by the user to the steps array 
                
                for (int i = 0;i < r.getNumSteps(); i++)
                {
                    Console.WriteLine("\nEnter Step {0}:", (i+1));
                    steps[i] = Validation.validateString(Console.ReadLine());
                }
                //pass the steps array to the recipe object
                r.setStepsArr(steps);

                //print the full recipe
                Console.WriteLine("\n" + r.toString());
                confirmBegin = "no";
            }

            //prompt the user to halve, double or triple the recipe measurements
            Console.WriteLine("\nWould you like to halve, double or triple the recipe?");
            Console.WriteLine("Select from the following menu options (1-4)");
            Console.WriteLine("1) Do nothing");
            Console.WriteLine("2) Halve the recipe");
            Console.WriteLine("3) Double the recipe");
            Console.WriteLine("4) Triple the recipe");
            Console.Write("\nEnter your option selection: ");
            int option = Validation.validateOption(Console.ReadLine());
            
            //duplicate the original recipe to a new object
            Recipe r2 = r;

            //multiply the recipe values
            r.multiplyRecipe(option);
            Console.WriteLine(r.toString());

            Console.WriteLine("\nWould you like to return to the original recipe values? (yes/no)");
            string confirmClear = Validation.validateString(Console.ReadLine());
            confirmClear = Validation.returnYesNo(confirmClear);

            //prompt the user to clear the recipe
            Console.WriteLine("\nWould you like to clear the recipe? (yes/no)");
            confirmClear = Validation.validateString(Console.ReadLine());
            confirmClear = Validation.returnYesNo(confirmClear);
            if (confirmClear.Equals("yes"))
            {
                r.clear();
                r2.clear();
            }
            Console.WriteLine(r.toString());
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            //end of application
        }
    }
}
