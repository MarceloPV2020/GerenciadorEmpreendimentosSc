using FluentValidation;
using GerenciadorEmpreendimentosSc.Api.Models;

namespace GerenciadorEmpreendimentosSc.Api.Dtos;

public sealed class EmpreendimentoCreateDto
{
    public string NomeEmpreendimento { get; set; } = string.Empty;
    public string NomeEmpreendedor { get; set; } = string.Empty;
    public string Municipio { get; set; } = string.Empty;
    public Segmento Segmento { get; set; }
    public string Telefone { get; set; } = string.Empty;
    public StatusEmpreendimento Status { get; set; } = StatusEmpreendimento.Ativo;

    public sealed class Validator : AbstractValidator<EmpreendimentoCreateDto>
    {
        public Validator()
        {
            RuleFor(x => x.NomeEmpreendimento)
                .NotEmpty()
                .WithMessage("O nome do empreendimento deve ser informado.")
                .MinimumLength(2)
                .WithMessage("O nome do empreendimento deve ter no mínimo 2 caracteres.")
                .MaximumLength(120)
                .WithMessage("O nome do empreendimento deve ter no máximo 120 caracteres.");

            RuleFor(x => x.NomeEmpreendedor)
                .NotEmpty()
                .WithMessage("O nome do empreendedor deve ser informado.")
                .MinimumLength(2)
                .WithMessage("O nome do empreendedor deve ter no mínimo 2 caracteres.")
                .MaximumLength(120)
                .WithMessage("O nome do empreendedor deve ter no máximo 120 caracteres.");

            RuleFor(x => x.Municipio)
                .NotEmpty()
                .WithMessage("O município deve ser informado.")
                .MinimumLength(2)
                .WithMessage("O município deve ter no mínimo 2 caracteres.")
                .MaximumLength(80)
                .WithMessage("O município deve ter no máximo 80 caracteres.");

            RuleFor(x => x.Segmento)
                .Must(x => Enum.IsDefined(typeof(Segmento), x))
                .WithMessage("O segmento informado é inválido.");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .WithMessage("O telefone deve ser informado.")
                .MinimumLength(8)
                .WithMessage("O telefone deve ter no mínimo 8 caracteres.")
                .MaximumLength(20)
                .WithMessage("O telefone deve ter no máximo 20 caracteres.")
                .Matches(@"^[0-9\-\+\(\)\s]{8,20}$")
                .WithMessage("Telefone inválido. Use apenas números e separadores como (), -, + e espaço.");

            RuleFor(x => x.Status)
                .Must(x => Enum.IsDefined(typeof(StatusEmpreendimento), x))
                .WithMessage("O status informado é inválido.");
        }
    }
}