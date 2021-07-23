namespace CatastroAvanza.Models.Trabajo
{
    public class TrabajoVolumenViewModel
    {
        public int TrabajosCreados { get; set; }

        public int TrabajosAsignados { get; set; }

        public int TrabajosCerrados { get; set; }

        public int GestionDiaria { get; set; }

        public int Total { get; private set; }

        public void SetTotal()
        {
            Total = TrabajosCreados + TrabajosAsignados + TrabajosCerrados + GestionDiaria;
        }
    }
}