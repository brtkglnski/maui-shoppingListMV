using ShoppingList_4J.Services;
using ShoppingList_4J.Models;
namespace ShoppingList_4J.Views.Components;

public partial class ProductView : ContentView
{
    private readonly StorageService _storage = new StorageService();
    public ProductView()
    {
        InitializeComponent();
    }
    private async void OnIncreaseClicked(object sender, EventArgs e)
    {
        if (BindingContext is Product product)
        {
            product.Quantity++;
            await _storage.SaveAsync(App.Categories.ToList());
        }
    }

    private async void OnDecreaseClicked(object sender, EventArgs e)
    {
        if (BindingContext is Product product && product.Quantity > 0)
        {
            product.Quantity--;
            await _storage.SaveAsync(App.Categories.ToList());
        }
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (BindingContext is Product product)
        {
            foreach (var category in App.Categories)
            {
                if (category.Products.Contains(product))
                {
                    category.Products.Remove(product);
                    break;
                }
            }

            await _storage.SaveAsync(App.Categories.ToList());
        }
    }

    private async void OnQuantityChanged(object sender, TextChangedEventArgs e)
    {
        if (BindingContext is Product product && sender is Entry entry)
        {
            if (int.TryParse(entry.Text, out int value))
            {
                product.Quantity = value;
                await _storage.SaveAsync(App.Categories.ToList());
            }
        }
    }

    private async void OnPurchasedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (BindingContext is not Product product) return;

        product.Purchased = e.Value;

        var category = App.Categories.FirstOrDefault(c => c.Products.Contains(product));
        category?.SortProducts();

        await _storage.SaveAsync(App.Categories.ToList());
    }


}
