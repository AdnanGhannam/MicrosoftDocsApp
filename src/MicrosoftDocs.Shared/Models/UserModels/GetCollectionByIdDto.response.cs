using MicrosoftDocs.Shared.Models.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Shared.Models.UserModels;

public record GetCollectionByIdDto(string Id, string Name, List<GetArticlesDto> Articles);
