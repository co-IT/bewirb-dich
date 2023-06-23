using CreepyApi.Domain;

namespace CreepyApi.Infrastructure;

public interface Repository
{
    Dokument? Find(Guid id);
    List<Dokument> List();
    void Add(Dokument dokument);
    void Save();
}