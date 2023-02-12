using System.Text;
using System.Text.Json;
using coIT.BewirbDich.Winforms.Domain;

namespace coIT.BewirbDich.Winforms.Infrastructure;

public class JsonRepository : IRepository
{
    private readonly string _file;
    private List<Dokument> _dokumente;

    public JsonRepository(string file)
    {
        _file = file;
        Load();
    }

    private void Load()
    {
        if (!File.Exists(_file))
        {
            var empty = Enumerable.Empty<Dokument>();
            File.WriteAllText(_file, JsonSerializer.Serialize(empty), Encoding.UTF8);
        }

        var json = File.ReadAllText(_file, Encoding.UTF8);
        _dokumente = JsonSerializer.Deserialize<List<Dokument>>(json) ?? new List<Dokument>();
    }

    public Dokument? Find(Guid id)
    {
        return _dokumente.SingleOrDefault(dok => dok.Id == id);
    }

    public List<Dokument> List()
    {
        return _dokumente;
    }

    public void Add(Dokument dokument)
    {
        _dokumente.Add(dokument);
    }

    public void Save()
    {
        var json = JsonSerializer.Serialize(_dokumente);
        File.WriteAllText(_file, json, new UTF8Encoding());
    }
}