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
using MyPOS.Core.Extensions;
using MyPOS.UI.BaseRemoteService.Http;

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
        public IUserRepository userRepository { get; set; }

        public async Task SubmitAsync(LoginModel loginModel)
        {
            editContext = new EditContext(loginModel);
            if (editContext.Validate())
            {
                var loginResponse = await userRepository.TryLoginAsync(loginModel);
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