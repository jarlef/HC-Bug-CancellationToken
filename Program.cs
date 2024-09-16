using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

builder.Services.AddGraphQLServer().AddTypes();

var app = builder.Build();

app.MapGet("/foo", async (CancellationToken cancellationToken) =>
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
        // OperationCanceledException is getting thrown as it should
        Log.Error("Something happened");
        throw;
    }
    finally
    {
        Log.Information("Finally done");
    }
});

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
