using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using MyPOS.Core.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyPOS.UI.PageViewModels
{
    public class LoginViewModel : ComponentBase
    {
        private EditContext editContext;

        [Inject]
        public ILogger<LoginViewModel> logger { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IHttpClientFactory clientFatory { get; set; }

        public async Task SubmitAsync(LoginModel loginModel)
        {
            var client = clientFatory.CreateClient("LoginAPI");
            editContext = new EditContext(loginModel);
            if (editContext.Validate())
            {
                client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
                var response = await client.PostAsJsonAsync("login", loginModel);
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                if (loginResponse.IsFailure)
                {
                    logger.LogError("Login failed");
                }
            }
            else
            {
                logger.LogError("Invalid form...");
            }
        }
    }
}