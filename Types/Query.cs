using Serilog;

namespace HCBugCancellationToken.Types;

[QueryType]
public static class Query
{
    public static async Task<string> Foo(CancellationToken cancellationToken)
    {
        try
        {
            Log.Information("This can take some while..");
            await Task.Delay(30_000, cancellationToken);
            Log.Information("Waiting done! Time to return result");
            return DateTime.Now.ToShortTimeString();
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
