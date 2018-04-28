using HtmlAgilityPack;
using Robot.Common.Grab;
using Robot.Domain.Grab;
using Robot.IService.Grab;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Service.Grab
{
    public class BaiduSearchService : ISearchService
    {
        public async Task<string> GetHtmlAsync(string keyword, int page)
        {
            var searchUrl = String.Format("https://www.baidu.com/s?wd={0}&&pn={1}", Uri.EscapeDataString(keyword), (page - 1) * 10);
            return await this.GetHtmlAsync(searchUrl);
        }
        public async Task<List<SearchDataModel>> GetDataAsync(string html)
        {
            return await Task.Run(() =>
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
                foreach (var script in htmlDoc.DocumentNode.Descendants("script").ToArray())
                    script.Remove();
                foreach (var style in htmlDoc.DocumentNode.Descendants("style").ToArray())
                    style.Remove();
                foreach (var comment in htmlDoc.DocumentNode.SelectNodes("//comment()").ToArray())
                    comment.Remove();//新增的代码
                var mainNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='content_left']");
                var listResult = new List<SearchDataModel>();
                foreach (var item in mainNode.ChildNodes)
                {
                    if (!item.HasClass("c-container") || item.Name == "#text") continue;
                    var result = this.GetItem(item);
                    listResult.Add(result);
                }
                return listResult;
            });
        }

        private async Task<string> GetHtmlAsync(string url)
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PhantomJS", "phantomjs.exe");
            var arguments = ".\\PhantomJS\\_ReqHtml.js " + url;
            return await ProcessHelper.Action(fileName, arguments);
        }

        public async Task<string> GetRealAddressAsync(string address)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, address);
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Found)
                    return response.Headers.Location.AbsoluteUri;
                else
                    return response.RequestMessage.RequestUri.AbsoluteUri;
            }
            catch
            {
                var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PhantomJS", "phantomjs.exe");
                var arguments = ".\\PhantomJS\\_ReqUrl.js " + address;
                return await ProcessHelper.Action(fileName, arguments);
            }
        }

        public SearchDataModel GetItem(HtmlNode node)
        {
            var result = new SearchDataModel();
            var titleNode = node.SelectSingleNode(node.XPath + "//h3[1]//a[1]");
            result.Title = titleNode.InnerText;
            result.SourceUrl = titleNode.GetAttributeValue("href", "http://a.b.c");
            var contentNode = node.SelectSingleNode(node.XPath + "//div[1]");
            result.Content = contentNode.InnerText.Replace("\r\n", "").Replace("\t", "");
            return result;
        }
    }
}