## Projects

- BlazorHybridDemo1: Refactor Razor components from a MAUI Blazor project to a Razor Class Library project.
- BlazorHybridDemo2: A Razor Class Library shared with a MAUI Blazor app and a Blazor Server app.



## Troubleshooting

Should you see [NETSDK1147](https://learn.microsoft.com/en-us/dotnet/core/tools/sdk-errors/netsdk1147) error while build .NET projects, as below:

> NETSDK1147  To build this project, the following workloads must be installed: wasm-tools

You can try the following command to fix it:

```
dotnet workload install wasm-tools
```
