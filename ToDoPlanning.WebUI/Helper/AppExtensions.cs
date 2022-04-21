using ToDoPlanning.Entities.Concrete;
using ToDoPlanning.WebUI.Models;

namespace ToDoPlanning.WebUI.Helper
{
    public static class AppExtensions
    {
        public static bool CallCoreApi()
        {
            HttpClient _httpClient = new HttpClient();

            try
            {
                var result = _httpClient.GetAsync("https://localhost:7276/Provider");
                result.Wait();
            }
            catch { return false; }

            return true;
        }
    }
}
