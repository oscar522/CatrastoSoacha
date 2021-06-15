using CatastroAvanza.Enumerations;
using CatastroAvanza.Models;
using System.Collections.Generic;

namespace CatastroAvanza.Negocio.Contratos
{
    public interface ICatalogo
    {
        ICollection<CatalogoViewModel> ObtenerCatalogoPorTipo(CatalogosEnum tipo);

        ICollection<CatalogoViewModel> ObtenerDepartamentosPorIdPais(int idPais);

        ICollection<CatalogoViewModel> ObtenerMunicipiosPorIdDepartamento(int IdDepartamento);

        ICollection<CatalogoViewModel> ObtenerActividadesPorRol(string IdRol);

        ICollection<CatalogoExtendidoViewModel> ObtenerUnidadArea();

        ICollection<CatalogoViewModel> ObtenerUso();

        ICollection<CatalogoExtendidoViewModel> ObtenerDestino();
    }
}