using BlazorSozluk.Common.ViewModels;
public class VoteService : IVoteService
{
    private readonly HttpClient client;

    public VoteService(HttpClient client)
    {
        this.client = client;
    }

    public async Task DeleteEntryVote(Guid entryId)
    {
        var response = await client.PostAsync($"/api/Vote/DeleteEntryVote/{entryId}", null);

        if (!response.IsSuccessStatusCode)
            throw new Exception("DeleteEntryVote error");
    }

    public async Task DeleteEntryCommentVote(Guid entryCommentId)
    {
        var response = await client.PostAsync($"/api/Vote/DeleteEntryCommentVote/{entryCommentId}", null);

        if (!response.IsSuccessStatusCode)
            throw new Exception("DeleteEntryCommentVote error");
    }

    public async Task CreateEntryUpVote(Guid entryId)
    {
        await CreateEntryVote(entryId, Enums.UpVote);
    }

    public async Task CreateEntryDownVote(Guid entryCommentId)
    {
        await CreateEntryVote(entryCommentId, Enums.DownVote);
    }

    public async Task CreateEntryCommentUpVote(Guid entryCommentId)
    {
        await CreateEntryCommentVote(entryCommentId, Enums.UpVote);
    }

    public async Task CreateEntryCommentDownVote(Guid entryCommentId)
    {
        await CreateEntryCommentVote(entryCommentId, Enums.DownVote);
    }


    private async Task<HttpResponseMessage> CreateEntryVote(Guid entryId, Enums voteType = Enums.UpVote)
    {
        var result = await client.PostAsync($"/api/vote/entry/{entryId}?voteType={voteType}", null);
        // TODO Check success code
        return result;
    }

    private async Task<HttpResponseMessage> CreateEntryCommentVote(Guid entryCommentId, Enums voteType = Enums.UpVote)
    {
        var result = await client.PostAsync($"/api/vote/entrycomment/{entryCommentId}?voteType={voteType}", null);
        // TODO Check success code
        return result;
    }
}