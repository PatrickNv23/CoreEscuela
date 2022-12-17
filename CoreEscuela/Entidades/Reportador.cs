using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    internal class Reportador
    {
        Dictionary<EnumDiccionario, IEnumerable<ObjetoEscuelaBase>> DiccionarioObjetos;

        public Reportador(Dictionary<EnumDiccionario, IEnumerable<ObjetoEscuelaBase>> diccionario)
        {
            if(diccionario == null)
            {
                throw new ArgumentNullException(nameof(diccionario));
            }
            this.DiccionarioObjetos = diccionario;
        }

        public IEnumerable<Evaluacion> obtenerListaEvaluaciones()
        {
            IEnumerable<Evaluacion> respuesta;
            if(this.DiccionarioObjetos.TryGetValue(EnumDiccionario.Evaluacion, 
                out IEnumerable<ObjetoEscuelaBase> listaEvaluaciones))
            {
                respuesta = listaEvaluaciones.Cast<Evaluacion>();
            }
            else
            {
                respuesta = new List<Evaluacion>();
            }

            return respuesta;
        }

        public IEnumerable<String> obtenerListaAsignaturas
           ()
        {
            return obtenerListaAsignaturas(out var dummy);
        }


            public IEnumerable<String> obtenerListaAsignaturas
            (out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = obtenerListaEvaluaciones();

            return (from ev in listaEvaluaciones
                   select ev.Asignatura.Nombre).Distinct();
        }


        public Dictionary<String, IEnumerable<Evaluacion>> obtenerDiccionarioEvaluacionesPorAsignatura()
        {
            Dictionary<String, IEnumerable<Evaluacion>> diccionarioRespuesta = 
                new Dictionary<string, IEnumerable<Evaluacion>>();

            var listaAsignaturas = obtenerListaAsignaturas(out var listaEvaluaciones);

            foreach (var asignatura in listaAsignaturas)
            {
                var evaluacionesAsignatura = from ev in listaEvaluaciones
                                             where ev.Asignatura.Nombre == asignatura
                                             select ev;
                diccionarioRespuesta.Add(asignatura, evaluacionesAsignatura);
            }

            return diccionarioRespuesta;

        }

        public Dictionary<String, IEnumerable<object>> obtenerPromedioAlumnosPorAsignatura()
        {
            var respuesta = new Dictionary<String, IEnumerable<object>>();
            var evaluacionesPorAsignatura = obtenerDiccionarioEvaluacionesPorAsignatura();

            foreach (var asignaturaConEvaluacion in evaluacionesPorAsignatura)
            {
                var promediosAlumno = from evaluacion in asignaturaConEvaluacion.Value
                                      group evaluacion by new
                                      {
                                          evaluacion.Alumno.Id,
                                          evaluacion.Alumno.Nombre
                                      }
                            into grupoEvaluacionesAlumno
                                      select new AlumnoPromedio
                                      {
                                          Promedio = grupoEvaluacionesAlumno.Average(eval => eval.Nota),
                                          AlumnoId = grupoEvaluacionesAlumno.Key.Id,
                                          AlumnoNombre = grupoEvaluacionesAlumno.Key.Nombre
                            };

                respuesta.Add(asignaturaConEvaluacion.Key, promediosAlumno);
            }

            return respuesta;
        }
        
    }
}
