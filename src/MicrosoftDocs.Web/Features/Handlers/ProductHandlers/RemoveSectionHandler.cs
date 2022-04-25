using AutoMapper;
using MediatR;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Commands.ProductCommands;

namespace MicrosoftDocs.Web.Features.Handlers.ProductHandlers;

public class RemoveSectionHandler : IRequestHandler<RemoveSectionCommand, object>
{
    private readonly IEfRepository<Section> _efRepository;
    private readonly IMapper _mapper;

    public RemoveSectionHandler(IEfRepository<Section> efRepository,
        IMapper mapper)
    {
        _efRepository = efRepository;
        _mapper = mapper;
    }

    public async Task<object> Handle(RemoveSectionCommand request, CancellationToken cancellationToken)
    {
        var section = await _efRepository.DeleteAsync(request.SectionId);

        if (section == null)
        {
            return new ErrorModel("NotFound", $"Product with Id: { request.SectionId } is not found");
        }

        var dto = _mapper.Map<GetSectionDto>(section);

        return dto;
    }
}
