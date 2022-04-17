using MicrosoftDocs.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Shared.Models.UserModels;

public record VerifyEmailDto(
    [Required,
        StringLength(EntitiesConstants.MaxEmailLength, MinimumLength = EntitiesConstants.MinEmailLength),
        EmailAddress
        ] string Email, 
    [Required] string Code);
