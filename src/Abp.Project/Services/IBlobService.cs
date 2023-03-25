namespace Abp.Project.Services;

public interface IBlobService
{
    Task SaveAsync(string name, byte[] bytes, CancellationToken cancellationToken);
}