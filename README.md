# ISSUE: Cancellation token not aborting HC resolvers

Repro steps
- Restore nuget
- Run server
- Execute the foo resolver in BananaCakePop. Foo resolver has a await delay of 30 seconds
- Click abort in BananaCakePop immediately 
- Observe the resolver is still executing and the finally block is called after 30 seconds without any OperationCanceledException being thrown

Additional observation
The built in minimal api is able to abort the thread as it should. E.g executing the Foo.http and clicking abort.