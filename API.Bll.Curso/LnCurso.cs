// Input alias directives
using AgregarCursoEntrada = API.Dto.Curso.Entrada.AgregarCurso;
using EditarCursoEntrada = API.Dto.Curso.Entrada.EditarCurso;
using VerDetalleCursoEntrada = API.Dto.Curso.Entrada.VerDetalleCurso;
using EliminarCursoEntrada = API.Dto.Curso.Entrada.EliminarCurso;
// Output alias directives
using AgregarCursoSalida = API.Dto.Curso.Salida.AgregarCurso;
using EditarCursoSalida = API.Dto.Curso.Salida.EditarCurso;
using VerTodosCursosSalida = API.Dto.Curso.Salida.VerTodosCursos;
using VerDetalleCursoSalida = API.Dto.Curso.Salida.VerDetalleCurso;
using EliminarCursoSalida = API.Dto.Curso.Salida.EliminarCurso;
using API.Bll.Curso.Interfaces;

namespace API.Bll.Curso
{
    public class LnCurso
    {
        private readonly IAdCurso _adCurso;

        public LnCurso(IAdCurso accesoDatosCurso)
        {
            _adCurso = accesoDatosCurso;
        }

        public AgregarCursoSalida AgregarCurso(AgregarCursoEntrada pInformacion)
        {
            try
            {
                return _adCurso.AgregarCurso(pInformacion);
            }
            catch (Exception ex)
            {
                var respuesta = new AgregarCursoSalida();
                respuesta.setErrorComunicacion(ex.Message.ToString());
                return respuesta;
            }
        }

        public EditarCursoSalida EditarCurso(EditarCursoEntrada pInformacion)
        {
            try
            {
                return _adCurso.EditarCurso(pInformacion);
            }
            catch (Exception ex)
            {
                var respuesta = new EditarCursoSalida();
                respuesta.setErrorComunicacion(ex.Message.ToString());
                return respuesta;
            }
        }

        public VerTodosCursosSalida VerTodosCursos()
        {
            try
            {
                return _adCurso.VerTodosCursos();
            }
            catch (Exception ex)
            {
                var respuesta = new VerTodosCursosSalida();
                respuesta.setErrorComunicacion(ex.Message.ToString());
                return respuesta;
            }
        }

        public VerDetalleCursoSalida VerDetalleCurso(VerDetalleCursoEntrada pInformacion)
        {
            try
            {
                return _adCurso.VerDetalleCurso(pInformacion);
            }
            catch (Exception ex)
            {
                var respuesta = new VerDetalleCursoSalida();
                respuesta.setErrorComunicacion(ex.Message.ToString());
                return respuesta;
            }
        }

        public EliminarCursoSalida EliminarCurso(EliminarCursoEntrada pInformacion)
        {
            try
            {
                return _adCurso.EliminarCurso(pInformacion);
            }
            catch (Exception ex)
            {
                var respuesta = new EliminarCursoSalida();
                respuesta.setErrorComunicacion(ex.Message.ToString());
                return respuesta;
            }
        }
    }
}
