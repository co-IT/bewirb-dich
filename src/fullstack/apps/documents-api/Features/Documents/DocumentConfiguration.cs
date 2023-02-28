using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fullstack.DocumentsApi.Features.Documents;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
  public void Configure(EntityTypeBuilder<Document> builder)
  {
    builder.HasKey(ba => ba.Id);

    builder.HasData(DocumentSeedGenerator.Seed());
  }
}
