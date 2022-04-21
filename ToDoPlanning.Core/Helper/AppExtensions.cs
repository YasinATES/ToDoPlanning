using Newtonsoft.Json.Linq;
using ToDoPlanning.Entities.Helper;

namespace ToDoPlanning.Core.Helper
{
    public static class AppExtensions
    {
        public static int GetIntField(this JToken token, string field)
        {
            return token[field] != null ? int.Parse(token[field].ToString()) : 0;
        }

        public static string GetStringField(this JToken token, string field)
        {
            return token[field] != null ? token[field].ToString() : string.Empty;
        }

        public static int GetSelectTokenInt(this JToken token, string field)
        {
            return token.SelectToken(field) != null ? int.Parse(token.SelectToken(field).ToString()) : 0;
        }

        public static string GetFirstFieldName(this JToken token)
        {
            return token.ToObject<JObject>() != null ? token.ToObject<JObject>().Properties().First().Name : string.Empty;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = new Random().Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static JArray CallApi(string api)
        {
            HttpClient _httpClient = new HttpClient();

            var result = _httpClient.GetAsync("https://localhost:7276/" + api);
            result.Wait();

            return JArray.Parse(result.Result.Content.ReadAsStringAsync().Result);
        }

        public static void CreateHelper(this BaseEntity entity)
        {
            entity.CreateAt = DateTime.Now;
            entity.Status = true;
            entity.UpdateAt = DateTime.Now;
        }

        public static void UpdateHelper(this BaseEntity entity)
        {
            entity.UpdateAt = DateTime.Now;
        }
    }
}
