using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace devops_project_web_t4.Shared.Components
{
    public partial class HierTextInput
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Type { get; set; }
    }
}
