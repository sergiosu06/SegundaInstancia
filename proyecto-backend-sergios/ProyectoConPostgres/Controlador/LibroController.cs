using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoConPostgres.Conector;
using ProyectoConPostgres.Modelo;
using Npgsql;

namespace ProyectoConPostgres.Controlador
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController
    {
        private string db = Coneccion.conexionConPostgres();

        [HttpGet]
        public List<Libro> get()
        {
            List<Libro> libros= new List<Libro>();
            string select = "SELECT * FROM PUBLIC.\"Libro\"";

            using NpgsqlConnection connection = new NpgsqlConnection(db);
            try
            {
                connection.Open();
                Console.WriteLine("Conexion obtenida");
                NpgsqlCommand command = new NpgsqlCommand(select, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows) {
                    while (reader.Read())
                    {
                        Libro libro1 = new Libro();
                        libro1.IdLibro = int.Parse(reader.GetValue(0).ToString());
                        libro1.Titulo = reader.GetValue(1).ToString();
                        libro1.Editorial = reader.GetValue(2).ToString();
                        libro1.Costo = int.Parse(reader.GetValue(3).ToString()); ;
                        

                        libros.Add(libro1);
                    }
                }
                reader.Close();
            }
            catch(Exception exception) {
                Console.WriteLine(exception.Message);    
            }
            return libros;
        }
        [HttpPost]
        public Libro create([FromBody] Libro libro)
        {
            string select = "INSERT INTO public.\"Libro\"(\r\n\t\"IdLibro\", \"Titulo\", \"Editorial\", \"Costo\")\r\n\tVALUES (@IdLibro, @Titulo, @Editorial, @Costo);";

            using (NpgsqlConnection connection = new NpgsqlConnection(db))
            {
                NpgsqlCommand command = new NpgsqlCommand(select, connection);
                command.Parameters.AddWithValue("@IdLibro", libro.IdLibro);
                command.Parameters.AddWithValue("@Titulo", libro.Titulo);
                command.Parameters.AddWithValue("@Editorial", libro.Editorial);
                command.Parameters.AddWithValue("@Costo", libro.Costo);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            return libro;
        }

        [HttpDelete]
        public void delete(int idlIBRO)
        {
            string select = "DELETE FROM public.\"libro\"\r\n\tWHERE \"IdLibro\" = " + idlIBRO + ";";
      
            using (NpgsqlConnection connection = new NpgsqlConnection(db))
            {
                NpgsqlCommand command = new NpgsqlCommand(select, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("El libro fue eliminado");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
