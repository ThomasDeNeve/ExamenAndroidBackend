using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace devops_project_web_t4.Shared.Components
{
    public partial class HierTable
    {
        [Parameter]
        public List<string> Headers { get; set; }

        [Parameter]
        public List<List<string>> TableData { get; set; }
    }
}
