using EducationApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text;

namespace EducationApp.Controllers
{
    
    [ApiController]
    [Route("keycloak-management")]
    public class KeycloakManagementController : ControllerBase
    {
        private readonly IStudentsService _studentsService;
        private string _userId;  
        private readonly ILogger<KeycloakManagementController> _logger;

        public KeycloakManagementController(ILogger<KeycloakManagementController> logger, IStudentsService studentsService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _studentsService = studentsService;
            _userId = httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

        }


        [HttpGet("assign-student-role")]
        public async Task AssignStudentRole()
        {

            var token = await GetTokenFromAdminCLI();
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:8090/admin/realms/educapp/users/{_userId}/role-mappings/realm");
            request.Headers.Add("Authorization", $"Bearer {token}");
            var content = new StringContent("[{\r\n        \"id\": \"c6098017-e89f-423f-bb8c-71c3c9964cba\",\r\n        \"name\": \"Student\"\r\n      }]", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }

        [HttpGet("assign-instructor-role")]
        public async Task AssignInstructorRole()
        {
            var token = await GetTokenFromAdminCLI();
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:8090/admin/realms/educapp/users/{_userId}/role-mappings/realm");
            request.Headers.Add("Authorization", $"Bearer {token}");
            var content = new StringContent("[{\r\n        \"id\": \"9fc372c1-e94a-4d7b-9731-c4944f2d238e\",\r\n        \"name\": \"Instructor\"\r\n      }]", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }

        [HttpGet("get-users")]
        public async Task<List<KeycloakUser>> KeycloakUsers()
        {
            var token = await GetTokenFromAdminCLI();
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8090/admin/realms/educapp/users");
            request.Headers.Add("Authorization", $"Bearer {token}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var users = JArray.Parse(responseContent).ToObject<List<KeycloakUser>>();
            return users;
        }

        [HttpDelete("delete-user/{userId}")]
        public async Task DeleteUser(string userId)
        {
            var token = await GetTokenFromAdminCLI();
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"http://localhost:8090/admin/realms/educapp/users/{userId}");
            request.Headers.Add("Authorization", $"Bearer {token}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }   

        private async Task<string> GetTokenFromAdminCLI()
        {
            using var client = new HttpClient();
            var tokenEndpoint = "http://localhost:8090/realms/master/protocol/openid-connect/token";
            var clientId = "admin-cli";
            var username = "admin";
            var password = "admin"; // Replace with the actual admin password

            // Create request content
            var content = new StringContent(
                $"client_id={clientId}&username={username}&password={password}&grant_type=password",
                Encoding.UTF8,
                "application/x-www-form-urlencoded"
            );

            // Send request to get the access token
            var response = await client.PostAsync(tokenEndpoint, content);
            response.EnsureSuccessStatusCode();

            // Parse the response and extract the access token
            var responseContent = await response.Content.ReadAsStringAsync();
            var token = JObject.Parse(responseContent)["access_token"].ToString();

            return token;
        }
    }

    public class KeycloakUser
    {
        public string Id { get; set; }
        public string UserName{ get; set; }
    }
}
