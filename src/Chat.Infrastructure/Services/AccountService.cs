using Chat.Application.Interfaces;
using Chat.Domain.Entities;

namespace Chat.Infrastructure.Services;
public class AccountService(IUserService userService, ITokenGeneratorService tokenGeneratorService) : IAccountService
{
    public async ValueTask<bool> RegisterAsync(User user, CancellationToken cancellationToken = default)
    {
        var newUser = await userService.CreateAsync(user,true,cancellationToken);

        return newUser is not null;
    }
    public async ValueTask<string> LoginAsync(User user, CancellationToken cancellationToken = default)
    {
        var foundUser =await userService.GetByUserNameAsync(user.UserName);

        if(foundUser is null)
            throw new ArgumentException("There is no such user");


        return tokenGeneratorService.GenerateToken(foundUser);
    }
}
