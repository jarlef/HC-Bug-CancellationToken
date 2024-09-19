using HCBugCancellationToken.Services;

namespace HCBugCancellationToken.Types.DataLoaders;

public class MovieRatingDataLoaderClassic(IBatchScheduler batchScheduler, DataLoaderOptions? options = null)
    : BatchDataLoader<int, int>(batchScheduler, options)
{
    protected override async Task<IReadOnlyDictionary<int, int>> LoadBatchAsync(IReadOnlyList<int> movieIds, CancellationToken cancellationToken)
    {
        var rating = await RatingService.GetRating(cancellationToken);
        return movieIds.ToDictionary(id => id, _ => rating);
    }
}