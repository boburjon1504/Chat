using Chat.Domain.Entities;
using System.Reflection.Metadata;

namespace Chat.Application.Interfaces;
public interface ITokenGeneratorService
{
    string GenerateToken(User user);
}
