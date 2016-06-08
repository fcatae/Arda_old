﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arda.Common.Models.Permissions
{
    [Table("Users")]
    public class User
    {
        [Key]
        public string UniqueName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public PermissionStatus Status { get; set; }


        public virtual ICollection<UsersPermission> UserPermissions { get; set; }
    }

    public enum PermissionStatus
    {
        Waiting_Review,
        Permissions_Denied,
        Permissions_Granted        
    }
}
