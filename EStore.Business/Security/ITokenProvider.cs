using EStore.Data.Models;

namespace EStore.Business.Security;

public interface ITokenProvider
{
    string GenerateToken(Member account, IEnumerable<string> roles);
}