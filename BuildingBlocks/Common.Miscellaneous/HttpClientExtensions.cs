using Common.Miscellaneous.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Common.Miscellaneous
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (response.Content.Headers.ContentLength == 0 || !response.IsSuccessStatusCode)
            {
                ErrorModel error = new ErrorModel();
                error.StatusCode = (int)response.StatusCode;
                error.ErrorMessage = response.ReasonPhrase;
                var errorSerialize = JsonSerializer.Serialize(error);
                var res = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.NoContent)
                {
                    Content = new StringContent(errorSerialize)
                };
                var errorString = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonSerializer.Deserialize<T>(errorString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpClient.PostAsync(url, content);
        }
        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data, int programId)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.Add("programId", Convert.ToString(programId));
            return httpClient.PostAsync(url, content);
        }



        public static Task<HttpResponseMessage> GetAsyncWithToken(this HttpClient httpClient, string url, int programId, string token)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("programId", programId.ToString());
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = httpClient.GetAsync(url);
            return response;
        }
    }
}
