using CatastroAvanza.Models.Security;
using System.Collections.Generic;

namespace CatastroAvanza.Negocio.Contratos
{
    public interface ISecurityLogic
    {
        List<RoleViewModel> GetRoles();

        RoleViewModel GetRolesById(string idRol);

        RoleViewModel GetRolesByUserId(string idUser);
    }
}