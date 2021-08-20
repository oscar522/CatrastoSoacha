using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Models.Archivo;
using CatastroAvanza.Negocio.Contratos;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CatastroAvanza.Controllers
{
    public class ArchivoController : BaseController
    {

        public ArchivoController(IArchivoLogic archivo)
        {
            _archivo = archivo;
        }
       
        private readonly IArchivoLogic _archivo;

        [Authorize]
        public async Task<ActionResult> CrearArchivo()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public  async Task<ActionResult> CrearArchivo(CrearArchivoViewModel model)
        {            
            var result = await _archivo.CrearParteArchivo(model);

            var resultCreactionFile = await _archivo.CrearArchivo(model, new Models.AuditoriaModel(GetUserName()));

            return Json(result, JsonRequestBehavior.AllowGet);           
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CompletarCargaArchivo(string fileId)
        {
            var result = await _archivo.CompletarCreacionArchivo(fileId);

            if (result != 0)
                return Json("ok", JsonRequestBehavior.AllowGet);

            return Json("error", JsonRequestBehavior.AllowGet);
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ConsultarArchivos([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest modelo)
        {
            var tabla = await _archivo.ConsultarArchivos(modelo);
            return Json(tabla, JsonRequestBehavior.AllowGet);
        }

        [Authorize]      
        public async Task<ActionResult> DescargarArchivo(int archivoId)
        {
            var archivo = await _archivo.DescargarArchivo(archivoId);
            if (archivo?.Archivo != null)
            {
                Response.Clear();                
                Response.Buffer = false;
                Response.BufferOutput = false;
                return File(archivo.Archivo, MediaTypeNames.Application.Octet, archivo.Nombre);
            }

            return RedirectToAction(nameof(CrearArchivo));
        }
    }
}