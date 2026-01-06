using System.Text.Json;
using ShoppingList_4J.Models;

namespace ShoppingList_4J.Services;

public class StorageService
{
    string FilePath => Path.Combine(FileSystem.AppDataDirectory, "ShoppingListData.json");

    public async Task SaveAsync(List<Category> categories)
    {
        var json = JsonSerializer.Serialize(categories);
        await File.WriteAllTextAsync(FilePath, json);
    }

    public async Task<List<Category>> LoadAsync()
    {
        if (!File.Exists(FilePath))
            return new();

        var json = await File.ReadAllTextAsync(FilePath);
        return JsonSerializer.Deserialize<List<Category>>(json) ?? new();
    }
}
