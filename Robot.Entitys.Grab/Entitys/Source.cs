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
    /// 数据来源
    /// </summary>
    [Table("Source")]
    public class Source
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 识别码
        /// </summary>
        [MaxLength(100)]
        public string Code { get; set; }
        /// <summary>
        /// 主页地址
        /// </summary>
        [MaxLength(1000)]
        public string Home { get; set; }

    }
}
