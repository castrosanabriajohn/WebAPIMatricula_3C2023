// Input alias
using AgregarEntrada = API.Dto.Beca.Entrada.AgregarBeca;
using EditarEntrada = API.Dto.Beca.Entrada.EditarBeca;
using EliminarEntrada = API.Dto.Beca.Entrada.EliminarBeca;
using VerDetalleEntrada = API.Dto.Beca.Entrada.VerDetalleBeca;
// Output alias
using AgregarSalida = API.Dto.Beca.Salida.AgregarBeca;
using EditarSalida = API.Dto.Beca.Salida.EditarBeca;
using EliminarSalida = API.Dto.Beca.Salida.EliminarBeca;
using VerDetalleSalida = API.Dto.Beca.Salida.VerDetalleBeca;
using VerTodosSalida = API.Dto.Beca.Salida.VerTodasBecas;

namespace API.Bll.Beca.Interfaces;
public interface IAdBeca
{
    AgregarSalida AgregarBeca(AgregarEntrada pInformacion);
    EditarSalida EditarBeca(EditarEntrada pInformacion);
    EliminarSalida EliminarBeca(EliminarEntrada pInformacion);
    VerTodosSalida VerTodasBecas();
    VerDetalleSalida VerDetalleBeca(VerDetalleEntrada pInformacion);
}
