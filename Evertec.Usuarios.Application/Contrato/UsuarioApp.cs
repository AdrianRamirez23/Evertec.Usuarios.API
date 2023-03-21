using Evertec.Usuario.Entities.Models;
using Evertec.Usuarios.Application.Interfaces;
using Evertec.Usuarios.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Usuarios.Application.Contrato
{
    public class UsuarioApp: IUsuarioApp
    {
        private readonly IUsuarioSrv _usuario;
        public UsuarioApp(IUsuarioSrv usuario)
        {
            _usuario = usuario;
        }

        public async Task<List<UsuarioModel>> listarUsuarios() 
        {
            return await _usuario.listarUsuarios();
        }
        public async Task<UsuarioModel> listarUsuario(string id)
        {
            return await _usuario.listarUsuario(id);
        }
        public async Task<int> crearUsuario(UsuarioModel usuario)
        {
            return await _usuario.crearUsuario(usuario);
        }
        public async Task<int> updateUsuario(UsuarioModel usuario)
        {
            return await _usuario.updateUsuario(usuario);
        }

        public async Task<int> deleteUsuario(string id)
        {
            return await _usuario.deleteUsuario(id);
        }
    }
}
