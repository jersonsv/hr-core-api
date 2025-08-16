using API.EMPRESA.CONF.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.EMPRESA.CONF.Services
{
    public class EmpleadoService
    {
        private readonly IConfiguration _configuration;
        private readonly string _cadenaSql;

        public EmpleadoService(IConfiguration configuration)
        {
            _configuration = configuration;
            _cadenaSql = _configuration.GetConnectionString("BddSql");
        }

        public async Task<List<Empleado>> Lista()
        {
            string query = "sp_listar_empleados";
            using (var conn = new SqlConnection(_cadenaSql)) {
                var lista = await conn.QueryAsync<Empleado>(query,commandType: CommandType.StoredProcedure);
                return lista.ToList();
            }
           
        }

        public async Task<Empleado> ObtenerEmpleado(int id)
        {
            string query = "sp_obtener_empleado";
            var parametros = new DynamicParameters();
            parametros.Add("@EmpleadoID", id, dbType: DbType.Int32);
            using (var conn = new SqlConnection(_cadenaSql))
            {
                var empleado = await conn.QueryFirstOrDefaultAsync<Empleado>(query, parametros, commandType: CommandType.StoredProcedure);
                return empleado;
            }

        }

        public async Task<String> CrearEmpleado(Empleado empleado)
        {
            string query = "sp_insertar_empleado";
            var parametros = new DynamicParameters();
            parametros.Add("@Nombre", empleado.Nombre, dbType: DbType.String);
            parametros.Add("@NumeroDocumento", empleado.NumeroDocumento, dbType: DbType.String);
            parametros.Add("@Sueldo", empleado.Sueldo, dbType: DbType.Int32);
            parametros.Add("@MsgError",dbType: DbType.String, direction: ParameterDirection.Output,size: 100);

            using(var conn = new SqlConnection(_cadenaSql))
            {
                var response = await conn.ExecuteAsync(query, parametros, commandType: CommandType.StoredProcedure);
                return parametros.Get<string>("@MsgError");
            }

        }

        public async Task<String> EditarEmpleado(Empleado empleado)
        {
            string query = "sp_actualizar_empleado";
            var parametros = new DynamicParameters();
            parametros.Add("@EmpleadoID", empleado.EmpleadoID, dbType: DbType.Int32);
            parametros.Add("@Nombre", empleado.Nombre, dbType: DbType.String);
            parametros.Add("@NumeroDocumento", empleado.NumeroDocumento, dbType: DbType.String);
            parametros.Add("@Sueldo", empleado.Sueldo, dbType: DbType.Int32);
            parametros.Add("@MsgError", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);

            using (var conn = new SqlConnection(_cadenaSql))
            {
                var response = await conn.ExecuteAsync(query, parametros, commandType: CommandType.StoredProcedure);
                return parametros.Get<string>("@MsgError");
            }

        }

        public async Task<String> EliminarEmpleado(int id)
        {
            string query = "sp_eliminar_empleado";
            var parametros = new DynamicParameters();
            parametros.Add("@EmpleadoID", id, dbType: DbType.Int32);

            using (var conn = new SqlConnection(_cadenaSql))
            {
                var response = await conn.ExecuteAsync(query, parametros, commandType: CommandType.StoredProcedure);
                return "OK";
            }

        }
    }
}
