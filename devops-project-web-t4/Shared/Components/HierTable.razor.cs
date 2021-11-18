using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

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
