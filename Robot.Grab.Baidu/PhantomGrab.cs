using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Grab.Baidu
{
    public class PhantomGrab
    {
        public PhantomGrab()
        { }
        public async Task<string> Get(string keyword, int page = 1)
        {
            var searchUrl = String.Format("https://www.baidu.com/s?wd={0}&&pn={1}", Uri.EscapeDataString(keyword), (page - 1) * 10);
            return await this.GetHtml(searchUrl);
        }
        public async Task Analysis(string html)
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
            var listResult = new List<BaiduListItemModel>();
            foreach (var item in mainNode.ChildNodes)
            {
                if (!item.HasClass("c-container") || item.Name== "#text") continue;
                var result = await this.GetItem(item);
                listResult.Add(result);
                Console.Write(result.ToString());
            }
        }
        public async Task<BaiduListItemModel> GetItem(HtmlNode node)
        {
            var result = new BaiduListItemModel();
            var titleNode = node.SelectSingleNode(node.XPath + "//h3[1]//a[1]");
            result.Title = titleNode.InnerText;
            result.Address = titleNode.GetAttributeValue("href", "http://a.b.c");
            result.RealAddress = await this.GetRealAddress(result.Address);
            var contentNode = node.SelectSingleNode(node.XPath + "//div[1]");
            result.Content = contentNode.InnerText.Replace("\r\n","").Replace("\t","");
            return result;
        }
        public async Task<string> GetRealAddress(string address)
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
                Process p = new Process();
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                p.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "phantomjs.exe");
                p.StartInfo.Arguments = String.Format(".\\_ReqItem.js \"{0}\"", address);
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                p.Start();
                string output = await p.StandardOutput.ReadToEndAsync();
                p.WaitForExit();
                return output;
            }
        }
        public async Task<string> GetHtml(string url)
        {
            Process p = new Process();
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            p.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "phantomjs.exe");
            p.StartInfo.Arguments = ".\\_Req.js " + url;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();
            string output = await p.StandardOutput.ReadToEndAsync();
            p.WaitForExit();
            return output;
        }
    }
}
