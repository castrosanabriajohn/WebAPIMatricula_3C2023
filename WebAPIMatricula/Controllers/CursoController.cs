using API.Bll.Curso;
using API.Bll.Curso.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPIMatricula_3C2022.Controllers;

[Route("api/v1" + "/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public class CursoController : Controller
{
    private readonly LnCurso oLnCurso;

    public CursoController(IAdCurso accesoAdCurso)
    {
        oLnCurso = new LnCurso(accesoAdCurso);
    }

    [HttpPost]
    [Route("AgregarCurso")]
    public IActionResult AgregarCurso([FromBody] API.Dto.Curso.Entrada.AgregarCurso pDatos)
    {
        API.Dto.Curso.Salida.AgregarCurso respuesta = new();
        try
        {
            respuesta = oLnCurso.AgregarCurso(pDatos);
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
    [Route("VerTodosCursos")]
    public IActionResult VerTodosCursos(API.Dto.Curso.Entrada.VerTodosCursos pDatos)
    {
        API.Dto.Curso.Salida.VerTodosCursos respuesta = new();

        try
        {
            respuesta = oLnCurso.VerTodosCursos();
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
    [Route("EliminarCurso")]
    public IActionResult EliminarCurso([FromBody] API.Dto.Curso.Entrada.EliminarCurso pDatos)
    {
        API.Dto.Curso.Salida.EliminarCurso respuesta = new();

        try
        {
            respuesta = oLnCurso.EliminarCurso(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }


    [HttpPost]
    [Route("VerDetalleCurso")]
    public IActionResult VerDetalleCurso([FromBody] API.Dto.Curso.Entrada.VerDetalleCurso pDatos)
    {
        API.Dto.Curso.Salida.VerDetalleCurso respuesta = new();

        try
        {
            respuesta = oLnCurso.VerDetalleCurso(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }

    [HttpPost]
    [Route("EditarCurso")]
    public IActionResult EditarCurso([FromBody] API.Dto.Curso.Entrada.EditarCurso pDatos)
    {
        API.Dto.Curso.Salida.EditarCurso respuesta = new();

        try
        {
            respuesta = oLnCurso.EditarCurso(pDatos);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            respuesta.setErrorComunicacion(ex.Message);
            return Ok(respuesta);
        }
    }



}