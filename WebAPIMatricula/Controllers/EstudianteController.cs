using API.Bll.Estudiante;
using API.Bll.Estudiante.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPIMatricula_3C2022.Controllers;
[Route("api/v1" + "/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public class EstudianteController : Controller
{
    private readonly LnEstudiante oLnEstudiante;

    public EstudianteController(IAdEstudiante accesoAdEstudiante)
    {
        oLnEstudiante = new LnEstudiante(accesoAdEstudiante);
    }

    [HttpPost]
    [Route("AgregarEstudiante")]
    public IActionResult AgregarEstudiante([FromBody] API.Dto.Estudiante.Entrada.AgregarEstudiante pDatos)
    {
        API.Dto.Estudiante.Salida.AgregarEstudiante respuesta = new API.Dto.Estudiante.Salida.AgregarEstudiante();
        try
        {
            respuesta = oLnEstudiante.AgregarEstudiante(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            //return StatusCode(StatusCodes.Status500InternalServerError, ex);
            return Ok(ex.Message);
        }
    }

    [HttpPost]
    [Route("VerTodosEstudiantes")]
    public IActionResult VerTodosEstudiantes(API.Dto.Estudiante.Entrada.VerTodosEstudiantes pDatos)
    {
        API.Dto.Estudiante.Salida.VerTodosEstudiantes respuesta = new API.Dto.Estudiante.Salida.VerTodosEstudiantes();

        try
        {
            respuesta = oLnEstudiante.VerTodosEstudiantes(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            //return StatusCode(StatusCodes.Status500InternalServerError, ex);
            return Ok(respuesta);
        }
    }


    [HttpPost]
    [Route("EliminarEstudiante")]
    public IActionResult EliminarEstudiante([FromBody] API.Dto.Estudiante.Entrada.EliminarEstudiante pDatos)
    {
        API.Dto.Estudiante.Salida.EliminarEstudiante respuesta = new API.Dto.Estudiante.Salida.EliminarEstudiante();

        try
        {
            respuesta = oLnEstudiante.EliminarEstudiante(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }


    [HttpPost]
    [Route("VerDetalleEstudiante")]
    public IActionResult VerDetalleEstudiante([FromBody] API.Dto.Estudiante.Entrada.VerDetalleEstudiante pDatos)
    {
        API.Dto.Estudiante.Salida.VerDetalleEstudiante respuesta = new API.Dto.Estudiante.Salida.VerDetalleEstudiante();

        try
        {
            respuesta = oLnEstudiante.VerDetalleEstudiante(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }

    [HttpPost]
    [Route("EditarEstudiante")]
    public IActionResult EditarEstudiante([FromBody] API.Dto.Estudiante.Entrada.EditarEstudiante pDatos)
    {
        API.Dto.Estudiante.Salida.EditarEstudiante respuesta = new API.Dto.Estudiante.Salida.EditarEstudiante();

        try
        {
            respuesta = oLnEstudiante.EditarEstudiante(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }



}