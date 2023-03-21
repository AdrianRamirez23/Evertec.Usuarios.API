using Evertec.Usuario.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Usuarios.Infraestructure.Interfaces
{
    public interface IUsuarioData
    {
        Task<List<UsuarioModel>> listarUsuarios();
        Task<UsuarioModel> listarUsuario(object parameters);
        Task<int> crearUsuario(object model);
        Task<int> updateUsuario(object model);
        Task<int> deleteUsuario(object parameters);
    }
}
