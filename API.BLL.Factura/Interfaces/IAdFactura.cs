// Input alias
using AgregarEntrada = API.Dto.Factura.Entrada.AgregarFactura;
using EditarEntrada = API.Dto.Factura.Entrada.EditarFactura;
using EliminarEntrada = API.Dto.Factura.Entrada.EliminarFactura;
using VerDetalleEntrada = API.Dto.Factura.Entrada.VerDetalleFactura;
// Output alias
using AgregarSalida = API.Dto.Factura.Salida.AgregarFactura;
using EditarSalida = API.Dto.Factura.Salida.EditarFactura;
using EliminarSalida = API.Dto.Factura.Salida.EliminarFactura;
using VerDetalleSalida = API.Dto.Factura.Salida.VerDetalleFactura;
using VerTodosSalida = API.Dto.Factura.Salida.VerTodasFacturas;

namespace API.Bll.Factura.Interfaces;
public interface IAdFactura
{
    AgregarSalida AgregarFactura(AgregarEntrada pInformacion);
    EditarSalida EditarFactura(EditarEntrada pInformacion);
    EliminarSalida EliminarFactura(EliminarEntrada pInformacion);
    VerTodosSalida VerTodasFacturas();
    VerDetalleSalida VerDetalleFactura(VerDetalleEntrada pInformacion);
}
