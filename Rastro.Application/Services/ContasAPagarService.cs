using AutoMapper;
using FluentValidation;
using Rastro.Domain.DTOs.ContasAPagar;
using Rastro.Domain.Entities;
using Rastro.Domain.Entities.Enums;
using Rastro.Domain.Interfaces.Repository;
using Rastro.Domain.Interfaces.Service;

namespace Rastro.Application.Services
{
    public class ContasAPagarService : IContasAPagarService
    {
        private readonly IContasAPagarRepository _repository;
        private readonly IValidator<CreateContasAPagarDTO> _validator;

        public ContasAPagarService(
            IContasAPagarRepository repository,
            IValidator<CreateContasAPagarDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<ContasAPagar> CreateAsync(CreateContasAPagarDTO createDTO)
        {
            // Validação via FluentValidation
            var validationResult = await _validator.ValidateAsync(createDTO);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var contaAPagar = new ContasAPagar(
                nomeCredor: createDTO.NomeCredor,
                valor: createDTO.Valor,
                dataVencimento: createDTO.DataVencimento,
                usuarioId: createDTO.UsuarioId,
                observacoes: createDTO.Observacoes,
                parcelado: createDTO.Parcelado,
                numeroParcelas: createDTO.NumeroParcelas,
                lembreteAtivo: createDTO.LembreteAtivo,
                dataLembrete: createDTO.DataLembrete
            );

            // Persiste no banco de dados
            await _repository.CreateAsync(contaAPagar);
            return contaAPagar;
        }

        public async Task<IEnumerable<ContasAPagar>> GetAllByUsuarioIdAsync(Guid usuarioId)
        {
            var contas = await _repository.GetAllAsync();
            return contas.Where(c => c.UsuarioId == usuarioId);
        }
    }
}
