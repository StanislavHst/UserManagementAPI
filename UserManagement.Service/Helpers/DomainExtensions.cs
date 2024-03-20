using UserManagement.Domain.Base;

namespace UserManagement.Service.Helpers.Startup;

public static class DomainExtensions
{
    public static bool IsNullOrDefault(this BaseEntity? domain)
    {
        return domain == null || domain.Id == default;
    }
}