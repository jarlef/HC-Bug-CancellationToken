using HCBugCancellationToken.Services;

namespace HCBugCancellationToken.Types.DataLoaders;

internal static class MovieRatingDataLoaderAnnotated
{
    [DataLoader]
    internal static async Task<IReadOnlyDictionary<int, int>> GetMovieRating(
        IReadOnlyList<int> movieIds,
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var rating = await RatingService.GetRating(cancellationToken);
        return movieIds.ToDictionary(id => id, _ => rating);
    }

}