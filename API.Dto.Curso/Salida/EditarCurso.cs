namespace API.Dto.Curso.Salida;

public class EditarCurso : General.RespuestaAPI
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string Creditos { get; set; }
    public string Horario { get; set; }
    public string Cupo { get; set; }
    public string Estado { get; set; }
}