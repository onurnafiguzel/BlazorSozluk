using BlazorSozluk.Common.ViewModels;

namespace BlazorSozluk.Api.Domain.Models;

public class EntryCommentVote : BaseEntity
{
    public Guid EntryCommentId { get; set; }

    public Enums VoteType { get; set; }

    public Guid CreatedById { get; set; }

    public virtual EntryComment EntryComment { get; set; }
}
