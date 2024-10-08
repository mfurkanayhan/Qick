using QickServer.Domain.Users;

namespace QickServer.Application.Services;
public interface IJwtProvider
{
    string CreateToken(User user);
}
