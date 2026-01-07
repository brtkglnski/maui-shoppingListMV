using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShoppingList_4J.Models;

public class Category : INotifyPropertyChanged
{
    public Category(string name)
    {
        Name = name;
        Products.CollectionChanged += (sender, eventArgs) => OnPropertyChanged(nameof(Products));
    }

    public string Name { get; set; }

    public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

    private bool _isExpanded;
    public bool IsExpanded
    {
        get => _isExpanded;
        set
        {
            if (_isExpanded != value)
            {
                _isExpanded = value;
                OnPropertyChanged();
            }
        }
    }

    public void SortProducts()
    {
        var sorted = Products.OrderBy(p => p.Purchased).ToList();
        for (int i = 0; i < sorted.Count; i++)
        {
            if (Products[i] != sorted[i])
                Products.Move(Products.IndexOf(sorted[i]), i);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
