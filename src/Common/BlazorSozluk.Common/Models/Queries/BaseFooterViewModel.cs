using BlazorSozluk.Common.ViewModels;

namespace BlazorSozluk.Common.Models.Queries;

public class BaseFooterRateViewModel
{
    public Enums VoteType { get; set; }
}

public class BaseFooterFavoritedViewModel
{
    public bool IsFavorited { get; set; }
    public int FavoritedCount { get; set; }
}
public class BaseFooterRateFavoritedViewModel : BaseFooterFavoritedViewModel
{
    public Enums VoteType { get; set; }

}
