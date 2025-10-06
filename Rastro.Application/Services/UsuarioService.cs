using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rastro.Domain.DTOs.Usuario;
using Rastro.Domain.Entities;
using Rastro.Domain.Interfaces.Repository;
using Rastro.Domain.Interfaces.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rastro.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;
        private IMapper _mapper;

        public UsuarioService(IConfiguration configuration, IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> CreateAsync(UsuarioDTO createDTO)
        {
            var usuario = _mapper.Map<Usuario>(createDTO);

            if (createDTO.Password is not null)
            {
                using var hmac = new System.Security.Cryptography.HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(createDTO.Password));
                byte[] passwordSalt = hmac.Key;

                usuario.AlterarSenha(passwordHash, passwordSalt);
            }

            await _usuarioRepository.CreateAsync(usuario);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task Update(UsuarioDTO updateDTO)
        {
            var usuario = _mapper.Map<Usuario>(updateDTO);
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task<UsuarioDTO> GetByIdAsync(Guid id)
        {
            var usario = await _usuarioRepository.GetByIdAsync(id);
            return _mapper.Map<UsuarioDTO>(usario);
        }
    }
}