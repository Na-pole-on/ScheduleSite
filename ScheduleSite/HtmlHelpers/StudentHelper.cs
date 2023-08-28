using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScheduleSite.ViewModels;

namespace ScheduleSite.HtmlHelpers
{
    public static class StudentHelper
    {
        public static HtmlString StudentPartyList(this IHtmlHelper html, ListOfStudentViewModel models)
        {
            string result = "<select class=\"form-select\" name=\"id\">";

            if(models.Parties.Count() > 0)
            {
                if (models.Party is null)
                    result = $"{result}<option value=\"{0}\" selected>Choose a party</option>";

                foreach (var party in models.Parties)
                {
                    if (models.Party is not null)
                    {
                        if (models.Party.PartyIdentifier == party.PartyIdentifier)
                        {
                            result = $"{result}<option value=\"{party.Id}\" selected>{party.PartyIdentifier}</option>";
                            continue;
                        }
                    }

                    result = $"{result}<option value=\"{party.Id}\">{party.PartyIdentifier}</option>";
                }
            }
            else
                result = $"{result}<option value=\"{0}\" selected>You don't have party</option>";


            return new HtmlString($"{result}</select>");
        }
    }
}
