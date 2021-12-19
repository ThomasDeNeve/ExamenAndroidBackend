using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace devops_project_web_t4.Shared.Components
{
    public partial class HierTableWithPaging
    {
        [Inject]
        public NavigationManager MyNavManager { get; set; }

        [Parameter]
        public List<string> Headers { get; set; }

        [Parameter]
        public List<List<string>> TableData { get; set; }

        [Parameter]
        public int RecordsPerPage { get; set; }

        public bool BackLinkEnabled { get => _currentPage > 1 ? true : false; }
        public bool NextLinkEnabled { get => _currentPage < _numberOfPages ? true : false; }

        private int _currentPage = 1;
        private int _numberOfPages = 1;
        private List<List<string>> _tableData = new List<List<string>>();

        public HierTableWithPaging()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            SelectRows();
        }

        private void SelectRows()
        {
            int skipRecords = (_currentPage - 1) * RecordsPerPage;
            _tableData = TableData.Skip(skipRecords).Take(RecordsPerPage).ToList();

            if (TableData?.Count > 0)
            {
                _numberOfPages = (int)Math.Ceiling((double)TableData.Count / RecordsPerPage);
            }
        }

        private void PreviousPage()
        {
            _currentPage -= 1;
            SelectRows();
        }
        private void NextPage()
        {
            _currentPage += 1;
            SelectRows();
        }
    }
}
