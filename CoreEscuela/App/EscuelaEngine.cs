using CoreEscuela.Entidades;
using System;
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



        public List<ObjetoEscuelaBase> obtenerObjetosEscuelaBase()
        {
            var listaObjetosEscuelaBase = new List<ObjetoEscuelaBase>
            {
                Escuela
            };
            listaObjetosEscuelaBase.AddRange(Escuela.Cursos);
            foreach (var Curso in Escuela.Cursos)
            {
                listaObjetosEscuelaBase.AddRange(Curso.Alumnos);
                listaObjetosEscuelaBase.AddRange(Curso.Asignaturas);

                foreach (var Alumno in Curso.Alumnos)
                {
                    listaObjetosEscuelaBase.AddRange(Alumno.Evaluaciones);
                }
            }

            return listaObjetosEscuelaBase;
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
                                Nota = (float)(5 * random.NextDouble()),
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
