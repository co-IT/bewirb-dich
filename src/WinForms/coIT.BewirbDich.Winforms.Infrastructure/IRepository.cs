using coIT.BewirbDich.Winforms.Domain;

namespace coIT.BewirbDich.Winforms.Infrastructure;

public interface IRepository
{
    Dokument? Find(Guid id);
    List<Dokument> List();
    void Add(Dokument dokument);
    void Save();
}