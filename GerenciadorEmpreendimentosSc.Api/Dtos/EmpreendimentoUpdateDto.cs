using System.ComponentModel.DataAnnotations;
using GerenciadorEmpreendimentosSc.Api.Models;

namespace GerenciadorEmpreendimentosSc.Api.Dtos;

public sealed record EmpreendimentoUpdateDto(
    [property: Required, MinLength(2), MaxLength(120)] string NomeEmpreendimento,
    [property: Required, MinLength(2), MaxLength(120)] string NomeEmpreendedor,
    [property: Required, MinLength(2), MaxLength(80)] string Municipio,
    [property: Required] Segmento Segmento,
    [property: Required, Phone, MinLength(8), MaxLength(20)] string Telefone,
    [property: Required] StatusEmpreendimento Status
);