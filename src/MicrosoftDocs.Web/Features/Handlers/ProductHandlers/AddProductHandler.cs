using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Infrastructure.Data;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Commands.ProductCommands;

namespace MicrosoftDocs.Web.Features.Handlers.ProductHandlers;

public class AddProductHandler : IRequestHandler<AddProductCommand, object>
{
    private readonly IEfRepository<Product> _efRepository;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AddProductHandler(IEfRepository<Product> efRepository,
        AppDbContext context,
        IMapper mapper)
    {
        _efRepository = efRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<object> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var language = await _context.Languages.FindAsync(request.Dto.LanguageId);

        if(language == null)
        {
            return new ErrorModel("NotFound", $"Language with Id: { request.Dto.LanguageId } is not found");
        }

        var product = new Product(request.Dto.Title, request.UserId, language.Id);

        await _efRepository.AddAsync(product);

        return _mapper.Map<GetProductDto>(product);
    }
}
