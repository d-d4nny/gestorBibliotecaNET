using gestorBiblioteca.Models;
using Npgsql;

namespace gestorBiblioteca.Services
{
    public interface IntzCRUD
    {
        /// <summary>
        /// Método para insertar libros en la base de datos.
        /// </summary>
        /// <param name="conexionGenerada">Objeto NpgsqlConnection que representa la conexión a la base de datos.</param>
        /// <returns>Lista de objetos LibroDto que representan los libros insertados.</returns>
        List<Usuarios> InsertarLibros(NpgsqlConnection conexionGenerada);
    }
}
