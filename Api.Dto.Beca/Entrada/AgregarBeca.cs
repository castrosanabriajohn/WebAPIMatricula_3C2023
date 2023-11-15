namespace API.Dto.Beca.Entrada;

public class AgregarBeca : API.Dto.General.EntradaAPI
{
    public int CodigoEstudiante { get; set; }
    public int CodigoCurso { get; set; }
    public int CodigoUsuarioCrea { get; set; }
    public string Tipo { get; set; }
    public int Porcentaje { get; set; }
    public decimal Monto { get; set; }
    public int AnhoAcademico { get; set; }
    public string Estado { get; set; }
    public string Comentario { get; set; }

}
