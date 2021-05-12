using System.Collections;
using System.Collections.Generic;

namespace CatastroAvanza.Models.Dashboard
{
    public class DataForm1Model
    {
        public int id { get; set; }

        public int dep { get; set; }

        public int mun { get; set; }

        public string NUMERO_DEL_PREDIO { get; set; }

        public int Tipo_de_registro { get; set; }

        public string NUMERO_DE_ORDEN { get; set; }

        public string TOTAL_REGISTROS { get; set; }

        public string NOMBRE { get; set; }

        public string TIPO_DOCUMENTO { get; set; }

        public string NUMERO_DOCUMENTO { get; set; }

        public string DIRECCION { get; set; }

        public string DESTINO_ECONOMICO { get; set; }

        public string AREA_TERRENO { get; set; }

        public string AREA_CONSTRUIDA { get; set; }

        public string AVALUO { get; set; }

        public string VIGENCIA { get; set; }

        public string NUMERO_PREDIAL_ANTERIOR { get; set; }

        public string CANTIDAD_MEJORA { get; set; }

        public IEnumerable<string> CANTIDAD_PROPIETARIOS { get; set; }

        public IEnumerable<R1_2020_66069_PREDIOSModel> R1_2020_66069_PREDIOSModel { get; set; }

        public IEnumerable<R2_2021_69295_CONSTRUCCIONESModel> R2_2021_69295_CONSTRUCCIONESModel { get; set; }
    }
}