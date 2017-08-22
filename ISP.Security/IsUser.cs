using ISP.Business.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.Security
{
    public partial class SecurityComponent
    {
        public bool IsUser()
        {
            foreach (SecurityRole securityRole in SecurityRoles)
            {
                if (securityRole.Id == new Guid("57A35A2E-E381-4BB4-8FCC-EA240059910B"))
                    return true;
            }

            return false;
        }
    }
}