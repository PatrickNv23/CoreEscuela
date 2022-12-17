// See https://aka.ms/new-console-template for more information
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Interfaces;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela{
    internal class Program
    {
        static void Main(String[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => Printer.pitar(2000, 1000, 1);

            var EscuelaEngine = new EscuelaEngine();
            EscuelaEngine.Inicializar();
            Printer.DibujarTitulo("Bienvenidos a la Escuela");

            var reportador = new Reportador(EscuelaEngine.obtenerDiccionarObjetosEscuela());
            var listaEvaluaciones = reportador.obtenerListaEvaluaciones();
            var listaAsignaturas = reportador.obtenerListaAsignaturas();
            var listaEvaluacionesAsignatura = reportador.obtenerDiccionarioEvaluacionesPorAsignatura();
            var listaPromedioAlumnoAsignatura = reportador.obtenerPromedioAlumnosPorAsignatura();

            Printer.DibujarTitulo("Captura de una Evaluación por consola");

            var nuevaEvaluación = new Evaluacion();
            string nombre, nota;



            WriteLine("Ingrese el nombre de la evaluación: ");
            Printer.presionarEnter();
            nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El valor del nombre no puede ser vacío");
            }
            else
            {
                nuevaEvaluación.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluación ha sido ingresada correctamente");
            }




            WriteLine("Ingrese la nota de la evaluación: ");
            Printer.presionarEnter();
            nota = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                WriteLine("La nota de la evaluación no puede ser vacio");
                WriteLine("Saliendo del programa");
            }
            else
            {
                try
                {
                    nuevaEvaluación.Nota = float.Parse(nota);
                    if(nuevaEvaluación.Nota <0 || nuevaEvaluación.Nota > 5)
                    {
                        throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                    }
                    WriteLine("La nota de la evaluación ha sido creada correctamente");
                    return;
                }
                catch (ArgumentOutOfRangeException excepcion)
                {
                    WriteLine(excepcion.Message);
                }
                catch (Exception)
                {
                    Printer.DibujarTitulo("El valor de la nota no es un número válido");
                    WriteLine("Saliendo del programa");
                }
                finally
                {
                    Printer.DibujarTitulo("FINALLY");
                    Printer.pitar(2500, 500, 3);
                }
                
                
            }

        }


        private static void AccionDelEvento(object? sender, EventArgs e)
        {
            Printer.DibujarTitulo("SALIENDO");
            Printer.pitar(3000, 1000, 3);
            Printer.DibujarTitulo("SALIÓ!!!");
        }

        private static void imprimirCursosEscuela(Escuela escuela)
        {
            WriteLine(escuela);
            Printer.DibujarTitulo($"Curso de Escuela {escuela.Nombre}");

            if (escuela?.Cursos != null)
            {
                foreach (Curso curso in escuela.Cursos)
                {
                    WriteLine($"{curso.Nombre} - Id: {curso.Id}");
                }
            }
        }

    }
}
