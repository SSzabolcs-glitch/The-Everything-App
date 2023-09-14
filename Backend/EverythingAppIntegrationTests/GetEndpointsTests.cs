using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using Backend.Services.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace EverythingAppIntegrationTests
{
    public class BasicTests
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;
        private TokenService _tokenService;
        private string _adminToken;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //Arrange

            // Specify the path to the appsettings.test.json file
            var currentDirectory = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(currentDirectory, "appsettings.test.json");

            var webHostBuilder = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureAppConfiguration((context, configBuilder) =>
                    {
                        configBuilder
                            .AddJsonFile(configPath);
                    });
                });

            _factory = webHostBuilder;

            // Create a HttpClient instance for making requests
            _client = _factory.CreateClient();

            // Create an instance of TokenService
            var config = _factory.Services.GetRequiredService<IConfiguration>();
            var issuerSigningKey = config["IssuerSigningKey"];

            // Create a test user with roles (e.g., "Admin")
            var testUser = new IdentityUser
            {
                Id = "1", 
                UserName = "admin", 
                Email = "admin@admin.com" 
            };

            // Create a list of roles including "Admin"
            var testRoles = new List<string>
                {
                    "Admin"
                };

            _tokenService = new TokenService(issuerSigningKey);
            _adminToken = _tokenService.CreateToken(testUser, testRoles);
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

        [TestCase("api/GetUsers")]
        [TestCase("api/GetUser?email=admin%40admin.com")]
        public async Task GetEndpointsWithAdminAuth_ReturnSuccessAndCorrectContentType(string url)
        {

            // Act
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", $"Bearer {_adminToken}");

            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}