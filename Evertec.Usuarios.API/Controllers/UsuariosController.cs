using Evertec.Usuario.Entities.Models;
using Evertec.Usuarios.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Evertec.Usuarios.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IUsuarioApp _usuario;
        public UsuariosController(ILogger<UsuariosController> logger, IUsuarioApp usuario)
        {
            _logger = logger;
            _usuario = usuario;
        }

        [HttpGet]
        [Route("listarUsuarios")]
        public async Task<IActionResult> listarUsuarios() 
        {
            try
            {
                var listUsuarios = await  _usuario.listarUsuarios();
                if(listarUsuarios != null) 
                {
                    _logger.LogTrace("Consulta correcta, usuarios listados", listarUsuarios);
                    return Ok(new
                    {
                        Estado = true,
                        Mensaje = "Usuarios Listados",
                        Result = listUsuarios
                    });
                }
                else 
                {
                    _logger.LogTrace("Consulta incorrecta", "No hay usuarios en la base de datos", null);
                    return NotFound("No hay usuarios en la base de datos");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Error consultar lista usuario: "+ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("listarUsuario/{id}")]
        public async Task<IActionResult> listarUsuario(string id)
        {
            try
            {
                var usuario = await _usuario.listarUsuario(id);
                if (usuario != null)
                {
                    _logger.LogTrace("Consulta correcta, usuario encontrado", usuario);
                    return Ok(new
                    {
                        Estado = true,
                        Mensaje = "Usuario encontrado",
                        Result = usuario
                    });
                }
                else
                {
                    _logger.LogTrace("Consulta incorrecta", "No hay usuarios en la base de datos con ese id", id);
                    return NotFound("Usuario no encontrado");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Error consultar usuario con id: "+id+" error: " + ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("crearUsuario")]
        public async Task<IActionResult> crearUsuario([FromForm] UsuarioRequest usuario)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    usuario.FotoUsuario = await convertirImagen(usuario.Imagen);
                    var result = await _usuario.crearUsuario(usuario);
                    if (result > 0)
                    {
                        _logger.LogTrace("Almacenamiento correcto correcta, usuario grabado", usuario);
                        return Ok(new
                        {
                            Estado = true,
                            Mensaje = "Usuario grabado en base de datos",
                            Result = result
                        });
                    }
                    else
                    {
                        _logger.LogTrace("Almacenamiento incorrecto", "No se insertó registros en la base de datos", usuario);
                        return NotFound("Usuario no grabado");
                    }
                }
                else 
                {
                    _logger.LogError("Error en la petición");
                    return BadRequest("Error en la petición: "+ModelState.IsValid.ToString());
                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Error almacenar usuario error: " + ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("updateUsuario")]
        public async Task<IActionResult> updateUsuario([FromForm] UsuarioRequest usuario)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    usuario.FotoUsuario = await convertirImagen(usuario.Imagen);
                    var result = await _usuario.updateUsuario(usuario);
                    if (result > 0)
                    {
                        _logger.LogTrace("Almacenamiento correcto, usuario actualizado", usuario);
                        return Ok(new
                        {
                            Estado = true,
                            Mensaje = "Usuario actualizado en base de datos",
                            Result = result
                        });
                    }
                    else
                    {
                        _logger.LogTrace("Actualización incorrecta", "No se actualizó registros en la base de datos", usuario);
                        return NotFound("Usuario no actualizado");
                    }
                }
                else
                {
                    _logger.LogError("Error en la petición");
                    return BadRequest("Error en la petición: " + ModelState.IsValid.ToString());
                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Error actualizar usuario error: " + ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteUsuario/{id}")]
        public async Task<IActionResult> deleteUsuario(string id)
        {
            try
            {
                var usuario = await _usuario.deleteUsuario(id);
                if (usuario != null)
                {
                    _logger.LogTrace("Eliminación correcta, usuario eliminado", usuario);
                    return Ok(new
                    {
                        Estado = true,
                        Mensaje = "Usuario eliminado",
                        Result = usuario
                    });
                }
                else
                {
                    _logger.LogTrace("Eliminación incorrecta", "No hay usuarios en la base de datos con ese id", id);
                    return NotFound("Usuario no encontrado");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Error eliminar usuario con id: " + id + " error: " + ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }


        internal async Task<byte[]> convertirImagen(IFormFile imagen)
        {
           
            using (var stream = new MemoryStream())
            {
                await imagen.CopyToAsync(stream);
                return stream.ToArray();
            }
        }
    }
}