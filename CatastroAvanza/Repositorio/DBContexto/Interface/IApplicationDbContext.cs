using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity;

namespace CatastroAvanza.Repositorio.DBContexto.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<ctpais> Pais { get; set; }
        DbSet<ctdepto> Departamento { get; set; }
        DbSet<ctciudad> Ciudad { get; set; }

        DbSet<ctcatalogo> Catalogo { get; set; }
        DbSet<R1_2020_66069_PREDIOS> R1202066069Predios { get; set; }
        DbSet<R1_2021_69295_PREDIOS> R1202169295Predios { get; set; }
        DbSet<R2_2021_69295_CONSTRUCCIONES> R2202169295Construcciones { get; set; }
    }
}
