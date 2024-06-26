using Jose_ST10376126_PROG6221_POE.Class;
using System.Windows;
using System.Windows.Controls;


namespace RecipeGUI
{
    public partial class MainWindow : Window
    {
        Recipe recipes = new Recipe();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            //
            recipes.recipeName = RecipeNameInput.Text;

        }
    }
}