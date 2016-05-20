﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arda.Permissions.Models
{
   [Table("UsersPermissions")]
    public class UsersPermissions
    {
        [Key]
        public string UniqueName { get; set; }

        [Required]
        public string PermissionsSerialized { get; set; }

        public PermissionsScope ToPermission()
        {
            try
            {
                return JsonConvert.DeserializeObject<PermissionsScope>(PermissionsSerialized);
            }
            catch (Exception e)
            {
                throw new Exception(e.StackTrace);
            }
        }
    }
}