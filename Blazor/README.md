Should you see the following error message while build .NET projects:

> NETSDK1147  To build this project, the following workloads must be installed: wasm-tools

You can try the following command to fix it:

```
dotnet workload install wasm-tools
```

See also: [NETSDK1147: Missing workload for specified target framework](https://learn.microsoft.com/en-us/dotnet/core/tools/sdk-errors/netsdk1147)