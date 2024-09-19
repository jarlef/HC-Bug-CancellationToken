using HCBugCancellationToken.Models;
using HCBugCancellationToken.Services;
using HCBugCancellationToken.Types.DataLoaders;
using Serilog;

namespace HCBugCancellationToken.Types.Resolvers;

[ExtendObjectType<Movie>]
public class MovieResolver
{
    /// <summary>
    /// Cancellation token works with plain async resolver (works)
    /// </summary>
    public async Task<int> GetRating([Parent] Movie movie, CancellationToken cancellationToken)
    {
        Log.Information($"Fetching rating for {movie.Id}");
        var rating = await RatingService.GetRating(cancellationToken);  
        Log.Information($"Rating for {movie.Id}: {rating}");
        return rating;
    }
    
    /// <summary>
    /// Cancellation token with data loaders using [DataLoader] annotation (does not work)
    /// </summary>
    public async Task<int> GetRatingWithDL([Parent] Movie movie, IMovieRatingDataLoader movieRatingDataLoader, CancellationToken cancellationToken)
    {
        Log.Information($"Fetching rating for {movie.Id}");
        var rating = await movieRatingDataLoader.LoadAsync(movie.Id, cancellationToken);
        Log.Information($"Rating for {movie.Id}: {rating}");
        return rating;
    }
    
    /// <summary>
    /// Cancellation token with data loaders using class based dataloader (does not work)
    /// </summary>
    public async Task<int> GetRatingWithDL2([Parent] Movie movie, MovieRatingDataLoaderClassic movieRatingDataLoader, CancellationToken cancellationToken)
    {
        Log.Information($"Fetching rating for {movie.Id}");
        var rating = await movieRatingDataLoader.LoadAsync(movie.Id, cancellationToken);
        Log.Information($"Rating for {movie.Id}: {rating}");
        return rating;

    }
}