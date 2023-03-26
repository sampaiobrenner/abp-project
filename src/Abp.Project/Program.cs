using Abp.Project.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Host.AddAppSettingsSecretsJson().UseAutofac();
await builder.AddApplicationAsync<AppModule>();
        
var app = builder.Build();
await app.InitializeApplicationAsync();
await app.RunAsync();