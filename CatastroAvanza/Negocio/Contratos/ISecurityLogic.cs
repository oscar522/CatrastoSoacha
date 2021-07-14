using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Models.Security;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatastroAvanza.Negocio.Contratos
{
    public interface ISecurityLogic
    {
        List<RoleViewModel> GetRoles();

        Task<DataTablesResponse> GetUsuarios(IDataTablesRequest modelo);

        Task<ActualizarUsuarioViewModel> GetUsuarioParaActualizar(string userId);

        RoleViewModel GetRolesById(string idRol);

        RoleViewModel GetRolesByUserId(string idUser);


    }

}