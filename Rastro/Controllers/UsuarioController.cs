using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rastro.API.Controllers.ViewModel.Request;
using Rastro.API.Controllers.ViewModel.Response;
using Rastro.Domain.DTOs.Usuario;
using Rastro.Domain.Interfaces.Account;
using Rastro.Domain.Interfaces.Service;

namespace Rastro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthenticate _authenticateService;
        private IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticateService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _authenticateService = authenticateService;
            _mapper = mapper;
        }

        [HttpPost("registrar")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserTokenViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(UserTokenViewModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserTokenViewModel>> Registrar([FromBody] UsuarioRegistroViewModel viewModel)
        {
            if (viewModel == null)
                return BadRequest("Dados inválidos.");

            var emailExists = await _authenticateService.UserExists(viewModel.Email);

            if (emailExists)
                return BadRequest("E-mail já possui um cadastrado.");

            var usuarioDTO = _mapper.Map<UsuarioDTO>(viewModel);

            var usuario = await _usuarioService.CreateAsync(usuarioDTO);

            if (usuario == null)
                return BadRequest("Erro ao tentar registrar usuário.");

            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserTokenViewModel
            {
                Token = token
            };
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> Login([FromBody] UsuarioLoginViewModel viewModel)
        {
          throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UsuarioResponseViewModel>> GetById(Guid id)
        {
            try
            {
                var result = await _usuarioService.GetByIdAsync(id);

                var response = new UsuarioResponseViewModel(
                    result.Id,
                    result.Nome,
                    result.Email
                );

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}