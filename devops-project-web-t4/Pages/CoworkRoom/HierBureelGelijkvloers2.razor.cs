using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.State;

namespace devops_project_web_t4.Pages.CoworkRoom
{
    public partial class HierBureelGelijkvloers2
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
