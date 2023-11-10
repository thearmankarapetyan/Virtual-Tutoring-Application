///<summary>
/// Interface defining the contract for a BotService in the UFAR.TUTOR.Core.Services namespace.
/// Specifies a single method, Request, which takes a subject as a parameter and returns a string.
/// This interface serves as a blueprint for classes providing bot-related functionalities.
///</summary>

namespace UFAR.TUTOR.Core.Services
{
    // Definition of the IBotService interface
    public interface IBotService
    {
        // Method signature for requesting bot responses based on a subject
        public string Request(string subject);
    }
}
