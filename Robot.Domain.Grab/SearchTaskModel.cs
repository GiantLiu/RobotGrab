using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Domain.Grab
{
    public class SearchTaskModel
    {
        public int ID { get; set; }
        /// <summary>
        /// 查询任务分组
        /// 一个关键字要查询很多平台，那么一个关键字分到一个组
        /// </summary>
        public Guid TaskGroup { get; set; }
        /// <summary>
        /// 查询指定平台
        /// </summary>
        public int SourceID { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}
