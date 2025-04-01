using EStore.Business.DTOs;
using EStore.Business.Security;

namespace EStore.Business.Service.IService;

public interface IAuthService
{
    Task<AccessToken> LoginAsync(LoginRequestDTO loginRequestDTO);
    Task<AccessToken> AdminLogin(LoginRequestDTO loginRequestDTO);
}