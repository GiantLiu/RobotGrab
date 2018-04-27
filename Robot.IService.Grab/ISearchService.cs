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
        Task<string> GetHtmlAsync(string keyword, int page);
        Task<List<SearchDataModel>> GetDataAsync(string html);
    }
}
