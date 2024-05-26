/* Jose Lubota
 * Student Number: ST10376126
 * Group: 2
 * References:
 *          https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
 *          https://www.w3schools.blog/c-sharp-list
 *          https://www.w3schools.com/cs/cs_arrays_loop.php
 *          https://web-p-ebscohost-com.ezproxy.iielearn.ac.za/ehost/ebookviewer/ebook/bmxlYmtfXzI5MTc3MDFfX0FO0?sid=f5055d80-d4b0-4010-9877-c1a2d34945af@redis&vid=0&format=EB&lpid=lp_xlv&rid=0     
 *          https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/exception-handling
 *          https://learn.microsoft.com/en-us/dotnet/api/system.formatexception?view=net-8.0
 *          https://sweetlife.org.za/how-much-to-eat-to-lose-weight/
 */
using System;
using System.Collections.Generic;
using System.Linq;


namespace Jose_ST10376126_PROG6221_POE.Class
{
    // Creating a class that represents a recipe
    public class Recipe
    {
        //..................................................................................................................
        // Class Contructor
        public Recipe() { }
        //--------------------------------------------------------------//
        //................................. Variables/List/Arrays belonging to Recipe class
        //
        List<Recipe> recipes { get; set; }
        // Indicates the number of ingrients in the recipe
        public double numberOfIngridient { get; set; }
        // Ingridient's name
        public string name { get; set; }
        // Ingridient's name
        public string foodGroup { get; set; }
        // Ingridient's quantity
        public double quantity { get; set; }
        // Ingridient's quantity
        public double calories { get; set; } 
        // Unit of measurement (tablespoon, cup, etc.) for ingridients
        public string unitOfMeasurement { get; set; }
        public List<Ingridient> recipeIngridient { get; set; }
        // Arry to store steps
        public List<Steps> recipeSteps { get; set; }
        // Array to store ingridients
        double factor;
        // List to store original values of quantity
        List<double> ogQuantityValues { get; set; }
        // List to store original values of quantity
        List<string> ogUnitOfMeasurement { get; set; }
        public double stepsNumber { get; set; }
        public string recipeName { get; set; }




        //.......................................................Methods..................................................//

        //.............................................Input Methods........................................ ..........//
        //
        // Allows user to enter ingridients
        public void enterIngridients()
        {
            try
            {
                for (int i = 0; i < numberOfIngridient; i++)
                {
                    Ingridient.CaloriesExceeded += Ingridient.Ingridient_CaloriesExceeded;
                    Console.WriteLine("----------------------------");
                    Console.Write("\nIngrident ", numberOfIngridient);
                    name = checkStringInput("\nEnter ingrident name - ");
                    unitOfMeasurement = checkStringInput("\nEnter unit of measuremnt  - ");
                    ogUnitOfMeasurement.Add(unitOfMeasurement); 
                    quantity = checkDoubleInput("\nEnter quantity of ingrident - ");
                    ogQuantityValues.Add(quantity);
                    foodGroup = provideFoodGroupDescription();
                    calories = checkDoubleInput("\nCalories are the energy used by our body and each food has an estimated amount of it \nEnter the quantity of calories - ");

                    // Name - Quantity - Unit of Measurement
                    Ingridient ingridient = new Ingridient(recipeName, name, quantity, unitOfMeasurement, foodGroup, calories);
                    recipeIngridient.Add(ingridient);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return;
            }

        }

        //----------------------------------------------------------------------------------------------------------------
        //Allows user to enter steps
        public void enterSteps() 
        {
            try
            {
                for (int i = 0; i < stepsNumber; i++)
                {
                    Console.WriteLine("------------------------");
                    Console.Write("\n Step " + i+1);
                    string description = checkStringInput("\nEnter description - ");
                    Steps step = new Steps(recipeName, description, i+1);
                    recipeSteps.Add(step);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //----------------------------------------------------------------------------------------------------------------
        // Create input for user to set ingridients and steps size
        public void initialize()
        {
            recipeName = checkStringInput("\nEnter the recipe name - ");
            numberOfIngridient = checkDoubleInput("\nEnter quantity of ingridients - ");
            stepsNumber = checkDoubleInput("\nEnter quantity of  steps - ");

            ogQuantityValues = new List<double> { };
            ogUnitOfMeasurement = new List<string> { };
        }
        public void initializeLists()
        {
            recipeIngridient = new List<Ingridient> { };
            recipeSteps = new List<Steps> { };
        }



        //.............................................Output Methods..................................................//
        //----------------------------------------------------------------------------------------------------------------
        // Print the ingridients
        public void printIngridients()
        {
            recipeIngridient.Sort((x, y) => string.Compare(x.recipeName, y.recipeName));
            foreach (var ingridient in recipeIngridient)
            {
                changeColor(3);
                Console.WriteLine("-------------------------------------------\n");
                Console.WriteLine("Recipe: " + ingridient.recipeName + "\n");
                changeColor(0);
                Console.WriteLine("| Name | "+ingridient.name);
                changeColor(1);
                Console.WriteLine("| Quantity | " +ingridient.quantity);
                changeColor(2);
                Console.WriteLine("| Unit of Measurement | " + ingridient.unitOfMeasurement );
                changeColor(3);
                Console.WriteLine("| Food group | "+ingridient.foodGroup );
                changeColor(0);
                Console.WriteLine("| Calories | "+ ingridient.calories);
                ingridient.provideCaloriesMeaning();
                // Set text color to white
                changeColor(10);

            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Print the steps
        public void printSteps()
        {  
            foreach (var step in recipeSteps)
            {
                changeColor(0);
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Recipe: " + step.recipeName);
                changeColor(1);
                Console.WriteLine("| Step | " + step.stepNumber);
                changeColor(2);
                Console.WriteLine("| Description | " + step.description);
            }
            Console.WriteLine("-------------------------------------------");
            changeColor(10);
        }


        //.................................,,,,,,,,,,,,...........Mixed Methods...................................................//
        //----------------------------------------------------------------------------------------------------------------------------
        // Create a loop to test all modules
        public void TestRecipe()
        {
            int option = 0;
            initializeLists();
            initialize();
            enterIngridients();
            enterSteps();
            while (true)
            {

                changeColor(3);
                Console.WriteLine("-----------------------------------------------");
                changeColor(10);
                Console.Write("Choose the operatio you'd like to do" +
                    "\n1-Print the Recipe" +
                    "\n2-Scale quantity of ingridients" +
                    "\n3-Rest values to original ones" +
                    "\n4-Add a new recipe" +
                    "\n5-Clear all data\n6-Stop program\n - ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        printIngridients();
                        printSteps();
                        break;
                    case 2:
                        scale();
                        printIngridients();
                        break;
                    case 3:
                        resetQuantity();
                        break;
                    case 4:
                        initialize();
                        enterIngridients();
                        enterSteps();
                        break;
                    case 5:
                        clearData();
                        initializeLists();
                        initialize();
                        enterIngridients();
                        enterSteps();
                        break;
                    case 6:
                        return;
                    default:
                        break;

                }
                Console.ReadLine();
            }

        }


        //...................................................Operative Methods........................................................//
        //----------------------------------------------------------------------------------------------------------------
        //  Reset the ingridient quantity to their first values
        public void resetQuantity()
        {
            int row = 0;
            foreach (var ingridient in recipeIngridient)
            {
                ingridient.quantity = ogQuantityValues[row];
                ingridient.unitOfMeasurement = ogUnitOfMeasurement[row];
                row += 1;
            }


        }
        //-------------------------- -------------------------------------------------------------------------------------------------
        // Clear ingridients and steps array
        public void clearData()
        {
            while (true)
            {
                string confirmation = checkStringInput("Please confirm if you really want to clear the data \nEnter [Y/N] ").ToUpper();
                if (confirmation == "Y")
                {
                    recipeSteps.Clear();
                    recipeIngridient.Clear();
                    Console.WriteLine("Data was seccusfully cleared!");
                    break;
                }
                else if (confirmation == "N")
                {
                    break;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        // Allow the user to multiply the quantity of ingridients by (0.5, 2, 3) times
        public void scale()
        {
            double option = checkDoubleInput("How would you like to change the ingridients quantity \n1-Half\n2-Double\n3-Triple\n - ");

            switch (option)
            {
                case 1:
                    factor = 0.5;
                    break;
                case 2:
                    factor = 2;
                    break;
                case 3:
                    factor = 3;
                    break;
                default:
                    factor = 1;
                    break;
            }
            foreach (var ingridient in recipeIngridient)
            {
                double newQuantity = Convert.ToInt32(ingridient.quantity) * factor;
                if (newQuantity >= 16)
                {
                    newQuantity = newQuantity / 16;
                    if (ingridient.unitOfMeasurement == "tablespoon")
                    {
                        ingridient.unitOfMeasurement = "Cup";
                    }
                }
                ingridient.quantity = newQuantity;

            }
        }

        //----------------------------------------------------------------------------------------------------------------------------
        // Change the default color's of printed values.
        public void changeColor(int column)
        {
            if (column == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;

            }
            else if (column == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (column == 2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (column == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        // 
        public string checkStringInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out _))
                {
                    changeColor(1);
                    Console.WriteLine("Invalid format. Please enter a valid strings (words/ not numbers) ");
                    changeColor(10);
                }else if (string.IsNullOrWhiteSpace(input))
                {
                    changeColor(1);
                    Console.WriteLine("Your input must contain words");
                    changeColor(10);
                }
                else
                {
                    return input;
                }

            }
  
        }
        //----------------------------------------------------------------------------------------------------------------------------
        // 
        public double checkDoubleInput(string prompt)
        {
            double result = 0;
            while (true)
            {
                Console.Write(prompt);
                string  input =Console.ReadLine();

                try
                {
                    result = double.Parse(input);
                    if (result <= 0)
                    {
                        throw new ArgumentException("The number must be grater than 0");
                    }
                    break;
                }
                catch (FormatException)
                {
                    changeColor(1);
                    Console.WriteLine("Invalied format. Please enter a number");
                    changeColor(10);
                }
                catch (OverflowException)
                {
                    changeColor(1);
                    Console.WriteLine("The number is too small or too large. Please enter a valid one");
                    changeColor(10);
                }
                catch(ArgumentException ex)
                {
                    changeColor(1);
                    Console.WriteLine(ex.Message);
                    changeColor(10);
                }

            }
            return result;


        }
        //----------------------------------------------------------------------------------------------------------------------------
        // User must select foodgroup from a selected option
        public string provideFoodGroupDescription()
        {
            Console.WriteLine("The food groups are the different categories of foods separated by what they can provide to our body");
            while (true)
            {
                double opt = checkDoubleInput("Select a food group" +
                    "\n1 - Starchy foods" +
                    "\n2 - Vegetables and fruits" +
                    "\n3 - Dry beans, peas, lentils and soya" +
                    "\n4 - Chicken, fish, meat and eggs" +
                    "\n5 - Milk and dairy products" +
                    "\n6 - Fats and oil" +
                    "\n7 - Water");

                switch (opt)
                {
                    case 1: return "Starchy foods";
                    case 2: return "Vegetables and fruits";
                    case 3: return "Dry beans, peas, lentils and soya";
                    case 4: return "Chicken, fish, meat and eggs";
                    case 5: return "Milk and dairy products";
                    case 6: return " Fats and oil";
                    case 7: return "Water";
                    default: break;
                }
            }


            }
        }
}

//-----------------------------------------------... END OF THE FILE...--------------------------------------------------------------//