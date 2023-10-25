using gestorBiblioteca.Services;
using Npgsql; // Importa la clase Npgsql para trabajar con NpgsqlConnection
using System;
using System.Configuration;

namespace gestorBiblioteca.Services
{
    public class ImplConexion : IntzConexion
    {

        private readonly IConfiguration _configuration; // Agrega una referencia a IConfiguration

        public ImplConexion(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Genera una conexión a la base de datos utilizando la cadena de conexión a PostgreSQL especificada en la configuración.
        /// </summary>
        /// <returns>Objeto NpgsqlConnection que representa la conexión a la base de datos.</returns>
        public NpgsqlConnection GeneraConexion()
        {
            string stringConexionPostgresql = _configuration.GetConnectionString("stringConexion");

            NpgsqlConnection conexion = null;
            string estado = "";

            if (!string.IsNullOrWhiteSpace(stringConexionPostgresql))
            {
                try
                {
                    conexion = new NpgsqlConnection(stringConexionPostgresql);
                    conexion.Open();
                    estado = conexion.State.ToString();

                    if (estado.Equals("Open"))
                    {
                        Console.WriteLine("[INFORMACIÓN-CrudImplementacion-generarConexionPostgresql] Estado conexión: " + estado);
                    }
                    else
                    {
                        conexion = null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERROR-CrudImplementacion-generarConexionPostgresql] Error al generar la conexión:" + e);
                    conexion = null;
                    return conexion;
                }
            }

            return conexion;
        }
    }
}
