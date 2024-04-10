using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Jose_ST10376126_PROG6221_POE
{
    class Program
    {
        static void Main(string[] args)
        {

            Recipe recipe = new Recipe(2, 1);
            //recipe.enterIngridient();
            recipe.ingridents[0] = new string[] { "Flour", "2", "cups" };
            recipe.ingridents[1] = new string[] { "Flour", "3", "cups" };
            recipe.steps[0] = new string[] { "1", "bla bla bla b l a" };
            //recipe.enterIngridients();
            //recipe.enterSteps();
            recipe.printIngridients();
            recipe.clearData();
            recipe.printIngridients();


        }

    }

}