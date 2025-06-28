using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleMenecment.Services;
public interface IPermissionService
{
    Task<List<string>> GetPermissionsByRolesAsync(List<string> roleNames);
}
