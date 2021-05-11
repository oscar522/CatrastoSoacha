using System.Data.Entity;

namespace CatastroAvanza.Repositorio.DBContexto
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>Constructor por defecto.</summary>
        public ApplicationDbContext()
            : base("name=BusinessRuleEntityModel")
        { }
    }
}