using BlazorSozluk.Common.ViewModels;

namespace BlazorSozluk.Common.Events.Entry;

public class CreateEntryVoteEvent
{
    public Guid EntryId { get; set; }

    public Enums VoteType { get; set; }

    public Guid CreatedBy { get; set; }
}