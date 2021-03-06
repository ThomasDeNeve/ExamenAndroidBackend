using Microsoft.AspNetCore.Components;

namespace devops_project_web_t4.Shared.Components
{
    public partial class HierButton
    {
        private string PrimaryButtonClass = "primaryHierButton";
        private string SecondaryButtonClass = "secondaryHierButton";
        private string DefaultButtonClass = "defaultHierButton";

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Type { get; set; }

        [Parameter]
        public string Action { get; set; }

        private string GetButtonClass()
        {
            switch (this.Type)
            {
                case "Primary":
                    return this.PrimaryButtonClass;
                case "Secondary":
                    return this.SecondaryButtonClass;
                default:
                    return this.DefaultButtonClass;
            }
        }

        public void NavigateTo()
        {
            _navigationManager.NavigateTo(Action);

        }


        [Inject]
        private NavigationManager _navigationManager { get; set; }

        /*public void NavigateToReserveSeat()
        {
            _navigationManager.NavigateTo("/coworking/reserveer", false);
        }**/
    }
}
