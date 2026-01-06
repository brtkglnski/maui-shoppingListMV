namespace ShoppingList_4J
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.AddNewCategoryPage), typeof(Views.AddNewCategoryPage));
            Routing.RegisterRoute(nameof(Views.AddNewProductPage), typeof(Views.AddNewProductPage));
        }
    }
}
