using Microsoft.AspNetCore.Authorization;

namespace RoleMenecment.Authorization;
public class PermissionRequirement : IAuthorizationRequirement
{
    public string PermissionName { get; }
    public PermissionRequirement(string permissionName)
    {
        PermissionName = permissionName;
    }
}


