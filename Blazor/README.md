## Projects

### BlazorHybridDemo1

Refactor Razor components from a MAUI Blazor project to a Razor Class Library project.

Watch the video: [Move Blazor components from MAUI project to Razor Class Library project](https://youtu.be/o58wieimmew)

### BlazorHybridDemo2

A Razor Class Library shared with a MAUI Blazor app and a Blazor Server app.

Watch the video: [Hello, Blazor Hybrid with NET MAUI](https://youtu.be/zZdhP4qTxTc)


## Troubleshooting

Should you see [NETSDK1147](https://learn.microsoft.com/en-us/dotnet/core/tools/sdk-errors/netsdk1147) error while build .NET projects, as below:

> NETSDK1147  To build this project, the following workloads must be installed: wasm-tools

You can try the following command to fix it:

```
dotnet workload install wasm-tools
```
