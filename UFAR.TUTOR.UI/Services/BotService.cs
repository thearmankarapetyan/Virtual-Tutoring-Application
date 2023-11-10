namespace UFAR.TUTOR.UI.Services
{
    public class BotService : IBotService
    {
        public string BotRequest(string question)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:7041/api/Bot/GetExplanationAnswer?subject={question}").Result;
            if (response != null && response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                return responseContent;
            }
            return "";
        }
    }
}
