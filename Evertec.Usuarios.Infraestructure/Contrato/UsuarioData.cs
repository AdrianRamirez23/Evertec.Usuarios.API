using Dapper;
using Evertec.Usuario.Entities.Models;
using Evertec.Usuario.Entities.Models78;
using Evertec.Usuarios.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Usuarios.Infraestructure.Contrato
{
    public class UsuarioData: IUsuarioData
    {
        private readonly IConfiguration _config;
        private readonly ILogger<UsuarioData> _logger;
        public UsuarioData(IConfiguration config, ILogger<UsuarioData> logger)
        {
            _config = config;
            _logger = logger;   
        }
        public async Task<List<UsuarioModel>> listarUsuarios() 
        {
            List<UsuarioModel> result = null;
            try
            {
                using (var con = new SqlConnection(_config.GetConnectionString("dbConection")))
                {
                    result = con.Query<UsuarioModel>(Constants.spListarUsuarios, commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                _logger.LogTrace("Se realiza la consulta a la base de datos", result);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error en la consulta a la base de datos listar todos: " + ex.Message, ex);
                return null;
            }
           
        }
        public async Task<UsuarioModel> listarUsuario(object parameters)
        {
            UsuarioModel result = null;
            try
            {
                using (var con = new SqlConnection(_config.GetConnectionString("dbConection")))
                {
                    result = con.Query<UsuarioModel>(Constants.spListarUsuariosById, parameters,commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                }
                _logger.LogTrace("Se realiza la consulta a la base de datos", result);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error en la consulta a la base de datos listar por id: " + ex.Message, ex);
                return null;
            }

        }
        public async Task<int> crearUsuario(object parameters)
        {
            int result = 0;
            try
            {
              
                using (var con = new SqlConnection(_config.GetConnectionString("dbConection")))
                {
                    result = con.Execute(Constants.spCreateUsuarios, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                _logger.LogTrace("Se ejecución la consulta a la base de datos", result);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al ejecutar crear usuario: " + ex.Message, ex);
                return 0;
            }

        }
        public async Task<int> updateUsuario(object parameters)
        {
            int result = 0;
            try
            {
                using (var con = new SqlConnection(_config.GetConnectionString("dbConection")))
                {
                    result = con.Execute(Constants.spUpdateUsuarios, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                _logger.LogTrace("Se ejecución la consulta a la base de datos", result);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al ejecutar editar usuario: " + ex.Message, ex);
                return 0;
            }

        }
        public async Task<int> deleteUsuario(object parameters)
        {
            int result = 0;
            try
            {
                using (var con = new SqlConnection(_config.GetConnectionString("dbConection")))
                {
                    result = con.Execute(Constants.spDeleteUsuarios, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                _logger.LogTrace("Se ejecución la consulta a la base de datos", result);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al ejecutar editar usuario: " + ex.Message, ex);
                return 0;
            }

        }
    }
}
