/* Jose Lubota
 * Student Number: ST10376126
 * Group: 2
 * References:
 *          https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
 *          https://www.w3schools.blog/c-sharp-list
 *          https://www.w3schools.com/cs/cs_arrays_loop.php
 *          https://web-p-ebscohost-com.ezproxy.iielearn.ac.za/ehost/ebookviewer/ebook/bmxlYmtfXzI5MTc3MDFfX0FO0?sid=f5055d80-d4b0-4010-9877-c1a2d34945af@redis&vid=0&format=EB&lpid=lp_xlv&rid=0     
 */
using System;
using System.Collections.Generic;


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
        public int numberOfIngridient { get; set; }
        // Ingridient's name
        public string name { get; set; }
        // Ingridient's name
        public string foodGroup { get; set; }
        // Ingridient's quantity
        public double quantity { get; set; }
        // Ingridient's quantity
        public int calories { get; set; } 
        // Unit of measurement (tablespoon, cup, etc.) for ingridients
        public string unitOfMeasurement { get; set; }
        List<Ingridient> recipeIngridient { get; set; }
        // Arry to store steps
        List<Steps> recipeSteps { get; set; }
        // Array to store ingridients
        double factor;
        // List to store original values of quantity
        List<double> ogQuantityValues { get; set; }
        // List to store original values of quantity
        List<string> ogUnitOfMeasurement { get; set; }
        public int stepsNumber { get; set; }
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
                    Console.WriteLine("------------------------");
                    Console.Write("\nIngrident ", numberOfIngridient);

                    Console.Write("\nEnter ingrident name - ");
                    name = Console.ReadLine();

                    Console.Write("\nEnter unit of measuremnt  - ");
                    unitOfMeasurement = Console.ReadLine();
                    ogUnitOfMeasurement.Add(unitOfMeasurement); 

                    Console.Write("\nEnter quantity of ingrident - ");
                    quantity = Convert.ToDouble(Console.ReadLine());
                    ogQuantityValues.Add(quantity);

                    Console.Write("\nEnter the food group - ");
                    foodGroup = Console.ReadLine();

                    Console.Write("\nEnter the quantity of calories - ");
                    calories = Convert.ToInt32(Console.ReadLine());

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
                    Console.Write("\nEnter description - ");
                    string description = Console.ReadLine();
                    Steps step = new Steps(recipeName, description, i);
                    recipeSteps.Add(step);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();

            }

        }

        //----------------------------------------------------------------------------------------------------------------
        // Create input for user to set ingridients and steps size
        public void initialize()
        {
            Console.WriteLine("Enter the recipe name - ");
            recipeName = Console.ReadLine();

            Console.Write("\nEnter quantity of ingridients - ");
            numberOfIngridient = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEnter quantity of  steps - ");
            stepsNumber = Convert.ToInt32(Console.ReadLine());

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
            Console.WriteLine("Recipe: " + recipeName);
            changeColor(3);
            Console.WriteLine("-------------------------------------------\n");
            Console.WriteLine("Ingridients\n");
            changeColor(30);
            // Name - Quantity - Unit of Measurement
            changeColor(0);
            Console.Write("| Name |");
            changeColor(1);
            Console.Write(" Quantity |");
            changeColor(2);
            Console.Write(" Unit of Measurement |");
            changeColor(1);
            Console.Write(" Food group |");
            changeColor(2);
            Console.Write(" Calories |\n");

            foreach (var ingridient in recipeIngridient)
            {
                changeColor(0);
                Console.Write(ingridient.name + "   ");
                changeColor(1);
                Console.Write(ingridient.quantity + "   ");
                changeColor(2);
                Console.Write(ingridient.unitOfMeasurement + "   ");
                changeColor(1);
                Console.Write(ingridient.foodGroup + "   ");
                changeColor(2);
                Console.Write(ingridient.calories + "   ");
                // Set text color to white
                Console.WriteLine(" ");
                changeColor(10);

            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Print the steps
        public void printSteps()
        {
            changeColor(3);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Steps of recipe:" + recipeName + "\n");
            changeColor(10);

            // Step number - Descrition
            changeColor(0);
            Console.Write("| Step |");
            changeColor(1);
            Console.WriteLine(" Description |\n");
            foreach (var step in recipeSteps)
            {
                changeColor(0);
                Console.Write(step.stepNumber);
                changeColor(1);
                Console.WriteLine(step.description);

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
        //---------------------------------------------------------------------------------------------------------------------------
        // Clear ingridients and steps array
        public void clearData()
        {
            recipeSteps.Clear();
            recipeIngridient.Clear();
            Console.WriteLine("Data was seccusfully cleared!");
        }
        //----------------------------------------------------------------------------------------------------------------------------
        // Allow the user to multiply the quantity of ingridients by (0.5, 2, 3) times
        public void scale()
        {
            Console.WriteLine("How would you like to change the ingridients quantity \n1-Half\n2-Double\n3-Triple\n - ");
            int option = Convert.ToInt32(Console.ReadLine());

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
    }
}

//-----------------------------------------------... END OF THE FILE...--------------------------------------------------------------//