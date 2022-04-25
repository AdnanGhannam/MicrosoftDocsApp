using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
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
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public AddArticleHandler(IEfRepository<Section> sectionRepository,
        IEfRepository<Product> productRepository,
        UserManager<AppUser> userManager,
        IMapper mapper)
    {
        _sectionRepository = sectionRepository;
        _productRepository = productRepository;
        _userManager = userManager;
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
        var user = await _userManager.FindByIdAsync(request.UserId);

        if(requestDto.SectionId != null)
        {
            var section = await _sectionRepository.GetByIdAsync(requestDto.SectionId);

            if(section == null)
            {
                return new ErrorModel("NotFound", $"Section with Id: { requestDto.SectionId } is not found");
            }

            if(section.IsApi != requestDto.IsApi)
            {
                return new ErrorModel("InValidData", $"Can't add an API article inside a non-API section, vice versa");
            }

            article = new(requestDto.Title,
                user.Id,
                requestDto.Content,
                string.Join(";", requestDto.Points),
                section.LanguageId,
                requestDto.FullTitle);

            section.Add(article);
            user.Add(article);
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
