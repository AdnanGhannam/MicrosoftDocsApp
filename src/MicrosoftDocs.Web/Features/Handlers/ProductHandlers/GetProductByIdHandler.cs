using AutoMapper;
using MediatR;
using MicrosoftDocs.Application.Specifications;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Queries.ProductQueries;

namespace MicrosoftDocs.Web.Features.Handlers.ProductHandlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, object>
{
    private readonly IEfRepository<Product> _efRepository;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(IEfRepository<Product> efRepository,
        IMapper mapper)
    {
        _efRepository = efRepository;
        _mapper = mapper;
    }

    public async Task<object> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var specifications = new GetProductByIdSpecifications();
        var product = await _efRepository.GetByIdAsync(request.Id, specifications);

        if(product == null)
        {
            return new ErrorModel("NotFound", $"Product with Id: { request.Id } is not found");
        }

        var dto = _mapper.Map<GetProductDto>(product);

        return dto;
    }
}
