using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.Base;

public class BaseEntity
{
    [Key] 
    public ulong Id { get; set; }
}