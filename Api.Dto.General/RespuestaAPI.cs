namespace API.Dto.General;

public class RespuestaAPI
{
    protected const int CODIGO_ERROR = -1;
    protected const int CODIGO_EXITOSO = 0;

    protected const string TRANSACCION_EXITOSA = "Transacción exitosa";
    protected const string ERROR_APLICACION = "Ocurrió un error la aplicación";

    public int CodigoRespuesta { get; set; }
    public string DetalleRespuesta { get; set; }
    public string DetalleTecnico { get; set; }

    public RespuestaAPI()
    {
        CodigoRespuesta = CODIGO_EXITOSO;
        DetalleRespuesta = TRANSACCION_EXITOSA;
        DetalleTecnico = string.Empty;
    }

    public void setErrorComunicacion(String error)
    {
        CodigoRespuesta = CODIGO_ERROR;
        DetalleRespuesta = ERROR_APLICACION;
        DetalleTecnico = error;
    }
}