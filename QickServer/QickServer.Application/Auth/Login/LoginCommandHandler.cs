using MediatR;
using MFA.Result;
using QickServer.Application.Services;
using QickServer.Domain.Users;

namespace QickServer.Application.Auth.Login;

internal sealed class LoginCommandHandler(
    IUserRepository userRepository,
    IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        UserName userName = new(request.UserName);
        Password password = new(request.Password);

        User? user = await userRepository.GetByUserNameAndPasswordAsync(userName, password, cancellationToken);
        if (user is null) 
        {
            return Result<string>.Failure("User not found");
        }

        return jwtProvider.CreateToken(user);
    }
}
