using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using System.Security.Policy;
using proj_casa_dos_dados;
//Install-Package System.Net.Http
//Install-Package Newtonsoft.Json
//Install-Package EPPlus // export to excel

namespace proj_casa_dos_dados
{
    public class ApiService //internal class 
    {
        public static async Task<string> PerformApiRequestAsync()
        {
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);

                var json = "{\"query\":{\"termo\":[],\"atividade_principal\":[],\"natureza_juridica\":[],\"uf\":[],\"municipio\":[],\"bairro\":[],\"situacao_cadastral\":\"ATIVA\",\"cep\":[],\"ddd\":[]},\"range_query\":{\"data_abertura\":{\"lte\":null,\"gte\":\"2024-01-01\"},\"capital_social\":{\"lte\":null,\"gte\":null}},\"extras\":{\"somente_mei\":false,\"excluir_mei\":true,\"com_email\":true,\"incluir_atividade_secundaria\":false,\"com_contato_telefonico\":true,\"somente_fixo\":false,\"somente_celular\":false,\"somente_matriz\":false,\"somente_filial\":false},\"page\":1}";
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                string apiUrl = "https://api.casadosdados.com.br/v2/public/cnpj/search";

                var response = await client.PostAsync(apiUrl, data);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                else
                {
                    return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                }
            }
        }
    }
}


//string jsonResponse = "[{\"Id\":1,\"Name\":\"John\",\"Age\":30},{\"Id\":2,\"Name\":\"Alice\",\"Age\":25}]";
//List<cnpj> dados = JsonConvert.DeserializeObject<List<cnpj>>(jsonResponse);
//List<string> tabularData = OrganizeDataIntoTabularFormat(dados);

//Console.WriteLine("Id\tName\tAge");
//foreach (cnpj encontardos in dados)
//{
//    Console.WriteLine($"{encontardos.Id}\t{encontardos.Name}\t{encontardos.Age}");
//}