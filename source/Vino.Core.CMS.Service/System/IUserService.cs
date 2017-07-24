﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vino.Core.CMS.Core.DependencyResolver;
using Vino.Core.CMS.Domain.Dto.System;

namespace Vino.Core.CMS.Service.System
{
    public interface IUserService
    {
        Task<(int count, List<UserDto> items)> GetListAsync(int pageIndex, int pageSize);

        Task<UserDto> GetByIdAsync(long id);

        Task SaveAsync(UserDto dto, long[] UserRoleIds);

        Task DeleteAsync(long id);

        Task<List<RoleDto>> GetUserRolesAsync(long userId);
    }
}