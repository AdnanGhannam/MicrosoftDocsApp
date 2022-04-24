using MediatR;

namespace MicrosoftDocs.Web.Features.Queries.UserQueries;

public record GetMyCollectionsQuery(string UserId) : IRequest<object?>;
