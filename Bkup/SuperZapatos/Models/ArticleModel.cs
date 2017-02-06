using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace SuperZapatos.Models
{
    public class ArticleModel
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("StoreId")]
        public Guid StoreId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("TotalInShelf")]
        public decimal TotalInShelf { get; set; }

        [JsonProperty("TotalInVault")]
        public decimal TotalInVault { get; set; }

        public IEnumerable<ArticleModel> GetAllArticles()
        {
            List<ArticleModel> lista = new List<ArticleModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5268/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Article").Result;
            if (!response.IsSuccessStatusCode)
            {
                // Error control
                return lista;
            }

            var jsonArticles = JArray.Parse(response.Content.ReadAsStringAsync().Result);
            foreach (var x in jsonArticles)
            {
                ArticleModel article = JsonConvert.DeserializeObject<ArticleModel>(x.ToString());
                lista.Add(article);
            }

            return lista;
        }

        public static ArticleModel GetArticle(Guid id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5268/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            string api = string.Format("api/Article/{0}", id);
            HttpResponseMessage response = client.GetAsync(api).Result;
            if (!response.IsSuccessStatusCode)
            {
                // Error control
                return null;
            }

            var jsonArticle = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            ArticleModel article = JsonConvert.DeserializeObject<ArticleModel>(jsonArticle.ToString());

            return article;
        }
    }
}