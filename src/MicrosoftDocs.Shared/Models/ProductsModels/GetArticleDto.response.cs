using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Enums;
using MicrosoftDocs.Shared.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Shared.Models.ProductsModels;

public class GetArticleDto
{
    // For AutoMapper
    public GetArticleDto() { }

    public GetArticleDto(string id, 
        string fullTitle, 
        TimeSpan readingTime, 
        int readTimes, 
        string content, 
        List<string> points,
        bool isApi, 
        ContentAreas contentAreas,
        List<GetUserDto> contributors)
    {
        Id = id;
        FullTitle = fullTitle;
        ReadingTime = readingTime;
        ReadTimes = readTimes;
        Content = content;
        Contributors = contributors;
        IsApi = isApi;
        ContentAreas = contentAreas;
        Points = points;
    }

    public string Id { get; set; }
    public string FullTitle { get; set; }
    public TimeSpan ReadingTime { get; set; }
    public int ReadTimes { get; set; }
    public string Content { get; set; }
    public List<GetUserDto> Contributors { get; set; }
    public bool IsApi { get; set; }
    public ContentAreas ContentAreas { get; set; }
    public List<string> Points { get; set; }
}
