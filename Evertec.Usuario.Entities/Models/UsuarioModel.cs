using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Evertec.Usuario.Entities.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("nombre")]
        [MaxLength(50, ErrorMessage = "El tamaño máximo en caracteres para el campo Nombre es de 50")]
        [MinLength(3, ErrorMessage = "El tamaño mínimo en caracteres para el campo Nombre es de 3")]
        public string Nombre { get; set; }

        [Required]
        [JsonPropertyName("apellido")]
        [MaxLength(50, ErrorMessage = "El tamaño máximo en caracteres para el campo Apellido es de 50")]
        [MinLength(3, ErrorMessage = "El tamaño mínimo en caracteres para el campo Apellido es de 3")]
        public string Apellido { get; set; }

        [Required]
        [JsonPropertyName("fechaNacimiento")]
        [DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }

        [JsonPropertyName("fotoUsuario")]
        public  byte[]? FotoUsuario { get; set; }

        [Required]
        [JsonPropertyName("estadoCivil")]
        [Range(1, 2, ErrorMessage = "Ingrese 1 = Soltero o 2 = Casado")]
        public int EstadoCivil { get; set; }

        [Required]
        [JsonPropertyName("tieneHermanos")]
        public bool TieneHermanos { get; set; }

    }
}
