using CatastroAvanza.Enumerations;
using CatastroAvanza.Mapeadores;
using CatastroAvanza.Models;
using CatastroAvanza.Negocio.Contratos;
using CatastroAvanza.Repositorio.DBContexto.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatastroAvanza.Negocio.Implementaciones
{
    public class Catalogo : ICatalogo
    {
        public Catalogo(IApplicationDbContext contexto, IMapeadoresApplicacion mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        private readonly IApplicationDbContext _contexto;
        private readonly IMapeadoresApplicacion _mapper;

        public ICollection<CatalogoViewModel> ObtenerCatalogoPorTipo(CatalogosEnum tipo)
        {
            try
            {
                var catalogo = _contexto.Catalogo.Where(m => m.Estado == "1" && m.Tipo == tipo.ToString()).ToList();

                ICollection<CatalogoViewModel> result = _mapper.MapDataAModel(catalogo);

                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new List<CatalogoViewModel>();
            }
        }
    }
}