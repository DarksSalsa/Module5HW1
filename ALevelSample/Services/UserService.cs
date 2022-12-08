using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ALevelSample.Config;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Requests;
using ALevelSample.Dtos.Responses;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ALevelSample.Services;

public class UserService : IUserService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<UserService> _logger;
    private readonly ApiOption _options;
    private readonly PathingOption _pathingOptions;
    private readonly string _userApi = "api/users";

    public UserService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        IOptions<PathingOption> pathingOptions,
        ILogger<UserService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
        _pathingOptions = pathingOptions.Value;
    }

    public async Task<UserDto> GetUserById(int id, int delay = 0)
    {
        var result = await _httpClientService.SendAsync<BaseResponse<UserDto>, object>(
            $"{_options.Host}{_userApi}/{id}{_pathingOptions.ParamsStartMark}{_pathingOptions.PageDelay}{delay}",
            HttpMethod.Get);

        if (result?.Data != null)
        {
            _logger.LogInformation($"User with id = {result.Data.Id} was found");
        }

        return result?.Data;
    }

    public async Task<BaseListResponse<UserDto>> GetListOfUsersById(int pageId = 1, int delay = 0)
    {
        var result = await _httpClientService.SendAsync<BaseListResponse<UserDto>, object>(
            $"{_options.Host}{_userApi}{_pathingOptions.ParamsStartMark}{_pathingOptions.PageNumber}{pageId}{_pathingOptions.ParamsAndMark}{_pathingOptions.PageDelay}{delay}",
            HttpMethod.Get);

        if (result?.Data != null)
        {
            _logger.LogInformation($"Page with id = {pageId} was found");
            _logger.LogInformation($"Vital information above data: {result.Page}, {result.PerPage}, {result.Total}, {result.TotalPages}");
        }

        return result;
    }

    public async Task<UserResponse> CreateUser(string name, string job, int delay = 0)
    {
        var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
            $"{_options.Host}{_userApi}{_pathingOptions.ParamsStartMark}{_pathingOptions.PageDelay}{delay}",
            HttpMethod.Post,
            new UserRequest()
            {
                Job = job,
                Name = name
            });

        if (result != null)
        {
            _logger.LogInformation($"User with id = {result?.Id} was created");
        }

        return result;
    }

    public async Task<UserUpdateAndPatchResponse> PutUser(int id, string name, string job, int delay = 0)
    {
        var result = await _httpClientService.SendAsync<UserUpdateAndPatchResponse, UserRequest>(
            $"{_options.Host}{_userApi}/{id}{_pathingOptions.ParamsStartMark}{_pathingOptions.PageDelay}{delay}",
            HttpMethod.Put,
            new UserRequest()
            {
                Job = job,
                Name = name
            });

        if (result != null)
        {
            _logger.LogInformation($"This is Put method: User's name is {result.Name} and his job is {result.Job}");
            _logger.LogInformation($"Update was conducted at {result.UpdatedAt}");
        }

        return result;
    }

    public async Task<UserUpdateAndPatchResponse> PatchUser(int id, string name, string job, int delay = 0)
    {
        var result = await _httpClientService.SendAsync<UserUpdateAndPatchResponse, UserRequest>(
            $"{_options.Host}{_userApi}/{id}{_pathingOptions.ParamsStartMark}{_pathingOptions.PageDelay}{delay}",
            HttpMethod.Put,
            new UserRequest()
            {
                Job = job,
                Name = name
            });

        if (result != null)
        {
            _logger.LogInformation($"This is Patch method: User's name is {result.Name} and his job is {result.Job}");
            _logger.LogInformation($"Update was conducted at {result.UpdatedAt}");
        }

        return result;
    }

    public async Task DeleteUser(int id, int delay = 0)
    {
        await _httpClientService.SendAsync<object, object>(
            $"{_options.Host}{_userApi}/{id}{_pathingOptions.ParamsStartMark}{_pathingOptions.PageDelay}{delay}",
            HttpMethod.Delete);
        _logger.LogInformation($"User with id = {id} was deleted");
    }
}