using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using MyPOS.Core.Models;
using System.Threading.Tasks;

namespace MyPOS.UI.PageViewModels
{
    public class LoginViewModel
    {
        private EditContext editContext;
        public ILogger<LoginViewModel> _logger { get; set; }

        public LoginViewModel(ILogger<LoginViewModel> logger)
        {
            _logger = logger;
        }

        public void Submit(LoginModel loginModel)
        {
            editContext = new EditContext(loginModel);
            if (editContext.Validate())
            {
                _logger.LogInformation("Form is valid");
            }
            else
            {
                _logger.LogError("Form is invalid");
            }
        }
    }
}