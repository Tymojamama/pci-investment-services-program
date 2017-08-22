using DihEntity = DataIntegrationHub.Business.Entities;
using IspEntity = ISP.Business.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.Security
{
    public partial class SecurityComponent
    {
        public DihEntity.User User { get; private set; }
        public List<IspEntity.SecurityRole> SecurityRoles { get; private set; }

        public SecurityComponent(DihEntity.User user)
        {
            User = user;
            SecurityRoles = IspEntity.UserSecurityRole.AssociatedSecurityRolesFromUser(this.User.UserId);
        }
    }
}
