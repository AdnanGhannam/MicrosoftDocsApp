using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Shared.Models.UserModels;

public record LoginDto([Required] string UserName, [Required] string Password, bool IsPersistence);
