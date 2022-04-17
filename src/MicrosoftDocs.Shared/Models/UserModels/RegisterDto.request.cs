using MicrosoftDocs.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace MicrosoftDocs.Shared.Models.UserModels;

public record RegisterDto(
    [Required, 
        StringLength(EntitiesConstants.MaxUserNameLength, MinimumLength = EntitiesConstants.MinUserNameLength)
        ] string UserName, 
    [Required, 
        StringLength(EntitiesConstants.MaxEmailLength, MinimumLength = EntitiesConstants.MinEmailLength),
        EmailAddress
        ] string Email, 
    [Required, 
        StringLength(EntitiesConstants.MaxPasswordLength, MinimumLength = EntitiesConstants.MinPasswordLength) 
        ] string Password);
