using System.ComponentModel.DataAnnotations;

namespace ProyClienteWebAPIClinica.Models
{
    public class Medico
    {
        [Required]
        public string Codmed { get; set; } = "";

        [Required]
        public string Nommed { get; set; } = "";

        [Required]
        public int AnioColegio { get; set; }

        [Required]
        public string Codesp { get; set; } = "";

        [Required]
        public string Coddis { get; set; } = string.Empty;

        public string Eliminado { get; set; } = "No";

        public Medico()
        {
            //PropiedadFecha = new DateTime(2000, 5, 23);
            Eliminado = "No";
        }
    }
}
