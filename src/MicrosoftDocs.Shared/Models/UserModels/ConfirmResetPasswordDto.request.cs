using MicrosoftDocs.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace MicrosoftDocs.Shared.Models.UserModels;

public record ConfirmResetPasswordDto(
    [Required,
        StringLength(EntitiesConstants.MaxUserNameLength, MinimumLength = EntitiesConstants.MinUserNameLength)
    ] string UserName,
    [Required] string Token, 
    [Required, 
        StringLength(EntitiesConstants.MaxPasswordLength, MinimumLength = EntitiesConstants.MinPasswordLength)
    ] string NewPassword);
