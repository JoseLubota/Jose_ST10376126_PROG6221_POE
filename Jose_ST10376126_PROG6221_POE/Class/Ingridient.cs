using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jose_ST10376126_PROG6221_POE.Class
{
    public delegate void CaloriesEventHandler(object sender, EventArgs e);
    public class Ingridient
    {
        // Ingridient's name
        public string name { get; set; }
        // Ingridient's quantity
        public double quantity { get; set; }
        // Unit of measurement (tablespoon, cup, etc.) for ingridients
        public string unitOfMeasurement { get; set; }
        //
        private double _calories {  get; set; } 
        //
        public string foodGroup { get; set; }
        public string recipeName { get; set; }
        //
        public double calories
        {
            get => _calories;
            set
            {
                if(value > 300)
                {
                    _calories = value;
                    OnCaloriesExceeded(EventArgs.Empty);
                    provideCaloriesMeaning();
                }
                else
                {
                    _calories = value;
                }
            }
        }
        //
        public static event CaloriesEventHandler CaloriesExceeded;



        public Ingridient(string recipeName, string name, double quantity, string measurement, string foodGroup, double calories)
        {
            this.recipeName = recipeName;
            this.name = name;
            this.quantity = quantity;
            unitOfMeasurement = measurement;
            this.foodGroup = foodGroup;
            this.calories = calories;
            //Check if total calories exceed 300 and raise the event
            /*
            if (totalCalories > 300)
            {
                OnCaloriesExceeded(EventArgs.Empty);

            } */
        }
        public Ingridient() { }
        //
        protected virtual void OnCaloriesExceeded(EventArgs e)
        {
            CaloriesExceeded?.Invoke(this, e);
        }
        //
        public static void Ingridient_CaloriesExceeded(object sender, EventArgs e)
        {
           Console.ForegroundColor = ConsoleColor.Red;
           Console.WriteLine("**********************************************");
           Console.WriteLine(" Warning: Total calories have exceeded 300! ");
           Console.WriteLine("**********************************************");
           
           Console.ForegroundColor = ConsoleColor.White;
        }

        public void provideCaloriesMeaning() 
        {
            Console.WriteLine("Meaning of the calories quantity\n");
            if (calories >= 5000)
            {
                Console.WriteLine("Current calories: " + calories + "\nUnsustainable for most people but sometimes associated with bodybuilders");
            }
            else if (calories >= 4000)
            {
                Console.WriteLine("Current calories: " + calories + "\nUnsustainable for most people but sometimes associated competite eating or bulking");
            }
            else if (calories >= 3000)
            {
                Console.WriteLine("Current calories: " + calories + "\nWhat atletes or people with calories expenditures consume");
            }
            else if (calories >= 2000)
            {
                Console.WriteLine("Current calories: " + calories + "\nNormally what an average adult consumes daily");
            }else if(calories >= 1000)
            {
                Console.WriteLine("Current calories: " + calories + "\nNormally a very large meal");
            }
            else if(calories >= 500)
            {
                Console.WriteLine("Current calories: " + calories + "\nNormally the principal meal of the day or fast food with some extras");
            }else if(calories >= 400)
            {
                Console.WriteLine("Current calories: " + calories + "\nNormally a meduim port meal, like a sandwich with beef and vegetables");
            }
            else if(calories >= 300)
            {
                Console.WriteLine("Current calories: " + calories + "\nA light breakfast");
            }
            else if (calories >= 200)
            {
                Console.WriteLine("Current calories: " + calories + "\n Foods like a sandwich or a small serving of yougurt");
            }
            else if (calories >= 100)
            {
                Console.WriteLine("Current calories: " + calories + "\nSmall snacks like an apple, orange,etc.");
            }
        }    
        public bool checkCalories()
        {

            return true;
        }
    }
}
