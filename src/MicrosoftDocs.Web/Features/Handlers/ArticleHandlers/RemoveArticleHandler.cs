using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using MicrosoftDocs.Application.Specifications;
using MicrosoftDocs.Domain.Constants;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Commands.ArticleCommands;

namespace MicrosoftDocs.Web.Features.Handlers.ArticleHandlers;

public class RemoveArticleHandler : IRequestHandler<RemoveArticleCommand, object>
{
    private readonly IEfRepository<Article> _efRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;

    public RemoveArticleHandler(IEfRepository<Article> efRepository,
        IAuthorizationService authorizationService,
        IMapper mapper)
    {
        _efRepository = efRepository;
        _authorizationService = authorizationService;
        _mapper = mapper;
    }

    public async Task<object> Handle(RemoveArticleCommand request, CancellationToken cancellationToken)
    {
        var specification = new GetArticleWithContributorsSpecifications();
        var article = await _efRepository.GetByIdAsync(request.ArticleId, specification);

        var authResults = await _authorizationService.AuthorizeAsync(request.User, 
                                                                    article, 
                                                                    PoliciesConstants.ContributorEdit);

        if (!authResults.Succeeded)
        {
            return new ErrorModel("UnAuthorized", "Not allowed to make this action");
        }

        article.RemoveContributors(article.Contributors.ToArray());

        await _efRepository.DeleteAsync(request.ArticleId);
        await _efRepository.SaveChangesAsync();

        var dto = _mapper.Map<GetArticleDto>(article);
        return dto;
    }
}
