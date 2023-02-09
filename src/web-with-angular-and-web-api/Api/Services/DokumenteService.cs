using System.Reflection;
using System.Text;
using System.Text.Json;
using Api.Domain;
using Api.Infrastructure;

namespace Api.Services;

public class DokumenteService : Repository
{
    private static readonly string JSONPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/dokumente.json";
    
    static DokumenteService instance = null;
    private List<Dokument> dokumente = new List<Dokument>();

    public static DokumenteService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DokumenteService();
                    instance.dokumente = LoadDokumenteFromJSON();
                }

                return instance;
            }
        }

    private static List<Dokument> LoadDokumenteFromJSON()
    {
        if (!File.Exists(JSONPath))
        {
            var empty = Enumerable.Empty<Dokument>();
            File.WriteAllText(JSONPath, JsonSerializer.Serialize(empty), Encoding.UTF8);
        }

        var json = File.ReadAllText(JSONPath, Encoding.UTF8);
        return JsonSerializer.Deserialize<List<Dokument>>(json) ?? new List<Dokument>();
    }

    public Dokument? Find(Guid id)
    {
        foreach (var dokument in dokumente)
        {
            if (dokument.Id == id)
            {
                return dokument;
            }
        }

        return null;
    }

    public List<Dokument> List()
    {
        return dokumente.ToList();
    }

    public void Add(Dokument dokument)
    {
        dokumente.Add(dokument);
    }

    public void Save()
    {
        var json = JsonSerializer.Serialize(dokumente);
        File.WriteAllText(JSONPath, json, new UTF8Encoding());
    }

    public void Delete(Dokument dokument)
    {
        dokumente.Remove(dokument);
    }
}   
