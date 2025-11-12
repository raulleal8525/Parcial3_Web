using System.ComponentModel.DataAnnotations;

namespace Parcial3_Web.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(20)]
        [Phone(ErrorMessage = "Formato de teléfono no válido")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "Formato de email no válido")]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Departamento { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;
    }
}