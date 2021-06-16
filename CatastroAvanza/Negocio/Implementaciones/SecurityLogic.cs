using CatastroAvanza.Identity.DbContext;
using CatastroAvanza.Models;
using CatastroAvanza.Models.Security;
using CatastroAvanza.Negocio.Contratos;
using System.Collections.Generic;
using System.Linq;

namespace CatastroAvanza.Negocio.Implementaciones
{
    public class SecurityLogic : ISecurityLogic
    {
        private ApplicationIdentityDbContext _roleManager;

        public SecurityLogic()
        {
            _roleManager = ApplicationIdentityDbContext.Create();
        }

        public List<RoleViewModel> GetRoles()
        {
            var roles = _roleManager.Roles;
            List<RoleViewModel> rolesCatalogo = roles.Select(m => new RoleViewModel { Id = m.Id, Name= m.Name }).ToList();
            return rolesCatalogo;
        }

        public RoleViewModel GetRolesById(string idRol)
        {
            var roles = _roleManager.Roles.Where(m=> m.Id ==idRol);
            RoleViewModel rolesCatalogo = roles.Select(m => new RoleViewModel { Id = m.Id, Name = m.Name }).FirstOrDefault();
            
            if (rolesCatalogo == null)
                return new RoleViewModel();

            return rolesCatalogo;
        }

        public RoleViewModel GetRolesByUserId(string idUser)
        {
            var roles = _roleManager.Users.Where(m => m.UserName == idUser)?.FirstOrDefault()?.Roles?.FirstOrDefault().RoleId;

            RoleViewModel rol = GetRolesById(roles);

            return rol;
        }

    }
}