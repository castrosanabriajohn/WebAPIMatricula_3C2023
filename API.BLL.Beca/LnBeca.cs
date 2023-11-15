// Input alias directives
using EditarBecaEntrada = API.Dto.Beca.Entrada.EditarBeca;
using EliminarBecaEntrada = API.Dto.Beca.Entrada.EliminarBeca;
using VerDetalleBecaEntrada = API.Dto.Beca.Entrada.VerDetalleBeca;
using VerTodasBecasEntrada = API.Dto.Beca.Entrada.VerTodasBecas;
using AgregarBecaEntrada = API.Dto.Beca.Entrada.AgregarBeca;

// Output alias directives
using AgregarBecaSalida = API.Dto.Beca.Salida.AgregarBeca;
using EditarBecaSalida = API.Dto.Beca.Salida.EditarBeca;
using EliminarBecaSalida = API.Dto.Beca.Salida.EliminarBeca;
using VerDetalleBecaSalida = API.Dto.Beca.Salida.VerDetalleBeca;
using VerTodasBecasSalida = API.Dto.Beca.Salida.VerTodasBecas;

using API.Bll.Beca.Interfaces;

namespace API.Bll.Beca;

public class LnBeca
{
    private IAdBeca _adBeca;

    public LnBeca(IAdBeca adBeca)
    {
        _adBeca = adBeca;
    }

    public VerTodasBecasSalida VerTodasBecas(VerTodasBecasEntrada pInformacion)
    {
        var respuesta = new VerTodasBecasSalida();

        try
        {
            respuesta = _adBeca.VerTodasBecas();
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message.ToString());
        }

        return respuesta;
    }

    public VerDetalleBecaSalida VerDetalleBeca(VerDetalleBecaEntrada pInformacion)
    {
        var respuesta = new VerDetalleBecaSalida();

        try
        {
            respuesta = _adBeca.VerDetalleBeca(pInformacion);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message.ToString());
        }

        return respuesta;
    }

    public AgregarBecaSalida AgregarBeca(AgregarBecaEntrada pInformacion)
    {
        var respuesta = new AgregarBecaSalida();

        try
        {
            respuesta = _adBeca.AgregarBeca(pInformacion);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message.ToString());
        }

        return respuesta;
    }

    public EditarBecaSalida EditarBeca(EditarBecaEntrada pInformacion)
    {
        var respuesta = new EditarBecaSalida();

        try
        {
            VerDetalleBecaEntrada verDetalleEntrada = new()
            {
                Codigo = pInformacion.Codigo
            };

            VerDetalleBecaSalida verDetalleSalida = _adBeca.VerDetalleBeca(verDetalleEntrada);

            respuesta = _adBeca.EditarBeca(pInformacion);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message.ToString());
        }

        return respuesta;
    }

    public EliminarBecaSalida EliminarBeca(EliminarBecaEntrada pInformacion)
    {
        var respuesta = new EliminarBecaSalida();

        try
        {
            respuesta = _adBeca.EliminarBeca(pInformacion);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message.ToString());
        }

        return respuesta;
    }
}
