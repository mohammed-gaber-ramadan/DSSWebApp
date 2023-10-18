using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DSSWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public List<Question> Questions { get; set; }

        public void OnGet()
        {
            try
            {
                var questionsJson = System.IO.File.ReadAllText("questions.json");
                Questions = JsonConvert.DeserializeObject<List<Question>>(questionsJson);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                _logger.LogError(ex, "questions.json file was not found.");
                ModelState.AddModelError(string.Empty, "There was an error loading the questions. Please try again later.");
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Error deserializing questions.json.");
                ModelState.AddModelError(string.Empty, "There was an error processing the questions. Please try again later.");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Unexpected error.");
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
            }
        }

        public IActionResult OnPost()
        {
            var answers = new Dictionary<string, string>();
            foreach (var key in Request.Form.Keys)
            {
                if (key != "__RequestVerificationToken") // Exclude the CSRF token
                {
                    answers.Add(key, Request.Form[key]);
                }
            }

            // Logging the answers for debug purposes
            _logger.LogInformation("Received answers: {@Answers}", answers);

            TempData["answers"] = answers;
            return RedirectToPage("/Results");
        }
    }
}
