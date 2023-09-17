﻿using MediatR;

namespace BlazorSozluk.Api.Application.Features.Commands.EntryComment.DelateFav;

public class DeleteEntryCommentFavCommand : IRequest<bool>
{
    public Guid EntryCommentId { get; set; }
    public Guid UserId { get; set; }

    public DeleteEntryCommentFavCommand(Guid entryCommentId, Guid userId)
    {
        EntryCommentId = entryCommentId;
        UserId = userId;
    }
}