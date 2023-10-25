using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace gestorBiblioteca.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        public Usuarios(long id_usuario, string dni_usuario, string nombre_usuario, string apellidos_usuario, string tlf_usuario,
            string email_usuario, string clave_usuario, bool estaBloqueado_usuario)
        {
            IdUsuario = id_usuario;
            DniUsuario = dni_usuario;
            NombreUsuario = nombre_usuario;
            ApellidosUsuario = apellidos_usuario;
            TlfUsuario = tlf_usuario;
            EmailUsuario = email_usuario;
            ClaveUsuario = clave_usuario;
            EstaBloqueadoUsuario = estaBloqueado_usuario;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdUsuario { get; set; }

        [Required]
        [Column("dni_usuario")]
        public string DniUsuario { get; set; }

        [Required]
        [Column("nombre_usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [Column("apellidos_usuario")]
        public string ApellidosUsuario { get; set; }

        [Required]
        [Column("tlf_usuario")]
        public string TlfUsuario { get; set; }

        [Required]
        [Column("email_usuario")]
        public string EmailUsuario { get; set; }

        [Required]
        [Column("clave_usuario")]
        public string ClaveUsuario { get; set; }

        [Required]
        [Column("estaBloqueado_usuario")]
        public bool EstaBloqueadoUsuario { get; set; }

        // Relación muchos a uno con la entidad Accesos
        public Accesos Acceso { get; set; }

        public override string ToString()
        {
            return $"Usuarios [IdUsuario={IdUsuario}, DniUsuario={DniUsuario}, NombreUsuario={NombreUsuario}, " +
                   $"ApellidosUsuario={ApellidosUsuario}, TlfUsuario={TlfUsuario}, EmailUsuario={EmailUsuario}, " +
                   $"ClaveUsuario={ClaveUsuario}, EstaBloqueadoUsuario={EstaBloqueadoUsuario}]";
        }
    }
}
