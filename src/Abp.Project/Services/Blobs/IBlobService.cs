namespace Abp.Project.Services.Blobs;

public interface IBlobService
{
    Task SaveAsync(string name, byte[] bytes, CancellationToken cancellationToken);
}