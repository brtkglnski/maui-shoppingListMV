namespace ShoppingList_4J.Views.Components;

public partial class CategoryView : ContentView
{
    public CategoryView()
    {
        InitializeComponent();
    }

    private void OnToggleClicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Category category)
        {
            category.IsExpanded = !category.IsExpanded;
        }
    }
}
