using AutoMapper;
using MediatR;
using MicrosoftDocs.Application.Specifications;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Queries.ArticleQueries;

namespace MicrosoftDocs.Web.Features.Handlers.ArticleHandlers;

public class GetApiArticlesHandler : IRequestHandler<GetApiArticlesQuery, List<GetArticlesDto>>
{
    private readonly IEfRepository<Article> _efRepository;
    private readonly IMapper _mapper;

    public GetApiArticlesHandler(IEfRepository<Article> efRepository,
        IMapper mapper)
    {
        _efRepository = efRepository;
        _mapper = mapper;
    }

    public async Task<List<GetArticlesDto>> Handle(GetApiArticlesQuery request, 
        CancellationToken cancellationToken)
    {
        var specification = new GetApiArticlesSpecifications();
        var articles = await _efRepository.GetListAsync(specification);

        var dtos = articles.Select(article => _mapper.Map<GetArticlesDto>(article));

        return dtos.ToList();
    }
}
