namespace devops_project_web_t4.Pages.CoworkRoom
{
    public partial class HierCoworkingGelijkvloers1
    {
        protected override void OnInitialized()
        {
            StateContainer.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            StateContainer.OnChange -= StateHasChanged;
        }
    }
}
