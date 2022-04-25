using AutoMapper;
using MediatR;
using MicrosoftDocs.Application.Specifications;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Queries.ProductQueries;

namespace MicrosoftDocs.Web.Features.Handlers.ProductHandlers;

public class GetAllProductsHandler
    : IRequestHandler<GetAllProductsQuery, List<GetProductDto>>
{
    private readonly IEfRepository<Product> _efRepository;
    private readonly IMapper _mapper;

    public GetAllProductsHandler(IEfRepository<Product> efRepository,
        IMapper mapper)
    {
        _efRepository = efRepository;
        _mapper = mapper;
    }

    public async Task<List<GetProductDto>> Handle(GetAllProductsQuery request, 
        CancellationToken cancellationToken)
    {
        var specification = new GetProductsTreeSpecifications();
        var products = await _efRepository.GetListAsync(specification);

        var dtos = products
            .Select(product => _mapper.Map<GetProductDto>(product))
            .ToList();

        return dtos;
    }
}
