using EStore.Business.DTOs;
using EStore.Business.Exceptions;
using EStore.Business.Security;
using EStore.Business.Services.IServices;
using EStore.Data.Models;
using EStore.Data.Repositories;

namespace EStore.Business.Services;

public class AuthService(
    IMemberRepository memberRepository,
    ITokenProvider tokenProvider
): IAuthService
{
    
    public async Task<AccessToken> LoginAsync(LoginRequestDTO loginRequestDTO)
    {
        var normalizedEmail = loginRequestDTO.Email!.Trim().ToLower();
        
        Member? member = await memberRepository.GetMemberByEmail(normalizedEmail);

        if (member == null)
        {
            throw new UserNotFoundException();
        }

        if (loginRequestDTO.Password != member.Password)
        {
            throw new InvalidPasswordException("Verify password is incorrect");
        }

        string token = tokenProvider.GenerateToken(member, ["Member"]);
        return new AccessToken { Token = token };
    }

    public Task<AccessToken> AdminLogin(LoginRequestDTO loginRequestDTO)
    {
        if (loginRequestDTO.Email == null)
        {
            throw new UserNotFoundException("Admin email is required");
        }
        
        var admin = new Member
        {
            Email = loginRequestDTO.Email,
            Password = loginRequestDTO.Password
        };
        
        string token = tokenProvider.GenerateToken(admin, ["Admin"]);
        return Task.FromResult(new AccessToken { Token = token });
    }
}