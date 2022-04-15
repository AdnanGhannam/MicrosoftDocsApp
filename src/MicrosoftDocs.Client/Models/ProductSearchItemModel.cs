namespace MicrosoftDocs.Client.Models;

public record ProductSearchItemModel(string Name,
    HashSet<ProductSearchItemModel>? Items = null);
