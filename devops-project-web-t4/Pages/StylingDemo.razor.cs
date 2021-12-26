using System.Collections.Generic;

namespace devops_project_web_t4.Pages
{
    public partial class StylingDemo
    {
        private List<string> DropdownOptions = new List<string>()
        {
            "Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"
        };

        private List<string> TableHeaders = new List<string>()
        {
            "First name", "Last name", "Email"
        };

        private List<List<string>> TableData = new List<List<string>>()
        {
            new List<string>()
            {
                "Jan", "Janssen","JanJanssen@janssen.jn"
            }, new List<string>()
            {
                "Frank","Frankerson","FransFrankerson@frank.fr"
            }, new List<string>()
            {
                "Tim","Timmerman","TimTimmerman@timmerwerken.tm"
            }, new List<string>()
            {
                "Bill","Billbao","BillBilbao@bill.bl"
            },
        };
    }
}
