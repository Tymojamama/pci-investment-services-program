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
        public bool IsAdmin()
        {
            foreach (SecurityRole securityRole in SecurityRoles)
            {
                if (securityRole.Id == new Guid("3C6899B9-485D-4AA7-9AB9-164D8C353C58"))
                    return true;
            }

            return false;
        }
    }
}