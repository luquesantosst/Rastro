namespace Rastro.API.Controllers.ViewModel.Response
{
    public record ContaAPagarResponseViewModel(
        Guid Id,
        string NomeCredor,
        decimal Valor,
        DateTime DataVencimento,
        string? Observacoes,
        bool LembreteAtivo,
        DateTime? DataLembrete,
        bool Parcelado,
        int? NumeroParcelas,
        int? ParcelaAtual,
        decimal? ValorParcela,
        decimal? ValorTotal
    );
}