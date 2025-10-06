using FluentValidation;
using Rastro.Domain.DTOs.ContasAPagar;

namespace Rastro.Domain.Validators
{
    public class CreateContasAPagarDTOValidator : AbstractValidator<CreateContasAPagarDTO>
    {
        public CreateContasAPagarDTOValidator()
        {
            RuleFor(x => x.NomeCredor)
                .NotEmpty()
                .WithMessage("O nome do credor é obrigatório")
                .MaximumLength(200)
                .WithMessage("O nome do credor não pode ter mais que 200 caracteres");

            RuleFor(x => x.Valor)
                .GreaterThan(0)
                .WithMessage("O valor deve ser maior que zero");

            RuleFor(x => x.DataVencimento)
                .NotEmpty()
                .WithMessage("A data de vencimento é obrigatória")
                .Must(dataVencimento => dataVencimento.Date >= DateTime.Now.Date)
                .WithMessage("A data de vencimento não pode ser anterior à data atual");

            RuleFor(x => x.Observacoes)
                .MaximumLength(500)
                .WithMessage("As observações não podem ter mais que 500 caracteres");

            When(x => x.Parcelado, () =>
            {
                RuleFor(x => x.NumeroParcelas)
                    .NotNull()
                    .WithMessage("O número de parcelas é obrigatório quando a conta é parcelada")
                    .InclusiveBetween(1, 999)
                    .WithMessage("O número de parcelas deve estar entre 1 e 999");
            });

            When(x => x.LembreteAtivo, () =>
            {
                RuleFor(x => x.DataLembrete)
                    .NotNull()
                    .WithMessage("A data do lembrete é obrigatória quando o lembrete está ativo")
                    .Must((dto, dataLembrete) => !dataLembrete.HasValue || dataLembrete.Value <= dto.DataVencimento)
                    .WithMessage("A data do lembrete não pode ser posterior à data de vencimento");
            });
        }
    }
}