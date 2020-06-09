namespace CSharp.CrossTraining.IntegrationTests.Base
{
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Csharp.CrossTraining.Infrastructure.Entities;
    using Csharp.CrossTraining.WebApi;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class IntegrationTestBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        public IntegrationTestBase(WebApplicationFactory<Startup> factory)
        {
            this.DataFactory = new DataFactory(factory.Services);
            this.ApiClient = factory.CreateClient();
        }

        protected HttpClient ApiClient { get; }

        protected DataFactory DataFactory { get; }
    }
}