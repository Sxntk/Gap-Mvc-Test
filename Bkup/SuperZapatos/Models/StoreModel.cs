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
    public class StoreModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public IEnumerable<StoreModel> GetAllArticles()
        {
            List<StoreModel> lista = new List<StoreModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5268/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Store").Result;
            if (!response.IsSuccessStatusCode)
            {
                // Error control
                return lista;
            }

            var jsonArticles = JArray.Parse(response.Content.ReadAsStringAsync().Result);
            foreach (var x in jsonArticles)
            {
                StoreModel store = JsonConvert.DeserializeObject<StoreModel>(x.ToString());
                lista.Add(store);
            }

            return lista;
        }
    }
}