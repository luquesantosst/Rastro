using FluentValidation;
using Rastro.Domain.Entities;
using Rastro.Domain.Entities.Enums;

namespace Rastro.Domain.Validators
{
    public class ContasAPagarValidator : AbstractValidator<ContasAPagar>
    {
        public ContasAPagarValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O Id é obrigatório");

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
                .WithMessage("A data de vencimento é obrigatória");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Status inválido");

            // Regras de negócio específicas para parcelamento
            When(x => x.Parcelado, () =>
            {
                RuleFor(x => x.NumeroParcelas)
                    .NotNull()
                    .WithMessage("Número de parcelas é obrigatório para contas parceladas")
                    .GreaterThan(0)
                    .WithMessage("Número de parcelas deve ser maior que zero");

                RuleFor(x => x.ParcelaAtual)
                    .NotNull()
                    .WithMessage("Número da parcela atual é obrigatório para contas parceladas")
                    .GreaterThan(0)
                    .WithMessage("Número da parcela atual deve ser maior que zero")
                    .Must((conta, parcelaAtual) => parcelaAtual <= conta.NumeroParcelas)
                    .WithMessage("Número da parcela atual não pode ser maior que o número total de parcelas");

                RuleFor(x => x.ValorParcela)
                    .NotNull()
                    .WithMessage("Valor da parcela é obrigatório para contas parceladas")
                    .GreaterThan(0)
                    .WithMessage("Valor da parcela deve ser maior que zero");

                RuleFor(x => x.ValorTotal)
                    .NotNull()
                    .WithMessage("Valor total é obrigatório para contas parceladas")
                    .GreaterThan(0)
                    .WithMessage("Valor total deve ser maior que zero")
                    .Must((conta, valorTotal) => !conta.ValorParcela.HasValue || 
                          valorTotal == conta.ValorParcela.Value * conta.NumeroParcelas)
                    .WithMessage("O valor total deve ser igual ao valor da parcela multiplicado pelo número de parcelas");
            });

            // Regras de negócio específicas para lembretes
            When(x => x.LembreteAtivo, () =>
            {
                RuleFor(x => x.DataLembrete)
                    .NotNull()
                    .WithMessage("Data do lembrete é obrigatória quando o lembrete está ativo")
                    .Must((conta, dataLembrete) => !dataLembrete.HasValue || 
                          dataLembrete.Value < conta.DataVencimento)
                    .WithMessage("A data do lembrete deve ser anterior à data de vencimento");
            });

            // Regras de status
            When(x => x.Status == StatusConta.Pago, () =>
            {
                RuleFor(x => x.DataVencimento)
                    .Must((conta, dataVencimento) => dataVencimento >= DateTime.Now.AddDays(-360))
                    .WithMessage("Não é possível registrar pagamentos com mais de 360 dias de atraso");
            });

            // Validação de observações
            When(x => !string.IsNullOrEmpty(x.Observacoes), () =>
            {
                RuleFor(x => x.Observacoes)
                    .MaximumLength(500)
                    .WithMessage("As observações não podem ter mais que 500 caracteres");
            });
        }
    }
}