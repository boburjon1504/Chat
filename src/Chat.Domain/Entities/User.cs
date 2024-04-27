using Chat.Domain.Common.Auditable;

namespace Chat.Domain.Entities;
public class User : Entity
{
    public string FirstName { get; set; } = default!;

    public string? LastName { get; set; }

    public string UserName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
}
