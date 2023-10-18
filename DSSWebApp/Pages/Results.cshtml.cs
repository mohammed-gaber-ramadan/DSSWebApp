using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DSSWebApp.Pages
{
    public class ResultsModel : PageModel
    {
        [BindProperty]
        public string PQ1 { get; set; }
        // ... Repeat for other questions ...

        public string RecommendationHtml { get; set; }

        public void OnPost()
        {
            // Check the answers. For example:
            if (PQ1 == "1" )
            {
                RecommendationHtml = GetRecommendationHtml();
            }
            else
            {
                // No recommendation or you can provide other default recommendations
                RecommendationHtml = "<p>No recommendations available for your selection.</p>";
            }
        }

        private string GetRecommendationHtml()
        {
            return "Hello world";
        }
    }
}
