using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MIS.BLL;
using MIS.Core;
using MIS.Core.OutputModels;

namespace MIS.Web.Components
{
    public class AuthChekComponent : ComponentBase
    {
        [CascadingParameter]
        protected Task<AuthenticationState>? AuthenticationState { get; set; }

        [Inject]
        protected UserManager UserManager { get; set; } = default!;

        protected UserOutputModel CurrentUser { get; private set; } = new();

        protected bool IsAuthenticated { get; private set; }

        protected bool IsAdmin { get; private set; } = false;


        protected override async Task OnInitializedAsync()
        {
            await CheckAuthentication();
            await base.OnInitializedAsync();
        }

        protected virtual async Task CheckAuthentication()
        {
            if (AuthenticationState is not null)
            {
                var authState = await AuthenticationState;
                var user = authState?.User;

                IsAuthenticated = user?.Identity?.IsAuthenticated == true;

                if (IsAuthenticated)
                {
                    var login = user.Identity.Name;
                    CurrentUser = UserManager.GetByLogin(login) ?? new UserOutputModel();
                    IsAdmin = UserManager.HasRole(CurrentUser.Id, UserRole.Admin);

                }
            }
        }
    }
}