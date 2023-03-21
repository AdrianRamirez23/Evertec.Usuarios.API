using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Evertec.Usuario.Entities.Models
{
    public class UsuarioRequest: UsuarioModel
    {
        [Required]
        [JsonPropertyName("imagen")]
        public IFormFile Imagen { get; set; }
    }
}
