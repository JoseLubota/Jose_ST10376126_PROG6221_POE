using Jose_ST10376126_PROG6221_POE.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JoseST10376126_PROG221_POE.UnitTests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void Test_Calories_Exceed_300_ReturnTrue()
        {
            bool eventTriggered = false;
            Ingridient.CaloriesExceeded += (sender, e) => { eventTriggered = true; };
            Ingridient test1 = new Ingridient("Curry","Chicken",1,"kg","Meat",400);
            Assert.IsTrue(eventTriggered, "Calories exceeded 300");
        }

        [TestMethod]
        public void Test_Calories_Dont_Exceed_300_ReturnFalse()
        {
            bool eventTriggered = false;
            Ingridient.CaloriesExceeded += (sender, e) => { eventTriggered = true; };
            Ingridient test2 = new Ingridient("Curry", "Chicken", 1, "kg", "Meat", 10);
            Assert.IsFalse(eventTriggered, "Calories don't exceeded 300");
        }

        [TestMethod]
        public void Test_Calories_Equals_300_ReturnFalse()
        {
            bool eventTriggered = false;
            Ingridient.CaloriesExceeded += (sender, e) => { eventTriggered = true; };
            Ingridient test3 = new Ingridient("Curry", "Chicken", 1, "kg", "Meat", 300);
            Assert.IsFalse(eventTriggered, "Calories equal to 300");
        }
    }
}
