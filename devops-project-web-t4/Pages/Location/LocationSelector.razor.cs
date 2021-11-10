using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace devops_project_web_t4.Pages.Location
{
    public partial class LocationSelector
    {
        [Parameter]
        public string TitlePinkUnderline { get; set; }

        [Parameter]
        public string Message { get; set; }

        [Parameter]
        public EventCallback Navigate { get; set; }
    }
}
