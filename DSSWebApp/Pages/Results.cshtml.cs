using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DSSWebApp.Pages
{
    public class ResultsModel : PageModel
    {
        [BindProperty]
        public string PQ1
        {
            get
            {
                return TempData["PQ1"] as string;
            }
            set
            {
                PQ1 = value;
            }
        }
        // ... Repeat for other questions ...

        public string RecommendationHtml { get; set; }

        public void OnGet()
        {
            // Check the answers. For example:
            if (PQ1 == "1")
            {
                RecommendationHtml = GetRecommendationHtml();
            }
            else
            {
                // No recommendation or you can provide other default recommendations
                RecommendationHtml = "<p>No recommendations available for your selection.</p>";
            }
        }

        public void OnPost()
        {
            
        }

        private string GetRecommendationHtml()
        {
            return "Hello world";
        }
    }
}
