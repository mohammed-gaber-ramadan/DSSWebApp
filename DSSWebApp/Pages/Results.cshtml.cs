using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DSSWebApp.Pages
{
    public class ResultsModel : PageModel
    {
        public Dictionary<string, string> Answers { get; set; } = new Dictionary<string, string>();


        public bool IsTrustRecommendation { get; set; }
        public bool IsTurnoverRecommendation { get; set; }


        public void OnGet()
        {
            // Get the answers dictionary from the ViewData property.
            Answers = TempData["answers"] as Dictionary<string, string>;

            //TrustRecommendationHtml = "<p>No recommendations available for your selection.</p>";

            foreach (var answer in Answers)
            {
                if (answer.Key == "Q12")
                {
                    //How high is the level of trust and commitment within the project team?
                    if (answer.Value == "Very low" || answer.Value == "Low" || answer.Value == "Medium")
                    {
                        IsTrustRecommendation = true;
                    }
                    else
                    {
                        IsTrustRecommendation = false;
                    }
                }
                if (answer.Key == "Q16")
                {
                    //How high is the level of trust and commitment within the project team?
                    if (answer.Value == "Sometimes" || answer.Value == "Often" || answer.Value == "Very often")
                    {
                        IsTurnoverRecommendation = true;
                    }
                    else
                    {
                        IsTurnoverRecommendation = false;
                    }
                }
            }
        }

        public void OnPost()
        {

        }
    }
}
