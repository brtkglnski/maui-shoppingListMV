using System.Collections.ObjectModel;
using ShoppingList_4J.Models;
using ShoppingList_4J.Services;

namespace ShoppingList_4J;

public partial class App : Application
{
    public static ObservableCollection<Category> Categories { get; } = new();

    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();

        LoadCategoriesAsync();
    }

    private async void LoadCategoriesAsync()
    {
        var loaded = await new StorageService().LoadAsync();
        foreach (var category in loaded)
            Categories.Add(category);
    }

}