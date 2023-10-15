namespace API.Bll.Error.Interfaces;

public interface IAdError
{
    API.Dto.Error.Salida.VerTodosErrores VerTodosErrores();
    API.Dto.Error.Salida.AgregarError AgregarError(API.Dto.Error.Entrada.AgregarError pInformacion);
}