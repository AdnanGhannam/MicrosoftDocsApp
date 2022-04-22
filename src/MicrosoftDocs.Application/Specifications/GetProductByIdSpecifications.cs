using Ardalis.Specification;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Application.Specifications;

public class GetProductByIdSpecifications : Specification<Product>
{
    public GetProductByIdSpecifications()
    {
        Query
            .AsNoTracking()
            .Include(e => e.Articles)
            .Include(e => e.Sections)
                .ThenInclude(e => e.Articles)
            .Include(e => e.Sections)
                .ThenInclude(e => e.Sections)
                    .ThenInclude(e => e.Articles);
    }
}
