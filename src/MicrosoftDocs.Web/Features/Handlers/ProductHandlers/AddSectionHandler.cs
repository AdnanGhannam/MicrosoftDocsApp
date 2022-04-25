using AutoMapper;
using MediatR;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Infrastructure.Data;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Commands.ProductCommands;

namespace MicrosoftDocs.Web.Features.Handlers.ProductHandlers;

public class AddSectionHandler : IRequestHandler<AddSectionCommand, object>
{
    private readonly IEfRepository<Section> _sectionRepository;
    private readonly IEfRepository<Product> _productRepository;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AddSectionHandler(IEfRepository<Section> sectionRepository,
        IEfRepository<Product> productRepository,
        AppDbContext context,
        IMapper mapper)
    {
        _sectionRepository = sectionRepository;
        _productRepository = productRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<object> Handle(AddSectionCommand request, CancellationToken cancellationToken)
    {
        if (request.Dto.ProductId == null && request.Dto.SectionId == null)
        {
            return new ErrorModel("RequiredField", "Either ProductId or SectionId is required");
        }

        var language = await _context.Languages.FindAsync(request.Dto.LanguageId);

        if (language == null)
        {
            return new ErrorModel("NotFound", $"Language with Id: { request.Dto.LanguageId } is not found");
        }

        var section = new Section(request.Dto.Title, request.UserId, language.Id);

        if(request.Dto.SectionId != null)
        {
            var parentSection = await _sectionRepository.GetByIdAsync(request.Dto.SectionId);

            if (parentSection  == null)
            {
                return new ErrorModel("NotFound", $"Section with Id: { request.Dto.SectionId } is not found");
            }

            parentSection.Add(section);
        }
        else if(request.Dto.ProductId != null)
        {
            var product = await _productRepository.GetByIdAsync(request.Dto.ProductId);

            if (product == null)
            {
                return new ErrorModel("NotFound", $"Product with Id: { request.Dto.ProductId } is not found");
            }

            product.Add(section);
        }

        await _context.SaveChangesAsync();

        return _mapper.Map<GetSectionDto>(section);
    }
}
