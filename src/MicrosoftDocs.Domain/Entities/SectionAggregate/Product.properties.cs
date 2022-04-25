using MicrosoftDocs.Domain.Base;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Product : ArticleBase, IAggregateRoot
{
    public string? ParentId { get; set; }



    private List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();


    private List<Section> _sections = new();
    public IReadOnlyCollection<Section> Sections => _sections.AsReadOnly();


    private List<Article> _articles = new();
    public IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();
}
