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
        private int _calories {  get; set; } 
        //
        public string foodGroup { get; set; }
        public string recipeName { get; set; }
        //
        public int calories
        {
            get => _calories;
            set
            {
                if(value > 300)
                {
                    _calories = value;
                    OnCaloriesExceeded(EventArgs.Empty);
                }
                else
                {
                    _calories = value;
                }
            }
        }
        //
        public static event CaloriesEventHandler CaloriesExceeded;



        public Ingridient(string recipeName, string name, double quantity, string measurement, string foodGroup, int calories)
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

        public bool checkCalories()
        {

            return true;
        }
    }
}
