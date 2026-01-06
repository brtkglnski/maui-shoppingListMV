using ShoppingList_4J.Services;

namespace ShoppingList_4J.Views;

public partial class AddNewCategoryPage : ContentPage
{
    public AddNewCategoryPage()
    {
        InitializeComponent();
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
            return;

        var category = new Models.Category(NameEntry.Text);

        App.Categories.Add(category);

        await new StorageService().SaveAsync(App.Categories.ToList());

        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
