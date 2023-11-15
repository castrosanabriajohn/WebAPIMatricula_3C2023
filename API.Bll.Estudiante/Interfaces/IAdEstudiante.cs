// Input alias
using AgregarEntrada = API.Dto.Estudiante.Entrada.AgregarEstudiante;
using EditarEntrada = API.Dto.Estudiante.Entrada.EditarEstudiante;
using EliminarEntrada = API.Dto.Estudiante.Entrada.EliminarEstudiante;
using VerDetalleEntrada = API.Dto.Estudiante.Entrada.VerDetalleEstudiante;
// Output alias
using AgregarSalida = API.Dto.Estudiante.Salida.AgregarEstudiante;
using EditarSalida = API.Dto.Estudiante.Salida.EditarEstudiante;
using EliminarSalida = API.Dto.Estudiante.Salida.EliminarEstudiante;
using VerDetalleSalida = API.Dto.Estudiante.Salida.VerDetalleEstudiante;
using VerTodosSalida = API.Dto.Estudiante.Salida.VerTodosEstudiantes;

namespace API.Bll.Estudiante.Interfaces;
public interface IAdEstudiante
{
    AgregarSalida AgregarEstudiante(AgregarEntrada pInformacion);
    EditarSalida EditarEstudiante(EditarEntrada pInformacion);
    EliminarSalida EliminarEstudiante(EliminarEntrada pInformacion);
    VerTodosSalida VerTodosEstudiantes();
    VerDetalleSalida VerDetalleEstudiante(VerDetalleEntrada pInformacion);
}
