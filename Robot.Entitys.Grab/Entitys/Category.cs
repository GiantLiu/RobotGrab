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
    /// 分类
    /// </summary>
    [Table("Category")]
    public class Category
    {
        public int ID { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
