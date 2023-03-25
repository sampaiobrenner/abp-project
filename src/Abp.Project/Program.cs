namespace Abp.Project;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Host.AddAppSettingsSecretsJson().UseAutofac();
        await builder.AddApplicationAsync<AppModule>();
        
        var app = builder.Build();
        await app.InitializeApplicationAsync();
        await app.RunAsync();
    }
}