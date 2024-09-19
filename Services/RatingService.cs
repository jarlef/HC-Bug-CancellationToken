using Serilog;

namespace HCBugCancellationToken.Services;

public class RatingService
{
    public static async Task<int> GetRating(CancellationToken cancellationToken)
    {
        try
        {
            Log.Information("This can take some while..");
            await Task.Delay(15_000, cancellationToken);
            Log.Information("Waiting done! Time to return result");
            return Random.Shared.Next(1, 10);
        }
        catch (OperationCanceledException)
        {
            // OperationCanceledException is never getting thrown
            Log.Error("Something happened");
            throw;
        }
        finally
        {
            Log.Information("Finally done");
        }
    }
}