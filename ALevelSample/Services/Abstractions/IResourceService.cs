using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Dtos;

namespace ALevelSample.Services.Abstractions
{
    public interface IResourceService
    {
        Task<ResourceDto> GetResourceById(int id);
        Task<IReadOnlyList<ResourceDto>> GetResourcePage();
    }
}
