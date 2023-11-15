// Input alias directives
using EditarFacturaEntrada = API.Dto.Factura.Entrada.EditarFactura;
using EliminarFacturaEntrada = API.Dto.Factura.Entrada.EliminarFactura;
using VerDetalleFacturaEntrada = API.Dto.Factura.Entrada.VerDetalleFactura;
using VerTodasFacturasEntrada = API.Dto.Factura.Entrada.VerTodasFacturas;
using AgregarFacturaEntrada = API.Dto.Factura.Entrada.AgregarFactura;

// Output alias directives
using AgregarFacturaSalida = API.Dto.Factura.Salida.AgregarFactura;
using EditarFacturaSalida = API.Dto.Factura.Salida.EditarFactura;
using EliminarFacturaSalida = API.Dto.Factura.Salida.EliminarFactura;
using VerDetalleFacturaSalida = API.Dto.Factura.Salida.VerDetalleFactura;
using VerTodasFacturasSalida = API.Dto.Factura.Salida.VerTodasFacturas;

using API.Bll.Factura.Interfaces;

namespace API.Bll.Factura
{
    public class LnFactura
    {
        private IAdFactura _adFactura;

        public LnFactura(IAdFactura adFactura)
        {
            _adFactura = adFactura;
        }

        public VerTodasFacturasSalida VerTodasFacturas(VerTodasFacturasEntrada pInformacion)
        {
            var respuesta = new VerTodasFacturasSalida();

            try
            {
                respuesta = _adFactura.VerTodasFacturas();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public VerDetalleFacturaSalida VerDetalleFactura(VerDetalleFacturaEntrada pInformacion)
        {
            var respuesta = new VerDetalleFacturaSalida();

            try
            {
                respuesta = _adFactura.VerDetalleFactura(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public AgregarFacturaSalida AgregarFactura(AgregarFacturaEntrada pInformacion)
        {
            var respuesta = new AgregarFacturaSalida();

            try
            {
                respuesta = _adFactura.AgregarFactura(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public EditarFacturaSalida EditarFactura(EditarFacturaEntrada pInformacion)
        {
            var respuesta = new EditarFacturaSalida();

            try
            {
                VerDetalleFacturaEntrada verDetalleEntrada = new()
                {
                    Codigo = pInformacion.Codigo
                };

                VerDetalleFacturaSalida verDetalleSalida = _adFactura.VerDetalleFactura(verDetalleEntrada);

                respuesta = _adFactura.EditarFactura(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public EliminarFacturaSalida EliminarFactura(EliminarFacturaEntrada pInformacion)
        {
            var respuesta = new EliminarFacturaSalida();

            try
            {
                respuesta = _adFactura.EliminarFactura(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
    }
}
