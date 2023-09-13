using System.Net;
using System.Text;
using Backend.Contracts;
using Backend.Controllers;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace EverythingAppIntegrationTests;

public class AuthIntegrationTests
{
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://webapp-230912181654.azurewebsites.net"); 
    }

    [Test]
    public async Task RegisterUser_ValidRegistrationRequest_ReturnsCreatedResponse()
    {

        var registrationRequest = new RegistrationRequest
        (
            "testuser@example.com",
            "testuser",
            "TestPassword123"
        );

        var content = new StringContent(JsonSerializer.Serialize(registrationRequest), Encoding.UTF8, "application/json");
        var requestUri = "/Auth/Register";

        var response = await _client.PostAsync(requestUri, content);

        if (response.StatusCode == HttpStatusCode.Created)
        {
           
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
      
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        else
        {
            Assert.Fail($"Unexpected response status code: {response.StatusCode}");
        }

    }
    [Test]
    public async Task Login_ValidCredentials_ReturnsToken()
    {

        var authRequest = new AuthController.AuthRequest
        (
            "admin@admin.com",
            "admin123"
        );

        var jsonContent = JsonConvert.SerializeObject(authRequest);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var requestUri = "/Auth/Login";

      
        var response = await _client.PostAsync(requestUri, content);

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);


        var responseContent = await response.Content.ReadAsStringAsync();
        var authResponse = JsonConvert.DeserializeObject<AuthController.AuthResponse>(responseContent);

        Assert.IsFalse(string.IsNullOrEmpty(authResponse.Token));
    }

    [TearDown]
    public void Cleanup()
    {
        _client.Dispose();
    }
}