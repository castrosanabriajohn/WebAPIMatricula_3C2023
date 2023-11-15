namespace API.Dto.Factura.Salida;

public class EditarFactura : General.RespuestaAPI
{
    public int Codigo { get; set; }
    public string NumeroReferencia { get; set; }
    public int CodigoEstudiante { get; set; }
    public int CodigoCurso { get; set; }
    public int CodigoUltimoUsuarioModifica { get; set; }
    public DateTime FechaPago { get; set; }
    public int AnhoAcademico { get; set; }
    public int Cuatrimestre { get; set; }
    public decimal MontoTotal { get; set; }
    public string Estado { get; set; }
    public string Comentario { get; set; }
}