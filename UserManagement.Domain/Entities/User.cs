using System.ComponentModel.DataAnnotations;
using UserManagement.Domain.Base;

namespace UserManagement.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public RoleType Role { get; set; }

    public ICollection<UserPermission> Permissions { get; set; } = new List<UserPermission>();
}