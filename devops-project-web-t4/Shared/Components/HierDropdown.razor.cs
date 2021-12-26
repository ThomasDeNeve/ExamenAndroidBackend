using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace devops_project_web_t4.Shared.Components
{
    public partial class HierDropdown
    {
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public List<string> Options { get; set; }
    }
}
