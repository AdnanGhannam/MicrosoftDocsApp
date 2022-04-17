using MediatR;
using MicrosoftDocs.Shared.Models.UserModels;

namespace MicrosoftDocs.Web.Features.Queries.UserQueries;

public record GetMyInformationsQuery(string UserId) : IRequest<GetMyInformationsDto>;
