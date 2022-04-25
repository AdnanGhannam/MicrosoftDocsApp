using AutoMapper;
using MediatR;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Commands.ProductCommands;

namespace MicrosoftDocs.Web.Features.Handlers.ProductHandlers;

public class RemoveProductHandler : IRequestHandler<RemoveProductCommand, object>
{
    private readonly IEfRepository<Product> _efRepository;
    private readonly IMapper _mapper;

    public RemoveProductHandler(IEfRepository<Product> efRepository,
        IMapper mapper)
    {
        _efRepository = efRepository;
        _mapper = mapper;
    }

    public async Task<object> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _efRepository.DeleteAsync(request.ProductId);

        if (product == null)
        {
            return new ErrorModel("NotFound", $"Product with Id: { request.ProductId } is not found");
        }

        var dto = _mapper.Map<GetProductDto>(product);

        return dto;
    }
}
