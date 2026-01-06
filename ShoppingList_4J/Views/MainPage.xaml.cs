namespace ShoppingList_4J.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = App.Categories;
    }

    private async void OnAddCategoryClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddNewCategoryPage));

    }

    private async void OnAddProductClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddNewProductPage));

    }
}
