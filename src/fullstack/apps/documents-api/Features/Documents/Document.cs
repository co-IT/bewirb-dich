namespace Fullstack.DocumentsApi.Features.Documents;

public class Document
{
  public Guid Id { get; }
  public string Number { get; private set; }
  public DateTimeOffset CreatedAt { get; private set; }
  public string Author { get; private set; }
  public DocumentType Type { get; private set; }

  public Document(string number, DateTimeOffset createdAt, string author, DocumentType type)
  {
    Id = Guid.NewGuid();
    Number = number;
    CreatedAt = createdAt;
    Author = author;
    Type = type;
  }
}
