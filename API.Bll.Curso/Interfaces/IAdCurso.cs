// Input alias
using AgregarEntrada = API.Dto.Curso.Entrada.AgregarCurso;
using EditarEntrada = API.Dto.Curso.Entrada.EditarCurso;
using EliminarEntrada = API.Dto.Curso.Entrada.EliminarCurso;
using VerDetalleEntrada = API.Dto.Curso.Entrada.VerDetalleCurso;
// Output alias
using AgregarSalida = API.Dto.Curso.Salida.AgregarCurso;
using EditarSalida = API.Dto.Curso.Salida.EditarCurso;
using EliminarSalida = API.Dto.Curso.Salida.EliminarCurso;
using VerDetalleSalida = API.Dto.Curso.Salida.VerDetalleCurso;
using VerTodosSalida = API.Dto.Curso.Salida.VerTodosCursos;

namespace API.Bll.Curso.Interfaces;

public interface IAdCurso
{
    AgregarSalida AgregarCurso(AgregarEntrada pInformacion);

    EditarSalida EditarCurso(EditarEntrada pInformacion);

    EliminarSalida EliminarCurso(EliminarEntrada pInformacion);

    VerTodosSalida VerTodosCursos();

    VerDetalleSalida VerDetalleCurso(VerDetalleEntrada pInformacion);
}
