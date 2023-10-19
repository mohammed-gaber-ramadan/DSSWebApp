using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DSSWebApp.Pages
{
    public class ResultsModel : PageModel
    {
        public Dictionary<string, string> Answers { get; set; } = new Dictionary<string, string>();


        public bool IsTrustRecommendation { get; set; }
        public bool IsTurnoverRecommendation { get; set; }
        public bool IsSkillsRecommendation { get; set; }
        public bool IsSupportBigTeamsRecommendation { get; set; }
        public bool IsSupporSmallTeamsRecommendation { get; set; }



        public void OnGet()
        {
            // Get the answers dictionary from the ViewData property.
            Answers = TempData["answers"] as Dictionary<string, string>;

            var strProjectTeamSizeAnswer = "";
            var strProjectComplexAnswer = "";
            var strProjectBudgetAnswer = "";

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
                if (answer.Key == "Q10")
                {
                    // What is the average level of skills and expertise of the project team members?
                    if (answer.Value == "Very low" || answer.Value == "Low" || answer.Value == "Medium")
                    {
                        IsSkillsRecommendation = true;
                    }
                    else
                    {
                        IsSkillsRecommendation = false;
                    }
                }
                if (answer.Key == "Q1")
                {
                    strProjectTeamSizeAnswer = answer.Value;
                }
                if (answer.Key == "Q2")
                {
                    strProjectComplexAnswer = answer.Value;
                }
                if (answer.Key == "Q5")
                {
                    strProjectBudgetAnswer = answer.Value;
                }
            }
            if ((strProjectTeamSizeAnswer == "Medium" || strProjectTeamSizeAnswer == "Large" || strProjectTeamSizeAnswer == "Very large")
                &&
                (strProjectComplexAnswer == "Medium" || strProjectComplexAnswer == "Complex" || strProjectComplexAnswer == "Very complex")
                && (strProjectBudgetAnswer == "Very loose" || strProjectBudgetAnswer == "Loose" || strProjectBudgetAnswer == "Medium"))
            {
                IsSupportBigTeamsRecommendation = true;
            }
            else
            {
                IsSupportBigTeamsRecommendation = false;
            }
            if ((strProjectTeamSizeAnswer == "Small" || strProjectTeamSizeAnswer == "Very small")
                &&
                (strProjectComplexAnswer == "Simple" || strProjectComplexAnswer == "Very simple")
                && (strProjectBudgetAnswer == "Tight" || strProjectBudgetAnswer == "Very tight"))
            {
                IsSupporSmallTeamsRecommendation = true;
            }
            else
            {
                IsSupporSmallTeamsRecommendation = false;
            }
        }

        public void OnPost()
        {

        }
    }
}
