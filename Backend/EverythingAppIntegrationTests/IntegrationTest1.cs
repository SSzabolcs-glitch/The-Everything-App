using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace EverythingAppIntegrationTests
{
    public class BasicTests
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;
        

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Create a WebApplicationFactory with your Program class
            _factory = new WebApplicationFactory<Program>();

            // Create a HttpClient instance for making requests
            _client = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Dispose of resources after all tests have run
            _factory.Dispose();
        }

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("api/Product/GetAll")]
        [TestCase("api/Product/GetSpecificProduct?name=pen")]
        public async Task GetEndpointsReturn_SuccessAndCorrectContentType(string url)
        {
            // Act
            var response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.AreEqual("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}