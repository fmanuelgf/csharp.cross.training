namespace CSharp.CrossTraining.IntegrationTests.Base
{
    using System;
    using System.Net.Http;
    using Csharp.CrossTraining.WebApi;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class IntegrationTestBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly Lazy<DataFactory> dataFactory;

        public IntegrationTestBase(WebApplicationFactory<Startup> factory)
        {
            this.dataFactory = new Lazy<DataFactory>(() => new DataFactory(factory.Services));
            this.ApiClient = factory.CreateClient();
        }

        protected HttpClient ApiClient { get; }

        protected DataFactory DataFactory => this.dataFactory.Value;
    }
}