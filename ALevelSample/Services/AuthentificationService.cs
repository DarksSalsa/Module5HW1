using System.Net.Http;
using System.Threading.Tasks;
using ALevelSample.Config;
using ALevelSample.Dtos.Requests;
using ALevelSample.Dtos.Responses;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ALevelSample.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ApiOption _options;
        private readonly ILogger<AuthentificationService> _logger;
        private readonly string _registerApi = "api/register";
        private readonly string _loginApi = "api/login";

        public AuthentificationService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOption> options,
            ILogger<AuthentificationService> logger)
        {
            _httpClientService = httpClientService;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<LoginResponse> Login(string email, string password)
        {
            var result = await _httpClientService.SendAsync<LoginResponse, RegisterAndLoginRequest>(
                $"{_options.Host}{_loginApi}",
                HttpMethod.Post,
                new RegisterAndLoginRequest()
                {
                    Email = email,
                    Password = password,
                });

            if (result.Error == null)
            {
                _logger.LogInformation("User was successfully created");
            }
            else
            {
                _logger.LogInformation($"Operation has failed with this error: {result.Error}");
            }

            return result;
        }

        public async Task<RegisterResponse> Register(string email, string password)
        {
            var result = await _httpClientService.SendAsync<RegisterResponse, RegisterAndLoginRequest>(
                $"{_options.Host}{_registerApi}",
                HttpMethod.Post,
                new RegisterAndLoginRequest()
                {
                    Email = email,
                    Password = password
                });

            if (result.Error == null)
            {
                _logger.LogInformation("User was successfully created");
            }
            else
            {
                _logger.LogInformation($"Operation has failed with this error: {result.Error}");
            }

            return result;
        }
    }
}
