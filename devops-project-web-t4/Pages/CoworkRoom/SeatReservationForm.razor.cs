﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace devops_project_web_t4.Pages.CoworkRoom
{
    public partial class SeatReservationForm
    {
        [Parameter]
        public int Id { get; set; }

        public string SubName = "HIER.af en toe";

        [Inject]
        public IReservationController ReservationController { get; set; }
        [Inject]
        public ISubscriptionController SubscriptionController { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        private string _userName;
        private AuthenticationState state;

        public void Confirm()
        {
            if (state.User.Identity.IsAuthenticated)
            {
                if (HasSub())
                {
                    ReservationController.ConfirmReservation(Id, _userName);
                    _navigationManager.NavigateTo("/coworking/overzicht");
                }
                else
                {
                    SubscriptionController.ConfirmSubscription(SubName, _userName);

                    ReservationController.ConfirmReservation(Id, _userName);
                    _navigationManager.NavigateTo("/coworking/overzicht");
                }
            }
            //gebruiker kan enkel reserveren als die is ingelogd
                /*if (state.User.Identity.IsAuthenticated && SubscriptionController.HasSub(_userName))
                {
                    //SubscriptionController.ConfirmSubscription(SubName, _userName);

                    ReservationController.ConfirmReservation(Id, _userName);
                    _navigationManager.NavigateTo("/coworking/overzicht");
                }*/
        }

        public void Cancel()
        {
            _navigationManager.NavigateTo("/coworking/overzicht");
        }

        protected override async Task OnInitializedAsync()
        {
            state = await AuthState.GetAuthenticationStateAsync();
            _userName = state.User.Identity.Name;

            await base.OnInitializedAsync();
        }

        public void RadioSelection(ChangeEventArgs args)
        {
            SubName = args.Value.ToString();
        }

        public bool LoggedIn()
        {
            if (!(_userName == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasSub()
        {
            return SubscriptionController.HasSub(_userName);
        }
    }
}
