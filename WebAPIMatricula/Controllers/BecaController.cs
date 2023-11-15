using API.Bll.Beca;
using API.Bll.Beca.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPIMatricula_3C2022.Controllers;

[Route("api/v1" + "/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public class BecaController : Controller
{
    private readonly LnBeca oLnBeca;

    public BecaController(IAdBeca accesoAdBeca)
    {
        oLnBeca = new LnBeca(accesoAdBeca);
    }

    [HttpPost]
    [Route("AgregarBeca")]
    public IActionResult AgregarBeca([FromBody] API.Dto.Beca.Entrada.AgregarBeca pDatos)
    {
        API.Dto.Beca.Salida.AgregarBeca respuesta = new API.Dto.Beca.Salida.AgregarBeca();
        try
        {
            respuesta = oLnBeca.AgregarBeca(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(ex.Message);
        }
    }

    [HttpPost]
    [Route("VerTodasBecas")]
    public IActionResult VerTodasBecas(API.Dto.Beca.Entrada.VerTodasBecas pDatos)
    {
        API.Dto.Beca.Salida.VerTodasBecas respuesta = new API.Dto.Beca.Salida.VerTodasBecas();

        try
        {
            respuesta = oLnBeca.VerTodasBecas(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }


    [HttpPost]
    [Route("EliminarBeca")]
    public IActionResult EliminarBeca([FromBody] API.Dto.Beca.Entrada.EliminarBeca pDatos)
    {
        API.Dto.Beca.Salida.EliminarBeca respuesta = new API.Dto.Beca.Salida.EliminarBeca();

        try
        {
            respuesta = oLnBeca.EliminarBeca(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }


    [HttpPost]
    [Route("VerDetalleBeca")]
    public IActionResult VerDetalleBeca([FromBody] API.Dto.Beca.Entrada.VerDetalleBeca pDatos)
    {
        API.Dto.Beca.Salida.VerDetalleBeca respuesta = new API.Dto.Beca.Salida.VerDetalleBeca();

        try
        {
            respuesta = oLnBeca.VerDetalleBeca(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }

    [HttpPost]
    [Route("EditarBeca")]
    public IActionResult EditarBeca([FromBody] API.Dto.Beca.Entrada.EditarBeca pDatos)
    {
        API.Dto.Beca.Salida.EditarBeca respuesta = new API.Dto.Beca.Salida.EditarBeca();

        try
        {
            respuesta = oLnBeca.EditarBeca(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }



}