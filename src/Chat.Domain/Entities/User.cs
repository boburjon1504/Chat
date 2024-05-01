using Chat.Domain.Common.Auditable;
using System.ComponentModel.DataAnnotations;

namespace Chat.Domain.Entities;
public class User : Entity
{
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = default!;

    public string? LastName { get; set; }

    [Required(ErrorMessage = "Username is required")]

    public string UserName { get; set; } = default!;

    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = default!;

    public bool IsOnline { get; set; }
}
