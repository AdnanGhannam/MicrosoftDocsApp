using MicrosoftDocs.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Feedback : EntityBase
{
    public string Title { get; protected set; }

    public string Content { get; protected set; }


    public string ArticleId { get; protected set; }
    public Article Article { get; protected set; }


    public string UserId { get; protected set; }
    public AppUser User { get; protected set; }
}
