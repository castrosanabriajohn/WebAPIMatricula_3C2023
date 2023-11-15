namespace API.Dto.Factura.Entrada;

public class AgregarFactura : API.Dto.General.EntradaAPI
{
    public string NumeroReferencia { get; set; }
    public int CodigoEstudiante { get; set; }
    public int CodigoCurso { get; set; }
    public int CodigoUsuarioCrea { get; set; }
    public DateTime FechaPago { get; set; }
    public int AnhoAcademico { get; set; }
    public int Cuatrimestre { get; set; }
    public decimal MontoTotal { get; set; }
    public string Estado { get; set; }
    public string Comentario { get; set; }

}
