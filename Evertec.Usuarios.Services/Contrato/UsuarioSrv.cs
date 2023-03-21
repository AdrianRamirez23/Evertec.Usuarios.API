using Evertec.Usuario.Entities.Models;
using Evertec.Usuarios.Infraestructure.Interfaces;
using Evertec.Usuarios.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Usuarios.Services.Contrato
{
    public class UsuarioSrv: IUsuarioSrv
    {
        private readonly IUsuarioData _usuario;
        public UsuarioSrv(IUsuarioData usuario)
        {
            _usuario = usuario;
        }
        public async Task<List<UsuarioModel>> listarUsuarios()
        {
            return await _usuario.listarUsuarios();
        }
        public async Task<UsuarioModel> listarUsuario(string id)
        {
            var parameters = new { Id = id };
            return await _usuario.listarUsuario(parameters);
        }
        public async Task<int> crearUsuario(UsuarioModel usuario)
        {
            var parameter = new
            {
                Id = 0,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                FechaNacimiento = usuario.FechaNacimiento,
                FotoUsuario = usuario.FotoUsuario,
                EstadoCivil = usuario.EstadoCivil,
                TieneHermanos = usuario.TieneHermanos

            };
            return await _usuario.crearUsuario(parameter);
        }
        public async Task<int> updateUsuario(UsuarioModel usuario)
        {
            var parameter = new
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                FechaNacimiento = usuario.FechaNacimiento,
                FotoUsuario = usuario.FotoUsuario,
                EstadoCivil = usuario.EstadoCivil,
                TieneHermanos = usuario.TieneHermanos

            };
            return await _usuario.updateUsuario(usuario);
        }
        public async Task<int> deleteUsuario(string id)
        {
            var parameters = new { Id = id };
            return await _usuario.deleteUsuario(parameters);
        }
    }
}
