using MicrosoftDocs.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace MicrosoftDocs.Shared.Models.UserModels;

public record ChangePasswordDto(
    [Required, 
        StringLength(EntitiesConstants.MaxPasswordLength, MinimumLength = EntitiesConstants.MinPasswordLength)
    ] string OldPassword,
    [Required, 
        StringLength(EntitiesConstants.MaxPasswordLength, MinimumLength = EntitiesConstants.MinPasswordLength)
    ] string NewPassword);
