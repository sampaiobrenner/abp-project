using Volo.Abp.BlobStoring;
using Volo.Abp.DependencyInjection;

namespace Abp.Project.Services.Blobs;

public class BlobService : IBlobService, IScopedDependency
{
    private readonly IBlobContainer _blobContainer;

    public BlobService(IBlobContainer blobContainer)
    {
        _blobContainer = blobContainer;
    }

    public async Task SaveAsync(string name, byte[] bytes, CancellationToken cancellationToken)
    {
        await _blobContainer.SaveAsync(name, bytes, false, cancellationToken);
    }
}