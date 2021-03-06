using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Components;

namespace devops_project_web_t4.Pages.MeetingRoom
{
    public partial class MeetingRoomLocationSelector
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }

        private string Message = @"Hou je van een groene omgeving? Of liever gezellig in het centrum van Aalst dicht bij het station? 
            HIER. hebben we voor elk bedrijf wat wils. Onze twee locaties hebben samen zeven zalen met een capaciteit van maximum 120 personen.
          Vergaderen met de board of directors, teammeetings, leuke workshops of een presentatie geven, dat kan HIER. allemaal! 
            De meeting & opleidingszalen zijn voorzien van de allernieuwste snufjes, van Sonos boxen tot de nieuwste digi-schermen op de markt.
            Koffie, water en thee zijn steeds inbegrepen en audiovisueel materiaal is uiteraard ook aanwezig in de zaal.";

        [Inject]
        ILocationRepository LocationRepository { get; set; }
    }
}
