using MediatR;
using System.Security.Claims;

namespace MicrosoftDocs.Web.Features.Queries.UserQueries;

public record GetCollectionByIdQuery(string UserId, string collectionName) : IRequest<object>;
