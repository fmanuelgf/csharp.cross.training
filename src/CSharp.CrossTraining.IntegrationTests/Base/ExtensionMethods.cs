namespace CSharp.CrossTraining.IntegrationTests.Base
{
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Csharp.CrossTraining.Infrastructure.Entities;

    public static class ExtensionMethods
    {
        public static Pet AddDefaultPet(this Person person)
        {
            return person.AddDefaultPet("Tobby", "Dog");
        }

        public static Pet AddDefaultPet(this Person person, string name, string specie)
        {
            var pet = new Pet(name, specie, person.Id);
            person.Pets.Add(pet);

            return pet;
        }

        public static async Task<T> Deserialize<T>(this HttpResponseMessage response)
        {
            var resultContent = await response?.Content?.ReadAsStreamAsync();
            if (resultContent == null)
            {
                return default(T);
            }

            var result = await JsonSerializer.DeserializeAsync<T>(
                resultContent,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            
            return result;
        }
    }
}