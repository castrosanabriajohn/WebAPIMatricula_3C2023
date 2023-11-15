// Input alias directives
using EditarEstudianteEntrada = API.Dto.Estudiante.Entrada.EditarEstudiante;
using EliminarEstudianteEntrada = API.Dto.Estudiante.Entrada.EliminarEstudiante;
using VerDetalleEstudianteEntrada = API.Dto.Estudiante.Entrada.VerDetalleEstudiante;
using VerTodosEstudiantesEntrada = API.Dto.Estudiante.Entrada.VerTodosEstudiantes;
using AgregarEstudianteEntrada = API.Dto.Estudiante.Entrada.AgregarEstudiante;

// Output alias directives
using AgregarEstudianteSalida = API.Dto.Estudiante.Salida.AgregarEstudiante;
using EditarEstudianteSalida = API.Dto.Estudiante.Salida.EditarEstudiante;
using EliminarEstudianteSalida = API.Dto.Estudiante.Salida.EliminarEstudiante;
using VerDetalleEstudianteSalida = API.Dto.Estudiante.Salida.VerDetalleEstudiante;
using VerTodosEstudiantesSalida = API.Dto.Estudiante.Salida.VerTodosEstudiantes;

using API.Bll.Estudiante.Interfaces;

namespace API.Bll.Estudiante
{
    public class LnEstudiante
    {
        private IAdEstudiante _adEstudiante;

        public LnEstudiante(IAdEstudiante adEstudiante)
        {
            _adEstudiante = adEstudiante;
        }

        public VerTodosEstudiantesSalida VerTodosEstudiantes(VerTodosEstudiantesEntrada pInformacion)
        {
            var respuesta = new VerTodosEstudiantesSalida();

            try
            {
                respuesta = _adEstudiante.VerTodosEstudiantes();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public VerDetalleEstudianteSalida VerDetalleEstudiante(VerDetalleEstudianteEntrada pInformacion)
        {
            var respuesta = new VerDetalleEstudianteSalida();

            try
            {
                respuesta = _adEstudiante.VerDetalleEstudiante(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public AgregarEstudianteSalida AgregarEstudiante(AgregarEstudianteEntrada pInformacion)
        {
            var respuesta = new AgregarEstudianteSalida();

            try
            {
                respuesta = _adEstudiante.AgregarEstudiante(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public EditarEstudianteSalida EditarEstudiante(EditarEstudianteEntrada pInformacion)
        {
            var respuesta = new EditarEstudianteSalida();

            try
            {
                VerDetalleEstudianteEntrada verDetalleEntrada = new()
                {
                    Codigo = pInformacion.Codigo
                };

                VerDetalleEstudianteSalida verDetalleSalida = _adEstudiante.VerDetalleEstudiante(verDetalleEntrada);

                respuesta = _adEstudiante.EditarEstudiante(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public EliminarEstudianteSalida EliminarEstudiante(EliminarEstudianteEntrada pInformacion)
        {
            var respuesta = new EliminarEstudianteSalida();

            try
            {
                respuesta = _adEstudiante.EliminarEstudiante(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
    }
}
