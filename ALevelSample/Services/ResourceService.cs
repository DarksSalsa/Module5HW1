using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ALevelSample.Config;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Responses;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ALevelSample.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<ResourceService> _logger;
        private readonly ApiOption _options;
        private readonly PathingOption _pathingOptions;
        private readonly string _resourceApi = "api/unknown";

        public ResourceService(
            IInternalHttpClientService httpClientService,
            ILogger<ResourceService> logger,
            IOptions<ApiOption> options,
            IOptions<PathingOption> pathingOptions)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
            _pathingOptions = pathingOptions.Value;
        }

        public async Task<ResourceDto> GetResourceById(int id, int delay = 0)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<ResourceDto>, object>(
                $"{_options.Host}{_resourceApi}/{id}{_pathingOptions.ParamsStartMark}{_pathingOptions.PageDelay}{delay}",
                HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Resource with id = {result.Data.Id} was found.");
            }

            return result?.Data;
        }

        public async Task<BaseListResponse<ResourceDto>> GetResourcePage(int delay = 0)
        {
            var result = await _httpClientService.SendAsync<BaseListResponse<ResourceDto>, object>(
                $"{_options.Host}{_resourceApi}{_pathingOptions.ParamsStartMark}{_pathingOptions.PageDelay}{delay}",
                HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Resource page was found!");
                _logger.LogInformation($"Vital information above data: {result.Page}, {result.PerPage}, {result.Total}, {result.TotalPages}");
            }

            return result;
        }
    }
}
