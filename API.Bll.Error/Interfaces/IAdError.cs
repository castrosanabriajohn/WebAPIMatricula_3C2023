// Input alias
using AgregarEntrada = API.Dto.Error.Entrada.AgregarError;
// Output alias
using AgregarSalida = API.Dto.Error.Salida.AgregarError;
using VerTodosSalida = API.Dto.Error.Salida.VerTodosErrores;

namespace API.Bll.Error.Interfaces;

public interface IAdError
{
    AgregarSalida AgregarError(AgregarEntrada pInformacion);
    VerTodosSalida VerTodosErrores();
}