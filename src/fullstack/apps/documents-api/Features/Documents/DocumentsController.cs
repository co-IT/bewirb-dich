using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fullstack.DocumentsApi.Features.Documents;

[ApiController]
[Route("[controller]")]
public class DocumentsController : ControllerBase
{
  private readonly DocumentDbContext _dbContext;

  public DocumentsController(DocumentDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  [HttpGet]
  public async Task<ActionResult<DocumentDto>> GetDocuments()
  {
    var documents = await _dbContext.Documents
      .AsNoTracking()
      .ToListAsync();

    var dtos = documents.Select(MapToDto);

    return Ok(dtos);
  }

  private static DocumentDto MapToDto(Document document)
  {
    return new DocumentDto(document.Id, document.Number, document.CreatedAt, document.Author, document.Type);
  }
}
