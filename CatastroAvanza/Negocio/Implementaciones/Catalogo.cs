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

        public ICollection<CatalogoViewModel> ObtenerDepartamentosPorIdPais(int idPais)
        {
            try
            {
                var catalogo = _contexto.Departamento.Where(m => m.estado == 1 && m.id_ct_pais == idPais).ToList();

                ICollection<CatalogoViewModel> result = _mapper.MapDataAModel(catalogo);

                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new List<CatalogoViewModel>();
            }
        }

        public ICollection<CatalogoViewModel> ObtenerMunicipiosPorIdDepartamento(int IdDepartamento)
        {
            try
            {
                var catalogo = _contexto.Ciudad.Where(m => m.estado == 1 && m.idctdepto == IdDepartamento).ToList();

                ICollection<CatalogoViewModel> result = _mapper.MapDataAModel(catalogo);

                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new List<CatalogoViewModel>();
            }
        }

        public ICollection<CatalogoViewModel> ObtenerActividadesPorRol(string IdRol)
        {
            try
            {
                var catalogo = _contexto.TipoActividad.Where(m => m.Estado == true && m.IdRol == IdRol).ToList();

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