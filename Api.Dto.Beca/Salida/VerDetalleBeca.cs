﻿namespace API.Dto.Beca.Salida;

public class VerDetalleBeca : General.RespuestaAPI
{
    public int Codigo { get; set; }
    //public int CodigoEstudiante { get; set; }
    public string NombreEstudiante { get; set; }
    //public int CodigoCurso { get; set; }
    public string NombreCurso { get; set; }
    
    public int CodigoUsuarioCrea { get; set; }
    public string Tipo { get; set; }
    public int Porcentaje { get; set; }
    public decimal Monto { get; set; }
    public int AnhoAcademico { get; set; }
    public string Estado { get; set; }
    public string Comentario { get; set; }
}