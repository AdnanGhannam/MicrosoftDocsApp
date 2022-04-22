using AutoMapper;
using MediatR;
using MicrosoftDocs.Application.Specifications;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Queries.ProductQueries;

namespace MicrosoftDocs.Web.Features.Handlers.ProductHandlers;

public class GetArticleByIdHandler : IRequestHandler<GetArticleByIdQuery, object>
{
    private readonly IEfRepository<Article> _efRepository;
    private readonly IMapper _mapper;

    public GetArticleByIdHandler(IEfRepository<Article> efRepository,
        IMapper mapper)
    {
        _efRepository = efRepository;
        _mapper = mapper;
    }

    public async Task<object> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var specification = new GetArticleByIdSpecifications();
        var article = await _efRepository.GetByIdAsync(request.Id, specification);

        if(article == null)
        {
            return new ErrorModel("NotFound", $"Article with Id: { request.Id } is not found");
        }

        var dto = _mapper.Map<GetArticleDto>(article);

        return dto;
    }
}
