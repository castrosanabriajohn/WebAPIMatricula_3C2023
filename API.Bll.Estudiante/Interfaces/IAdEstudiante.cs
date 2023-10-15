namespace API.Bll.Estudiante.Interfaces;

public interface IAdEstudiante
{
    API.Dto.Estudiante.Salida.AgregarEstudiante AgregarEstudiante(API.Dto.Estudiante.Entrada.AgregarEstudiante pInformacion);
    API.Dto.Estudiante.Salida.EditarEstudiante EditarEstudiante(API.Dto.Estudiante.Entrada.EditarEstudiante pInformacion);
    API.Dto.Estudiante.Salida.EliminarEstudiante EliminarEstudiante(API.Dto.Estudiante.Entrada.EliminarEstudiante pInformacion);
    API.Dto.Estudiante.Salida.VerTodosEstudiantes VerTodosEstudiantes();
    API.Dto.Estudiante.Salida.VerDetalleEstudiante VerDetalleEstudiante(API.Dto.Estudiante.Entrada.VerDetalleEstudiante pInformacion);
}