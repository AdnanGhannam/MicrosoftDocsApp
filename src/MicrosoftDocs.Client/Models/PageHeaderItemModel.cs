using MudBlazor;

namespace MicrosoftDocs.Client.Models;

public record PageHeaderItemModel(string Label, 
    string Icon, 
    Dictionary<string, string>? Items = null, 
    string? Url = null);
