using Chat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces;
public interface IUserService
{
    IQueryable<User> Get();
    ValueTask<IList<User>> GetAsync(CancellationToken cancellationToken);

    ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<User?> GetByEmailAsync(string userName, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
}
