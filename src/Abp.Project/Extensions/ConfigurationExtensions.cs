namespace Abp.Project.Extensions;

public static class ConfigurationExtensions
{
    public static string GetMinioUrl(this IConfiguration configuration) 
        => configuration.GetValue("MINIO_URL", string.Empty);
    public static string GetMinioAccessKey(this IConfiguration configuration) 
        => configuration.GetValue("MINIO_ACCESS_KEY", string.Empty);
    public static string GetMinioSecretKey(this IConfiguration configuration) 
        => configuration.GetValue("MINIO_SECRET_KEY", string.Empty);
    public static string GetMinioBucketName(this IConfiguration configuration) 
        => configuration.GetValue("MINIO_BUCKET_NAME", string.Empty);
}