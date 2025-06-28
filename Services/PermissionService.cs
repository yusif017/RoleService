using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoleMenecment.Data;

namespace RoleMenecment.Services;
public class PermissionService : IPermissionService
{
    private readonly AppDbContext _context;

    public PermissionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<string>> GetPermissionsByRolesAsync(List<string> roleNames)
    {
        var permissions = await _context.RolePermissions
            .Where(rp => roleNames.Contains(rp.Role.Name))
            .Select(rp => rp.PermissionName)
            .ToListAsync();

        return permissions;
    }
}
