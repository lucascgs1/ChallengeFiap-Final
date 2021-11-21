using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

using ChallengeFiap.Model;
using ChallengeFiap.Api.Model;
using ChallengeFiap.Api.Helper;
using ChallengeFiap.Services.Interfaces;

using System;
using System.Linq;
using System.Security.Claims;

namespace ChallengeFiap.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsuarioController : ControllerBase
  {
    private readonly IOptions<AppSettings> appSettings;
    public UsuarioController(
        IOptions<AppSettings> appSettings
        )
    {
      this.appSettings = appSettings;
    }

    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult GetById([FromServices] IUsuarioServices usuarioServices, int id)
    {
      try
      {
        var usuario = usuarioServices.GetById(id);

        if (usuario == null)
          return NotFound("Usuário não encontrado!");

        return Ok(new { usuario });
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult GetAll([FromServices] IUsuarioServices usuarioServices)
    {
      try
      {
        var usuarios = usuarioServices.GetAllUsuarios().ToList();

        return Ok(usuarios);
      }
      catch (Exception ex)
      {
        return Problem(ex.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult Post([FromServices] IUsuarioServices usuarioServices, [FromBody] Usuario usuario)
    {
      try
      {
        var user = usuario;

        int.TryParse(TokenHelper.GetClaims(User.Identity, ClaimTypes.Authentication), out int id);
        usuarioServices.Save(user, id);

        return Ok(new { usuario });
      }
      catch (Exception ex)
      {
        return ValidationProblem(ex.Message);
      }
    }


    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Delete([FromServices] IUsuarioServices usuarioServices, int id)
    {
      try
      {
        usuarioServices.DeleteUsuarioById(id);

        return Ok();
      }
      catch (Exception ex)
      {
        return Problem(ex.Message);
      }
    }
  }
}
