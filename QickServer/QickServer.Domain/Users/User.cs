using QickServer.Domain.Shared;

namespace QickServer.Domain.Users;
public sealed class User : Entity
{
    private User() { }
    public User(UserName userName, Password password)
    {
        UserName = userName;
        Password = password;
    }
    public UserName UserName { get; private set; } = default!;
    public Password Password { get; private set; } = default!;
}
