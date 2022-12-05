using System.Threading.Tasks;
using ALevelSample.Dtos.Responses;

namespace ALevelSample.Services.Abstractions
{
    public interface IAuthentificationService
    {
        Task<RegisterResponse> Register(string email, string password = null);
        Task<LoginResponse> Login(string email, string password = null);
    }
}
