namespace CSharp.CrossTraining.IntegrationTests.ControllerTests
{
    using System.Linq;
    using Csharp.CrossTraining.WebApi;
    using Csharp.CrossTraining.WebApi.Dtos;
    using CSharp.CrossTraining.IntegrationTests.Base;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class PersonsControllerTests : IntegrationTestBase
    {
        public PersonsControllerTests(WebApplicationFactory<Startup> factory)
            : base(factory)
        {
        }
        
        [Fact]
        public async void CanCreatePersonWithSuccessAsync()
        {
            // Arrange
            var person = this.DataFactory.BuildDefaultPerson();
            person.AddDefaultPet("Tom", "Cat");
            person.AddDefaultPet("Jerry", "Mouse");

            this.DataFactory.Save();

            // Act
            var response = await this.ApiClient.GetAsync($"http://localhost:5000/api/persons/{person.Id}");
            var result = await response.Deserialize<PersonDto>();

            // Assert
            Assert.True(response.IsSuccessStatusCode);
            Assert.True(result.Id == person.Id);
            Assert.True(result.Name == person.Name);
            Assert.True(result.Age == person.Age);
            Assert.True(result.Weight == person.Weight);
            Assert.True(result.Pets.Count() == person.Pets.Count);
        }
    }
}