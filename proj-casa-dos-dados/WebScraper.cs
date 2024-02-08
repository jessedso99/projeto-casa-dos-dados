using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using OfficeOpenXml;
using System.Net.Http;
using System.Threading.Tasks;

namespace proj_casa_dos_dados
{
    class WebScraper
    {
        public async Task<string> ScrapeCnpjDados(string cnpjLink, string label)
        {
            string htmlContent = await DownloadHtmlAsync(cnpjLink);

            if (!string.IsNullOrEmpty(htmlContent))
            {
                return ExtractCnpjDados(htmlContent, label);
            }
            else
            {
                return null;
            }
        }

        private async Task<string> DownloadHtmlAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
                return await client.GetStringAsync(url);
            }
        }

        private string ExtractCnpjDados(string htmlContent, string label)
        {
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlContent);

            // Usando XPath para achar os elementos com a classes especificada
            HtmlNode cnpjNode = document.DocumentNode.SelectSingleNode($"//p[@class='has-text-weight-bold' and text()='{label}']");
            var dadosCnpjNode = cnpjNode?.SelectSingleNode("following-sibling::p[not(contains(@data-v-81897e2b, '['))]/a");

            // Checando se o node foi encontrado e retornando o seu valor
            return dadosCnpjNode?.InnerText?.Trim().ToLower();
        }
    }

}
