using Bogus;

namespace Fullstack.DocumentsApi.Features.Documents;

public static class DocumentSeedGenerator
{
  public static IEnumerable<Document> Seed(int count = 1000)
  {
    Randomizer.Seed = new Random(2023);

    var faker = new Faker<Document>()
      .CustomInstantiator(f => new Document(f.Commerce.Ean13(), f.Date.PastOffset(3), f.Name.FullName(), f.PickRandom<DocumentType>()));

    return faker.Generate(count);
  }
}
