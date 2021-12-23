using devops_project_web_t4.Areas.Controllers;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace devops_project_web_t4.Shared
{
    public partial class LoginDisplay
    {
        [Inject]
        public ICustomerController CustomerController { get; set; }

        private string _username;
        private string Picture = "";

        protected override async Task OnInitializedAsync()
        {
            var state = await AuthState.GetAuthenticationStateAsync();
            _username = state.User.Identity.Name;

            //Maps auth0 username (email) to our own database table Customer on first login
            CustomerController.MapAuth0User(_username);

            await base.OnInitializedAsync();
        }
    }
}
