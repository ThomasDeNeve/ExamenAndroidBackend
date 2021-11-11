using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Controllers;
using devops_project_web_t4.Areas.State;
using Microsoft.AspNetCore.Components;

namespace devops_project_web_t4.Pages.CoworkRoom
{
    public partial class HierBureelGelijkvloers1
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