using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.AppUserAggregate;

public partial class AppUser
{
    protected AppUser() { }

    public AppUser(string userName,
        string email) : base(userName)
    {
        Email = email;
        CreationTime = DateTime.Now;
    }

}
