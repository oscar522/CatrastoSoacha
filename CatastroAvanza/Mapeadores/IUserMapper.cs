using CatastroAvanza.Identity.Model;
using CatastroAvanza.Models.Security;
using System.Collections.Generic;

namespace CatastroAvanza.Mapeadores
{
    public interface IUserMapper
    {
        List<UserViewModel> MapDataAModel(List<ApplicationUser> users);

        ActualizarUsuarioViewModel MapDataAModel(ApplicationUser user);
    }
}
