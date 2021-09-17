using CatastroAvanza.App_Start;
using CatastroAvanza.Enumerations;
using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Identity.DbContext;
using CatastroAvanza.Mapeadores;
using CatastroAvanza.Models.Security;
using CatastroAvanza.Negocio.Contratos;
using CatastroAvanza.Repositorio.DBContexto.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatastroAvanza.Negocio.Implementaciones
{
    public class SecurityLogic : ISecurityLogic
    {
        private ApplicationIdentityDbContext _securityManager;
        private readonly IApplicationDbContext _contexto;
        private readonly IUserMapper _mapper;        

        public SecurityLogic(IUserMapper mapper, IApplicationDbContext contexto)
        {
            
            _contexto = contexto;
            _securityManager = ApplicationIdentityDbContext.Create();
            _mapper = mapper;
        }
        

        public List<RoleViewModel> GetRoles()
        {
            var roles = _securityManager.Roles;
            List<RoleViewModel> rolesCatalogo = roles.Select(m => new RoleViewModel { Id = m.Id, Name= m.Name }).ToList();
            return rolesCatalogo;
        }

        public RoleViewModel GetRolesById(string idRol)
        {
            var roles = _securityManager.Roles.Where(m=> m.Id ==idRol);
            RoleViewModel rolesCatalogo = roles.Select(m => new RoleViewModel { Id = m.Id, Name = m.Name }).FirstOrDefault();
            
            if (rolesCatalogo == null)
                return new RoleViewModel();

            return rolesCatalogo;
        }

        public RoleViewModel GetRolesByUserId(string idUser)
        {
            var roles = _securityManager.Users.Where(m => m.UserName == idUser)?.FirstOrDefault()?.Roles?.FirstOrDefault()?.RoleId;

            if (roles == null)
                return new RoleViewModel();

            RoleViewModel rol = GetRolesById(roles);

            return rol;
        }

        public async Task<DataTablesResponse> GetUsuarios(IDataTablesRequest modelo, ApplicationUserManager userManager)
        {
            try
            {
                var sortedColumn = modelo.Columns.GetSortedColumns().Where(x => x.OrderNumber == 0).FirstOrDefault();
                UserColumnasOrdenables? columnaOrdenar = null;
                bool orderByDescending = false;
                if (sortedColumn != null && Enum.GetNames(typeof(UserColumnasOrdenables)).Contains(sortedColumn.Name))
                {
                    columnaOrdenar = (UserColumnasOrdenables)Enum.Parse(typeof(UserColumnasOrdenables), sortedColumn.Name);
                    orderByDescending = sortedColumn.SortDirection == Column.OrderDirection.Descendant;
                }

                var users = _securityManager.Users.AsQueryable();

                if (!string.IsNullOrEmpty(modelo.Search.Value))
                {
                    users = users.Where(m => m.Email == modelo.Search.Value);
                }

                if (orderByDescending)
                    users = users.OrderBy(m => columnaOrdenar);
                else
                    users = users.OrderByDescending(m => columnaOrdenar);

                var listadoUsuariosDb = users.Skip(modelo.Start).Take(modelo.Length).ToList();

                var listadoUsuarios = _mapper.MapDataAModel(listadoUsuariosDb);

                listadoUsuarios.ForEach(u =>
                {
                    u.rol = GetRolesById(u.rol)?.Name;
                    var tipoDocumentoEntity =_contexto.Catalogo.FirstOrDefault(c => c.Id == u.TipoDocumento && c.Tipo == nameof(CatalogosEnum.TipoDocumento));
                    u.TipoDocumentoNombre = tipoDocumentoEntity?.Nombre;                    
                });

                var tabla = new DataTablesResponse(modelo.Draw, listadoUsuarios, _securityManager.Users.Count(), listadoUsuarios.Count);

                return tabla;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new DataTablesResponse(modelo.Draw, new List<UserViewModel>(), 0, 0);
            }            
        }

        public async Task<ICollection<UserViewModel>> GetUsuariosByName(string userName)
        {
            try
            {
                var users = _securityManager.Users.Where(m=> m.UserName.Contains(userName) || m.Nombres.Contains(userName) || m.Apellidos.Contains(userName));

                if (!users.Any())
                    return new List<UserViewModel>();

                var listadoUsuariosDb = users.ToList();

                var listadoUsuarios = _mapper.MapDataAModel(listadoUsuariosDb);
                
                return listadoUsuarios;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new List<UserViewModel>();
            }
        }


        public async Task<ActualizarUsuarioViewModel> GetUsuarioParaActualizar(string userId)
        {
            var users = _securityManager.Users.Where(m=> m.Id ==  userId);

            var usuario = _mapper.MapDataAModel(users.FirstOrDefault());

            return usuario;
        }
    }
}