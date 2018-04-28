using Robot.Domain.Grab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.IService.Grab
{
    public interface ISearchService
    {
        /// <summary>
        /// 拿到当前页码的搜索结果
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<string> GetHtmlAsync(string keyword, int page);
        /// <summary>
        /// 根据Html分析出对应列表数据
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        Task<List<SearchDataModel>> GetDataAsync(string html);
        /// <summary>
        /// 拿到搜索结果真实URL地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        Task<string> GetRealAddressAsync(string address);
    }
}
