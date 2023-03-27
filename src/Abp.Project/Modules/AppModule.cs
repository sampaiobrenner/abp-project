using Abp.Project.Modules.Extensions;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.Minio;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace Abp.Project.Modules;

[DependsOn(typeof(AbpAspNetCoreMvcModule))] // Adiciona a dependência do MVC
[DependsOn(typeof(AbpAutofacModule))] // Adiciona a dependência do AutoFac
[DependsOn(typeof(AbpSwashbuckleModule))] // Adiciona a dependência do Swagger
[DependsOn(typeof(AbpBlobStoringMinioModule))] // Adiciona a dependência do Minio
[DependsOn(typeof(AbpEventBusRabbitMqModule))] // Adiciona a dependência do RabbitMQ
[DependsOn(typeof(AbpCachingStackExchangeRedisModule))] // Adiciona a dependência do Redis
[DependsOn(typeof(AbpEntityFrameworkCoreModule))] // Adiciona a dependência do EF
[DependsOn(typeof(AbpEntityFrameworkCorePostgreSqlModule))] // Adiciona a dependência do PostgreSql
public class AppModule : AbpModule
{
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment()) 
            app.UseDeveloperExceptionPage();

        app.UseStaticFiles();
        app.UseRouting();
        app.UseUnitOfWork();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Abp.Project"); });
        app.UseConfiguredEndpoints();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        ConfigureSwagger(context.Services);
        ConfigureMinio(configuration);
        ConfigurePostgreSql();
    }

    private static void ConfigureSwagger(IServiceCollection services)
    {
        services.AddAbpSwaggerGen(
            options =>
            {
                options.HideAbpEndpoints();
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Abp.Project", Version = "v1" });
                options.DocInclusionPredicate((_, _) => true);
                options.CustomSchemaIds(type => type.FullName);
            }
        );
    }
    
    private void ConfigureMinio(IConfiguration configuration)
    {
        Configure<AbpBlobStoringOptions>(options =>
        {
            options.Containers.ConfigureDefault(container =>
            {
                container.UseMinio(minio =>
                {
                    minio.CreateBucketIfNotExists = true;
                    minio.EndPoint = configuration.GetMinioUrl();
                    minio.AccessKey = configuration.GetMinioAccessKey();
                    minio.SecretKey = configuration.GetMinioSecretKey();
                    minio.BucketName = configuration.GetMinioBucketName();
                });
            });
        });
    }
    
    private void ConfigurePostgreSql()
    {
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseNpgsql();
        });
    }
}