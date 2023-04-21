namespace ST10204902_PROG6211_POE
{

    public class Recipe
    {
        //Variables
        private int numIngredients;
        private int numSteps;
        private Ingredient[] arrIngredients;
        private string[] arrSteps;

        //Incomplete constructor
        public Recipe(int inNumIngredients, int inNumSteps)
        {
            arrIngredients = new Ingredient[inNumIngredients];
            arrSteps = new string[inNumSteps];
        }
        /*The user shall be able to enter the details for a single recipe:
a. The number of ingredients.
b. For each ingredient: the name, quantity, and unit of measurement. For example, one
tablespoon of sugar.
c. The number of steps.
d. For each step: a description of what the user should do*/



    }
}
