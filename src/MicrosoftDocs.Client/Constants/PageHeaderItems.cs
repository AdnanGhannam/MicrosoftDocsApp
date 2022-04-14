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
                    { "/csharp", "C#" },
                    { "/fsharp", "F#" },
                    { "/visual-basic", "Visual Basic" },
                }),
                new("Workflows", Icons.Filled.KeyboardArrowDown, new()
                {
                    { "/web", "Web" },
                    { "/mobile", "Mobile" },
                    { "/clound", "Cloud" },
                    { "/desktop", "Desktop" },
                    { "/ml", "Machine Learning & Data" },
                }),
                new("APIs", Icons.Filled.KeyboardArrowDown, new()
                {
                    { "/api/dotnet", ".NET" },
                    { "/api/dotnet-framework", ".NET Framework" },
                    { "/api/aspnet", "ASP.NET" },
                    { "/api/ml", "Machine Learning" },
                    { "/api/ef-core", "EF Core" },
                }),
                new("Resources", Icons.Filled.KeyboardArrowDown, new()
                {
                    { "https://www.fake.c/what-is-dotnet", "What is .NET" },
                    { "https://www.fake.c/dotent-archi-guide", ".NET Architecture Guide" },
                    { "https://www.fake.c/leaning-materials", "Learning Materials" },
                    { "https://www.fake.c/downloads", "Downloads" },
                    { "https://www.fake.c/communtiy", "Community" },
                    { "https://www.fake.c/support", "Support" },
                    { "https://www.fake.c/blog", "Blog" },
                }),
            }),
        new("xamarin",
            "Xamarin",
            new()
            {
                new("Get Started", Icons.Filled.KeyboardArrowDown, Url: "/xamarin/get-started"),
                new("Android", Icons.Filled.KeyboardArrowDown, Url: "/xamarin/android"),
                new("IOS", Icons.Filled.KeyboardArrowDown, Url: "/xamarin/ios"),
                new("Mac", Icons.Filled.KeyboardArrowDown, Url: "/xamarin/mac"),
                new("Xamarin.Forms", Icons.Filled.KeyboardArrowDown, Url: "/xamarin/xamarin-forms"),
                new("Xamarin Community Toolkit", Icons.Filled.KeyboardArrowDown, Url: "/xamarin/xamarin-community-toolkit"),
                new("Samples", Icons.Filled.KeyboardArrowDown, new()
                {
                    { "/samples/xamarin-forms", "Xamarin.Forms Samples" },
                    { "/samples/android", "Android Samples" },
                    { "/samples/ios", "IOS Samples" },
                    { "/samples/mac", "Mac Samples" },
                    { "/samples/all-xamarin", "All Xamarin Samples" },
                }),
                new("APIs", Icons.Filled.KeyboardArrowDown, new()
                {
                    { "/api/xamarin-forms", "Xamarin.Forms APIs" },
                    { "/api/xamarin-community-toolkit", "Xamarin Community Toolkit APIs" },
                    { "/api/android", "Android APIs" },
                    { "/api/ios", "IOS APIs" },
                    { "/api/mac", "Mac APIs" },
                }),
            }),
    };



    //public static readonly Dictionary<string, List<PageHeaderItemModel>> ItemsLists = new()
    //{
    //    { 
    //        "dotnet", 
    //        new()
    //        {
    //            new("Languages", Icons.Filled.KeyboardArrowDown, new()
    //            {
    //                { "/csharp", "C#" },
    //                { "/fsharp", "F#" },
    //                { "/visual-basic", "Visual Basic" },
    //            }),
    //            new("Workflows", Icons.Filled.KeyboardArrowDown, new()
    //            {
    //                { "/web", "Web" },
    //                { "/mobile", "Mobile" },
    //                { "/clound", "Cloud" },
    //                { "/desktop", "Desktop" },
    //                { "/ml", "Machine Learning & Data" },
    //            }),
    //            new("APIs", Icons.Filled.KeyboardArrowDown, new()
    //            {
    //                { "/api/dotnet", ".NET" },
    //                { "/api/dotnet-framework", ".NET Framework" },
    //                { "/api/aspnet", "ASP.NET" },
    //                { "/api/ml", "Machine Learning" },
    //                { "/api/ef-core", "EF Core" },
    //            }),
    //            new("Resources", Icons.Filled.KeyboardArrowDown, new()
    //            {
    //                { "https://www.fake.c/what-is-dotnet", "What is .NET" },
    //                { "https://www.fake.c/dotent-archi-guide", ".NET Architecture Guide" },
    //                { "https://www.fake.c/leaning-materials", "Learning Materials" },
    //                { "https://www.fake.c/downloads", "Downloads" },
    //                { "https://www.fake.c/communtiy", "Community" },
    //                { "https://www.fake.c/support", "Support" },
    //                { "https://www.fake.c/blog", "Blog" },
    //            }),
    //        } 
    //    },
    //    {
    //        "xamarin",
    //        new()
    //        {
    //            new("Get Started", Icons.Filled.KeyboardArrowDown, Url: "/xamarin/get-started"),
    //            new("Android", Icons.Filled.KeyboardArrowDown, Url: "/xamarin/android"),
    //            new("IOS", Icons.Filled.KeyboardArrowDown, Url: "/xamarin/ios"),
    //            new("Mac", Icons.Filled.KeyboardArrowDown, Url: "/xamarin/mac"),
    //            new("Xamarin.Forms", Icons.Filled.KeyboardArrowDown, Url: "/xamarin/xamarin-forms"),
    //            new("Xamarin Community Toolkit", Icons.Filled.KeyboardArrowDown, Url: "/xamarin/xamarin-community-toolkit"),
    //            new("Samples", Icons.Filled.KeyboardArrowDown, new()
    //            {
    //                { "/samples/xamarin-forms", "Xamarin.Forms Samples" },
    //                { "/samples/android", "Android Samples" },
    //                { "/samples/ios", "IOS Samples" },
    //                { "/samples/mac", "Mac Samples" },
    //                { "/samples/all-xamarin", "All Xamarin Samples" },
    //            }),
    //            new("APIs", Icons.Filled.KeyboardArrowDown, new()
    //            {
    //                { "/api/xamarin-forms", "Xamarin.Forms APIs" },
    //                { "/api/xamarin-community-toolkit", "Xamarin Community Toolkit APIs" },
    //                { "/api/android", "Android APIs" },
    //                { "/api/ios", "IOS APIs" },
    //                { "/api/mac", "Mac APIs" },
    //            }),
    //        }
    //    }
    //};
}
