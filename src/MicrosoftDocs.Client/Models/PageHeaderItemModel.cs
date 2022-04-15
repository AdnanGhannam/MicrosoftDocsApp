using MudBlazor;

namespace MicrosoftDocs.Client.Models;

public record PageHeaderItemModel(string Label, 
    string Icon = "", 
    List<PageHeaderItemModel>? Items = null, 
    string? Href = null);
