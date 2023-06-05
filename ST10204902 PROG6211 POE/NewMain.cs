using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10204902_PROG6211_POE
{
    internal class NewMain
    {
        List <Recipe> Recipes = new List<Recipe>();
        //Start of application
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the Recipe Applicaton");
            Console.WriteLine("Would you like to begin?");

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


            
        }

        private void ViewRecipes()
        {
            sortRecipes();
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
                ViewRecipeMenu(r, recipeSelectedNum);
            }
        }

        private void ViewRecipeMenu(Recipe recipe, int recipeSelectedNum)
        {
            Console.WriteLine("Recipe "+recipeSelectedNum +":");
            Console.WriteLine(recipe.toString());
        }

        private void sortRecipes()
        {
            Recipes.Sort(delegate (Recipe x, Recipe y) { return x.Name.CompareTo(y.Name); });
        }
    }
}
