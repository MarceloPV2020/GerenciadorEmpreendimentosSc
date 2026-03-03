using GerenciadorEmpreendimentosSc.Api.Models;

namespace GerenciadorEmpreendimentosSc.Api.Dtos;

public sealed record EmpreendimentoReadDto(
    Guid Id,
    string NomeEmpreendimento,
    string NomeEmpreendedor,
    string Municipio,
    Segmento Segmento,
    string Telefone,
    StatusEmpreendimento Status,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);