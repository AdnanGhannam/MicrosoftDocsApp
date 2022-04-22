using Ardalis.Specification;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Application.Specifications;

public class GetArticleByIdSpecifications : Specification<Article>
{
    public GetArticleByIdSpecifications()
    {
        Query
            .Include(e => e.Contributors);
    }
}
