using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Responses;

namespace ALevelSample.Services.Abstractions;

public interface IUserService
{
    Task<IReadOnlyList<UserDto>> GetListOfUsersById(int pageId);
    Task<IReadOnlyList<UserDto>> GetListOfUsersByIdWithDelay(int pageId = 1, int delay = 0);
    Task<UserDto> GetUserById(int id);
    Task<UserResponse> CreateUser(string name, string job);
    Task<UserUpdateAndPatchResponse> PutUser(int id, string name, string job);
    Task<UserUpdateAndPatchResponse> PatchUser(int id, string name, string job);
    Task DeleteUser(int id);
}