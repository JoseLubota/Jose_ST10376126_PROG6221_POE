/* Jose Lubota
 * Student Number: ST10376126
 * Group: 2
 * References:
 *          https://www.w3schools.blog/c-sharp-list
 *          https://web-p-ebscohost-com.ezproxy.iielearn.ac.za/ehost/ebookviewer/ebook/bmxlYmtfXzI5MTc3MDFfX0FO0?sid=f5055d80-d4b0-4010-9877-c1a2d34945af@redis&vid=0&format=EB&lpid=lp_xlv&rid=0     
 *          https://sweetlife.org.za/how-much-to-eat-to-lose-weight/
 *          https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test
 */
using Jose_ST10376126_PROG6221_POE.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace JoseST10376126_PROG221_POE.UnitTests
{
    [TestClass]
    public class RecipeTests
    {
//................................................................................................................................................................................
        [TestMethod]
        // Test if calories exceed handler will trigger after the condition to trigger it is met.
        // If it triggers it must returns true
        public void Test_Calories_Exceed_300_ReturnTrue()
        {
            bool eventTriggered = false;
            Ingridient.CaloriesExceeded += (sender, e) => { eventTriggered = true; };
            Ingridient test1 = new Ingridient("Curry","Chicken",1,"kg","Meat",400);
            Assert.IsTrue(eventTriggered, "Calories exceeded 300");
        }

//................................................................................................................................................................................
        [TestMethod]
        // Test if calories exceed handler will not trigger after the condition to trigger it is not met.
        // If won't trigger so it must return false
        public void Test_Calories_Dont_Exceed_300_ReturnFalse()
        {
            bool eventTriggered = false;
            Ingridient.CaloriesExceeded += (sender, e) => { eventTriggered = true; };
            Ingridient test2 = new Ingridient("Curry", "Chicken", 1, "kg", "Meat", 10);
            Assert.IsFalse(eventTriggered, "Calories don't exceeded 300");
        }
//................................................................................................................................................................................
        [TestMethod]
        // Test if calories exceed handler will not trigger after the condition to trigger(x > 300) is equal the current calories value.
        // If won't trigger because the calories must be GREATER than 300 so it must return false
        public void Test_Calories_Equals_300_ReturnFalse()
        {
            bool eventTriggered = false;
            Ingridient.CaloriesExceeded += (sender, e) => { eventTriggered = true; };
            Ingridient test3 = new Ingridient("Curry", "Chicken", 1, "kg", "Meat", 300);
            Assert.IsFalse(eventTriggered, "Calories equal to 300");
        }
    }
}
//...........................................END OF FILE..................................................................................