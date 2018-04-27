using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Entitys.Grab
{
    /// <summary>
    /// 搜索数据
    /// </summary>
    [Table("SearchData")]
    public class SearchData
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
        [MaxLength(100)]
        public string Title { get; set; }
        /// <summary>
        /// 平台地址
        /// </summary>
        [MaxLength(1000)]
        public string SourceUrl { get; set; }
        /// <summary>
        /// 真实地址
        /// </summary>
        [MaxLength(1000)]
        public string RealUrl { get; set; }
        /// <summary>
        /// 查询内容
        /// </summary>
        [MaxLength(2000)]
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
