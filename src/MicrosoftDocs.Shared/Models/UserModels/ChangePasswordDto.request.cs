using MicrosoftDocs.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace MicrosoftDocs.Shared.Models.UserModels;

public record ChangePasswordDto(
    [Required, 
        StringLength(EntitiesConstants.MaxUserNameLength, MinimumLength = EntitiesConstants.MinUserNameLength)
    ] string UserName, 
    [Required, 
        StringLength(EntitiesConstants.MaxPasswordLength, MinimumLength = EntitiesConstants.MaxPasswordLength)
    ] string OldPassword,
    [Required, 
        StringLength(EntitiesConstants.MaxPasswordLength, MinimumLength = EntitiesConstants.MaxPasswordLength)
    ] string NewPassword);
