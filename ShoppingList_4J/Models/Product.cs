using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShoppingList_4J.Models;

public class Product : INotifyPropertyChanged
{
    public Product(string name, string unit)
    {
        Name = name;
        Unit = unit;
    }
    public string Name { get; set; }
    public string Unit { get; set; }
    private int _quantity = 1;
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }
    }

    private bool _purchased;
    public bool Purchased
    {
        get => _purchased;
        set
        {
            if (_purchased != value)
            {
                _purchased = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
