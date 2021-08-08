using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using MyPOS.Core.Models;

namespace MyPOS.UI.PageViewModels
{
    public class LoginViewModel : ComponentBase
    {
        private EditContext editContext;

        [Inject]
        public ILogger<LoginViewModel> _logger { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        public void Submit(LoginModel loginModel)
        {
            editContext = new EditContext(loginModel);
            if (editContext.Validate())
            {
                navigationManager.NavigateTo("fetchdata");
            }
            else
            {
                _logger.LogError("Invalid form...");
            }
        }
    }
}