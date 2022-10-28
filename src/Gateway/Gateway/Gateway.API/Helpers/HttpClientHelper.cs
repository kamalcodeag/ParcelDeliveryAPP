using Newtonsoft.Json;
using System.Text;

namespace Gateway.API.Helpers
{
    public static class HttpClientHelper
    {
        public static async Task<T> GetAsync<T>(string url)
        {
            T? tData = default(T);

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }

                    using (HttpContent content = response.Content)
                    {
                        string serializedContent = await content.ReadAsStringAsync();

                        if (serializedContent == string.Empty)
                        {
                            return tData;
                        }

                        if (serializedContent != null)
                        {
                            tData = JsonConvert.DeserializeObject<T>(serializedContent) ?? throw new ArgumentNullException();
                            return tData;
                        }
                    }
                }
            }

            return tData;
        }

        public static async Task<T> PostAsync<T>(string url, string json)
        {
            T? tData = default(T);

            using (HttpClient client = new HttpClient())
            {
                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await client.PostAsync(url, requestContent))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }

                    using (HttpContent content = response.Content)
                    {
                        string serializedContent = await content.ReadAsStringAsync();

                        if (serializedContent == string.Empty)
                        {
                            return tData;
                        }

                        if (serializedContent != null)
                        {
                            tData = JsonConvert.DeserializeObject<T>(serializedContent) ?? throw new ArgumentNullException();
                            return tData;
                        }
                    }
                }
            }

            return tData;
        }

        public static async Task<T> PutAsync<T>(string url, string json)
        {
            T? tData = default(T);

            using (HttpClient client = new HttpClient())
            {
                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await client.PutAsync(url, requestContent))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }

                    using (HttpContent content = response.Content)
                    {
                        string serializedContent = await content.ReadAsStringAsync();

                        if (serializedContent == string.Empty)
                        {
                            return tData;
                        }

                        if (serializedContent != null)
                        {
                            tData = JsonConvert.DeserializeObject<T>(serializedContent) ?? throw new ArgumentNullException();
                            return tData;
                        }
                    }
                }
            }

            return tData;
        }

        public static async Task<T> DeleteAsync<T>(string url)
        {
            T? tData = default(T);

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.DeleteAsync(url))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }

                    using (HttpContent content = response.Content)
                    {
                        string serializedContent = await content.ReadAsStringAsync();

                        if (serializedContent == string.Empty)
                        {
                            return tData;
                        }

                        if (serializedContent != null)
                        {
                            tData = JsonConvert.DeserializeObject<T>(serializedContent) ?? throw new ArgumentNullException();
                            return tData;
                        }
                    }
                }
            }

            return tData;
        }
    }
}
