using BlazorSozluk.Common.ViewModels;

namespace BlazorSozluk.Common.Events.EntryComment;

public class CreateEntryCommentVoteEvent
{
    public Guid EntryCommentId { get; set; }

    public Enums VoteType { get; set; }

    public Guid CreatedBy { get; set; }
}
