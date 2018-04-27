using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Domain.Grab
{
    public class SearchDataModel
    {
        public int ID { get; set; }
        /// <summary>
        /// 任务组
        /// </summary>
        public Guid TaskGroup { get; set; }
        /// <summary>
        /// 任务ID
        /// </summary>
        public int TaskID { get; set; }
        public int SoruceID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 平台地址
        /// </summary>
        public string SourceUrl { get; set; }
        /// <summary>
        /// 真实地址
        /// </summary>
        public string RealUrl { get; set; }
        /// <summary>
        /// 查询内容
        /// </summary>
        public string Content { get; set; }
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
