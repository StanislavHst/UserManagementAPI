using UserManagement.Domain.Base;

namespace UserManagement.Domain.Entities;

public class UserPermission : BaseEntity
{
    public ulong UserId { get; set; }
    public User User { get; set; }

    public ulong PermissionId { get; set; }
    public Permission Permission { get; set; }
}