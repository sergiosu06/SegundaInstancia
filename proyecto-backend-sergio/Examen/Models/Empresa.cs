using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class Empresa
    {
        [Key]
        public int idEmpresa { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string localizacion { get; set; }
    }
}
