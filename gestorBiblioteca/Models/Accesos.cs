using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace gestorBiblioteca.Models
{
    [Table("Accesos")]
    public class Accesos
    {
        public Accesos(string codigo_acceso, string descripcion_acceso)
        {
            CodigoAcceso = codigo_acceso;
            DescripcionAcceso = descripcion_acceso;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdAcceso { get; set; }

        [Required]
        [Column("codigo_acceso")]
        public string CodigoAcceso { get; set; }

        [Required]
        [Column("descripcion_acceso")]
        public string DescripcionAcceso { get; set; }

        // Relación uno a muchos con la entidad Usuarios
        public List<Usuarios> Usuarios { get; set; }

        public override string ToString()
        {
            return $"Accesos [IdAcceso={IdAcceso}, CodigoAcceso={CodigoAcceso}, DescripcionAcceso={DescripcionAcceso}]";
        }
    }
}
