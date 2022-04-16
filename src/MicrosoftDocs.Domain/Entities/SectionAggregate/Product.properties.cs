using MicrosoftDocs.Domain.Base;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Product : EntityBase, IAggregateRoot
{
    public string Title { get; protected set; }


    public string CreatorId { get; protected set; }
    public AppUser Creator { get; protected set; }


    public string LanguageId { get; protected set; }
    public Language Language { get; protected set; }



    protected List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
}
