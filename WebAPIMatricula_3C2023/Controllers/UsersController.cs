using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPIMatricula_3C2023.Entities;
using WebAPIMatricula_3C2023.Helpers;
using WebAPIMatricula_3C2023.Models;
using WebAPIMatricula_3C2023.Services;

namespace WebAPIMatricula_3C2023.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;

    public UsersController(
        IUserService userService,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _userService = userService;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
    {
        var user = await _userService.Authenticate(model.Username, model.Password);

        if (user == null)
        {
            return Unauthorized(new { message = "Credenciales incorrectas" });
        }

        var token = GenerateJwtToken(user);

        // return basic user info and authentication token
        return Ok(new
        {
            user.Codigo,
            user.Identificacion,
            user.NombreCompleto,
            user.CorreoElectronico,
            user.Username,
            Token = token,
            user.Estado
        });
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        // map model to entity
        var user = _mapper.Map<Usuario>(model);

        try
        {
            // create user
            await _userService.Create(user, model.Password);
            return Ok();
        }
        catch (AppException ex)
        {
            // return error message if there was an exception
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAll();
        var model = _mapper.Map<IList<UserModel>>(users);
        return Ok(model);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetById(id);
        if (user == null)
        {
            return NotFound();
        }
        var model = _mapper.Map<UserModel>(user);
        return Ok(model);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateModel model)
    {
        // map model to entity and set id
        var user = _mapper.Map<Usuario>(model);
        user.Codigo = id;

        try
        {
            // update user 
            await _userService.Update(user, model.Password);
            return Ok(user);
        }
        catch (AppException ex)
        {
            // return error message if there was an exception
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.Delete(id);
        return NoContent();
    }

    private string GenerateJwtToken(Usuario user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Codigo.ToString())
            }),
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_appSettings.MinutosExpiracionToken)),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
