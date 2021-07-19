﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface IUserRoleQueryService
    {
        UserRole GetUserRoleById(int id);
        List<UserRole> GetAllUserRoles();
        string[] GetRolesForUser(string Email);
    }
}
