namespace API.Dto.Factura.Salida;

public class VerTodasFacturas : General.RespuestaAPI
{
    public List<DatosFactura> ListaFacturas { get; set; }
    public VerTodasFacturas()
    {
        ListaFacturas = new List<DatosFactura>();
    }
}

public class DatosFactura
{
    public int Codigo { get; set; }
    public string NumeroReferencia { get; set; }
    //public int CodigoEstudiante { get; set; }
    public string NombreEstudiante { get; set; }
    //public int CodigoCurso { get; set; }
    public string NombreCurso { get; set; }
    //public int CodigoUsuarioCrea { get; set; }
    public DateTime FechaPago { get; set; }
    public int AnhoAcademico { get; set; }
    public int Cuatrimestre { get; set; }
    public decimal MontoTotal { get; set; }
    public string Estado { get; set; }
    public string Comentario { get; set; }
}
