using System.ComponentModel.DataAnnotations;
using UserManagement.Domain.Base;

namespace UserManagement.Domain.Entities;

public class Permission : BaseEntity
{
    public string Name { get; set; }

    public ICollection<UserPermission> Users { get; set; } = new List<UserPermission>();
}