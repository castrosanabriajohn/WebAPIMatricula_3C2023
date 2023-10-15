namespace API.Dto.Estudiante.Entrada;

public class EditarEstudiante : Dto.General.EntradaAPI
{
    public int Codigo { get; set; }
    public string Identificacion { get; set; }
    public string NombreCompleto { get; set; }
    public string CorreoElectronico { get; set; }
    public string Estado { get; set; }
}