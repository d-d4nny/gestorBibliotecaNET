using gestorBiblioteca.Models;
using gestorBiblioteca.Services.EjercicioConexionbdCRUD.servicios;
using Npgsql;
using System.Net;

namespace gestorBiblioteca.Services
{
    public class ImplCRUD : IntzCRUD
    {
        // Instanciar implementaciones de las interfaces para usar en la aplicación
        ImplMenus intM = new ImplMenus();
        List<Usuarios> listaLibros = new List<Usuarios>();

        // Métodos para la operación de inserción

        /// <summary>
        /// Permite insertar libros en la base de datos.
        /// </summary>
        /// <param name="conexionGenerada">Conexión a la base de datos.</param>
        /// <returns>Lista de libros insertados.</returns>

        public List<Usuarios> InsertarLibros(NpgsqlConnection conexionGenerada)
        {
            bool cerrarMenu = false; // Variable para controlar la salida del bucle del menú
            int opcion; // Variable para almacenar la opción elegida por el usuario

            try
            {
                do
                {
                    intM.MostrarMenuInsert(); // Mostrar el menú de inserción
                    Console.WriteLine("Introduce una opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine()); // Leer la opción del usuario

                    switch (opcion)
                    {
                        case 1:
                            // Inserción de un solo libro
                            Console.Write("Ingrese el DNI del nuevo usuario: ");
                            string dni = Console.ReadLine();

                            Console.Write("Ingrese el nombre del nuevo usuario: ");
                            string nombre = Console.ReadLine();

                            Console.Write("Ingrese los apellidos del nuevo usuario: ");
                            string apellidos = Console.ReadLine();

                            Console.Write("Ingrese el teléfono del nuevo usuario: ");
                            string telefono = Console.ReadLine();

                            Console.Write("Ingrese el correo electrónico del nuevo usuario: ");
                            string correo = Console.ReadLine();

                            Console.Write("Ingrese la clave del nuevo usuario: ");
                            string clave = Console.ReadLine();

                            Console.Write("Ingrese el ID de acceso del nuevo usuario: ");
                            long idAcceso = Convert.ToInt64(Console.ReadLine());

                            Console.Write("¿El usuario está bloqueado? (true/false): ");
                            bool estaBloqueado = Convert.ToBoolean(Console.ReadLine());

                            try
                            {
                                // Query de inserción para un solo libro
                                string query = $"INSERT INTO gbp_operacional.\"Usuarios\" (dni_usuario, nombre_usuario, apellidos_usuario, tlf_usuario, email_usuario, clave_usuario, id_acceso, \"estaBloqueado_usuario\") VALUES ('{dni}', '{nombre}', '{apellidos}', '{telefono}', '{correo}', '{clave}', {idAcceso}, {estaBloqueado})";

                                using (var comandoSQL = new NpgsqlCommand(query, conexionGenerada))
                                {
                                    int filasAfectadas = comandoSQL.ExecuteNonQuery();

                                    // Mostrar el resultado de la inserción
                                    if (filasAfectadas > 0)
                                    {
                                        Console.WriteLine("Nuevo libro agregado exitosamente.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se pudo agregar el nuevo libro.");
                                    }
                                }
                            }
                            catch (NpgsqlException e)
                            {
                                Console.WriteLine("[ERROR] Error al agregar un nuevo libro: " + e);
                            }

                            break;
                        case 2:
                            cerrarMenu = true; // Cerrar el menú
                            break;
                        default:
                            Console.WriteLine("\n**[ERROR] Opción elegida no disponible **");
                            break;
                    }

                } while (!cerrarMenu); // Continuar hasta que el usuario decida cerrar el menú
            }
            catch (FormatException e)
            {
                Console.WriteLine("\n**[ERROR] Entrada inválida: por favor ingrese un número entero **");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n**[ERROR] Ocurrió una excepción no esperada: " + e.Message + " **");
            }

            return listaLibros; // Devolver la lista de libros actualizada
        }
    }
}
