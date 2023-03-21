using Evertec.Usuario.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Usuarios.Application.Interfaces
{
    public interface IUsuarioApp
    {
        Task<List<UsuarioModel>> listarUsuarios();
        Task<UsuarioModel> listarUsuario(string id);
        Task<int> deleteUsuario(string id);
        Task<int> crearUsuario(UsuarioModel model);
        Task<int> updateUsuario(UsuarioModel model);
    }
}
