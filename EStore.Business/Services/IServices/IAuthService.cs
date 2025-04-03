using EStore.Business.DTOs;
using EStore.Business.Security;

namespace EStore.Business.Services.IServices;

public interface IAuthService
{
    Task<AccessToken> LoginAsync(LoginRequestDTO loginRequestDTO);
    Task<AccessToken> AdminLogin(LoginRequestDTO loginRequestDTO);
}