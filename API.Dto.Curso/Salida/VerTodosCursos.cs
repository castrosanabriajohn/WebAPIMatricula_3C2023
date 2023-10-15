namespace API.Dto.Curso.Salida;

public class VerTodosCursos : General.RespuestaAPI
{
    public List<DatosCurso> ListaCursos { get; set; }
    public VerTodosCursos()
    {
        ListaCursos = new List<DatosCurso>();
    }
}

public class DatosCurso
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string Creditos { get; set; }
    public string Horario { get; set; }
    public string Cupo { get; set; }
    public string Estado { get; set; }
}
