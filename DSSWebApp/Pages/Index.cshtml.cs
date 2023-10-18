using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DSSWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Project Characteristics Questions
            ViewData["ProjectQuestion1"] = "How large is the project team?";
            ViewData["ProjectQuestion2"] = "How complex is the project?";
            ViewData["ProjectQuestion3"] = "How much uncertainty is there in the project?";
            ViewData["ProjectQuestion4"] = "How tight are the project's deadlines?";
            ViewData["ProjectQuestion5"] = "How constrained is the project's budget?";
            ViewData["ProjectQuestion6"] = "How involved is the customer in the project?";
            ViewData["ProjectQuestion7"] = "How high are the risk factors in the project?";
            ViewData["ProjectQuestion8"] = "What is the type of software project?";

            // Team Characteristics Questions
            ViewData["TeamQuestion1"] = "What is the average level of experience of the project team members?";
            ViewData["TeamQuestion2"] = "What is the average level of skills and expertise of the project team members?";
            ViewData["TeamQuestion3"] = "How good is the communication and collaboration within the project team?";
            ViewData["TeamQuestion4"] = "How high is the level of trust and commitment within the project team?";
            ViewData["TeamQuestion5"] = "How diverse is the project team in terms of culture and background?";
            ViewData["TeamQuestion6"] = "To what extent does your team have experience using agile software development methodologies?";
            ViewData["TeamQuestion7"] = "To what extent does your team have experience using cloud-based software development tools?";
            ViewData["TeamQuestion8"] = "How frequently do team members leave and join the team?";

            // Options for Questions
            ViewData["Option1"] = "1 = very low";
            ViewData["Option2"] = "2 = low";
            ViewData["Option3"] = "3 = medium";
            ViewData["Option4"] = "4 = high";
            ViewData["Option5"] = "5 = very high";

            // Modify options for specific questions
            ViewData["Option1PQ8"] = "1 = New Development";
            ViewData["Option2PQ8"] = "2 = Maintenance & Enhancement";
            ViewData["Option3PQ8"] = "3 = Integration";
            ViewData["Option4PQ8"] = "4 = Migration";
            ViewData["Option5PQ8"] = "5 = Evaluation";
        }

    }
}