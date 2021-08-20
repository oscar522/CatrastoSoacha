using CatastroAvanza.Mapeadores.Interfaces;
using CatastroAvanza.Models;
using CatastroAvanza.Models.Archivo;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace CatastroAvanza.Mapeadores
{
    public class ArchivoMapper : IArchivoMapper
    {
        public Archivo MapViewModelToEntidad(CrearArchivoViewModel model, AuditoriaModel auditoriaModel)
        {
            if (model == null)
                return new Archivo();

            if(model.fileBlob == null)
                return new Archivo();

            Archivo result = new Archivo
            {
                Nombre = model.fileRelativePath,
                NombreFisico = model.fileId,
                CreadoPor = auditoriaModel.CreadoPor,
                FechaCreacion = auditoriaModel.FechaCreacion,
                EstadoCarga = "NoCompletado"
            };            

            return result;
        }

        public ICollection<ArchivoViewModel> MapListaEntidadesToListaViewModel(ICollection<Archivo> model)
        {
            if (model == null)
                return new List<ArchivoViewModel>();

            ICollection<ArchivoViewModel> result = model.Select(m => new ArchivoViewModel
            {
                CreadoPor = m.CreadoPor,
                FechaCreacion = m.FechaCreacion,              
                Id = m.Id,
                Nombre = m.Nombre,
                NombreFisico = m.NombreFisico
            }).ToList();

            return result;
        }
    }
}