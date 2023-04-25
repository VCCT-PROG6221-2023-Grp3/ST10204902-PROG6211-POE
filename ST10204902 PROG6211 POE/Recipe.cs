namespace ST10204902_PROG6211_POE
{

    public class Recipe
    {
        //Variables
        private int numIngredients;
        private int numSteps;
        private Ingredient[] arrIngredients;
        private string[] arrSteps;
        private int ingredientCount=0;
        private int stepCount = 0;

        //Parameterised constructor that accepts two integers that represent the length of the ingredient array and length of the steps array
        //The constructor also sets the local variables of numIngredients and numSteps to the variables in the parameter
        public Recipe(int inNumIngredients, int inNumSteps)
        {
            arrIngredients = new Ingredient[inNumIngredients];
            arrSteps = new string[inNumSteps];
            numIngredients= inNumIngredients;
            numSteps = inNumSteps;
        }

        //default constructor to allow building during testing
        public Recipe() 
        {
        }
        //Custom adder method to streamline data input in main program

        //Adder method for arrIngredient
        //Accepts an Ingredient object, stores it in the array then increments the counter by 1

        public void addIngredientToArray(Ingredient item)
        {
            arrIngredients[ingredientCount] = item;
            this.ingredientCount=ingredientCount+1;
        }
        

        //Getter methods
        public int getNumIngredients() {  return numIngredients; }

        public int getNumSteps() { return numSteps; }

        public Ingredient[] getIngredientArr() { return arrIngredients; }
        public string[] getStepsArr() { return arrSteps; }


        //Setter methods

        public void setStepsArr(string[] steps) { arrSteps = steps; }

        public void setNumIngredients(int inNumIngredients)
        {
            arrIngredients = new Ingredient[inNumIngredients];
            numIngredients = inNumIngredients;
        }

        public void setNumSteps(int inNumSteps)
        {
            arrSteps = new string[inNumSteps];
            numSteps = inNumSteps; 
        }
        /*The user shall be able to enter the details for a single recipe:
a. The number of ingredients.
b. For each ingredient: the name, quantity, and unit of measurement. For example, one
tablespoon of sugar.
c. The number of steps.
d. For each step: a description of what the user should do*/

        //Custom toString that returns a formatted list within the recipe
        public string toString()
        {
            string temp = "";

            for (int i  = 0; i < numIngredients; i++)
            {
                temp += "\n - Ingredient "+(i+1) + ": " +  arrIngredients[i].printIngredient();
            }

            for (int i = 0;i<numSteps; i++)
            {
                temp += "\nStep " + (i+1) + ": " + arrSteps[i];
            }


            return temp;
        }
    }
}
