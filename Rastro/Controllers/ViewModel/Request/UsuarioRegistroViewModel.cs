namespace Rastro.API.Controllers.ViewModel.Request
{
    public record UsuarioRegistroViewModel(
        string Nome,
        string Email,
        string Password
    );
}