using MediatR;

namespace BlazorSozluk.Api.Application.Features.Commands.Entry.CreateFav;

public class CreateEntryCommentFavCommand : IRequest<bool>
{
    public Guid EntryCommentId { get; set; }
    public Guid UserId { get; set; }

    public CreateEntryCommentFavCommand(Guid entryCommentId, Guid userId)
    {
        EntryCommentId = entryCommentId;
        UserId = userId;
    }
}
