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
    /// 查询任务
    /// </summary>
    [Table("SearchTask")]
    public class SearchTask
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
        [MaxLength(100)]
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
