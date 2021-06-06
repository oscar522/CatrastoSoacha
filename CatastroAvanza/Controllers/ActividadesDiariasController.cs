using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Models;
using CatastroAvanza.Models.ActividadesDiarias;
using CatastroAvanza.Negocio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CatastroAvanza.Controllers
{
    public class ActividadesDiariasController : Controller
    {

        public ActividadesDiariasController(ICatalogo catalogos)
        {
            _catalogos = catalogos;
        }

        private readonly ICatalogo _catalogos;
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CrearActividad()
        {
            return View(new ActividadesDiariasModel());
        }

        public async Task<ActionResult> TipoActividadList(string RolId)
        {

            var actividades = new List<CatalogoViewModel> {
                new CatalogoViewModel { Text = "Act 1", Value=1 },
                new CatalogoViewModel { Text = "Act 2", Value=2 },
                new CatalogoViewModel { Text = "Act 3", Value=3 }
            };
            
            return Json(new SelectList(actividades, "Value", "Text", 1));
        }

        public async Task<ActionResult> GetRoles()
        {

            var roles = new List<CatalogoViewModel> {
                new CatalogoViewModel { Text = "Rol 1", Value=1 },
                new CatalogoViewModel { Text = "Rol 2", Value=2 },
                new CatalogoViewModel { Text = "Rol 3", Value=3 }
            };

            return Json(new SelectList(roles, "Value", "Text", 1));
        }

        public async Task<ActionResult> GetProcess()
        {

            var roles = new List<CatalogoViewModel> {
                new CatalogoViewModel { Text = "Process 1", Value=1 },
                new CatalogoViewModel { Text = "Process 2", Value=2 },
                new CatalogoViewModel { Text = "Process 3", Value=3 }
            };

            return Json(new SelectList(roles, "Value", "Text", 1));
        }

        public async Task<ActionResult> GetModalidades()
        {

            var roles = new List<CatalogoViewModel> {
                new CatalogoViewModel { Text = "Modalidad 1", Value=1 },
                new CatalogoViewModel { Text = "Modalidad 2", Value=2 },
                new CatalogoViewModel { Text = "Modalidad 3", Value=3 }
            };

            return Json(new SelectList(roles, "Value", "Text", 1));
        }

        public async Task<ActionResult> GetDepartamentos()
        {            
            return Json(new SelectList(_catalogos.ObtenerDepartamentosPorIdPais(1), "Value", "Text", 1));
        }

        public async Task<ActionResult> GetMunicipios(int IdDepartamento)
        {
            var municipios = new SelectList(_catalogos.ObtenerMunicipiosPorIdDepartamento(IdDepartamento), "Value", "Text", 1);
            return Json(municipios);
        }

        [HttpPost]
        public async Task<ActionResult> ObtenerActividades([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest modelo)
        {

            var actividadesDiarias = new List<ActividadesDiariasTablaModel>();
            actividadesDiarias.Add(new ActividadesDiariasTablaModel
            {
                FechaActividadS = DateTime.Now,
                Cantidad = 2,
                Id = 1,
                NombreActividad = "Actividad 1",
                NombreModalidad = "Modalidad 1",
                NombreProceso = "Proceso 1",
                NombreRolActividad = "Rol 1",
                NombreUsuario = "oscarmorales1@msn.com",
                Observacion = "Observacion",
                RolUsuario = "Rol usuario"

            });
            var tabla = new DataTablesResponse(modelo.Draw, actividadesDiarias, actividadesDiarias.Count(), actividadesDiarias.Count);

            return Json(tabla, JsonRequestBehavior.AllowGet);
        }
    }
}