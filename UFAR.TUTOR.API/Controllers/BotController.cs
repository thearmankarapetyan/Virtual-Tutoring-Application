///<summary>
/// API controller for handling requests related to a chatbot.
/// Defines an endpoint for retrieving explanations based on a given subject.
/// Utilizes dependency injection for the Bot service and Entity Framework Core for database interactions.
/// Logs requests and responses in the AiLogs table of the ApplicationDbContext.
///</summary>

using Microsoft.AspNetCore.Mvc;               // MVC framework for handling HTTP requests
using UFAR.TUTOR.Core.Services;                // Custom services for the application
using UFAR.TUTOR.Data;                         // Data-related components for the application
using UFAR.TUTOR.Data.Entities;               // Entity class for AiLogs

namespace UFAR.TUTOR.API.Controllers
{
    [Route("api/[controller]")]                 // Route prefix for the controller
    [ApiController]                             // Attribute indicating that this class is an API controller
    public class BotController : ControllerBase
    {
        private readonly IBotService _botService;         // Service for handling bot-related operations
        private readonly ApplicationDbContext _context;   // Database context for interacting with AiLogs

        // Constructor to initialize the controller with required services
        public BotController(IBotService botService, ApplicationDbContext context)
        {
            _botService = botService;     // Injected Bot service
            _context = context;           // Injected Database context
        }

        // HTTP GET method with route "api/Bot/GetExplanationAnswer" and a parameter "subject"
        [HttpGet("GetExplanationAnswer")]
        // Method to handle GET requests with a subject parameter
        public IActionResult SendRequest(string subject)
        {
            // Check if the subject is not null or empty
            if (!string.IsNullOrEmpty(subject))
            {
                // Call the bot service to get a response based on the provided subject
                var response = _botService.Request(subject);

                // Log the request and response in the database
                _context.AiLogs.Add(new AiLog()
                {
                    Request = subject,
                    Response = response
                });

                // Save changes to the database
                _context.SaveChanges();

                // Return HTTP 200 OK status with the bot's response
                return Ok(response);
            }

            // Return HTTP 400 Bad Request status with a message if the subject is empty
            return BadRequest("Empty request");
        }
    }
}
