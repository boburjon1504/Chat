using Chat.Application.Common.Helpers;
using Chat.Application.Interfaces;
using Chat.Domain.Entities;

namespace Chat.Infrastructure.Services;
public class AccountService(IUserService userService, ITokenGeneratorService tokenGeneratorService,IPasswordHasher passwordHasher) : IAccountService
{
    public async ValueTask<bool> RegisterAsync(User user, CancellationToken cancellationToken = default)
    {
        user.Password = passwordHasher.Hash(user.Password);
        var newUser = await userService.CreateAsync(user,true,cancellationToken);

        return newUser is not null;
    }
    public async ValueTask<string> LoginAsync(User user, CancellationToken cancellationToken = default)
    {
        var foundUser =await userService.GetByUserNameAsync(user.UserName);

        if(foundUser is null)
            throw new ArgumentException("Username or password is wrong");

        if (!passwordHasher.Verify(user.Password, foundUser.Password))
            throw new ArgumentException("Username or password is wrong");

        return tokenGeneratorService.GenerateToken(foundUser);
    }
}
