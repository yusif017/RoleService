using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleMenecment.Models;
  public class RolePermission
{
    public Guid Id { get; set; }

    public Guid RoleId { get; set; }
    public Role Role { get; set; }

    public string PermissionName { get; set; } = null!;
}


