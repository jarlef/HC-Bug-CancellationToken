using HCBugCancellationToken.Models;
using Serilog;

namespace HCBugCancellationToken.Types;

[QueryType]
public static class Query
{
    public static Movie[] GetMovies()
    {
        return
        [
            new Movie() {Id = 1, Name = "Terminator 1"},
            new Movie() {Id = 2, Name = "Terminator 2"},
            new Movie() {Id = 3, Name = "Shaun the Sheep"}
        ];
    }
    
    
}
