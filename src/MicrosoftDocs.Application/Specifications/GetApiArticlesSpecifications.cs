using Ardalis.Specification;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Application.Specifications;

public class GetApiArticlesSpecifications : Specification<Article>
{
    public GetApiArticlesSpecifications()
    {
        Query.Where(e => e.IsApi == true);
    }
}
