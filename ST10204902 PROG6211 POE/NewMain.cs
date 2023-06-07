using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ST10204902_PROG6211_POE
{
    
    internal class NewMain
    {
        public delegate void delCalorieWarning(Recipe r);
        static List <Recipe> Recipes = new List<Recipe>();
        //Start of application
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the Recipe Applicaton");
            Console.WriteLine("Would you like to begin? (yes/no)");

            //Validate user input is not null
            string confirmBegin = Validation.validateString(Console.ReadLine());

            //Validate user input is either yes or no. Reprompt until valid entry
            confirmBegin = Validation.returnYesNo(confirmBegin);

            bool showMenu = true;

            while (showMenu && confirmBegin.Equals("yes"))
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) View List of all Recipes");
            Console.WriteLine("2) Add a new Recipe");
            Console.WriteLine("3) Exit");

            switch (Validation.validateInt(Validation.validateString(Console.ReadLine())))
            {
                case 1:
                    ViewRecipeMenu();
                    return true;
                case 2:
                    AddRecipe();
                    MainMenu();
                    return true;
                case 3:
                    Environment.Exit(0);
                    return false;
                default: 
                    return true;
            }
        }

        private static void ViewRecipeMenu()
        {
            SortRecipes();
            Console.Clear() ;
            Console.WriteLine("List of all recipes");
            int count = 0;
            if(Recipes.Count ==0)
            {
                Console.WriteLine("There are no recipes added yet");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                MainMenu();
            }
            foreach (Recipe recipe in Recipes)
            {
                count++;
                Console.WriteLine(count + ") " + recipe.Name);
            }

            Console.WriteLine("Select a recipe number to view or enter 0 to exit");
            int recipeSelectedNum = Validation.validateInt(Console.ReadLine());

            while(recipeSelectedNum < 0 && recipeSelectedNum>Recipes.Count) 
            { 
                Console.WriteLine($"There is no recipe {recipeSelectedNum}, please try selecting a new number");
                recipeSelectedNum = Validation.validateInt(Console.ReadLine());
            }

            if(recipeSelectedNum == 0) 
            { 
                MainMenu();
            }
            else
            {
                Recipe r = Recipes.ElementAt<Recipe>(recipeSelectedNum - 1);
                ViewRecipe(r, recipeSelectedNum);
            }
        }

        private static void ViewRecipe(Recipe recipe, int recipeSelectedNum)
        {
            Console.Clear();
            delCalorieWarning cl = new delCalorieWarning(CalorieWarning);
            
            Console.WriteLine("Recipe "+recipeSelectedNum +":");
            Console.WriteLine(recipe.toString());

            Console.WriteLine("\nSelect an option from the menu:");
            Console.WriteLine("1) Scale the recipe");
            Console.WriteLine("2) Calculate the total calories");
            Console.WriteLine("3) Clear recipe");
            Console.WriteLine("4) Return to previous menu");

            switch (Validation.validateInt(Validation.validateString(Console.ReadLine())))
            {
                case 1:
                    ScalePrompt(recipe, recipeSelectedNum);
                    
                    break;
                case 2:
                    Console.WriteLine("Total calories for the recipe = " + recipe.calculateTotalCalories() + " calories");
                    cl(recipe);
                    Console.WriteLine("Press any key to return to the previous menu...");
                    Console.ReadKey();
                    ViewRecipe(recipe, recipeSelectedNum);
                    break;
                case 3:
                    RemoveRecipe(recipe);
                    ViewRecipeMenu();
                    break;
                case 4:
                    MainMenu();
                    break;
                default:
                    ViewRecipe(recipe, recipeSelectedNum);
                    break;
            }
        }

        private static void ScalePrompt(Recipe r, int recipeSelectedNum)
        {
            Console.Clear();
            Console.WriteLine("Select from the following menu options (1-4)");
            Console.WriteLine("1) Do nothing");
            Console.WriteLine("2) Halve the recipe");
            Console.WriteLine("3) Double the recipe");
            Console.WriteLine("4) Triple the recipe");
            Console.Write("\nEnter your option selection: ");

            int option = Validation.validateOption(Console.ReadLine());

            //Duplicate the original recipe to a new object
            Recipe recipeNewQuantity = new Recipe();
            Recipe recipeOriginalQuantity = new Recipe();
            recipeNewQuantity = r;
            recipeOriginalQuantity = r;


            Console.Clear() ;

            Console.WriteLine(recipeNewQuantity.toString());

            //Multiply the recipe values
            recipeNewQuantity.multiplyRecipe(option);
            Console.WriteLine(recipeNewQuantity.toString());

            //Prompt the user to revert changes and validate entry
            Console.WriteLine("\nWould you like to return to the original recipe values? (yes/no)");
            string confirmClear = Validation.validateString(Console.ReadLine());
            confirmClear = Validation.returnYesNo(confirmClear);

            if(confirmClear.Equals("yes"))
            {
                Console.WriteLine("Waiting here");
                Console.WriteLine(recipeOriginalQuantity.ToString());
                Console.WriteLine(recipeNewQuantity.ToString());
                Console.ReadLine();
                ViewRecipe(recipeOriginalQuantity , recipeSelectedNum);
            }
            else
            {
                Recipes.Remove(r);
                Recipes.Add(recipeNewQuantity);

                Console.WriteLine("Waitinng there");
                Console.WriteLine(recipeNewQuantity.toString() );
                Console.ReadLine() ;
                ViewRecipe(recipeNewQuantity, recipeSelectedNum);
            }

        }
        private static void SortRecipes()
        {
            Recipes.Sort(delegate (Recipe x, Recipe y) { return x.Name.CompareTo(y.Name); });
        }

        private static void RemoveRecipe(Recipe recipe)
        { Recipes.Remove(recipe); }
        private static void AddRecipe()
        {
            Console.Clear();
            Recipe recipe = new Recipe();

            Console.WriteLine("Please enter the name of the recipe");
            recipe.Name = Validation.validateString(Console.ReadLine());

            Console.Clear() ;

            Console.WriteLine("Please enter the number of ingredients in your recipe: ");
            int numberOfIngredients = Validation.validateInt(Console.ReadLine()); //Validate user input for an integer
            List<Ingredient> tempIngredients = new List<Ingredient>();
            //Loop numberIngredients times. Build an ingredient object and populate it with the values entered by the user
            //Once all the Ingredient objects data has been populated, add the ingredient to the array within the Recipe object
            for (int i = 0; i < numberOfIngredients; i++)
            {
                //Initialise new ingredient object to insert later into the recipe List
                Ingredient ing = new Ingredient();

                //Clear console to declutter
                Console.Clear();

                //Prompt the user to enter the ingredient name and validate the string entry
                Console.WriteLine($"Please enter ingredient {i+1}'s name: ");
                ing.Name = Validation.validateString(Console.ReadLine());
                
                //Clear console to declutter
                Console.Clear();

                //Prompt the user to enter the unit of measurement and validate the string entry
                Console.WriteLine($"Please enter the unit of measurement for ingredient {i+1}: ");
                ing.UnitOfMeasurement = Validation.validateString(Console.ReadLine());

                //Clear console to declutter
                Console.Clear();

                //Prompt the user to enter a quantity and validate the string as a double
                Console.WriteLine($"Please enter the quantity of ingredient {i+1}: ");
                ing.Quantity = Validation.validateDouble(Console.ReadLine());

                //Clear console to declutter
                Console.Clear();

                //Prompt the user to enter the food group and validate the string entry
                Console.WriteLine($"Please enter the food group of the ingredient {i + 1}: ");
                Console.WriteLine("Example: Starch, Vegetable, Animal Products");
                ing.FoodGroup = Validation.validateString(Console.ReadLine());

                //Clear console to declutter
                Console.Clear();

                //Prompt the user to enter a double and validate the double
                Console.WriteLine($"Please enter the calorie count of the ingredient {i+1}: ");
                ing.Calories = Validation.validateDouble(Validation.validateString(Console.ReadLine()));

                

                //Add the ingredient object to the ingredient list
                tempIngredients.Add( ing );    
            }
            recipe.Ingredients = tempIngredients;

            //Clear console to declutter
            Console.Clear();

            //Prompt the user to enter steps in the recipe
            Console.WriteLine("Please enter the number of steps in your recipe: ");
            int stepNum = Validation.validateInt(Console.ReadLine());


            //Instantiate a new string array to later be added to the Recipe object
            List<string> steps = new List<string>();

            //Loop for number of steps
            //Add each step entered by the user to the steps array 

            for (int i = 0; i < stepNum; i++)
            {
                //Clear console to declutter
                Console.Clear();

                Console.WriteLine("Enter Step {0}:", (i + 1));
                steps.Add(Validation.validateString(Console.ReadLine()));
            }

            //Pass the steps list to the recipe object
            recipe.Steps = steps;

            Recipes.Add(recipe);

            Console.Clear();
        }

        public static void CalorieWarning(Recipe r)
        {
            if(r.calculateTotalCalories()>300)
            {
                Console.WriteLine("Warning: This recipe has over 300 calories");
            }
        }
    }
}
