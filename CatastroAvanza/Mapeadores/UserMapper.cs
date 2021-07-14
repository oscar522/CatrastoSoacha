using CatastroAvanza.Identity.Model;
using CatastroAvanza.Models.Security;
using System.Collections.Generic;
using System.Linq;

namespace CatastroAvanza.Mapeadores
{
    public class UserMapper : IUserMapper
    {
        public List<UserViewModel> MapDataAModel(List<ApplicationUser> users)
        {
            List<UserViewModel> result = new List<UserViewModel>();
            if (users == null || !users.Any())
                return result;
            users.ForEach(m =>
            {
                UserViewModel user = new UserViewModel
                {
                    UserID = m.Id,
                    Apellidos = m.Apellidos,
                    Nombres = m.Nombres,
                    Documento = m.Documento,
                    TipoDocumento = m.TipoDocumento,
                    Telefono = m.PhoneNumber,
                    Email = m.Email,
                    Estado = m.LockoutEndDateUtc >= System.DateTime.Now ? "Inactivo" : "Activo",
                    rol = m.Roles.FirstOrDefault()?.RoleId
                };

                result.Add(user);
            });

            return result;
        }

        public ActualizarUsuarioViewModel MapDataAModel(ApplicationUser user)
        {
            ActualizarUsuarioViewModel result = new ActualizarUsuarioViewModel();
            if (user == null)
                return result;

            result = new ActualizarUsuarioViewModel
            {
                UserId = user.Id,
                Apellidos = user.Apellidos,
                Nombres = user.Nombres,
                Documento = user.Documento,
                TipoDocumento = user.TipoDocumento,
                Telefono = user.PhoneNumber,
                Email = user.Email,
                Estado = user.LockoutEnabled ? "Activo" : "Inactivo",
                Rol = user.Roles.FirstOrDefault()?.RoleId
            };
               
            return result;
        }
    }
}