using System;
using ProyectoConPostgres.Conector;
using ProyectoConPostgres.Modelo;

using ProyectoConPostgres.Controlador;

namespace ProyectoConPostgres
{
    public class Program {
        public static void Main()
        {
            LibroController libroController = new LibroController(); ;
           
            Libro libro = new Libro() 
            {  IdLibro = 1, 
                Titulo = "en busqueda de la felicidad", 
                Editorial = "Don bosquo", 
                Costo = 50,
            };
            Libro LIBRO = libroController.create(libro);
            libroController.delete(1);
            List<Libro> librosList = libroController.get();

            for(int i=0; i< librosList.Count; i++)
            {
                Console.WriteLine("El id es: " + librosList[i].IdLibro);
                Console.WriteLine("El titulo es: " + librosList[i].Titulo);
                Console.WriteLine("El editorial es: " + librosList[i].Editorial);
                Console.WriteLine("El costo es: " + librosList[i].Costo);
            }
        }
    }
}
