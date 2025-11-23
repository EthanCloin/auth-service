var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AuthService_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");


var webFrontend = builder.AddViteApp("auth-frontend", workingDirectory: "../auth-frontend")
    .WithReference(apiService)
    .WaitFor(apiService)
    .WithNpmPackageInstallation();

builder.Build().Run();
