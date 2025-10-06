namespace Rastro.API.Controllers.ViewModel.Response
{
    public record UsuarioResponseViewModel(
        Guid Id,
        string Nome,
        string Email
    );
}