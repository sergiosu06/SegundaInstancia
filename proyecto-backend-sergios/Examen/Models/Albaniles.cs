using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class Albanil
    {
        [Key]
        public int idAlbanil { get; set; }
        public string numSegSocial { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string fechaNacimiento { get; set; }
        public int numeroTelefono { get; set; }
        public string categoriaProfesional { get; set; }
        public int idEmpresa { get; set; }
    }
}
