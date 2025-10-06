namespace Rastro.API.Controllers.ViewModel.Request
{
    public record UsuarioLoginViewModel(
        string Email,
        string Senha
    );
}