using FluentValidation;
using Rastro.Domain.DTOs.Usuario;
using Rastro.Domain.Entities;

namespace Rastro.Domain.Validators
{
    public class CreateUsuarioValidator : AbstractValidator<UsuarioDTO>
    {
        public CreateUsuarioValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty().WithMessage("O nome é obrigatório")
                .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres");

            RuleFor(x => x.Email)
                .NotNull().NotEmpty().WithMessage("O email é obrigatório")
                .EmailAddress().WithMessage("Email inválido")
                .MaximumLength(100).WithMessage("O email deve ter no máximo 100 caracteres");

            RuleFor(x => x.Password)
                .NotNull().NotEmpty().WithMessage("A senha é obrigatória")
                .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres")
                .MaximumLength(20).WithMessage("A senha deve ter no máximo 20 caracteres");
        }
    }
}