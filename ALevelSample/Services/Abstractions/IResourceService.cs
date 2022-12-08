using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Responses;

namespace ALevelSample.Services.Abstractions
{
    public interface IResourceService
    {
        Task<ResourceDto> GetResourceById(int id, int delay = 0);
        Task<BaseListResponse<ResourceDto>> GetResourcePage(int delay = 0);
    }
}
