using API.Bll.Factura;
using API.Bll.Factura.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPIMatricula_3C2022.Controllers;

[Route("api/v1" + "/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public class FacturaController : Controller
{
    private readonly LnFactura oLnFactura;

    public FacturaController(IAdFactura accesoAdFactura)
    {
        oLnFactura = new LnFactura(accesoAdFactura);
    }

    [HttpPost]
    [Route("AgregarFactura")]
    public IActionResult AgregarFactura([FromBody] API.Dto.Factura.Entrada.AgregarFactura pDatos)
    {
        API.Dto.Factura.Salida.AgregarFactura respuesta = new API.Dto.Factura.Salida.AgregarFactura();
        try
        {
            respuesta = oLnFactura.AgregarFactura(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(ex.Message);
        }
    }

    [HttpPost]
    [Route("VerTodasFacturas")]
    public IActionResult VerTodasFacturas(API.Dto.Factura.Entrada.VerTodasFacturas pDatos)
    {
        API.Dto.Factura.Salida.VerTodasFacturas respuesta = new API.Dto.Factura.Salida.VerTodasFacturas();

        try
        {
            respuesta = oLnFactura.VerTodasFacturas(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }


    [HttpPost]
    [Route("EliminarFactura")]
    public IActionResult EliminarFactura([FromBody] API.Dto.Factura.Entrada.EliminarFactura pDatos)
    {
        API.Dto.Factura.Salida.EliminarFactura respuesta = new API.Dto.Factura.Salida.EliminarFactura();

        try
        {
            respuesta = oLnFactura.EliminarFactura(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }


    [HttpPost]
    [Route("VerDetalleFactura")]
    public IActionResult VerDetalleFactura([FromBody] API.Dto.Factura.Entrada.VerDetalleFactura pDatos)
    {
        API.Dto.Factura.Salida.VerDetalleFactura respuesta = new API.Dto.Factura.Salida.VerDetalleFactura();

        try
        {
            respuesta = oLnFactura.VerDetalleFactura(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }

    [HttpPost]
    [Route("EditarFactura")]
    public IActionResult EditarFactura([FromBody] API.Dto.Factura.Entrada.EditarFactura pDatos)
    {
        API.Dto.Factura.Salida.EditarFactura respuesta = new API.Dto.Factura.Salida.EditarFactura();

        try
        {
            respuesta = oLnFactura.EditarFactura(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }



}