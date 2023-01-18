using Api.Domain;

namespace Api.Infrastructure;

public interface Repository
{
    Dokument? Find(Guid id);
    List<Dokument> List();
    void Add(Dokument dokument);
    void Save();
}