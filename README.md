# ISSUE: Cancellation token not aborting HC resolvers

Repro steps
- Restore nuget
- Run server
- Execute the requests in the Fetch.http one at a time and abort them. The ones using dataloaders does not abort processing. 
