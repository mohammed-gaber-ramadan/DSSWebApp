using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DSSWebApp.Pages
{
    public class ResultsModel : PageModel
    {
        public Dictionary<string, string> Answers { get; set; } = new Dictionary<string, string>();


        public string TrustRecommendationHtml { get; set; }

        public void OnGet()
        {
            TrustRecommendationHtml = GetRecommendationHtml();

            // Get the answers dictionary from the ViewData property.
            Answers = TempData["answers"] as Dictionary<string, string>;

            TrustRecommendationHtml = "<p>No recommendations available for your selection.</p>";

            foreach (var answer in Answers)
            {
                if (answer.Key == "Q12")
                {
                    //How high is the level of trust and commitment within the project team?
                    if (answer.Value == "Very low" || answer.Value == "Low" || answer.Value == "Medium")
                    {
                        TrustRecommendationHtml = GetRecommendationHtml();
                    }
                }
            }
        }

        public void OnPost()
        {

        }

        private string GetRecommendationHtml()
        {
            return @"
<div class='container mt-5'>
    <div class='custom-border'>
        <p class='lead'>We recommend the use of the <strong>Theseus prototype</strong> to address the team awareness and trust issues in your project. The Theseus prototype is a promising tool that visualizes and analyzes the availability and responsiveness of remote team members, which can help to build trust and improve collaboration. The Theseus prototype architecture consists of four components:</p>
        
        <ul class='list-group list-group-flush'>
            <li class='list-group-item'><strong>1- Collector:</strong> This component uses JIRA's REST API to connect to a project's JIRA issue repository, retrieves all open issues grouped by project, and stores them in an object database.</li>
            <li class='list-group-item'><strong>2- Extractor/generator:</strong> This component extracts issues, their priorities, and assigned developers from the database and cross-links the issues and developers associated with them with a generated set of developer names and pictures. The generator component also generates a set of e-mail responsiveness times for each developer using a normal distribution with a mean reply time of 24 hours. It then standardizes the scores for each team member. The generator also creates locations for team members using locations from a previous study and times of each day of the week when developers are active at the keyboard.</li>
            <li class='list-group-item'><strong>3- Analyzer:</strong> This component creates a bi-partite, socio-technical graph where nodes are either people or software artifacts (e.g., work items), and edges are one of several relationships (e.g., work item assigned to person).</li>
            <li class='list-group-item'><strong>4- Visualizer:</strong> This component creates one of several types of visualizations using the socio-technical graph created by the analyzer as input.</li>
        </ul>
        
        <p class='mt-4 mb-2'><strong>The Theseus prototype provides three visualizations of the availability and responsiveness of remote team members:</strong></p>
        
        <ul class='list-group list-group-flush'>
            <li class='list-group-item'><strong>1- Average reply time:</strong> This visualization shows the average reply time of a remote team member compared to other team members at the same location. The average time is marked by a small vertical 62 notch. Developers who tend to reply quicker than average have a blue dot to the left of the notch; developers who reply slower have a blue dot to the right of the notch. The horizontal distance from the notch is calculated from the number of standard deviations away from the average.</li>
            <li class='list-group-item'><strong>2- Project participation:</strong> This visualization shows a developer's participation in each project with each slice of the pie corresponding to the number of assigned work items to that developer in the project.</li>
            <li class='list-group-item'><strong>3- Time zone overlap:</strong> This visualization shows, for each hour, the remote developer's corresponding time. It shows how many overlapping work hours there are between the user of Theseus and the remote developer. A black dot on each hour indicates that the developer is active (at the keyboard) during that time.</li>
        </ul>
        
        <p class='mt-4'>The Theseus prototype has the potential to be a valuable tool for software teams. By helping teams to understand the availability and responsiveness of their remote team members, the prototype can help to build trust and improve collaboration. For example, the prototype could be used to help teams to identify remote team members who may be overloaded or who may be working in a different time zone. The prototype could also be used to help teams to identify remote team members who are working on a lot of projects or who are focused on a particular project.</p>
        
        <img src='images/1.png' alt='Theseus Image 1'>
        
        <img src='images/2.png' alt='Theseus Image 2'>
    </div>
</div>
";
        }
    }
}
