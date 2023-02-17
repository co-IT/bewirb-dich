namespace Fullstack.DocumentsApi.Features.Documents;

public record DocumentDto(Guid Id, string Number, DateTimeOffset CreatedAt, string Author, DocumentType Type);
