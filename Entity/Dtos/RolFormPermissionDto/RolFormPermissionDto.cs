﻿using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.RolFormPermissionDto
{
    public class RolFormPermissionDto : Base.BaseDto
    {
        public int RoleId { get; set; }
        public int FormId { get; set; }
        public int PermissionId { get; set; }
    }
}
