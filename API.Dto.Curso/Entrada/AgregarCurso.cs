﻿namespace API.Dto.Curso.Entrada;

public class AgregarCurso : General.EntradaAPI
{
    public string Nombre { get; set; }
    public string Creditos { get; set; }
    public string Horario { get; set; }
    public string Cupo { get; set; }
    public string Estado { get; set; }
}
