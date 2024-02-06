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
        public async Task<string> ScrapeNickname(string username, string label)
        {
            //string githubUrl = $"https://casadosdados.com.br/solucao/cnpj{username}";
            string htmlContent = await DownloadHtmlAsync(username);// (githubUrl);

            if (!string.IsNullOrEmpty(htmlContent))
            {
                return ExtractNickname(htmlContent, label);
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

        private string ExtractNickname(string htmlContent, string label)
        {
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlContent);

            // Use XPath to find the span element with the specified class
            HtmlNode nicknameNode = document.DocumentNode.SelectSingleNode($"//p[@class='has-text-weight-bold' and text()='{label}']");//("//title");// span[@class='p-nickname vcard-username d-block']");
            var valueNode = nicknameNode?.SelectSingleNode("following-sibling::p[not(contains(@data-v-81897e2b, '['))]/a");

            // Check if the node is found
            //return nicknameNode?.InnerText;
            return valueNode?.InnerText?.Trim().ToLower();
        }
    }

}
