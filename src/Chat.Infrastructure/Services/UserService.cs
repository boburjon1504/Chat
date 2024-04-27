using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Chat.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Services;
public class UserService(IUserRepository userRepository) : IUserService
{
    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<IList<User>> GetAsync(CancellationToken cancellationToken)
    {
        return await userRepository.Get().ToListAsync(cancellationToken);
    }

    public async ValueTask<User?> GetByEmailAsync(string userName, CancellationToken cancellationToken = default)
    {
        return await userRepository.Get().FirstOrDefaultAsync(u => u.Email.Equals(userName));
    }

    public ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return userRepository.GetByIdAsync(id,true,cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.UpdateAsync(user,saveChanges,cancellationToken);
    }
}
