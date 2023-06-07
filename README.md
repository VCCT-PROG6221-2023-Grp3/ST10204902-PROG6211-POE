# ST10204902 PROG6211 POE

[Github](https://github.com/VCCT-PROG6221-2023-Grp3/ST10204902-PROG6211-POE)

## 1A. Installation Instructions
Download the zip file available on this page or via [this link](https://github.com/VCCT-PROG6221-2023-Grp3/ST10204902-PROG6211-POE/archive/refs/heads/master.zip). Open the file using your preferred archive utility tool like [WinRAR](https://www.win-rar.com/predownload.html?&L=0) or Windows File Explorer. Extract the folder to your preferred location like your desktop or documents folder. Navigate to ST10204902 PROG6211 POE/bin/Debug to locate the file labelled ST10204902 PROG6211 POE.exe, launch this file by double clicking it.

## 1B. App Functionality and How To Use It

This application serves as a recipe management application. The currently included features are:
- Adding new Recipes
- Viewing all added recipes in an alphabetically sorted list
- Scaling recipe ingredients
- Clearing recipes from the list
- Calculating the total calories of a Recipe

Adding a new Recipe allows users to enter:
- The name of the recipe, which determines the sorting order
- Number of ingredients in the Recipe
- Details of each ingredient including: name of ingredient, quantity, unit of measurement, food group and calories of the ingredient.
- Number of steps in recreating the recipe
- Description of each step

When running this application, the user will be prompted with instructions at each step. There are two menus that the user can interact with. The first being the Main Menu. This gives users the choice of viewing currently stored Recipes or adding new ones. The user can select the Add New Recipe option and will be navigated to the prompts to fill in Recipe information. After successfully adding a Recipe the user will be returned to the main menu. The user can then select the View Recipes option which will present the namesof all added recipes in a list, sorted alphabetically. The user can then enter the corresponding number for a recipe. This takes the user to the second menu. This menu is specific to the Recipe selected. The user will be presented with the Recipe as well as several options. The user can scale the recipe by a factor of 0.5, 1, 2 or 3. Another is calculating the total calories in the Recipe. If the Recipe exceeds 300 calories, the user will be prompted with a warning and a description of calories. The final option on the Recipe menu is to delete the Recipe. The user will be asked to confirm if they want to delete the recipe before proceeding. The user has an option to return to the previous menu at each point or exit the application on the Main Menu.

## 2. Hardware Requirements
The minimum hardware requirements provided by Microsoft for running applications on the .NET Framework v4.7.2 are as follows:

Processor - 1GHz

RAM - 512MB

Minimum Disk Space - 4.5GB

## 3. Software Requirements
This application was developed in C# on the [.NET Framework v4.7.2](https://support.microsoft.com/en-us/topic/microsoft-net-framework-4-7-2-offline-installer-for-windows-05a72734-2127-a15d-50cf-daf56d5faec2)

To view the code for this application you can use an application such as [Microsoft Visual Studio](https://visualstudio.microsoft.com/vs/community/)

Recommended OS: Windows 11 64-bit

## 4. Contributions
Please feel free to comment on the work and make pull requests. Open an issue ticket to start a conversation about changes.

## 5. License

[MIT](https://choosealicense.com/licenses/mit/)

## 6. Updates after POE 1
1. The number of commits in the previous submission were under the required amount. After this submission the number of commits with meaningful comments has increased beyond the 15 required. 
2. Error handling fell short on the previous submission. To rectify this, certain validation prompts included new details on what is missing in a users submitted input.
3. App functionality was overrall strong but fell short on menu management. With the part 2 submission, the main console class was rewritten in the style of a number-based menu. 
4. Additional detail on installation was added to the readme to address the information requirement for the rubric.