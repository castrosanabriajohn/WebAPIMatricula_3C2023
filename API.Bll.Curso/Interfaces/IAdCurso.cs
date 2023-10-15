namespace API.Bll.Curso.Interfaces;

public interface IAdCurso

{
    API.Dto.Curso.Salida.AgregarCurso AgregarCurso(API.Dto.Curso.Entrada.AgregarCurso pInformacion);

    API.Dto.Curso.Salida.EditarCurso EditarCurso(API.Dto.Curso.Entrada.EditarCurso pInformacion);

    API.Dto.Curso.Salida.EliminarCurso EliminarCurso(API.Dto.Curso.Entrada.EliminarCurso pInformacion);

    API.Dto.Curso.Salida.VerTodosCursos VerTodosCursos();

    API.Dto.Curso.Salida.VerDetalleCurso VerDetalleCurso(API.Dto.Curso.Entrada.VerDetalleCurso pInformacion);
}
