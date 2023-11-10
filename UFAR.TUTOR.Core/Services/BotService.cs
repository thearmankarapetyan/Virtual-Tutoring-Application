///<summary>
/// Service class implementing the IBotService interface for handling bot-related operations.
/// Utilizes the OpenAI API to generate elaborative answers or explanations based on academic questions.
/// The provided question is used as a prompt for the OpenAI ChatGPTTurbo model.
/// The response is limited to a maximum of 4000 tokens.
///</summary>

using OpenAI_API;                 // OpenAI API client
using OpenAI_API.Chat;            // Classes related to OpenAI Chat API

namespace UFAR.TUTOR.Core.Services
{
    public class BotService : IBotService
    {
        // Method to generate a response for the provided academic question using the OpenAI API
        public string Request(string question)
        {
            // Construct a prompt by appending the question to a predefined string
            var prompt = "Please provide me with an elaborative answer or explanation, not exceeding 4000 tokens, regarding the following academic question: "
                + question;

            // API key for authenticating with the OpenAI API
            string apiKey = "sk-ptSxsSiOzkp7f6OiNKmgXXXXXXXXXXXXXXXXXXXXXX";

            string answer = string.Empty;  // Variable to store the generated answer

            var openai = new OpenAIAPI(apiKey);  // Create an instance of the OpenAI API client
            ChatRequest chatModel = new ChatRequest();

            // Set up the chat model with the provided prompt
            chatModel.Messages = new List<ChatMessage> { new ChatMessage() { Content = prompt } };
            chatModel.Model = OpenAI_API.Models.Model.ChatGPTTurbo0301;  // Specify the ChatGPTTurbo model
            chatModel.MaxTokens = 4000;  // Set the maximum length for both request and response

            // Request a chat completion from the OpenAI API
            var result = openai.Chat.CreateChatCompletionAsync(chatModel);

            // Check if the result is null (empty answer case)
            if (result == null)
                return string.Empty;

            // Iterate through the choices in the result and select the answer
            foreach (var item in result.Result.Choices)
            {
                answer = item.Message.Content;
            }

            // Return the generated answer
            return answer;
        }
    }
}
