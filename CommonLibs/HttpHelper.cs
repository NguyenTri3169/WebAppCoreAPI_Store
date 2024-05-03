using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CommonLibs
{
    public static class HttpHelper
    {
        public static async Task<string> SendPost(string url, string baseUrl, string jsonData)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //POST Method
                    StringContent queryString = new StringContent(jsonData);
                    var response = await client.PostAsync(baseUrl, queryString);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static async Task<string> SendGet(string url, string baseUrl)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method
                    
                    var response = await client.GetAsync(baseUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        
    }
}
