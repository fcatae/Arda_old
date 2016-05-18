﻿using Arda.Permissions.Interfaces;
using Arda.Permissions.Models;
using System;
using System.Linq;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Arda.Permissions.ViewModels;
using Arda.Common.Utils;

namespace Arda.Permissions.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private UserPermissionsContext _context;
        private IDistributedCache _cache;

        public PermissionRepository(UserPermissionsContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }


        public bool SetUserPermissionsAndCode(string uniqueName, string code)
        {
            try
            {
                var userProperties = _context.UsersPermissions.SingleOrDefault(user => user.UniqueName == uniqueName);
                if (userProperties != null)
                {
                    var permissions = userProperties.ToPermission();
                    var propertiesToCache = new UserPropertiesCachedViewModel(code, permissions);

                    _cache.Set(uniqueName, Util.GetBytes(propertiesToCache.ToString()));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateUserPermissions(string uniqueName, string userPermissionsSerialized)
        {
            try
            {
                var propertiesSerializedCached = Util.GetString(_cache.Get(uniqueName));

                if (propertiesSerializedCached != null)
                {
                    var propertiesToCache = new UserPropertiesCachedViewModel(propertiesSerializedCached);
                    propertiesToCache.Permissions = new PermissionsScope(userPermissionsSerialized);

                    _cache.Set(uniqueName, Util.GetBytes(propertiesToCache.ToString()));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteUserPermissions(string uniqueName)
        {
            try
            {
                _cache.Remove(uniqueName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool VerifyUserAccessToResource(string uniqueName, string module, string resource)
        {
            try
            {
                resource = resource.ToLower();
                module = module.ToLower();

                var propertiesSerializedCached = Util.GetString(_cache.Get(uniqueName));
                if (propertiesSerializedCached != null)
                {
                    var permissions = new UserPropertiesCachedViewModel(propertiesSerializedCached).Permissions.ToString().Trim().ToLower();
                    if (permissions.Contains(module) && permissions.Contains(resource))
                    {
                        var search = "module\":\"" + module + "\",\"resource\":\"" + resource + "\",\"enabled\":";
                        var permExtracted = permissions.Substring(permissions.IndexOf(search) + search.Length);
                        var value = permExtracted.Substring(0, permExtracted.IndexOf("}"));
                        if (bool.Parse(value))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public void SetAllan()
        //{
        //    PermissionsScope perm = new PermissionsScope();
        //    perm.Permissions.Add(new Permission() { Module = "Infos", Resource = "GetInfo", Enabled = true });
        //    perm.Permissions.Add(new Permission() { Module = "Values", Resource = "GetValues", Enabled = false });

        //    _context.UsersPermissions.Add(new UsersPermissions()
        //    {
        //        UniqueName = "t-allta@microsoft.com",
        //        PermissionsSerialized = perm.ToString()
        //    });
        //    _context.SaveChanges();
        //}
    }
}