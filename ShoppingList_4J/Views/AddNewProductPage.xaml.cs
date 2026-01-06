using ShoppingList_4J.Services;

namespace ShoppingList_4J.Views;

public partial class AddNewProductPage : ContentPage
{
    public AddNewProductPage()
    {
        InitializeComponent();

        CategoryPicker.ItemsSource = App.Categories;
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
            CategoryPicker.SelectedItem is not Models.Category category)
            return;

        var product = new Models.Product(NameEntry.Text, UnitEntry.Text ?? "");

        category.Products.Add(product);

        await new StorageService().SaveAsync(App.Categories.ToList());
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
