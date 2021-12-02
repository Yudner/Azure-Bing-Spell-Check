using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AzureSpellCheck.Infrastructure.SpellCheck
{
    public class SpellCheckService: ISpellCheckService
    {
        static string Key = "YOUR KEY";
        static string EndPoint = "https://api.cognitive.microsoft.com/bing/v7.0/SpellCheck";
        static string Mkt = "?mkt=es-es";
        static string Mode = "&mode=spell"; //spell - proof

        public async Task<SpellCheckModel> Execute(string text)
        {
            try
            {
                string Text = $"&text={text}";
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage())
                {
                    request.Method = HttpMethod.Get;
                    request.RequestUri = new Uri($"{EndPoint}{Mkt}{Mode}{Text}");
                    request.Headers.Add("Ocp-Apim-Subscription-Key", Key);

                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var model = JsonConvert.DeserializeObject<SpellCheckModel>(responseBody);
                        return model;
                    }

                    return new SpellCheckModel();
                }
            }
            catch (Exception e)
            {
                return new SpellCheckModel();
            }
        }
    }
}
