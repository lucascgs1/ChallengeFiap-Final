using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

using ChallengeFiap.Services.Interfaces;
using ChallengeFiap.Api.Model;
using ChallengeFiap.Services;
using ChallengeFiap.Api.Helper;

using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ChallengeFiap.Model;

namespace ChallengeFiap.Api.Controllers
{
    /// <summary>
    /// controller de configuracao de contas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IOptions<AppSettings> _appSettings;

        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="appSettings"></param>
        public ContaController(
          IOptions<AppSettings> appSettings
        )
        {
            _appSettings = appSettings;
        }

        /// <summary>
        /// Login na aplicacao
        /// </summary>
        /// <param name="usuarioServices">servico de usuario</param>
        /// <param name="login">dados de login</param>
        /// <returns>usuario e token de autenticacao</returns>
        [HttpPost("autenticar")]
        [AllowAnonymous]
        public async Task<ActionResult> Autenticar([FromServices] IUsuarioServices usuarioServices, [FromBody] LoginViewModel login)
        {
            try
            {
                var usuario = await usuarioServices.AuthenticateAsync(login.Email, login.Senha);

                if (usuario == null)
                    throw new ValidationException("Usuário ou senha inválidos!");

                if (usuario.Senha != login.Senha.Md5Hash())
                    throw new ValidationException("Senha invalida!");

                var token = TokenHelper.GenerateToken(usuario, _appSettings.Value.Secret);

                return Ok(new { usuario, token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtem os dados do usuario
        /// </summary>
        /// <param name="usuarioServices">servico de usuario</param>
        /// <returns>dados do usuario</returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Get([FromServices] IUsuarioServices usuarioServices)
        {
            try
            {
                var userId = this.User.Claims.Where(x => x.Type.Contains("authentication")).FirstOrDefault().Value;
                var usuario = await usuarioServices.GetByIdAsync(Convert.ToInt32(userId));

                return Ok(new { usuario });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// edita os dados do usuario
        /// </summary>
        /// <param name="usuarioServices">servico de usuario</param>
        /// <param name="usuarioViewModel">modelo de dados do usuario</param>
        /// <returns></returns>
        [HttpPost("editar")]
        [Authorize]
        public async Task<ActionResult> Editar([FromServices] IUsuarioServices usuarioServices, [FromBody] UsuarioViewModel usuarioViewModel)
        {
            try
            {
                var userId = this.User.Claims.Where(x => x.Type.Contains("authentication")).FirstOrDefault().Value;
                var usuario = await usuarioServices.GetByIdAsync(Convert.ToInt32(userId));

                usuario.Nome = usuarioViewModel.Nome;
                usuario.Sobrenome = usuarioViewModel.Sobrenome;
                usuario.Apelido = usuarioViewModel.Apelido;
                usuario.Email = usuarioViewModel.Email;
                usuario.Senha = usuarioViewModel.Senha;
                usuario.Telefone = usuarioViewModel.Telefone;

                usuarioServices.Save(usuario, usuario.Id);

                return Ok(new { usuario });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// efetua o cadastro de um novo usuario
        /// </summary>
        /// <param name="usuarioServices">servico de usuarios</param>
        /// <param name="usuarioViewModel">dados do usuario</param>
        /// <returns></returns>
        [HttpPost("cadastrar")]
        public ActionResult Cadastrar([FromServices] IUsuarioServices usuarioServices, [FromBody] UsuarioViewModel usuarioViewModel)
        {
            try
            {
                var usuario = new Usuario();

                usuario.Nome = usuarioViewModel.Nome;
                usuario.Sobrenome = usuarioViewModel.Sobrenome;
                usuario.Apelido = usuarioViewModel.Apelido;
                usuario.Email = usuarioViewModel.Email;
                usuario.Senha = usuarioViewModel.Senha;
                usuario.Telefone = usuarioViewModel.Telefone;

                usuarioServices.Save(usuario, usuario.Id);

                return Ok(new { usuario });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
