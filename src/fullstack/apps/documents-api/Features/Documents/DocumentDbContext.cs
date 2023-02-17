using Microsoft.EntityFrameworkCore;

namespace Fullstack.DocumentsApi.Features.Documents;

public class DocumentDbContext : DbContext
{
  public DocumentDbContext(DbContextOptions<DocumentDbContext> options) : base(options)
  {
  }

  public DbSet<Document> Documents => Set<Document>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new DocumentConfiguration());
  }
}
