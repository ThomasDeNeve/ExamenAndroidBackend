using devops_project_web_t4.Areas.Controllers;
using Microsoft.AspNetCore.Components;
using System;
using System.Globalization;

namespace devops_project_web_t4.Pages.Problems
{
    public partial class Problem
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private IProblemController ProblemController { get; set; }
        [Parameter]
        public string ProblemDescription { get; set; }
        [Parameter]
        public int LocationId { get; set; }
        [Parameter]
        public string LocationDescription { get; set; }

        private bool _problemPosted;


        private CultureInfo _culture = CultureInfo.InvariantCulture;

        private void PostProblem()
        {
            try
            {
                ProblemController.PostNewProblem(ProblemDescription, LocationId, LocationDescription);
                _problemPosted = true;
                //_navigationManager.NavigateTo("/");
            }
            catch(Exception e)
            {
                throw new NotImplementedException("Not Implemented yet");
            }
        }
    }
}