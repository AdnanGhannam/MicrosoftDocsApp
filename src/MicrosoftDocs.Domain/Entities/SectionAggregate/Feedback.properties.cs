using MicrosoftDocs.Domain.Base;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Feedback : EntityBase
{
    /// <summary>
    /// Required
    /// Max length is 60
    /// </summary>
    public string Title { get; protected set; }

    /// <summary>
    /// Required
    /// </summary>
    public string Content { get; protected set; }


    public string ArticleId { get; protected set; }
    public Article Article { get; protected set; }


    public string UserId { get; protected set; }
    public AppUser User { get; protected set; }
}
