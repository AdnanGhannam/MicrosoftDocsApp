using MicrosoftDocs.Domain.Base;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Interaction : EntityBase
{
    public InteractionTypes InteractionType { get; protected set; }


    public string InteractorId { get; protected set; }
    public AppUser Interactor { get; protected set; }

    
    public string ArticleId { get; protected set; }
    public Article Article { get; protected set; }
}
