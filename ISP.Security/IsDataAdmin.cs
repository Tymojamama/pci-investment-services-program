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
        public bool IsDataAdmin()
        {
            foreach (SecurityRole securityRole in SecurityRoles)
            {
                if (securityRole.Id == new Guid("C0A4E87F-1706-45AF-AD5B-F5ED736231AC"))
                    return true;
            }

            return false;
        }
    }
}