using Chat.Application.Common.Helpers;
using BC = BCrypt.Net.BCrypt;
namespace Chat.Infrastructure.Common.Helpers;
public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password) => BC.HashPassword(password);

    public bool Verify(string password, string passwordHash) => BC.Verify(password, passwordHash);
}
