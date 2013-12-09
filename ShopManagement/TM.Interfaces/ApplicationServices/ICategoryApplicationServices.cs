﻿using TM.DataContracts;
using TM.Framework;

namespace TM.Interfaces.ApplicationServices
{
    public interface ICategoryApplicationServices
    {
        ServiceResult<CategoryDTO> AddCategory(CategoryDTO categoryDTO);
    }
}