using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RoleMenecment.Services;

namespace RoleMenecment.Authorization;
public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IPermissionService _permissionService;

    public PermissionHandler(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var userRoles = context.User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();

        // DB-dən istifadəçinin rollarına aid permission-ları götür
        var permissions = await _permissionService.GetPermissionsByRolesAsync(userRoles);

        if (permissions.Contains(requirement.PermissionName))
        {
            context.Succeed(requirement);
        }
    }
}


