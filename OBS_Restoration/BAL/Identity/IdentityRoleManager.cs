using Common.Log;
using DAL;
using Microsoft.AspNet.Identity;
using Models.Entities;
using System;
using System.Collections.Generic;

namespace BAL.Identity
{
    public class IdentityRoleManager : RoleManager<Role, long>
    {
        public IdentityRoleManager(IRoleStore<Role, long> store) : base(store)
        {
        }
        public IEnumerable<string> Get(List<long> ids)
        {
            try
            {
                using (var db = DbFactory.GetNotTrackingInstance())
                {
                    return db.RoleRepository.Find(x => ids.Contains(x.Id), x => x.Name);
                }
            }
            catch (Exception e)
            {
                Logger.LogErrorException("Error by getting roles", e);
                throw;
            }
        }
    }
}
