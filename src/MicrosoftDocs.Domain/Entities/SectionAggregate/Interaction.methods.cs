using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Interaction
{
    protected Interaction() { }

    public Interaction(string interactorId,
        string articleId,
        InteractionTypes interactionType)
    {
        InteractorId = interactorId;
        ArticleId = articleId;
        InteractionType = interactionType;
    }

    public Interaction(AppUser interactor,
        Article article,
        InteractionTypes interactionType)
        : this(interactor.Id, article.Id, interactionType) { }
}
