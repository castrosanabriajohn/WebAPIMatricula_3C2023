// Input alias directives
using AgregarErrorEntrada = API.Dto.Error.Entrada.AgregarError;
// Output alias directives
using AgregarErrorSalida = API.Dto.Error.Salida.AgregarError;
using VerTodosErroresSalida = API.Dto.Error.Salida.VerTodosErrores;
using API.Bll.Error.Interfaces;

namespace API.Bll.Error
{
    public class LnError
    {
        private readonly IAdError _adError;

        public LnError(IAdError adError)
        {
            _adError = adError;
        }

        public AgregarErrorSalida AgregarError(AgregarErrorEntrada pInformacion)
        {
            var respuesta = new AgregarErrorSalida();

            try
            {
                respuesta = _adError.AgregarError(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public VerTodosErroresSalida VerTodosErrores()
        {
            var respuesta = new VerTodosErroresSalida();

            try
            {
                respuesta = _adError.VerTodosErrores();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
    }
}
