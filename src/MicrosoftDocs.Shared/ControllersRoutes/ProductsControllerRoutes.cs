using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Shared.ControllersRoutes;

public static class ProductsControllerRoutes
{
    public const string Root = "/api/[controller]";
    public const string GetAll = "all";
    public const string GetById = "";
    public const string AddProduct = "add";
    public const string AddSection = "sections/add";
    public const string RemoveProduct = "remove";
    public const string RemoveSection = "sections/remove";
}
