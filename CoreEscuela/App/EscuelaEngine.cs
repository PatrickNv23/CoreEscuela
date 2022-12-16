using CoreEscuela.Entidades;
using CoreEscuela.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.App
{
    internal sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            this.Escuela = new Escuela("Platzi Academy", 2012, TipoEscuela.Secundaria, pais: "Colombia", ciudad: "Bogotá");

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        public void imprimirDiccionario(Dictionary<EnumDiccionario,IEnumerable<ObjetoEscuelaBase>> diccionario, bool imprimeEvaluaciones = false)
        {
            foreach (var objeto in diccionario)
            {
                Printer.DibujarTitulo(objeto.Key.ToString());

                foreach (var objKey in objeto.Value)
                {
                    switch (objeto.Key)
                    {
                        case EnumDiccionario.Evaluacion:
                            if (imprimeEvaluaciones)
                            {
                                Console.WriteLine(objKey);
                            }
                            break;
                        case EnumDiccionario.Escuela:
                            Console.WriteLine("Escuela: " +objKey);
                            break;
                        case EnumDiccionario.Alumno:
                            Console.WriteLine("Alumno: " + objKey.Nombre);
                            break;
                        case EnumDiccionario.Curso:
                            var cursoTemporal = objKey as Curso;
                            if (cursoTemporal  != null)
                            {
                                int contador = cursoTemporal.Alumnos.Count;
                                Console.WriteLine("Curso: " + objKey.Nombre + " Cantidad de alumnos: " +contador);
                            }
                            break;
                        default:
                            Console.WriteLine(objKey);
                            break;

                    }
                    if(imprimeEvaluaciones && objKey is Evaluacion)
                    {
                    }
                    else
                    {
                        Console.WriteLine(objKey);
                    }
                }
            }
        }

        // Objetos de Escuela con diccionarios
        public Dictionary<EnumDiccionario, IEnumerable<ObjetoEscuelaBase>> obtenerDiccionarObjetosEscuela()
        {
            Dictionary<EnumDiccionario, IEnumerable<ObjetoEscuelaBase>> diccionarioEscuela = 
                new Dictionary<EnumDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            diccionarioEscuela.Add(EnumDiccionario.Escuela, new[] { Escuela });
            diccionarioEscuela.Add(EnumDiccionario.Curso,Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            
            var listaTemporalEvaluaciones = new List<Evaluacion>();
            var listaTemporalAsignaturas = new List<Asignatura>();
            var listaTemporalAlumnos = new List<Alumno>();

            foreach (var curso in Escuela.Cursos)
            {

                listaTemporalAsignaturas.AddRange(curso.Asignaturas);
                listaTemporalAlumnos.AddRange(curso.Alumnos);
                foreach (var alumno in curso.Alumnos)
                {
                    listaTemporalEvaluaciones.AddRange(alumno.Evaluaciones);  
                }
            }
            diccionarioEscuela.Add(EnumDiccionario.Evaluacion, listaTemporalEvaluaciones.Cast<ObjetoEscuelaBase>());
            diccionarioEscuela.Add(EnumDiccionario.Asignatura, listaTemporalAsignaturas.Cast<ObjetoEscuelaBase>());
            diccionarioEscuela.Add(EnumDiccionario.Alumno, listaTemporalAlumnos.Cast<ObjetoEscuelaBase>());

            return diccionarioEscuela;
        }



        // con esta modificación del método podemos traer objetos según sus parámetros
        // Ejemplo: En caso contieneAlumnos sea falso ya no obtendría los objetos alumno.
        // Sobrecarga de métodos

        public IReadOnlyList<ObjetoEscuelaBase> obtenerObjetosEscuelaBase(
            out int conteoEvaluaciones,
            bool contieneEvaluaciones = true,
            bool contieneAlumnos = true,
            bool contieneAsignaturas = true,
            bool contieneCursos = true)
        {
            return obtenerObjetosEscuelaBase(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> obtenerObjetosEscuelaBase(
            bool contieneEvaluaciones = true,
            bool contieneAlumnos = true,
            bool contieneAsignaturas = true,
            bool contieneCursos = true)
        {
            return obtenerObjetosEscuelaBase(out int dummy, out dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> obtenerObjetosEscuelaBase
            (
            out int conteoEvaluaciones,
            out int conteoAsignaturas,
            out int conteoAlumnos,
            out int conteoCursos,
            bool contieneEvaluaciones = true,
            bool contieneAlumnos = true,
            bool contieneAsignaturas = true,
            bool contieneCursos = true
            )
        {
            conteoEvaluaciones = conteoAsignaturas = conteoAlumnos = conteoCursos = 0;

            var listaObjetosEscuelaBase = new List<ObjetoEscuelaBase>
            {
                Escuela
            };
            if (contieneCursos)
            {
             listaObjetosEscuelaBase.AddRange(Escuela.Cursos);
                conteoCursos = Escuela.Cursos.Count;
            }

            foreach (var Curso in Escuela.Cursos)
            {
                conteoAlumnos += Curso.Alumnos.Count;
                conteoAsignaturas += Curso.Asignaturas.Count;

                if (contieneAlumnos)
                {
                    listaObjetosEscuelaBase.AddRange(Curso.Alumnos);
                }
                if (contieneAsignaturas)
                {
                    listaObjetosEscuelaBase.AddRange(Curso.Asignaturas);
                }

                if (contieneEvaluaciones)
                {
                    foreach (var Alumno in Curso.Alumnos)
                    {
                        conteoEvaluaciones += Alumno.Evaluaciones.Count;
                        listaObjetosEscuelaBase.AddRange(Alumno.Evaluaciones);
                    }
                }

               
            }
            return listaObjetosEscuelaBase.AsReadOnly();
        }


        #region Métodos de carga
        public void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var random = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var evaluacion = new Evaluacion()
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Evaluación#{i + 1}",
                                Nota = (float) Math.Round(5 * random.NextDouble(),2),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(evaluacion);
                        }
                    }
                }
            }
        }

        public void CargarAsignaturas()
        {
            foreach (var Curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura(){ Nombre = "Matemática"},
                    new Asignatura(){ Nombre = "Educación Física"},
                    new Asignatura(){Nombre = "Inglés"},
                    new Asignatura(){Nombre = "Ciencias Naturales"}
                };

                Curso.Asignaturas = listaAsignaturas;
            }
        }

        public List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            String[] nombre1 = { "Alba", "Pepe", "Juan", "Tom", "Enrique", "José", "Luis" };
            String[] apellido1 = { "Hernandez", "Thomás", "Vasquez", "Pizarro", "Lopez", "Rios", "Gonzales" };
            String[] nombre2 = { "Freddy", "Jacky", "Angel", "Kathy", "Carlos", "Pedro", "Ana" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((alumno) => alumno.Id).Take(cantidad).ToList();
        }

        public void CargarCursos()
        {
            this.Escuela.Cursos = new List<Curso>()
            {
                new Curso() { Nombre = "Curso 1", Jornada = TipoJornada.Mañana},
                new Curso(){Nombre = "Curso 2", Jornada = TipoJornada.Tarde},
                new Curso(){Nombre = "Curso 3", Jornada = TipoJornada.Noche},
                new Curso(){ Nombre = "Curso 4" , Jornada = TipoJornada.Noche},
                new Curso() { Nombre = "Curso 5", Jornada = TipoJornada.Tarde },
            };
            Random random = new Random();
            
            foreach (var curso in Escuela.Cursos)
            {
                int cantidadRandom = random.Next(5, 20);
                curso.Alumnos = GenerarAlumnosAlAzar(cantidadRandom);
            }
        }

        #endregion


    }
}
