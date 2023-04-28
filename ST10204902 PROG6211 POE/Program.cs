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

            //Start of application

            Recipe r = new Recipe();
            Console.WriteLine("Welcome to my Recipe application");
            Console.WriteLine("Would you like to begin? (yes/no)");

            // Validate user input is not null
            string confirmBegin = Validation.validateString(Console.ReadLine()); 
            
            // Validate user input is either yes or no. Reprompt user until valid entry
            confirmBegin = Validation.returnYesNo(confirmBegin);

            //Loop until user changes confirmbegin
            while (confirmBegin.Equals("yes")) 
            {
                Console.Clear();
                Console.WriteLine("Please enter the number of ingredients in your recipe: ");
                r.setNumIngredients(Validation.validateInt(Console.ReadLine())); //Validate user input for an integer

                //Loop numberIngredients times. Build an ingredient object and populate it with the values entered by the user
                //Once all the Ingredient objects data has been populated, add the ingredient to the array within the Recipe object
                for (int i = 0;  i < r.getNumIngredients(); i++) 
                {
                    //Initialise new ingredient object to insert later into the recipe object
                    Ingredient ing = new Ingredient();

                    //Clear console to declutter
                    Console.Clear();

                    //Prompt the user to enter the ingredient name and validate the string entry
                    Console.WriteLine("\nPlease enter ingredient name: ");
                    ing.setName(Validation.validateString(Console.ReadLine()));

                    //Clear console to declutter
                    Console.Clear();

                    //Prompt the user to enter the unit of measurement and validate the string entry
                    Console.WriteLine("\nPlease enter the unit of measurement: ");
                    ing.setUnitOfMeasurement(Validation.validateString(Console.ReadLine()));

                    //Clear console to declutter
                    Console.Clear();

                    //Prompt the user to enter a quantity and validate the string as a double
                    Console.WriteLine("\nPlease enter the quantity of the ingredient: ");
                    ing.setQuantity(Validation.validateDouble(Console.ReadLine()));

                    //Clear console to declutter
                    Console.Clear();

                    //Add the ingredient object to the ingredient array
                    r.addIngredientToArray(ing);
                }
                //Prompt the user to enter steps in the recipe
                Console.WriteLine("\nPlease enter the number of steps in your recipe: ");
                r.setNumSteps(Validation.validateInt(Console.ReadLine()));

                //Clear console to declutter
                Console.Clear();

                //Instantiate a new string array to later be added to the Recipe object
                string[] steps = new string[r.getNumSteps()]; 

                //Loop for number of steps
                //Add each step entered by the user to the steps array 
                
                for (int i = 0;i < r.getNumSteps(); i++)
                {
                    Console.WriteLine("\nEnter Step {0}:", (i+1));
                    steps[i] = Validation.validateString(Console.ReadLine());
                }
               
                //Pass the steps array to the recipe object
                r.setStepsArr(steps);

                //Print the full recipe
                Console.WriteLine("\n" + r.toString());

                //Change confirmBegin to no to exit the while loop
                confirmBegin = "no";
            }

            //Clear console to declutter
            Console.Clear();

            //Print the recipe so the user can see what has been input before following prompt
            Console.WriteLine(r.toString());

            //Prompt the user to halve, double or triple the recipe measurements
            Console.WriteLine("\nWould you like to halve, double or triple the recipe?");
            Console.WriteLine("Select from the following menu options (1-4)");
            Console.WriteLine("1) Do nothing");
            Console.WriteLine("2) Halve the recipe");
            Console.WriteLine("3) Double the recipe");
            Console.WriteLine("4) Triple the recipe");
            Console.Write("\nEnter your option selection: ");

            int option = Validation.validateOption(Console.ReadLine());
            
            //Duplicate the original recipe to a new object
            Recipe r2 = r;

            //Multiply the recipe values
            r.multiplyRecipe(option);
            Console.WriteLine(r.toString());

            //Prompt the user to revert changes and validate entry
            Console.WriteLine("\nWould you like to return to the original recipe values? (yes/no)");
            string confirmClear = Validation.validateString(Console.ReadLine());
            confirmClear = Validation.returnYesNo(confirmClear);

            //Prompt the user to clear the recipe
            Console.WriteLine("\nWould you like to clear the recipe? (yes/no)");
            confirmClear = Validation.validateString(Console.ReadLine());
            confirmClear = Validation.returnYesNo(confirmClear);

            if (confirmClear.Equals("yes"))
            {
                r.clear();
                r2.clear();
            }

            //Print the recipe
            Console.WriteLine(r.toString());


            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            //end of application
        }
    }
}
