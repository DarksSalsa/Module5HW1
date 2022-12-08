using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Responses;

namespace ALevelSample.Services.Abstractions;

public interface IUserService
{
    Task<BaseListResponse<UserDto>> GetListOfUsersById(int pageId = 0, int delay = 0);
    Task<UserDto> GetUserById(int id, int delay = 0);
    Task<UserResponse> CreateUser(string name, string job, int delay = 0);
    Task<UserUpdateAndPatchResponse> PutUser(int id, string name, string job, int delay = 0);
    Task<UserUpdateAndPatchResponse> PatchUser(int id, string name, string job, int delay = 0);
    Task DeleteUser(int id, int delay = 0);
}