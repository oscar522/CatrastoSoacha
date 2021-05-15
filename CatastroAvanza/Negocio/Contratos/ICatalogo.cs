using CatastroAvanza.Enumerations;
using CatastroAvanza.Models;
using System.Collections.Generic;

namespace CatastroAvanza.Negocio.Contratos
{
    public interface ICatalogo
    {
        ICollection<CatalogoViewModel> ObtenerCatalogoPorTipo(CatalogosEnum tipo);
    }
}