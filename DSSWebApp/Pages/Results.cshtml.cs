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
        public bool IsProjectTypeKanbanRecommendation { get; set; }
        public bool IsProjectTypeScrumRecommendation { get; set; }
        public bool IsCloudToolsRecommendation { get; set; }
        public bool IsAgileRecommendation { get; set; }
        public bool IsWaterfallRecommendation { get; set; }


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
                //How large is the project team?
                if (answer.Key == "Q1")
                {
                    strProjectTeamSizeAnswer = answer.Value;
                }
                //How complex is the project?
                if (answer.Key == "Q2")
                {
                    strProjectComplexAnswer = answer.Value;
                }
                //How constrained is the project's budget?
                if (answer.Key == "Q5")
                {
                    strProjectBudgetAnswer = answer.Value;
                }
                //What is the type of software project?
                if (answer.Key == "Q8")
                {
                    if (answer.Value == "Maintenance & enhancement" || answer.Value == "Evaluation")
                    {
                        IsProjectTypeKanbanRecommendation = true;
                    }
                    else
                    {
                        IsProjectTypeKanbanRecommendation = false;
                    }
                    if (answer.Value == "New development" || answer.Value == "Integration" || answer.Value == "Migration")
                    {
                        IsProjectTypeScrumRecommendation = true;
                    }
                    else
                    {
                        IsProjectTypeScrumRecommendation = false;
                    }
                }
                //To what extent does your team have experience using cloud-based software development tools?
                if (answer.Key == "Q15")
                {
                    if (answer.Value == "Very little experience" || answer.Value == "Some experience" || answer.Value == "Moderate experience")
                    {
                        IsCloudToolsRecommendation = true;
                    }
                    else
                    {
                        IsCloudToolsRecommendation = false;
                    }
                }
                //How much uncertainty is there in the project?
                if (answer.Key == "Q3")
                {
                    if (answer.Value == "Medium" || answer.Value == "High" || answer.Value == "Very high")
                    {
                        IsAgileRecommendation = true;
                    }
                    else
                    {
                        IsAgileRecommendation = false;
                    }
                    if (answer.Value == "Very low" || answer.Value == "Low")
                    {
                        IsWaterfallRecommendation = true;
                    }
                    else
                    {
                        IsWaterfallRecommendation = false;
                    }
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
