using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

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

        private string teamSizeAnswer = "", complexAnswer = "", budgetAnswer = "";

        public void OnGet()
        {
            if (!TempData.TryGetValue("answers", out var answersData) || !(answersData is Dictionary<string, string> tempAnswers))
            {
                return;
            }

            Answers = tempAnswers;

            foreach (var answer in Answers)
            {
                switch (answer.Key)
                {
                    case "Q12":
                        IsTrustRecommendation = CheckValues(answer.Value, new[] { "Very low", "Low", "Medium" });
                        break;
                    case "Q16":
                        IsTurnoverRecommendation = CheckValues(answer.Value, new[] { "Sometimes", "Often", "Very often" });
                        break;
                    case "Q10":
                        IsSkillsRecommendation = CheckValues(answer.Value, new[] { "Very low", "Low", "Medium" });
                        break;
                    case "Q1":
                    case "Q2":
                    case "Q5":
                        CheckProjectConditions(answer);
                        break;
                    case "Q8":
                        IsProjectTypeKanbanRecommendation = CheckValues(answer.Value, new[] { "Maintenance & enhancement", "Evaluation" });
                        IsProjectTypeScrumRecommendation = CheckValues(answer.Value, new[] { "New development", "Integration", "Migration" });
                        break;
                    case "Q15":
                        IsCloudToolsRecommendation = CheckValues(answer.Value, new[] { "Very little experience", "Some experience", "Moderate experience" });
                        break;
                    case "Q3":
                        IsAgileRecommendation = CheckValues(answer.Value, new[] { "Medium", "High", "Very high" });
                        IsWaterfallRecommendation = CheckValues(answer.Value, new[] { "Very low", "Low" });
                        break;
                }
            }
        }

        private void CheckProjectConditions(KeyValuePair<string, string> answer)
        {
            if (answer.Key == "Q1") teamSizeAnswer = answer.Value;
            if (answer.Key == "Q2") complexAnswer = answer.Value;
            if (answer.Key == "Q5") budgetAnswer = answer.Value;

            IsSupportBigTeamsRecommendation = CheckValues(teamSizeAnswer, new[] { "Medium", "Large", "Very large" }) &&
                                              CheckValues(complexAnswer, new[] { "Medium", "Complex", "Very complex" }) &&
                                              CheckValues(budgetAnswer, new[] { "Very loose", "Loose", "Medium" });

            IsSupporSmallTeamsRecommendation = CheckValues(teamSizeAnswer, new[] { "Small", "Very small" }) &&
                                               CheckValues(complexAnswer, new[] { "Simple", "Very simple" }) &&
                                               CheckValues(budgetAnswer, new[] { "Tight", "Very tight" });
        }

        private static bool CheckValues(string value, string[] matches)
        {
            return Array.Exists(matches, match => match == value);
        }

        public void OnPost()
        {
            // Logic for post if needed
        }
    }
}
