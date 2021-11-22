using Microsoft.Extensions.Logging;
using ChallengeFiap.Model;
using ChallengeFiap.Data.Interfaces;
using ChallengeFiap.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChallengeFiap.Services
{
  public class UsuarioServices : IUsuarioServices
  {
    private readonly ILogger<UsuarioServices> _logger;

    public IUsuarioRepository UsuarioRepository { get; set; }


    public UsuarioServices(
        IUsuarioRepository usuarioRepository,
        ILogger<UsuarioServices> logger
        )
    {
      UsuarioRepository = usuarioRepository;
      _logger = logger;
    }

    public Usuario GetById(int id)
    {
      var usuario = UsuarioRepository.GetById(id);

      if (usuario == null)
        throw new Exception("Usuário não encontrado!");

      return usuario;
    }
    public async Task<Usuario> AuthenticateAsync(string email, string senha)
    {
      if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
        throw new ValidationException("Dados não preenchidos!");

      return await UsuarioRepository.GetByEmail(email); ;
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
      var usuario = await UsuarioRepository.GetByIdAsync(id);

      if (usuario == null)
        throw new Exception("Usuário não encontrado!");

      return usuario;
    }

    public IEnumerable<Usuario> GetAllUsuarios()
    {
      return UsuarioRepository.GetAll();
    }

    public Usuario Save(Usuario usuarioNovo, int usuarioId = 0)
    {
      try
      {
        if (usuarioNovo.Id > 0)
        {
          if (usuarioNovo.Id != usuarioId) throw new Exception("Acesso negado!");

          var usuario = UsuarioRepository.GetById(usuarioNovo.Id);
          usuario.Nome = usuarioNovo.Nome;
          usuario.Email = usuarioNovo.Email;
          usuario.Telefone = usuarioNovo.Telefone;

          UsuarioRepository.Update(usuario);
          return usuario;
        }
        else
        {
          if (UsuarioRepository.FindFirstBy(x => x.Email == usuarioNovo.Email) != null)
            throw new ValidationException("E-mail já cadastrado!");

          usuarioNovo.DataCadastro = DateTime.Now;
          usuarioNovo.Senha = usuarioNovo.Senha.Md5Hash();

          UsuarioRepository.Add(usuarioNovo);
          UsuarioRepository.SaveChanges();
          return usuarioNovo;
        }
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        throw;
      }
    }

    public void DeleteUsuarioById(int usuarioId)
    {
      UsuarioRepository.Remove(usuarioId);
      UsuarioRepository.SaveChanges();
    }
  }
}
