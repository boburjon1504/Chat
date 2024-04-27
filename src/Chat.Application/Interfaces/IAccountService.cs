using Chat.Domain.Entities;

namespace Chat.Application.Interfaces;
public interface IAccountService
{
    ValueTask<bool> RegisterAsync(User user, CancellationToken cancellationToken = default);
    ValueTask<string> LoginAsync(User user, CancellationToken cancellationToken = default);
}
