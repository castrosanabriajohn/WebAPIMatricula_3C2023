using API.Bll.Estudiante.Interfaces;

namespace API.Bll.Estudiante;
public class LnEstudiante
{
    private IAdEstudiante adEstudiante;

    public LnEstudiante(IAdEstudiante accesoDatosEstudiante)
    {
        this.adEstudiante = accesoDatosEstudiante;
    }

    public API.Dto.Estudiante.Salida.VerTodosEstudiantes VerTodosEstudiantes(Dto.Estudiante.Entrada.VerTodosEstudiantes pInformacion)
    {
        API.Dto.Estudiante.Salida.VerTodosEstudiantes respuesta = new API.Dto.Estudiante.Salida.VerTodosEstudiantes();

        try
        {
            respuesta = adEstudiante.VerTodosEstudiantes();
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message.ToString());
        }

        return respuesta;
    }

    public Dto.Estudiante.Salida.VerDetalleEstudiante VerDetalleEstudiante(Dto.Estudiante.Entrada.VerDetalleEstudiante pInformacion)
    {
        API.Dto.Estudiante.Salida.VerDetalleEstudiante respuesta = new Dto.Estudiante.Salida.VerDetalleEstudiante();

        try
        {
            respuesta = adEstudiante.VerDetalleEstudiante(pInformacion);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message.ToString());
        }

        return respuesta;
    }

    public API.Dto.Estudiante.Salida.AgregarEstudiante AgregarEstudiante(Dto.Estudiante.Entrada.AgregarEstudiante pInformacion)
    {
        API.Dto.Estudiante.Salida.AgregarEstudiante respuesta = new API.Dto.Estudiante.Salida.AgregarEstudiante();

        try
        {
            respuesta = adEstudiante.AgregarEstudiante(pInformacion);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message.ToString());
        }

        return respuesta;
    }

    public Dto.Estudiante.Salida.EditarEstudiante EditarEstudiante(Dto.Estudiante.Entrada.EditarEstudiante pInformacion)
    {
        API.Dto.Estudiante.Salida.EditarEstudiante respuesta = new API.Dto.Estudiante.Salida.EditarEstudiante();

        try
        {
            API.Dto.Estudiante.Entrada.VerDetalleEstudiante entradaVerDetalleEstudiante = new API.Dto.Estudiante.Entrada.VerDetalleEstudiante();
            entradaVerDetalleEstudiante.Codigo = pInformacion.Codigo;
            API.Dto.Estudiante.Salida.VerDetalleEstudiante detalleTrader = adEstudiante.VerDetalleEstudiante(entradaVerDetalleEstudiante);

            respuesta = adEstudiante.EditarEstudiante(pInformacion);

        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message.ToString());
        }

        return respuesta;
    }
    public Dto.Estudiante.Salida.EliminarEstudiante EliminarEstudiante(Dto.Estudiante.Entrada.EliminarEstudiante pInformacion)
    {
        API.Dto.Estudiante.Salida.EliminarEstudiante respuesta = new Dto.Estudiante.Salida.EliminarEstudiante();

        try
        {
            respuesta = adEstudiante.EliminarEstudiante(pInformacion);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message.ToString());
        }

        return respuesta;
    }
}

