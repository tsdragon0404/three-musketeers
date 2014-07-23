﻿using System.Linq;
using Core.Common.Validation;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class RoleManagement : BaseManagement<RoleDto, Role, long, IRoleRepository>, IRoleManagement
    {
        #region Fields

        public virtual IRolePermissionRepository RolePermissionRepository { get; set; }

        #endregion

        public override ServiceResult<RoleDto> Save(RoleDto dto)
        {
            var pageIds = dto.Pages.Select(x => x.ID).ToList();
            dto.Pages.Clear();
            
            var result = base.Save(dto);

            foreach (var pageId in pageIds)
                RolePermissionRepository.Add(new RolePermission { RoleID = result.Data.ID, PageID = pageId });

            return result;
        }
    }
}