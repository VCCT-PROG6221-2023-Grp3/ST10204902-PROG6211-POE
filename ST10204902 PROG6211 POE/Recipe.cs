using System.Windows.Markup;

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
        
        //Resets the values of the Recipe object
        public void clear()
        {
            arrIngredients = null;
            arrSteps = null;
            numIngredients=0;
            numSteps=0;
            ingredientCount=0;
            stepCount=0;
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


        public void multiplyRecipe(int option)
        { 
            switch (option)
            {
                //Halve the quantity of ingredients
                case 2:
                    for (int i = 0; i<numIngredients;i++)
                    {
                        arrIngredients[i].setQuantity(arrIngredients[i].getQuantity()*0.5);
                    }
                    break;
                //Double the quantity of ingredients
                case 3:
                    for (int i = 0; i < numIngredients; i++)
                    {
                        arrIngredients[i].setQuantity(arrIngredients[i].getQuantity() * 2);
                    }
                    break;
                //Triple the quantity of ingredients
                case 4:
                    for (int i = 0; i < numIngredients; i++)
                    {
                        arrIngredients[i].setQuantity(arrIngredients[i].getQuantity() * 3);
                    }
                    break;
            }
        }

        //Custom toString that returns a formatted list within the recipe
        public string toString()
        {
            string temp = "\t\tRecipe";
            temp += "\n___________________________________";
            temp += "\nIngredients";
            for (int i  = 0; i < numIngredients; i++)
            {
                temp += "\n - Ingredient "+(i+1) + ": " +  arrIngredients[i].printIngredient();
            }
            temp += "\n___________________________________";
            temp += "\nSteps:";
            for (int i = 0;i<numSteps; i++)
            {
                temp += "\nStep " + (i+1) + ": " + arrSteps[i];
            }


            return temp;
        }
    }
}
