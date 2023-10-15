namespace API.Dto.Curso.Entrada;
public class EditarCurso : General.EntradaAPI
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string Creditos { get; set; }
    public string Horario { get; set; }
    public string Cupo { get; set; }
    public string Estado { get; set; }
}
