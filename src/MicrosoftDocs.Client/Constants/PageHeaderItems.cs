using MicrosoftDocs.Client.Models;
using MudBlazor;

namespace MicrosoftDocs.Client.Constants;

public static class PageHeaderItems
{
    public static readonly List<(string Name, string Alias, List<PageHeaderItemModel> Items)> ItemsLists = new()
    {
        new("dotnet",
            ".NET",
            new()
            {
                new("Languages", Icons.Filled.KeyboardArrowDown, new()
                {
                    new("C#", Href: "#"),
                    new("F#", Href: "#"),
                    new("Visual Basic", Href: "#"),
                }),
                new("Workflows", Icons.Filled.KeyboardArrowDown, new()
                {
                    new("Web", Href: "#"),
                    new("Mobile", Href: "#"),
                    new("Cloud", Href: "#"),
                    new("Desktop", Items: new()
                    {
                        new("Windows Presentation Foundation", Href: "#"),
                        new("Windows Forms", Href: "#"),
                        new("Universal Windows apps", Href: "#"),
                        new("Xamarin for macOS", Href: "#"),
                    }),
                }),
                new("APIs", Icons.Filled.KeyboardArrowDown, new()
                {
                    new(".NET", Href: "#"),
                    new(".NET Framework", Href: "#"),
                    new("ASP.NET", Href: "#"),
                    new("Machine Learning", Href: "#"),
                    new("EF Core", Href: "#"),
                    new("NET", Href: "#"),
                }),
                new("Resources", Icons.Filled.KeyboardArrowDown, new()
                {
                    new("What is .NET", Href: "https://www.fake.c/what-is-dotnet"),
                    new(".NET Architecture Guide", Href: "https://www.fake.c/dotent-archi-guide"),
                    new("Learning Materials", Href: "https://www.fake.c/leaning-materials"),
                    new("Downloads", Href: "https://www.fake.c/downloads"),
                    new("Community", Href: "https://www.fake.c/communtiy"),
                    new("Support", Href: "https://www.fake.c/support"),
                    new("Blog", Href: "https://www.fake.c/blog"),
                }),
            }),
        new("xamarin",
            "Xamarin",
            new()
            {
                new("Get Started", Icons.Filled.KeyboardArrowDown, Href: "/xamarin/get-started"),
                new("Android", Icons.Filled.KeyboardArrowDown, Href: "/xamarin/android"),
                new("IOS", Icons.Filled.KeyboardArrowDown, Href: "/xamarin/ios"),
                new("Mac", Icons.Filled.KeyboardArrowDown, Href: "/xamarin/mac"),
                new("Xamarin.Forms", Icons.Filled.KeyboardArrowDown, Href: "/xamarin/xamarin-forms"),
                new("Xamarin Community Toolkit", Icons.Filled.KeyboardArrowDown, Href: "/xamarin/xamarin-community-toolkit"),
                new("Samples", Icons.Filled.KeyboardArrowDown, new()
                {
                    new("Xamarin.Forms Samples", Href: "#"),
                    new("Android Samples", Href: "#"),
                    new("IOS Samples", Href: "#"),
                    new("Mac Samples", Href: "#"),
                    new("All Xamarin Samples", Href: "#"),
                }),
                new("APIs", Icons.Filled.KeyboardArrowDown, new()
                {
                    new("Xamarin.Forms APIs", Href: "#"),
                    new("Xamarin Community Toolkit APIs", Href: "#"),
                    new("Android APIs", Href: "#"),
                    new("IOS APIs", Href: "#"),
                    new("Mac APIs", Href: "#"),
                }),
            }),
    };
}
