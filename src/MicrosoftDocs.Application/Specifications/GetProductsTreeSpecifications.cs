using Ardalis.Specification;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Application.Specifications;

public class GetProductsTreeSpecifications : Specification<Product>
{
    public GetProductsTreeSpecifications()
    {
        Query
            .AsNoTracking()
            .Where(e => e.ParentId == null)
            .Include(e => e.Creator)
            .Include(e => e.Language)
            .Include(e => e.Products)
                .ThenInclude(e => e.Products)
                    .ThenInclude(e => e.Products);
    }
}
