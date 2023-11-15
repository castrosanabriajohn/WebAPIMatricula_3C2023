using API.Bll.Error;
using API.Bll.Error.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPIMatricula_3C2022.Controllers;

[Route("api/v1" + "/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public class ErrorController : Controller
{
    private LnError oLnError;

    public ErrorController(IAdError accesoAdError)
    {
        oLnError = new API.Bll.Error.LnError(accesoAdError);
    }

    [HttpPost]
    [Route("AgregarError")]
    public IActionResult AgregarEstudiante([FromBody] API.Dto.Error.Entrada.AgregarError pDatos)
    {
        API.Dto.Error.Salida.AgregarError respuesta = new API.Dto.Error.Salida.AgregarError();

        try
        {
            respuesta = oLnError.AgregarError(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(ex.Message);
            throw;
        }
    }

    [HttpPost]
    [Route("VerTodosErrores")]
    public IActionResult VerTodosEstudiantes(API.Dto.Error.Entrada.VerTodosErrores pDatos)
    {
        API.Dto.Error.Salida.VerTodosErrores respuesta = new API.Dto.Error.Salida.VerTodosErrores();

        try
        {
            respuesta = oLnError.VerTodosErrores();
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }
}