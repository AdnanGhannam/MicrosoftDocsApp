using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Infrastructure.Data;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Commands.ArticleCommands;

namespace MicrosoftDocs.Web.Features.Handlers.ArticleHandlers;

public class AddArticleHandler : IRequestHandler<AddArticleCommand, object>
{
    private readonly IEfRepository<Section> _sectionRepository;
    private readonly IEfRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public AddArticleHandler(IEfRepository<Section> sectionRepository,
        IEfRepository<Product> productRepository,
        IMapper mapper)
    {
        _sectionRepository = sectionRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<object> Handle(AddArticleCommand request, CancellationToken cancellationToken)
    {
        var requestDto = request.ArticleDto;

        if(requestDto.SectionId == null && requestDto.ProductId == null)
        {
            return new ErrorModel("RequiredField", "Either 'SectionId' or 'ProductId' is required");
        }

        Article article;

        if(requestDto.SectionId != null)
        {
            var section = await _sectionRepository.GetByIdAsync(requestDto.SectionId);

            if(section == null)
            {
                return new ErrorModel("NotFound", $"Section with Id: { requestDto.SectionId } is not found");
            }

            article = new(requestDto.Title,
                request.UserId,
                requestDto.Content,
                string.Join(";", requestDto.Points),
                section.LanguageId,
                requestDto.FullTitle);

            section.Add(article);
        } 
        else
        {
            var product = await _productRepository.GetByIdAsync(requestDto.ProductId);

            if(product == null)
            {
                return new ErrorModel("NotFound", $"Product with Id: { requestDto.ProductId } is not found");
            }

            article = new(requestDto.Title,
                request.UserId,
                requestDto.Content,
                string.Join(";", requestDto.Points),
                product.LanguageId,
                requestDto.FullTitle);

            product.Add(article);
        }

        await _productRepository.SaveChangesAsync();

        return _mapper.Map<GetArticleDto>(article);
    }
}
