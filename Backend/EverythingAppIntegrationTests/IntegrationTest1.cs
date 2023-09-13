using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace EverythingAppIntegrationTests
{
    public class BasicTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public BasicTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Program>());
            _client = _server.CreateClient();
        }
        [SetUp]
        public void Setup()
        {
        }

        [Theory]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Act
            var response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equals("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}